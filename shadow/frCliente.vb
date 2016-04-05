Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class frCliente
    Public Shared dirEnvios As New List(Of Envios)
    Public flagEditCli As Boolean

    Private Sub frCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectTab(1)
        cmdNuevo.Enabled = True
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = True
        btNuevoEnvio.Enabled = False
        btGrabarEnvio.Enabled = False

        txCif.Focus()

        cargoClientes()

        flagEditCli = False

    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim equiv As String
        Dim exento As String


        If flagEditCli = False Then
            Dim cmd As New MySqlCommand
            Dim cmdLastId As New MySqlCommand("SELECT LAST_INSERT_ID()  ", conexionmy)
            Dim numid As Int32


            Dim descuento As String = txDescuento.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")
            Dim comision As String = txComision.Text
            Dim guardo_comision As String = Replace(comision, ",", ".")



            If chRecargo.Checked = True Then
                equiv = "S"
            Else
                equiv = "N"
            End If

            If chIVA.Checked = True Then
                exento = "S"
            Else
                exento = "N"
            End If

            Dim fecha As Date = txFechaAlta.Text

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO clientes (cif, nombre, nombrecom, direccion, poblacion, cpostal, provincia, pais, telefono, movil, fax, email, url, observaciones, contacto, contacto2, telefcontac1, telefcontac2, agenteID, descuento, comision, recargo, exento, formapago, formatexto, diapago, entidad, cuentabancaria, iban, bic, tipocli, fechaalta, horario, mensaje, libre1, libre2, libre3) VALUES ('" + txCif.Text + "' , '" + txNFiscal.Text + "' , '" + txNComercial.Text + "' , '" + txDomicilio.Text + "' , '" + txPoblacion.Text + "' , '" + txCpostal.Text + "' , '" + cbProvincia.Text + "' , '" + txPais.Text + "' , '" + txTel.Text + "' , '" + txMovil.Text + "' , '" + txFax.Text + "' , '" + txEmail.Text + "' , '" + txWeb.Text + "' , '" + txObservaciones.Text + "' , '" + txContacto1.Text + "' , '" + txContacto2.Text + "' , '" + txTel1.Text + "' , '" + txTel2.Text + "' , '" + txIdAgente.Text + "' , '" + guardo_descuento + "' , '" + guardo_comision + "' , '" + equiv + "' , '" + exento + "' , " + cbFormapago.SelectedValue.ToString + " , '" + cbFormapago.Text + "' , '" + txPago1.Text + "' , '" + txBANCO.Text + "' , '" + txCCC.Text + "' ,'" + txIBAN.Text + "' , '" + txBIC.Text + "' , '" + cbTipocli.Text + "' , '" + fecha.ToString("yyyy-MM-dd") + "' , '" + txHorario.Text + "' , '" + txEmergente.Text + "' , '" + txLibre1.Text + "', '" + txLibre2.Text + "', '" + txLibre3.Text + "')"

            cmd.Connection = conexionmy

            cmd.ExecuteNonQuery()

            numid = cmdLastId.ExecuteScalar()
            'MsgBox(numid)
            If dirEnvios.Count > 0 Then
                For Each itemenvio As Envios In dirEnvios
                    cmd.CommandText = "INSERT INTO envios (clienteID, domicilio, cpostal, localidad, provincia) VALUES ('" + numid.ToString + "', '" + itemenvio.domicilio + "', '" + itemenvio.cpostal + "', '" + itemenvio.poblacion + "', '" + itemenvio.provincia + "')"
                    cmd.Connection = conexionmy
                    cmd.ExecuteNonQuery()
                Next
            Else
                cmd.CommandText = "INSERT INTO envios (clienteID, domicilio, cpostal, localidad, provincia) VALUES ('" + numid.ToString + "', '" + txDomicilio.Text + "', '" + txCpostal.Text + "', '" + txPoblacion.Text + "', '" + cbProvincia.Text + "')"
                cmd.Connection = conexionmy
                cmd.ExecuteNonQuery()
            End If

            conexionmy.Close()
            Me.Hide()
        Else
            Dim cmdEnvio As New MySqlCommand
            Dim descuento As String = txDescuento.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")
            Dim comision As String = txComision.Text
            Dim guardo_comision As String = Replace(comision, ",", ".")

            If chRecargo.Checked = True Then
                equiv = "S"
            Else
                equiv = "N"
            End If

            If chIVA.Checked = True Then
                exento = "S"
            Else
                exento = "N"
            End If

            Dim fecha As Date = txFechaAlta.Text

            Dim cmdActualizar As New MySqlCommand("UPDATE clientes SET nombre = '" + txNFiscal.Text + "', 
                                                cif = '" + txCif.Text + "',
                                                nombrecom = '" + txNComercial.Text + "', 
                                                direccion = '" + txDomicilio.Text + "',
                                                poblacion= '" + txPoblacion.Text + "',
                                                cpostal = '" + txCpostal.Text + "',
                                                provincia = '" + cbProvincia.Text + "',
                                                pais = '" + txPais.Text + "',
                                                telefono = '" + txTel.Text + "',
                                                movil = '" + txMovil.Text + "',
                                                fax = '" + txFax.Text + "',
                                                email = '" + txEmail.Text + "',
                                                url = '" + txWeb.Text + "',
                                                observaciones = '" + txObservaciones.Text + "',
                                                contacto = '" + txContacto1.Text + "',
                                                contacto2 = '" + txContacto2.Text + "',
                                                telefcontac1 = '" + txTel1.Text + "',
                                                telefcontac2 = '" + txTel2.Text + "',
                                                agenteID = '" + txIdAgente.Text + "',
                                                descuento = '" + guardo_descuento + "',
                                                comision = '" + guardo_comision + "',
                                                exento = '" + exento + "',
                                                recargo = '" + equiv + "',
                                                formapago = '" + cbFormapago.SelectedValue.ToString + "',
                                                formatexto = '" + cbFormapago.Text + "',
                                                diapago = '" + txPago1.Text + "',
                                                entidad = '" + txBANCO.Text + "',
                                                cuentabancaria = '" + txCCC.Text + "',
                                                iban = '" + txIBAN.Text + "',
                                                bic = '" + txBIC.Text + "',
                                                fechaalta = '" + fecha.ToString("yyyy-MM-dd") + "',
                                                horario = '" + txHorario.Text + "',
                                                mensaje = '" + txEmergente.Text + "',
                                                libre1 = '" + txLibre1.Text + "',
                                                libre2 = '" + txLibre2.Text + "',
                                                libre3 = '" + txLibre3.Text + "',
                                                tipocli = '" + cbTipocli.Text + "' WHERE clienteID = '" + txCodigo.Text + "'", conexionmy)
            cmdActualizar.ExecuteNonQuery()
            If dirEnvios.Count > 0 Then
                For Each itemenvio As Envios In dirEnvios
                    cmdEnvio.CommandText = "INSERT INTO envios (clienteID, domicilio, cpostal, localidad, provincia) VALUES ('" + txCodigo.Text + "', '" + itemenvio.domicilio + "', '" + itemenvio.cpostal + "', '" + itemenvio.poblacion + "', '" + itemenvio.provincia + "')"
                    cmdEnvio.Connection = conexionmy
                    cmdEnvio.ExecuteNonQuery()
                Next
            Else
                cmdEnvio.CommandText = "INSERT INTO envios (clienteID, domicilio, cpostal, localidad, provincia) VALUES ('" + txCodigo.Text + "', '" + txDomicilio.Text + "', '" + txCpostal.Text + "', '" + txPoblacion.Text + "', '" + cbProvincia.Text + "')"
                cmdEnvio.Connection = conexionmy
                cmdEnvio.ExecuteNonQuery()
            End If
            MsgBox("Los datos del cliente se han actualizado correctamente")
            flagEditCli = False
            'Me.Close()
        End If
        TabControl2.SelectTab(0)
        TabControl1.SelectTab(0)
        cargoClientes()


    End Sub

    Private Sub btNuevoEnvio_Click(sender As Object, e As EventArgs) Handles btNuevoEnvio.Click
        txDirEnvio.Text = ""
        txPobEnvio.Text = ""
        txPostEnvio.Text = ""
        cbEnvioProv.Text = "Sevilla"
        txDirEnvio.Focus()
    End Sub

    Private Sub btGrabarEnvio_Click(sender As Object, e As EventArgs) Handles btGrabarEnvio.Click
        dirEnvios.Add(New Envios() With {.domicilio = txDirEnvio.Text, .cpostal = txPostEnvio.Text, .poblacion = txPobEnvio.Text, .provincia = cbEnvioProv.Text})
        txDirEnvio.Text = ""
        txPostEnvio.Text = ""
        txPobEnvio.Text = ""
        cbEnvioProv.Text = "Sevilla"
        txDirEnvio.Focus()

    End Sub
    Public Sub cargoDatos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM clientes WHERE clienteID = '" + txCodigo.Text + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        txCif.Text = rdr("cif")
        txNFiscal.Text = rdr("nombre")
        txNComercial.Text = rdr("nombrecom")
        txDomicilio.Text = rdr("direccion")
        txPoblacion.Text = rdr("poblacion")
        txCpostal.Text = rdr("cpostal")
        cbProvincia.Text = rdr("provincia")
        txPais.Text = rdr("pais")
        txTel.Text = rdr("telefono")
        txMovil.Text = rdr("movil")
        txFax.Text = rdr("fax")
        txEmail.Text = rdr("email")
        txWeb.Text = rdr("url")
        txObservaciones.Text = rdr("observaciones")
        txContacto1.Text = rdr("contacto")
        txContacto2.Text = rdr("contacto2")
        txTel1.Text = rdr("telefcontac1")
        txTel2.Text = rdr("telefcontac2")
        txDescuento.Text = rdr("descuento")
        txIdAgente.Text = rdr("agenteID")
        cargoAgente()
        txComision.Text = rdr("comision")
        If rdr("exento") = "N" Then
            chIVA.Checked = False
        Else
            chIVA.Checked = True
        End If
        If rdr("recargo") = "N" Then
            chRecargo.Checked = False
        Else
            chRecargo.Checked = True
        End If
        cargoFormaPago()
        Dim vForma As Integer = 0
        vForma = rdr("formapago")
        Select Case vForma
            Case 1
                cbFormapago.SelectedIndex = 0
            Case 2
                cbFormapago.SelectedIndex = 1
            Case 3
                cbFormapago.SelectedIndex = 2
            Case 4
                cbFormapago.SelectedIndex = 3
            Case 5
                cbFormapago.SelectedIndex = 4
            Case 6
                cbFormapago.SelectedIndex = 5
            Case 7
                cbFormapago.SelectedIndex = 6
            Case 8
                cbFormapago.SelectedIndex = 7
            Case 9
                cbFormapago.SelectedIndex = 8
        End Select

        txPago1.Text = rdr("diapago")
        txBANCO.Text = rdr("entidad")
        txCCC.Text = rdr("cuentabancaria")
        txIBAN.Text = rdr("iban")
        txBIC.Text = rdr("bic")
        txFechaAlta.Text = rdr("fechaalta")
        txHorario.Text = rdr("horario")
        txEmergente.Text = rdr("mensaje")
        txLibre1.Text = rdr("libre1")
        txLibre2.Text = rdr("libre2")
        txLibre3.Text = rdr("libre3")
        cbTipocli.Text = rdr("tipocli")

        conexionmy.Close()
    End Sub
    Public Sub limpiarFormulario()
        txCodigo.Text = ""
        txCif.Text = ""
        txNFiscal.Text = ""
        txNComercial.Text = ""
        txDomicilio.Text = ""
        txPoblacion.Text = ""
        txCpostal.Text = ""
        cbProvincia.Text = "Sevilla"
        txPais.Text = ""
        txTel.Text = ""
        txMovil.Text = ""
        txFax.Text = ""
        txEmail.Text = ""
        txWeb.Text = ""
        txObservaciones.Text = ""
        txContacto1.Text = ""
        txContacto2.Text = ""
        txTel1.Text = ""
        txTel2.Text = ""
        txDescuento.Text = 0.00
        txComision.Text = 0.00
        txAgente.Text = ""
        chIVA.Checked = False
        chRecargo.Checked = False

        txPago1.Text = ""

        txBANCO.Text = ""
        txCCC.Text = ""
        txIBAN.Text = ""
        txBIC.Text = ""
        txFechaAlta.Text = ""
        txHorario.Text = ""
        txEmergente.Text = ""
        txLibre1.Text = ""
        txLibre2.Text = ""
        txLibre3.Text = ""
        cbTipocli.Text = ""

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        limpiarFormulario()
        cmdNuevo.Enabled = True
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = True
        btNuevoEnvio.Enabled = False
        btGrabarEnvio.Enabled = False
        TabControl2.SelectTab(0)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        limpiarFormulario()
        cmdNuevo.Enabled = False
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        btNuevoEnvio.Enabled = True
        btGrabarEnvio.Enabled = True
        txCif.Focus()
    End Sub
    Public Sub cargoClientes()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT * FROM provincias ORDER BY provincia", conexionmy)
        Dim consultacli As New MySqlCommand("SELECT clienteID, cif, nombre, telefono FROM clientes ORDER BY nombre", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim readercli As MySqlDataReader
        Dim dtablecli As New DataTable
        Dim bind As New BindingSource()
        Dim bind2 As New BindingSource()
        Dim bind3 As New BindingSource()

        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        readercli = consultacli.ExecuteReader
        dtablecli.Load(readercli, LoadOption.OverwriteChanges)

        bind.DataSource = dtable
        bind2.DataSource = dtable
        bind3.DataSource = dtablecli

        dgClientes.DataSource = bind3
        dgClientes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgClientes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgClientes.Columns(0).HeaderText = "CODIGO"
        dgClientes.Columns(0).Name = "Column1"
        dgClientes.Columns(0).FillWeight = 100
        dgClientes.Columns(0).MinimumWidth = 100
        dgClientes.Columns(1).HeaderText = "CIF"
        dgClientes.Columns(1).Name = "Column2"
        dgClientes.Columns(1).FillWeight = 100
        dgClientes.Columns(1).MinimumWidth = 100
        dgClientes.Columns(2).HeaderText = "CLIENTE"
        dgClientes.Columns(2).Name = "Column3"
        dgClientes.Columns(2).FillWeight = 450
        dgClientes.Columns(2).MinimumWidth = 450
        dgClientes.Columns(3).HeaderText = "TELEFONO"
        dgClientes.Columns(3).Name = "Column4"
        'gridcliente.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridcliente.Columns(4).Visible = False
        'gridcliente.Columns(5).Visible = False
        'gridcliente.Columns(6).Visible = False
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgClientes.Visible = True


        cbProvincia.DataSource = bind
        cbProvincia.DisplayMember = "provincia"

        cbEnvioProv.DataSource = bind2
        cbEnvioProv.DisplayMember = "provincia"

        conexionmy.Close()
    End Sub

    Private Sub cmdDirEnvio_Click(sender As Object, e As EventArgs) Handles cmdDirEnvio.Click

    End Sub

    Private Sub cmdMostrarAgente_Click(sender As Object, e As EventArgs) Handles cmdMostrarAgente.Click
        frVerAgentes.Show()
    End Sub
    Public Sub cargoFormaPago()
        cbFormapago.ResetText()

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


        cbFormapago.DataSource = ds.Tables(0)
        cbFormapago.DisplayMember = ds.Tables(0).Columns("formapago").ToString
        cbFormapago.ValueMember = "formaID"

        cn.Close()
    End Sub
    Public Sub cargoAgente()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM agentes WHERE agenteID = '" + txIdAgente.Text + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        txAgente.Text = rdr("agente")

        conexionmy.Close()

    End Sub

    Private Sub dgClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClientes.CellDoubleClick
        txCodigo.Text = dgClientes.CurrentRow.Cells("column1").Value.ToString
        TabControl1.SelectTab(1)
        cargoDatos()
        cmdNuevo.Enabled = False
        cmdGuardar.Enabled = True


        flagEditCli = True
    End Sub
End Class