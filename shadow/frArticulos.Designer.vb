<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frArticulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frArticulos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txCodigo1 = New System.Windows.Forms.TextBox()
        Me.txArticulo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgArticulos = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnLotes = New System.Windows.Forms.Panel()
        Me.txCorte = New System.Windows.Forms.TextBox()
        Me.txBakLote = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txFiltroLotes = New System.Windows.Forms.TextBox()
        Me.btGrabarLote = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txUbicLote = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txStockLote = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txLoteLote = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txDescLote = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txRefLote = New System.Windows.Forms.TextBox()
        Me.btEliminarLinea = New System.Windows.Forms.Button()
        Me.btNuevaLinea = New System.Windows.Forms.Button()
        Me.btCloseLotes = New System.Windows.Forms.Button()
        Me.dgLotes = New System.Windows.Forms.DataGridView()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsBotones = New System.Windows.Forms.ToolStrip()
        Me.cmdNuevo = New System.Windows.Forms.ToolStripButton()
        Me.cmdGuardar = New System.Windows.Forms.ToolStripButton()
        Me.cmdCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdLotes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdFlechas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdLonas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdDuplicar = New System.Windows.Forms.ToolStripButton()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.pnModelo = New System.Windows.Forms.Panel()
        Me.grModelo = New System.Windows.Forms.GroupBox()
        Me.dgMods = New System.Windows.Forms.DataGridView()
        Me.btCloseMod = New System.Windows.Forms.Button()
        Me.pnTejidos = New System.Windows.Forms.Panel()
        Me.grTejidos = New System.Windows.Forms.GroupBox()
        Me.dgTejidos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbColores = New System.Windows.Forms.ComboBox()
        Me.cbMedidas = New System.Windows.Forms.ComboBox()
        Me.txTejidoID = New System.Windows.Forms.TextBox()
        Me.btTejidos = New System.Windows.Forms.Button()
        Me.btModelo = New System.Windows.Forms.Button()
        Me.btProveedor = New System.Windows.Forms.Button()
        Me.cbFamilias = New System.Windows.Forms.ComboBox()
        Me.txModeloID = New System.Windows.Forms.TextBox()
        Me.txNumPro = New System.Windows.Forms.TextBox()
        Me.txProveedor = New System.Windows.Forms.TextBox()
        Me.txUbicacion = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbTipoArti = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ckControlStock = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txModelo = New System.Windows.Forms.TextBox()
        Me.cbTejido = New System.Windows.Forms.ComboBox()
        Me.txTejido = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txInicial = New System.Windows.Forms.TextBox()
        Me.txMinimo = New System.Windows.Forms.TextBox()
        Me.txStock = New System.Windows.Forms.TextBox()
        Me.txMargenEuro = New System.Windows.Forms.TextBox()
        Me.txDto = New System.Windows.Forms.TextBox()
        Me.txIva = New System.Windows.Forms.TextBox()
        Me.txGrupo = New System.Windows.Forms.TextBox()
        Me.txCompra = New System.Windows.Forms.TextBox()
        Me.txCodigo = New System.Windows.Forms.TextBox()
        Me.txDescripcion = New System.Windows.Forms.TextBox()
        Me.txPrecio = New System.Windows.Forms.TextBox()
        Me.txMargenPor = New System.Windows.Forms.TextBox()
        Me.txRefProv = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbUnidad = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbInfluye = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.pnLotes.SuspendLayout()
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsBotones.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.pnModelo.SuspendLayout()
        Me.grModelo.SuspendLayout()
        CType(Me.dgMods, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnTejidos.SuspendLayout()
        Me.grTejidos.SuspendLayout()
        CType(Me.dgTejidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(936, 589)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txCodigo1)
        Me.TabPage1.Controls.Add(Me.txArticulo)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.dgArticulos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(928, 563)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ARTICULOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txCodigo1
        '
        Me.txCodigo1.Location = New System.Drawing.Point(103, 13)
        Me.txCodigo1.Name = "txCodigo1"
        Me.txCodigo1.Size = New System.Drawing.Size(630, 20)
        Me.txCodigo1.TabIndex = 15
        '
        'txArticulo
        '
        Me.txArticulo.Location = New System.Drawing.Point(103, 46)
        Me.txArticulo.Name = "txArticulo"
        Me.txArticulo.Size = New System.Drawing.Size(630, 20)
        Me.txArticulo.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "ARTÍCULO:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(33, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "CÓDIGO:"
        '
        'dgArticulos
        '
        Me.dgArticulos.AllowUserToAddRows = False
        Me.dgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgArticulos.Location = New System.Drawing.Point(6, 86)
        Me.dgArticulos.Name = "dgArticulos"
        Me.dgArticulos.Size = New System.Drawing.Size(907, 459)
        Me.dgArticulos.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnLotes)
        Me.TabPage2.Controls.Add(Me.tsBotones)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(928, 563)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DATOS ARTICULO"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnLotes
        '
        Me.pnLotes.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.pnLotes.Controls.Add(Me.txCorte)
        Me.pnLotes.Controls.Add(Me.txBakLote)
        Me.pnLotes.Controls.Add(Me.Label22)
        Me.pnLotes.Controls.Add(Me.txFiltroLotes)
        Me.pnLotes.Controls.Add(Me.btGrabarLote)
        Me.pnLotes.Controls.Add(Me.Label21)
        Me.pnLotes.Controls.Add(Me.txUbicLote)
        Me.pnLotes.Controls.Add(Me.Label20)
        Me.pnLotes.Controls.Add(Me.txStockLote)
        Me.pnLotes.Controls.Add(Me.Label19)
        Me.pnLotes.Controls.Add(Me.txLoteLote)
        Me.pnLotes.Controls.Add(Me.Label18)
        Me.pnLotes.Controls.Add(Me.txDescLote)
        Me.pnLotes.Controls.Add(Me.Label17)
        Me.pnLotes.Controls.Add(Me.txRefLote)
        Me.pnLotes.Controls.Add(Me.btEliminarLinea)
        Me.pnLotes.Controls.Add(Me.btNuevaLinea)
        Me.pnLotes.Controls.Add(Me.btCloseLotes)
        Me.pnLotes.Controls.Add(Me.dgLotes)
        Me.pnLotes.Location = New System.Drawing.Point(52, 49)
        Me.pnLotes.Name = "pnLotes"
        Me.pnLotes.Size = New System.Drawing.Size(830, 415)
        Me.pnLotes.TabIndex = 147
        Me.pnLotes.Visible = False
        '
        'txCorte
        '
        Me.txCorte.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txCorte.ForeColor = System.Drawing.Color.White
        Me.txCorte.Location = New System.Drawing.Point(602, 371)
        Me.txCorte.Name = "txCorte"
        Me.txCorte.Size = New System.Drawing.Size(62, 20)
        Me.txCorte.TabIndex = 141
        Me.txCorte.Text = "0"
        Me.txCorte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txCorte.Visible = False
        '
        'txBakLote
        '
        Me.txBakLote.Location = New System.Drawing.Point(391, 375)
        Me.txBakLote.Name = "txBakLote"
        Me.txBakLote.Size = New System.Drawing.Size(100, 20)
        Me.txBakLote.TabIndex = 140
        Me.txBakLote.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(129, 54)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 13)
        Me.Label22.TabIndex = 139
        Me.Label22.Text = "LOTES"
        '
        'txFiltroLotes
        '
        Me.txFiltroLotes.Location = New System.Drawing.Point(178, 47)
        Me.txFiltroLotes.Name = "txFiltroLotes"
        Me.txFiltroLotes.Size = New System.Drawing.Size(570, 20)
        Me.txFiltroLotes.TabIndex = 138
        '
        'btGrabarLote
        '
        Me.btGrabarLote.Location = New System.Drawing.Point(723, 375)
        Me.btGrabarLote.Name = "btGrabarLote"
        Me.btGrabarLote.Size = New System.Drawing.Size(96, 23)
        Me.btGrabarLote.TabIndex = 137
        Me.btGrabarLote.Text = "Grabar Lote"
        Me.btGrabarLote.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(678, 329)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 136
        Me.Label21.Text = "UBICACIÓN"
        '
        'txUbicLote
        '
        Me.txUbicLote.Location = New System.Drawing.Point(671, 345)
        Me.txUbicLote.Name = "txUbicLote"
        Me.txUbicLote.Size = New System.Drawing.Size(148, 20)
        Me.txUbicLote.TabIndex = 135
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(607, 329)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 13)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "STOCK"
        '
        'txStockLote
        '
        Me.txStockLote.Location = New System.Drawing.Point(602, 345)
        Me.txStockLote.Name = "txStockLote"
        Me.txStockLote.Size = New System.Drawing.Size(62, 20)
        Me.txStockLote.TabIndex = 133
        Me.txStockLote.Text = "0"
        Me.txStockLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(500, 330)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "LOTE"
        '
        'txLoteLote
        '
        Me.txLoteLote.Location = New System.Drawing.Point(497, 345)
        Me.txLoteLote.Name = "txLoteLote"
        Me.txLoteLote.Size = New System.Drawing.Size(100, 20)
        Me.txLoteLote.TabIndex = 131
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(145, 329)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 130
        Me.Label18.Text = "DESCRIPCIÓN"
        '
        'txDescLote
        '
        Me.txDescLote.Location = New System.Drawing.Point(141, 345)
        Me.txDescLote.Name = "txDescLote"
        Me.txDescLote.Size = New System.Drawing.Size(350, 20)
        Me.txDescLote.TabIndex = 129
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 330)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "REFERENCIA"
        '
        'txRefLote
        '
        Me.txRefLote.Location = New System.Drawing.Point(10, 345)
        Me.txRefLote.Name = "txRefLote"
        Me.txRefLote.Size = New System.Drawing.Size(124, 20)
        Me.txRefLote.TabIndex = 127
        '
        'btEliminarLinea
        '
        Me.btEliminarLinea.BackgroundImage = CType(resources.GetObject("btEliminarLinea.BackgroundImage"), System.Drawing.Image)
        Me.btEliminarLinea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btEliminarLinea.Location = New System.Drawing.Point(40, 8)
        Me.btEliminarLinea.Name = "btEliminarLinea"
        Me.btEliminarLinea.Size = New System.Drawing.Size(24, 23)
        Me.btEliminarLinea.TabIndex = 126
        Me.btEliminarLinea.UseVisualStyleBackColor = True
        '
        'btNuevaLinea
        '
        Me.btNuevaLinea.BackgroundImage = CType(resources.GetObject("btNuevaLinea.BackgroundImage"), System.Drawing.Image)
        Me.btNuevaLinea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btNuevaLinea.Location = New System.Drawing.Point(10, 8)
        Me.btNuevaLinea.Name = "btNuevaLinea"
        Me.btNuevaLinea.Size = New System.Drawing.Size(24, 23)
        Me.btNuevaLinea.TabIndex = 125
        Me.btNuevaLinea.UseVisualStyleBackColor = True
        '
        'btCloseLotes
        '
        Me.btCloseLotes.BackgroundImage = CType(resources.GetObject("btCloseLotes.BackgroundImage"), System.Drawing.Image)
        Me.btCloseLotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btCloseLotes.Location = New System.Drawing.Point(795, 6)
        Me.btCloseLotes.Name = "btCloseLotes"
        Me.btCloseLotes.Size = New System.Drawing.Size(24, 23)
        Me.btCloseLotes.TabIndex = 123
        Me.btCloseLotes.UseVisualStyleBackColor = True
        '
        'dgLotes
        '
        Me.dgLotes.AllowUserToAddRows = False
        Me.dgLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.referencia, Me.descripcion, Me.lote, Me.stock, Me.ubicacion})
        Me.dgLotes.Location = New System.Drawing.Point(10, 77)
        Me.dgLotes.Name = "dgLotes"
        Me.dgLotes.Size = New System.Drawing.Size(809, 236)
        Me.dgLotes.TabIndex = 0
        '
        'referencia
        '
        Me.referencia.HeaderText = "REFERENCIA"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        Me.referencia.Width = 110
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "DESCRIPCION"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Width = 330
        '
        'lote
        '
        Me.lote.HeaderText = "LOTE"
        Me.lote.Name = "lote"
        '
        'stock
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.stock.DefaultCellStyle = DataGridViewCellStyle1
        Me.stock.HeaderText = "STOCK"
        Me.stock.Name = "stock"
        Me.stock.Width = 75
        '
        'ubicacion
        '
        Me.ubicacion.HeaderText = "UBICACION"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.Width = 150
        '
        'tsBotones
        '
        Me.tsBotones.AutoSize = False
        Me.tsBotones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdNuevo, Me.cmdGuardar, Me.cmdCancelar, Me.ToolStripSeparator1, Me.cmdLotes, Me.ToolStripSeparator2, Me.cmdFlechas, Me.ToolStripButton2, Me.cmdLonas, Me.ToolStripSeparator3, Me.cmdDuplicar})
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
        Me.cmdNuevo.ToolTipText = "Nuevo Artículo"
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
        Me.cmdGuardar.ToolTipText = "Guardar Artículo"
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
        Me.cmdCancelar.ToolTipText = "Cancelar Artículo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(33, 30)
        '
        'cmdLotes
        '
        Me.cmdLotes.AutoSize = False
        Me.cmdLotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLotes.Image = CType(resources.GetObject("cmdLotes.Image"), System.Drawing.Image)
        Me.cmdLotes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdLotes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLotes.Name = "cmdLotes"
        Me.cmdLotes.Size = New System.Drawing.Size(33, 30)
        Me.cmdLotes.Text = "ToolStripButton1"
        Me.cmdLotes.ToolTipText = "Creación / Consulta de lotes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(33, 30)
        '
        'cmdFlechas
        '
        Me.cmdFlechas.AutoSize = False
        Me.cmdFlechas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFlechas.Image = CType(resources.GetObject("cmdFlechas.Image"), System.Drawing.Image)
        Me.cmdFlechas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdFlechas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdFlechas.Name = "cmdFlechas"
        Me.cmdFlechas.Size = New System.Drawing.Size(33, 30)
        Me.cmdFlechas.Text = "ToolStripButton1"
        Me.cmdFlechas.ToolTipText = "Imprimir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(33, 30)
        '
        'cmdLonas
        '
        Me.cmdLonas.AutoSize = False
        Me.cmdLonas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLonas.Image = CType(resources.GetObject("cmdLonas.Image"), System.Drawing.Image)
        Me.cmdLonas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdLonas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLonas.Name = "cmdLonas"
        Me.cmdLonas.Size = New System.Drawing.Size(33, 30)
        Me.cmdLonas.Text = "ToolStripButton1"
        Me.cmdLonas.ToolTipText = "Activar Lonas"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(33, 30)
        '
        'cmdDuplicar
        '
        Me.cmdDuplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdDuplicar.Image = Global.shadow.My.Resources.Resources.interface24
        Me.cmdDuplicar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDuplicar.Name = "cmdDuplicar"
        Me.cmdDuplicar.Size = New System.Drawing.Size(28, 35)
        Me.cmdDuplicar.Text = "ToolStripButton1"
        Me.cmdDuplicar.ToolTipText = "Duplicar Artículo"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(21, 52)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(901, 505)
        Me.TabControl2.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.pnModelo)
        Me.TabPage4.Controls.Add(Me.pnTejidos)
        Me.TabPage4.Controls.Add(Me.cbColores)
        Me.TabPage4.Controls.Add(Me.cbMedidas)
        Me.TabPage4.Controls.Add(Me.txTejidoID)
        Me.TabPage4.Controls.Add(Me.btTejidos)
        Me.TabPage4.Controls.Add(Me.btModelo)
        Me.TabPage4.Controls.Add(Me.btProveedor)
        Me.TabPage4.Controls.Add(Me.cbFamilias)
        Me.TabPage4.Controls.Add(Me.txModeloID)
        Me.TabPage4.Controls.Add(Me.txNumPro)
        Me.TabPage4.Controls.Add(Me.txProveedor)
        Me.TabPage4.Controls.Add(Me.txUbicacion)
        Me.TabPage4.Controls.Add(Me.Label23)
        Me.TabPage4.Controls.Add(Me.cbTipoArti)
        Me.TabPage4.Controls.Add(Me.Label24)
        Me.TabPage4.Controls.Add(Me.ckControlStock)
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.txInicial)
        Me.TabPage4.Controls.Add(Me.txMinimo)
        Me.TabPage4.Controls.Add(Me.txStock)
        Me.TabPage4.Controls.Add(Me.txMargenEuro)
        Me.TabPage4.Controls.Add(Me.txDto)
        Me.TabPage4.Controls.Add(Me.txIva)
        Me.TabPage4.Controls.Add(Me.txGrupo)
        Me.TabPage4.Controls.Add(Me.txCompra)
        Me.TabPage4.Controls.Add(Me.txCodigo)
        Me.TabPage4.Controls.Add(Me.txDescripcion)
        Me.TabPage4.Controls.Add(Me.txPrecio)
        Me.TabPage4.Controls.Add(Me.txMargenPor)
        Me.TabPage4.Controls.Add(Me.txRefProv)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Controls.Add(Me.Label43)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.cbUnidad)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.cbInfluye)
        Me.TabPage4.Controls.Add(Me.Label42)
        Me.TabPage4.Controls.Add(Me.Label39)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(893, 479)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "GENERAL"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'pnModelo
        '
        Me.pnModelo.Controls.Add(Me.grModelo)
        Me.pnModelo.Location = New System.Drawing.Point(471, 33)
        Me.pnModelo.Name = "pnModelo"
        Me.pnModelo.Size = New System.Drawing.Size(401, 187)
        Me.pnModelo.TabIndex = 144
        Me.pnModelo.Visible = False
        '
        'grModelo
        '
        Me.grModelo.BackColor = System.Drawing.Color.White
        Me.grModelo.Controls.Add(Me.dgMods)
        Me.grModelo.Controls.Add(Me.btCloseMod)
        Me.grModelo.Location = New System.Drawing.Point(17, 8)
        Me.grModelo.Name = "grModelo"
        Me.grModelo.Size = New System.Drawing.Size(369, 164)
        Me.grModelo.TabIndex = 140
        Me.grModelo.TabStop = False
        Me.grModelo.Text = "MODELO"
        '
        'dgMods
        '
        Me.dgMods.AllowUserToAddRows = False
        Me.dgMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMods.Location = New System.Drawing.Point(6, 42)
        Me.dgMods.Name = "dgMods"
        Me.dgMods.Size = New System.Drawing.Size(354, 112)
        Me.dgMods.TabIndex = 123
        '
        'btCloseMod
        '
        Me.btCloseMod.BackgroundImage = CType(resources.GetObject("btCloseMod.BackgroundImage"), System.Drawing.Image)
        Me.btCloseMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btCloseMod.Location = New System.Drawing.Point(336, 12)
        Me.btCloseMod.Name = "btCloseMod"
        Me.btCloseMod.Size = New System.Drawing.Size(24, 23)
        Me.btCloseMod.TabIndex = 122
        Me.btCloseMod.UseVisualStyleBackColor = True
        '
        'pnTejidos
        '
        Me.pnTejidos.Controls.Add(Me.grTejidos)
        Me.pnTejidos.Location = New System.Drawing.Point(343, 42)
        Me.pnTejidos.Name = "pnTejidos"
        Me.pnTejidos.Size = New System.Drawing.Size(401, 186)
        Me.pnTejidos.TabIndex = 146
        Me.pnTejidos.Visible = False
        '
        'grTejidos
        '
        Me.grTejidos.BackColor = System.Drawing.Color.White
        Me.grTejidos.Controls.Add(Me.dgTejidos)
        Me.grTejidos.Controls.Add(Me.Button1)
        Me.grTejidos.Location = New System.Drawing.Point(17, 11)
        Me.grTejidos.Name = "grTejidos"
        Me.grTejidos.Size = New System.Drawing.Size(369, 164)
        Me.grTejidos.TabIndex = 141
        Me.grTejidos.TabStop = False
        Me.grTejidos.Text = "TEJIDOS"
        '
        'dgTejidos
        '
        Me.dgTejidos.AllowUserToAddRows = False
        Me.dgTejidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTejidos.Location = New System.Drawing.Point(6, 42)
        Me.dgTejidos.Name = "dgTejidos"
        Me.dgTejidos.Size = New System.Drawing.Size(354, 112)
        Me.dgTejidos.TabIndex = 123
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(336, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 23)
        Me.Button1.TabIndex = 122
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbColores
        '
        Me.cbColores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbColores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbColores.FormattingEnabled = True
        Me.cbColores.Location = New System.Drawing.Point(150, 256)
        Me.cbColores.Name = "cbColores"
        Me.cbColores.Size = New System.Drawing.Size(368, 21)
        Me.cbColores.TabIndex = 7
        '
        'cbMedidas
        '
        Me.cbMedidas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbMedidas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbMedidas.FormattingEnabled = True
        Me.cbMedidas.Location = New System.Drawing.Point(150, 283)
        Me.cbMedidas.Name = "cbMedidas"
        Me.cbMedidas.Size = New System.Drawing.Size(118, 21)
        Me.cbMedidas.TabIndex = 8
        '
        'txTejidoID
        '
        Me.txTejidoID.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txTejidoID.Location = New System.Drawing.Point(642, 154)
        Me.txTejidoID.Name = "txTejidoID"
        Me.txTejidoID.Size = New System.Drawing.Size(72, 20)
        Me.txTejidoID.TabIndex = 143
        Me.txTejidoID.Visible = False
        '
        'btTejidos
        '
        Me.btTejidos.BackColor = System.Drawing.Color.Gainsboro
        Me.btTejidos.BackgroundImage = CType(resources.GetObject("btTejidos.BackgroundImage"), System.Drawing.Image)
        Me.btTejidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btTejidos.Location = New System.Drawing.Point(606, 151)
        Me.btTejidos.Name = "btTejidos"
        Me.btTejidos.Size = New System.Drawing.Size(26, 23)
        Me.btTejidos.TabIndex = 142
        Me.btTejidos.UseVisualStyleBackColor = False
        '
        'btModelo
        '
        Me.btModelo.BackColor = System.Drawing.Color.Gainsboro
        Me.btModelo.BackgroundImage = CType(resources.GetObject("btModelo.BackgroundImage"), System.Drawing.Image)
        Me.btModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btModelo.Location = New System.Drawing.Point(606, 123)
        Me.btModelo.Name = "btModelo"
        Me.btModelo.Size = New System.Drawing.Size(26, 23)
        Me.btModelo.TabIndex = 138
        Me.btModelo.UseVisualStyleBackColor = False
        '
        'btProveedor
        '
        Me.btProveedor.BackColor = System.Drawing.Color.Gainsboro
        Me.btProveedor.BackgroundImage = CType(resources.GetObject("btProveedor.BackgroundImage"), System.Drawing.Image)
        Me.btProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btProveedor.Location = New System.Drawing.Point(606, 42)
        Me.btProveedor.Name = "btProveedor"
        Me.btProveedor.Size = New System.Drawing.Size(26, 23)
        Me.btProveedor.TabIndex = 4
        Me.btProveedor.UseVisualStyleBackColor = False
        '
        'cbFamilias
        '
        Me.cbFamilias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbFamilias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbFamilias.FormattingEnabled = True
        Me.cbFamilias.Location = New System.Drawing.Point(150, 226)
        Me.cbFamilias.Name = "cbFamilias"
        Me.cbFamilias.Size = New System.Drawing.Size(368, 21)
        Me.cbFamilias.TabIndex = 6
        '
        'txModeloID
        '
        Me.txModeloID.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txModeloID.Location = New System.Drawing.Point(642, 125)
        Me.txModeloID.Name = "txModeloID"
        Me.txModeloID.Size = New System.Drawing.Size(72, 20)
        Me.txModeloID.TabIndex = 131
        Me.txModeloID.Visible = False
        '
        'txNumPro
        '
        Me.txNumPro.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txNumPro.Location = New System.Drawing.Point(657, 44)
        Me.txNumPro.Name = "txNumPro"
        Me.txNumPro.Size = New System.Drawing.Size(100, 20)
        Me.txNumPro.TabIndex = 130
        Me.txNumPro.Visible = False
        '
        'txProveedor
        '
        Me.txProveedor.Location = New System.Drawing.Point(150, 45)
        Me.txProveedor.Name = "txProveedor"
        Me.txProveedor.Size = New System.Drawing.Size(449, 20)
        Me.txProveedor.TabIndex = 3
        '
        'txUbicacion
        '
        Me.txUbicacion.Location = New System.Drawing.Point(683, 248)
        Me.txUbicacion.Name = "txUbicacion"
        Me.txUbicacion.Size = New System.Drawing.Size(172, 20)
        Me.txUbicacion.TabIndex = 18
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(609, 255)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 13)
        Me.Label23.TabIndex = 127
        Me.Label23.Text = "UBICACION:"
        '
        'cbTipoArti
        '
        Me.cbTipoArti.FormattingEnabled = True
        Me.cbTipoArti.Location = New System.Drawing.Point(150, 343)
        Me.cbTipoArti.Name = "cbTipoArti"
        Me.cbTipoArti.Size = New System.Drawing.Size(171, 21)
        Me.cbTipoArti.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(41, 351)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(103, 13)
        Me.Label24.TabIndex = 124
        Me.Label24.Text = "TIPO ART. TOLDO:"
        '
        'ckControlStock
        '
        Me.ckControlStock.AutoSize = True
        Me.ckControlStock.Location = New System.Drawing.Point(684, 285)
        Me.ckControlStock.Name = "ckControlStock"
        Me.ckControlStock.Size = New System.Drawing.Size(188, 17)
        Me.ckControlStock.TabIndex = 19
        Me.ckControlStock.Text = "DESACTIVAR CONTROL STOCK"
        Me.ckControlStock.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txModelo)
        Me.GroupBox2.Controls.Add(Me.cbTejido)
        Me.GroupBox2.Controls.Add(Me.txTejido)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Location = New System.Drawing.Point(150, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 118)
        Me.GroupBox2.TabIndex = 121
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "LONAS"
        '
        'txModelo
        '
        Me.txModelo.Location = New System.Drawing.Point(81, 54)
        Me.txModelo.Name = "txModelo"
        Me.txModelo.Size = New System.Drawing.Size(352, 20)
        Me.txModelo.TabIndex = 98
        '
        'cbTejido
        '
        Me.cbTejido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTejido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTejido.FormattingEnabled = True
        Me.cbTejido.Items.AddRange(New Object() {"ACRILICO", "MICROPERFORADO", "PVC"})
        Me.cbTejido.Location = New System.Drawing.Point(81, 27)
        Me.cbTejido.Name = "cbTejido"
        Me.cbTejido.Size = New System.Drawing.Size(352, 21)
        Me.cbTejido.TabIndex = 97
        '
        'txTejido
        '
        Me.txTejido.Location = New System.Drawing.Point(81, 83)
        Me.txTejido.Name = "txTejido"
        Me.txTejido.Size = New System.Drawing.Size(194, 20)
        Me.txTejido.TabIndex = 95
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(27, 88)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(48, 13)
        Me.Label44.TabIndex = 94
        Me.Label44.Text = "TEJIDO:"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(6, 33)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(76, 13)
        Me.Label45.TabIndex = 93
        Me.Label45.Text = "TIPO TEJIDO:"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(22, 60)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(56, 13)
        Me.Label46.TabIndex = 92
        Me.Label46.Text = "MODELO:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(591, 395)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 120
        Me.Label16.Text = "STOCK INICIAL:"
        '
        'txInicial
        '
        Me.txInicial.Location = New System.Drawing.Point(684, 388)
        Me.txInicial.Name = "txInicial"
        Me.txInicial.Size = New System.Drawing.Size(73, 20)
        Me.txInicial.TabIndex = 22
        Me.txInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txMinimo
        '
        Me.txMinimo.Location = New System.Drawing.Point(684, 362)
        Me.txMinimo.Name = "txMinimo"
        Me.txMinimo.Size = New System.Drawing.Size(73, 20)
        Me.txMinimo.TabIndex = 21
        Me.txMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txStock
        '
        Me.txStock.Location = New System.Drawing.Point(684, 336)
        Me.txStock.Name = "txStock"
        Me.txStock.Size = New System.Drawing.Size(73, 20)
        Me.txStock.TabIndex = 20
        Me.txStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txMargenEuro
        '
        Me.txMargenEuro.Location = New System.Drawing.Point(298, 425)
        Me.txMargenEuro.Name = "txMargenEuro"
        Me.txMargenEuro.Size = New System.Drawing.Size(73, 20)
        Me.txMargenEuro.TabIndex = 16
        Me.txMargenEuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txDto
        '
        Me.txDto.Location = New System.Drawing.Point(413, 399)
        Me.txDto.Name = "txDto"
        Me.txDto.Size = New System.Drawing.Size(104, 20)
        Me.txDto.TabIndex = 14
        Me.txDto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txIva
        '
        Me.txIva.Location = New System.Drawing.Point(150, 370)
        Me.txIva.Name = "txIva"
        Me.txIva.Size = New System.Drawing.Size(43, 20)
        Me.txIva.TabIndex = 12
        Me.txIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txGrupo
        '
        Me.txGrupo.Location = New System.Drawing.Point(629, 18)
        Me.txGrupo.Name = "txGrupo"
        Me.txGrupo.Size = New System.Drawing.Size(85, 20)
        Me.txGrupo.TabIndex = 2
        '
        'txCompra
        '
        Me.txCompra.Location = New System.Drawing.Point(150, 399)
        Me.txCompra.Name = "txCompra"
        Me.txCompra.Size = New System.Drawing.Size(104, 20)
        Me.txCompra.TabIndex = 13
        Me.txCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txCodigo
        '
        Me.txCodigo.BackColor = System.Drawing.Color.White
        Me.txCodigo.Location = New System.Drawing.Point(400, 18)
        Me.txCodigo.Name = "txCodigo"
        Me.txCodigo.Size = New System.Drawing.Size(144, 20)
        Me.txCodigo.TabIndex = 1
        '
        'txDescripcion
        '
        Me.txDescripcion.Location = New System.Drawing.Point(150, 200)
        Me.txDescripcion.Name = "txDescripcion"
        Me.txDescripcion.Size = New System.Drawing.Size(449, 20)
        Me.txDescripcion.TabIndex = 5
        '
        'txPrecio
        '
        Me.txPrecio.Location = New System.Drawing.Point(425, 425)
        Me.txPrecio.Name = "txPrecio"
        Me.txPrecio.Size = New System.Drawing.Size(93, 20)
        Me.txPrecio.TabIndex = 17
        Me.txPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txMargenPor
        '
        Me.txMargenPor.Location = New System.Drawing.Point(150, 425)
        Me.txMargenPor.Name = "txMargenPor"
        Me.txMargenPor.Size = New System.Drawing.Size(73, 20)
        Me.txMargenPor.TabIndex = 15
        Me.txMargenPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txRefProv
        '
        Me.txRefProv.Location = New System.Drawing.Point(150, 18)
        Me.txRefProv.Name = "txRefProv"
        Me.txRefProv.Size = New System.Drawing.Size(144, 20)
        Me.txRefProv.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(588, 369)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "STOCK MINIMO:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(631, 343)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(46, 13)
        Me.Label43.TabIndex = 108
        Me.Label43.Text = "STOCK:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(229, 432)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "MARGEN €:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(259, 406)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 13)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "DESCUENTO PROVEEDOR:"
        '
        'cbUnidad
        '
        Me.cbUnidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbUnidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbUnidad.FormattingEnabled = True
        Me.cbUnidad.Location = New System.Drawing.Point(362, 284)
        Me.cbUnidad.Name = "cbUnidad"
        Me.cbUnidad.Size = New System.Drawing.Size(73, 21)
        Me.cbUnidad.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(274, 291)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "UND. MEDIDA:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(106, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "% IVA:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(66, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "PROVEEDOR:"
        '
        'cbInfluye
        '
        Me.cbInfluye.FormattingEnabled = True
        Me.cbInfluye.Location = New System.Drawing.Point(150, 316)
        Me.cbInfluye.Name = "cbInfluye"
        Me.cbInfluye.Size = New System.Drawing.Size(171, 21)
        Me.cbInfluye.TabIndex = 10
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(93, 235)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(51, 13)
        Me.Label42.TabIndex = 93
        Me.Label42.Text = "FAMILIA:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(560, 25)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(63, 13)
        Me.Label39.TabIndex = 84
        Me.Label39.Text = "ID GRUPO:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(75, 406)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(69, 13)
        Me.Label30.TabIndex = 72
        Me.Label30.Text = "P. COMPRA:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(97, 262)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(47, 13)
        Me.Label29.TabIndex = 70
        Me.Label29.Text = "COLOR:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(316, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "REFERENCIA:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "REF. PROVEEDOR:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(384, 432)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "PVP:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(76, 432)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "MARGEN %:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 323)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "INFLUYE TOLDO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "MEDIDA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "DESCRIPCION:"
        '
        'frArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 606)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ARTICULOS"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.pnLotes.ResumeLayout(False)
        Me.pnLotes.PerformLayout()
        CType(Me.dgLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsBotones.ResumeLayout(False)
        Me.tsBotones.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.pnModelo.ResumeLayout(False)
        Me.grModelo.ResumeLayout(False)
        CType(Me.dgMods, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnTejidos.ResumeLayout(False)
        Me.grTejidos.ResumeLayout(False)
        CType(Me.dgTejidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgArticulos As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tsBotones As ToolStrip
    Friend WithEvents cmdNuevo As ToolStripButton
    Friend WithEvents cmdGuardar As ToolStripButton
    Friend WithEvents cmdCancelar As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripSeparator
    Friend WithEvents cmdLonas As ToolStripButton
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbTejido As ComboBox
    Friend WithEvents txTejido As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txInicial As TextBox
    Friend WithEvents txMinimo As TextBox
    Friend WithEvents txStock As TextBox
    Friend WithEvents txMargenEuro As TextBox
    Friend WithEvents txDto As TextBox
    Friend WithEvents txIva As TextBox
    Friend WithEvents txGrupo As TextBox
    Friend WithEvents txCompra As TextBox
    Friend WithEvents txCodigo As TextBox
    Friend WithEvents txDescripcion As TextBox
    Friend WithEvents txPrecio As TextBox
    Friend WithEvents txMargenPor As TextBox
    Friend WithEvents txRefProv As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cbUnidad As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbInfluye As ComboBox
    Friend WithEvents Label42 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ckControlStock As CheckBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdLotes As ToolStripButton
    Friend WithEvents cbTipoArti As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdFlechas As ToolStripButton
    Friend WithEvents Label23 As Label
    Friend WithEvents txUbicacion As TextBox
    Friend WithEvents txNumPro As TextBox
    Friend WithEvents txProveedor As TextBox
    Friend WithEvents txModeloID As TextBox
    Friend WithEvents txModelo As TextBox
    Friend WithEvents cbFamilias As ComboBox
    Friend WithEvents btModelo As Button
    Friend WithEvents btProveedor As Button
    Friend WithEvents grModelo As GroupBox
    Friend WithEvents btCloseMod As Button
    Friend WithEvents dgMods As DataGridView
    Friend WithEvents txTejidoID As TextBox
    Friend WithEvents btTejidos As Button
    Friend WithEvents grTejidos As GroupBox
    Friend WithEvents dgTejidos As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents pnTejidos As Panel
    Friend WithEvents pnModelo As Panel
    Friend WithEvents pnLotes As Panel
    Friend WithEvents dgLotes As DataGridView
    Friend WithEvents btCloseLotes As Button
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents lote As DataGridViewTextBoxColumn
    Friend WithEvents stock As DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents btEliminarLinea As Button
    Friend WithEvents btNuevaLinea As Button
    Friend WithEvents txCodigo1 As TextBox
    Friend WithEvents txArticulo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cbMedidas As ComboBox
    Friend WithEvents cbColores As ComboBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmdDuplicar As ToolStripButton
    Friend WithEvents Label21 As Label
    Friend WithEvents txUbicLote As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txStockLote As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txLoteLote As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txDescLote As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txRefLote As TextBox
    Friend WithEvents btGrabarLote As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents txFiltroLotes As TextBox
    Friend WithEvents txBakLote As TextBox
    Friend WithEvents txCorte As TextBox
End Class
