Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frVerArticulosPProv
    Private Sub frVerArticulosPProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT articulos2.ref_proveedor,articulos2.descripcion,proveedores.nombre, articulos2.stock, articulos2.precio_compra, proveedores.proveedorID, articulos2.stock_disp, articulos2.iva, articulos2.medidaID, articulos2.familia FROM articulos2 INNER JOIN proveedores ON articulos2.proveedorID=proveedores.proveedorID", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader


        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable


        dgArticulos.DataSource = bind
        dgArticulos.AutoGenerateColumns = False
        dgArticulos.Columns(0).HeaderText = "REF PROV"
        dgArticulos.Columns(0).Name = "refpro"
        dgArticulos.Columns(0).FillWeight = 80
        dgArticulos.Columns(0).MinimumWidth = 80
        dgArticulos.Columns(1).HeaderText = "DESCRIPCION"
        dgArticulos.Columns(1).Name = "descrip"
        dgArticulos.Columns(1).FillWeight = 200
        dgArticulos.Columns(1).MinimumWidth = 200
        dgArticulos.Columns(2).HeaderText = "PROVEEDOR"
        dgArticulos.Columns(2).Name = "prov"
        dgArticulos.Columns(2).FillWeight = 180
        dgArticulos.Columns(2).MinimumWidth = 180
        dgArticulos.Columns(3).HeaderText = "STOCK"
        dgArticulos.Columns(3).Name = "stock"
        dgArticulos.Columns(3).FillWeight = 50
        dgArticulos.Columns(3).MinimumWidth = 50
        dgArticulos.Columns(4).HeaderText = "PREC.COMPRA"
        dgArticulos.Columns(4).Name = "prec"
        dgArticulos.Columns(4).FillWeight = 50
        dgArticulos.Columns(4).MinimumWidth = 50
        dgArticulos.Columns(5).HeaderText = "ID"
        dgArticulos.Columns(5).Name = "provID"
        dgArticulos.Columns(5).Visible = False
        dgArticulos.Columns(6).HeaderText = "DISP"
        dgArticulos.Columns(6).Name = "disponible"
        dgArticulos.Columns(6).Visible = False
        dgArticulos.Columns(7).HeaderText = "IVA"
        dgArticulos.Columns(7).Name = "porciva"
        dgArticulos.Columns(7).Visible = False
        dgArticulos.Columns(8).HeaderText = "MEDIDA"
        dgArticulos.Columns(8).Name = "longitud"
        dgArticulos.Columns(8).Visible = False
        dgArticulos.Columns(9).HeaderText = "FAMILIA"
        dgArticulos.Columns(9).Name = "fam"
        dgArticulos.Columns(9).Visible = False


        dgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub txCodigo_TextChanged(sender As Object, e As EventArgs) Handles txCodigo.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT articulos2.ref_proveedor,articulos2.descripcion,proveedores.nombre, articulos2.stock, articulos2.precio_compra, proveedores.proveedorID, articulos2.stock_disp, articulos2.iva, articulos2.medidaID, articulos2.familia FROM articulos2 INNER JOIN proveedores ON articulos2.proveedorID=proveedores.proveedorID WHERE ref_proveedor LIKE'" & txCodigo.Text & "%'", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgArticulos.DataSource = bind
        dgArticulos.AutoGenerateColumns = False
        dgArticulos.Columns(0).HeaderText = "REF PROV"
        dgArticulos.Columns(0).Name = "refpro"
        dgArticulos.Columns(0).FillWeight = 80
        dgArticulos.Columns(0).MinimumWidth = 80
        dgArticulos.Columns(1).HeaderText = "DESCRIPCION"
        dgArticulos.Columns(1).Name = "descrip"
        dgArticulos.Columns(1).FillWeight = 200
        dgArticulos.Columns(1).MinimumWidth = 200
        dgArticulos.Columns(2).HeaderText = "PROVEEDOR"
        dgArticulos.Columns(2).Name = "prov"
        dgArticulos.Columns(2).FillWeight = 180
        dgArticulos.Columns(2).MinimumWidth = 180
        dgArticulos.Columns(3).HeaderText = "STOCK"
        dgArticulos.Columns(3).Name = "stock"
        dgArticulos.Columns(3).FillWeight = 50
        dgArticulos.Columns(3).MinimumWidth = 50
        dgArticulos.Columns(4).HeaderText = "PREC.COMPRA"
        dgArticulos.Columns(4).Name = "prec"
        dgArticulos.Columns(4).FillWeight = 50
        dgArticulos.Columns(4).MinimumWidth = 50
        dgArticulos.Columns(5).HeaderText = "ID"
        dgArticulos.Columns(5).Name = "provID"
        dgArticulos.Columns(5).Visible = False
        dgArticulos.Columns(6).HeaderText = "DISP"
        dgArticulos.Columns(6).Name = "disponible"
        dgArticulos.Columns(6).Visible = False
        dgArticulos.Columns(7).HeaderText = "IVA"
        dgArticulos.Columns(7).Name = "porciva"
        dgArticulos.Columns(7).Visible = False
        dgArticulos.Columns(8).HeaderText = "MEDIDA"
        dgArticulos.Columns(8).Name = "longitud"
        dgArticulos.Columns(8).Visible = False
        dgArticulos.Columns(9).HeaderText = "FAMILIA"
        dgArticulos.Columns(9).Name = "fam"
        dgArticulos.Columns(9).Visible = False
        dgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        conexionmy.Close()
    End Sub

    Private Sub txArticulo_TextChanged(sender As Object, e As EventArgs) Handles txArticulo.TextChanged
        If txArticulo.Text <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            Dim vFiltro As String
            vFiltro = txArticulo.Text
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT articulos2.ref_proveedor,articulos2.descripcion,proveedores.nombre, articulos2.stock, articulos2.precio_compra, proveedores.proveedorID, articulos2.stock_disp, articulos2.iva, articulos2.medidaID, articulos2.familia FROM articulos2 INNER JOIN proveedores ON articulos2.proveedorID=proveedores.proveedorID WHERE descripcion LIKE'" & vFiltro & "%'", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()


            readermy = consultamy.ExecuteReader

            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable


            dgArticulos.DataSource = bind
            dgArticulos.AutoGenerateColumns = False
            dgArticulos.Columns(0).HeaderText = "REF PROV"
            dgArticulos.Columns(0).Name = "refpro"
            dgArticulos.Columns(0).FillWeight = 80
            dgArticulos.Columns(0).MinimumWidth = 80
            dgArticulos.Columns(1).HeaderText = "DESCRIPCION"
            dgArticulos.Columns(1).Name = "descrip"
            dgArticulos.Columns(1).FillWeight = 200
            dgArticulos.Columns(1).MinimumWidth = 200
            dgArticulos.Columns(2).HeaderText = "PROVEEDOR"
            dgArticulos.Columns(2).Name = "prov"
            dgArticulos.Columns(2).FillWeight = 180
            dgArticulos.Columns(2).MinimumWidth = 180
            dgArticulos.Columns(3).HeaderText = "STOCK"
            dgArticulos.Columns(3).Name = "stock"
            dgArticulos.Columns(3).FillWeight = 50
            dgArticulos.Columns(3).MinimumWidth = 50
            dgArticulos.Columns(4).HeaderText = "PREC.COMPRA"
            dgArticulos.Columns(4).Name = "prec"
            dgArticulos.Columns(4).FillWeight = 50
            dgArticulos.Columns(4).MinimumWidth = 50
            dgArticulos.Columns(5).HeaderText = "ID"
            dgArticulos.Columns(5).Name = "provID"
            dgArticulos.Columns(5).Visible = False
            dgArticulos.Columns(6).HeaderText = "DISP"
            dgArticulos.Columns(6).Name = "disponible"
            dgArticulos.Columns(6).Visible = False
            dgArticulos.Columns(7).HeaderText = "IVA"
            dgArticulos.Columns(7).Name = "porciva"
            dgArticulos.Columns(7).Visible = False
            dgArticulos.Columns(8).HeaderText = "MEDIDA"
            dgArticulos.Columns(8).Name = "longitud"
            dgArticulos.Columns(8).Visible = False
            dgArticulos.Columns(9).HeaderText = "FAMILIA"
            dgArticulos.Columns(9).Name = "fam"
            dgArticulos.Columns(9).Visible = False

            dgArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            conexionmy.Close()
        Else
        End If
    End Sub

    Private Sub dgArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgArticulos.CellDoubleClick
        If dgArticulos.CurrentRow.Cells("fam").Value = 7 Or dgArticulos.CurrentRow.Cells("fam").Value = 4 And formArti <> "P" Then
            frVerLotes.vReferencia = dgArticulos.CurrentRow.Cells("refpro").Value
            frVerLotes.vPrecio = dgArticulos.CurrentRow.Cells("prec").Value
            frVerLotes.vIva = dgArticulos.CurrentRow.Cells("porciva").Value
            If dgArticulos.CurrentRow.Cells("longitud").Value = "" Then
                frVerLotes.vLongitud = 0
            Else
                frVerLotes.vLongitud = dgArticulos.CurrentRow.Cells("longitud").Value
            End If

            frVerLotes.Show()
        Else
            If formArti = "R" Then
                If frPedidoProv.flagEdit = "N" Then
                    newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value
                    Else
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiPedidoProv.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiPedidoProv.dgLineasPres1.CurrentCell = newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiPedidoProv.dgLineasPres1.BeginEdit(True)
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                Else
                    newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value
                    Else
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiPedidoProv.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiPedidoProv.dgLineasPres2.CurrentCell = newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiPedidoProv.dgLineasPres2.BeginEdit(True)
                    newMdiPedidoProv.actualizarLinea()
                    newMdiPedidoProv.recalcularTotales()
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txArticulo.KeyDown
        Dim address As Point = Me.dgArticulos.CurrentCellAddress
        If e.KeyCode = Keys.Down Then
            If address.Y < Me.dgArticulos.RowCount - 1 Then
                address.Y += 1
            End If

            Me.dgArticulos.CurrentCell = Me.dgArticulos(address.X, address.Y)
        End If
        If e.KeyCode = Keys.Up Then
            If address.Y <> 0 Then
                address.Y -= 1
            End If

            Me.dgArticulos.CurrentCell = Me.dgArticulos(address.X, address.Y)
        End If

        If e.KeyCode = Keys.Enter Then
            If dgArticulos.CurrentRow.Cells("fam").Value = 7 Or dgArticulos.CurrentRow.Cells("fam").Value = 4 And formArti <> "P" Then
                frVerLotes.vReferencia = dgArticulos.CurrentRow.Cells("referen").Value
                frVerLotes.vPrecio = dgArticulos.CurrentRow.Cells("prec").Value
                frVerLotes.vIva = dgArticulos.CurrentRow.Cells("porciva").Value
                If dgArticulos.CurrentRow.Cells("longitud").Value = 0 Then
                    frVerLotes.vLongitud = 0
                Else
                    frVerLotes.vLongitud = dgArticulos.CurrentRow.Cells("longitud").Value
                End If

                frVerLotes.Show()
            Else
                If formArti = "R" Then
                    If frPedidoProv.flagEdit = "N" Then
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedidoProv.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedidoProv.dgLineasPres1.CurrentCell = newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiPedidoProv.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedidoProv.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedidoProv.dgLineasPres2.CurrentCell = newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiPedidoProv.dgLineasPres2.BeginEdit(True)
                        newMdiPedidoProv.actualizarLinea()
                        newMdiPedidoProv.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txCodigo.KeyDown
        Dim address As Point = Me.dgArticulos.CurrentCellAddress
        If e.KeyCode = Keys.Down Then
            If address.Y < Me.dgArticulos.RowCount - 1 Then
                address.Y += 1
            End If

            Me.dgArticulos.CurrentCell = Me.dgArticulos(address.X, address.Y)
        End If
        If e.KeyCode = Keys.Up Then
            If address.Y <> 0 Then
                address.Y -= 1
            End If

            Me.dgArticulos.CurrentCell = Me.dgArticulos(address.X, address.Y)
        End If

        If e.KeyCode = Keys.Enter Then
            If dgArticulos.CurrentRow.Cells("fam").Value = 7 Or dgArticulos.CurrentRow.Cells("fam").Value = 4 And formArti <> "P" Then
                frVerLotes.vReferencia = dgArticulos.CurrentRow.Cells("referen").Value
                frVerLotes.vPrecio = dgArticulos.CurrentRow.Cells("prec").Value
                frVerLotes.vIva = dgArticulos.CurrentRow.Cells("porciva").Value
                frVerLotes.Show()
            Else
                If formArti = "R" Then
                    If frPedidoProv.flagEdit = "N" Then
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedidoProv.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedidoProv.dgLineasPres1.CurrentCell = newMdiPedidoProv.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiPedidoProv.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedidoProv.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedidoProv.dgLineasPres2.CurrentCell = newMdiPedidoProv.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiPedidoProv.dgLineasPres2.BeginEdit(True)
                        newMdiPedidoProv.actualizarLinea()
                        newMdiPedidoProv.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub
End Class