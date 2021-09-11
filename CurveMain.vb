
Public Class Curve

    Dim NewOne As Boolean

 
    Sub New()
        Me.Location = New System.Drawing.Point(12, 12)
        Me.Size = New System.Drawing.Size(550, 350)
        Me.CurveObj.Location = New System.Drawing.Point(0, 0)
        Me.CurveObj.Size = Me.Size
        Me.BackColor = Color.Black
        Me.Controls.Add(Me.CurveObj)

        Me.CurveState.Cursor = Cursors.Default
        BackStyle.StrColor = New SolidBrush(Color.Yellow)
        BackStyle.LabelColor = New SolidBrush(Color.Yellow)
        BackStyle.DataLabelColor = New SolidBrush(Color.Yellow)




        NewDataCount = 0
        Lstepi = 0

        BackStyle.XAxisMin = 0
        BackStyle.XAxisMax = 100
        BackStyle.YAxisMax = 200
        BackStyle.YAxisMin = -100
        BackStyle.XLineNumber = 10       '网格横线的数量
        BackStyle.YLineNumber = 10
        BackStyle.XAxisGridMax = 10      '刻度点的数量
        BackStyle.YAxisGridMax = 5

        ForeStyle.CurveNumber = 3
        ForeStyle.CurveBuffMax = 1000000

        BackStyle.LeftWidth = 40         '边距
        BackStyle.RightWidth = 14
        BackStyle.TopWidth = 30
        BackStyle.BottomWidth = 30

        BackStyle.XHead = 4              '网格横线头部延伸长度
        BackStyle.YHead = 8

        ForeStyle.ZoomPoint = New Point
        ForeStyle.ZoomRect = New Rectangle

        BackStyle.BackGridNews_ = True
        BackStyle.BackStrNews_ = True
        ForeStyle.SmoothingMode = True

        BackStyle.StrFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        BackStyle.LabelFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))

        BackStyle.StrColor.Color = Color.Cyan
        BackStyle.LabelColor.Color = Color.Cyan
        BackStyle.DataLabelColor.Color = Color.Cyan


        BackGridPen.DashStyle = Drawing2D.DashStyle.Dot
        ZoomPen.DashStyle = Drawing2D.DashStyle.Dot
        NewOne = True
    End Sub



    Sub BackTyleInit()
        If NewOne Then


            BackBitmap = New Bitmap(Me.Width, Me.Height)
            ForeBitmap = New Bitmap(Me.Width, Me.Height)
            Me.CurveObj.Size = Me.Size
            Gr = Graphics.FromImage(BackBitmap)



            BackStyle.YPoleIn = (Me.CurveObj.Height - (BackStyle.TopWidth + BackStyle.BottomWidth)) / (BackStyle.XLineNumber * BackStyle.YAxisGridMax)
            BackStyle.XPoleIn = (Me.CurveObj.Width - (BackStyle.LeftWidth + BackStyle.RightWidth)) / (BackStyle.YLineNumber * BackStyle.XAxisGridMax)

            BackStyle.Width = BackStyle.XPoleIn * BackStyle.XAxisGridMax * BackStyle.YLineNumber
            BackStyle.Height = BackStyle.YPoleIn * BackStyle.YAxisGridMax * BackStyle.XLineNumber

            BackStyle.WidthEndD = (BackStyle.LeftWidth + BackStyle.Width)
            BackStyle.HeightEndD = (Me.Height - BackStyle.BottomWidth)
            BackStyle.TopIn = (Me.Height - BackStyle.BottomWidth - BackStyle.Height)
            BackStyle.RightIn = Me.Width - BackStyle.WidthEndD
            BackStyle.ZoreYLocation = BackStyle.HeightEndD - _
            (BackStyle.Height / (BackStyle.YAxisMax - BackStyle.YAxisMin) * Math.Abs(BackStyle.YAxisMin))

            BackStyle.NegativeHeight = BackStyle.HeightEndD - BackStyle.ZoreYLocation
            BackStyle.PositiveHeight = BackStyle.Height - BackStyle.NegativeHeight

            BackStyle.YIn = (Me.CurveObj.Width - (BackStyle.LeftWidth + BackStyle.RightWidth)) / BackStyle.YLineNumber
            BackStyle.XIn = (Me.CurveObj.Height - (BackStyle.TopWidth + BackStyle.BottomWidth)) / BackStyle.XLineNumber


            BackXLine = New BackLineStruct(BackStyle.XLineNumber) {}
            BackYLine = New BackLineStruct(BackStyle.YLineNumber) {}
            BackXString = New Point(BackStyle.XLineNumber) {}
            BackYString = New Point(BackStyle.YLineNumber) {}
            BackXPoleLine = New BackLineStruct(BackStyle.YLineNumber * BackStyle.XAxisGridMax) {}
            BackYPoleLine = New BackLineStruct(BackStyle.XLineNumber * BackStyle.YAxisGridMax) {}

            BackXLineZoom = New BackLineStruct(BackStyle.XLineNumber) {}
            BackYLineZoom = New BackLineStruct(BackStyle.YLineNumber) {}
            BackXStringZoom = New Point(BackStyle.XLineNumber) {}
            BackYStringZoom = New Point(BackStyle.YLineNumber) {}
            'BackXPoleLineZoom = New BackLineStruct(BackStyle.YLineNumber * BackStyle.XAxisGridMax) {}
            'BackYPoleLineZoom = New BackLineStruct(BackStyle.XLineNumber * BackStyle.YAxisGridMax) {}


            ReDim XnumberStr(BackStyle.YLineNumber)
            ReDim YnumberStr(BackStyle.XLineNumber)
            ReDim ZoomStr(BackStyle.YLineNumber)

            '曲线标签
            'ReDim CurveLabelStr(ForeStyle.CurveNumber)
            CurveLabelPoint = New BackLineStruct(ForeStyle.CurveNumber) {}

            ForeStyle.CurvePointNumber = BackStyle.XAxisMax - BackStyle.XAxisMin
            ForeStyle.CurveXMoveIn = BackStyle.Width / ForeStyle.CurvePointNumber

            DispCurve = New Point(ForeStyle.CurveNumber)() {}
            DispCurvet = New Point(ForeStyle.CurveNumber)() {}
            CurveBuff = New Point(ForeStyle.CurveNumber)() {}

            CurvePen = New Pen(ForeStyle.CurveNumber) {}
            For index As Integer = 0 To ForeStyle.CurveNumber - 1
                DispCurve(index) = New Point(ForeStyle.CurvePointNumber) {}
                DispCurvet(index) = New Point(ForeStyle.CurvePointNumber) {}
                CurveBuff(index) = New Point(ForeStyle.CurveBuffMax) {}
                CurvePen(index) = New Pen(Color.Red, 2)
            Next


            CurvePen(0).Color = Color.Red
            CurvePen(0).Width = 1
            CurvePen(0).DashStyle = Drawing2D.DashStyle.Solid
            CurvePen(1).Color = Color.Blue
            CurvePen(1).Width = 1
            CurvePen(1).DashStyle = Drawing2D.DashStyle.Solid
            CurvePen(2).Color = Color.Cyan
            CurvePen(2).Width = 1
            CurvePen(2).DashStyle = Drawing2D.DashStyle.Solid
            'CurvePen(3).Color = Color.Yellow
            'CurvePen(3).Width = 1
            'CurvePen(3).DashStyle = Drawing2D.DashStyle.Solid


            Me.CurveState.Location = New Point(Me.CurveObj.Width / 10 * 7, 0)
            Me.CurveState.Size = New Size(Me.CurveObj.Width / 10 * 3, BackStyle.HeightEndD - BackStyle.Height)
            Me.CurveState.BackColor = Me.CurveObj.BackColor
            Me.CurveObj.Controls.Add(Me.CurveState)


        End If

    End Sub

    Sub CurveLabelInit()
        Dim labelWidth As Integer
        Dim strSize As SizeF

        BackLabelBmp = BackBitmap.Clone
        Dim Gr As Graphics = Graphics.FromImage(BackLabelBmp)
        labelWidth = (Me.CurveObj.Width / 10 * 7 - BackStyle.LeftWidth) / ForeStyle.CurveNumber


        For index As Integer = 0 To ForeStyle.CurveNumber - 1
            If CurveLabelStr(index) = Nothing Then
                CurveLabelStr(index) = "Label" & index
            End If
            strSize = Gr.MeasureString(CurveLabelStr(index), BackStyle.LabelFont)
            CurveLabelPoint(index).P1.X = BackStyle.LeftWidth + index * labelWidth
            CurveLabelPoint(index).P2.X = CurveLabelPoint(index).P1.X + strSize.Width - 4
            CurveLabelPoint(index).P1.Y = Me.CurveState.Height / 2 + strSize.Height / 2 + 2
            CurveLabelPoint(index).P2.Y = CurveLabelPoint(index).P1.Y
            If CurveLabelStyle Then
                Gr.DrawString(CurveLabelStr(index), BackStyle.LabelFont, New SolidBrush(CurvePen(index).Color), _
                                New Point(CurveLabelPoint(index).P1.X, Me.CurveState.Height / 2 - strSize.Height / 2))
            Else
                Gr.DrawString(CurveLabelStr(index), BackStyle.LabelFont, BackStyle.LabelColor, _
                                New Point(CurveLabelPoint(index).P1.X, Me.CurveState.Height / 2 - strSize.Height / 2))
            End If

            Gr.DrawLine(CurvePen(index), CurveLabelPoint(index).P1, CurveLabelPoint(index).P2)

        Next

    End Sub

    '动态曲线部分

    Sub DrawBackXAxisLine(ByRef bm As Bitmap, ByVal drawLineStr As Boolean)
        Dim Gr As Graphics = Graphics.FromImage(bm)
        Dim indext As Integer
        'YAxis刻度,网格横线
        For index As Integer = 0 To BackStyle.XLineNumber * BackStyle.YAxisGridMax
            BackYPoleLine(index).P1.X = BackStyle.LeftWidth
            BackYPoleLine(index).P1.Y = (Me.Height - BackStyle.BottomWidth) - index * BackStyle.YPoleIn '- BackStyle.YPoleIn 
            BackYPoleLine(index).P2.X = BackStyle.LeftWidth + 5
            BackYPoleLine(index).P2.Y = BackYPoleLine(index).P1.Y
            Gr.DrawLine(BackPolePen, BackYPoleLine(index).P1, BackYPoleLine(index).P2)
            If index Mod BackStyle.YAxisGridMax = 0 Then
                indext = index / BackStyle.YAxisGridMax
                BackXLine(indext).P1.X = BackStyle.LeftWidth - BackStyle.XHead
                BackXLine(indext).P1.Y = BackYPoleLine(index).P1.Y
                BackXLine(indext).P2.X = (BackStyle.LeftWidth + BackStyle.Width)
                BackXLine(indext).P2.Y = BackXLine(indext).P1.Y
                '文字
                YnumberStr(indext) = BackStyle.YAxisMin + ((indext) * ((BackStyle.YAxisMax - BackStyle.YAxisMin) / BackStyle.XLineNumber))
                BackStyle.StrSize = Gr.MeasureString(YnumberStr(indext), BackStyle.StrFont)
                BackXString(indext).X = BackXLine(indext).P1.X - (BackStyle.StrSize.Width)
                BackXString(indext).Y = BackXLine(indext).P1.Y - (BackStyle.StrSize.Height / 2)
                If drawLineStr Then
                    Gr.DrawString(YnumberStr(indext), BackStyle.StrFont, BackStyle.StrColor, BackXString(indext))
                    Gr.DrawLine(BackGridPen, BackXLine(indext).P1, BackXLine(indext).P2)
                End If
            End If
        Next
    End Sub

    Sub DrawBackYAxisLine(ByRef bm As Bitmap)
        Dim Gr As Graphics = Graphics.FromImage(bm)
        ''XAxis刻度，网格竖线
        Dim indext As Integer
        For index As Integer = 0 To BackStyle.YLineNumber * BackStyle.XAxisGridMax
            BackXPoleLine(index).P1.X = BackStyle.LeftWidth + index * BackStyle.XPoleIn ' + BackStyle.XPoleIn
            BackXPoleLine(index).P1.Y = Me.Height - BackStyle.BottomWidth
            BackXPoleLine(index).P2.X = BackXPoleLine(index).P1.X
            BackXPoleLine(index).P2.Y = Me.Height - BackStyle.BottomWidth - 5
            Gr.DrawLine(BackPolePen, BackXPoleLine(index).P1, BackXPoleLine(index).P2)

            If index Mod BackStyle.XAxisGridMax = 0 Then
                indext = index / BackStyle.XAxisGridMax
                BackYLine(indext).P1.X = BackXPoleLine(index).P1.X
                BackYLine(indext).P1.Y = BackXPoleLine(0).P1.Y - BackStyle.Height
                BackYLine(indext).P2.X = BackXPoleLine(index).P1.X
                BackYLine(indext).P2.Y = Me.Height - BackStyle.BottomWidth + BackStyle.YHead
                '文字
                XnumberStr(indext) = BackStyle.XAxisMin + ((indext) * ((BackStyle.XAxisMax - BackStyle.XAxisMin) / BackStyle.YLineNumber))

                BackStyle.StrSize = Gr.MeasureString(XnumberStr(indext), BackStyle.StrFont)
                BackYString(indext).X = BackYLine(indext).P2.X - (BackStyle.StrSize.Width / 2)
                BackYString(indext).Y = BackYLine(indext).P2.Y

                If Not BackStyle.BackStrNews_ Then
                    Gr.DrawString(XnumberStr(indext), BackStyle.StrFont, BackStyle.StrColor, BackYString(indext))
                End If
                If Not BackStyle.BackGridNews_ Then
                    Gr.DrawLine(BackGridPen, BackYLine(indext).P1, BackYLine(indext).P2)
                End If

            End If
        Next
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Curve
        '
        Me.Name = "Curve"
        Me.Size = New System.Drawing.Size(694, 354)
        Me.ResumeLayout(False)

    End Sub
End Class
