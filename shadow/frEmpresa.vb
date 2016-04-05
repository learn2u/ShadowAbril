Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class frEmpresa
    Public Shared editEmpresa As Boolean = False

    Private Sub frEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btNueva.Enabled = False

        editEmpresa = False

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM configuracion WHERE empresaID = 1", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()

        txNumero.Text = rdr("empresaID")
        txRazon.Text = rdr("razon")
        txDescripcion.Text = rdr("descripcion")
        txCif.Text = rdr("cif")
        txDomicilio.Text = rdr("domicilio")
        txCpostal.Text = rdr("cpostal")
        txPoblacion.Text = rdr("poblacion")
        txProvincia.Text = rdr("provincia")
        txTel1.Text = rdr("telefono")
        txTel2.Text = rdr("telefono2")
        txMovil.Text = rdr("telefono3")
        txFax.Text = rdr("fax")
        txEmail.Text = rdr("email")
        txWeb.Text = rdr("web")
        txPorciva.Text = rdr("iva")
        txPorcrec.Text = rdr("recargo")
        txPedido1.Text = rdr("num_pedido")
        txAlbaran1.Text = rdr("num_albaran")
        txPresupuesto1.Text = rdr("num_presupuesto")
        txFactura1.Text = rdr("num_factura")
        txAbono1.Text = rdr("num_abono")
        txEntrada1.Text = rdr("num_entrada")

        txPedido2.Text = rdr("num_pedido_2")
        txAlbaran2.Text = rdr("num_albaran_2")
        txPresupuesto2.Text = rdr("num_presupuesto_2")
        txFactura2.Text = rdr("num_factura_2")
        txAbono2.Text = rdr("num_abono_2")
        txEntrada2.Text = rdr("num_entrada_2")

        txServidor.Text = rdr("servidor")
        txUsuario.Text = rdr("usuario")
        txPassword.Text = rdr("password")
        txBasedatos.Text = rdr("basedatos")


        conexionmy.Close()

    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click

        editEmpresa = True

        If editEmpresa = False Then

        Else
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET razon = '" + txRazon.Text + "', 
                                                descripcion = '" + txDescripcion.Text + "', 
                                                cif = '" + txCif.Text + "',
                                                domicilio = '" + txDomicilio.Text + "',
                                                cpostal = '" + txCpostal.Text + "',
                                                poblacion = '" + txPoblacion.Text + "',
                                                provincia = '" + txProvincia.Text + "',
                                                telefono = '" + txTel1.Text + "',
                                                num_pedido = '" + txPedido1.Text + "',
                                                num_albaran = '" + txAlbaran1.Text + "',
                                                num_presupuesto = '" + txPresupuesto1.Text + "',
                                                num_factura = '" + txFactura1.Text + "',
                                                num_abono = '" + txAbono1.Text + "',
                                                num_entrada = '" + txEntrada1.Text + "',
                                                num_pedido_2 = '" + txPedido2.Text + "',
                                                num_albaran_2 = '" + txAlbaran2.Text + "',
                                                num_presupuesto_2 = '" + txPresupuesto2.Text + "',
                                                num_factura_2 = '" + txFactura2.Text + "',
                                                num_abono_2 = '" + txAbono2.Text + "',
                                                num_entrada_2 = '" + txEntrada2.Text + "',
                                                servidor = '" + txServidor.Text + "',
                                                usuario = '" + txUsuario.Text + "',
                                                password = '" + txPassword.Text + "',
                                                basedatos = '" + txBasedatos.Text + "',
                                                iva = '" + txPorciva.Text + "',
                                                recargo = '" + txPorcrec.Text + "',
                                                telefono3 = '" + txMovil.Text + "',
                                                fax = '" + txFax.Text + "',
                                                email = '" + txEmail.Text + "',
                                                web = '" + txWeb.Text + "',
                                                telefono2 = '" + txTel2.Text + "' WHERE empresaID = '" + txNumero.Text + "'", conexionmy)
            cmdActualizar.ExecuteNonQuery()
            MsgBox("Los datos de configuración se han actualizado correctamente")
            Me.Close()
        End If


    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        limpiarFormulario()
        Me.Close()

    End Sub
    Public Sub limpiarFormulario()

    End Sub

    Private Sub btNueva_Click(sender As Object, e As EventArgs) Handles btNueva.Click
        limpiarFormulario()
        txRazon.Focus()

    End Sub
    Public Sub cargoDatos()

    End Sub
End Class