<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Curve1 = New Chart.Curve()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Combo1 = New System.Windows.Forms.ComboBox()
        Me.Label_Port = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo2 = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(627, 36)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 53)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "停止"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(500, 36)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 53)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "开始"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(994, 37)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(84, 53)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "清空数据"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(1083, 37)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(85, 53)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "坐标还原"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(200, 36)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(85, 52)
        Me.Button7.TabIndex = 18
        Me.Button7.Text = "打开串口"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Curve1
        '
        Me.Curve1.BackColor = System.Drawing.Color.Black
        Me.Curve1.BackScroll = True
        Me.Curve1.BottomWidth = 30
        Me.Curve1.CurveNumber = 1
        Me.Curve1.CurveSmoothingMode = True
        Me.Curve1.CurveSpline = True
        Me.Curve1.DataCoreStyle = Chart.Curve.DataCoreStyleEnum.XOne
        Me.Curve1.DataLabelColor = System.Drawing.Color.Cyan
        Me.Curve1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Curve1.GridColor = System.Drawing.Color.Teal
        Me.Curve1.GridStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.Curve1.HandStyle = True
        Me.Curve1.LabelColor = System.Drawing.Color.Cyan
        Me.Curve1.LabelFont = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Curve1.LabelShow = True
        Me.Curve1.LabelStyle = False
        Me.Curve1.LeftWidth = 40
        Me.Curve1.Location = New System.Drawing.Point(4, 4)
        Me.Curve1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Curve1.MoveDispData = True
        Me.Curve1.Name = "Curve1"
        Me.Curve1.PolerColor = System.Drawing.Color.Magenta
        Me.Curve1.PrintColor = True
        Me.Curve1.PrintYStyle = False
        Me.Curve1.PrintZoom = False
        Me.Curve1.RightTool = True
        Me.Curve1.RightWidth = 14
        Me.Curve1.ShowZeroStyle = Chart.Curve.ShowDataStyle.sDefault
        Me.Curve1.Size = New System.Drawing.Size(1167, 503)
        Me.Curve1.TabIndex = 16
        Me.Curve1.TopWidth = 30
        Me.Curve1.UpdateLineColor = System.Drawing.Color.Blue
        Me.Curve1.UpdateLineShow = True
        Me.Curve1.XAxisFont = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Curve1.XAxisMax = 100.0R
        Me.Curve1.XAxisMin = 0R
        Me.Curve1.XAxisStrScroll = True
        Me.Curve1.XHead = 4
        Me.Curve1.XLabelColor = System.Drawing.Color.Cyan
        Me.Curve1.XLineNumber = 10
        Me.Curve1.YAxisMax = 0R
        Me.Curve1.YAxisMin = -100.0R
        Me.Curve1.YHead = 8
        Me.Curve1.YLineNumber = 10
        'Me.Curve1.YZoomNumber = 0
        Me.Curve1.ZoomGridColor = System.Drawing.Color.Violet
        Me.Curve1.ZoomGridStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.Curve1.ZoomStyle = False
        Me.Curve1.ZoomX = True
        Me.Curve1.ZoomY = False
        '
        'SerialPort1
        '
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(83, 36)
        Me.Combo1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(89, 24)
        Me.Combo1.TabIndex = 19
        '
        'Label_Port
        '
        Me.Label_Port.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label_Port.AutoSize = True
        Me.Label_Port.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Port.Location = New System.Drawing.Point(28, 37)
        Me.Label_Port.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Port.Name = "Label_Port"
        Me.Label_Port.Size = New System.Drawing.Size(37, 20)
        Me.Label_Port.TabIndex = 20
        Me.Label_Port.Text = "端口"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Combo2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label_Port)
        Me.GroupBox1.Controls.Add(Me.Combo1)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 522)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1175, 128)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "设置"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(887, 37)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(99, 53)
        Me.Button6.TabIndex = 24
        Me.Button6.Text = "显示源数据"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "间隔(ms)"
        '
        'Combo2
        '
        Me.Combo2.BackColor = System.Drawing.SystemColors.Window
        Me.Combo2.FormattingEnabled = True
        Me.Combo2.Location = New System.Drawing.Point(83, 69)
        Me.Combo2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo2.Name = "Combo2"
        Me.Combo2.Size = New System.Drawing.Size(89, 24)
        Me.Combo2.TabIndex = 22
        Me.Combo2.Text = "1000"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(341, 39)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 21)
        Me.CheckBox1.TabIndex = 21
        Me.CheckBox1.Text = "模拟数据"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.17305!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.82695!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1181, 653)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Curve1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1175, 511)
        Me.TableLayoutPanel2.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1178, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 505)
        Me.Panel1.TabIndex = 18
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1, 505)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RAW DATA"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 18)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(0, 484)
        Me.TextBox1.TabIndex = 17
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(341, 66)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(95, 21)
        Me.CheckBox2.TabIndex = 25
        Me.CheckBox2.Text = "RAIL RSSI"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1181, 653)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "自供电无线温度传感器Demo "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Curve1 As Chart.Curve
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Port As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Combo2 As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button6 As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBox2 As CheckBox
End Class
