<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class launcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(launcher))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónEmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónMySQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PresupuestosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlbaranesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaciónManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturarAlbaranesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COMPRASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidosAProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ALMACENToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADMINISTRACIÓNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GastosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txCancelar = New System.Windows.Forms.Button()
        Me.btConectar = New System.Windows.Forms.Button()
        Me.txIp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txContra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txUser = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmpresaToolStripMenuItem, Me.VENTASToolStripMenuItem, Me.COMPRASToolStripMenuItem, Me.ALMACENToolStripMenuItem, Me.ADMINISTRACIÓNToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(907, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EmpresaToolStripMenuItem
        '
        Me.EmpresaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónEmpresaToolStripMenuItem, Me.ConfiguraciónMySQLToolStripMenuItem, Me.LoginUsuariosToolStripMenuItem})
        Me.EmpresaToolStripMenuItem.Name = "EmpresaToolStripMenuItem"
        Me.EmpresaToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.EmpresaToolStripMenuItem.Text = "EMPRESA"
        '
        'ConfiguraciónEmpresaToolStripMenuItem
        '
        Me.ConfiguraciónEmpresaToolStripMenuItem.Name = "ConfiguraciónEmpresaToolStripMenuItem"
        Me.ConfiguraciónEmpresaToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConfiguraciónEmpresaToolStripMenuItem.Text = "Configuración empresa"
        '
        'ConfiguraciónMySQLToolStripMenuItem
        '
        Me.ConfiguraciónMySQLToolStripMenuItem.Name = "ConfiguraciónMySQLToolStripMenuItem"
        Me.ConfiguraciónMySQLToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConfiguraciónMySQLToolStripMenuItem.Text = "Configuración MySQL"
        '
        'LoginUsuariosToolStripMenuItem
        '
        Me.LoginUsuariosToolStripMenuItem.Name = "LoginUsuariosToolStripMenuItem"
        Me.LoginUsuariosToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.LoginUsuariosToolStripMenuItem.Text = "Login Usuarios"
        '
        'VENTASToolStripMenuItem
        '
        Me.VENTASToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PresupuestosToolStripMenuItem, Me.PedidosToolStripMenuItem, Me.AlbaranesToolStripMenuItem, Me.FacturaciónManualToolStripMenuItem, Me.FacturarAlbaranesToolStripMenuItem, Me.ClientesToolStripMenuItem})
        Me.VENTASToolStripMenuItem.Name = "VENTASToolStripMenuItem"
        Me.VENTASToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.VENTASToolStripMenuItem.Text = "VENTAS"
        '
        'PresupuestosToolStripMenuItem
        '
        Me.PresupuestosToolStripMenuItem.Name = "PresupuestosToolStripMenuItem"
        Me.PresupuestosToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PresupuestosToolStripMenuItem.Text = "Presupuestos"
        '
        'PedidosToolStripMenuItem
        '
        Me.PedidosToolStripMenuItem.Name = "PedidosToolStripMenuItem"
        Me.PedidosToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PedidosToolStripMenuItem.Text = "Pedidos"
        '
        'AlbaranesToolStripMenuItem
        '
        Me.AlbaranesToolStripMenuItem.Name = "AlbaranesToolStripMenuItem"
        Me.AlbaranesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AlbaranesToolStripMenuItem.Text = "Albaranes"
        '
        'FacturaciónManualToolStripMenuItem
        '
        Me.FacturaciónManualToolStripMenuItem.Name = "FacturaciónManualToolStripMenuItem"
        Me.FacturaciónManualToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.FacturaciónManualToolStripMenuItem.Text = "Facturación manual"
        '
        'FacturarAlbaranesToolStripMenuItem
        '
        Me.FacturarAlbaranesToolStripMenuItem.Name = "FacturarAlbaranesToolStripMenuItem"
        Me.FacturarAlbaranesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.FacturarAlbaranesToolStripMenuItem.Text = "Facturar Albaranes"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'COMPRASToolStripMenuItem
        '
        Me.COMPRASToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PedidosAProveedoresToolStripMenuItem, Me.ProveedoresToolStripMenuItem})
        Me.COMPRASToolStripMenuItem.Name = "COMPRASToolStripMenuItem"
        Me.COMPRASToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.COMPRASToolStripMenuItem.Text = "COMPRAS"
        '
        'PedidosAProveedoresToolStripMenuItem
        '
        Me.PedidosAProveedoresToolStripMenuItem.Name = "PedidosAProveedoresToolStripMenuItem"
        Me.PedidosAProveedoresToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.PedidosAProveedoresToolStripMenuItem.Text = "Pedidos / Entradas a proveedores"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'ALMACENToolStripMenuItem
        '
        Me.ALMACENToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArtículosToolStripMenuItem})
        Me.ALMACENToolStripMenuItem.Name = "ALMACENToolStripMenuItem"
        Me.ALMACENToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.ALMACENToolStripMenuItem.Text = "ALMACÉN"
        '
        'ArtículosToolStripMenuItem
        '
        Me.ArtículosToolStripMenuItem.Name = "ArtículosToolStripMenuItem"
        Me.ArtículosToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.ArtículosToolStripMenuItem.Text = "Artículos"
        '
        'ADMINISTRACIÓNToolStripMenuItem
        '
        Me.ADMINISTRACIÓNToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GastosToolStripMenuItem})
        Me.ADMINISTRACIÓNToolStripMenuItem.Name = "ADMINISTRACIÓNToolStripMenuItem"
        Me.ADMINISTRACIÓNToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.ADMINISTRACIÓNToolStripMenuItem.Text = "ADMINISTRACIÓN"
        '
        'GastosToolStripMenuItem
        '
        Me.GastosToolStripMenuItem.Name = "GastosToolStripMenuItem"
        Me.GastosToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.GastosToolStripMenuItem.Text = "Gastos"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txCancelar)
        Me.Panel1.Controls.Add(Me.btConectar)
        Me.Panel1.Controls.Add(Me.txIp)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txContra)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txUser)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 271)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(907, 247)
        Me.Panel1.TabIndex = 14
        '
        'txCancelar
        '
        Me.txCancelar.Location = New System.Drawing.Point(537, 189)
        Me.txCancelar.Name = "txCancelar"
        Me.txCancelar.Size = New System.Drawing.Size(75, 23)
        Me.txCancelar.TabIndex = 4
        Me.txCancelar.Text = "Cancelar"
        Me.txCancelar.UseVisualStyleBackColor = True
        '
        'btConectar
        '
        Me.btConectar.Location = New System.Drawing.Point(435, 189)
        Me.btConectar.Name = "btConectar"
        Me.btConectar.Size = New System.Drawing.Size(75, 23)
        Me.btConectar.TabIndex = 3
        Me.btConectar.Text = "Conectar"
        Me.btConectar.UseVisualStyleBackColor = True
        '
        'txIp
        '
        Me.txIp.BackColor = System.Drawing.Color.White
        Me.txIp.Location = New System.Drawing.Point(403, 111)
        Me.txIp.Name = "txIp"
        Me.txIp.Size = New System.Drawing.Size(209, 20)
        Me.txIp.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(299, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "IP CONEXION:"
        '
        'txContra
        '
        Me.txContra.BackColor = System.Drawing.Color.White
        Me.txContra.Location = New System.Drawing.Point(403, 72)
        Me.txContra.Name = "txContra"
        Me.txContra.Size = New System.Drawing.Size(209, 20)
        Me.txContra.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(294, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "CONTRASEÑA:"
        '
        'txUser
        '
        Me.txUser.BackColor = System.Drawing.Color.White
        Me.txUser.Location = New System.Drawing.Point(403, 34)
        Me.txUser.Name = "txUser"
        Me.txUser.Size = New System.Drawing.Size(209, 20)
        Me.txUser.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(319, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "USUARIO:"
        '
        'launcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(907, 518)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "launcher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shadow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguraciónEmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguraciónMySQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VENTASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PresupuestosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlbaranesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturaciónManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturarAlbaranesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents COMPRASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PedidosAProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ALMACENToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ADMINISTRACIÓNToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GastosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoginUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txCancelar As Button
    Friend WithEvents btConectar As Button
    Friend WithEvents txIp As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txContra As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txUser As TextBox
    Friend WithEvents Label1 As Label
End Class
