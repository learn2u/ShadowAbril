Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frPedidoProv
    Public Shared lineas As Int16
    Public Shared pos As Integer
    Public Shared flagEdit As String = "N"
    Public Shared lineasEdit As New List(Of lineasEditadas)
    Public Shared artiEdit As String
    Public Shared cantIni As Decimal
    Public Shared cantFin As Decimal
    Public Shared serieIni As String
    Public Shared estadoLinea As String = "N"
    Public Shared newLinea As String = "N"
    Public Shared editNumber As String = "N"
    Private Sub frPedidoProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deshabilitarBotones()

        lineas = 0

        If flagEdit = "N" Then
            dgLineasPres1.Visible = True
            dgLineasPres2.Visible = False
        Else
            dgLineasPres1.Visible = False
            dgLineasPres2.Visible = True
        End If

        cargoTodosPedidos()
    End Sub
    Public Sub deshabilitarBotones()
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = False
        cmdImprimir.Enabled = False
        cmdPDF.Enabled = False
        cmdMail.Enabled = False
        cmdCliente.Enabled = False
        cmdLineas.Enabled = False
    End Sub
    Public Sub cargoTodosPedidos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT pedidoprov_cab.num_pedidoprov, 
                                                    pedidoprov_cab.referencia,
                                                    pedidoprov_cab.fecha, 
                                                    proveedores.nombre, 
                                                    pedidoprov_cab.totalbruto, 
                                                    pedidoprov_cab.totalpedido, 
                                                    pedidoprov_cab.proveedorID, 
                                                    proveedores.proveedorID 
                                            FROM pedidoprov_cab INNER JOIN proveedores ON pedidoprov_cab.proveedorID=proveedores.proveedorID ORDER BY pedidoprov_cab.num_pedidoprov DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgPedidos.DataSource = bind
        dgPedidos.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgPedidos.ColumnHeadersDefaultCellStyle = styCabeceras

        dgPedidos.Columns(0).HeaderText = "NUMERO"
        dgPedidos.Columns(0).Name = "Column1"
        dgPedidos.Columns(0).FillWeight = 90
        dgPedidos.Columns(0).MinimumWidth = 90
        dgPedidos.Columns(1).HeaderText = "REFERENCIA"
        dgPedidos.Columns(1).Name = "Column2"
        dgPedidos.Columns(1).FillWeight = 190
        dgPedidos.Columns(1).MinimumWidth = 190
        dgPedidos.Columns(2).HeaderText = "FECHA"
        dgPedidos.Columns(2).Name = "Column3"
        dgPedidos.Columns(2).FillWeight = 90
        dgPedidos.Columns(2).MinimumWidth = 90
        dgPedidos.Columns(3).HeaderText = "CLIENTE"
        dgPedidos.Columns(3).Name = "Column4"
        dgPedidos.Columns(3).FillWeight = 300
        dgPedidos.Columns(3).MinimumWidth = 300
        dgPedidos.Columns(4).HeaderText = "IMPORTE"
        dgPedidos.Columns(4).Name = "Column5"
        dgPedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgPedidos.Columns(4).FillWeight = 90
        dgPedidos.Columns(4).MinimumWidth = 90
        dgPedidos.Columns(5).HeaderText = "TOTAL"
        dgPedidos.Columns(5).Name = "Column6"
        dgPedidos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgPedidos.Columns(5).FillWeight = 90
        dgPedidos.Columns(5).MinimumWidth = 90
        dgPedidos.Columns(6).Visible = False
        dgPedidos.Columns(7).Visible = False
        dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPedidos.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub limpiarFormulario()
        txtNumpres.Text = ""
        txFecha.Text = ""
        txReferenciapres.Text = ""
        txNumcli.Text = ""
        txClientepres.Text = ""
        txFechaEntrega.Text = ""
        txDtocli.Text = ""
        txIva.Text = "21.00"
        cbEstado.Text = ""
        txObserva.Text = ""
        txImpBruto.Text = 0
        txImpDto.Text = 0
        txImponible.Text = 0
        txTotalAlbaran.Text = 0
        tsBotones.Focus()
        cmdNuevo.Select()
        dgLineasPres1.Rows.Clear()
    End Sub

    Private Sub cmdLineas_ButtonClick(sender As Object, e As EventArgs) Handles cmdLineas.ButtonClick
        newLinea = "S"
        If txNumcli.Text = "" Then
            MsgBox("Antes de añadir líneas al pedido es necesario seleccionar un proveedor")
            formCli = "D"
            frVerProveedores.Show()
        Else
            If flagEdit = "N" Then
                If dgLineasPres1.RowCount = 0 Then
                    lineas = 0
                End If
                For Each row As DataGridViewRow In dgLineasPres1.Rows
                    If row.Cells(3).Value Is Nothing Then
                        MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                        Exit Sub
                    End If
                Next
                lineas = lineas + 1
                dgLineasPres1.Rows.Add()
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(0).Value = lineas
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(4).Value = 1
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(7).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(8).Value = txDtocli.Text
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(9).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(10).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(13).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(14).Value = 1
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(14).Style.BackColor = Color.Red

            Else
                If dgLineasPres2.RowCount = 0 Then
                    lineas = 0
                End If
                For Each row As DataGridViewRow In dgLineasPres2.Rows
                    If row.Cells(3).Value Is Nothing Then
                        MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                        Exit Sub
                    End If
                Next
                lineas = lineas + 1
                dgLineasPres2.Rows.Add()
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(0).Value = lineas
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = 1
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(7).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(8).Value = txDtocli.Text
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(9).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(10).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(13).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Value = 1
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Style.BackColor = Color.Red
            End If

        End If
        newLinea = "N"
    End Sub

    Private Sub INSERTARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTARToolStripMenuItem.Click
        newLinea = "S"
        If flagEdit = "N" Then
            For Each row As DataGridViewRow In dgLineasPres1.Rows
                If row.Cells(3).Value Is Nothing Then
                    MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                    Exit Sub
                End If
            Next
            dgLineasPres1.Rows.Insert(dgLineasPres1.CurrentRow.Index)
            renumerar()
            dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.CurrentRow.Index - 1).Cells(4)

            pos = dgLineasPres1.CurrentRow.Index

            dgLineasPres1.CurrentRow.Cells(4).Value = 1
            dgLineasPres1.CurrentRow.Cells(5).Value = 0
            dgLineasPres1.CurrentRow.Cells(6).Value = 0
            dgLineasPres1.CurrentRow.Cells(7).Value = 0
            dgLineasPres1.CurrentRow.Cells(8).Value = txDtocli.Text
            dgLineasPres1.CurrentRow.Cells(9).Value = 0
            dgLineasPres1.CurrentRow.Cells(10).Value = 0
            dgLineasPres1.CurrentRow.Cells(13).Value = 0
            dgLineasPres1.CurrentRow.Cells(14).Value = 1
            dgLineasPres1.CurrentRow.Cells(14).Style.BackColor = Color.Red
        Else
            For Each row As DataGridViewRow In dgLineasPres2.Rows
                If row.Cells(3).Value Is Nothing Then
                    MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descrpción")
                    Exit Sub
                End If
            Next
            dgLineasPres2.Rows.Insert(dgLineasPres2.CurrentRow.Index)
            renumerar()
            dgLineasPres2.CurrentCell = dgLineasPres2.Rows(dgLineasPres2.CurrentRow.Index - 1).Cells(4)

            pos = dgLineasPres2.CurrentRow.Index

            dgLineasPres2.CurrentRow.Cells(4).Value = 1
            dgLineasPres2.CurrentRow.Cells(5).Value = 0
            dgLineasPres2.CurrentRow.Cells(6).Value = 0
            dgLineasPres2.CurrentRow.Cells(7).Value = 0
            dgLineasPres2.CurrentRow.Cells(8).Value = txDtocli.Text
            dgLineasPres2.CurrentRow.Cells(9).Value = 0
            dgLineasPres2.CurrentRow.Cells(10).Value = 0
            dgLineasPres2.CurrentRow.Cells(13).Value = 0
            dgLineasPres2.CurrentRow.Cells(14).Value = 1
            dgLineasPres1.CurrentRow.Cells(14).Style.BackColor = Color.Red
        End If
        newLinea = "N"
    End Sub
    Public Sub renumerar()
        lineas = 0
        If flagEdit = "N" Then
            For Each row As DataGridViewRow In dgLineasPres1.Rows
                lineas = lineas + 1
                row.Cells(0).Value = lineas

            Next
        Else
            For Each row As DataGridViewRow In dgLineasPres2.Rows
                lineas = lineas + 1
                row.Cells(0).Value = lineas

            Next
        End If
    End Sub
    Public Sub recalcularTotales()
        Dim totalLinea As Decimal = 0
        Dim dtoLinea As Decimal = 0
        Dim ivaLinea As Decimal = 0

        If flagEdit = "N" Then
            For Each row2 As DataGridViewRow In dgLineasPres1.Rows
                totalLinea = totalLinea + Decimal.Parse(row2.Cells(9).Value)
                dtoLinea = dtoLinea + (Decimal.Parse(row2.Cells(9).Value) * Decimal.Parse(row2.Cells(8).Value)) / 100
            Next
        Else
            For Each row2 As DataGridViewRow In dgLineasPres2.Rows
                totalLinea = totalLinea + Decimal.Parse(row2.Cells(9).Value)
                dtoLinea = dtoLinea + (Decimal.Parse(row2.Cells(9).Value) * Decimal.Parse(row2.Cells(8).Value)) / 100
            Next
        End If

        If totalLinea < 1 Then
            txImpBruto.Text = totalLinea.ToString("0.00")
        Else
            txImpBruto.Text = totalLinea.ToString("#,###.00")
        End If
        If dtoLinea < 1 Then
            txImpDto.Text = dtoLinea.ToString("0.00")
        Else
            txImpDto.Text = dtoLinea.ToString("#,###.00")
        End If
        If (totalLinea - dtoLinea) < 1 Then
            txImponible.Text = (totalLinea - dtoLinea).ToString("0.00")
        Else
            txImponible.Text = (totalLinea - dtoLinea).ToString("#,###.00")
        End If

        'ivaLinea = (Decimal.Parse(txImponible.Text) * Decimal.Parse(txIva.Text)) / 100
        ivaLinea = (Decimal.Parse(txImponible.Text) * 21) / 100

        If ivaLinea < 1 Then
            txImpIva.Text = ivaLinea.ToString("0.00")
        Else
            txImpIva.Text = ivaLinea.ToString("#,###.00")
        End If
        If (Decimal.Parse(txImponible.Text) + ivaLinea) < 1 Then
            txTotalAlbaran.Text = (Decimal.Parse(txImponible.Text) + ivaLinea).ToString("0.00")
        Else
            txTotalAlbaran.Text = (Decimal.Parse(txImponible.Text) + ivaLinea).ToString("#,###.00")
        End If
    End Sub
    Public Sub actualizarLinea()
        If flagEdit = "N" Then
            If dgLineasPres1.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal
                Dim medida As Decimal
                Dim cantidad As Decimal
                cantidad = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value)

                dgLineasPres1.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value)
                dgLineasPres1.CurrentRow.Cells(4).Value = cantidad
                If dgLineasPres1.CurrentRow.Cells(5).Value = 0 Then
                    total2 = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value) * Decimal.Parse(dgLineasPres1.CurrentRow.Cells(7).Value)
                Else
                    medida = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value) * Decimal.Parse(dgLineasPres1.CurrentRow.Cells(5).Value)
                    dgLineasPres1.CurrentRow.Cells(6).Value = medida
                    total2 = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(6).Value) * Decimal.Parse(dgLineasPres1.CurrentRow.Cells(7).Value)
                End If

                dto2 = (total2 * Decimal.Parse(dgLineasPres1.CurrentRow.Cells(8).Value)) / 100


                totaldef = (total2 - dto2).ToString("0.00")

                dgLineasPres1.CurrentRow.Cells(9).Value = total2
                dgLineasPres1.CurrentRow.Cells(10).Value = totaldef
            End If
        Else
            If dgLineasPres2.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal
                Dim medida As Decimal

                If dgLineasPres2.CurrentRow.Cells(5).Value = 0 Then
                    total2 = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value) * Decimal.Parse(dgLineasPres2.CurrentRow.Cells(7).Value)
                Else
                    medida = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value) * Decimal.Parse(dgLineasPres2.CurrentRow.Cells(5).Value)
                    dgLineasPres2.CurrentRow.Cells(6).Value = medida
                    total2 = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(6).Value) * Decimal.Parse(dgLineasPres2.CurrentRow.Cells(7).Value)
                End If

                dto2 = (total2 * Decimal.Parse(dgLineasPres2.CurrentRow.Cells(8).Value)) / 100


                totaldef = (total2 - dto2).ToString("0.00")

                dgLineasPres2.CurrentRow.Cells(9).Value = total2
                dgLineasPres2.CurrentRow.Cells(10).Value = totaldef
            End If
        End If


    End Sub

    Private Sub dgLineasPres1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellEndEdit
        If (e.ColumnIndex = 4 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8) Then
            actualizarLinea()
            recalcularTotales()

        End If
        If (e.ColumnIndex = 2) Then
            Dim vRef As String = dgLineasPres1.CurrentCell.Value
            cargarArticulos(vRef)
            actualizarLinea()
            recalcularTotales()
        End If
        If (e.ColumnIndex = 13) Then
            Dim entrada As Decimal
            entrada = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(13).Value)
            dgLineasPres1.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value) - Decimal.Parse(dgLineasPres1.CurrentRow.Cells(13).Value)
            dgLineasPres1.CurrentRow.Cells(13).Value = entrada
            dgLineasPres1.CurrentCell = dgLineasPres1.CurrentRow.Cells(2)
        End If
    End Sub

    Private Sub cmdCliente_ButtonClick(sender As Object, e As EventArgs) Handles cmdCliente.ButtonClick
        formCli = "D"
        frVerProveedores.Show()
    End Sub

    Private Sub dgLineasPres1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "R"
            frVerArticulos.Show()
        End If
        If (e.ColumnIndex = 11) Then
            dgLineasPres1.CurrentRow.Cells(13).Value = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value)
            dgLineasPres1.CurrentRow.Cells(14).Style.BackColor = Color.Green
            dgLineasPres1.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value) - Decimal.Parse(dgLineasPres1.CurrentRow.Cells(13).Value)
        End If
        If (e.ColumnIndex = 12) Then
            'dgLineasPres1.CurrentRow.Cells(13).Value = 0
            dgLineasPres1.CurrentRow.Cells(14).Style.BackColor = Color.Orange
            dgLineasPres1.CurrentCell = dgLineasPres1.CurrentRow.Cells(13)
            dgLineasPres1.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value) - Decimal.Parse(dgLineasPres1.CurrentRow.Cells(13).Value)
        End If
        If (e.ColumnIndex = 14) Then
            dgLineasPres1.CurrentRow.Cells(14).Style.BackColor = Color.Red
            dgLineasPres1.CurrentCell = dgLineasPres1.CurrentRow.Cells(2)
            dgLineasPres1.CurrentRow.Cells(13).Value = 0
            dgLineasPres1.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value)
        End If
        If (e.ColumnIndex = 15) Then
            'formArti = "R"
            frCrearLotes.Show()
            frCrearLotes.txReferencia.Text = dgLineasPres1.CurrentRow.Cells(2).Value
            frCrearLotes.txDescripcion.Text = dgLineasPres1.CurrentRow.Cells(3).Value
            frCrearLotes.txFecha.Text = Format(Today, "ddMMyyyy")
            frCrearLotes.txLote.Focus()

        End If

        pos = dgLineasPres1.CurrentRow.Index
    End Sub

    Private Sub ELIMINARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARToolStripMenuItem.Click
        If flagEdit = "N" Then
            dgLineasPres1.Rows.RemoveAt(dgLineasPres1.CurrentRow.Index)
            renumerar()
            recalcularTotales()
        Else
            'Cargo los datos de la linea para el control de stocks
            artiEdit = dgLineasPres2.CurrentRow.Cells(2).Value
            cantIni = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
            cantFin = 0
            lineasEdit.Add(New lineasEditadas() With {.codigoArt = artiEdit, .cantAntes = cantIni, .cantDespues = cantFin})

            dgLineasPres2.Rows.RemoveAt(dgLineasPres2.CurrentRow.Index)
            renumerar()
            recalcularTotales()
        End If
    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        cmdNuevo.Enabled = False
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdLineas.Enabled = True
        cmdCliente.Enabled = True
        limpiarFormulario()
        flagEdit = "N"
        dgLineasPres2.Visible = False
        dgLineasPres1.Visible = True
        'cbSerie.Text = "S1"
        cbEstado.Text = "PENDIENTE"
        txFecha.Text = Format(Today, "ddMMyyyy")
        txReferenciapres.Focus()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdNuevo.Enabled = True
        deshabilitarBotones()
        limpiarFormulario()
        If flagEdit = "S" Then
            dgLineasPres2.Rows.Clear()
            flagEdit = "N"
        Else
            dgLineasPres1.Rows.Clear()
        End If
        lineas = 0
        tabPresupuestos.SelectTab(0)
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If flagEdit = "N" Then
            cargoNumero()

            Dim impbru As String = Replace(txImpBruto.Text.ToString, ".", "")
            Dim guardo_impbru As String = Replace(impbru, ",", ".")
            Dim impdto As String = Replace(txImpDto.Text.ToString, ".", "")
            Dim guardo_impdto As String = Replace(impdto, ",", ".")
            Dim impiva As String = Replace(txImpIva.Text.ToString, ".", "")
            Dim guardo_impiva As String = Replace(impiva, ",", ".")
            Dim imptot As String = Replace(txTotalAlbaran.Text.ToString, ".", "")
            Dim guardo_imptot As String = Replace(imptot, ",", ".")

            Dim fecha As Date = txFecha.Text
            Dim fechaent As Date
            If txFechaEntrega.Text = "  /  /" Then
                fechaent = Nothing
            Else
                fechaent = txFechaEntrega.Text
            End If


            'Guardo cabecera y actualizo número de presupuesto
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand("INSERT INTO pedidoprov_cab (num_pedidoprov, proveedorID, empresaID, usuarioID, fecha, fechaentrega, albaranpro, referencia, observaciones, totalbruto, totaldto, totaliva, totalpedido, estado, eliminado) VALUES (" + txtNumpres.Text + ", " + txNumcli.Text + ", " + txEmpresa.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "', '" + fechaent.ToString("yyyy-MM-dd") + "', '" + txAlbaranPro.Text + "', '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imptot + "', 'P', 'N')", conexionmy)
            cmd.ExecuteNonQuery()

            Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_pedidoprov = '" + txtNumpres.Text + "'", conexionmy)
            cmdActualizar.ExecuteNonQuery()



            'Guardo líneas del presupuesto

            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow

            Dim lincant As String
            Dim guardo_lincant As String
            Dim linancho As String
            Dim guardo_linancho As String
            Dim linmetros As String
            Dim guardo_linmetros As String
            Dim linprec As String
            Dim guardo_linprec As String
            Dim lindto As String
            Dim guardo_lindto As String
            Dim liniva As String
            Dim guardo_liniva As String
            Dim linimporte As String
            Dim guardo_linimporte As String
            Dim lintotal As String
            Dim guardo_lintotal As String
            Dim linentrada As String
            Dim guardo_linentrada As String
            Dim linpendiente As String
            Dim guardo_linpendiente As String

            Dim arti As String

            For Each row In dgLineasPres1.Rows


                lincant = Decimal.Parse(row.Cells(4).Value).ToString("0.00")
                guardo_lincant = Replace(lincant, ",", ".")

                linancho = row.Cells(5).Value.ToString
                guardo_linancho = Replace(linancho, ",", ".")

                linmetros = row.Cells(6).Value.ToString
                guardo_linmetros = Replace(linmetros, ",", ".")

                linprec = row.Cells(7).Value.ToString
                guardo_linprec = Replace(linprec, ",", ".")

                lindto = row.Cells(8).Value.ToString
                guardo_lindto = Replace(lindto, ",", ".")

                liniva = txIva.Text
                guardo_liniva = Replace(liniva, ",", ".")

                linimporte = row.Cells(9).Value.ToString
                guardo_linimporte = Replace(linimporte, ",", ".")

                lintotal = row.Cells(10).Value.ToString
                guardo_lintotal = Replace(lintotal, ",", ".")

                linentrada = row.Cells(13).Value.ToString
                guardo_linentrada = Replace(linentrada, ",", ".")

                linpendiente = row.Cells(14).Value.ToString
                guardo_linpendiente = Replace(linpendiente, ",", ".")

                arti = row.Cells(2).Value

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO pedidoprov_linea (num_pedidoprov, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, estado, entrada, pendiente, albaranpro) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', 'N', '" + guardo_linentrada + "', '" + guardo_linpendiente + "', '" + txAlbaranPro.Text + "')"

                cmdLinea.ExecuteNonQuery()
                'descontarStock(arti, lincant)

            Next

            conexionmy.Close()

            deshabilitarBotones()
            limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
        Else

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim impbru As String = Replace(txImpBruto.Text.ToString, ".", "")
            Dim guardo_impbru As String = Replace(impbru, ",", ".")
            Dim impdto As String = Replace(txImpDto.Text.ToString, ".", "")
            Dim guardo_impdto As String = Replace(impdto, ",", ".")
            Dim impiva As String = Replace(txImpIva.Text.ToString, ".", "")
            Dim guardo_impiva As String = Replace(impiva, ",", ".")
            Dim imptot As String = Replace(txTotalAlbaran.Text.ToString, ".", "")
            Dim guardo_imptot As String = Replace(imptot, ",", ".")

            Dim fecha As Date = txFecha.Text
            Dim fechaent As Date
            If txFechaEntrega.Text = "  /  /" Then
                fechaent = Nothing
            Else
                fechaent = txFechaEntrega.Text
            End If

            'Guardo cabecera y actualizo número de presupuesto


            Dim cmd As New MySqlCommand("UPDATE pedidoprov_cab SET fecha = '" + fecha.ToString("yyyy-MM-dd") + "', fechaentrega = '" + fechaent.ToString("yyyy-MM-dd") + "', proveedorID = " + txNumcli.Text + ", albaranpro = '" + txAlbaranPro.Text + "', referencia = '" + txReferenciapres.Text + "', observaciones = '" + txObserva.Text + "', totalbruto = '" + guardo_impbru + "', totaldto = '" + guardo_impdto + "', totaliva = '" + guardo_impiva + "', totalpedido = '" + guardo_imptot + "' WHERE num_pedidoprov = " + txtNumpres.Text + "", conexionmy)
            cmd.ExecuteNonQuery()


            'Guardo líneas del presupuesto

            Dim cmdEliminar As New MySqlCommand("DELETE FROM pedidoprov_linea WHERE num_pedidoprov = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow

            Dim lincant As String
            Dim guardo_lincant As String
            Dim linancho As String
            Dim guardo_linancho As String
            Dim linmetros As String
            Dim guardo_linmetros As String
            Dim linprec As String
            Dim guardo_linprec As String
            Dim lindto As String
            Dim guardo_lindto As String
            Dim liniva As String
            Dim guardo_liniva As String
            Dim linimporte As String
            Dim guardo_linimporte As String
            Dim lintotal As String
            Dim guardo_lintotal As String
            Dim linentrada As String
            Dim guardo_linentrada As String
            Dim linpendiente As String
            Dim guardo_linpendiente As String

            For Each row In dgLineasPres2.Rows


                lincant = Decimal.Parse(row.Cells(4).Value).ToString("0.00")
                guardo_lincant = Replace(lincant, ",", ".")

                linancho = row.Cells(5).Value.ToString
                guardo_linancho = Replace(linancho, ",", ".")

                linmetros = row.Cells(6).Value.ToString
                guardo_linmetros = Replace(linmetros, ",", ".")

                linprec = row.Cells(7).Value.ToString
                guardo_linprec = Replace(linprec, ",", ".")

                lindto = row.Cells(8).Value.ToString
                guardo_lindto = Replace(lindto, ",", ".")

                liniva = txIva.Text
                guardo_liniva = Replace(liniva, ",", ".")

                linimporte = row.Cells(9).Value.ToString
                guardo_linimporte = Replace(linimporte, ",", ".")

                lintotal = row.Cells(10).Value.ToString
                guardo_lintotal = Replace(lintotal, ",", ".")

                linentrada = row.Cells(13).Value.ToString
                guardo_linentrada = Replace(linentrada, ",", ".")

                linpendiente = row.Cells(14).Value.ToString
                guardo_linpendiente = Replace(linpendiente, ",", ".")

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO pedidoprov_linea (num_pedidoprov, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, estado, entrada, pendiente, albaranpro) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', 'N', '" + guardo_linentrada + "', '" + guardo_linpendiente + "', '" + txAlbaranPro.Text + "')"

                cmdLinea.ExecuteNonQuery()


            Next

            conexionmy.Close()

            If lineasEdit.Count > 0 Then
                For Each itemlineas As lineasEditadas In lineasEdit
                    'aumentarStock(itemlineas.codigoArt, itemlineas.cantAntes)
                    'descontarStock(itemlineas.codigoArt, itemlineas.cantDespues)
                Next
            End If
            lineasEdit.Clear()


            deshabilitarBotones()
            limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub
    Public Sub cargoNumero()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim numid As Int32


        Dim cmdLastId As New MySqlCommand("SELECT num_pedidoprov FROM configuracion  ", conexionmy)
        numid = cmdLastId.ExecuteScalar()


        txtNumpres.Text = numid + 1

        conexionmy.Close()

    End Sub

    Private Sub dgPedidos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPedidos.CellClick
        limpiarFormulario()
        cmdLineas.Enabled = True
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdCliente.Enabled = True

        txtNumpres.Text = dgPedidos.CurrentRow.Cells("Column1").Value.ToString
        tabPresupuestos.SelectTab(1)
        flagEdit = "S"
        dgLineasPres1.Visible = False
        dgLineasPres2.Visible = True
        dgLineasPres2.Rows.Clear()


        cargoPedido()
        cargoLineas()
        recalcularTotales()
    End Sub
    Public Sub cargoPedido()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCab As New MySqlCommand

        Dim cmdCli As New MySqlCommand

        Dim rdrCab As MySqlDataReader

        Dim rdrCli As MySqlDataReader


        cmdCab = New MySqlCommand("SELECT * FROM pedidoprov_cab WHERE num_pedidoprov = '" + txtNumpres.Text + "'", conexionmy)

        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        rdrCab.Read()
        txFecha.Text = rdrCab("fecha")
        If rdrCab("fechaentrega") = "00:00:0" Then
            txFechaEntrega.Text = "  /  /"
        Else
            txFechaEntrega.Text = rdrCab("fechaentrega")
        End If

        txNumcli.Text = rdrCab("proveedorID")
        txReferenciapres.Text = rdrCab("referencia")
        txAlbaranPro.Text = rdrCab("albaranpro")
        txObserva.Text = rdrCab("observaciones")

        rdrCab.Close()


        cmdCli = New MySqlCommand("SELECT * FROM proveedores WHERE proveedorID = '" + txNumcli.Text + "'", conexionmy)

        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        rdrCli = cmdCli.ExecuteReader
        rdrCli.Read()

        txNumcli.Text = rdrCli("proveedorID")
        txClientepres.Text = rdrCli("nombre")
        txDtocli.Text = rdrCli("descuento")

        rdrCli.Close()

        conexionmy.Close()
    End Sub
    Public Sub cargoLineas()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT pedidoprov_linea.linea,
                                            pedidoprov_linea.codigo,
                                            pedidoprov_linea.descripcion,
                                            pedidoprov_linea.cantidad,
                                            pedidoprov_linea.ancho_largo,
                                            pedidoprov_linea.m2_ml,
                                            pedidoprov_linea.precio,
                                            pedidoprov_linea.descuento,
                                            pedidoprov_linea.ivalinea,
                                            pedidoprov_linea.importe,
                                            pedidoprov_linea.totalinea,
                                            pedidoprov_linea.entrada,
                                            pedidoprov_linea.pendiente,
                                            pedidoprov_linea.num_pedidoprov
                                            FROM pedidoprov_linea WHERE num_pedidoprov = '" + txtNumpres.Text + "' ORDER BY pedidoprov_linea.linea", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        rdrLin = cmdLinea.ExecuteReader
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                lineas = lineas + 1
                dgLineasPres2.Rows.Add()
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(0).Value = rdrLin("linea")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(2).Value = rdrLin("codigo")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(3).Value = rdrLin("descripcion")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = rdrLin("cantidad")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(5).Value = rdrLin("ancho_largo")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(6).Value = rdrLin("m2_ml")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(7).Value = rdrLin("precio")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(8).Value = rdrLin("descuento")
                'dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(9).Value = rdrLin("ivalinea")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(9).Value = rdrLin("importe")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(10).Value = rdrLin("totalinea")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(13).Value = rdrLin("entrada")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Value = rdrLin("pendiente")
                If Decimal.Parse(dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Value) = 0 Then
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Style.BackColor = Color.Green
                End If
                If Decimal.Parse(dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Value) > 0 And Decimal.Parse(dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Value) < Decimal.Parse(dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value) Then
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Style.BackColor = Color.Orange
                End If
                If Decimal.Parse(dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Value) = Decimal.Parse(dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value) Then
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(14).Style.BackColor = Color.Red
                End If
            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()

        recalcularTotales()
    End Sub

    Private Sub dgLineasPres2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "R"
            frVerArticulos.Show()
        End If
        If (e.ColumnIndex = 11) Then
            dgLineasPres2.CurrentRow.Cells(13).Value = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
            dgLineasPres2.CurrentRow.Cells(14).Style.BackColor = Color.Green
            dgLineasPres2.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value) - Decimal.Parse(dgLineasPres2.CurrentRow.Cells(13).Value)
        End If
        If (e.ColumnIndex = 12) Then
            ' dgLineasPres2.CurrentRow.Cells(13).Value = 0
            dgLineasPres2.CurrentRow.Cells(14).Style.BackColor = Color.Orange
            dgLineasPres2.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value) - Decimal.Parse(dgLineasPres2.CurrentRow.Cells(13).Value)
        End If
        If (e.ColumnIndex = 14) Then
            dgLineasPres2.CurrentRow.Cells(14).Style.BackColor = Color.Red
            dgLineasPres2.CurrentCell = dgLineasPres2.CurrentRow.Cells(2)
            dgLineasPres2.CurrentRow.Cells(14).Value = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
        End If
        If (e.ColumnIndex = 15) Then
            'formArti = "R"
            frCrearLotes.Show()
        End If
        pos = dgLineasPres2.CurrentRow.Index
    End Sub

    Private Sub dgLineasPres2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellEndEdit
        If (e.ColumnIndex = 4 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8) Then
            actualizarLinea()
            recalcularTotales()
        End If
        If (e.ColumnIndex = 4) Then
            cantFin = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
            lineasEdit.Add(New lineasEditadas() With {.codigoArt = artiEdit, .cantAntes = cantIni, .cantDespues = cantFin})
            'MsgBox(artiEdit)
            'MsgBox(cantIni)
            'MsgBox(cantFin)
        End If
    End Sub
    Public Sub recalcularDescuentos()
        For Each row2 As DataGridViewRow In dgLineasPres2.Rows
            row2.Cells(8).Value = Decimal.Parse(txDtocli.Text).ToString("0.00")
            actualizarLinea()
        Next
        recalcularTotales()

    End Sub
    Public Sub descontarStock(codArti As String, unidades As Decimal)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim cmdLastId As New MySqlCommand("SELECT ref_proveedor, stock_disp FROM articulos2 WHERE ref_proveedor = '" + codArti + "'", conexionmy)
        Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
        reader.Read()

        Dim stock As String = (reader.GetString(1) - unidades).ToString
        reader.Close()

        Dim cmdActualizo As New MySqlCommand("UPDATE articulos2 SET stock_disp = '" + stock + "' WHERE ref_proveedor = '" + codArti + "'", conexionmy)
        cmdActualizo.ExecuteNonQuery()

        conexionmy.Close()

    End Sub
    Public Sub aumentarStock(codArti As String, unidades As Decimal)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim cmdLastId As New MySqlCommand("SELECT ref_proveedor, stock_disp FROM articulos2 WHERE ref_proveedor = '" + codArti + "'", conexionmy)
        Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
        reader.Read()

        Dim stock As String = (reader.GetString(1) + unidades).ToString
        reader.Close()

        Dim cmdActualizo As New MySqlCommand("UPDATE articulos2 SET stock_disp = '" + stock + "' WHERE ref_proveedor = '" + codArti + "'", conexionmy)
        cmdActualizo.ExecuteNonQuery()

        conexionmy.Close()

    End Sub

    Private Sub dgLineasPres2_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellEnter
        If (e.ColumnIndex = 4) Then
            artiEdit = dgLineasPres2.CurrentRow.Cells(2).Value
            cantIni = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
        End If
    End Sub
    Public Sub cargarArticulos(refer As String)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCli As New MySqlCommand
        Dim rdrArt As MySqlDataReader
        cmdCli = New MySqlCommand("SELECT ref_proveedor,referencia,descripcion,pvp,iva,medidaID,familia FROM articulos2 WHERE ref_proveedor = '" & refer & "'", conexionmy)


        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        rdrArt = cmdCli.ExecuteReader
        rdrArt.Read()

        If rdrArt.HasRows = True Then
            If flagEdit = "N" Then
                dgLineasPres1.CurrentRow.Cells(3).Value = rdrArt("descripcion")
                dgLineasPres1.CurrentRow.Cells(4).Value = 1
                dgLineasPres1.CurrentRow.Cells(5).Value = rdrArt("medidaID") / 100
                dgLineasPres1.CurrentRow.Cells(6).Value = dgLineasPres1.CurrentRow.Cells(4).Value * dgLineasPres1.CurrentRow.Cells(5).Value
                dgLineasPres1.CurrentRow.Cells(7).Value = rdrArt("pvp")
                dgLineasPres1.CurrentRow.Cells(8).Value = txDtocli.Text
                dgLineasPres1.CurrentRow.Cells(9).Value = 0
                dgLineasPres1.CurrentRow.Cells(10).Value = 0
                dgLineasPres1.CurrentRow.Cells(11).Value = ""
                txIva.Text = rdrArt("iva")
                'dgLineasPres1.CurrentCell = dgLineasPres1.CurrentRow.Cells(4)
                'dgLineasPres1.BeginEdit(True)
            Else
                dgLineasPres2.CurrentRow.Cells(3).Value = rdrArt("descripcion")
                dgLineasPres2.CurrentRow.Cells(4).Value = 1
                dgLineasPres2.CurrentRow.Cells(5).Value = rdrArt("medidaID") / 100
                dgLineasPres2.CurrentRow.Cells(6).Value = dgLineasPres2.CurrentRow.Cells(4).Value * dgLineasPres2.CurrentRow.Cells(5).Value
                dgLineasPres2.CurrentRow.Cells(7).Value = rdrArt("pvp")
                dgLineasPres2.CurrentRow.Cells(8).Value = txDtocli.Text
                dgLineasPres2.CurrentRow.Cells(9).Value = 0
                dgLineasPres2.CurrentRow.Cells(10).Value = 0
                dgLineasPres2.CurrentRow.Cells(11).Value = ""
                txIva.Text = rdrArt("iva")
                'dgLineasPres2.CurrentCell = dgLineasPres2.CurrentRow.Cells(4)
                'dgLineasPres2.BeginEdit(True)
            End If
        Else

        End If



        rdrArt.Close()

        conexionmy.Close()
    End Sub

    Private Sub dgLineasPres1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellValueChanged
        If newLinea = "N" Then
            Dim value1 As String = ""
            Dim value2 As String = ""
            Dim value3 As String = ""
            If dgLineasPres1.CurrentCell Is Nothing Then
                Exit Sub
            Else

                If (e.ColumnIndex = 4) Then
                    value1 = dgLineasPres1.CurrentRow.Cells(4).EditedFormattedValue.ToString
                    value1 = value1.Replace(".", ",")
                    If value1 <> "" Then
                        Dim cellValue As Decimal = CType(value1, Decimal)
                        dgLineasPres1.CurrentRow.Cells(4).Value = cellValue
                    End If
                End If
                If (e.ColumnIndex = 7) Then
                    value2 = dgLineasPres1.CurrentRow.Cells(7).EditedFormattedValue.ToString
                    value2 = value2.Replace(".", ",")
                    If value2 <> "" Then
                        Dim cellValue As Decimal = CType(value2, Decimal)
                        dgLineasPres1.CurrentRow.Cells(7).Value = cellValue
                    End If
                End If
                If (e.ColumnIndex = 8) Then
                    value3 = dgLineasPres1.CurrentRow.Cells(8).EditedFormattedValue.ToString
                    value3 = value3.Replace(".", ",")
                    If value3 <> "" Then
                        Dim cellValue As Decimal = CType(value3, Decimal)
                        dgLineasPres1.CurrentRow.Cells(8).Value = cellValue
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgLineasPres2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellValueChanged
        If newLinea = "N" Then
            Dim value1 As String = ""
            Dim value2 As String = ""
            Dim value3 As String = ""
            If dgLineasPres2.CurrentCell Is Nothing Then
                Exit Sub
            Else
                If (e.ColumnIndex = 4) Then

                    If editNumber = "S" Then
                        value1 = dgLineasPres2.CurrentRow.Cells(4).EditedFormattedValue.ToString
                        value1 = value1.Replace(".", ",")
                    Else
                        value1 = Replace(dgLineasPres2.CurrentRow.Cells(4).EditedFormattedValue.ToString, ".", "")
                    End If
                    If value1 <> "" Then
                        Dim cellValue As Decimal = CType(value1, Decimal)
                        dgLineasPres2.CurrentRow.Cells(4).Value = cellValue
                    End If
                    editNumber = "N"
                End If
                If (e.ColumnIndex = 7) Then
                    If editNumber = "S" Then
                        value2 = dgLineasPres2.CurrentRow.Cells(7).EditedFormattedValue.ToString
                        value2 = value2.Replace(".", ",")
                    Else
                        value2 = Replace(dgLineasPres2.CurrentRow.Cells(7).EditedFormattedValue.ToString, ".", "")
                    End If
                    If value2 <> "" Then
                        Dim cellValue As Decimal = CType(value2, Decimal)
                        dgLineasPres2.CurrentRow.Cells(7).Value = cellValue
                    End If
                    editNumber = "N"
                End If
                If (e.ColumnIndex = 8) Then
                    If editNumber = "S" Then
                        value3 = dgLineasPres2.CurrentRow.Cells(8).EditedFormattedValue.ToString
                        value3 = value3.Replace(".", ",")
                    Else
                        value3 = Replace(dgLineasPres2.CurrentRow.Cells(8).EditedFormattedValue.ToString, ".", "")
                    End If
                    If value3 <> "" Then
                        Dim cellValue As Decimal = CType(value3, Decimal)
                        dgLineasPres2.CurrentRow.Cells(8).Value = cellValue
                    End If
                    editNumber = "N"
                End If
            End If
        End If
    End Sub

    Private Sub dgLineasPres2_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgLineasPres2.CellBeginEdit
        If (e.ColumnIndex = 4) Or (e.ColumnIndex = 7) Or (e.ColumnIndex = 8) Then
            editNumber = "S"
        End If
    End Sub

    Private Sub dgPedidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPedidos.CellDoubleClick
        limpiarFormulario()
        cmdLineas.Enabled = True
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdCliente.Enabled = True

        txtNumpres.Text = dgPedidos.CurrentRow.Cells("Column1").Value.ToString
        tabPresupuestos.SelectTab(1)
        flagEdit = "S"
        dgLineasPres1.Visible = False
        dgLineasPres2.Visible = True
        dgLineasPres2.Rows.Clear()


        cargoPedido()
        cargoLineas()
        cmdDelete.Enabled = True
        recalcularTotales()
    End Sub
End Class