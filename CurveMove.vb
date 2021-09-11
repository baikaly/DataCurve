Partial Public Class Curve

    ''' <summary>
    ''' 背景左移,点右边
    ''' </summary>
    ''' <param name="bm"></param>
    ''' <param name="rstep"></param>
    ''' <remarks></remarks>
    Sub BackLMove(ByRef bm As Bitmap, ByVal rstep As Double)
        Dim Gr As Graphics = Graphics.FromImage(bm)
        '竖线
        For index As Integer = 1 To BackStyle.YLineNumber


            If BackYLine(index).P1.X > BackStyle.LeftWidth - rstep / 2 And BackYLine(index).P1.X < BackStyle.LeftWidth + rstep / 2 Then '

                BackYLine(index).P1.X = (BackStyle.WidthEndD) '移到最后一个点
                BackYLine(index).P2.X = BackYLine(index).P1.X
                '文字 
                XnumberStr(index) = CurveBuff(0)(Lstepi - 1).X

                BackStyle.StrSize = Gr.MeasureString(XnumberStr(index), BackStyle.StrFont)
                BackYString(index).X = BackYLine(index).P2.X - (BackStyle.StrSize.Width / 2)
                BackYString(index).Y = BackYLine(index).P2.Y

            End If
            BackYLine(index).P1.X = BackYLine(index).P1.X - rstep
            BackYLine(index).P2.X = BackYLine(index).P1.X
            BackYString(index).X = BackYString(index).X - rstep
            If BackStyle.BackStrNews_ Then
                Gr.DrawString(XnumberStr(index), BackStyle.StrFont, BackStyle.StrColor, BackYString(index))
            End If
            If BackStyle.BackGridNews_ Then
                Gr.DrawLine(BackGridPen, BackYLine(index).P1, BackYLine(index).P2)
            End If
            ' 
        Next
    End Sub

    ''' <summary>
    ''' 背景右移，点左边
    ''' </summary>
    ''' <param name="bm"></param>
    ''' <param name="rstep"></param>
    ''' <remarks></remarks>
    Sub BackRMove(ByRef bm As Bitmap, ByVal rstep As Double)
        Dim Gr As Graphics = Graphics.FromImage(bm)
        '竖线
        For index As Integer = 1 To BackStyle.YLineNumber

            If BackYLine(index).P1.X > BackStyle.WidthEndD - rstep / 2 And BackYLine(index).P1.X < BackStyle.WidthEndD + rstep / 2 Then '

                BackYLine(index).P1.X = (BackStyle.LeftWidth) '移到第一个点
                BackYLine(index).P2.X = BackYLine(index).P1.X
                '文字 
                XnumberStr(index) = CurveBuff(0)(Lstepi).X - BackStyle.XAxisMax

                BackStyle.StrSize = Gr.MeasureString(XnumberStr(index), BackStyle.StrFont)
                BackYString(index).X = BackYLine(index).P2.X - (BackStyle.StrSize.Width / 2)
                BackYString(index).Y = BackYLine(index).P2.Y

            End If
            BackYLine(index).P1.X = BackYLine(index).P1.X + rstep
            BackYLine(index).P2.X = BackYLine(index).P1.X
            BackYString(index).X = BackYString(index).X + rstep
            If BackStyle.BackStrNews_ Then
                Gr.DrawString(XnumberStr(index), BackStyle.StrFont, BackStyle.StrColor, BackYString(index))
            End If
            If BackStyle.BackGridNews_ Then
                Gr.DrawLine(BackGridPen, BackYLine(index).P1, BackYLine(index).P2)
            End If
            ' 
        Next
    End Sub


    ''' <summary>
    ''' 曲线左移
    ''' </summary>
    ''' <remarks></remarks>
    Sub CurveLMove()
        If Lstepi < NewDataCount Then
            ForeBitmap = New Bitmap(BackBitmap.Width, BackBitmap.Height)
            Dim Gr As Graphics = Graphics.FromImage(ForeBitmap)

            If (BackStyle.BackGridNews_ Or BackStyle.BackStrNews_) Then
                BackLMove(ForeBitmap, ForeStyle.CurveXMoveIn)
            End If

            For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
                For index As Integer = 0 To ForeStyle.CurvePointNumber - 1
                    DispCurve(pointi)(index).Y = DispCurve(pointi)(index + 1).Y
                Next
                DispCurve(pointi)(ForeStyle.CurvePointNumber).Y = CurveBuff(pointi)(Lstepi).Y

                If ForeStyle.SmoothingMode Then
                    Gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                End If
                Gr.DrawLines(CurvePen(pointi), DispCurve(pointi))
            Next

            Lstepi += 1
            CurveObj.Image = ForeBitmap
        End If

    End Sub


    ''' <summary>
    ''' 曲线右移
    ''' </summary>
    ''' <remarks></remarks>
    Sub CurveRMove()
        If Lstepi - ForeStyle.CurvePointNumber > 1 Then
            Lstepi -= 1
            ForeBitmap = New Bitmap(BackBitmap.Width, BackBitmap.Height)
            Dim Gr As Graphics = Graphics.FromImage(ForeBitmap)

            If (BackStyle.BackGridNews_ Or BackStyle.BackStrNews_) Then
                BackRMove(ForeBitmap, ForeStyle.CurveXMoveIn)
            End If

            For pointi As Integer = 0 To ForeStyle.CurveNumber - 1
                For index As Integer = ForeStyle.CurvePointNumber To 1 Step -1
                    DispCurve(pointi)(index).Y = DispCurve(pointi)(index - 1).Y
                Next
                DispCurve(pointi)(0).Y = CurveBuff(pointi)(Lstepi - ForeStyle.CurvePointNumber - 1).Y

                If ForeStyle.SmoothingMode Then
                    Gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                End If
                Gr.DrawLines(CurvePen(pointi), DispCurve(pointi))
            Next

            CurveObj.Image = ForeBitmap
        End If

    End Sub


    Sub MoveData(ByVal e As System.Windows.Forms.MouseEventArgs)
        CurveStateBmp = New Bitmap(Me.CurveState.Width, Me.CurveState.Height)
        Dim Gr As Graphics = Graphics.FromImage(CurveStateBmp)

        Dim currXAxisMax, x, y As Integer '当前X轴最大值

        Dim xv As Double = ForeStyle.CurvePointNumber / BackStyle.Width
        Dim yv As Double = (BackStyle.YAxisMax - BackStyle.YAxisMin) / BackStyle.Height

        Dim dataStr As String
        Dim strSize As SizeF

        If Lstepi > BackStyle.XAxisMax Then
            currXAxisMax = Lstepi
        Else
            currXAxisMax = BackStyle.XAxisMax
        End If

        x = (currXAxisMax - ForeStyle.CurvePointNumber) + (e.X - BackStyle.LeftWidth) * xv
        y = BackStyle.YAxisMax - (e.Y - BackStyle.TopIn) * yv

        dataStr = "X:" & x & "    Y:" & y

        strSize = Gr.MeasureString(dataStr, BackStyle.StrFont)

        Gr.DrawString(dataStr, BackStyle.StrFont, BackStyle.DataLabelColor, _
                      New Point(Me.CurveState.Width - strSize.Width - BackStyle.RightIn, Me.CurveState.Height - strSize.Height))



        Me.CurveState.Image = CurveStateBmp

    End Sub



    Private Sub CurveObj_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CurveObj.MouseMove
        If ForeStyle.Zoom_ Then

            DrawZoomRect(e.X, e.Y)

        ElseIf (e.X >= BackStyle.LeftWidth And e.X <= BackStyle.LeftWidth + 60) Then
            If ForeStyle.MoveEn_ Then
                CurveObj.Cursor = Cursors.PanWest
            Else
                CurveObj.Cursor = Cursors.NoMoveHoriz
            End If

        ElseIf (e.X >= BackStyle.WidthEndD - 60 And e.X <= BackStyle.WidthEndD) Then
            If ForeStyle.MoveEn_ Then
                CurveObj.Cursor = Cursors.PanEast
            Else
                CurveObj.Cursor = Cursors.NoMoveHoriz
            End If
        Else
            CurveObj.Cursor = Cursors.Default
        End If

        If BackStyle.MoveDispData Then
            MoveData(e)
        End If

    End Sub

    Private Sub CurveObj_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CurveObj.MouseDown
        '如果是右键按下去
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If ForeStyle.MoveEn_ Then
                ForeStyle.MoveEn_ = Not ForeStyle.MoveEn_
                ForeStyle.MoveL_ = False
                ForeStyle.MoveR_ = False
            ElseIf (e.X >= BackStyle.LeftWidth And e.X <= BackStyle.LeftWidth + 60) Then
                ForeStyle.MoveEn_ = Not ForeStyle.MoveEn_
                ForeStyle.MoveL_ = True
            ElseIf (e.X >= BackStyle.WidthEndD - 60 And e.X <= BackStyle.WidthEndD) Then
                ForeStyle.MoveEn_ = Not ForeStyle.MoveEn_
                ForeStyle.MoveR_ = True
            End If
            '如果是左键按下去
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            If ForeStyle.MoveEn_ Then
                If (e.X >= BackStyle.LeftWidth And e.X <= BackStyle.LeftWidth + 60) Then
                    ForeStyle.Exit_ = True
                    While ForeStyle.Exit_
                        CurveRMove()
                        Application.DoEvents()
                    End While

                ElseIf (e.X >= BackStyle.WidthEndD - 60 And e.X <= BackStyle.WidthEndD) Then

                    ForeStyle.Exit_ = True
                    While ForeStyle.Exit_
                        CurveLMove()
                        Application.DoEvents()
                    End While
                End If

                '如果不需要滚动曲线就执行放大
            Else
                ForeStyle.Zoom_ = True
                CurveObj.Cursor = Cursors.Default
                ForeStyle.ZoomPoint.X = e.X
                ForeStyle.ZoomPoint.Y = e.Y
            End If

        End If
    End Sub

    Private Sub CurveObj_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CurveObj.MouseUp
        If ForeStyle.Zoom_ Then
            '
            If ForeStyle.ZoomRect.Width > 40 And BackStyle.XAxisMax > BackStyle.YLineNumber * 2 Then
                ZoomInit()
                ForeStyle.ZoomOne_ = True
            Else
                CurveObj.Image = ForeBitmap
            End If
        End If
        ForeStyle.Exit_ = False
        ForeStyle.Zoom_ = False
    End Sub




End Class
