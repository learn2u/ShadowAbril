Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frVerAgentes
    Private Sub frVerAgentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargoTodosAgentes()
    End Sub
    Public Sub cargoTodosAgentes()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT agente, agenteID FROM agentes", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        dgProvedores.DataSource = bind
        dgProvedores.AutoGenerateColumns = False
        dgProvedores.Columns(0).HeaderText = "AGENTE"
        dgProvedores.Columns(0).Name = "cliente"
        dgProvedores.Columns(1).HeaderText = "CODIGO"
        dgProvedores.Columns(1).Name = "cod"
        dgProvedores.Columns(1).Visible = False
        dgProvedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub txProveedor_TextChanged(sender As Object, e As EventArgs) Handles txProveedor.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT agente, agenteID, FROM agentes WHERE agente LIKE'" & txProveedor.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgProvedores.DataSource = bind
        dgProvedores.AutoGenerateColumns = False
        dgProvedores.Columns(0).HeaderText = "AGENTES"
        dgProvedores.Columns(0).Name = "cliente"

        dgProvedores.Columns(2).HeaderText = "CODIGO"
        dgProvedores.Columns(2).Name = "cod"
        dgProvedores.Columns(2).Visible = False

        dgProvedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub dgProvedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProvedores.CellClick
        frCliente.txAgente.Text = dgProvedores.CurrentRow.Cells("cliente").Value
        frCliente.txIdAgente.Text = dgProvedores.CurrentRow.Cells("cod").Value

        Me.Hide()
    End Sub
End Class