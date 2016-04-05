Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frVerLotes
    Public Shared vReferencia As String
    Public Shared vPrecio As Decimal
    Public Shared vIva As Decimal
    Public Shared vLote As String

    Private Sub frVerLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT referencia,descripcion,lote,stock FROM lotes WHERE referencia = '" + vReferencia + "'", conexionmy)

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
        vLote = dgLotes.CurrentRow.Cells("lote").Value
        If formArti = "P" Then
            If frPresupuestos.flagEdit = "N" Then
                newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                'newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(7).Value = vPrecio
                newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(11).Value = vLote
                newMdiPresupuesto.txIva.Text = vIva
                newMdiPresupuesto.dgLineasPres1.CurrentCell = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4)
                newMdiPresupuesto.dgLineasPres1.BeginEdit(True)

                Me.Close()
            Else
                newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                'newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(7).Value = vPrecio
                newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(11).Value = vLote
                newMdiPresupuesto.txIva.Text = vIva
                newMdiPresupuesto.dgLineasPres2.CurrentCell = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4)
                newMdiPresupuesto.dgLineasPres2.BeginEdit(True)
                newMdiPresupuesto.actualizarLinea()
                newMdiPresupuesto.recalcularTotales()

                Me.Close()
            End If
        End If
        If formArti = "A" Then
            If frAlbaran.flagEdit = "N" Then
                newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                'newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(7).Value = vPrecio
                newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(11).Value = vLote
                newMdiAlbaran.txIva.Text = vIva
                newMdiAlbaran.dgLineasPres1.CurrentCell = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4)
                newMdiAlbaran.dgLineasPres1.BeginEdit(True)

                Me.Close()
            Else
                newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                'newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(7).Value = vPrecio
                newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(11).Value = vLote
                newMdiAlbaran.txIva.Text = vIva
                newMdiAlbaran.dgLineasPres2.CurrentCell = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4)
                newMdiAlbaran.dgLineasPres2.BeginEdit(True)
                newMdiAlbaran.actualizarLinea()
                newMdiAlbaran.recalcularTotales()

                Me.Close()
            End If
        End If

        If formArti = "D" Then
            If frPedido.flagEdit = "N" Then
                newMdiPedido.dgLineasPres1.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                newMdiPedido.dgLineasPres1.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                'newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                newMdiPedido.dgLineasPres1.CurrentRow.Cells(7).Value = vPrecio
                newMdiPedido.dgLineasPres1.CurrentRow.Cells(11).Value = vLote
                newMdiPedido.txIva.Text = vIva
                newMdiPedido.dgLineasPres1.CurrentCell = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4)
                newMdiPedido.dgLineasPres1.BeginEdit(True)

                Me.Close()
            Else
                newMdiPedido.dgLineasPres2.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                newMdiPedido.dgLineasPres2.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                'newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                newMdiPedido.dgLineasPres2.CurrentRow.Cells(7).Value = vPrecio
                newMdiPedido.dgLineasPres2.CurrentRow.Cells(11).Value = vLote
                newMdiPedido.txIva.Text = vIva
                newMdiPedido.dgLineasPres2.CurrentCell = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4)
                newMdiPedido.dgLineasPres2.BeginEdit(True)
                newMdiPedido.actualizarLinea()
                newMdiPedido.recalcularTotales()

                Me.Close()
            End If
        End If
    End Sub

    Private Sub txLote_TextChanged(sender As Object, e As EventArgs) Handles txLote.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT referencia,descripcion,lote,stock FROM lotes WHERE referencia = '" + vReferencia + "' AND lote LIKE '%" & txLote.Text & "%'", conexionmy)

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

    Private Sub txLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txLote.KeyDown
        Dim address As Point = Me.dgLotes.CurrentCellAddress
        If e.KeyCode = Keys.Down Then
            If address.Y < Me.dgLotes.RowCount - 1 Then
                address.Y += 1
            End If

            Me.dgLotes.CurrentCell = Me.dgLotes(address.X, address.Y)
        End If
        If e.KeyCode = Keys.Up Then
            If address.Y <> 0 Then
                address.Y -= 1
            End If

            Me.dgLotes.CurrentCell = Me.dgLotes(address.X, address.Y)
        End If

        If e.KeyCode = Keys.Enter Then
            vLote = dgLotes.CurrentRow.Cells("lote").Value
            If formArti = "P" Then
                If frPresupuestos.flagEdit = "N" Then
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                    'newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(7).Value = vPrecio
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(11).Value = vLote
                    newMdiPresupuesto.txIva.Text = vIva
                    newMdiPresupuesto.dgLineasPres1.CurrentCell = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiPresupuesto.dgLineasPres1.BeginEdit(True)

                    Me.Close()
                Else
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                    'newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(7).Value = vPrecio
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(11).Value = vLote
                    newMdiPresupuesto.txIva.Text = vIva
                    newMdiPresupuesto.dgLineasPres2.CurrentCell = frPresupuestos.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiPresupuesto.dgLineasPres2.BeginEdit(True)
                    newMdiPresupuesto.actualizarLinea()
                    newMdiPresupuesto.recalcularTotales()

                    Me.Close()
                End If
            End If
            If formArti = "A" Then
                If frAlbaran.flagEdit = "N" Then
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                    'newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(7).Value = vPrecio
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(11).Value = vLote
                    newMdiAlbaran.txIva.Text = vIva
                    newMdiAlbaran.dgLineasPres1.CurrentCell = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiAlbaran.dgLineasPres1.BeginEdit(True)

                    Me.Close()
                Else
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                    'newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(7).Value = vPrecio
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(11).Value = vLote
                    newMdiAlbaran.txIva.Text = vIva
                    newMdiAlbaran.dgLineasPres2.CurrentCell = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiAlbaran.dgLineasPres2.BeginEdit(True)
                    newMdiAlbaran.actualizarLinea()
                    newMdiAlbaran.recalcularTotales()

                    Me.Close()
                End If
            End If

            If formArti = "D" Then
                If frPedido.flagEdit = "N" Then
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                    'newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(7).Value = vPrecio
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(11).Value = vLote
                    newMdiPedido.txIva.Text = vIva
                    newMdiPedido.dgLineasPres1.CurrentCell = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiPedido.dgLineasPres1.BeginEdit(True)

                    Me.Close()
                Else
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(2).Value = dgLotes.CurrentRow.Cells("referen").Value
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(3).Value = dgLotes.CurrentRow.Cells("descrip").Value
                    'newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = dgLotes.CurrentRow.Cells("longitud").Value
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(7).Value = vPrecio
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(11).Value = vLote
                    newMdiPedido.txIva.Text = vIva
                    newMdiPedido.dgLineasPres2.CurrentCell = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiPedido.dgLineasPres2.BeginEdit(True)
                    newMdiPedido.actualizarLinea()
                    newMdiPedido.recalcularTotales()

                    Me.Close()
                End If
            End If
        End If
    End Sub
End Class