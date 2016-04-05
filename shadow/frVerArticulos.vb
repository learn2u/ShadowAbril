Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frVerArticulos
    Private Sub frVerArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT articulos2.ref_proveedor,articulos2.descripcion,proveedores.nombre, articulos2.stock, articulos2.pvp, proveedores.proveedorID, articulos2.stock_disp, articulos2.iva, articulos2.medidaID, articulos2.familia FROM articulos2 INNER JOIN proveedores ON articulos2.proveedorID=proveedores.proveedorID", conexionmy)

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
        dgArticulos.Columns(4).HeaderText = "PVP"
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
        Dim consultamy As New MySqlCommand("SELECT articulos2.ref_proveedor,articulos2.descripcion,proveedores.nombre, articulos2.stock, articulos2.pvp, proveedores.proveedorID, articulos2.stock_disp, articulos2.iva, articulos2.medidaID, articulos2.familia FROM articulos2 INNER JOIN proveedores ON articulos2.proveedorID=proveedores.proveedorID WHERE ref_proveedor LIKE'" & txCodigo.Text & "%'", conexionmy)

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
        dgArticulos.Columns(4).HeaderText = "PVP"
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
            Dim consultamy As New MySqlCommand("SELECT articulos2.ref_proveedor,articulos2.descripcion,proveedores.nombre, articulos2.stock, articulos2.pvp, proveedores.proveedorID, articulos2.stock_disp, articulos2.iva, articulos2.medidaID, articulos2.familia FROM articulos2 INNER JOIN proveedores ON articulos2.proveedorID=proveedores.proveedorID WHERE descripcion LIKE'" & vFiltro & "%'", conexionmy)

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
            dgArticulos.Columns(4).HeaderText = "PVP"
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
            frVerLotes.Show()
        Else
            If formArti = "P" Then
                If frPresupuestos.flagEdit = "N" Then
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value
                    Else
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiPresupuesto.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiPresupuesto.dgLineasPres1.CurrentCell = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiPresupuesto.dgLineasPres1.BeginEdit(True)
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                Else
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value
                    Else
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiPresupuesto.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiPresupuesto.dgLineasPres2.CurrentCell = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiPresupuesto.dgLineasPres2.BeginEdit(True)
                    newMdiPresupuesto.actualizarLinea()
                    newMdiPresupuesto.recalcularTotales()
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                End If
            End If
            If formArti = "A" Then
                If frAlbaran.flagEdit = "N" Then
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value
                    Else
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiAlbaran.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiAlbaran.dgLineasPres1.CurrentCell = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiAlbaran.dgLineasPres1.BeginEdit(True)
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                Else
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value
                    Else
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiAlbaran.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiAlbaran.dgLineasPres2.CurrentCell = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiAlbaran.dgLineasPres2.BeginEdit(True)
                    newMdiAlbaran.actualizarLinea()
                    newMdiAlbaran.recalcularTotales()
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                End If
            End If

            If formArti = "D" Then
                If frPedido.flagEdit = "N" Then
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value
                    Else
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiPedido.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiPedido.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiPedido.dgLineasPres1.CurrentCell = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiPedido.dgLineasPres1.BeginEdit(True)
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                Else
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value
                    Else
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiPedido.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiPedido.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiPedido.dgLineasPres2.CurrentCell = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiPedido.dgLineasPres2.BeginEdit(True)
                    newMdiPedido.actualizarLinea()
                    newMdiPedido.recalcularTotales()
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                End If
            End If

            If formArti = "F" Then
                If frFacturaManual.flagEdit = "N" Then
                    newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value
                    Else
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiFacturaManual.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiFacturaManual.dgLineasPres1.CurrentCell = newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4)
                    newMdiFacturaManual.dgLineasPres1.BeginEdit(True)
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                Else
                    newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                    newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                    newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                    If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value
                    Else
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                    End If
                    newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                    newMdiFacturaManual.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                    newMdiFacturaManual.dgLineasPres2.CurrentCell = newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4)
                    newMdiFacturaManual.dgLineasPres2.BeginEdit(True)
                    newMdiFacturaManual.actualizarLinea()
                    newMdiFacturaManual.recalcularTotales()
                    txArticulo.Text = ""
                    Me.txArticulo.Focus()
                    Me.Close()
                End If
            End If
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
                frVerLotes.Show()
            Else
                If formArti = "P" Then
                    If frPresupuestos.flagEdit = "N" Then
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPresupuesto.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPresupuesto.dgLineasPres1.CurrentCell = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiPresupuesto.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPresupuesto.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPresupuesto.dgLineasPres2.CurrentCell = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiPresupuesto.dgLineasPres2.BeginEdit(True)
                        newMdiPresupuesto.actualizarLinea()
                        newMdiPresupuesto.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If
                If formArti = "A" Then
                    If frAlbaran.flagEdit = "N" Then
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiAlbaran.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiAlbaran.dgLineasPres1.CurrentCell = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiAlbaran.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiAlbaran.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiAlbaran.dgLineasPres2.CurrentCell = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiAlbaran.dgLineasPres2.BeginEdit(True)
                        newMdiAlbaran.actualizarLinea()
                        newMdiAlbaran.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If

                If formArti = "D" Then
                    If frPedido.flagEdit = "N" Then
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedido.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedido.dgLineasPres1.CurrentCell = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiPedido.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedido.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedido.dgLineasPres2.CurrentCell = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiPedido.dgLineasPres2.BeginEdit(True)
                        newMdiPedido.actualizarLinea()
                        newMdiPedido.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If

                If formArti = "F" Then
                    If frFacturaManual.flagEdit = "N" Then
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiFacturaManual.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiFacturaManual.dgLineasPres1.CurrentCell = newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiFacturaManual.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiFacturaManual.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiFacturaManual.dgLineasPres2.CurrentCell = newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiFacturaManual.dgLineasPres2.BeginEdit(True)
                        newMdiFacturaManual.actualizarLinea()
                        newMdiFacturaManual.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If
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
                If formArti = "P" Then
                    If frPresupuestos.flagEdit = "N" Then
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPresupuesto.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPresupuesto.dgLineasPres1.CurrentCell = newMdiPresupuesto.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiPresupuesto.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPresupuesto.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPresupuesto.dgLineasPres2.CurrentCell = newMdiPresupuesto.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiPresupuesto.dgLineasPres2.BeginEdit(True)
                        newMdiPresupuesto.actualizarLinea()
                        newMdiPresupuesto.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If
                If formArti = "A" Then
                    If frAlbaran.flagEdit = "N" Then
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiAlbaran.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiAlbaran.dgLineasPres1.CurrentCell = newMdiAlbaran.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiAlbaran.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiAlbaran.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiAlbaran.dgLineasPres2.CurrentCell = newMdiAlbaran.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiAlbaran.dgLineasPres2.BeginEdit(True)
                        newMdiAlbaran.actualizarLinea()
                        newMdiAlbaran.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If

                If formArti = "D" Then
                    If frPedido.flagEdit = "N" Then
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiPedido.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedido.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedido.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedido.dgLineasPres1.CurrentCell = newMdiPedido.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiPedido.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiPedido.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiPedido.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiPedido.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiPedido.dgLineasPres2.CurrentCell = newMdiPedido.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiPedido.dgLineasPres2.BeginEdit(True)
                        newMdiPedido.actualizarLinea()
                        newMdiPedido.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If

                If formArti = "F" Then
                    If frFacturaManual.flagEdit = "N" Then
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(6).Value = newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4).Value * newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value
                        Else
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(5).Value = 0
                            newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiFacturaManual.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiFacturaManual.dgLineasPres1.CurrentCell = newMdiFacturaManual.dgLineasPres1.CurrentRow.Cells(4)
                        newMdiFacturaManual.dgLineasPres1.BeginEdit(True)
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    Else
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(2).Value = dgArticulos.CurrentRow.Cells("refpro").Value
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(3).Value = dgArticulos.CurrentRow.Cells("descrip").Value
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4).Value = 1
                        If dgArticulos.CurrentRow.Cells("fam").Value = 3 Or dgArticulos.CurrentRow.Cells("fam").Value = 7 Then
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value = dgArticulos.CurrentRow.Cells("longitud").Value / 100
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(6).Value = newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4).Value * newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value
                        Else
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(5).Value = 0
                            newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(6).Value = 0
                        End If
                        newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(7).Value = dgArticulos.CurrentRow.Cells("prec").Value
                        newMdiFacturaManual.txIva.Text = dgArticulos.CurrentRow.Cells("porciva").Value
                        newMdiFacturaManual.dgLineasPres2.CurrentCell = newMdiFacturaManual.dgLineasPres2.CurrentRow.Cells(4)
                        newMdiFacturaManual.dgLineasPres2.BeginEdit(True)
                        newMdiFacturaManual.actualizarLinea()
                        newMdiFacturaManual.recalcularTotales()
                        txArticulo.Text = ""
                        Me.txArticulo.Focus()
                        Me.Close()
                    End If
                End If
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

    Private Sub dgArticulos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgArticulos.CellContentClick

    End Sub
End Class