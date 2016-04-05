<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Me.txIp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txContra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txUser = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txCancelar = New System.Windows.Forms.Button()
        Me.btConectar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txIp
        '
        Me.txIp.BackColor = System.Drawing.Color.White
        Me.txIp.Location = New System.Drawing.Point(150, 145)
        Me.txIp.Name = "txIp"
        Me.txIp.Size = New System.Drawing.Size(209, 20)
        Me.txIp.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(46, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "IP CONEXION:"
        '
        'txContra
        '
        Me.txContra.BackColor = System.Drawing.Color.White
        Me.txContra.Location = New System.Drawing.Point(150, 106)
        Me.txContra.Name = "txContra"
        Me.txContra.Size = New System.Drawing.Size(209, 20)
        Me.txContra.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(41, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "CONTRASEÑA:"
        '
        'txUser
        '
        Me.txUser.BackColor = System.Drawing.Color.White
        Me.txUser.Location = New System.Drawing.Point(150, 68)
        Me.txUser.Name = "txUser"
        Me.txUser.Size = New System.Drawing.Size(209, 20)
        Me.txUser.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(66, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "USUARIO:"
        '
        'txCancelar
        '
        Me.txCancelar.Location = New System.Drawing.Point(284, 223)
        Me.txCancelar.Name = "txCancelar"
        Me.txCancelar.Size = New System.Drawing.Size(75, 23)
        Me.txCancelar.TabIndex = 15
        Me.txCancelar.Text = "Cancelar"
        Me.txCancelar.UseVisualStyleBackColor = True
        '
        'btConectar
        '
        Me.btConectar.Location = New System.Drawing.Point(182, 223)
        Me.btConectar.Name = "btConectar"
        Me.btConectar.Size = New System.Drawing.Size(75, 23)
        Me.btConectar.TabIndex = 14
        Me.btConectar.Text = "Conectar"
        Me.btConectar.UseVisualStyleBackColor = True
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(424, 273)
        Me.Controls.Add(Me.txCancelar)
        Me.Controls.Add(Me.btConectar)
        Me.Controls.Add(Me.txIp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txContra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txUser)
        Me.Controls.Add(Me.Label1)
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login Usuarios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txIp As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txContra As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txUser As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txCancelar As Button
    Friend WithEvents btConectar As Button
End Class
