<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frVerArticulos
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
        Me.dgArticulos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txArticulo = New System.Windows.Forms.TextBox()
        Me.txCodigo = New System.Windows.Forms.TextBox()
        CType(Me.dgArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgArticulos
        '
        Me.dgArticulos.AllowUserToAddRows = False
        Me.dgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgArticulos.Location = New System.Drawing.Point(12, 115)
        Me.dgArticulos.Name = "dgArticulos"
        Me.dgArticulos.Size = New System.Drawing.Size(955, 334)
        Me.dgArticulos.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CÓDIGO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ARTÍCULO:"
        '
        'txArticulo
        '
        Me.txArticulo.Location = New System.Drawing.Point(82, 62)
        Me.txArticulo.Name = "txArticulo"
        Me.txArticulo.Size = New System.Drawing.Size(630, 20)
        Me.txArticulo.TabIndex = 0
        '
        'txCodigo
        '
        Me.txCodigo.Location = New System.Drawing.Point(82, 29)
        Me.txCodigo.Name = "txCodigo"
        Me.txCodigo.Size = New System.Drawing.Size(630, 20)
        Me.txCodigo.TabIndex = 2
        '
        'frVerArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 461)
        Me.Controls.Add(Me.txCodigo)
        Me.Controls.Add(Me.txArticulo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgArticulos)
        Me.Name = "frVerArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de Artículos"
        CType(Me.dgArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgArticulos As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txArticulo As TextBox
    Friend WithEvents txCodigo As TextBox
End Class
