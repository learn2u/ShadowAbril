Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class launcher
    Private Sub launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim documento As XmlDocument
        Dim nodelist As XmlNodeList
        Dim nodo As XmlNode
        documento = New XmlDocument
        documento.Load("conexion.xml")
        nodelist = documento.SelectNodes("conexion")
        For Each nodo In nodelist
            vServidor = nodo.ChildNodes(0).InnerText
            vUsuario = nodo.ChildNodes(1).InnerText
            vPassword = nodo.ChildNodes(2).InnerText
            vBasedatos = nodo.ChildNodes(3).InnerText
        Next
        formArti = "N"
        formCli = "N"

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT recargo FROM configuracion", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        vRecargo = rdr("recargo")

        conexionmy.Close()

    End Sub

    Private Sub ConfiguraciónEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónEmpresaToolStripMenuItem.Click
        muestroEmpresa()
    End Sub

    Private Sub ConfiguraciónMySQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónMySQLToolStripMenuItem.Click
        muestroConfiguracion()
    End Sub

    Private Sub PresupuestosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PresupuestosToolStripMenuItem.Click
        muestroPresupuestos()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        muestroPedidos()
    End Sub

    Private Sub AlbaranesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlbaranesToolStripMenuItem.Click
        muestroAlbaranes()
    End Sub

    Private Sub FacturaciónManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónManualToolStripMenuItem.Click
        muestroFacturaManual()
    End Sub

    Private Sub FacturarAlbaranesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturarAlbaranesToolStripMenuItem.Click
        muestroFacturaAlbaranes()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        muestroClientes()
    End Sub

    Private Sub PedidosAProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosAProveedoresToolStripMenuItem.Click
        muestroPedidoProv()
    End Sub

    Private Sub EntradasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        muestroProveedor()
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem.Click
        muestroArticulos()
    End Sub

    Private Sub GastosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GastosToolStripMenuItem.Click
        muestroGastos()
    End Sub
    Public Sub muestroPresupuestos()
        If newMdiPresupuesto Is Nothing Then
            newMdiPresupuesto.MdiParent = Me
            newMdiPresupuesto.Dock = DockStyle.Fill
            newMdiPresupuesto.Show()
        Else
            newMdiPresupuesto = New frPresupuestos
            newMdiPresupuesto.MdiParent = Me
            newMdiPresupuesto.Dock = DockStyle.Fill
            newMdiPresupuesto.Show()
        End If

    End Sub
    Public Sub muestroAlbaranes()
        If newMdiAlbaran Is Nothing Then
            newMdiAlbaran.MdiParent = Me
            newMdiAlbaran.Dock = DockStyle.Fill
            newMdiAlbaran.Show()
        Else
            newMdiAlbaran = New frAlbaran
            newMdiAlbaran.MdiParent = Me
            newMdiAlbaran.Dock = DockStyle.Fill
            newMdiAlbaran.Show()
        End If
    End Sub
    Public Sub muestroPedidos()
        If newMdiPedido Is Nothing Then
            newMdiPedido.MdiParent = Me
            newMdiPedido.Dock = DockStyle.Fill
            newMdiPedido.Show()
        Else
            newMdiPedido = New frPedido
            newMdiPedido.MdiParent = Me
            newMdiPedido.Dock = DockStyle.Fill
            newMdiPedido.Show()
        End If
    End Sub
    Public Sub muestroEmpresa()
        If newMdiEmpresa Is Nothing Then
            newMdiEmpresa.MdiParent = Me
            newMdiEmpresa.Dock = DockStyle.Fill
            newMdiEmpresa.Show()
        Else
            newMdiEmpresa = New frEmpresa
            newMdiEmpresa.MdiParent = Me
            newMdiEmpresa.Dock = DockStyle.Fill
            newMdiEmpresa.Show()
        End If
    End Sub
    Public Sub muestroConfiguracion()
        If newMdiConfiguracion Is Nothing Then
            newMdiConfiguracion.MdiParent = Me
            newMdiConfiguracion.Dock = DockStyle.Fill
            newMdiConfiguracion.Show()
        Else
            newMdiConfiguracion = New frConfiguracion
            newMdiConfiguracion.MdiParent = Me
            newMdiConfiguracion.Dock = DockStyle.Fill
            newMdiConfiguracion.Show()
        End If
    End Sub
    Public Sub muestroFacturaManual()
        If newMdiFacturaManual Is Nothing Then
            newMdiFacturaManual.MdiParent = Me
            newMdiFacturaManual.Dock = DockStyle.Fill
            newMdiFacturaManual.Show()
        Else
            newMdiFacturaManual = New frFacturaManual
            newMdiFacturaManual.MdiParent = Me
            newMdiFacturaManual.Dock = DockStyle.Fill
            newMdiFacturaManual.Show()
        End If
    End Sub
    Public Sub muestroFacturaAlbaranes()
        If newMdiFacturaAlbaran Is Nothing Then
            newMdiFacturaAlbaran.MdiParent = Me
            newMdiFacturaAlbaran.Dock = DockStyle.Fill
            newMdiFacturaAlbaran.Show()
        Else
            newMdiFacturaAlbaran = New frFacturaAlbaran
            newMdiFacturaAlbaran.MdiParent = Me
            newMdiFacturaAlbaran.Dock = DockStyle.Fill
            newMdiFacturaAlbaran.Show()
        End If
    End Sub
    Public Sub muestroClientes()
        If newMdiCliente Is Nothing Then
            newMdiCliente.MdiParent = Me
            newMdiCliente.Dock = DockStyle.Fill
            newMdiCliente.Show()
        Else
            newMdiCliente = New frCliente
            newMdiCliente.MdiParent = Me
            newMdiCliente.Dock = DockStyle.Fill
            newMdiCliente.Show()
        End If
    End Sub
    Public Sub muestroPedidoProv()
        If newMdiPedidoProv Is Nothing Then
            newMdiPedidoProv.MdiParent = Me
            newMdiPedidoProv.Dock = DockStyle.Fill
            newMdiPedidoProv.Show()
        Else
            newMdiPedidoProv = New frPedidoProv
            newMdiPedidoProv.MdiParent = Me
            newMdiPedidoProv.Dock = DockStyle.Fill
            newMdiPedidoProv.Show()
        End If
    End Sub
    Public Sub muestroProveedor()
        If newMdiProveedor Is Nothing Then
            newMdiProveedor.MdiParent = Me
            newMdiProveedor.Dock = DockStyle.Fill
            newMdiProveedor.Show()
        Else
            newMdiProveedor = New frProveedor
            newMdiProveedor.MdiParent = Me
            newMdiProveedor.Dock = DockStyle.Fill
            newMdiProveedor.Show()
        End If
    End Sub
    Public Sub muestroArticulos()
        If newMdiArticulos Is Nothing Then
            newMdiArticulos.MdiParent = Me
            newMdiArticulos.Dock = DockStyle.Fill
            newMdiArticulos.Show()
        Else
            newMdiArticulos = New frArticulos
            newMdiArticulos.MdiParent = Me
            newMdiArticulos.Dock = DockStyle.Fill
            newMdiArticulos.Show()
        End If
    End Sub
    Public Sub muestroGastos()
        If newMdiGasto Is Nothing Then
            newMdiGasto.MdiParent = Me
            newMdiGasto.Dock = DockStyle.Fill
            newMdiGasto.Show()
        Else
            newMdiGasto = New frGastos
            newMdiGasto.MdiParent = Me
            newMdiGasto.Dock = DockStyle.Fill
            newMdiGasto.Show()
        End If
    End Sub
End Class