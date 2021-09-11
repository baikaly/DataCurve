

Partial Public Class Curve

    '实时曲线部分

    Sub BackRealLMove(ByRef bm As Bitmap, ByVal rstep As Double)
        Dim Gr As Graphics = Graphics.FromImage(bm)
        Dim offset As Integer = 1
        If rstep = 0 Then
            offset = 0
        End If
        '竖线
        For index As Integer = offset To BackStyle.YLineNumber

            BackYLine(index).P1.X = BackYLine(index).P1.X - rstep
            BackYLine(index).P2.X = BackYLine(index).P1.X
            BackYString(index).X = BackYString(index).X - rstep

            If BackYLine(index).P1.X > BackStyle.LeftWidth - rstep / 2 And BackYLine(index).P1.X < BackStyle.LeftWidth + rstep / 2 And NewDataCount > 1 Then

                BackYLine(index).P1.X = BackStyle.WidthEndD '移到最后一个点
                BackYLine(index).P2.X = BackYLine(index).P1.X
                '文字 
                XnumberStr(index) = NewDataCount
                BackStyle.StrSize = Gr.MeasureString(XnumberStr(index), BackStyle.StrFont)
                BackYString(index).X = BackYLine(index).P2.X - (BackStyle.StrSize.Width / 2)
                BackYString(index).Y = BackYLine(index).P2.Y

            End If
            If BackStyle.BackStrNews_ Then
                Gr.DrawString(XnumberStr(index), BackStyle.StrFont, BackStyle.StrColor, BackYString(index))
            End If
            If BackStyle.BackGridNews_ Then
                Gr.DrawLine(BackGridPen, BackYLine(index).P1, BackYLine(index).P2)
            End If        ' 

        Next

    End Sub


    Public Sub RealCurveInit()
        If NewOne Then

            BackTyleInit()
            DrawBackXAxisLine(BackBitmap, True)
            DrawBackYAxisLine(BackBitmap)
            BackRealLMove(ForeBitmap, 0)
            CurveLabelInit()
            ' CurveObj.BackgroundImage = BackBitmap
            CurveObj.BackgroundImage = BackLabelBmp
            CurveObj.Image = ForeBitmap
        End If
    End Sub

    '动态曲线
    Public Sub RealCurve(ByVal val() As Integer)

        Dim YNumber(ForeStyle.CurveNumber) As Integer

        For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
            If val(pointi) > 0 Then
                YNumber(pointi) = BackStyle.ZoreYLocation - (BackStyle.PositiveHeight * (val(pointi) / BackStyle.YAxisMax))
            ElseIf val(pointi) < 0 Then
                YNumber(pointi) = BackStyle.ZoreYLocation + (BackStyle.NegativeHeight * (Math.Abs(val(pointi)) / Math.Abs(BackStyle.YAxisMin)))
            Else
                YNumber(pointi) = BackStyle.ZoreYLocation
            End If

            CurveBuff(pointi)(NewDataCount).Y = YNumber(pointi)
            CurveBuff(pointi)(NewDataCount).X = NewDataCount
        Next


        '大于XAXis容纳的总数，需要移动
        If NewDataCount > ForeStyle.CurvePointNumber Then

            ForeBitmap = New Bitmap(BackBitmap.Width, BackBitmap.Height)
            Dim Gr As Graphics = Graphics.FromImage(ForeBitmap)

            If (BackStyle.BackGridNews_ Or BackStyle.BackStrNews_) Then
                'BackRealLMove(ForeBitmap, BackStyle.XPoleIn)
                BackRealLMove(ForeBitmap, ForeStyle.CurveXMoveIn)
            End If

            For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
                For index As Integer = 0 To ForeStyle.CurvePointNumber - 1
                    DispCurve(pointi)(index).Y = DispCurve(pointi)(index + 1).Y
                Next
                DispCurve(pointi)(ForeStyle.CurvePointNumber).Y = YNumber(pointi)

                If ForeStyle.SmoothingMode Then
                    Gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                End If
                Gr.DrawLines(CurvePen(pointi), DispCurve(pointi))
            Next

        ElseIf NewDataCount > 0 Then

            Dim Gr As Graphics = Graphics.FromImage(ForeBitmap)
            For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
                ' DispCurve(pointi)(Rstepi).X = DispCurve(pointi)(Rstepi - 1).X + BackStyle.XPoleIn 
                DispCurve(pointi)(NewDataCount).X = NewDataCount * ForeStyle.CurveXMoveIn + BackStyle.LeftWidth
                DispCurve(pointi)(NewDataCount).Y = YNumber(pointi)
                If ForeStyle.SmoothingMode Then
                    Gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                End If
                Gr.DrawLine(CurvePen(pointi), DispCurve(pointi)(NewDataCount - 1), DispCurve(pointi)(NewDataCount))
            Next
        Else

            For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
                DispCurve(pointi)(NewDataCount).X = BackStyle.LeftWidth
                DispCurve(pointi)(NewDataCount).Y = YNumber(pointi)
            Next

        End If

        NewDataCount += 1
        Lstepi = NewDataCount

        CurveObj.Image = ForeBitmap

    End Sub


End Class
