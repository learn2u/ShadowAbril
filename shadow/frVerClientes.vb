Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frVerClientes
    Private Sub frVerClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT nombre, agenteID, descuento, clienteID, recargo FROM clientes", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        dgClientes.DataSource = bind
        dgClientes.AutoGenerateColumns = False
        dgClientes.Columns(0).HeaderText = "NOMBRE"
        dgClientes.Columns(0).Name = "cliente"
        dgClientes.Columns(1).HeaderText = "AGENTE"
        dgClientes.Columns(1).Name = "agent"
        dgClientes.Columns(1).Visible = False
        dgClientes.Columns(2).HeaderText = "DESCUENTO"
        dgClientes.Columns(2).Name = "dto"
        dgClientes.Columns(2).Visible = False
        dgClientes.Columns(3).HeaderText = "CODIGO"
        dgClientes.Columns(3).Name = "cod"
        dgClientes.Columns(3).Visible = False
        dgClientes.Columns(4).HeaderText = "REC"
        dgClientes.Columns(4).Name = "recargo"
        dgClientes.Columns(4).Visible = False
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()

    End Sub

    Private Sub txCliente_TextChanged(sender As Object, e As EventArgs) Handles txCliente.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT nombre, agenteID, descuento, clienteID, recargo FROM clientes WHERE nombre LIKE'" & txCliente.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgClientes.DataSource = bind
        dgClientes.AutoGenerateColumns = False
        dgClientes.Columns(0).HeaderText = "NOMBRE"
        dgClientes.Columns(0).Name = "cliente"
        dgClientes.Columns(1).HeaderText = "AGENTE"
        dgClientes.Columns(1).Name = "agent"
        dgClientes.Columns(1).Visible = False
        dgClientes.Columns(2).HeaderText = "DESCUENTO"
        dgClientes.Columns(2).Name = "dto"
        dgClientes.Columns(2).Visible = False
        dgClientes.Columns(3).HeaderText = "CODIGO"
        dgClientes.Columns(3).Name = "cod"
        dgClientes.Columns(3).Visible = False
        dgClientes.Columns(4).HeaderText = "REC"
        dgClientes.Columns(4).Name = "recargo"
        dgClientes.Columns(4).Visible = False
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()

    End Sub

    Public Sub mostrarEmergente(vCodcli As String)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim cmdCli As New MySqlCommand
        Dim rdrCli As MySqlDataReader
        cmdCli = New MySqlCommand("SELECT clienteID, mensaje FROM clientes WHERE clienteID = '" + vCodcli + "'", conexionmy)

        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        rdrCli = cmdCli.ExecuteReader
        rdrCli.Read()

        If rdrCli("mensaje") = "" Then
            'Si el mensaje esta en blanco
        Else
            MsgBox(rdrCli("mensaje"))
        End If



        rdrCli.Close()

        conexionmy.Close()
    End Sub
    Public Sub cargoEnvios()
        If formCli = "P" Then
            newMdiPresupuesto.cbEnvio.ResetText()

            Dim cn As MySqlConnection
            Dim cm As MySqlCommand

            Dim da As MySqlDataAdapter
            Dim ds As DataSet
            cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

            cn.Open()
            cm = New MySqlCommand("SELECT envioID, clienteID, localidad, provincia, concat_ws(' - ',cpostal, domicilio) AS direccion FROM envios WHERE clienteID = '" & newMdiPresupuesto.txNumcli.Text & "'", cn)


            cm.CommandType = CommandType.Text
            cm.Connection = cn

            da = New MySqlDataAdapter(cm)
            ds = New DataSet()
            da.Fill(ds)


            newMdiPresupuesto.cbEnvio.DataSource = ds.Tables(0)
            newMdiPresupuesto.cbEnvio.DisplayMember = ds.Tables(0).Columns("direccion").ToString
            newMdiPresupuesto.cbEnvio.ValueMember = "envioID"

            cn.Close()
        End If
        If formCli = "A" Then
            newMdiAlbaran.cbEnvio.ResetText()

            Dim cn As MySqlConnection
            Dim cm As MySqlCommand

            Dim da As MySqlDataAdapter
            Dim ds As DataSet
            cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

            cn.Open()
            cm = New MySqlCommand("SELECT envioID, clienteID, localidad, provincia, concat_ws(' - ',cpostal, domicilio) AS direccion FROM envios WHERE clienteID = '" & newMdiAlbaran.txNumcli.Text & "'", cn)


            cm.CommandType = CommandType.Text
            cm.Connection = cn

            da = New MySqlDataAdapter(cm)
            ds = New DataSet()
            da.Fill(ds)


            newMdiAlbaran.cbEnvio.DataSource = ds.Tables(0)
            newMdiAlbaran.cbEnvio.DisplayMember = ds.Tables(0).Columns("direccion").ToString
            newMdiAlbaran.cbEnvio.ValueMember = "envioID"

            cn.Close()
        End If
        If formCli = "D" Then
            newMdiPedido.cbEnvio.ResetText()

            Dim cn As MySqlConnection
            Dim cm As MySqlCommand

            Dim da As MySqlDataAdapter
            Dim ds As DataSet
            cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

            cn.Open()
            cm = New MySqlCommand("SELECT envioID, clienteID, localidad, provincia, concat_ws(' - ',cpostal, domicilio) AS direccion FROM envios WHERE clienteID = '" & newMdiPedido.txNumcli.Text & "'", cn)


            cm.CommandType = CommandType.Text
            cm.Connection = cn

            da = New MySqlDataAdapter(cm)
            ds = New DataSet()
            da.Fill(ds)


            newMdiPedido.cbEnvio.DataSource = ds.Tables(0)
            newMdiPedido.cbEnvio.DisplayMember = ds.Tables(0).Columns("direccion").ToString
            newMdiPedido.cbEnvio.ValueMember = "envioID"

            cn.Close()
        End If

        If formCli = "F" Then
            newMdiFacturaManual.cbEnvio.ResetText()

            Dim cn As MySqlConnection
            Dim cm As MySqlCommand

            Dim da As MySqlDataAdapter
            Dim ds As DataSet
            cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

            cn.Open()
            cm = New MySqlCommand("SELECT envioID, clienteID, localidad, provincia, concat_ws(' - ',cpostal, domicilio) AS direccion FROM envios WHERE clienteID = '" & newMdiFacturaManual.txNumcli.Text & "'", cn)


            cm.CommandType = CommandType.Text
            cm.Connection = cn

            da = New MySqlDataAdapter(cm)
            ds = New DataSet()
            da.Fill(ds)


            newMdiFacturaManual.cbEnvio.DataSource = ds.Tables(0)
            newMdiFacturaManual.cbEnvio.DisplayMember = ds.Tables(0).Columns("direccion").ToString
            newMdiFacturaManual.cbEnvio.ValueMember = "envioID"

            cn.Close()
        End If

    End Sub
    Public Sub cargoFormapagoCliente()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM clientes WHERE clienteID = '" + newMdiFacturaManual.txNumcli.Text + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        newMdiFacturaManual.txDiapago.Text = rdr("diapago")
        cargoFormaPago()

        Dim vForma As Integer = 0
        vForma = rdr("formapago")
        Select Case vForma
            Case 1
                newMdiFacturaManual.cbFormapago.SelectedIndex = 0
            Case 2
                newMdiFacturaManual.cbFormapago.SelectedIndex = 1
            Case 3
                newMdiFacturaManual.cbFormapago.SelectedIndex = 2
            Case 4
                newMdiFacturaManual.cbFormapago.SelectedIndex = 3
            Case 5
                newMdiFacturaManual.cbFormapago.SelectedIndex = 4
            Case 6
                newMdiFacturaManual.cbFormapago.SelectedIndex = 5
            Case 7
                newMdiFacturaManual.cbFormapago.SelectedIndex = 6
            Case 8
                newMdiFacturaManual.cbFormapago.SelectedIndex = 7
            Case 9
                newMdiFacturaManual.cbFormapago.SelectedIndex = 8
        End Select
    End Sub
    Public Sub cargoFormaPago()
        newMdiFacturaManual.cbFormapago.ResetText()

        Dim cn As MySqlConnection
        Dim cm As MySqlCommand

        Dim da As MySqlDataAdapter
        Dim ds As DataSet
        cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        cn.Open()
        cm = New MySqlCommand("SELECT formaID, formapago FROM formapago", cn)


        cm.CommandType = CommandType.Text
        cm.Connection = cn

        da = New MySqlDataAdapter(cm)
        ds = New DataSet()
        da.Fill(ds)


        newMdiFacturaManual.cbFormapago.DataSource = ds.Tables(0)
        newMdiFacturaManual.cbFormapago.DisplayMember = ds.Tables(0).Columns("formapago").ToString
        newMdiFacturaManual.cbFormapago.ValueMember = "formaID"

        cn.Close()
    End Sub

    Private Sub dgClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClientes.CellDoubleClick
        mostrarEmergente(dgClientes.CurrentRow.Cells("cod").Value)
        If formCli = "P" Then
            newMdiPresupuesto.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
            newMdiPresupuesto.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
            newMdiPresupuesto.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
            newMdiPresupuesto.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
            newMdiPresupuesto.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
            Me.Close()
            newMdiPresupuesto.recalcularDescuentos()
            cargoEnvios()
        End If
        If formCli = "A" Then

            newMdiAlbaran.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
            newMdiAlbaran.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
            newMdiAlbaran.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
            newMdiAlbaran.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
            newMdiAlbaran.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value

            Me.Close()
            newMdiAlbaran.recalcularDescuentos()
            cargoEnvios()
        End If

        If formCli = "D" Then
            newMdiPedido.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
            newMdiPedido.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
            newMdiPedido.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
            newMdiPedido.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
            newMdiPedido.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
            Me.Close()
            newMdiPedido.recalcularDescuentos()
            cargoEnvios()
        End If

        If formCli = "F" Then
            newMdiFacturaManual.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
            newMdiFacturaManual.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
            newMdiFacturaManual.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
            newMdiFacturaManual.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
            newMdiFacturaManual.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
            Me.Close()
            newMdiFacturaManual.recalcularDescuentos()
            cargoEnvios()
            cargoFormapagoCliente()
        End If

    End Sub

    Private Sub txCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txCliente.KeyDown
        Dim address As Point = Me.dgClientes.CurrentCellAddress
        If e.KeyCode = Keys.Down Then
            If address.Y < Me.dgClientes.RowCount - 1 Then
                address.Y += 1
            End If

            Me.dgClientes.CurrentCell = Me.dgClientes(address.X, address.Y)
        End If
        If e.KeyCode = Keys.Up Then
            If address.Y <> 0 Then
                address.Y -= 1
            End If

            Me.dgClientes.CurrentCell = Me.dgClientes(address.X, address.Y)
        End If

        If e.KeyCode = Keys.Enter Then
            mostrarEmergente(dgClientes.CurrentRow.Cells("cod").Value)
            If formCli = "P" Then
                newMdiPresupuesto.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
                newMdiPresupuesto.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
                newMdiPresupuesto.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
                newMdiPresupuesto.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
                newMdiPresupuesto.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
                Me.Close()
                newMdiPresupuesto.recalcularDescuentos()
                cargoEnvios()
            End If
            If formCli = "A" Then
                newMdiAlbaran.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
                newMdiAlbaran.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
                newMdiAlbaran.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
                newMdiAlbaran.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
                newMdiAlbaran.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
                Me.Close()
                newMdiAlbaran.recalcularDescuentos()
                cargoEnvios()
            End If

            If formCli = "D" Then
                newMdiPedido.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
                newMdiPedido.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
                newMdiPedido.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
                newMdiPedido.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
                newMdiPedido.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
                Me.Close()
                newMdiPedido.recalcularDescuentos()
                cargoEnvios()
            End If

            If formCli = "F" Then
                newMdiFacturaManual.txNumcli.Text = dgClientes.CurrentRow.Cells("cod").Value
                newMdiFacturaManual.txClientepres.Text = dgClientes.CurrentRow.Cells("cliente").Value
                newMdiFacturaManual.txAgente.Text = dgClientes.CurrentRow.Cells("agent").Value
                newMdiFacturaManual.txDtocli.Text = dgClientes.CurrentRow.Cells("dto").Value
                newMdiFacturaManual.txRecargo.Text = dgClientes.CurrentRow.Cells("recargo").Value
                Me.Close()
                newMdiFacturaManual.recalcularDescuentos()
                cargoEnvios()
                cargoFormapagoCliente()
            End If
        End If
    End Sub
End Class