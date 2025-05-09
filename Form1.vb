Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextControl1 As TXTextControl.TextControl
    Friend WithEvents ButtonBar1 As TXTextControl.ButtonBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextControl1 = New TXTextControl.TextControl()
        Me.ButtonBar1 = New TXTextControl.ButtonBar()
        Me.SuspendLayout()
        '
        'TextControl1
        '
        Me.TextControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextControl1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextControl1.FormattingPrinter = "Standard"
        Me.TextControl1.Location = New System.Drawing.Point(0, 44)
        Me.TextControl1.Name = "TextControl1"
        Me.TextControl1.Size = New System.Drawing.Size(632, 450)
        Me.TextControl1.TabIndex = 0
        Me.TextControl1.UserNames = Nothing
        '
        'ButtonBar1
        '
        Me.ButtonBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonBar1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonBar1.Name = "ButtonBar1"
        Me.ButtonBar1.Size = New System.Drawing.Size(632, 44)
        Me.ButtonBar1.TabIndex = 1
        Me.ButtonBar1.Text = "ButtonBar1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(632, 494)
        Me.Controls.Add(Me.TextControl1)
        Me.Controls.Add(Me.ButtonBar1)
        Me.Name = "Form1"
        Me.Text = "TX Page Limitation Sample"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim pageLimit As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextControl1.ButtonBar = ButtonBar1
        pageLimit = 2
    End Sub

    Private Sub TextControl1_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextControl1.Changed
        If TextControl1.Pages > pageLimit And TextControl1.Text.Length > 0 Then

            Dim lastLineLength As Integer

            ' set the input position to the first col/row of pageLimit + 1
            TextControl1.InputPosition = New TXTextControl.InputPosition(pageLimit + 1, 0, 0)
            lastLineLength = TextControl1.Lines.GetItem(TextControl1.InputPosition.TextPosition).Text.Length - 2

            ' delete selected text
            TextControl1.Select(TextControl1.InputPosition.TextPosition + lastLineLength, TextControl1.Text.Length - TextControl1.InputPosition.TextPosition)
            TextControl1.Selection.Text = ""
        End If
    End Sub
End Class
