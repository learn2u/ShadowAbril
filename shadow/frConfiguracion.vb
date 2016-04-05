Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Xml
Imports System.Configuration

Public Class frConfiguracion
    Private Sub frConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txServidor.Text = vServidor
        txUsuario.Text = vUsuario
        txPassword.Text = vPassword
        txBasedatos.Text = vBasedatos

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        vServidor = txServidor.Text
        vUsuario = txUsuario.Text
        vPassword = txPassword.Text
        vBasedatos = txBasedatos.Text

        Dim documento As XmlDocument
        Dim nodelist As XmlNodeList
        Dim nodo As XmlNode


        documento = New XmlDocument
        documento.Load("conexion.xml")
        nodelist = documento.SelectNodes("conexion")
        For Each nodo In nodelist
            nodo.ChildNodes(0).InnerText = txServidor.Text
            nodo.ChildNodes(1).InnerText = txUsuario.Text
            nodo.ChildNodes(2).InnerText = txPassword.Text
            nodo.ChildNodes(3).InnerText = txBasedatos.Text
        Next

        documento.Save("conexion.xml")

        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)

        Dim connectionStringsSection As ConnectionStringsSection = DirectCast(config.GetSection("connectionStrings"), ConnectionStringsSection)

        connectionStringsSection.ConnectionStrings("Shadow.My.MySettings.tolseproMySQLConnection").ConnectionString = "server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos

        config.Save(ConfigurationSaveMode.Modified, False)

        MsgBox("La conexión a la base de datos se ha actualizado correctamente")


        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class