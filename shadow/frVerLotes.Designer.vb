<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frVerLotes
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
        Me.dgLotes = New System.Windows.Forms.DataGridView()
        Me.txLote = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgLotes
        '
        Me.dgLotes.AllowUserToAddRows = False
        Me.dgLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLotes.Location = New System.Drawing.Point(12, 86)
        Me.dgLotes.Name = "dgLotes"
        Me.dgLotes.Size = New System.Drawing.Size(495, 377)
        Me.dgLotes.TabIndex = 1
        '
        'txLote
        '
        Me.txLote.Location = New System.Drawing.Point(73, 37)
        Me.txLote.Name = "txLote"
        Me.txLote.Size = New System.Drawing.Size(434, 20)
        Me.txLote.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "LOTES:"
        '
        'frVerLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(519, 475)
        Me.Controls.Add(Me.txLote)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgLotes)
        Me.Name = "frVerLotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECCIÓN DE LOTES"
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgLotes As DataGridView
    Friend WithEvents txLote As TextBox
    Friend WithEvents Label1 As Label
End Class
