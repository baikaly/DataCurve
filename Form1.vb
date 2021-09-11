Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Chart.Curve
Imports System.ComponentModel
'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.Data.OleDb
Imports System.IO
Imports System.IO.Ports



Public Class Form1
    Friend WithEvents t1 As New System.Windows.Forms.Timer
    Dim Rate As Integer = 115200
    Dim RevMsg As String = ""
    Dim UpdateTime As String = ""
    Dim LastUpdat As String = ""
    Dim MaxSensorNumber = 9
    Dim TempADC(MaxSensorNumber - 1) As String
    Dim PowerADC(MaxSensorNumber - 1) As String
    Dim No As Integer = 0
    Dim SenCnt As Integer
    Dim isCommportChanged As Boolean = False
    Dim TempDic As New Dictionary(Of Integer, Double)
    Dim VccDic As New Dictionary(Of Integer, Double)
    Dim SensDic As New Dictionary(Of String, Integer)
    Dim val(MaxSensorNumber - 1) As Integer
    Dim x As Integer = 0
    Dim Trx As New Stopwatch
    Dim isDataUpdate(MaxSensorNumber - 1) As Boolean
    Sub New()
        MyBase.KeyPreview = True
        InitializeComponent()
    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Curve1.CurveNumber = 1
        Curve1.CurveLabelText(0) = " "
        Curve1.CurveColor(0) = Color.Red

        'Curve1.CurveLabelText(1) = ""
        'Curve1.CurveLabelText(2) = ""
        'Curve1.CurveColor(0) = Color.Red
        'Curve1.CurveColor(1) = Color.Blue
        'Curve1.CurveColor(2) = Color.Yellow

        For i = 0 To MaxSensorNumber - 1
            TempADC(i) = "0"
            PowerADC(i) = "0"
        Next
        Me.Text = "RSSI curve demo v" & Application.ProductVersion
        Try
            Dim r As Boolean = ReadTempConfile(Application.StartupPath & "\TempConfig.csv")
            If Not r Then MsgBox("读取ADC配置文件失败,请检查TempConfig.csv文件设置!")
            Call CheckPort()
        Catch ex As Exception

        End Try

        t1.Interval = 100

    End Sub

    Private Sub MsgDepack(msg As String)
        Dim SenID As String, SenNo As Integer, SenValue As String, tmp, Dcnt
        RevMsg = ""

        Dim msgStart = InStr(msg, "[")
        Dim msgStop = InStr(msg, "]")

        If msgStart > 0 And msgStop > 0 And msgStop - msgStart > 0 Then
            msg = Mid(msg, msgStart + 1, msgStop - msgStart)
            If msg.Contains(",") Then
                tmp = Split(msg, ",")
                Dcnt = UBound(tmp)

                If Dcnt >= 2 Then
                    SenID = tmp(0).ToString
                    If Not SenID = "" And IsNumeric(tmp(1)) Then
                        If Not SensDic.ContainsKey(tmp(0)) Then
                            SenCnt = SenCnt + 1
                            SenNo = SenCnt - 1
                            SensDic.Add(SenID, SenNo)
                        Else
                            SenNo = SensDic.Item(SenID)
                            If Not IsNumeric(SenNo) Then
                                Debug.Print("字典里的SenNo非法")
                                Exit Sub
                            End If
                        End If


                        SenValue = tmp(1)
                        'If TempDic.Item(SenValue) > 60 Or TempDic.Item(SenValue) < 20 Then
                        '    Dim a = 1
                        'End If

                        If SenNo <= UBound(TempADC) Then
                            TempADC(SenNo) = SenValue
                            isDataUpdate(SenNo) = True
                        End If


                    End If
                End If
                If Dcnt = 3 Then
                    If IsNumeric(tmp(2)) And SenNo <= UBound(PowerADC) Then PowerADC(SenNo) = tmp(2)
                End If
                If Dcnt < 2 Or Dcnt > 3 Then
                    Debug.Print("未能在此次的接收消息中解析到数据")
                End If
            End If
        End If




    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not Combo2.Text = "" Then
            If IsNumeric(Combo2.Text) Then
                t1.Interval = CInt(Combo2.Text)
            End If
        End If
        t1.Start()
        Button3.Enabled = False
        Button2.Enabled = True
    End Sub


    Private Sub t1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles t1.Tick


        If Not CheckBox1.Checked And Not CheckBox2.Checked Then                   '真实数据

            If Not UpdateTime = LastUpdat Then
                MsgDepack(RevMsg)
                PlotData(TempADC)
                LastUpdat = UpdateTime
            End If



        ElseIf CheckBox2.Checked Then                 'RAIL
            SerialPort1.Write("getrssi" + vbCr)
            If InStr(RevMsg, "rssi:") > 0 Then
                Dim rssi = RevMsg.Substring(InStr(RevMsg, "-") - 1, 6)
                RevMsg = "[" & "RSSI," & rssi & ",0]"
                MsgDepack(RevMsg)
                PlotData(TempADC)
                RevMsg = ""
                WriteLog(rssi)
            End If


        Else                                  '模拟数据
            Select Case No
                Case 0
                    RevMsg = "[" + No.ToString + "," + CStr(x) + "," + "255]"
                Case 1
                    RevMsg = "[" + No.ToString + "," + CStr(CInt(Rnd() * 100) + 50) + "," + "155]"
                Case 2
                    RevMsg = "[" + No.ToString + "," + CStr(x + 50) + "," + "55]"
                Case Else
                    RevMsg = ""
            End Select
            If No < 2 Then
                No = No + 1
            Else
                No = 0
            End If
            If x < 1025 Then
                x = x + 1
            Else
                x = 0
            End If
            MsgDepack(RevMsg)
            PlotData(TempADC)
        End If





        'val(0) = Math.Sin(3.14 * (x Mod 360) / 180) * 70 '红线
        'val(1) = -50 + (Math.Sin(x * 0.035) * 5) + (Rnd() * 1)
        'val(2) = 30 + (Math.Sin(x * 0.035) * 9) + (Rnd() * 19)
        'val(3) = (Math.Sin(x * 0.035) * 80) + (Rnd() * 30)
        'Curve1.RealCurve(val)
        'x += 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        t1.Stop()
        Button3.Enabled = True
        Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PlotData(DataArr() As String)
        Dim ADC_TEMP As Double, i As Integer
        Dim InvalidData As Integer = -999
        Dim r As New Random
        Dim m_Color As Color = Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
        Dim HaveNewData As Boolean = False
        'Dim li As New List(Of String)

        For i = 0 To MaxSensorNumber - 1
            ' val(i) = InvalidData
        Next


        If Curve1.CurveNumber < SenCnt Then
            Dim PreCurveNumber = Curve1.CurveNumber
            Curve1.CurveNumber = SenCnt
            Curve1.CurveColor(0) = Color.Red
            For i = 1 To SenCnt - 1
                Curve1.CurveColor(i) = Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
            Next
            Application.DoEvents()
        End If



        For i = 0 To SenCnt - 1
            If isDataUpdate(i) Then
                HaveNewData = True
                If Not DataArr(i) = "" Then
                    If IsNumeric(DataArr(i)) Then
                        'ADC_TEMP = CInt(DataArr(i))
                        ADC_TEMP = DataArr(i)
                        If TempDic.ContainsKey(ADC_TEMP) Then
                            val(i) = TempDic.Item(ADC_TEMP)
                            Curve1.CurveLabelText(i) = SensDic.Keys(i) & ":" + CStr(val(i)) + "℃"
                            Debug.Print("Val(" & i.ToString & ")=" & val(i))

                            Application.DoEvents()
                        ElseIf CheckBox2.Checked Then
                            val(i) = ADC_TEMP
                            Curve1.CurveLabelText(i) = SensDic.Keys(i) & ":" + ADC_TEMP.ToString
                            Debug.Print("Val(" & i.ToString & ")=" & val(i))
                        End If
                    End If
                End If

            End If
        Next


        'If isDataUpdate(0) Then
        '    If Not DataArr(0) = "" Then
        '        If IsNumeric(DataArr(0)) Then
        '            ADC_TEMP = CInt(DataArr(0))
        '            If TempDic.ContainsKey(ADC_TEMP) Then
        '                val(0) = TempDic.Item(ADC_TEMP)
        '                Curve1.CurveLabelText(0) = "Sensor1:" + val(0).ToString + "℃"
        '            End If
        '        End If
        '    End If
        'End If
        'If isDataUpdate(1) Then
        '    If Not DataArr(1) = "" Then
        '        If IsNumeric(DataArr(1)) Then
        '            ADC_TEMP = CInt(DataArr(1))
        '            If TempDic.ContainsKey(ADC_TEMP) Then
        '                val(1) = TempDic.Item(ADC_TEMP)
        '                Curve1.CurveLabelText(1) = "Sensor2:" + val(1).ToString + "℃"
        '            End If
        '        End If
        '    End If
        'End If
        'If isDataUpdate(2) Then
        '    If Not DataArr(2) = "" Then
        '        If IsNumeric(DataArr(2)) Then
        '            ADC_TEMP = CInt(DataArr(2))
        '            If TempDic.ContainsKey(ADC_TEMP) Then
        '                val(2) = TempDic.Item(ADC_TEMP)
        '                Curve1.CurveLabelText(2) = "Sensor3:" + val(2).ToString + "℃"
        '            End If
        '        End If
        '    End If
        'End If


        If HaveNewData Then
            For i = 0 To UBound(isDataUpdate)
                isDataUpdate(i) = False
            Next
            Curve1.RealCurve(val)
            Application.DoEvents()
        Else
            'Dim a = 1
        End If

        'x += 1
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer
        Dim CurveCnt As Integer = Curve1.CurveNumber
        Dim c(CurveCnt) As Color
        x = 0

        TextBox1.Clear()
        For i = 0 To CurveCnt - 1
            c(i) = Curve1.CurveColor(i)
        Next
        Curve1.RealCurveInit()
        For i = 0 To Curve1.CurveNumber
            Curve1.CurveColor(i) = c(i)
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Curve1.ZoomReset()
    End Sub


    Private Sub Button1122_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Filter = "图像文件(*.jpg;*.gif;*.png)|*.jpg;*.gif;*.png"

        If fd.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim fn As Image = Image.FromFile(fd.FileName)

            Dim bitmap As New Bitmap(fn)

            Dim handle As IntPtr = bitmap.GetHicon()

            Dim myCursor As New Cursor(handle)

            Me.Cursor = myCursor

        End If

    End Sub

    Delegate Sub RxReadMethodDelegate(ByVal txt As String)
    Private Sub Serialport_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim s As String = ""
        Dim RxRead As New RxReadMethodDelegate(AddressOf RxReadMethod)
        Me.BeginInvoke(RxRead, s)
    End Sub
    Dim RevTxt As String = ""
    Private Sub RxReadMethod(ByVal str As String)
        Dim Rev As String = ""
        Dim r As Boolean
        If Trx.IsRunning = False Then Trx.Start()

        Try
            If Trx.ElapsedMilliseconds < 30 Then
                If SerialPort1.BytesToRead > 0 Then
                    RevTxt = RevTxt + SerialPort1.ReadExisting
                End If
            Else
                If Not IsNothing(RevTxt) Then
                    UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    RevMsg = RevTxt.Replace(vbLf, "").Replace(" ", "").Replace("]", "]" & vbCrLf)
                    TextBox1.AppendText(RevMsg)
                    If Not CheckBox2.Checked Then
                        WriteLog(UpdateTime & "," & RevTxt & vbCrLf)
                    End If
                End If
                RevTxt = ""
                Trx.Stop()
                Trx.Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "读取串口数据出错")
        End Try
    End Sub
    Function WriteLog(t As String) As Boolean
        Dim DataPath = Application.StartupPath & "\SerialLog.log"
        Dim StrWriter As New StreamWriter(DataPath, True)
        Try
            StrWriter.WriteLine(t)
            StrWriter.Close()
            Return True
        Catch ex As Exception
            StrWriter.Close()
            MessageBox.Show(ex.Message, "写入Log时出错,错误产生于函数WriteLog")
            Return False
        End Try
    End Function

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Curve1.Size = New Size(Me.Width - 10, Me.Height - 90)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Try
            If Not Combo1.Text = "" Then
                If SerialPort1.IsOpen = True Then
                    SerialPort1.Close()
                    Combo1.BackColor = Color.White
                    Button7.Text = "打开串口"
                Else
                    Call setSerialPort1(Combo1.Text, Rate)
                    SerialPort1.Open()
                    Combo1.BackColor = Color.GreenYellow
                    Button7.Text = "关闭串口"
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Label_Port_DoubleClick")
        End Try


    End Sub

    Private Function ReadTempConfile(Path As String) As Boolean

        Dim StrReader As StreamReader, LineData As String
        Dim adc As String, temp, Vcc As String, tmp
        Try
            StrReader = File.OpenText(Path)
            TempDic.Clear()
            While Not StrReader.EndOfStream
                LineData = StrReader.ReadLine
                If LineData.Contains(",") Then
                    LineData = LineData.Replace(" ", "")
                    If LineData.Length - LineData.Replace(",", "").Length = 1 Or LineData.Length - LineData.Replace(",", "").Length = 2 Then
                        tmp = Split(LineData, ",")
                        adc = tmp(0)
                        temp = tmp(1)
                        If UBound(tmp) = 3 Then Vcc = tmp(2)
                        If IsNumeric(adc) And IsNumeric(temp) Then
                            TempDic.Add(adc, temp)
                            If UBound(tmp) = 3 Then
                                Vcc = tmp(2)
                                VccDic.Add(adc, Vcc)
                            End If

                        End If
                    End If
                End If
            End While
            StrReader.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fail to read config file", MessageBoxButtons.OK)
            Return False
        End Try

    End Function

    Private Sub Label_Port_DoubleClick(sender As Object, e As EventArgs) Handles Label_Port.DoubleClick
        'Dim r As Boolean
        Try
            If Not Combo1.Text = "" Then
                If SerialPort1.IsOpen = True Then
                    SerialPort1.Close()
                    Combo1.BackColor = Color.White
                Else
                    Call setSerialPort1(Combo1.Text, Rate)
                    If SerialPort1.IsOpen = False Then
                        SerialPort1.Open()
                        Combo1.BackColor = Color.GreenYellow
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Label_Port_DoubleClick")
        End Try

    End Sub

    Private Sub Combo1_TextChanged(sender As Object, e As EventArgs) Handles Combo1.TextChanged
        isCommportChanged = True
        Try
            SerialPort1.Close()
            Combo1.BackColor = Color.White
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Combo1_DropDown(sender As Object, e As EventArgs) Handles Combo1.DropDown
        Call CheckPort()
    End Sub

    Private Sub CheckPort()
        Dim ports() As String = SerialPort.GetPortNames
        Combo1.BeginUpdate()
        Combo1.Items.Clear()
        If ports.Length > 0 Then
            For i = 0 To ports.Length - 1
                Combo1.Items.Add(ports(i))
            Next
        End If
        Combo1.EndUpdate()
        If Combo1.Items.Count > 0 Then
            Combo1.SelectedIndex = Combo1.Items.Count - 1
        Else
            Combo1.Text = ""
        End If
    End Sub
    Private Function setSerialPort1(Port As String, rate As Integer) As Boolean
        Try
            With SerialPort1()
                If .IsOpen = True Then .Close()
                .PortName = Port
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Parity = IO.Ports.Parity.None
                .BaudRate = rate
                .RtsEnable = True
                .ReceivedBytesThreshold = 1
            End With
            isCommportChanged = False
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误产生于函数setSerialPort1")
            Return False
        End Try

    End Function



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If Button6.Text = "隐藏源数据" Then
            Button6.Text = "显示源数据"
            TableLayoutPanel2.ColumnStyles.Item(1).Width = 0
        ElseIf Button6.Text = "显示源数据" Then
            Button6.Text = "隐藏源数据"
            TableLayoutPanel2.ColumnStyles.Item(1).Width = 30
        End If





        'Dim i As Integer, val2(3) As Integer
        'Curve1.CurveNumber = 2


        'For i = 0 To 20
        '    val2(0) = 25
        '    Curve1.CurveColor(0) = Color.Red
        '    Curve1.CurveLabelText(0) = "No.0  " & val2(0).ToString
        '    Curve1.RealCurve(val2)
        '    Application.DoEvents()
        'Next
        'For i = 0 To 20
        '    val2(0) = 25
        '    Curve1.CurveColor(0) = Color.Red
        '    Curve1.CurveLabelText(0) = "No.1  " & val2(0).ToString
        '    Curve1.RealCurve(val2)
        '    Application.DoEvents()
        'Next

        ''Curve1.CurveNumber = 2

        'For i = 0 To 20
        '    val2(0) = 25
        '    val2(1) = 50
        '    Curve1.CurveColor(0) = Color.Red
        '    Curve1.CurveColor(1) = Color.Yellow
        '    Curve1.CurveLabelText(0) = "No.0  " & val2(0).ToString
        '    Curve1.CurveLabelText(1) = "No.1  " & val2(1).ToString
        '    Curve1.RealCurve(val2)
        '    Application.DoEvents()
        'Next

        'Curve1.ShowCh(0)


    End Sub


End Class


