Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Chart.Curve
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Form1
    Friend WithEvents t1 As New System.Windows.Forms.Timer
    Sub New()
        MyBase.KeyPreview = True

        InitializeComponent()

    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Curve1.CurveLabelText(0) = "通道一"
        Curve1.CurveLabelText(1) = "通道二"
        Curve1.CurveLabelText(2) = "通道三"
        Curve1.CurveLabelText(3) = "通道四"
        Curve1.CurveColor(0) = Color.Red
        Curve1.CurveColor(1) = Color.Blue
        Curve1.CurveColor(2) = Color.Yellow
        Curve1.CurveColor(3) = Color.PaleVioletRed


        t1.Interval = 40

    End Sub
    Sub PrinterSettingsSub()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '
        t1.Start()
    End Sub

    Dim val(4) As Integer
    Dim x As Integer = 0
    Private Sub t1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles t1.Tick
        val(0) = Math.Sin(3.14 * (x Mod 360) / 180) * 700 '红线

        val(1) = -500 + (Math.Sin(x * 0.035) * 50) + (Rnd() * 10)

        val(2) = 300 + (Math.Sin(x * 0.035) * 90) + (Rnd() * 190)

        val(3) = (Math.Sin(x * 0.035) * 800) + (Rnd() * 30)

        Curve1.RealCurve(val)
        x += 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        t1.Stop()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        val(0) = Math.Sin(3.14 * (x Mod 360) / 180) * 700 '红线

        val(1) = -500 + (Math.Sin(x * 0.035) * 50) + (Rnd() * 10)

        val(2) = 300 + (Math.Sin(x * 0.035) * 90) + (Rnd() * 30)

        val(3) = (Math.Sin(x * 0.035) * 800) + (Rnd() * 30)

        Curve1.RealCurve(val)
        x += 1
    End Sub

    Private Sub Curve1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        x += 1
        TextBox1.Text = x
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        x = 0
        Curve1.RealCurveInit()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Curve1.ZoomReset()
    End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    Curve1.ZoomReset()
    'End Sub

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

    Dim CommandStr1 As New CommandStr2
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim scn As New SqlConnection(CommandStr2.ConnectStr)

        'Dim CommandSelectString As String = " SELECT CH1,CH2,CH11,CH22 FROM "
        'Dim TabelString As String = " (SELECT distinct 'aa'=case when A.ddt_btime is null then b.ddt_btime else a.ddt_btime end , " & _
        '                             " isnull(A.ch1,0) as ch1,isnull(A.ch2, 0) as ch2, isnull(B.ch1,0) as ch11,isnull(B.ch2, 0) as ch22 " & _
        '                            " FROM VIEW1 A full  JOIN VIEW2 B ON A.DDT_BTIME = B.DDT_BTIME ) A"
        'Dim CommandWhereString As String = " order by AA"
        'Dim str = CommandSelectString & TabelString & CommandWhereString

        Dim str As String = "select ddt_btime,ddt_volt,ddt_curr from frdetaildata_1 where ddt_cellno=1 order by ddt_btime "
        Dim scm As New SqlCommand(str, scn)
        Dim sda As New SqlDataAdapter(scm)
        Dim ds As New DataSet
        Dim datar As SqlDataReader

        'da.Fill(ts, CommandStr1.TabelName)
        'DataGridView1.DataSource = ts.Tables(0).DefaultView


        sda.Fill(ds)
        'DataGridView1.DataSource = .DefaultView
        'Curve1.ShowCurve(ts.Tables(0))




        Curve1.DataCoreStyle = DataCoreStyleEnum.XOne

        Curve1.ShowZeroStyle = ShowDataStyle.sDefault

        Curve1.ShowCurve(ds, 0)

        Curve1.CurveColor(0) = Color.Red
        Curve1.CurveColor(1) = Color.Blue
        Curve1.CurveColor(2) = Color.Yellow
        Curve1.CurveColor(3) = Color.PaleVioletRed




        scn.Close()
        scn.Dispose()
        scm.Dispose()
        sda.Dispose()
        ds.Dispose()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Curve1.Size = New Size(Me.Width - 10, Me.Height - 90)
    End Sub
End Class



Public Class CommandStr

    Dim base As String

    Dim ConnectString As String = "server=yanzhenpc;database=test;user=yanzhen;password=123"

    Dim CommandSelectString As String = " Select * from "
    Dim TabelString As String = " CurveDataTest"
    Dim CommandWhereString As String = "" ' " where t2.书名=t1.书名"



    Public Property ConnectStr() As String
        Get
            Return ConnectString
        End Get
        Set(ByVal value As String)
            ConnectString = value
        End Set
    End Property

    Public ReadOnly Property CommandStr() As String
        Get
            Return CommandSelectString & TabelString & CommandWhereString
        End Get

    End Property

    Public Property TabelName() As String
        Get
            Return TabelString
        End Get
        Set(ByVal value As String)
            TabelString = value
        End Set
    End Property

    Sub New()

    End Sub
    Sub New(ByVal servername As String, ByVal base As String, ByVal user As String, ByVal passwrod As String)

    End Sub
End Class


