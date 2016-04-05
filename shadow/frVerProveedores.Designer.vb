<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frVerProveedores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProvedores = New System.Windows.Forms.DataGridView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.dgProvedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txProveedor
        '
        Me.txProveedor.Location = New System.Drawing.Point(96, 27)
        Me.txProveedor.Name = "txProveedor"
        Me.txProveedor.Size = New System.Drawing.Size(426, 20)
        Me.txProveedor.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "PROVEEDOR:"
        '
        'dgProvedores
        '
        Me.dgProvedores.AllowUserToAddRows = False
        Me.dgProvedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProvedores.Location = New System.Drawing.Point(12, 85)
        Me.dgProvedores.Name = "dgProvedores"
        Me.dgProvedores.Size = New System.Drawing.Size(510, 348)
        Me.dgProvedores.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(96, 53)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(169, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "VER SOLO TRABAJADORES"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frVerProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(534, 461)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgProvedores)
        Me.Name = "frVerProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECCIÓN DE PROVEEDORES"
        CType(Me.dgProvedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txProveedor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgProvedores As DataGridView
    Friend WithEvents CheckBox1 As CheckBox
End Class
