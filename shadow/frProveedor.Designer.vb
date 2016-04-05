<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frProveedor))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgClientes = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tsBotones = New System.Windows.Forms.ToolStrip()
        Me.cmdNuevo = New System.Windows.Forms.ToolStripButton()
        Me.cmdGuardar = New System.Windows.Forms.ToolStripButton()
        Me.cmdCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ckTipo = New System.Windows.Forms.CheckBox()
        Me.cbProvincia = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txContacto2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txContacto1 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txTel1 = New System.Windows.Forms.TextBox()
        Me.txPais = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txNComercial = New System.Windows.Forms.TextBox()
        Me.txObservaciones = New System.Windows.Forms.TextBox()
        Me.txCodigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txNFiscal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txTel2 = New System.Windows.Forms.TextBox()
        Me.txWeb = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txFax = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txMovil = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txTel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txCpostal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txPoblacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txDomicilio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txCif = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.cbFormapago = New System.Windows.Forms.ComboBox()
        Me.grBanco = New System.Windows.Forms.GroupBox()
        Me.txBanco = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txBic = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txIban = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txCCC = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chRecargo = New System.Windows.Forms.CheckBox()
        Me.chIVA = New System.Windows.Forms.CheckBox()
        Me.txPago1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txDescuento = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txFechaAlta = New System.Windows.Forms.MaskedTextBox()
        Me.txLibre3 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txLibre2 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txLibre1 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txEmergente = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txHorario = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.tsBotones.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.grBanco.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(936, 589)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgClientes)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(928, 563)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PROVEEDORES"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgClientes
        '
        Me.dgClientes.AllowUserToAddRows = False
        Me.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgClientes.Location = New System.Drawing.Point(6, 18)
        Me.dgClientes.Name = "dgClientes"
        Me.dgClientes.Size = New System.Drawing.Size(907, 527)
        Me.dgClientes.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tsBotones)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(928, 563)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DATOS PROVEEDOR"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tsBotones
        '
        Me.tsBotones.AutoSize = False
        Me.tsBotones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdNuevo, Me.cmdGuardar, Me.cmdCancelar, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.tsBotones.Location = New System.Drawing.Point(3, 3)
        Me.tsBotones.Name = "tsBotones"
        Me.tsBotones.Size = New System.Drawing.Size(922, 38)
        Me.tsBotones.TabIndex = 56
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
        Me.cmdNuevo.ToolTipText = "Nuevo Presupuesto"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AutoSize = False
        Me.cmdGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdGuardar.Image = CType(resources.GetObject("cmdGuardar.Image"), System.Drawing.Image)
        Me.cmdGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(33, 30)
        Me.cmdGuardar.Text = "ToolStripButton1"
        Me.cmdGuardar.ToolTipText = "Guardar Presupuesto"
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
        Me.cmdCancelar.ToolTipText = "Cancelar Presupuesto"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(33, 30)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(33, 30)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Imprimir"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Location = New System.Drawing.Point(21, 52)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(901, 505)
        Me.TabControl2.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ckTipo)
        Me.TabPage4.Controls.Add(Me.cbProvincia)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Controls.Add(Me.txContacto2)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.txContacto1)
        Me.TabPage4.Controls.Add(Me.Label31)
        Me.TabPage4.Controls.Add(Me.txTel1)
        Me.TabPage4.Controls.Add(Me.txPais)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.txNComercial)
        Me.TabPage4.Controls.Add(Me.txObservaciones)
        Me.TabPage4.Controls.Add(Me.txCodigo)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.txNFiscal)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.txTel2)
        Me.TabPage4.Controls.Add(Me.txWeb)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.txEmail)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.txFax)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.txMovil)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.txTel)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.txCpostal)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.txPoblacion)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.txDomicilio)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.txCif)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(893, 479)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "GENERAL"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ckTipo
        '
        Me.ckTipo.AutoSize = True
        Me.ckTipo.Checked = True
        Me.ckTipo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckTipo.Location = New System.Drawing.Point(265, 21)
        Me.ckTipo.Name = "ckTipo"
        Me.ckTipo.Size = New System.Drawing.Size(94, 17)
        Me.ckTipo.TabIndex = 85
        Me.ckTipo.Text = "PROVEEDOR"
        Me.ckTipo.UseVisualStyleBackColor = True
        '
        'cbProvincia
        '
        Me.cbProvincia.FormattingEnabled = True
        Me.cbProvincia.Location = New System.Drawing.Point(150, 200)
        Me.cbProvincia.Name = "cbProvincia"
        Me.cbProvincia.Size = New System.Drawing.Size(449, 21)
        Me.cbProvincia.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 388)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "OBSERVACIONES:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(529, 314)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 82
        Me.Label15.Text = "TELÉFONO:"
        '
        'txContacto2
        '
        Me.txContacto2.Location = New System.Drawing.Point(150, 307)
        Me.txContacto2.Name = "txContacto2"
        Me.txContacto2.Size = New System.Drawing.Size(364, 20)
        Me.txContacto2.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(66, 314)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "CONTACTO 2:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(529, 288)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "TELÉFONO:"
        '
        'txContacto1
        '
        Me.txContacto1.Location = New System.Drawing.Point(150, 281)
        Me.txContacto1.Name = "txContacto1"
        Me.txContacto1.Size = New System.Drawing.Size(364, 20)
        Me.txContacto1.TabIndex = 11
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(66, 288)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(78, 13)
        Me.Label31.TabIndex = 77
        Me.Label31.Text = "CONTACTO 1:"
        '
        'txTel1
        '
        Me.txTel1.Location = New System.Drawing.Point(602, 281)
        Me.txTel1.Name = "txTel1"
        Me.txTel1.Size = New System.Drawing.Size(144, 20)
        Me.txTel1.TabIndex = 12
        '
        'txPais
        '
        Me.txPais.Location = New System.Drawing.Point(150, 227)
        Me.txPais.Name = "txPais"
        Me.txPais.Size = New System.Drawing.Size(196, 20)
        Me.txPais.TabIndex = 7
        Me.txPais.Text = "España"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(110, 234)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(34, 13)
        Me.Label30.TabIndex = 72
        Me.Label30.Text = "PAIS:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(79, 130)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 13)
        Me.Label29.TabIndex = 70
        Me.Label29.Text = "DOMICILIO:"
        '
        'txNComercial
        '
        Me.txNComercial.Location = New System.Drawing.Point(150, 96)
        Me.txNComercial.Name = "txNComercial"
        Me.txNComercial.Size = New System.Drawing.Size(449, 20)
        Me.txNComercial.TabIndex = 2
        '
        'txObservaciones
        '
        Me.txObservaciones.Location = New System.Drawing.Point(150, 385)
        Me.txObservaciones.Multiline = True
        Me.txObservaciones.Name = "txObservaciones"
        Me.txObservaciones.Size = New System.Drawing.Size(688, 88)
        Me.txObservaciones.TabIndex = 17
        '
        'txCodigo
        '
        Me.txCodigo.BackColor = System.Drawing.Color.Gainsboro
        Me.txCodigo.Enabled = False
        Me.txCodigo.Location = New System.Drawing.Point(150, 18)
        Me.txCodigo.Name = "txCodigo"
        Me.txCodigo.Size = New System.Drawing.Size(73, 20)
        Me.txCodigo.TabIndex = 65
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(92, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "CODIGO:"
        '
        'txNFiscal
        '
        Me.txNFiscal.Location = New System.Drawing.Point(150, 70)
        Me.txNFiscal.Name = "txNFiscal"
        Me.txNFiscal.Size = New System.Drawing.Size(449, 20)
        Me.txNFiscal.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(118, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "CIF:"
        '
        'txTel2
        '
        Me.txTel2.Location = New System.Drawing.Point(602, 307)
        Me.txTel2.Name = "txTel2"
        Me.txTel2.Size = New System.Drawing.Size(144, 20)
        Me.txTel2.TabIndex = 14
        '
        'txWeb
        '
        Me.txWeb.Location = New System.Drawing.Point(150, 359)
        Me.txWeb.Name = "txWeb"
        Me.txWeb.Size = New System.Drawing.Size(290, 20)
        Me.txWeb.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(109, 366)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "WEB:"
        '
        'txEmail
        '
        Me.txEmail.Location = New System.Drawing.Point(150, 333)
        Me.txEmail.Name = "txEmail"
        Me.txEmail.Size = New System.Drawing.Size(290, 20)
        Me.txEmail.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(102, 340)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "EMAIL:"
        '
        'txFax
        '
        Me.txFax.Location = New System.Drawing.Point(552, 255)
        Me.txFax.Name = "txFax"
        Me.txFax.Size = New System.Drawing.Size(144, 20)
        Me.txFax.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(516, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "FAX:"
        '
        'txMovil
        '
        Me.txMovil.Location = New System.Drawing.Point(356, 255)
        Me.txMovil.Name = "txMovil"
        Me.txMovil.Size = New System.Drawing.Size(144, 20)
        Me.txMovil.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(307, 262)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "MÓVIL:"
        '
        'txTel
        '
        Me.txTel.Location = New System.Drawing.Point(150, 255)
        Me.txTel.Name = "txTel"
        Me.txTel.Size = New System.Drawing.Size(144, 20)
        Me.txTel.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(77, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "TELÉFONO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(76, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "PROVINCIA:"
        '
        'txCpostal
        '
        Me.txCpostal.Location = New System.Drawing.Point(150, 175)
        Me.txCpostal.Name = "txCpostal"
        Me.txCpostal.Size = New System.Drawing.Size(103, 20)
        Me.txCpostal.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "COD.POSTAL:"
        '
        'txPoblacion
        '
        Me.txPoblacion.Location = New System.Drawing.Point(150, 149)
        Me.txPoblacion.Name = "txPoblacion"
        Me.txPoblacion.Size = New System.Drawing.Size(449, 20)
        Me.txPoblacion.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "POBLACIÓN:"
        '
        'txDomicilio
        '
        Me.txDomicilio.Location = New System.Drawing.Point(150, 123)
        Me.txDomicilio.Name = "txDomicilio"
        Me.txDomicilio.Size = New System.Drawing.Size(449, 20)
        Me.txDomicilio.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "NOMBRE COMERCIAL:"
        '
        'txCif
        '
        Me.txCif.Location = New System.Drawing.Point(150, 44)
        Me.txCif.Name = "txCif"
        Me.txCif.Size = New System.Drawing.Size(144, 20)
        Me.txCif.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "NOMBRE FISCAL:"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.cbFormapago)
        Me.TabPage5.Controls.Add(Me.grBanco)
        Me.TabPage5.Controls.Add(Me.chRecargo)
        Me.TabPage5.Controls.Add(Me.chIVA)
        Me.TabPage5.Controls.Add(Me.txPago1)
        Me.TabPage5.Controls.Add(Me.Label20)
        Me.TabPage5.Controls.Add(Me.Label19)
        Me.TabPage5.Controls.Add(Me.txDescuento)
        Me.TabPage5.Controls.Add(Me.Label18)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(893, 479)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "DATOS COMERCIALES"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'cbFormapago
        '
        Me.cbFormapago.FormattingEnabled = True
        Me.cbFormapago.Location = New System.Drawing.Point(108, 49)
        Me.cbFormapago.Name = "cbFormapago"
        Me.cbFormapago.Size = New System.Drawing.Size(187, 21)
        Me.cbFormapago.TabIndex = 80
        '
        'grBanco
        '
        Me.grBanco.Controls.Add(Me.txBanco)
        Me.grBanco.Controls.Add(Me.Label24)
        Me.grBanco.Controls.Add(Me.txBic)
        Me.grBanco.Controls.Add(Me.Label23)
        Me.grBanco.Controls.Add(Me.txIban)
        Me.grBanco.Controls.Add(Me.Label22)
        Me.grBanco.Controls.Add(Me.txCCC)
        Me.grBanco.Controls.Add(Me.Label21)
        Me.grBanco.Location = New System.Drawing.Point(108, 178)
        Me.grBanco.Name = "grBanco"
        Me.grBanco.Size = New System.Drawing.Size(579, 164)
        Me.grBanco.TabIndex = 70
        Me.grBanco.TabStop = False
        Me.grBanco.Text = "DATOS BANCARIOS"
        '
        'txBanco
        '
        Me.txBanco.Location = New System.Drawing.Point(75, 39)
        Me.txBanco.Name = "txBanco"
        Me.txBanco.Size = New System.Drawing.Size(449, 20)
        Me.txBanco.TabIndex = 75
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(22, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(47, 13)
        Me.Label24.TabIndex = 76
        Me.Label24.Text = "BANCO:"
        '
        'txBic
        '
        Me.txBic.Location = New System.Drawing.Point(75, 117)
        Me.txBic.Name = "txBic"
        Me.txBic.Size = New System.Drawing.Size(160, 20)
        Me.txBic.TabIndex = 73
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(42, 124)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 13)
        Me.Label23.TabIndex = 74
        Me.Label23.Text = "BIC:"
        '
        'txIban
        '
        Me.txIban.Location = New System.Drawing.Point(75, 91)
        Me.txIban.Name = "txIban"
        Me.txIban.Size = New System.Drawing.Size(255, 20)
        Me.txIban.TabIndex = 71
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(34, 98)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 13)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "IBAN:"
        '
        'txCCC
        '
        Me.txCCC.Location = New System.Drawing.Point(75, 65)
        Me.txCCC.Name = "txCCC"
        Me.txCCC.Size = New System.Drawing.Size(255, 20)
        Me.txCCC.TabIndex = 69
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(38, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "CCC:"
        '
        'chRecargo
        '
        Me.chRecargo.AutoSize = True
        Me.chRecargo.Location = New System.Drawing.Point(108, 144)
        Me.chRecargo.Name = "chRecargo"
        Me.chRecargo.Size = New System.Drawing.Size(160, 17)
        Me.chRecargo.TabIndex = 60
        Me.chRecargo.Text = "RECARGO EQUIVALENCIA"
        Me.chRecargo.UseVisualStyleBackColor = True
        '
        'chIVA
        '
        Me.chIVA.AutoSize = True
        Me.chIVA.Location = New System.Drawing.Point(108, 121)
        Me.chIVA.Name = "chIVA"
        Me.chIVA.Size = New System.Drawing.Size(43, 17)
        Me.chIVA.TabIndex = 59
        Me.chIVA.Text = "IVA"
        Me.chIVA.UseVisualStyleBackColor = True
        '
        'txPago1
        '
        Me.txPago1.Location = New System.Drawing.Point(108, 81)
        Me.txPago1.Name = "txPago1"
        Me.txPago1.Size = New System.Drawing.Size(56, 20)
        Me.txPago1.TabIndex = 55
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(34, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(68, 13)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "DIAS PAGO:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(25, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(81, 13)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "FORMA PAGO:"
        '
        'txDescuento
        '
        Me.txDescuento.Location = New System.Drawing.Point(108, 22)
        Me.txDescuento.Name = "txDescuento"
        Me.txDescuento.Size = New System.Drawing.Size(56, 20)
        Me.txDescuento.TabIndex = 49
        Me.txDescuento.Text = "0"
        Me.txDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(25, 29)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "DESCUENTO:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txFechaAlta)
        Me.TabPage3.Controls.Add(Me.txLibre3)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.txLibre2)
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.txLibre1)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.txEmergente)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.txHorario)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(893, 479)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "OTROS DATOS"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txFechaAlta
        '
        Me.txFechaAlta.BackColor = System.Drawing.Color.White
        Me.txFechaAlta.Location = New System.Drawing.Point(164, 21)
        Me.txFechaAlta.Mask = "00/00/0000"
        Me.txFechaAlta.Name = "txFechaAlta"
        Me.txFechaAlta.Size = New System.Drawing.Size(81, 20)
        Me.txFechaAlta.TabIndex = 102
        Me.txFechaAlta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txFechaAlta.ValidatingType = GetType(Date)
        '
        'txLibre3
        '
        Me.txLibre3.Location = New System.Drawing.Point(164, 280)
        Me.txLibre3.Name = "txLibre3"
        Me.txLibre3.Size = New System.Drawing.Size(658, 20)
        Me.txLibre3.TabIndex = 63
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(70, 287)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 13)
        Me.Label33.TabIndex = 64
        Me.Label33.Text = "CAMPO LIBRE3:"
        '
        'txLibre2
        '
        Me.txLibre2.Location = New System.Drawing.Point(164, 254)
        Me.txLibre2.Name = "txLibre2"
        Me.txLibre2.Size = New System.Drawing.Size(658, 20)
        Me.txLibre2.TabIndex = 61
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(70, 261)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 13)
        Me.Label32.TabIndex = 62
        Me.Label32.Text = "CAMPO LIBRE2:"
        '
        'txLibre1
        '
        Me.txLibre1.Location = New System.Drawing.Point(164, 228)
        Me.txLibre1.Name = "txLibre1"
        Me.txLibre1.Size = New System.Drawing.Size(658, 20)
        Me.txLibre1.TabIndex = 59
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(70, 235)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(88, 13)
        Me.Label28.TabIndex = 60
        Me.Label28.Text = "CAMPO LIBRE1:"
        '
        'txEmergente
        '
        Me.txEmergente.Location = New System.Drawing.Point(164, 77)
        Me.txEmergente.Multiline = True
        Me.txEmergente.Name = "txEmergente"
        Me.txEmergente.Size = New System.Drawing.Size(449, 145)
        Me.txEmergente.TabIndex = 57
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(27, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "MENSAJE EMERGENTE:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(83, 28)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(75, 13)
        Me.Label26.TabIndex = 56
        Me.Label26.Text = "FECHA ALTA:"
        '
        'txHorario
        '
        Me.txHorario.Location = New System.Drawing.Point(164, 47)
        Me.txHorario.Name = "txHorario"
        Me.txHorario.Size = New System.Drawing.Size(449, 20)
        Me.txHorario.TabIndex = 53
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(98, 54)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 13)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "HORARIO:"
        '
        'frProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(960, 624)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PROVEEDORES"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.tsBotones.ResumeLayout(False)
        Me.tsBotones.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.grBanco.ResumeLayout(False)
        Me.grBanco.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgClientes As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tsBotones As ToolStrip
    Friend WithEvents cmdNuevo As ToolStripButton
    Friend WithEvents cmdGuardar As ToolStripButton
    Friend WithEvents cmdCancelar As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents cbProvincia As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txContacto2 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txContacto1 As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txTel1 As TextBox
    Friend WithEvents txPais As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txNComercial As TextBox
    Friend WithEvents txObservaciones As TextBox
    Friend WithEvents txCodigo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txNFiscal As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txTel2 As TextBox
    Friend WithEvents txWeb As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txEmail As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txFax As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txMovil As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txTel As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txCpostal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txPoblacion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txDomicilio As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txCif As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents cbFormapago As ComboBox
    Friend WithEvents grBanco As GroupBox
    Friend WithEvents txBanco As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txBic As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txIban As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txCCC As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents chRecargo As CheckBox
    Friend WithEvents chIVA As CheckBox
    Friend WithEvents txPago1 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txDescuento As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txFechaAlta As MaskedTextBox
    Friend WithEvents txLibre3 As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txLibre2 As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txLibre1 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txEmergente As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txHorario As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents ckTipo As CheckBox
End Class
