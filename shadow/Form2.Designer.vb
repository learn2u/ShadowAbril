<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btBuscar = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txGeneral = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txNumero = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txReferencia = New System.Windows.Forms.TextBox()
        Me.txHasta = New System.Windows.Forms.MaskedTextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txCliente = New System.Windows.Forms.TextBox()
        Me.txDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbFactura = New System.Windows.Forms.RadioButton()
        Me.rbAceptados = New System.Windows.Forms.RadioButton()
        Me.rbPendientes = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.dgPedidos = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.06075!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.93925!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgPedidos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1251, 560)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox5)
        Me.Panel4.Controls.Add(Me.GroupBox4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(294, 554)
        Me.Panel4.TabIndex = 13
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btBuscar)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.txGeneral)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.txNumero)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.txReferencia)
        Me.GroupBox5.Controls.Add(Me.txHasta)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.txCliente)
        Me.GroupBox5.Controls.Add(Me.txDesde)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 179)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(280, 316)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "BUSQUEDA"
        '
        'btBuscar
        '
        Me.btBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btBuscar.FlatAppearance.BorderSize = 0
        Me.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btBuscar.Image = CType(resources.GetObject("btBuscar.Image"), System.Drawing.Image)
        Me.btBuscar.Location = New System.Drawing.Point(241, 280)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(33, 30)
        Me.btBuscar.TabIndex = 21
        Me.btBuscar.UseVisualStyleBackColor = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(7, 221)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(124, 13)
        Me.Label40.TabIndex = 20
        Me.Label40.Text = "BUSQUEDA GENERAL:"
        '
        'txGeneral
        '
        Me.txGeneral.Location = New System.Drawing.Point(10, 237)
        Me.txGeneral.Name = "txGeneral"
        Me.txGeneral.Size = New System.Drawing.Size(265, 20)
        Me.txGeneral.TabIndex = 19
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(7, 74)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(58, 13)
        Me.Label39.TabIndex = 18
        Me.Label39.Text = "NUMERO:"
        '
        'txNumero
        '
        Me.txNumero.Location = New System.Drawing.Point(10, 90)
        Me.txNumero.Name = "txNumero"
        Me.txNumero.Size = New System.Drawing.Size(265, 20)
        Me.txNumero.TabIndex = 17
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(7, 125)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(78, 13)
        Me.Label38.TabIndex = 16
        Me.Label38.Text = "REFERENCIA:"
        '
        'txReferencia
        '
        Me.txReferencia.Location = New System.Drawing.Point(10, 141)
        Me.txReferencia.Name = "txReferencia"
        Me.txReferencia.Size = New System.Drawing.Size(265, 20)
        Me.txReferencia.TabIndex = 15
        '
        'txHasta
        '
        Me.txHasta.BackColor = System.Drawing.Color.White
        Me.txHasta.Location = New System.Drawing.Point(185, 185)
        Me.txHasta.Mask = "00/00/0000"
        Me.txHasta.Name = "txHasta"
        Me.txHasta.Size = New System.Drawing.Size(72, 20)
        Me.txHasta.TabIndex = 11
        Me.txHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txHasta.ValidatingType = GetType(Date)
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(133, 192)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(46, 13)
        Me.Label37.TabIndex = 13
        Me.Label37.Text = "HASTA:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 25)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(55, 13)
        Me.Label36.TabIndex = 12
        Me.Label36.Text = "CLIENTE:"
        '
        'txCliente
        '
        Me.txCliente.Location = New System.Drawing.Point(9, 41)
        Me.txCliente.Name = "txCliente"
        Me.txCliente.Size = New System.Drawing.Size(265, 20)
        Me.txCliente.TabIndex = 11
        '
        'txDesde
        '
        Me.txDesde.BackColor = System.Drawing.Color.White
        Me.txDesde.Location = New System.Drawing.Point(58, 185)
        Me.txDesde.Mask = "00/00/0000"
        Me.txDesde.Name = "txDesde"
        Me.txDesde.Size = New System.Drawing.Size(72, 20)
        Me.txDesde.TabIndex = 10
        Me.txDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txDesde.ValidatingType = GetType(Date)
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(7, 192)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(47, 13)
        Me.Label35.TabIndex = 9
        Me.Label35.Text = "DESDE:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbFactura)
        Me.GroupBox4.Controls.Add(Me.rbAceptados)
        Me.GroupBox4.Controls.Add(Me.rbPendientes)
        Me.GroupBox4.Controls.Add(Me.rbTodos)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox4.Location = New System.Drawing.Point(3, 17)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(280, 139)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ESTADO"
        '
        'rbFactura
        '
        Me.rbFactura.AutoSize = True
        Me.rbFactura.Location = New System.Drawing.Point(6, 97)
        Me.rbFactura.Name = "rbFactura"
        Me.rbFactura.Size = New System.Drawing.Size(85, 17)
        Me.rbFactura.TabIndex = 3
        Me.rbFactura.Text = "A FACTURA"
        Me.rbFactura.UseVisualStyleBackColor = True
        '
        'rbAceptados
        '
        Me.rbAceptados.AutoSize = True
        Me.rbAceptados.Location = New System.Drawing.Point(6, 74)
        Me.rbAceptados.Name = "rbAceptados"
        Me.rbAceptados.Size = New System.Drawing.Size(85, 17)
        Me.rbAceptados.TabIndex = 2
        Me.rbAceptados.Text = "A ALBARAN"
        Me.rbAceptados.UseVisualStyleBackColor = True
        '
        'rbPendientes
        '
        Me.rbPendientes.AutoSize = True
        Me.rbPendientes.Location = New System.Drawing.Point(6, 51)
        Me.rbPendientes.Name = "rbPendientes"
        Me.rbPendientes.Size = New System.Drawing.Size(94, 17)
        Me.rbPendientes.TabIndex = 1
        Me.rbPendientes.Text = "PENDIENTES"
        Me.rbPendientes.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(6, 28)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(63, 17)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.Text = "TODOS"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'dgPedidos
        '
        Me.dgPedidos.AllowUserToAddRows = False
        Me.dgPedidos.BackgroundColor = System.Drawing.Color.White
        Me.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPedidos.Location = New System.Drawing.Point(303, 3)
        Me.dgPedidos.Name = "dgPedidos"
        Me.dgPedidos.Size = New System.Drawing.Size(945, 554)
        Me.dgPedidos.TabIndex = 14
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1256, 564)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btBuscar As Button
    Friend WithEvents Label40 As Label
    Friend WithEvents txGeneral As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents txNumero As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txReferencia As TextBox
    Friend WithEvents txHasta As MaskedTextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents txCliente As TextBox
    Friend WithEvents txDesde As MaskedTextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbFactura As RadioButton
    Friend WithEvents rbAceptados As RadioButton
    Friend WithEvents rbPendientes As RadioButton
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents dgPedidos As DataGridView
End Class
