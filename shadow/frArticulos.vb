Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frArticulos
    Public Shared flagEditArti As Boolean
    Public Shared flagLona As Boolean
    Public Shared lineas As Int16
    Public Shared flagEditLotes As Boolean
    Public Shared flagModifLote As Boolean = False



    Public Sub cargoArticulos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()

        Dim consultacli As New MySqlCommand("SELECT ref_proveedor, grupoID, descripcion, color, pvp, articuloID FROM articulos2 ORDER BY descripcion", conexionmy)


        Dim readercli As MySqlDataReader
        Dim dtablecli As New DataTable

        Dim bind3 As New BindingSource()



        readercli = consultacli.ExecuteReader
        dtablecli.Load(readercli, LoadOption.OverwriteChanges)


        bind3.DataSource = dtablecli

        dgArticulos.DataSource = bind3
        dgArticulos.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgArticulos.ColumnHeadersDefaultCellStyle = styCabeceras

        dgArticulos.Columns(0).HeaderText = "REF PROVEEDOR"
        dgArticulos.Columns(0).Name = "Column1"
        dgArticulos.Columns(0).FillWeight = 125
        dgArticulos.Columns(0).MinimumWidth = 125
        dgArticulos.Columns(1).HeaderText = "GRUPO"
        dgArticulos.Columns(1).Name = "Column2"
        dgArticulos.Columns(1).FillWeight = 75
        dgArticulos.Columns(1).MinimumWidth = 75
        dgArticulos.Columns(2).HeaderText = "DESCRIPCION"
        dgArticulos.Columns(2).Name = "Column3"
        dgArticulos.Columns(2).FillWeight = 350
        dgArticulos.Columns(2).MinimumWidth = 350
        dgArticulos.Columns(3).HeaderText = "COLOR"
        dgArticulos.Columns(3).Name = "Column4"
        dgArticulos.Columns(3).FillWeight = 175
        dgArticulos.Columns(3).MinimumWidth = 175
        dgArticulos.Columns(4).HeaderText = "PVP"
        dgArticulos.Columns(4).Name = "Column5"
        dgArticulos.Columns(4).FillWeight = 75
        dgArticulos.Columns(4).MinimumWidth = 75
        dgArticulos.Columns(5).Visible = False
        'gridcliente.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridcliente.Columns(4).Visible = False
        'gridcliente.Columns(5).Visible = False
        'gridcliente.Columns(6).Visible = False
        dgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgArticulos.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub frArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deshabilitarBotones()
        ocultarLineaLote()

        TabControl1.SelectTab(1)
        cmdNuevo.Enabled = True
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = True

        txRefProv.Focus()

        cargoArticulos()

        flagEditArti = False
        flagLona = False

    End Sub

    Private Sub cmdLonas_Click(sender As Object, e As EventArgs) Handles cmdLonas.Click
        If GroupBox2.Enabled = False Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub
    Public Sub deshabilitarBotones()
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = False
        cmdFlechas.Enabled = False
        cmdLonas.Enabled = False
        cmdLotes.Enabled = False
        btProveedor.Enabled = False
        cmdDuplicar.Enabled = False
    End Sub
    Public Sub limpiarFormulario()
        txRefProv.Text = ""
        txCodigo.Text = ""
        txGrupo.Text = ""
        txProveedor.Text = ""
        txNumPro.Text = ""
        txDescripcion.Text = ""

        txModeloID.Text = ""

        txUbicacion.Text = ""
        ckControlStock.Enabled = True
        txIva.Text = "21.00"
        txCompra.Text = 0
        txDto.Text = 0
        txMargenPor.Text = 0
        txMargenEuro.Text = 0
        txPrecio.Text = 0
        txStock.Text = 0
        txMinimo.Text = 0
        txInicial.Text = 0
        tsBotones.Focus()
        cmdNuevo.Select()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim equiv As String

        If flagEditArti = False Then
            Dim cmd As New MySqlCommand
            Dim cmdLastId As New MySqlCommand("SELECT LAST_INSERT_ID()  ", conexionmy)
            Dim numid As Int32


            Dim descuento As String = txDto.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")
            Dim iva As String = txIva.Text
            Dim guardo_iva As String = Replace(iva, ",", ".")
            Dim compra As String = txCompra.Text
            Dim guardo_compra As String = Replace(compra, ",", ".")
            Dim dto As String = txDto.Text
            Dim guardo_dto As String = Replace(dto, ",", ".")
            Dim margenpor As String = txMargenPor.Text
            Dim guardo_margenpor As String = Replace(margenpor, ",", ".")
            Dim margeneur As String = txMargenEuro.Text
            Dim guardo_margeneur As String = Replace(margeneur, ",", ".")
            Dim precio As String = txPrecio.Text
            Dim guardo_precio As String = Replace(precio, ",", ".")
            Dim stock As String = txStock.Text
            Dim guardo_stock As String = Replace(stock, ",", ".")

            Dim stockmin As String = txMinimo.Text
            Dim guardo_stockmin As String = Replace(stockmin, ",", ".")
            Dim stockini As String = txInicial.Text
            Dim guardo_stockini As String = Replace(stockini, ",", ".")
            Dim vColores As String
            Dim vTejido As String


            If ckControlStock.Checked = True Then
                equiv = "S"
            Else
                equiv = "N"
            End If

            If cbColores.SelectedItem Is Nothing Then
                vColores = ""
            Else
                vColores = cbColores.SelectedValue.ToString
            End If
            If cbTejido.SelectedItem Is Nothing Then
                vTejido = ""
            Else
                vTejido = cbTejido.SelectedValue.ToString
            End If

            If txNumPro.Text = "" Then
                MsgBox("Es necesario seleccionar un proveedor para el artículo actual")
                Exit Sub
            End If
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO articulos2 (ref_proveedor, referencia, grupoID, proveedorID, descripcion, tipo_tejido, modelo, tejido, familia, color, colorID, ubicacion, medida, medidaID, unidad, ud_medida, control_stock, iva, precio_compra, dto_prov, porc_margen, euro_margen, pvp, stock, stock_min, stock_ini) VALUES ('" + txRefProv.Text + "' , '" + txCodigo.Text + "' , '" + txGrupo.Text + "' , '" + txNumPro.Text + "' , '" + txDescripcion.Text + "' , '" + vTejido + "' , '" + cbModelos.SelectedValue.ToString + "' , '" + cbTejido2.SelectedValue.ToString + "' , '" + cbFamilias.SelectedValue.ToString + "' , '" + cbColores.Text + "' , '" + vColores + "' , '" + txUbicacion.Text + "' , '" + cbMedidas.Text + "' , '" + cbMedidas.SelectedValue.ToString + "' , '" + cbUnidad.SelectedValue.ToString + "' , '" + cbUnidad.Text + "' , '" + equiv + "' , '" + guardo_iva + "' , '" + guardo_compra + "' , '" + guardo_dto + "' , '" + guardo_margenpor + "' , '" + guardo_margeneur + "' , '" + guardo_precio + "' , '" + guardo_stock + "' , '" + guardo_stockmin + "' , '" + guardo_stockini + "')"

            cmd.Connection = conexionmy

                cmd.ExecuteNonQuery()

                numid = cmdLastId.ExecuteScalar()

                'Guardo lotes
                Dim cmdLinea As New MySqlCommand
                Dim row As New DataGridViewRow
                Dim lincant As String
                Dim guardo_lincant As String


                For Each row In dgLotes.Rows

                    lincant = Decimal.Parse(row.Cells(3).Value).ToString("0.00")
                    guardo_lincant = Replace(lincant, ",", ".")

                    cmdLinea.Connection = conexionmy
                    cmdLinea.CommandText = "INSERT INTO lotes (referencia, descripcion, lote, stock_inicial, ubicacion) VALUES ('" + row.Cells(0).Value + "', " + row.Cells(1).Value + ", '" + row.Cells(2).Value + "', '" + guardo_lincant + "', '" + row.Cells(4).Value + "')"

                    cmdLinea.ExecuteNonQuery()

                Next

                conexionmy.Close()
                'Me.Hide()
            Else

                Dim descuento As String = txDto.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")
            Dim iva As String = txIva.Text
            Dim guardo_iva As String = Replace(iva, ",", ".")
            Dim compra As String = txCompra.Text
            Dim guardo_compra As String = Replace(compra, ",", ".")
            Dim dto As String = txDto.Text
            Dim guardo_dto As String = Replace(dto, ",", ".")
            Dim margenpor As String = txMargenPor.Text
            Dim guardo_margenpor As String = Replace(margenpor, ",", ".")
            Dim margeneur As String = txMargenEuro.Text
            Dim guardo_margeneur As String = Replace(margeneur, ",", ".")
            Dim precio As String = txPrecio.Text
            Dim guardo_precio As String = Replace(precio, ",", ".")
            Dim stock As String = txStock.Text
            Dim guardo_stock As String = Replace(stock, ",", ".")

            Dim stockmin As String = txMinimo.Text
            Dim guardo_stockmin As String = Replace(stockmin, ",", ".")
            Dim stockini As String = txInicial.Text
            Dim guardo_stockini As String = Replace(stockini, ",", ".")
            Dim vColores As String
            Dim vTejido As String

            If ckControlStock.Checked = True Then
                equiv = "S"
            Else
                equiv = "N"
            End If

            If cbColores.SelectedItem Is Nothing Then
                vColores = ""
            Else
                vColores = cbColores.SelectedValue.ToString
            End If
            If cbTejido.SelectedItem Is Nothing Then
                vTejido = ""
            Else
                vTejido = cbTejido.SelectedValue.ToString
            End If

            Dim cmdActualizar As New MySqlCommand("UPDATE articulos2 SET descripcion = '" + txDescripcion.Text + "', 
                                                referencia = '" + txCodigo.Text + "',
                                                grupoID = '" + txGrupo.Text + "', 
                                                proveedorID = '" + txNumPro.Text + "',
                                                medidaID= '" + cbMedidas.SelectedValue.ToString + "',
                                                medida = '" + cbMedidas.SelectedValue.ToString + "',
                                                tejido = '" + vTejido + "',
                                                tejido = '" + cbTejido2.SelectedValue.ToString + "',
                                                modelo = '" + cbModelos.SelectedValue.ToString + "',
                                                familia = '" + cbFamilias.SelectedValue.ToString + "',
                                                color = '" + cbColores.Text + "',
                                                colorID = '" + vColores + "',
                                                ubicacion = '" + txUbicacion.Text + "',
                                                unidad = '" + cbUnidad.SelectedValue.ToString + "',
                                                ud_medida = '" + cbUnidad.Text + "',
                                                control_stock = '" + equiv + "',
                                                iva = '" + guardo_iva + "',
                                                precio_compra = '" + guardo_compra + "',
                                                dto_prov = '" + guardo_dto + "',
                                                porc_margen = '" + guardo_margenpor + "',
                                                euro_margen = '" + guardo_margeneur + "',
                                                pvp = '" + guardo_precio + "',
                                                stock = '" + guardo_stock + "',
                                                stock_min = '" + guardo_stockmin + "',
                                                stock_ini = '" + guardo_stockini + "' WHERE articuloID = '" + txIdarticulo.Text + "'", conexionmy)
            cmdActualizar.ExecuteNonQuery()

            MsgBox("Los datos del artículo se han actualizado correctamente")
            flagEditArti = False
            'Me.Close()
        End If
        TabControl2.SelectTab(0)
        TabControl1.SelectTab(0)
        txCodigo1.Text = ""
        txArticulo.Text = ""
        cargoArticulos()

    End Sub

    Private Sub btProveedor_Click(sender As Object, e As EventArgs) Handles btProveedor.Click
        formCli = "A"
        frVerProveedores.Show()

    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        limpiarFormulario()
        cmdNuevo.Enabled = False
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdFlechas.Enabled = False
        cmdLotes.Enabled = True
        cmdLonas.Enabled = True
        cmdDuplicar.Enabled = False
        btProveedor.Enabled = True

        GroupBox2.Enabled = False

        cargoCombos()

        txRefProv.Focus()

    End Sub

    Private Sub cmdLotes_Click(sender As Object, e As EventArgs) Handles cmdLotes.Click
        pnLotes.Visible = True
        If flagEditArti = True Then
            ocultarLineaLote()
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmdLinea As New MySqlCommand

            cmdLinea = New MySqlCommand("SELECT * FROM lotes WHERE referencia = '" + txRefProv.Text + "' ORDER BY loteID", conexionmy)

            cmdLinea.CommandType = CommandType.Text
            cmdLinea.Connection = conexionmy

            Dim rdrLin As MySqlDataReader
            rdrLin = cmdLinea.ExecuteReader
            If rdrLin.HasRows Then
                Do While rdrLin.Read()
                    lineas = lineas + 1
                    dgLotes.Rows.Add()
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = rdrLin("referencia")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = rdrLin("descripcion")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = rdrLin("lote")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = rdrLin("stock")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = rdrLin("ubicacion")
                Loop
            Else

            End If

            rdrLin.Close()
            conexionmy.Close()

        Else
            ocultarLineaLote()
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmdLinea As New MySqlCommand

            cmdLinea = New MySqlCommand("SELECT * FROM lotes WHERE referencia = '" + txRefProv.Text + "' ORDER BY loteID", conexionmy)

            cmdLinea.CommandType = CommandType.Text
            cmdLinea.Connection = conexionmy

            Dim rdrLin As MySqlDataReader
            rdrLin = cmdLinea.ExecuteReader
            If rdrLin.HasRows Then
                Do While rdrLin.Read()
                    lineas = lineas + 1
                    dgLotes.Rows.Add()
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = rdrLin("referencia")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = rdrLin("descripcion")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = rdrLin("lote")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = rdrLin("stock")
                    dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = rdrLin("ubicacion")
                Loop
            Else

            End If

            rdrLin.Close()
            conexionmy.Close()
        End If

    End Sub

    Public Sub montoDescripcion()
        txDescripcion.Text = cbModelos.Text + " " + cbTejido2.Text + " " + txCodigo.Text
    End Sub

    Private Sub txModelo_TextChanged(sender As Object, e As EventArgs)
        montoDescripcion()
    End Sub

    Private Sub txTejido_TextChanged(sender As Object, e As EventArgs)
        montoDescripcion()
    End Sub

    Private Sub btCloseLotes_Click(sender As Object, e As EventArgs) Handles btCloseLotes.Click
        pnLotes.Visible = False
        dgLotes.Rows.Clear()
        flagEditLotes = False

    End Sub

    Private Sub btNuevaLinea_Click(sender As Object, e As EventArgs) Handles btNuevaLinea.Click

        If flagEditArti = True Then
            flagEditLotes = True
            txRefLote.Text = txRefProv.Text
            txDescLote.Text = txDescripcion.Text
            verLineaLote()
            txLoteLote.Focus()

        Else
            'dgLotes.Rows.Add()
            'dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = txRefProv.Text
            'dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = txDescripcion.Text
            'dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = ""
            'dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = 0
            'dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = ""

            'dgLotes.Focus()
            'dgLotes.CurrentCell = dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2)
            'dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Selected = True
            txRefLote.Text = txRefProv.Text
            txDescLote.Text = txDescripcion.Text
            verLineaLote()
            txLoteLote.Focus()
        End If

    End Sub

    Private Sub btEliminarLinea_Click(sender As Object, e As EventArgs) Handles btEliminarLinea.Click
        If flagEditArti = True Then
            eliminarLote()
        Else
            dgLotes.Rows.RemoveAt(dgLotes.CurrentRow.Index)
        End If

    End Sub

    Private Sub dgArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgArticulos.CellDoubleClick
        txRefProv.Text = dgArticulos.CurrentRow.Cells("column1").Value.ToString
        TabControl1.SelectTab(1)
        cargoDatos()
        cmdNuevo.Enabled = False
        cmdGuardar.Enabled = True
        cmdDuplicar.Enabled = True
        cmdLotes.Enabled = True
        cmdCancelar.Enabled = True


        flagEditArti = True
    End Sub

    Private Sub txCodigo1_TextChanged(sender As Object, e As EventArgs) Handles txCodigo1.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)


        conexionmy.Open()
        Dim consultacli As New MySqlCommand("SELECT ref_proveedor, grupoID, descripcion, color, pvp, articuloID FROM articulos2 WHERE ref_proveedor LIKE'" & txCodigo1.Text & "%'  ORDER BY descripcion", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultacli.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        bind.DataSource = dtable
        dgArticulos.DataSource = bind
        dgArticulos.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgArticulos.ColumnHeadersDefaultCellStyle = styCabeceras

        dgArticulos.Columns(0).HeaderText = "REF PROVEEDOR"
        dgArticulos.Columns(0).Name = "Column1"
        dgArticulos.Columns(0).FillWeight = 125
        dgArticulos.Columns(0).MinimumWidth = 125
        dgArticulos.Columns(1).HeaderText = "GRUPO"
        dgArticulos.Columns(1).Name = "Column2"
        dgArticulos.Columns(1).FillWeight = 75
        dgArticulos.Columns(1).MinimumWidth = 75
        dgArticulos.Columns(2).HeaderText = "DESCRIPCION"
        dgArticulos.Columns(2).Name = "Column3"
        dgArticulos.Columns(2).FillWeight = 350
        dgArticulos.Columns(2).MinimumWidth = 350
        dgArticulos.Columns(3).HeaderText = "COLOR"
        dgArticulos.Columns(3).Name = "Column4"
        dgArticulos.Columns(3).FillWeight = 175
        dgArticulos.Columns(3).MinimumWidth = 175
        dgArticulos.Columns(4).HeaderText = "PVP"
        dgArticulos.Columns(4).Name = "Column5"
        dgArticulos.Columns(4).FillWeight = 75
        dgArticulos.Columns(4).MinimumWidth = 75
        dgArticulos.Columns(5).Visible = False
        'gridcliente.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridcliente.Columns(4).Visible = False
        'gridcliente.Columns(5).Visible = False
        'gridcliente.Columns(6).Visible = False
        dgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgArticulos.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub txArticulo_TextChanged(sender As Object, e As EventArgs) Handles txArticulo.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)


        conexionmy.Open()
        Dim consultacli As New MySqlCommand("SELECT ref_proveedor, grupoID, descripcion, color, pvp, articuloID FROM articulos2 WHERE descripcion LIKE'" & txArticulo.Text & "%'  ORDER BY descripcion", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultacli.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        bind.DataSource = dtable
        dgArticulos.DataSource = bind
        dgArticulos.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgArticulos.ColumnHeadersDefaultCellStyle = styCabeceras

        dgArticulos.Columns(0).HeaderText = "REF PROVEEDOR"
        dgArticulos.Columns(0).Name = "Column1"
        dgArticulos.Columns(0).FillWeight = 125
        dgArticulos.Columns(0).MinimumWidth = 125
        dgArticulos.Columns(1).HeaderText = "GRUPO"
        dgArticulos.Columns(1).Name = "Column2"
        dgArticulos.Columns(1).FillWeight = 75
        dgArticulos.Columns(1).MinimumWidth = 75
        dgArticulos.Columns(2).HeaderText = "DESCRIPCION"
        dgArticulos.Columns(2).Name = "Column3"
        dgArticulos.Columns(2).FillWeight = 350
        dgArticulos.Columns(2).MinimumWidth = 350
        dgArticulos.Columns(3).HeaderText = "COLOR"
        dgArticulos.Columns(3).Name = "Column4"
        dgArticulos.Columns(3).FillWeight = 175
        dgArticulos.Columns(3).MinimumWidth = 175
        dgArticulos.Columns(4).HeaderText = "PVP"
        dgArticulos.Columns(4).Name = "Column5"
        dgArticulos.Columns(4).FillWeight = 75
        dgArticulos.Columns(4).MinimumWidth = 75
        dgArticulos.Columns(5).Visible = False
        'gridcliente.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridcliente.Columns(4).Visible = False
        'gridcliente.Columns(5).Visible = False
        'gridcliente.Columns(6).Visible = False
        dgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgArticulos.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub cargoDatos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM articulos2 WHERE ref_proveedor = '" + txRefProv.Text + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        txIdarticulo.Text = rdr("articuloID")
        txCodigo.Text = rdr("referencia")
        txGrupo.Text = rdr("grupoID")
        txNumPro.Text = rdr("proveedorID")
        cargoProveedor()
        cargoCombos()
        If rdr("familia") <> 7 Then
            GroupBox2.Enabled = False
        Else
            GroupBox2.Enabled = True
            cbTejido.SelectedValue = rdr("tipo_tejido")
            cbModelos.SelectedValue = rdr("modelo")
            cbTejido2.SelectedValue = rdr("tejido")
        End If

        cargoFamilia(rdr("familia"))
        txDescripcion.Text = rdr("descripcion")
        cbColores.Text = rdr("color")
        If rdr("medida") = "" Then
            cbMedidas.SelectedValue = "000"
        Else
            cbMedidas.SelectedValue = rdr("medida")
        End If

        cbUnidad.Text = rdr("ud_medida")
        txIva.Text = rdr("iva")
        txCompra.Text = rdr("precio_compra")
        txDto.Text = rdr("dto_prov")
        txMargenPor.Text = rdr("porc_margen")
        If rdr("euro_margen") = "" Then
            txMargenEuro.Text = "0,00"
        Else
            txMargenEuro.Text = rdr("euro_margen")
        End If
        txPrecio.Text = rdr("pvp")
        txUbicacion.Text = rdr("ubicacion")
        txStock.Text = rdr("stock")
        txMinimo.Text = rdr("stock_min")
        txInicial.Text = rdr("stock_ini")

        conexionmy.Close()

    End Sub
    Public Sub cargoProveedor()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT proveedorID, nombrecom FROM proveedores WHERE proveedorID = '" + txNumPro.Text + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        txProveedor.Text = rdr("nombrecom")
        conexionmy.Close()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        deshabilitarBotones()
        cmdNuevo.Enabled = True
        limpiarFormulario()
        TabControl1.SelectTab(0)
        txCodigo1.Text = ""
        txArticulo.Text = ""
    End Sub
    Public Sub cargoCombos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()

        Dim consultfamilia As New MySqlCommand("SELECT * FROM familias ORDER BY nombrefamilia", conexionmy)
        Dim consultMedidas As New MySqlCommand("SELECT * FROM unidades ORDER BY unidades", conexionmy)
        Dim consultMedidasNum As New MySqlCommand("SELECT * FROM medidas ORDER BY medida", conexionmy)
        Dim consultColores As New MySqlCommand("SELECT * FROM colores ORDER BY colores", conexionmy)
        Dim consultTipoTejidos As New MySqlCommand("SELECT * FROM tipo_tejido ORDER BY descripcion", conexionmy)
        Dim consultModelos As New MySqlCommand("SELECT * FROM modelos_lona ORDER BY modelos", conexionmy)
        Dim consultTejidos As New MySqlCommand("SELECT * FROM colores_lona ORDER BY coloreslona", conexionmy)

        Dim readermy As MySqlDataReader
        Dim readerMedida As MySqlDataReader
        Dim readerMedidaNum As MySqlDataReader
        Dim readerColores As MySqlDataReader
        Dim readerTipoTejido As MySqlDataReader
        Dim readerModelos As MySqlDataReader
        Dim readerTejidos As MySqlDataReader

        Dim dtable As New DataTable
        Dim dtableMedida As New DataTable
        Dim dtableMedidaNum As New DataTable
        Dim dtableColores As New DataTable
        Dim dtableTipoTejido As New DataTable
        Dim dtableModelos As New DataTable
        Dim dtableTejidos As New DataTable

        Dim bind As New BindingSource()
        Dim bind2 As New BindingSource()
        Dim bind4 As New BindingSource()
        Dim bind5 As New BindingSource()
        Dim bind6 As New BindingSource()
        Dim bind7 As New BindingSource()
        Dim bind8 As New BindingSource()

        readermy = consultfamilia.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        readerMedida = consultMedidas.ExecuteReader
        dtableMedida.Load(readerMedida, LoadOption.OverwriteChanges)

        readerMedidaNum = consultMedidasNum.ExecuteReader
        dtableMedidaNum.Load(readerMedidaNum, LoadOption.OverwriteChanges)

        readerColores = consultColores.ExecuteReader
        dtableColores.Load(readerColores, LoadOption.OverwriteChanges)

        readerTipoTejido = consultTipoTejidos.ExecuteReader
        dtableTipoTejido.Load(readerTipoTejido, LoadOption.OverwriteChanges)

        readerModelos = consultModelos.ExecuteReader
        dtableModelos.Load(readerModelos, LoadOption.OverwriteChanges)

        readerTejidos = consultTejidos.ExecuteReader
        dtableTejidos.Load(readerTejidos, LoadOption.OverwriteChanges)

        bind.DataSource = dtable
        bind2.DataSource = dtableMedida
        bind4.DataSource = dtableMedidaNum
        bind5.DataSource = dtableColores
        bind6.DataSource = dtableTipoTejido
        bind7.DataSource = dtableModelos
        bind8.DataSource = dtableTejidos


        cbFamilias.DataSource = bind
        cbFamilias.DisplayMember = "nombrefamilia"
        cbFamilias.ValueMember = "familiaID"

        cbUnidad.DataSource = bind2
        cbUnidad.DisplayMember = "unidades"
        cbUnidad.ValueMember = "unidadID"

        cbMedidas.DataSource = bind4
        cbMedidas.DisplayMember = "medida"
        cbMedidas.ValueMember = "medidaID"

        cbColores.DataSource = bind5
        cbColores.DisplayMember = "colores"
        cbColores.ValueMember = "colorID"

        cbTejido.DataSource = bind6
        cbTejido.DisplayMember = "descripcion"
        cbTejido.ValueMember = "tejidoID"

        cbModelos.DataSource = bind7
        cbModelos.DisplayMember = "modelos"
        cbModelos.ValueMember = "modeloID"

        cbTejido2.DataSource = bind8
        cbTejido2.DisplayMember = "coloreslona"
        cbTejido2.ValueMember = "colorID"

        conexionmy.Close()

    End Sub
    Public Sub cargoFamilia(famCod As String)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM familias WHERE familiaID = '" + famCod + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        cbFamilias.Text = rdr("nombrefamilia")
        'cbFamilias.ValueMember = rdr("familiaID")
        conexionmy.Close()
    End Sub

    Private Sub cmdDuplicar_Click(sender As Object, e As EventArgs) Handles cmdDuplicar.Click

        Dim respuesta As String
        respuesta = MsgBox("Va a duplicar esta ficha de artículo ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim equiv As String

            Dim cmd As New MySqlCommand
            Dim cmdLastId As New MySqlCommand("SELECT LAST_INSERT_ID()  ", conexionmy)
            Dim numid As Int32


            Dim descuento As String = txDto.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")
            Dim iva As String = txIva.Text
            Dim guardo_iva As String = Replace(iva, ",", ".")
            Dim compra As String = txCompra.Text
            Dim guardo_compra As String = Replace(compra, ",", ".")
            Dim dto As String = txDto.Text
            Dim guardo_dto As String = Replace(dto, ",", ".")
            Dim margenpor As String = txMargenPor.Text
            Dim guardo_margenpor As String = Replace(margenpor, ",", ".")
            Dim margeneur As String = txMargenEuro.Text
            Dim guardo_margeneur As String = Replace(margeneur, ",", ".")
            Dim precio As String = txPrecio.Text
            Dim guardo_precio As String = Replace(precio, ",", ".")
            Dim stock As String = txStock.Text
            Dim guardo_stock As String = Replace(stock, ",", ".")

            Dim stockmin As String = txMinimo.Text
            Dim guardo_stockmin As String = Replace(stockmin, ",", ".")
            Dim stockini As String = txInicial.Text
            Dim guardo_stockini As String = Replace(stockini, ",", ".")



            If ckControlStock.Checked = True Then
                equiv = "S"
            Else
                equiv = "N"
            End If

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO articulos2 (ref_proveedor, referencia, grupoID, proveedorID, descripcion, modelo, tejido, familia, color, colorID, ubicacion, medida, unidad, control_stock, iva, precio_compra, dto_prov, porc_margen, euro_margen, pvp, stock, stock_min, stock_ini) VALUES ('" + txRefProv.Text + "' , '" + txCodigo.Text + "' , '" + txGrupo.Text + "' , '" + txNumPro.Text + "' , '" + txDescripcion.Text + "' , '" + cbModelos.Text + "' , '" + cbTejido2.Text + "' , '" + cbFamilias.SelectedValue.ToString + "' , '" + cbColores.Text + "' , '" + cbColores.SelectedValue.ToString + "' , '" + txUbicacion.Text + "' , '" + cbMedidas.SelectedValue.ToString + "' , '" + cbUnidad.SelectedValue.ToString + "' , '" + equiv + "' , '" + guardo_iva + "' , '" + guardo_compra + "' , '" + guardo_dto + "' , '" + guardo_margenpor + "' , '" + guardo_margeneur + "' , '" + guardo_precio + "' , '" + guardo_stock + "' , '" + guardo_stockmin + "' , '" + guardo_stockini + "')"

            cmd.Connection = conexionmy

            cmd.ExecuteNonQuery()

            numid = cmdLastId.ExecuteScalar()

            'Guardo lotes
            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow
            Dim lincant As String
            Dim guardo_lincant As String


            For Each row In dgLotes.Rows

                lincant = Decimal.Parse(row.Cells(3).Value).ToString("0.00")
                guardo_lincant = Replace(lincant, ",", ".")

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO lotes (referencia, descripcion, lote, stock_inicial, ubicacion) VALUES ('" + row.Cells(0).Value + "', " + row.Cells(1).Value + ", '" + row.Cells(2).Value + "', '" + guardo_lincant + "', '" + row.Cells(4).Value + "')"

                cmdLinea.ExecuteNonQuery()

            Next

            conexionmy.Close()

            TabControl2.SelectTab(0)
            TabControl1.SelectTab(0)
            txCodigo1.Text = ""
            txArticulo.Text = ""
            cargoArticulos()
        End If


    End Sub
    Public Sub verLineaLote()
        Label17.Visible = True
        Label18.Visible = True
        Label19.Visible = True
        Label20.Visible = True
        Label21.Visible = True

        txRefLote.Visible = True
        txDescLote.Visible = True
        txLoteLote.Visible = True
        txStockLote.Visible = True
        txUbicLote.Visible = True
        txCorte.Visible = True

        btGrabarLote.Visible = True

    End Sub
    Public Sub ocultarLineaLote()
        Label17.Visible = False
        Label18.Visible = False
        Label19.Visible = False
        Label20.Visible = False
        Label21.Visible = False

        txRefLote.Visible = False
        txDescLote.Visible = False
        txLoteLote.Visible = False
        txStockLote.Visible = False
        txUbicLote.Visible = False
        txCorte.Visible = False
        btGrabarLote.Visible = False
    End Sub

    Private Sub btGrabarLote_Click(sender As Object, e As EventArgs) Handles btGrabarLote.Click
        If flagModifLote = True Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow
            Dim lincant As String
            Dim guardo_lincant As String

            lincant = Decimal.Parse(txStockLote.Text).ToString("0.00")
            guardo_lincant = Replace(lincant, ",", ".")

            cmdLinea.Connection = conexionmy
            cmdLinea.CommandText = "UPDATE lotes SET referencia = '" + txRefLote.Text + "', descripcion = '" + txDescLote.Text + "', lote = '" + txLoteLote.Text + "', stock = '" + guardo_lincant + "', stock_disp = '" + guardo_lincant + "', ubicacion = '" + txUbicLote.Text + "' WHERE lote = '" + txBakLote.Text + "'"
            cmdLinea.ExecuteNonQuery()

            conexionmy.Close()

            limpiarLineaLote()
            ocultarLineaLote()
            flagModifLote = False
            dgLotes.Rows.Clear()
            cargarLotes()

        Else
            Dim fecha As Date = Format(Today, "dd/MM/yyyy")
            dgLotes.Rows.Add()
            dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = txRefProv.Text
            dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = txDescripcion.Text
            dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = txLoteLote.Text
            dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = txStockLote.Text
            dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = txUbicLote.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow
            Dim lincant As String
            Dim guardo_lincant As String

            lincant = Decimal.Parse(txStockLote.Text).ToString("0.00")
            guardo_lincant = Replace(lincant, ",", ".")

            cmdLinea.Connection = conexionmy
            cmdLinea.CommandText = "INSERT INTO lotes (referencia, descripcion, lote, stock, stock_inicial, stock_disp, fechaentrada, ubicacion) VALUES ('" + txRefLote.Text + "', '" + txDescLote.Text + "', '" + txLoteLote.Text + "', '" + guardo_lincant + "', '" + guardo_lincant + "', '" + guardo_lincant + "', '" + fecha.ToString("yyyy-MM-dd") + "', '" + txUbicLote.Text + "')"

            cmdLinea.ExecuteNonQuery()

            conexionmy.Close()

            limpiarLineaLote()
            ocultarLineaLote()
        End If


    End Sub
    Public Sub limpiarLineaLote()
        txRefLote.Text = ""
        txDescLote.Text = ""
        txLoteLote.Text = ""
        txStockLote.Text = 0
        txUbicLote.Text = ""
        txCorte.Text = 0

    End Sub

    Private Sub txStockLote_Leave(sender As Object, e As EventArgs) Handles txStockLote.Leave
        Dim vStock As String
        vStock = Replace(txStockLote.Text, ".", ",")
        txStockLote.Text = vStock
    End Sub
    Public Sub eliminarLote()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand
        Dim vLoteElim As String
        vLoteElim = dgLotes.CurrentRow.Cells(2).Value.ToString
        cmdLinea.Connection = conexionmy
        cmdLinea.CommandText = "DELETE FROM lotes WHERE lote = '" + vLoteElim + "'"

        cmdLinea.ExecuteNonQuery()

        conexionmy.Close()
        dgLotes.Rows.RemoveAt(dgLotes.CurrentRow.Index)
    End Sub

    Private Sub txCompra_Leave(sender As Object, e As EventArgs) Handles txCompra.Leave
        Dim vCompra As String
        vCompra = Replace(txCompra.Text, ".", ",")
        txCompra.Text = vCompra
    End Sub

    Private Sub txDto_Leave(sender As Object, e As EventArgs) Handles txDto.Leave
        Dim vDto As String
        vDto = Replace(txDto.Text, ".", ",")
        txDto.Text = vDto
    End Sub

    Private Sub txMargenPor_Leave(sender As Object, e As EventArgs) Handles txMargenPor.Leave
        Dim vMargenp As String
        vMargenp = Replace(txMargenPor.Text, ".", ",")
        txMargenPor.Text = vMargenp
    End Sub

    Private Sub txMargenEuro_Leave(sender As Object, e As EventArgs) Handles txMargenEuro.Leave
        Dim vMargeneu As String
        vMargeneu = Replace(txMargenEuro.Text, ".", ",")
        txMargenEuro.Text = vMargeneu
    End Sub

    Private Sub txPrecio_Leave(sender As Object, e As EventArgs) Handles txPrecio.Leave
        Dim vPrecio As String
        vPrecio = Replace(txPrecio.Text, ".", ",")
        txPrecio.Text = vPrecio
    End Sub

    Private Sub txStock_Leave(sender As Object, e As EventArgs) Handles txStock.Leave
        Dim vStock As String
        vStock = Replace(txStock.Text, ".", ",")
        txStock.Text = vStock
        txInicial.Text = vStock
    End Sub

    Private Sub txMinimo_Leave(sender As Object, e As EventArgs) Handles txMinimo.Leave
        Dim vMin As String
        vMin = Replace(txMinimo.Text, ".", ",")
        txMinimo.Text = vMin
    End Sub

    Private Sub dgLotes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLotes.CellDoubleClick
        flagModifLote = True
        verLineaLote()
        txRefLote.Text = dgLotes.CurrentRow.Cells(0).Value
        txDescLote.Text = dgLotes.CurrentRow.Cells(1).Value
        txLoteLote.Text = dgLotes.CurrentRow.Cells(2).Value
        txBakLote.Text = dgLotes.CurrentRow.Cells(2).Value
        txStockLote.Text = dgLotes.CurrentRow.Cells(3).Value
        txUbicLote.Text = dgLotes.CurrentRow.Cells(4).Value
    End Sub
    Private Sub cargarLotes()
        ocultarLineaLote()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT * FROM lotes WHERE referencia = '" + txRefProv.Text + "' ORDER BY loteID", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        rdrLin = cmdLinea.ExecuteReader
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                lineas = lineas + 1
                dgLotes.Rows.Add()
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = rdrLin("referencia")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = rdrLin("descripcion")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = rdrLin("lote")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = rdrLin("stock")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = rdrLin("ubicacion")
            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()
    End Sub

    Private Sub txFiltroLotes_TextChanged(sender As Object, e As EventArgs) Handles txFiltroLotes.TextChanged
        dgLotes.Rows.Clear()

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT * FROM lotes WHERE referencia = '" + txRefProv.Text + "' AND lote LIKE '%" & txFiltroLotes.Text & "%' ORDER BY loteID", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        rdrLin = cmdLinea.ExecuteReader
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                lineas = lineas + 1
                dgLotes.Rows.Add()
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = rdrLin("referencia")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = rdrLin("descripcion")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = rdrLin("lote")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = rdrLin("stock")
                dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = rdrLin("ubicacion")
            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()
    End Sub

    Private Sub txStockLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txStockLote.KeyPress
        If e.KeyChar.ToString() = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub txCorte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txCorte.KeyPress

        If e.KeyChar.ToString() = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub txCorte_KeyDown(sender As Object, e As KeyEventArgs) Handles txCorte.KeyDown
        If e.KeyCode = Keys.Return Then
            txStockLote.Text = CDbl(txStockLote.Text - txCorte.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim conexionmy2 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy2.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT ref_proveedor, proveedorID, familia, pvp, pcr FROM articulos2 WHERE proveedorID = '" + txpro.Text + "' AND familia = '" + txfam.Text + "' ORDER BY proveedorID", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim precom As Decimal
        Dim prepcr As Decimal
        Dim porcen As Decimal
        Dim resultado As Decimal
        Dim referencia As String
        Dim contador As Integer = 0

        Dim rdrLin As MySqlDataReader
        rdrLin = cmdLinea.ExecuteReader
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                'Math.Round(numero, 2, MidpointRounding.AwayFromZero)
                contador = contador + 1
                referencia = rdrLin("ref_proveedor")
                prepcr = rdrLin("pcr")
                porcen = Decimal.Parse(txpor.Text)
                resultado = Decimal.Parse((rdrLin("pcr") * porcen) / 100)
                precom = Math.Round((prepcr + resultado), 3, MidpointRounding.AwayFromZero)

                Dim precio As String = Decimal.Parse(precom.ToString("0.000"))
                Dim guardo_precio As String = Replace(precio, ",", ".")

                'MsgBox(referencia & " " & prepcr & " " & resultado & " " & precom & " " & guardo_precio)

                Dim cmdActualizar As New MySqlCommand("UPDATE articulos2 SET pvp = '" + guardo_precio + "' WHERE ref_proveedor = '" + referencia + "'", conexionmy2)
                cmdActualizar.ExecuteNonQuery()
            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()
        conexionmy2.Close()
        MsgBox("El recálculo de precio se ha realizado correctamente en " & contador & " registros")
        Me.Close()

    End Sub
End Class