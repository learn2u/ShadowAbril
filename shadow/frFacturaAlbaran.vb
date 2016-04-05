Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frFacturaAlbaran
    Public Shared linea As Int16
    Private Sub frFacturaAlbaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgClientes.Visible = False
        cargoClientesMy()
        txFechaFra.Text = Format(Today, "ddMMyyyy")
    End Sub
    Public Sub cargoClientesMy()

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT clienteID, nombre, descuento FROM clientes", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        dgClientes.DataSource = bind
        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(1).HeaderText = "NOMBRE CLIENTE"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(2).HeaderText = "DTO"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub txClientes_TextChanged(sender As Object, e As EventArgs)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT clienteID, nombre, descuento FROM clientes WHERE nombre LIKE'" & txCliente.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgClientes.DataSource = bind
        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(1).HeaderText = "NOMBRE CLIENTE"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(2).HeaderText = "DTO"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgClientes.Visible = True


        conexionmy.Close()

    End Sub

    Private Sub btCargoClientes_Click(sender As Object, e As EventArgs) Handles btCargoClientes.Click
        cargoClientesMy()
        dgClientes.Visible = True

    End Sub

    Private Sub dgClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClientes.CellClick

        txCliente.Text = dgClientes.CurrentRow.Cells("Column2").Value
        txCodcli.Text = dgClientes.CurrentRow.Cells("Column1").Value.ToString

        dgClientes.Visible = False

        cargoAlbaranes()

    End Sub
    Public Sub cargoAlbaranes()

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.facturado, 
                                                    albaran_cab.clienteID, 
                                                    clientes.clienteID 
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID 
                                            WHERE albaran_cab.clienteID ='" & txCodcli.Text & "' 
                                                AND albaran_cab.facturado ='N' ", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "Nº ALBARAN"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 100
        dgAlbaranes.Columns(0).MinimumWidth = 100
        dgAlbaranes.Columns(1).HeaderText = "FECHA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 100
        dgAlbaranes.Columns(1).MinimumWidth = 100
        dgAlbaranes.Columns(2).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 450
        dgAlbaranes.Columns(2).MinimumWidth = 450
        dgAlbaranes.Columns(3).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).Visible = False
        dgAlbaranes.Columns(5).Visible = False
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True


        conexionmy.Close()
    End Sub

    Private Sub btFacturarSelec_Click(sender As Object, e As EventArgs) Handles btFacturarSelec.Click

        Dim selectedRowCount As Integer = dgAlbaranes.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim albaranes(selectedRowCount) As Integer

        If selectedRowCount > 0 Then
            Dim contador As Integer
            cargoNumero()
            For contador = 0 To selectedRowCount - 1
                albaranes(contador) = dgAlbaranes.SelectedRows(contador).Cells(0).Value
                Dim numAlb As Integer
                numAlb = dgAlbaranes.SelectedRows(contador).Cells(0).Value
                facturoAlbaran(numAlb)
            Next
        End If

        Me.Close()

    End Sub
    Public Sub cargoAlbaranFecha()

        Dim fec1 As Date = txFechaD.Text
        Dim fec2 As Date = txFechaH.Text
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, albaran_cab.fecha, clientes.nombre, albaran_cab.totalalbaran, albaran_cab.facturado, albaran_cab.clienteID, clientes.clienteID FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE DATE(albaran_cab.fecha) BETWEEN '" & fec1.ToString("yyyy-MM-dd") & "' AND '" & fec2.ToString("yyyy-MM-dd") & "' AND albaran_cab.facturado ='N' ", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Aquamarine
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "Nº ALBARAN"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 100
        dgAlbaranes.Columns(0).MinimumWidth = 100
        dgAlbaranes.Columns(1).HeaderText = "FECHA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 100
        dgAlbaranes.Columns(1).MinimumWidth = 100
        dgAlbaranes.Columns(2).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 450
        dgAlbaranes.Columns(2).MinimumWidth = 450
        dgAlbaranes.Columns(3).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).Visible = False
        dgAlbaranes.Columns(5).Visible = False
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True


        conexionmy.Close()
    End Sub
    Public Sub cargoNumero()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim cmdLastId As New MySqlCommand("SELECT num_factura FROM configuracion  ", conexionmy)
        Dim numid As Int32

        numid = cmdLastId.ExecuteScalar()

        txNumero.Text = numid + 1

        conexionmy.Close()
    End Sub

    Private Sub btFiltroFecha_Click(sender As Object, e As EventArgs) Handles btFiltroFecha.Click
        cargoAlbaranFecha()
    End Sub
    Public Sub cargoAlbaranNumero()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, albaran_cab.fecha, clientes.nombre, albaran_cab.totalalbaran, albaran_cab.facturado, albaran_cab.clienteID, clientes.clienteID FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE albaran_cab.num_albaran BETWEEN '" & txAlbaD.Text & "' AND '" & txAlbaH.Text & "' AND albaran_cab.facturado ='N' ", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Aquamarine
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "Nº ALBARAN"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 100
        dgAlbaranes.Columns(0).MinimumWidth = 100
        dgAlbaranes.Columns(1).HeaderText = "FECHA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 100
        dgAlbaranes.Columns(1).MinimumWidth = 100
        dgAlbaranes.Columns(2).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 450
        dgAlbaranes.Columns(2).MinimumWidth = 450
        dgAlbaranes.Columns(3).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).Visible = False
        dgAlbaranes.Columns(5).Visible = False
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True


        conexionmy.Close()
    End Sub

    Private Sub btFiltroAlbaran_Click(sender As Object, e As EventArgs) Handles btFiltroAlbaran.Click
        cargoAlbaranNumero()
    End Sub

    Private Sub btFacturarTodos_Click(sender As Object, e As EventArgs) Handles btFacturarTodos.Click

        Dim selectedRowCount As Integer = dgAlbaranes.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim row As New DataGridViewRow


        If selectedRowCount = 0 Then
            cargoNumero()
            For Each row In dgAlbaranes.Rows
                Dim numAlb As Integer
                numAlb = row.Cells(0).Value
                facturoAlbaran(numAlb)
            Next
        End If

        Me.Close()
    End Sub

    Private Sub txCliente_TextChanged(sender As Object, e As EventArgs) Handles txCliente.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT clienteID, nombre, descuento FROM clientes WHERE nombre LIKE'" & txCliente.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgClientes.DataSource = bind
        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(1).HeaderText = "NOMBRE CLIENTE"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(2).HeaderText = "DTO"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgClientes.Visible = True


        conexionmy.Close()

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()

    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        txNumero.Text = ""
        txFechaFra.Text = ""
        txFechaD.Text = ""
        txFechaH.Text = ""
        txAlbaD.Text = ""
        txAlbaH.Text = ""
        txCodcli.Text = ""
        txCliente.Text = ""

    End Sub
    Public Sub facturoAlbaran(nAlb As Integer)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdAlb As New MySqlCommand
        Dim cmd As New MySqlCommand
        cmd.CommandType = System.Data.CommandType.Text

        Dim rdrAlb As MySqlDataReader
        cmdAlb = New MySqlCommand("SELECT * FROM albaran_cab WHERE num_albaran = '" & nAlb & "'", conexionmy)


        cmdAlb.CommandType = CommandType.Text
        cmdAlb.Connection = conexionmy
        rdrAlb = cmdAlb.ExecuteReader
        rdrAlb.Read()



        If rdrAlb.HasRows = True Then

            'cargoNumero()
            Dim vFecha As Date = txFechaFra.Text
            Dim vCliente As String = rdrAlb("clienteID").ToString
            Dim vEnvio As String = rdrAlb("envioID").ToString
            Dim vEmpresa As String = rdrAlb("empresaID").ToString
            Dim vAgente As String = rdrAlb("agenteID").ToString
            Dim vUsuario As String = rdrAlb("usuarioID").ToString
            Dim vBruto As String = Replace(rdrAlb("totalbruto").ToString, ",", ".")
            Dim vDto As String = Replace(rdrAlb("totaldto").ToString, ",", ".")
            Dim vIva As String = Replace(rdrAlb("totaliva").ToString, ",", ".")
            Dim vTotal As String = Replace(rdrAlb("totalalbaran").ToString, ",", ".")
            Dim vReferencia As String = rdrAlb("referencia")
            Dim vObservaciones As String = rdrAlb("observaciones")
            Dim vAlb As String = nAlb.ToString
            Dim vDescrip As String = "Albarán Nº " + vAlb

            rdrAlb.Close()
            cmd.CommandText = "INSERT INTO factura_cab (num_factura, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalfactura, manual, eliminado, num_albaran) VALUES (" + txNumero.Text + " , '1' , " + vCliente + ", " + vEnvio + ", " + vEmpresa + ", " + vAgente + ", " + vUsuario + ", '" + vFecha.ToString("yyyy-MM-dd") + "', '" + vReferencia + "', '" + vObservaciones + "', '" + vBruto + "', '" + vDto + "', '" + vIva + "', '" + vTotal + "', 'N', 'N', " + vAlb + ")"
            cmd.Connection = conexionmy
            cmd.ExecuteNonQuery()

            Dim cmdLinea As New MySqlCommand
            cmdLinea.CommandType = System.Data.CommandType.Text
            cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, articuloID, descripcion, cantidad, precio, descuento, ivalinea, totalinea, linea) VALUES (" + txNumero.Text + " , '99999' , '" + vDescrip + "', 1, '" + vBruto + "', '" + vDto + "', '" + vIva + "', '" + vTotal + "', 1)"
            cmdLinea.Connection = conexionmy
            cmdLinea.ExecuteNonQuery()
            graboLineas(vAlb)
        Else
            'Por si no encuentra el albaran
            MsgBox("Albarán no disponible en la base de datos")
        End If

        Dim cmdupdate As New MySqlCommand
        cmdupdate.CommandType = System.Data.CommandType.Text
        cmdupdate.CommandText = "UPDATE albaran_cab SET facturado = 'S' WHERE num_albaran = '" & nAlb & "'"
        cmdupdate.Connection = conexionmy
        cmdupdate.ExecuteNonQuery()

        Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura = '" + txNumero.Text + "'  ", conexionmy)
        cmdActualizar.ExecuteNonQuery()

        conexionmy.Close()

    End Sub
    Public Sub graboLineas(nAlba As Integer)
        linea = 1
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdAlb As New MySqlCommand
        Dim cmd As New MySqlCommand
        cmd.CommandType = System.Data.CommandType.Text

        Dim rdrAlb As MySqlDataReader
        cmdAlb = New MySqlCommand("SELECT * FROM albaran_linea WHERE num_albaran = '" & nAlba & "'", conexionmy)


        cmdAlb.CommandType = CommandType.Text
        cmdAlb.Connection = conexionmy
        rdrAlb = cmdAlb.ExecuteReader
        rdrAlb.Read()
        If rdrAlb.HasRows Then
            Do While rdrAlb.Read()

                linea = linea + 1
                Dim cmdLinea As New MySqlCommand
                cmdLinea.CommandType = System.Data.CommandType.Text
                cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, totalinea, linea, lote) VALUES (" + txNumero.Text + " , '" + rdrAlb("codigo") + "' , '" + rdrAlb("descripcion") + "', '" + rdrAlb("cantidad") + "', '" + rdrAlb("cantidad") + "', '" + rdrAlb("ancho_largo") + "', '" + rdrAlb("m2_ml") + "', '" + rdrAlb("precio") + "', '" + rdrAlb("descuento") + "', '" + rdrAlb("ivalinea") + "', '" + rdrAlb("totalinea") + "', '" + linea + "', '" + rdrAlb("lote") + "')"
                cmdLinea.Connection = conexionmy
                cmdLinea.ExecuteNonQuery()

            Loop
        End If

    End Sub
End Class