<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PageServeur
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
        Me.BTN_StartServer = New System.Windows.Forms.Button()
        Me.BTN_StopServer = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColumnNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPrenom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_StartServer
        '
        Me.BTN_StartServer.Location = New System.Drawing.Point(83, 22)
        Me.BTN_StartServer.Name = "BTN_StartServer"
        Me.BTN_StartServer.Size = New System.Drawing.Size(75, 23)
        Me.BTN_StartServer.TabIndex = 0
        Me.BTN_StartServer.Text = "Start"
        Me.BTN_StartServer.UseVisualStyleBackColor = True
        '
        'BTN_StopServer
        '
        Me.BTN_StopServer.Location = New System.Drawing.Point(164, 22)
        Me.BTN_StopServer.Name = "BTN_StopServer"
        Me.BTN_StopServer.Size = New System.Drawing.Size(75, 23)
        Me.BTN_StopServer.TabIndex = 1
        Me.BTN_StopServer.Text = "Stop"
        Me.BTN_StopServer.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnNom, Me.ColumnPrenom, Me.ColumnAge})
        Me.DataGridView1.Location = New System.Drawing.Point(7, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(309, 163)
        Me.DataGridView1.TabIndex = 2
        '
        'ColumnNom
        '
        Me.ColumnNom.HeaderText = "Nom"
        Me.ColumnNom.Name = "ColumnNom"
        Me.ColumnNom.ReadOnly = True
        '
        'ColumnPrenom
        '
        Me.ColumnPrenom.HeaderText = "Prenom"
        Me.ColumnPrenom.Name = "ColumnPrenom"
        Me.ColumnPrenom.ReadOnly = True
        '
        'ColumnAge
        '
        Me.ColumnAge.HeaderText = "Age"
        Me.ColumnAge.Name = "ColumnAge"
        Me.ColumnAge.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_StartServer)
        Me.GroupBox1.Controls.Add(Me.BTN_StopServer)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 53)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Commandes du serveur"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 191)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Données reçues"
        '
        'PageServeur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 269)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PageServeur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serveur JsonRPC"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_StartServer As Button
    Friend WithEvents BTN_StopServer As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ColumnNom As DataGridViewTextBoxColumn
    Friend WithEvents ColumnPrenom As DataGridViewTextBoxColumn
    Friend WithEvents ColumnAge As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
