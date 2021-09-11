
Partial Public Class Curve

    'Inherits System.Windows.Forms.Control
    Inherits System.Windows.Forms.UserControl

    Friend WithEvents CurveObj As New System.Windows.Forms.PictureBox
    Friend WithEvents CurveState As New System.Windows.Forms.PictureBox

    Dim Gr As Graphics


#Region "背景的所有元素"

    ''' <summary>
    ''' 背景网格线结构
    ''' </summary>
    ''' <remarks></remarks>
    Structure BackLineStruct
        Dim P1 As Point
        Dim P2 As Point
    End Structure
    Dim BackXLine() As BackLineStruct
    Dim BackYLine() As BackLineStruct
    Dim BackXPoleLine() As BackLineStruct
    Dim BackYPoleLine() As BackLineStruct
    Dim BackXString() As Point
    Dim BackYString() As Point

    Dim CurveLabelPoint() As BackLineStruct
    Dim CurveLabelStr(10) As String

    Dim BackXLineZoom() As BackLineStruct
    Dim BackYLineZoom() As BackLineStruct
    Dim BackXStringZoom() As Point
    Dim BackYStringZoom() As Point


    Dim BackGridPen As New Pen(Color.Teal, 1)
    Dim BackPolePen As New Pen(Color.Magenta, 1)

    ''' <summary>
    ''' 背景样式控制
    ''' </summary>
    ''' <remarks></remarks>
    Structure BackStyleStruct
        Dim XIn As Integer
        Dim YIn As Integer
        Dim XPoleIn As Integer
        Dim YPoleIn As Integer
        Dim XHead As Integer
        Dim YHead As Integer
        Dim XAxisGridMax As Integer
        Dim YAxisGridMax As Integer

        Dim Width As Integer
        Dim Height As Integer

        Dim WidthEndD As Integer                    '宽度点在像素的X位置
        Dim HeightEndD As Integer                   '高度点在像素的y位置
        Dim ZoreYLocation As Integer
        Dim PositiveHeight As Integer
        Dim NegativeHeight As Integer

        Dim LeftWidth As Integer
        Dim RightWidth As Integer
        Dim TopWidth As Integer
        Dim BottomWidth As Integer

        Dim TopIn As Integer                   '
        Dim RightIn As Integer                   '

        Dim XLineNumber As Integer
        Dim YLineNumber As Integer
        Dim XAxisMax As Double
        Dim XAxisMaxt As Double
        Dim YAxisMax As Double
        Dim XAxisMin As Double
        Dim XAxisMint As Double
        Dim YAxisMin As Double

        Dim StrSize As SizeF
        Dim StrFont As Font
        Dim LabelFont As Font
        Dim StrColor As SolidBrush
        Dim LabelColor As SolidBrush
        Dim DataLabelColor As SolidBrush
        Dim BackGridNews_ As Boolean
        Dim BackStrNews_ As Boolean
        Dim CurveLabelStyle As Boolean
        Dim MoveDispData As Boolean
    End Structure

    Dim BackStyle As BackStyleStruct
    Dim BackBitmap As Bitmap
    Dim BackLabelBmp As Bitmap
    Dim CurveStateBmp As Bitmap

    Dim XnumberStr() As String                      'x轴的数字，数组数量和y轴线的数量相同
    Dim YnumberStr() As String                      'y轴的数字，数组数量和x轴线的数量相同
    Dim ZoomStr() As String


#End Region

#Region "前景元素"

    Dim ForeBitmap As Bitmap
    Dim bmpTemp As Bitmap

    Dim ZoomPen As New Pen(Color.Violet, 1)         '放大框使用的网格画笔
    Dim CurvePen() As Pen                           '绘制曲线用的画笔
    Dim CurveBuff()() As Point                      '曲线缓冲区，所有的曲线在此
    Dim DispCurve()() As Point                      '曲线可显示的区域，随放大而调整
    Dim DispCurvet()() As Point                     '曲线可显示的区域，随放大而调整

    Structure ForeStyleStruct
        Dim CurveNumber As Integer                  '曲线线的数量
        Dim CurvePointNumber As Double              '一条线的点数
        Dim CurveXMoveIn As Double
        Dim CurveBuffMax As Integer
        Dim MoveEn_ As Boolean
        Dim MoveL_ As Boolean
        Dim MoveR_ As Boolean
        Dim Exit_ As Boolean
        Dim Zoom_ As Boolean
        Dim ZoomOne_ As Boolean
        Dim ZoomPoint As Point
        Dim ZoomRect As Rectangle
        Dim SmoothingMode As Boolean
    End Structure
    Dim ForeStyle As ForeStyleStruct


    Dim NewDataCount As Integer = 0                 '曲线缓冲区的数量，只有新数据来时才加1
    Dim Lstepi As Integer = 0
    Dim Lstepit As Integer = 0
#End Region



End Class
