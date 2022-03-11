<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PageClient
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BTN_Submit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_LastName = New System.Windows.Forms.TextBox()
        Me.TB_FirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NUM_Age = New System.Windows.Forms.NumericUpDown()
        CType(Me.NUM_Age, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Submit
        '
        Me.BTN_Submit.Location = New System.Drawing.Point(169, 92)
        Me.BTN_Submit.Name = "BTN_Submit"
        Me.BTN_Submit.Size = New System.Drawing.Size(111, 31)
        Me.BTN_Submit.TabIndex = 1
        Me.BTN_Submit.Text = "Envoyer"
        Me.BTN_Submit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nom:"
        '
        'TB_LastName
        '
        Me.TB_LastName.Location = New System.Drawing.Point(80, 4)
        Me.TB_LastName.Name = "TB_LastName"
        Me.TB_LastName.Size = New System.Drawing.Size(200, 23)
        Me.TB_LastName.TabIndex = 3
        '
        'TB_FirstName
        '
        Me.TB_FirstName.Location = New System.Drawing.Point(80, 33)
        Me.TB_FirstName.Name = "TB_FirstName"
        Me.TB_FirstName.Size = New System.Drawing.Size(200, 23)
        Me.TB_FirstName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Prénom:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Âge:"
        '
        'NUM_Age
        '
        Me.NUM_Age.Location = New System.Drawing.Point(80, 63)
        Me.NUM_Age.Name = "NUM_Age"
        Me.NUM_Age.Size = New System.Drawing.Size(200, 23)
        Me.NUM_Age.TabIndex = 7
        '
        'PageClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 130)
        Me.Controls.Add(Me.NUM_Age)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB_FirstName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_LastName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_Submit)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PageClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client"
        CType(Me.NUM_Age, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_Submit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_LastName As TextBox
    Friend WithEvents TB_FirstName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NUM_Age As NumericUpDown
End Class
