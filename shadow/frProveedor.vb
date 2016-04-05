Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Public Class frProveedor
    Public flagEditPro As Boolean

    Private Sub frProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectTab(1)
        cmdNuevo.Enabled = True
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = True


        txCif.Focus()

        cargoProveedores()

        flagEditPro = False
    End Sub
    Public Sub cargoProveedores()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT * FROM provincias ORDER BY provincia", conexionmy)
        Dim consultacli As New MySqlCommand("SELECT proveedorID, cif, nombre, telefono FROM proveedores ORDER BY nombre", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim readercli As MySqlDataReader
        Dim dtablecli As New DataTable
        Dim bind As New BindingSource()

        Dim bind3 As New BindingSource()

        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        readercli = consultacli.ExecuteReader
        dtablecli.Load(readercli, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

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
        dgClientes.Columns(2).HeaderText = "PROVEEDOR"
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



        conexionmy.Close()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim tipo As String
        Dim exento As String
        Dim recargo As String


        If flagEditPro = False Then
            Dim cmd As New MySqlCommand
            Dim cmdLastId As New MySqlCommand("SELECT LAST_INSERT_ID()  ", conexionmy)
            Dim numid As Int32


            Dim descuento As String = txDescuento.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")


            If ckTipo.Checked = True Then
                tipo = "P"
            Else
                tipo = "T"
            End If

            If chIVA.Checked = True Then
                exento = "S"
            Else
                exento = "N"
            End If

            If chRecargo.Checked = True Then
                recargo = "S"
            Else
                recargo = "N"
            End If

            Dim fecha As Date = txFechaAlta.Text

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "INSERT INTO proveedores (cif, nombre, nombrecom, direccion, poblacion, cpostal, provincia, pais, telefono, movil, fax, email, url, observaciones, contacto, contacto2, telefcontac1, telefcontac2, descuento, recargo, exento, formapago, formatexto, diapago, entidad, cuentabancaria, iban, bic, fechaalta, horario, mensaje, libre1, libre2, libre3, tipo) VALUES ('" + txCif.Text + "' , '" + txNFiscal.Text + "' , '" + txNComercial.Text + "' , '" + txDomicilio.Text + "' , '" + txPoblacion.Text + "' , '" + txCpostal.Text + "' , '" + cbProvincia.Text + "' , '" + txPais.Text + "' , '" + txTel.Text + "' , '" + txMovil.Text + "' , '" + txFax.Text + "' , '" + txEmail.Text + "' , '" + txWeb.Text + "' , '" + txObservaciones.Text + "' , '" + txContacto1.Text + "' , '" + txContacto2.Text + "' , '" + txTel1.Text + "' , '" + txTel2.Text + "' , '" + guardo_descuento + "' , '" + recargo + "' , '" + exento + "' , " + cbFormapago.SelectedValue.ToString + " , '" + cbFormapago.Text + "' , '" + txPago1.Text + "' , '" + txBanco.Text + "' , '" + txCCC.Text + "' ,'" + txIban.Text + "' , '" + txBic.Text + "' , '" + fecha.ToString("yyyy-MM-dd") + "' , '" + txHorario.Text + "' , '" + txEmergente.Text + "' , '" + txLibre1.Text + "', '" + txLibre2.Text + "', '" + txLibre3.Text + "', '" + tipo + "')"

            cmd.Connection = conexionmy

            cmd.ExecuteNonQuery()

            numid = cmdLastId.ExecuteScalar()
            'MsgBox(numid)


            conexionmy.Close()
            'Me.Hide()
        Else
            Dim cmdEnvio As New MySqlCommand
            Dim descuento As String = txDescuento.Text
            Dim guardo_descuento As String = Replace(descuento, ",", ".")


            If ckTipo.Checked = True Then
                tipo = "P"
            Else
                tipo = "T"
            End If

            If chIVA.Checked = True Then
                exento = "S"
            Else
                exento = "N"
            End If

            If chRecargo.Checked = True Then
                recargo = "S"
            Else
                recargo = "N"
            End If

            Dim fecha As Date = txFechaAlta.Text

            Dim cmdActualizar As New MySqlCommand("UPDATE proveedores SET nombre = '" + txNFiscal.Text + "', 
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
                                                descuento = '" + guardo_descuento + "',
                                                exento = '" + exento + "',
                                                recargo = '" + recargo + "',
                                                formapago = '" + cbFormapago.SelectedValue.ToString + "',
                                                formatexto = '" + cbFormapago.Text + "',
                                                diapago = '" + txPago1.Text + "',
                                                entidad = '" + txBanco.Text + "',
                                                cuentabancaria = '" + txCCC.Text + "',
                                                iban = '" + txIban.Text + "',
                                                bic = '" + txBic.Text + "',
                                                fechaalta = '" + fecha + "',
                                                horario = '" + txHorario.Text + "',
                                                mensaje = '" + txEmergente.Text + "',
                                                libre1 = '" + txLibre1.Text + "',
                                                libre2 = '" + txLibre2.Text + "',
                                                libre3 = '" + txLibre3.Text + "',
                                                tipo = '" + tipo + "' WHERE proveedorID = '" + txCodigo.Text + "'", conexionmy)
            cmdActualizar.ExecuteNonQuery()

            MsgBox("Los datos del proveedor se han actualizado correctamente")
            flagEditPro = False
            'Me.Close()
        End If
        TabControl2.SelectTab(0)
        TabControl1.SelectTab(0)
        cargoProveedores()

    End Sub
    Public Sub cargoDatos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader
        cmd = New MySqlCommand("SELECT * FROM proveedores WHERE proveedorID = '" + txCodigo.Text + "'", conexionmy)

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
        txBanco.Text = rdr("entidad")
        txCCC.Text = rdr("cuentabancaria")
        txIban.Text = rdr("iban")
        txBic.Text = rdr("bic")
        txFechaAlta.Text = rdr("fechaalta")
        txHorario.Text = rdr("horario")
        txEmergente.Text = rdr("mensaje")
        txLibre1.Text = rdr("libre1")
        txLibre2.Text = rdr("libre2")
        txLibre3.Text = rdr("libre3")
        If rdr("tipo") = "P" Then
            ckTipo.Checked = True
        Else
            ckTipo.Checked = False
        End If

        conexionmy.Close()
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

        chIVA.Checked = False
        chRecargo.Checked = False

        txPago1.Text = ""

        txBanco.Text = ""
        txCCC.Text = ""
        txIban.Text = ""
        txBic.Text = ""
        txFechaAlta.Text = ""
        txHorario.Text = ""
        txEmergente.Text = ""
        txLibre1.Text = ""
        txLibre2.Text = ""
        txLibre3.Text = ""
        ckTipo.Checked = True

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        limpiarFormulario()
        cmdNuevo.Enabled = True
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = True

        TabControl2.SelectTab(0)
        TabControl1.SelectTab(0)
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        limpiarFormulario()
        cmdNuevo.Enabled = False
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cargoFormaPago()
        txCif.Focus()
    End Sub
    Private Sub dgClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClientes.CellDoubleClick
        txCodigo.Text = dgClientes.CurrentRow.Cells("column1").Value.ToString
        TabControl1.SelectTab(1)
        cargoDatos()
        cmdNuevo.Enabled = False

        flagEditPro = True
    End Sub
End Class