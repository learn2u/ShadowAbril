<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frConfiguracion
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
        Me.txServidor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txBasedatos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txServidor
        '
        Me.txServidor.Location = New System.Drawing.Point(117, 56)
        Me.txServidor.Name = "txServidor"
        Me.txServidor.Size = New System.Drawing.Size(209, 20)
        Me.txServidor.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "SERVIDOR:"
        '
        'txUsuario
        '
        Me.txUsuario.Location = New System.Drawing.Point(117, 94)
        Me.txUsuario.Name = "txUsuario"
        Me.txUsuario.Size = New System.Drawing.Size(209, 20)
        Me.txUsuario.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "USUARIO:"
        '
        'txPassword
        '
        Me.txPassword.Location = New System.Drawing.Point(117, 133)
        Me.txPassword.Name = "txPassword"
        Me.txPassword.Size = New System.Drawing.Size(209, 20)
        Me.txPassword.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PASSWORD:"
        '
        'txBasedatos
        '
        Me.txBasedatos.Location = New System.Drawing.Point(117, 171)
        Me.txBasedatos.Name = "txBasedatos"
        Me.txBasedatos.Size = New System.Drawing.Size(209, 20)
        Me.txBasedatos.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "BASE DATOS:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(318, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(399, 231)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(486, 266)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txBasedatos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txServidor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACIÓN MYSQL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txServidor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txUsuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txBasedatos As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
