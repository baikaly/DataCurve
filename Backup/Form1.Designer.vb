<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Curve1 = New Chart.Curve
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1, 482)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(117, 482)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(390, 482)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "停止"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(517, 482)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(52, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "测试"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(633, 482)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "CLS"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(769, 482)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "还原"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(251, 502)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 15)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(263, 473)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 18
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Curve1
        '
        Me.Curve1.BackColor = System.Drawing.Color.Black
        Me.Curve1.BackScroll = True
        Me.Curve1.BottomWidth = 30
        Me.Curve1.CurveNumber = 4
        Me.Curve1.CurveSmoothingMode = True
        Me.Curve1.CurveSpline = False
        Me.Curve1.DataCoreStyle = Chart.Curve.DataCoreStyleEnum.XOne
        Me.Curve1.DataLabelColor = System.Drawing.Color.Cyan
        Me.Curve1.GridColor = System.Drawing.Color.Teal
        Me.Curve1.GridStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.Curve1.HandStyle = True
        Me.Curve1.LabelColor = System.Drawing.Color.Cyan
        Me.Curve1.LabelFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Curve1.LabelShow = True
        Me.Curve1.LabelStyle = False
        Me.Curve1.LeftWidth = 40
        Me.Curve1.Location = New System.Drawing.Point(0, 0)
        Me.Curve1.MoveDispData = True
        Me.Curve1.Name = "Curve1"
        Me.Curve1.PolerColor = System.Drawing.Color.Magenta
        Me.Curve1.PrintColor = True
        Me.Curve1.PrintYStyle = False
        Me.Curve1.PrintZoom = False
        Me.Curve1.RightTool = True
        Me.Curve1.RightWidth = 14
        Me.Curve1.ShowZeroStyle = Chart.Curve.ShowDataStyle.sDefault
        Me.Curve1.Size = New System.Drawing.Size(858, 467)
        Me.Curve1.TabIndex = 16
        Me.Curve1.TopWidth = 30
        Me.Curve1.UpdateLineColor = System.Drawing.Color.Blue
        Me.Curve1.UpdateLineShow = True
        Me.Curve1.XAxisFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Curve1.XAxisMax = 200
        Me.Curve1.XAxisMin = 0
        Me.Curve1.XAxisStrScroll = True
        Me.Curve1.XHead = 4
        Me.Curve1.XLabelColor = System.Drawing.Color.Cyan
        Me.Curve1.XLineNumber = 10
        Me.Curve1.YAxisMax = 1000
        Me.Curve1.YAxisMin = -1000
        Me.Curve1.YHead = 8
        Me.Curve1.YLineNumber = 10
        Me.Curve1.YZoomNumber = 20
        Me.Curve1.ZoomGridColor = System.Drawing.Color.Violet
        Me.Curve1.ZoomGridStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.Curve1.ZoomStyle = False
        Me.Curve1.ZoomX = True
        Me.Curve1.ZoomY = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 521)
        Me.Controls.Add(Me.Curve1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Curve1 As Chart.Curve
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button



End Class