Public Class CommandStr2

    Public datahead As Integer
    Public datalen As Integer
    Public ExcelYThiss As String
    Public ExcelXThiss As String
    Public ExcelTabel As String
    Public ExcelWhere As String

    Const ConnectString As String = "server=.;database=roofercust;user=sa;password=sa"

    'Dim ConnectExcelString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & ExcelPathstr & ";Extended Properties=""Excel 8.0;HDR=NO"""
    Dim ExcelPathstr As String


    '    If False Then
    ''指定返回例和搜索条件，在所有Sheet1空间范围搜索
    '        mySelectData = "Select F5,F6,F7 from [Sheet1$] " & WhereStr & ";"
    '        mySelectTime = "Select F" & XAsitAdd & " from [Sheet1$] " & WhereStr & ";"
    '    Else
    ''指定返回例和搜索条件，并在指定地址的Sheet1空间范围搜索
    '        mySelectData = "Select F5,F6,F7 from [Sheet1$A" & DataPen & ":G" & DataLen & "]" & WhereStr & ";"
    '        mySelectTime = "Select F" & XAsitAdd & " from [Sheet1$A" & DataPen & ":D" & DataLen & "]" & WhereStr & ";"
    '    End If


    'Dim CommandSelectString As String = " Select a.ddt_curr as ch1,b.ddt_curr as ch2 from "
    'Dim TabelString As String = " (select ddt_btime,ddt_curr from FRdetaildata_1 where ddt_cellno = 1) a , " & _
    '                            " (select ddt_btime,ddt_curr from FRdetaildata_1 where ddt_cellno = 2) b "
    'Dim CommandWhereString As String = " where a.ddt_btime = b.ddt_btime order by A.ddt_btime"

    ' Dim CommandSelectString As String = " SELECT distinct 'aa'=case when A.ddt_btime is null then b.ddt_btime else a.ddt_btime end , A.ch1,A.ch2,B.ch1,B.ch2"
    Dim CommandSelectString As String = " SELECT CH1,CH2,CH11,CH22 FROM "
    Dim TabelString As String = " (SELECT distinct 'aa'=case when A.ddt_btime is null then b.ddt_btime else a.ddt_btime end , " & _
                                 " isnull(A.ch1,0) as ch1,isnull(A.ch2, 0) as ch2, isnull(B.ch1,0) as ch11,isnull(B.ch2, 0) as ch22 " & _
                                " FROM VIEW1 A full  JOIN VIEW2 B ON A.DDT_BTIME = B.DDT_BTIME ) A"
    Dim CommandWhereString As String = " order by AA"


    '' Dim CommandSelectString As String = " SELECT distinct 'aa'=case when A.ddt_btime is null then b.ddt_btime else a.ddt_btime end , A.ch1,A.ch2,B.ch1,B.ch2"
    'Dim CommandSelectString As String = " SELECT distinct 'aa'=case when A.ddt_btime is null then b.ddt_btime else a.ddt_btime end , " & _
    '                                    " isnull(A.ch1,0) as ch1,isnull(A.ch2, 0) as ch2, isnull(B.ch1,0) as ch1,isnull(B.ch2, 0) as ch2"
    'Dim TabelString As String = " FROM VIEW1 A full  JOIN VIEW2 B ON A.DDT_BTIME = B.DDT_BTIME order by 1"
    'Dim CommandWhereString As String = "" '" where ddt_cellno=1 order by ddt_btime"


    Dim CommandSelectString2 As String = " Select ddt_btime from "
    Dim TabelString2 As String = " FRdetaildata_11"
    Dim CommandWhereString2 As String = " where ddt_cellno=1"


    Public Shared ReadOnly Property ConnectStr() As String
        Get
            Return ConnectString
        End Get

    End Property

    Public ReadOnly Property CommandStr() As String
        Get
            Return CommandSelectString & TabelString & CommandWhereString
        End Get

    End Property

    Public ReadOnly Property CommandStr2() As String
        Get
            Return CommandSelectString2 & TabelString2 & CommandWhereString2
        End Get

    End Property

    Public Property TabelName() As String
        Get
            Return TabelString
        End Get
        Set(ByVal value As String)
            TabelString = value
        End Set
    End Property

    Public Property TabelName2() As String
        Get
            Return TabelString2
        End Get
        Set(ByVal value As String)
            TabelString2 = value
        End Set
    End Property






    Public WriteOnly Property ExcelPath() As String
        Set(ByVal value As String)
            ExcelPathstr = value
        End Set
    End Property

    Public ReadOnly Property ConnectExcelStr() As String
        Get
            Return "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & ExcelPathstr & ";Extended Properties=""Excel 8.0;HDR=NO"""
        End Get
    End Property

    Public ReadOnly Property CommandExcelStr() As String
        Get
            Return "Select " & ExcelYThiss & " from [" & ExcelTabel & "$] " & " where " & ExcelWhere
        End Get
    End Property

    Public ReadOnly Property CommandExcelStr2() As String
        Get
            Return "Select " & ExcelXThiss & " from [" & ExcelTabel & "$] " & " where " & ExcelWhere
        End Get
    End Property


    Sub New()

    End Sub
    Sub New(ByVal servername As String, ByVal base As String, ByVal user As String, ByVal passwrod As String)

    End Sub
End Class