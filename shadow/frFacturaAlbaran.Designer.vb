<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frFacturaAlbaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frFacturaAlbaran))
        Me.txFechaFra = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txNumero = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txFechaH = New System.Windows.Forms.MaskedTextBox()
        Me.txFechaD = New System.Windows.Forms.MaskedTextBox()
        Me.btFiltroFecha = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txAlbaH = New System.Windows.Forms.TextBox()
        Me.txAlbaD = New System.Windows.Forms.TextBox()
        Me.btFiltroAlbaran = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btCargoClientes = New System.Windows.Forms.Button()
        Me.txCodcli = New System.Windows.Forms.TextBox()
        Me.dgClientes = New System.Windows.Forms.DataGridView()
        Me.dgAlbaranes = New System.Windows.Forms.DataGridView()
        Me.btFacturarTodos = New System.Windows.Forms.Button()
        Me.btFacturarSelec = New System.Windows.Forms.Button()
        Me.tsBotones = New System.Windows.Forms.ToolStrip()
        Me.cmdNuevo = New System.Windows.Forms.ToolStripButton()
        Me.cmdGuardar = New System.Windows.Forms.ToolStripButton()
        Me.cmdCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdImprimir = New System.Windows.Forms.ToolStripButton()
        Me.cmdPDF = New System.Windows.Forms.ToolStripButton()
        Me.cmdMail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRentabilidad = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.txCliente = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAlbaranes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'txFechaFra
        '
        Me.txFechaFra.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txFechaFra.Location = New System.Drawing.Point(241, 59)
        Me.txFechaFra.Mask = "00/00/0000"
        Me.txFechaFra.Name = "txFechaFra"
        Me.txFechaFra.Size = New System.Drawing.Size(81, 20)
        Me.txFechaFra.TabIndex = 105
        Me.txFechaFra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txFechaFra.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "FECHA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "NUMERO:"
        '
        'txNumero
        '
        Me.txNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txNumero.Location = New System.Drawing.Point(95, 59)
        Me.txNumero.Name = "txNumero"
        Me.txNumero.ReadOnly = True
        Me.txNumero.Size = New System.Drawing.Size(74, 20)
        Me.txNumero.TabIndex = 104
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txFechaH)
        Me.GroupBox1.Controls.Add(Me.txFechaD)
        Me.GroupBox1.Controls.Add(Me.btFiltroFecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 79)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FECHAS"
        '
        'txFechaH
        '
        Me.txFechaH.Location = New System.Drawing.Point(212, 36)
        Me.txFechaH.Mask = "00/00/0000"
        Me.txFechaH.Name = "txFechaH"
        Me.txFechaH.Size = New System.Drawing.Size(81, 20)
        Me.txFechaH.TabIndex = 1
        '
        'txFechaD
        '
        Me.txFechaD.Location = New System.Drawing.Point(59, 36)
        Me.txFechaD.Mask = "00/00/0000"
        Me.txFechaD.Name = "txFechaD"
        Me.txFechaD.Size = New System.Drawing.Size(81, 20)
        Me.txFechaD.TabIndex = 0
        '
        'btFiltroFecha
        '
        Me.btFiltroFecha.Image = CType(resources.GetObject("btFiltroFecha.Image"), System.Drawing.Image)
        Me.btFiltroFecha.Location = New System.Drawing.Point(310, 30)
        Me.btFiltroFecha.Name = "btFiltroFecha"
        Me.btFiltroFecha.Size = New System.Drawing.Size(30, 30)
        Me.btFiltroFecha.TabIndex = 2
        Me.btFiltroFecha.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(161, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "HASTA:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "DESDE:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txAlbaH)
        Me.GroupBox2.Controls.Add(Me.txAlbaD)
        Me.GroupBox2.Controls.Add(Me.btFiltroAlbaran)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(424, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 79)
        Me.GroupBox2.TabIndex = 107
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ALBARANES"
        '
        'txAlbaH
        '
        Me.txAlbaH.Location = New System.Drawing.Point(225, 36)
        Me.txAlbaH.Name = "txAlbaH"
        Me.txAlbaH.Size = New System.Drawing.Size(74, 20)
        Me.txAlbaH.TabIndex = 4
        '
        'txAlbaD
        '
        Me.txAlbaD.Location = New System.Drawing.Point(65, 36)
        Me.txAlbaD.Name = "txAlbaD"
        Me.txAlbaD.Size = New System.Drawing.Size(74, 20)
        Me.txAlbaD.TabIndex = 3
        '
        'btFiltroAlbaran
        '
        Me.btFiltroAlbaran.Image = CType(resources.GetObject("btFiltroAlbaran.Image"), System.Drawing.Image)
        Me.btFiltroAlbaran.Location = New System.Drawing.Point(315, 30)
        Me.btFiltroAlbaran.Name = "btFiltroAlbaran"
        Me.btFiltroAlbaran.Size = New System.Drawing.Size(30, 30)
        Me.btFiltroAlbaran.TabIndex = 5
        Me.btFiltroAlbaran.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(173, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "HASTA:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "DESDE:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "CLIENTE:"
        '
        'btCargoClientes
        '
        Me.btCargoClientes.Image = CType(resources.GetObject("btCargoClientes.Image"), System.Drawing.Image)
        Me.btCargoClientes.Location = New System.Drawing.Point(579, 180)
        Me.btCargoClientes.Name = "btCargoClientes"
        Me.btCargoClientes.Size = New System.Drawing.Size(30, 30)
        Me.btCargoClientes.TabIndex = 7
        Me.btCargoClientes.UseVisualStyleBackColor = True
        '
        'txCodcli
        '
        Me.txCodcli.BackColor = System.Drawing.Color.White
        Me.txCodcli.Location = New System.Drawing.Point(615, 186)
        Me.txCodcli.Name = "txCodcli"
        Me.txCodcli.ReadOnly = True
        Me.txCodcli.Size = New System.Drawing.Size(42, 20)
        Me.txCodcli.TabIndex = 115
        Me.txCodcli.Visible = False
        '
        'dgClientes
        '
        Me.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgClientes.Location = New System.Drawing.Point(91, 212)
        Me.dgClientes.Name = "dgClientes"
        Me.dgClientes.Size = New System.Drawing.Size(472, 103)
        Me.dgClientes.TabIndex = 116
        '
        'dgAlbaranes
        '
        Me.dgAlbaranes.AllowUserToAddRows = False
        Me.dgAlbaranes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAlbaranes.Location = New System.Drawing.Point(29, 226)
        Me.dgAlbaranes.Name = "dgAlbaranes"
        Me.dgAlbaranes.Size = New System.Drawing.Size(775, 231)
        Me.dgAlbaranes.TabIndex = 117
        '
        'btFacturarTodos
        '
        Me.btFacturarTodos.Location = New System.Drawing.Point(529, 480)
        Me.btFacturarTodos.Name = "btFacturarTodos"
        Me.btFacturarTodos.Size = New System.Drawing.Size(128, 23)
        Me.btFacturarTodos.TabIndex = 9
        Me.btFacturarTodos.Text = "Facturar Todos"
        Me.btFacturarTodos.UseVisualStyleBackColor = True
        '
        'btFacturarSelec
        '
        Me.btFacturarSelec.Location = New System.Drawing.Point(676, 480)
        Me.btFacturarSelec.Name = "btFacturarSelec"
        Me.btFacturarSelec.Size = New System.Drawing.Size(128, 23)
        Me.btFacturarSelec.TabIndex = 8
        Me.btFacturarSelec.Text = "Facturar Seleccionados"
        Me.btFacturarSelec.UseVisualStyleBackColor = True
        '
        'tsBotones
        '
        Me.tsBotones.AutoSize = False
        Me.tsBotones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdNuevo, Me.cmdGuardar, Me.cmdCancelar, Me.ToolStripButton2, Me.cmdImprimir, Me.cmdPDF, Me.cmdMail, Me.ToolStripButton7, Me.cmdRentabilidad, Me.ToolStripSeparator3})
        Me.tsBotones.Location = New System.Drawing.Point(0, 0)
        Me.tsBotones.Name = "tsBotones"
        Me.tsBotones.Size = New System.Drawing.Size(834, 38)
        Me.tsBotones.TabIndex = 120
        Me.tsBotones.Text = "ToolStrip1"
        '
        'cmdNuevo
        '
        Me.cmdNuevo.AutoSize = False
        Me.cmdNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNuevo.Image = CType(resources.GetObject("cmdNuevo.Image"), System.Drawing.Image)
        Me.cmdNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(33, 30)
        Me.cmdNuevo.Text = "ToolStripButton1"
        Me.cmdNuevo.ToolTipText = "Nuevo Albarán"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AutoSize = False
        Me.cmdGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdGuardar.Enabled = False
        Me.cmdGuardar.Image = CType(resources.GetObject("cmdGuardar.Image"), System.Drawing.Image)
        Me.cmdGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(33, 30)
        Me.cmdGuardar.Text = "ToolStripButton1"
        Me.cmdGuardar.ToolTipText = "Guardar Albarán"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.AutoSize = False
        Me.cmdCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(33, 30)
        Me.cmdCancelar.Text = "ToolStripButton1"
        Me.cmdCancelar.ToolTipText = "Cancelar Albarán"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(33, 30)
        '
        'cmdImprimir
        '
        Me.cmdImprimir.AutoSize = False
        Me.cmdImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdImprimir.Image = CType(resources.GetObject("cmdImprimir.Image"), System.Drawing.Image)
        Me.cmdImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(33, 30)
        Me.cmdImprimir.Text = "ToolStripButton1"
        Me.cmdImprimir.ToolTipText = "Imprimir"
        '
        'cmdPDF
        '
        Me.cmdPDF.AutoSize = False
        Me.cmdPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPDF.Image = CType(resources.GetObject("cmdPDF.Image"), System.Drawing.Image)
        Me.cmdPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPDF.Name = "cmdPDF"
        Me.cmdPDF.Size = New System.Drawing.Size(33, 30)
        Me.cmdPDF.Text = "ToolStripButton1"
        Me.cmdPDF.ToolTipText = "Convertir a PDF"
        '
        'cmdMail
        '
        Me.cmdMail.AutoSize = False
        Me.cmdMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdMail.Image = CType(resources.GetObject("cmdMail.Image"), System.Drawing.Image)
        Me.cmdMail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdMail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdMail.Name = "cmdMail"
        Me.cmdMail.Size = New System.Drawing.Size(33, 30)
        Me.cmdMail.Text = "ToolStripButton1"
        Me.cmdMail.ToolTipText = "Enviar por Email"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.AutoSize = False
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(33, 30)
        '
        'cmdRentabilidad
        '
        Me.cmdRentabilidad.AutoSize = False
        Me.cmdRentabilidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRentabilidad.Image = CType(resources.GetObject("cmdRentabilidad.Image"), System.Drawing.Image)
        Me.cmdRentabilidad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdRentabilidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRentabilidad.Name = "cmdRentabilidad"
        Me.cmdRentabilidad.Size = New System.Drawing.Size(33, 30)
        Me.cmdRentabilidad.Text = "ToolStripButton1"
        Me.cmdRentabilidad.ToolTipText = "Rentabilidad"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(33, 30)
        '
        'txCliente
        '
        Me.txCliente.Location = New System.Drawing.Point(91, 186)
        Me.txCliente.Name = "txCliente"
        Me.txCliente.Size = New System.Drawing.Size(472, 20)
        Me.txCliente.TabIndex = 6
        '
        'frFacturaAlbaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(834, 541)
        Me.Controls.Add(Me.txCliente)
        Me.Controls.Add(Me.tsBotones)
        Me.Controls.Add(Me.dgClientes)
        Me.Controls.Add(Me.btFacturarSelec)
        Me.Controls.Add(Me.btFacturarTodos)
        Me.Controls.Add(Me.dgAlbaranes)
        Me.Controls.Add(Me.txCodcli)
        Me.Controls.Add(Me.btCargoClientes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txFechaFra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txNumero)
        Me.Name = "frFacturaAlbaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FACTURACIÓN DE ALBARANES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAlbaranes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsBotones.ResumeLayout(False)
        Me.tsBotones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txFechaFra As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txNumero As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btFiltroFecha As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btFiltroAlbaran As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btCargoClientes As Button
    Friend WithEvents txCodcli As TextBox
    Friend WithEvents dgClientes As DataGridView
    Friend WithEvents dgAlbaranes As DataGridView
    Friend WithEvents btFacturarTodos As Button
    Friend WithEvents btFacturarSelec As Button
    Friend WithEvents tsBotones As ToolStrip
    Friend WithEvents cmdNuevo As ToolStripButton
    Friend WithEvents cmdGuardar As ToolStripButton
    Friend WithEvents cmdCancelar As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripSeparator
    Friend WithEvents cmdImprimir As ToolStripButton
    Friend WithEvents cmdPDF As ToolStripButton
    Friend WithEvents cmdMail As ToolStripButton
    Friend WithEvents ToolStripButton7 As ToolStripSeparator
    Friend WithEvents cmdRentabilidad As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents txCliente As TextBox
    Friend WithEvents txFechaH As MaskedTextBox
    Friend WithEvents txFechaD As MaskedTextBox
    Friend WithEvents txAlbaH As TextBox
    Friend WithEvents txAlbaD As TextBox
End Class
