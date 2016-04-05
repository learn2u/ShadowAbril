Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txIp.Text = vServidor
        txUser.Focus()

    End Sub
    Private Sub cargoRecargo()
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

    Private Sub btConectar_Click(sender As Object, e As EventArgs) Handles btConectar.Click

        vServidor = txIp.Text
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmd As New MySqlCommand

        Dim rdr As MySqlDataReader

        cmd = New MySqlCommand("SELECT * FROM usuarios WHERE usuario = '" + txUser.Text + "' AND password = '" + txContra.Text + "'", conexionmy)

        cmd.CommandType = CommandType.Text
        cmd.Connection = conexionmy
        rdr = cmd.ExecuteReader


        rdr.Read()
        If rdr.HasRows Then
            vUser = rdr("usuario")
            vContra = rdr("password")
            vRol = rdr("rol")
            MsgBox("El login de usuario a sido correcto")
            Me.Close()
        Else
            MsgBox("El usuario no está registrado en la base de datos. Inténtalo otra vez")
            Exit Sub
        End If

        conexionmy.Close()
        cargoRecargo()
    End Sub

    Private Sub txCancelar_Click(sender As Object, e As EventArgs) Handles txCancelar.Click
        Me.Close()
    End Sub
End Class