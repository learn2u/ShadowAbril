<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frCrearLotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frCrearLotes))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgLotes = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txReferencia = New System.Windows.Forms.TextBox()
        Me.txDescripcion = New System.Windows.Forms.TextBox()
        Me.txLote = New System.Windows.Forms.TextBox()
        Me.txStock = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txUbicacion = New System.Windows.Forms.TextBox()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.btEliminar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgLotes
        '
        Me.dgLotes.AllowUserToAddRows = False
        Me.dgLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgLotes.Location = New System.Drawing.Point(12, 44)
        Me.dgLotes.Name = "dgLotes"
        Me.dgLotes.Size = New System.Drawing.Size(745, 218)
        Me.dgLotes.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "REFERENCIA:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "DESCRIPCIÓN:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 341)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "LOTE:"
        '
        'txReferencia
        '
        Me.txReferencia.Location = New System.Drawing.Point(116, 289)
        Me.txReferencia.Name = "txReferencia"
        Me.txReferencia.Size = New System.Drawing.Size(100, 20)
        Me.txReferencia.TabIndex = 0
        '
        'txDescripcion
        '
        Me.txDescripcion.Location = New System.Drawing.Point(116, 315)
        Me.txDescripcion.Name = "txDescripcion"
        Me.txDescripcion.Size = New System.Drawing.Size(268, 20)
        Me.txDescripcion.TabIndex = 1
        '
        'txLote
        '
        Me.txLote.Location = New System.Drawing.Point(116, 341)
        Me.txLote.Name = "txLote"
        Me.txLote.Size = New System.Drawing.Size(156, 20)
        Me.txLote.TabIndex = 2
        '
        'txStock
        '
        Me.txStock.Location = New System.Drawing.Point(552, 289)
        Me.txStock.Name = "txStock"
        Me.txStock.Size = New System.Drawing.Size(100, 20)
        Me.txStock.TabIndex = 3
        Me.txStock.Text = "0"
        Me.txStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(460, 289)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "STOCK INICIAL:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(446, 315)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "FECHA ENTRADA:"
        '
        'txFecha
        '
        Me.txFecha.Location = New System.Drawing.Point(552, 315)
        Me.txFecha.Mask = "00/00/0000"
        Me.txFecha.Name = "txFecha"
        Me.txFecha.Size = New System.Drawing.Size(100, 20)
        Me.txFecha.TabIndex = 4
        Me.txFecha.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(478, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "UBICACIÓN:"
        '
        'txUbicacion
        '
        Me.txUbicacion.Location = New System.Drawing.Point(552, 341)
        Me.txUbicacion.Name = "txUbicacion"
        Me.txUbicacion.Size = New System.Drawing.Size(100, 20)
        Me.txUbicacion.TabIndex = 5
        '
        'btGuardar
        '
        Me.btGuardar.BackgroundImage = CType(resources.GetObject("btGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btGuardar.Location = New System.Drawing.Point(12, 7)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(29, 31)
        Me.btGuardar.TabIndex = 7
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.BackgroundImage = CType(resources.GetObject("btCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btCancelar.Location = New System.Drawing.Point(47, 7)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(29, 31)
        Me.btCancelar.TabIndex = 8
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'btEliminar
        '
        Me.btEliminar.BackgroundImage = CType(resources.GetObject("btEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btEliminar.Location = New System.Drawing.Point(728, 370)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(29, 31)
        Me.btEliminar.TabIndex = 9
        Me.btEliminar.UseVisualStyleBackColor = True
        '
        'btNuevo
        '
        Me.btNuevo.BackgroundImage = CType(resources.GetObject("btNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btNuevo.Location = New System.Drawing.Point(693, 370)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(29, 31)
        Me.btNuevo.TabIndex = 6
        Me.btNuevo.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "REFERENCIA"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "DESCRIPCIÓN"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 255
        '
        'Column3
        '
        Me.Column3.HeaderText = "LOTE"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column4.HeaderText = "STOCK"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "FECHA"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 75
        '
        'Column6
        '
        Me.Column6.HeaderText = "UBICACIÓN"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 110
        '
        'frCrearLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(769, 413)
        Me.Controls.Add(Me.btNuevo)
        Me.Controls.Add(Me.btEliminar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.txUbicacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txStock)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txLote)
        Me.Controls.Add(Me.txDescripcion)
        Me.Controls.Add(Me.txReferencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgLotes)
        Me.Name = "frCrearLotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE LOTES"
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgLotes As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txReferencia As TextBox
    Friend WithEvents txDescripcion As TextBox
    Friend WithEvents txLote As TextBox
    Friend WithEvents txStock As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txFecha As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txUbicacion As TextBox
    Friend WithEvents btGuardar As Button
    Friend WithEvents btCancelar As Button
    Friend WithEvents btEliminar As Button
    Friend WithEvents btNuevo As Button
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
