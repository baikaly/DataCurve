Partial Public Class Curve

    Public Property XAxisMin() As Double
        Get
            Return BackStyle.XAxisMin
        End Get
        Set(ByVal value As Double)
            BackStyle.XAxisMin = value
            RealCurveInit()
        End Set
    End Property

    Public Property XAxisMax() As Double
        Get
            Return BackStyle.XAxisMax
        End Get
        Set(ByVal value As Double)
            BackStyle.XAxisMax = value
            RealCurveInit()
        End Set
    End Property
    Public Property YAxisMin() As Double
        Get
            Return BackStyle.YAxisMin
        End Get
        Set(ByVal value As Double)
            BackStyle.YAxisMin = value
            RealCurveInit()
        End Set
    End Property

    Public Property YAxisMax() As Double
        Get
            Return BackStyle.YAxisMax
        End Get
        Set(ByVal value As Double)
            BackStyle.YAxisMax = value
            RealCurveInit()
        End Set
    End Property

    Public Property XLineNumber() As Integer
        Get
            Return BackStyle.XLineNumber
        End Get
        Set(ByVal value As Integer)
            BackStyle.XLineNumber = value
            RealCurveInit()
        End Set
    End Property

    Public Property YLineNumber() As Integer
        Get
            Return BackStyle.YLineNumber
        End Get
        Set(ByVal value As Integer)
            BackStyle.YLineNumber = value
            RealCurveInit()

        End Set
    End Property

    Public Property CurveNumber() As Integer
        Get
            Return ForeStyle.CurveNumber
        End Get
        Set(ByVal value As Integer)
            ForeStyle.CurveNumber = value
            RealCurveInit()
        End Set
    End Property


    Public Property LeftWidth() As Integer
        Get
            Return BackStyle.LeftWidth
        End Get
        Set(ByVal value As Integer)
            BackStyle.LeftWidth = value
            RealCurveInit()
        End Set
    End Property

    Public Property RightWidth() As Integer
        Get
            Return BackStyle.RightWidth
        End Get
        Set(ByVal value As Integer)
            BackStyle.RightWidth = value
            RealCurveInit()
        End Set
    End Property

    Public Property TopWidth() As Integer
        Get
            Return BackStyle.TopWidth
        End Get
        Set(ByVal value As Integer)
            BackStyle.TopWidth = value
            RealCurveInit()
        End Set
    End Property

    Public Property BottomWidth() As Integer
        Get
            Return BackStyle.BottomWidth
        End Get
        Set(ByVal value As Integer)
            BackStyle.BottomWidth = value
            RealCurveInit()
        End Set
    End Property





    Public Property CurveColor(ByVal index As Integer) As Color
        Get
            If index <= ForeStyle.CurveNumber Then
                Return CurvePen(index).Color
            Else
                Return Color.Red
            End If
        End Get
        Set(ByVal value As Color)
            If index <= ForeStyle.CurveNumber Then
                CurvePen(index).Color = value
                RealCurveInit()
            End If
        End Set
    End Property

    Public Property CurveWidth(ByVal index As Integer) As Integer
        Get
            If index <= ForeStyle.CurveNumber Then
                Return CurvePen(index).Width
            Else
                Return 1
            End If
        End Get
        Set(ByVal value As Integer)
            If index <= ForeStyle.CurveNumber Then
                CurvePen(index).Width = value
                RealCurveInit()
            End If
        End Set
    End Property

    Public Property CurveStyle(ByVal index As Integer) As Drawing2D.DashStyle
        Get
            If index <= ForeStyle.CurveNumber Then
                Return CurvePen(index).DashStyle
            Else
                Return Drawing2D.DashStyle.Solid
            End If
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            If index <= ForeStyle.CurveNumber Then
                CurvePen(index).DashStyle = value
                RealCurveInit()
            End If
        End Set
    End Property


    Public Property PolerColor() As Color
        Get
            Return BackPolePen.Color
        End Get
        Set(ByVal value As Color)
            BackPolePen.Color = value
            RealCurveInit()
        End Set
    End Property

    Public Property GridColor() As Color
        Get
            Return BackGridPen.Color
        End Get
        Set(ByVal value As Color)
            BackGridPen.Color = value
            RealCurveInit()
        End Set
    End Property

    Public Property XAxisStrColor() As Color
        Get
            Return BackStyle.StrColor.Color
        End Get
        Set(ByVal value As Color)
            BackStyle.StrColor.Color = value
            RealCurveInit()
        End Set
    End Property

    Public Property CurveLabelColor() As Color
        Get
            Return BackStyle.LabelColor.Color
        End Get
        Set(ByVal value As Color)
            BackStyle.LabelColor.Color = value
            RealCurveInit()
        End Set
    End Property

    Public Property DataLabelColor() As Color
        Get
            Return BackStyle.DataLabelColor.Color
        End Get
        Set(ByVal value As Color)
            BackStyle.DataLabelColor.Color = value
            'RealCurveInit()
        End Set
    End Property

    Public Property CurveLabelText(ByVal index As Integer) As String
        Get
            If index <= ForeStyle.CurveNumber Then
                Return CurveLabelStr(index)
            Else
                Return "Label"
            End If
        End Get
        Set(ByVal value As String)
            If index <= ForeStyle.CurveNumber Then
                CurveLabelStr(index) = value
                RealCurveInit()
            End If
        End Set
    End Property

    Public Property CurveLabelStyle() As Boolean
        Get
            Return BackStyle.CurveLabelStyle
        End Get
        Set(ByVal value As Boolean)
            BackStyle.CurveLabelStyle = value
            RealCurveInit()
        End Set
    End Property

    Public Property XAxisFont() As Font
        Get
            Return BackStyle.StrFont
        End Get
        Set(ByVal value As Font)
            BackStyle.StrFont = value
            RealCurveInit()
        End Set
    End Property

    Public Property LabelFont() As Font
        Get
            Return BackStyle.LabelFont
        End Get
        Set(ByVal value As Font)
            BackStyle.LabelFont = value
            RealCurveInit()
        End Set
    End Property
    Public Property GridStyle() As Drawing2D.DashStyle
        Get
            Return BackGridPen.DashStyle
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            BackGridPen.DashStyle = value
            RealCurveInit()
        End Set
    End Property



    Public Property ZoomGridColor() As Color
        Get
            Return ZoomPen.Color
        End Get
        Set(ByVal value As Color)
            ZoomPen.Color = value
            RealCurveInit()
        End Set
    End Property

    Public Property ZoomGridStyle() As Drawing2D.DashStyle
        Get
            Return ZoomPen.DashStyle
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            ZoomPen.DashStyle = value
            RealCurveInit()
        End Set
    End Property


    Public ReadOnly Property GetCurveNumber() As Integer
        Get
            Return NewDataCount
        End Get
    End Property

    Public ReadOnly Property GetCurrViewLocation() As Integer
        Get
            Return Lstepi
        End Get
    End Property

    Public Property XHead() As Integer
        Get
            Return BackStyle.XHead
        End Get
        Set(ByVal value As Integer)
            BackStyle.XHead = value
        End Set
    End Property

    Public Property YHead() As Integer
        Get
            Return BackStyle.YHead
        End Get
        Set(ByVal value As Integer)
            BackStyle.YHead = value
        End Set
    End Property

    Public Property BackScroll() As Boolean
        Get
            Return BackStyle.BackGridNews_
        End Get
        Set(ByVal value As Boolean)
            BackStyle.BackGridNews_ = value
        End Set
    End Property

    Public Property XAxisStrScroll() As Boolean
        Get
            Return BackStyle.BackStrNews_
        End Get
        Set(ByVal value As Boolean)
            BackStyle.BackStrNews_ = value
        End Set
    End Property


    Public Property CurveSmoothingMode() As Boolean
        Get
            Return ForeStyle.SmoothingMode
        End Get
        Set(ByVal value As Boolean)
            ForeStyle.SmoothingMode = value
        End Set
    End Property


    'Public Overrides Property BackColor() As Color
    '    Get
    '        Return CurveObj.BackColor
    '    End Get
    '    Set(ByVal value As Color)
    '        CurveObj.BackColor = value
    '    End Set
    'End Property

    Public Property MoveDispData() As Boolean
        Get
            Return BackStyle.MoveDispData
        End Get
        Set(ByVal value As Boolean)
            BackStyle.MoveDispData = value
        End Set
    End Property


    Private Sub Curve_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        CurveObj.BackColor = Me.BackColor
    End Sub

    Private Sub Curve_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Me.DockPadding.All
        RealCurveInit()
    End Sub
End Class
