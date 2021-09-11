Partial Public Class Curve


    Sub BackTyleInit(ByVal xmin As Integer, ByVal xmax As Integer)


        BackStyle.XAxisMin = xmin
        BackStyle.XAxisMax = xmax


        BackStyle.YPoleIn = (Me.CurveObj.Height - (BackStyle.TopWidth + BackStyle.BottomWidth)) / (BackStyle.XLineNumber * BackStyle.YAxisGridMax)
        BackStyle.XPoleIn = (Me.CurveObj.Width - (BackStyle.LeftWidth + BackStyle.RightWidth)) / (BackStyle.YLineNumber * BackStyle.XAxisGridMax)

        BackStyle.Width = BackStyle.XPoleIn * BackStyle.XAxisGridMax * BackStyle.YLineNumber
        BackStyle.Height = BackStyle.YPoleIn * BackStyle.YAxisGridMax * BackStyle.XLineNumber


        BackStyle.ZoreYLocation = BackStyle.HeightEndD - _
        (BackStyle.Height / (BackStyle.YAxisMax - BackStyle.YAxisMin) * Math.Abs(BackStyle.YAxisMin))

        BackStyle.NegativeHeight = BackStyle.HeightEndD - BackStyle.ZoreYLocation
        BackStyle.PositiveHeight = BackStyle.Height - BackStyle.NegativeHeight

        BackStyle.YIn = (Me.CurveObj.Width - (BackStyle.LeftWidth + BackStyle.RightWidth)) / BackStyle.YLineNumber
        BackStyle.XIn = (Me.CurveObj.Height - (BackStyle.TopWidth + BackStyle.BottomWidth)) / BackStyle.XLineNumber


        ForeStyle.CurvePointNumber = BackStyle.XAxisMax
        ForeStyle.CurveXMoveIn = BackStyle.Width / ForeStyle.CurvePointNumber

        DispCurve = New Point(ForeStyle.CurveNumber)() {}
        For index As Integer = 0 To ForeStyle.CurveNumber - 1
            DispCurve(index) = New Point(ForeStyle.CurvePointNumber) {}
        Next


    End Sub

    Sub DrawBackYAxisLine2(ByRef bm As Bitmap)
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
                XnumberStr(indext) = BackStyle.XAxisMin + (indext * (BackStyle.XAxisMax / BackStyle.YLineNumber))
                'XnumberStr(indext) = indext + Lstepi

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

    Sub ZoomInit()
        Dim newWidth, newLd, currXAxisMax As Integer '当前X轴最大值
        '如果是首次放大
        If ForeStyle.ZoomOne_ = False Then
            Lstepit = Lstepi
            BackStyle.XAxisMaxt = BackStyle.XAxisMax
            BackStyle.XAxisMint = BackStyle.XAxisMin
            Array.Copy(XnumberStr, ZoomStr, UBound(XnumberStr) + 1)
            Array.Copy(BackYString, BackYStringZoom, UBound(BackYString) + 1)
            Array.Copy(BackYLine, BackYLineZoom, UBound(BackXLine) + 1)
            Array.Copy(DispCurve, DispCurvet, UBound(DispCurvet))
            bmpTemp = ForeBitmap.Clone
        End If

        ForeBitmap = New Bitmap(Me.Width, Me.Height)
        Dim Gr As Graphics = Graphics.FromImage(ForeBitmap)

        If Lstepi > BackStyle.XAxisMax Then
            currXAxisMax = Lstepi
        Else
            currXAxisMax = BackStyle.XAxisMax
        End If

        If ForeStyle.ZoomRect.X < BackStyle.LeftWidth Then
            ForeStyle.ZoomRect.X = BackStyle.LeftWidth
        End If

        If ForeStyle.ZoomRect.X + ForeStyle.ZoomRect.Width >= BackStyle.WidthEndD Then
            ForeStyle.ZoomRect.Width -= ((ForeStyle.ZoomRect.X + ForeStyle.ZoomRect.Width) - (BackStyle.WidthEndD - 1))
        End If

        newWidth = BackStyle.XAxisMax / BackStyle.Width * ForeStyle.ZoomRect.Width                '求曲线框容纳的点数

        newLd = (BackStyle.XAxisMax) / BackStyle.Width * Math.Abs(BackStyle.LeftWidth - ForeStyle.ZoomRect.X) + (currXAxisMax - BackStyle.XAxisMax)



        Lstepi = newWidth + newLd

        BackTyleInit(newLd, newWidth)
        DrawBackYAxisLine2(BackBitmap)
        BackRealLMove(ForeBitmap, 0)

        For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
            For index As Integer = 0 To ForeStyle.CurvePointNumber
                DispCurve(pointi)(index).Y = CurveBuff(pointi)(BackStyle.XAxisMin + index).Y
                DispCurve(pointi)(index).X = ForeStyle.CurveXMoveIn * index + BackStyle.LeftWidth
            Next

            If ForeStyle.SmoothingMode Then
                Gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            End If

            Gr.DrawLines(CurvePen(pointi), DispCurve(pointi))
        Next

        CurveObj.Image = ForeBitmap
    End Sub

    ''' <summary>
    ''' 还原曲线及数据
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ZoomReset()
        ForeStyle.ZoomOne_ = False

        Lstepi = Lstepit
        ForeBitmap = bmpTemp.Clone
        BackTyleInit(BackStyle.XAxisMint, BackStyle.XAxisMaxt)
        Array.Copy(ZoomStr, XnumberStr, UBound(ZoomStr) + 1)
        Array.Copy(BackYStringZoom, BackYString, UBound(BackYStringZoom) + 1)
        Array.Copy(BackYLineZoom, BackYLine, UBound(BackXLineZoom) + 1)
        Array.Copy(DispCurvet, DispCurve, UBound(DispCurvet))
        CurveObj.Image = ForeBitmap

    End Sub



    ''' <summary>
    ''' 实时显示放大框
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <remarks></remarks>
    Sub DrawZoomRect(ByVal x As Integer, ByVal y As Integer)
        Dim bmp As Bitmap

        bmp = ForeBitmap.Clone()


        Dim Gr As Graphics = Graphics.FromImage(bmp)

        ForeStyle.ZoomRect.Width = Math.Abs(x - ForeStyle.ZoomPoint.X)
        ForeStyle.ZoomRect.Height = Math.Abs(y - ForeStyle.ZoomPoint.Y)

        If x < ForeStyle.ZoomPoint.X Then
            ForeStyle.ZoomRect.X = ForeStyle.ZoomPoint.X - ForeStyle.ZoomRect.Width
        Else
            ForeStyle.ZoomRect.X = ForeStyle.ZoomPoint.X
        End If

        If y < ForeStyle.ZoomPoint.Y Then
            ForeStyle.ZoomRect.Y = ForeStyle.ZoomPoint.Y - ForeStyle.ZoomRect.Height
        Else
            ForeStyle.ZoomRect.Y = ForeStyle.ZoomPoint.Y
        End If

        Gr.DrawRectangle(ZoomPen, ForeStyle.ZoomRect)
        CurveObj.Image = bmp

    End Sub
End Class
