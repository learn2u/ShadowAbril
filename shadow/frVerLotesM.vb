Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frVerLotesM
    Public Shared vReferencia As String
    Public Shared vPrecio As Decimal
    Public Shared vIva As Decimal
    Public Shared vLote As String
    Private Sub frVerLotesM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarLotes(vReLote)
    End Sub
    Public Sub cargarLotes(lote As String)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT referencia,descripcion,lote,stock FROM lotes WHERE referencia = '" + lote + "'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        dgLotes.DataSource = bind
        dgLotes.AutoGenerateColumns = False
        dgLotes.Columns(0).HeaderText = "REFERENCIA"
        dgLotes.Columns(0).Name = "referen"
        dgLotes.Columns(0).FillWeight = 80
        dgLotes.Columns(0).MinimumWidth = 80
        dgLotes.Columns(1).HeaderText = "DESCRIPCION"
        dgLotes.Columns(1).Name = "descrip"
        dgLotes.Columns(1).FillWeight = 245
        dgLotes.Columns(1).MinimumWidth = 245
        dgLotes.Columns(2).HeaderText = "LOTE"
        dgLotes.Columns(2).Name = "lote"
        dgLotes.Columns(2).FillWeight = 50
        dgLotes.Columns(2).MinimumWidth = 50
        dgLotes.Columns(3).HeaderText = "STOCK"
        dgLotes.Columns(3).Name = "stock"
        dgLotes.Columns(3).FillWeight = 50
        dgLotes.Columns(3).MinimumWidth = 50


        dgLotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub dgLotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLotes.CellClick
        If formArti = "D" Then

            newMdiPedido.dgLineasPres2.CurrentRow.Cells(11).Value = dgLotes.CurrentRow.Cells("lote").Value

            Me.Close()
        End If
        If formArti = "A" Then

            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(11).Value = dgLotes.CurrentRow.Cells("lote").Value

            Me.Close()
        End If

    End Sub
End Class