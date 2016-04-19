Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frFacturaAlbaran
    Public Shared linea As Int16 = 0
    Public Shared vTotalBruto As Decimal = 0
    Public Shared vTotalDto As Decimal = 0
    Public Shared vTotalIva As Decimal = 0
    Public Shared vTotalRecargo As Decimal = 0
    Public Shared vTotalAlbaran As Decimal = 0
    Public Shared vTotalBrutoFac As Decimal = 0
    Public Shared vTotalDtoFac As Decimal = 0
    Public Shared vTotalIvaFac As Decimal = 0
    Public Shared vTotalRecargoFac As Decimal = 0
    Public Shared vTotalFactura As Decimal = 0
    Public Shared albaFactu As New List(Of albaranFactura)

    Private Sub frFacturaAlbaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgClientes.Visible = False
        cargoClientesMy()
        txFechaFra.Text = Format(Today, "ddMMyyyy")
    End Sub
    Public Sub cargoClientesMy()

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT clienteID, nombre, descuento, agenteID FROM clientes", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        dgClientes.DataSource = bind
        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(0).FillWeight = 50
        dgClientes.Columns(0).MinimumWidth = 50
        dgClientes.Columns(1).HeaderText = "NOMBRE CLIENTE"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(1).FillWeight = 160
        dgClientes.Columns(1).MinimumWidth = 160
        dgClientes.Columns(2).HeaderText = "DTO"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.Columns(2).FillWeight = 50
        dgClientes.Columns(2).MinimumWidth = 50
        dgClientes.Columns(3).HeaderText = "AG"
        dgClientes.Columns(3).Name = "Column4"
        dgClientes.Columns(3).FillWeight = 30
        dgClientes.Columns(3).MinimumWidth = 30
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub txClientes_TextChanged(sender As Object, e As EventArgs)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT clienteID, nombre, descuento, agenteID FROM clientes WHERE nombre LIKE'" & txCliente.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgClientes.DataSource = bind
        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(0).FillWeight = 50
        dgClientes.Columns(0).MinimumWidth = 50
        dgClientes.Columns(1).HeaderText = "NOMBRE CLIENTE"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(1).FillWeight = 160
        dgClientes.Columns(1).MinimumWidth = 160
        dgClientes.Columns(2).HeaderText = "DTO"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.Columns(2).FillWeight = 50
        dgClientes.Columns(2).MinimumWidth = 50
        dgClientes.Columns(3).HeaderText = "AG"
        dgClientes.Columns(3).Name = "Column4"
        dgClientes.Columns(3).FillWeight = 30
        dgClientes.Columns(3).MinimumWidth = 30
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
        txAgente.Text = dgClientes.CurrentRow.Cells("Column4").Value.ToString

        dgClientes.Visible = False

        cargoAlbaranes()

    End Sub
    Public Sub cargoAlbaranes()

        If txCodcli.Text = "" Then
            MsgBox("No ha seleccionado ningún cliente. Antes de continuar seleccione un cliente")
            Exit Sub
        Else
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")

            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.facturado, 
                                                    albaran_cab.clienteID, 
                                                    clientes.clienteID,
                                                    albaran_cab.serie
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID 
                                            WHERE albaran_cab.clienteID ='" & txCodcli.Text & "' 
                                                AND albaran_cab.facturado ='N' AND serie = '1' ORDER BY albaran_cab.num_albaran ASC", conexionmy)

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
            dgAlbaranes.Columns(7).Visible = False
            dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgAlbaranes.Visible = True


            conexionmy.Close()
        End If

    End Sub

    Private Sub btFacturarSelec_Click(sender As Object, e As EventArgs) Handles btFacturarSelec.Click

        Dim numAlb As Integer
        Dim selectedRowCount As Integer = dgAlbaranes.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim albaranes(selectedRowCount) As Integer

        If selectedRowCount > 0 Then
            Dim contador As Integer
            cargoNumero()
            For contador = 0 To selectedRowCount - 1
                albaranes(contador) = dgAlbaranes.SelectedRows(contador).Cells(0).Value
                numAlb = dgAlbaranes.SelectedRows(contador).Cells(0).Value
                'guardoDatosAlbaran - Guardo las cabeceras de los albaranes
                guardoDatosAlbaran(numAlb)
                'facturoAlbaran - Grabo la linea de resumen y llamo a graboLineas para guardar las líneas de cada albarán
                facturoAlbaran(numAlb)
            Next
            'sumoLineas - Totaliza las líneas y graba a cabecera de la factura
            sumoLineas(numAlb)
        End If

        MsgBox("La factura de los albaranes seleccionados se ha realizado correctamente")
        Me.Close()

    End Sub
    Public Sub cargoAlbaranFecha()
        If txCodcli.Text = "" Then
            MsgBox("No ha seleccionado ningún cliente. Antes de continuar seleccione un cliente")
            Exit Sub
        Else
            Dim fec1 As Date = txFechaD.Text
            Dim fec2 As Date = txFechaH.Text
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")

            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                            albaran_cab.fecha, 
                                                            clientes.nombre, 
                                                            albaran_cab.totalalbaran, 
                                                            albaran_cab.facturado, 
                                                            albaran_cab.clienteID, 
                                                            clientes.clienteID,
                                                            albaran_cab.serie
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID 
                                            WHERE DATE(albaran_cab.fecha) BETWEEN '" & fec1.ToString("yyyy-MM-dd") & "' AND '" & fec2.ToString("yyyy-MM-dd") & "' 
                                            AND albaran_cab.facturado ='N' AND albaran_cab.clienteID = '" & txCodcli.Text & "' AND albaran_cab.serie = '1' ORDER BY albaran_cab.num_albaran ASC", conexionmy)

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
            dgAlbaranes.Columns(7).Visible = False
            dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgAlbaranes.Visible = True


            conexionmy.Close()
        End If

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

        If txCodcli.Text = "" Then
            MsgBox("No ha seleccionado ningún cliente. Antes de continuar seleccione un cliente")
            Exit Sub
        Else
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")

            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.facturado, 
                                                    albaran_cab.clienteID, 
                                                    clientes.clienteID,
                                                    albaran_cab.serie
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID 
                                            WHERE albaran_cab.num_albaran BETWEEN '" & txAlbaD.Text & "' AND '" & txAlbaH.Text & "' 
                                            AND albaran_cab.facturado ='N' AND albaran_cab.clienteID = '" & txCodcli.Text & "' AND albaran_cab.serie = '1' ORDER BY albaran_cab.num_albaran ASC ", conexionmy)

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
            dgAlbaranes.Columns(7).Visible = False
            dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgAlbaranes.Visible = True


            conexionmy.Close()
        End If


    End Sub

    Private Sub btFiltroAlbaran_Click(sender As Object, e As EventArgs) Handles btFiltroAlbaran.Click
        cargoAlbaranNumero()
    End Sub

    Private Sub btFacturarTodos_Click(sender As Object, e As EventArgs) Handles btFacturarTodos.Click
        Dim numAlb As Integer
        Dim selectedRowCount As Integer = dgAlbaranes.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim row As New DataGridViewRow

        If selectedRowCount = 0 Then
            cargoNumero()

            For Each row In dgAlbaranes.Rows
                numAlb = row.Cells(0).Value
                'guardoDatosAlbaran - Guardo las cabeceras de los albaranes
                guardoDatosAlbaran(numAlb)
                'facturoAlbaran - Grabo la linea de resumen y llamo a graboLineas para guardar las líneas de cada albarán
                facturoAlbaran(numAlb)
            Next
            'sumoLineas - Totaliza las líneas y graba a cabecera de la factura
            sumoLineas(numAlb)
        End If
        MsgBox("La factura de los albaranes seleccionados se ha realizado correctamente")
        Me.Close()
    End Sub

    Private Sub txCliente_TextChanged(sender As Object, e As EventArgs) Handles txCliente.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT clienteID, nombre, descuento, agenteID FROM clientes WHERE nombre LIKE'" & txCliente.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgClientes.DataSource = bind
        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(0).FillWeight = 50
        dgClientes.Columns(0).MinimumWidth = 50
        dgClientes.Columns(1).HeaderText = "NOMBRE CLIENTE"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(1).FillWeight = 160
        dgClientes.Columns(1).MinimumWidth = 160
        dgClientes.Columns(2).HeaderText = "DTO"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.Columns(2).FillWeight = 50
        dgClientes.Columns(2).MinimumWidth = 50
        dgClientes.Columns(3).HeaderText = "AG"
        dgClientes.Columns(3).Name = "Column4"
        dgClientes.Columns(3).FillWeight = 30
        dgClientes.Columns(3).MinimumWidth = 30
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

        Dim rdrAlb As MySqlDataReader
        cmdAlb = New MySqlCommand("SELECT * FROM albaran_cab WHERE num_albaran = '" & nAlb & "'", conexionmy)


        cmdAlb.CommandType = CommandType.Text
        cmdAlb.Connection = conexionmy
        rdrAlb = cmdAlb.ExecuteReader
        rdrAlb.Read()



        If rdrAlb.HasRows = True Then
            linea = linea + 1
            Dim vAlb As String = nAlb.ToString
            Dim vFechaAlb As Date = rdrAlb("fecha").ToString
            Dim vDescrip As String = "***** ALBARAN Nº: " + vAlb + " DE: " + vFechaAlb + " *****"

            rdrAlb.Close()

            Dim cmdLinea As New MySqlCommand
            cmdLinea.CommandType = System.Data.CommandType.Text
            cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, articuloID, descripcion, cantidad, precio, descuento, ivalinea, totalinea, linea) VALUES (" + txNumero.Text + " , '99999' , '" + vDescrip + "', 0, '0', '0', '0', '0', '" + linea.ToString + "')"
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
        'linea = 1
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim conexionmy2 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy2.Open()
        Dim cmdAlb As New MySqlCommand()


        Dim rdrAlb As MySqlDataReader
        cmdAlb = New MySqlCommand("SELECT * FROM albaran_linea WHERE num_albaran = '" & nAlba & "'", conexionmy)


        cmdAlb.CommandType = CommandType.Text
        cmdAlb.Connection = conexionmy
        rdrAlb = cmdAlb.ExecuteReader
        If rdrAlb.HasRows Then
            Do While rdrAlb.Read()

                linea = linea + 1
                Dim vCantidad As String = Replace(rdrAlb("cantidad").ToString, ",", ".")
                Dim vAncho As String = Replace(rdrAlb("ancho_largo").ToString, ",", ".")
                Dim vMl As String = Replace(rdrAlb("m2_ml").ToString, ",", ".")
                Dim vPrecio As String = Replace(rdrAlb("precio").ToString, ",", ".")
                Dim vDescuento As String = Replace(rdrAlb("descuento").ToString, ",", ".")
                Dim vIva As String = Replace(rdrAlb("ivalinea").ToString, ",", ".")
                Dim vImporte As String = Replace(rdrAlb("importe").ToString, ",", ".")
                Dim vTotal As String = Replace(rdrAlb("totalinea").ToString, ",", ".")
                Dim cmdLinea As New MySqlCommand
                cmdLinea.CommandType = System.Data.CommandType.Text
                cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, linea, lote, num_albaran) VALUES (" + txNumero.Text + " , '" + rdrAlb("codigo") + "' , '" + rdrAlb("descripcion") + "', '" + vCantidad + "' , '" + vAncho + "', '" + vMl + "', '" + vPrecio + "', '" + vDescuento + "', '" + vIva + "', '" + vImporte + "', '" + vTotal + "', '" + linea.ToString + "', '" + rdrAlb("lote") + "', '" + nAlba.ToString + "')"
                cmdLinea.Connection = conexionmy2
                cmdLinea.ExecuteNonQuery()

            Loop
        End If
        conexionmy.Close()

    End Sub

    Public Sub guardoDatosAlbaran(nAlbaran As Integer)
        vTotalBruto = 0
        vTotalDto = 0
        vTotalIva = 0
        vTotalRecargo = 0
        vTotalAlbaran = 0



        Dim vNdeAlbaran As Integer
        vNdeAlbaran = nAlbaran

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdAlb As New MySqlCommand


        Dim rdrAlb As MySqlDataReader
        cmdAlb = New MySqlCommand("SELECT * FROM albaran_cab WHERE num_albaran = '" & nAlbaran & "'", conexionmy)


        cmdAlb.CommandType = CommandType.Text
        cmdAlb.Connection = conexionmy
        rdrAlb = cmdAlb.ExecuteReader
        rdrAlb.Read()

        If rdrAlb.HasRows = True Then

            vTotalBruto = vTotalBruto + rdrAlb("totalbruto")
            vTotalDto = vTotalDto + rdrAlb("totaldto")
            vTotalIva = vTotalIva + rdrAlb("totaliva")
            vTotalRecargo = vTotalRecargo + rdrAlb("totalrecargo")
            vTotalAlbaran = vTotalAlbaran + rdrAlb("totalalbaran")

            albaFactu.Add(New albaranFactura() With {.numAlba = vNdeAlbaran, .totbrut = vTotalBruto, .totdto = vTotalDto, .totiva = vTotalIva, .totrec = vTotalRecargo, .totalb = vTotalAlbaran})

            rdrAlb.Close()

        Else
            'Por si no encuentra el albaran
            MsgBox("Albarán no disponible en la base de datos")
        End If



    End Sub
    Public Sub sumoLineas(nAlba As Integer)
        vTotalBrutoFac = 0
        vTotalDtoFac = 0
        vTotalIvaFac = 0
        vTotalRecargoFac = 0
        vTotalFactura = 0
        Dim vFecha As Date = Today

        For Each itemlineas As albaranFactura In albaFactu
            'Calculo los totales de la factura
            vTotalBrutoFac = vTotalBrutoFac + itemlineas.totbrut
            vTotalDtoFac = vTotalDtoFac + itemlineas.totdto
            vTotalIvaFac = vTotalIvaFac + itemlineas.totiva
            vTotalRecargoFac = vTotalRecargoFac + itemlineas.totrec
            vTotalFactura = vTotalFactura + itemlineas.totalb
        Next
        'Genero la cabecera del albarán

        Dim vTotalBF As String = Replace(vTotalBrutoFac.ToString, ",", ".")
        Dim vTotalDF As String = Replace(vTotalDtoFac.ToString, ",", ".")
        Dim vTotalIF As String = Replace(vTotalIvaFac.ToString, ",", ".")
        Dim vTotalRF As String = Replace(vTotalRecargoFac.ToString, ",", ".")
        Dim vTotalF As String = Replace(vTotalFactura.ToString, ",", ".")
        Dim vObserva As String = " "

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand
        cmd.CommandType = System.Data.CommandType.Text

        cmd.CommandText = "INSERT INTO factura_cab (num_factura, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, fechapago, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalfactura, manual, eliminado, formapago, pagado) VALUES (" + txNumero.Text + " , '1' , " + txCodcli.Text + ", " + txCodcli.Text + ", " + vEmpresa + ", " + txAgente.Text + ", " + vCodUser + ", '" + vFecha.ToString("yyyy-MM-dd") + "', '" + vFecha.ToString("yyyy-MM-dd") + "', '" + vObserva + "', '" + vTotalBF + "', '" + vTotalDF + "', '" + vTotalIF + "', '" + vTotalRF + "', '" + vTotalF + "', 'N', 'N', 1, 'N')"
        cmd.Connection = conexionmy
        cmd.ExecuteNonQuery()

        conexionmy.Close()

    End Sub

    Private Sub frFacturaAlbaran_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        albaFactu.Clear()
        launcher.FacturarAlbaranesToolStripMenuItem.Enabled = True

    End Sub
End Class