<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frRecalcular
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
        Me.btRecalculoPres = New System.Windows.Forms.Button()
        Me.btRacalculoPed = New System.Windows.Forms.Button()
        Me.btRecalcularAlba = New System.Windows.Forms.Button()
        Me.btRecalcularFactu = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btRecalculoPres
        '
        Me.btRecalculoPres.Location = New System.Drawing.Point(45, 52)
        Me.btRecalculoPres.Name = "btRecalculoPres"
        Me.btRecalculoPres.Size = New System.Drawing.Size(277, 41)
        Me.btRecalculoPres.TabIndex = 0
        Me.btRecalculoPres.Text = "Recalcular Totales Presupuestos"
        Me.btRecalculoPres.UseVisualStyleBackColor = True
        '
        'btRacalculoPed
        '
        Me.btRacalculoPed.Enabled = False
        Me.btRacalculoPed.Location = New System.Drawing.Point(45, 112)
        Me.btRacalculoPed.Name = "btRacalculoPed"
        Me.btRacalculoPed.Size = New System.Drawing.Size(277, 41)
        Me.btRacalculoPed.TabIndex = 1
        Me.btRacalculoPed.Text = "Recalcular Totales Pedidos"
        Me.btRacalculoPed.UseVisualStyleBackColor = True
        '
        'btRecalcularAlba
        '
        Me.btRecalcularAlba.Location = New System.Drawing.Point(45, 172)
        Me.btRecalcularAlba.Name = "btRecalcularAlba"
        Me.btRecalcularAlba.Size = New System.Drawing.Size(277, 41)
        Me.btRecalcularAlba.TabIndex = 2
        Me.btRecalcularAlba.Text = "Recalcular Totales Albaranes"
        Me.btRecalcularAlba.UseVisualStyleBackColor = True
        '
        'btRecalcularFactu
        '
        Me.btRecalcularFactu.Enabled = False
        Me.btRecalcularFactu.Location = New System.Drawing.Point(45, 235)
        Me.btRecalcularFactu.Name = "btRecalcularFactu"
        Me.btRecalcularFactu.Size = New System.Drawing.Size(277, 41)
        Me.btRecalcularFactu.TabIndex = 3
        Me.btRecalcularFactu.Text = "Recalcular Totales Facturas"
        Me.btRecalcularFactu.UseVisualStyleBackColor = True
        '
        'frRecalcular
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 323)
        Me.Controls.Add(Me.btRecalcularFactu)
        Me.Controls.Add(Me.btRecalcularAlba)
        Me.Controls.Add(Me.btRacalculoPed)
        Me.Controls.Add(Me.btRecalculoPres)
        Me.Name = "frRecalcular"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECALCULAR TOTALES"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btRecalculoPres As Button
    Friend WithEvents btRacalculoPed As Button
    Friend WithEvents btRecalcularAlba As Button
    Friend WithEvents btRecalcularFactu As Button
End Class
