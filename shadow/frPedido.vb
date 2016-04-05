﻿Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frPedido
    Public Shared lineas As Int16
    Public Shared pos As Integer
    Public Shared flagEdit As String = "N"
    Public Shared lineasEdit As New List(Of lineasEditadas)
    Public Shared artiEdit As String
    Public Shared cantIni As Decimal
    Public Shared cantFin As Decimal
    Public Shared serieIni As String
    Public Shared newLinea As String = "N"
    Public Shared editNumber As String = "N"

    Private Sub frPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deshabilitarBotones()

        lineas = 0

        If flagEdit = "N" Then
            dgLineasPres1.Visible = True
            dgLineasPres1.Enabled = False
            dgLineasPres2.Visible = False
        Else
            dgLineasPres1.Visible = False
            dgLineasPres2.Visible = True
        End If


        'GroupBox5.Visible = False
        btBuscar.Visible = False


    End Sub
    Public Sub deshabilitarBotones()
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = False
        cmdDelete.Enabled = False
        cmdImprimir.Enabled = False
        cmdPDF.Enabled = False
        cmdMail.Enabled = False
        cmdPedido.Enabled = False
        cmdAlbaran.Enabled = False
        cmdToldos.Enabled = False
        cmdCliente.Enabled = False
        cmdRentabilidad.Enabled = False
        cmdLineas.Enabled = False
    End Sub
    Public Sub cargoTodosPedidos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.eliminado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE eliminado = 'N' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
            dgPedidos.Columns(8).Visible = False
            dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgPedidos.Visible = True
            conexionmy.Close()



    End Sub
    Public Sub limpiarFormulario()
        txtNumpres.Text = ""
        txNumpresBk.Text = ""
        txFecha.Text = ""
        txReferenciapres.Text = ""
        txNumcli.Text = ""
        txClientepres.Text = ""
        txAgente.Text = ""
        txRecargo.Text = ""
        txDtocli.Text = ""
        txIva.Text = "21.00"
        cbEstado.Text = ""
        cbEnvio.Text = ""
        txObserva.Text = ""
        txImpBruto.Text = 0
        txImpDto.Text = 0
        txImponible.Text = 0
        txImpIva.Text = 0
        txImpRecargo.Text = 0
        txTotalAlbaran.Text = 0
        tsBotones.Focus()
        cmdNuevo.Select()
        dgLineasPres1.Rows.Clear()
    End Sub

    Private Sub cmdLineas_ButtonClick(sender As Object, e As EventArgs) Handles cmdLineas.ButtonClick

        newLinea = "S"
        If txNumcli.Text = "" Then
            MsgBox("Antes de añadir líneas al pedido es necesario seleccionar un cliente")
            formCli = "D"
            frVerClientes.Show()
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
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(4).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(7).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(8).Value = txDtocli.Text
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(9).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(10).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(11).Value = ""
                dgLineasPres1.Focus()
                dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(2)
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(2).Selected = True
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
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(7).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(8).Value = txDtocli.Text
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(9).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(10).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(11).Value = ""
                dgLineasPres2.Focus()
                dgLineasPres2.CurrentCell = dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(2)
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(2).Selected = True
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

            dgLineasPres1.CurrentRow.Cells(4).Value = 0
            dgLineasPres1.CurrentRow.Cells(5).Value = 0
            dgLineasPres1.CurrentRow.Cells(6).Value = 0
            dgLineasPres1.CurrentRow.Cells(7).Value = 0
            dgLineasPres1.CurrentRow.Cells(8).Value = txDtocli.Text
            dgLineasPres1.CurrentRow.Cells(9).Value = 0
            dgLineasPres1.CurrentRow.Cells(10).Value = 0
            dgLineasPres1.CurrentRow.Cells(11).Value = ""
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

            dgLineasPres2.CurrentRow.Cells(4).Value = 0
            dgLineasPres2.CurrentRow.Cells(5).Value = 0
            dgLineasPres2.CurrentRow.Cells(6).Value = 0
            dgLineasPres2.CurrentRow.Cells(7).Value = 0
            dgLineasPres2.CurrentRow.Cells(8).Value = txDtocli.Text
            dgLineasPres2.CurrentRow.Cells(9).Value = 0
            dgLineasPres2.CurrentRow.Cells(10).Value = 0
            dgLineasPres2.CurrentRow.Cells(11).Value = ""
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
        'MsgBox(lineas)

    End Sub
    Public Sub recalcularTotales()
        Dim totalLinea As Decimal = 0
        Dim dtoLinea As Decimal = 0
        Dim ivaLinea As Decimal = 0
        Dim reclinea As Decimal = 0

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
        If txRecargo.Text = "S" Then
            reclinea = (Decimal.Parse(txImponible.Text) * vRecargo) / 100
            If reclinea < 1 Then
                txImpRecargo.Text = reclinea.ToString("0.00")
            Else
                txImpRecargo.Text = reclinea.ToString("#,###.00")
            End If

        End If
        If ivaLinea < 1 Then
            txImpIva.Text = ivaLinea.ToString("0.00")
        Else
            txImpIva.Text = ivaLinea.ToString("#,###.00")
        End If
        If (Decimal.Parse(txImponible.Text) + ivaLinea + reclinea) < 1 Then
            txTotalAlbaran.Text = (Decimal.Parse(txImponible.Text) + ivaLinea + reclinea).ToString("0.00")
        Else
            txTotalAlbaran.Text = (Decimal.Parse(txImponible.Text) + ivaLinea + reclinea).ToString("#,###.00")
        End If
    End Sub
    Public Sub actualizarLinea()
        If flagEdit = "N" Then
            If dgLineasPres1.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal
                Dim medida As Decimal

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
    End Sub

    Private Sub cmdCliente_ButtonClick(sender As Object, e As EventArgs) Handles cmdCliente.ButtonClick
        formCli = "D"
        frVerClientes.Show()
    End Sub

    Private Sub dgLineasPres1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "D"
            frVerArticulos.Show()
        End If
        If (dgLineasPres1.CurrentRow.Index = 0) Then

        Else
            pos = dgLineasPres1.CurrentRow.Index
        End If
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
        'If dgLineasPres1.RowCount = 0 Then
        ' lineas = 0
        ' End If
        ' If dgLineasPres2.RowCount = 0 Then
        ' lineas = 0
        ' End If
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
        dgLineasPres1.Enabled = True
        dgLineasPres1.Visible = True
        cbEstado.Text = "PENDIENTE"
        cbEstado.Enabled = True
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
            Dim imprec As String = Replace(txImpRecargo.Text.ToString, ".", "")
            Dim guardo_imprec As String = Replace(imprec, ",", ".")

            Dim fecha As Date = txFecha.Text
            Dim vEstado As String
            If cbEstado.Text = "PENDIENTE" Then
                vEstado = "P"
            ElseIf cbEstado.Text = "ENVIADO" Then
                vEstado = "E"
            ElseIf cbEstado.Text = "CONVERTIDO A ALBARAN" Then
                vEstado = "A"
            Else
                vEstado = "F"
            End If

            'Guardo cabecera y actualizo número de presupuesto
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand("INSERT INTO pedido_cab (num_pedido, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalpedido, estado) VALUES (" + txtNumpres.Text + ", " + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', '" + vEstado + "')", conexionmy)
            cmd.ExecuteNonQuery()

            Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_pedido = '" + txtNumpres.Text + "'", conexionmy)
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

                arti = row.Cells(2).Value

                If row.Cells(2).Value Is Nothing Then
                    row.Cells(2).Value = ""
                End If

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO pedido_linea (num_pedido, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, lote) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', '" + row.Cells(11).Value + "')"

                cmdLinea.ExecuteNonQuery()
                descontarStock(arti, lincant)

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
            Dim imprec As String = Replace(txImpRecargo.Text.ToString, ".", "")
            Dim guardo_imprec As String = Replace(imprec, ",", ".")

            Dim fecha As Date = txFecha.Text
            Dim vEstado As String
            If cbEstado.Text = "PENDIENTE" Then
                vEstado = "P"
            ElseIf cbEstado.Text = "ENVIADO" Then
                vEstado = "E"
            ElseIf cbEstado.Text = "CONVERTIDO A ALBARAN" Then
                vEstado = "A"
            Else
                vEstado = "F"
            End If

            'Guardo cabecera y actualizo número de presupuesto


            Dim cmd As New MySqlCommand("UPDATE pedido_cab SET fecha = '" + fecha.ToString("yyyy-MM-dd") + "', clienteID = " + txNumcli.Text + ", agenteID = " + txAgente.Text + ", referencia = '" + txReferenciapres.Text + "', observaciones = '" + txObserva.Text + "', totalbruto = '" + guardo_impbru + "', totaldto = '" + guardo_impdto + "', totaliva = '" + guardo_impiva + "', totalrecargo = '" + guardo_imprec + "', totalpedido = '" + guardo_imptot + "', estado = '" + vEstado + "' WHERE num_pedido = " + txtNumpres.Text + "", conexionmy)
            cmd.ExecuteNonQuery()


            'Guardo líneas del presupuesto

            Dim cmdEliminar As New MySqlCommand("DELETE FROM pedido_linea WHERE num_pedido = '" + txtNumpres.Text + "'", conexionmy)
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

                If row.Cells(2).Value Is Nothing Then
                    row.Cells(2).Value = ""
                End If

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO pedido_linea (num_pedido, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, lote) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', '" + row.Cells(11).Value + "')"

                cmdLinea.ExecuteNonQuery()


            Next

            conexionmy.Close()

            If lineasEdit.Count > 0 Then
                For Each itemlineas As lineasEditadas In lineasEdit
                    aumentarStock(itemlineas.codigoArt, itemlineas.cantAntes)
                    descontarStock(itemlineas.codigoArt, itemlineas.cantDespues)
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


        Dim cmdLastId As New MySqlCommand("SELECT num_pedido FROM configuracion  ", conexionmy)
        numid = cmdLastId.ExecuteScalar()


        txtNumpres.Text = numid + 1

        conexionmy.Close()

    End Sub
    Public Sub cargoPedido()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCab As New MySqlCommand

        Dim cmdCli As New MySqlCommand

        Dim rdrCab As MySqlDataReader

        Dim rdrCli As MySqlDataReader


        cmdCab = New MySqlCommand("SELECT * FROM pedido_cab WHERE num_pedido = '" + txtNumpres.Text + "'", conexionmy)

        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        rdrCab.Read()
        txFecha.Text = rdrCab("fecha")
        txNumcli.Text = rdrCab("clienteID")
        txAgente.Text = rdrCab("agenteID")
        txReferenciapres.Text = rdrCab("referencia")
        txObserva.Text = rdrCab("observaciones")
        If rdrCab("estado") = "P" Then
            cbEstado.Text = "PENDIENTE"
        End If
        If rdrCab("estado") = "A" Then
            cbEstado.Text = "CONVERTIDO A ALBARAN"
            cmdAlbaran.Enabled = False
        End If
        If rdrCab("estado") = "E" Then
            cbEstado.Text = "ENVIADO"
        End If
        If rdrCab("estado") = "F" Then
            cbEstado.Text = "CONVERTIDO A FACTURA"
            cmdAlbaran.Enabled = False
            cmdPedido.Enabled = False
        End If
        cbEstado.Enabled = True

        rdrCab.Close()


        cmdCli = New MySqlCommand("SELECT * FROM clientes WHERE clienteID = '" + txNumcli.Text + "'", conexionmy)

        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        rdrCli = cmdCli.ExecuteReader
        rdrCli.Read()

        txNumcli.Text = rdrCli("clienteID")
        txClientepres.Text = rdrCli("nombre")
        txDtocli.Text = rdrCli("descuento")


        rdrCli.Close()

        conexionmy.Close()
        cargoEnvios()
    End Sub
    Public Sub cargoLineas()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT pedido_linea.linea,
                                            pedido_linea.codigo,
                                            pedido_linea.descripcion,
                                            pedido_linea.cantidad,
                                            pedido_linea.ancho_largo,
                                            pedido_linea.m2_ml,
                                            pedido_linea.precio,
                                            pedido_linea.descuento,
                                            pedido_linea.ivalinea,
                                            pedido_linea.importe,
                                            pedido_linea.totalinea,
                                            pedido_linea.lote,
                                            pedido_linea.num_pedido
                                            FROM pedido_linea WHERE num_pedido = '" + txtNumpres.Text + "' ORDER BY pedido_linea.linea", conexionmy)

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
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(11).Value = rdrLin("lote")
            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()

        recalcularTotales()
    End Sub

    Private Sub dgLineasPres2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "D"
            frVerArticulos.Show()
        End If
        If (e.ColumnIndex = 12) Then
            formArti = "D"
            vLotes = dgLineasPres2.CurrentRow.Cells(11).Value
            vReLote = dgLineasPres2.CurrentRow.Cells(2).Value
            'MsgBox(vReLote)
            frVerLotesM.Show()
        End If
        If (dgLineasPres2.CurrentRow.Index = 0) Then

        Else
            pos = dgLineasPres2.CurrentRow.Index
        End If
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
        If (e.ColumnIndex = 2) Then
            Dim vRef As String = dgLineasPres2.CurrentCell.Value
            cargarArticulos(vRef)
            actualizarLinea()
            recalcularTotales()
        End If
    End Sub
    Public Sub recalcularDescuentos()
        For Each row2 As DataGridViewRow In dgLineasPres2.Rows
            row2.Cells(8).Value = Decimal.Parse(txDtocli.Text).ToString("0.00")
            actualizarLinea()
        Next
        recalcularTotales()

    End Sub
    Private Sub descontarStock(codArti As String, unidades As Decimal)
        If codArti <> "" Then
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
        End If
    End Sub
    Private Sub aumentarStock(codArti As String, unidades As Decimal)
        If codArti <> "" Then
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
        End If
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
    Public Sub cargoEnvios()
        cbEnvio.ResetText()

        Dim cn As MySqlConnection
        Dim cm As MySqlCommand

        Dim da As MySqlDataAdapter
        Dim ds As DataSet
        cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        cn.Open()
        cm = New MySqlCommand("SELECT envioID, clienteID, localidad, provincia, concat_ws(' - ',cpostal, domicilio) AS direccion FROM envios WHERE clienteID = '" & txNumcli.Text & "'", cn)


        cm.CommandType = CommandType.Text
        cm.Connection = cn

        da = New MySqlDataAdapter(cm)
        ds = New DataSet()
        da.Fill(ds)


        cbEnvio.DataSource = ds.Tables(0)
        cbEnvio.DisplayMember = ds.Tables(0).Columns("direccion").ToString
        cbEnvio.ValueMember = "envioID"

        cn.Close()
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

    Private Sub dgLineasPres1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellLeave
        If (e.ColumnIndex = 8) Then
            tsBotones.Focus()
            cmdLineas.Select()
        End If
    End Sub

    Private Sub dgLineasPres2_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellLeave
        If (e.ColumnIndex = 8) Then
            tsBotones.Focus()
            cmdLineas.Select()
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

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim respuesta As String
        respuesta = MsgBox("El borrado de pedidos es una acción no recuperable. ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdEliminar As New MySqlCommand("DELETE FROM pedido_cab WHERE num_pedido = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

            Dim cmdEliminarLineas As New MySqlCommand("DELETE FROM pedido_linea WHERE num_pedido = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminarLineas.ExecuteNonQuery()

            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"

        End If
    End Sub

    Private Sub cmdPedido_Click(sender As Object, e As EventArgs) Handles cmdPedido.Click
        'Convertir Pedido en Albaran
        Dim respuesta As String
        respuesta = MsgBox("La conversión a Albarán no es reversible. Una vez convertido, el pedido será eliminado. ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            txNumpresBk.Text = txtNumpres.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand
            cmd.CommandType = System.Data.CommandType.Text


            cargoNumeroConversion("A")
            Dim vFecha As Date = txFecha.Text
            Dim vBruto As String = Replace(txImpBruto.Text.ToString, ",", ".")
            Dim vDto As String = Replace(txImpDto.Text.ToString, ",", ".")
            Dim vIva As String = Replace(txImpIva.Text.ToString, ",", ".")
            Dim vTotal As String = Replace(txTotalAlbaran.Text.ToString, ",", ".")

            cmd.CommandText = "INSERT INTO albaran_cab (num_albaran, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalalbaran, facturado, bultos, eliminado) VALUES (" + txtNumpres.Text + " , '1', " + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + vFecha.ToString("yyyy-MM-dd") + "', '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + vBruto + "', '" + vDto + "', '" + vIva + "', '" + vTotal + "', 'N', 0, 'N')"
            cmd.Connection = conexionmy
            cmd.ExecuteNonQuery()

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

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO albaran_linea (num_albaran, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, lote) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', '" + row.Cells(11).Value + "')"

                cmdLinea.ExecuteNonQuery()

            Next

            Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_albaran = '" + txtNumpres.Text + "'  ", conexionmy)
            cmdActualizar.ExecuteNonQuery()

            'Borro la cabecera y las lineas del presupuesto

            Dim cmdEliminar As New MySqlCommand("UPDATE pedido_cab SET estado = 'B' WHERE num_pedido = '" + txNumpresBk.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()


            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        Else
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub

    Private Sub cmdAlbaran_Click(sender As Object, e As EventArgs) Handles cmdAlbaran.Click
        'Convertir Pedido en Factura
        Dim respuesta As String
        respuesta = MsgBox("La conversión a Factura no es reversible. Una vez convertido, el pedido será eliminado. ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            txNumpresBk.Text = txtNumpres.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand
            cmd.CommandType = System.Data.CommandType.Text


            cargoNumeroConversion("F")
            Dim vFecha As Date = txFecha.Text
            Dim vBruto As String = Replace(txImpBruto.Text.ToString, ",", ".")
            Dim vDto As String = Replace(txImpDto.Text.ToString, ",", ".")
            Dim vIva As String = Replace(txImpIva.Text.ToString, ",", ".")
            Dim vTotal As String = Replace(txTotalAlbaran.Text.ToString, ",", ".")

            cmd.CommandText = "INSERT INTO factura_cab (num_factura, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalfactura, manual, eliminado) VALUES (" + txtNumpres.Text + " , '1', " + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + vFecha.ToString("yyyy-MM-dd") + "', '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + vBruto + "', '" + vDto + "', '" + vIva + "', '" + vTotal + "', 'S', 'N')"
            cmd.Connection = conexionmy
            cmd.ExecuteNonQuery()

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

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, lote) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', '" + row.Cells(11).Value + "')"

                cmdLinea.ExecuteNonQuery()

            Next

            Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura = '" + txtNumpres.Text + "'  ", conexionmy)
            cmdActualizar.ExecuteNonQuery()

            'Borro la cabecera y las lineas del presupuesto

            Dim cmdEliminar As New MySqlCommand("UPDATE pedido_cab SET estado = 'F' WHERE num_pedido = '" + txNumpresBk.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        Else
            cargoTodosPedidos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub
    Public Sub cargoNumeroConversion(tipoDoc As String)
        If tipoDoc = "A" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLastId As New MySqlCommand("SELECT num_albaran FROM configuracion  ", conexionmy)
            Dim numid As Int32

            numid = cmdLastId.ExecuteScalar()

            txtNumpres.Text = numid + 1

            conexionmy.Close()
        Else
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLastId As New MySqlCommand("SELECT num_factura FROM configuracion  ", conexionmy)
            Dim numid As Int32

            numid = cmdLastId.ExecuteScalar()

            txtNumpres.Text = numid + 1

            conexionmy.Close()

        End If

    End Sub

    Private Sub dgPedidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPedidos.CellDoubleClick
        limpiarFormulario()
        cmdLineas.Enabled = True
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdCliente.Enabled = True
        cmdPedido.Enabled = True
        cmdAlbaran.Enabled = True


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

    Private Sub dgLineasPres2_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgLineasPres2.CellBeginEdit
        If (e.ColumnIndex = 4) Or (e.ColumnIndex = 7) Or (e.ColumnIndex = 8) Then
            editNumber = "S"
        End If

    End Sub
    Public Sub cargoPediPendiente()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.estado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE estado = 'P' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
        dgPedidos.Columns(8).Visible = False
        dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPedidos.Visible = True
        conexionmy.Close()


    End Sub
    Public Sub cargoPediAlbaran()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.estado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE estado = 'B' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
        dgPedidos.Columns(8).Visible = False
        dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPedidos.Visible = True
        conexionmy.Close()

    End Sub
    Public Sub cargoPediFactura()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()

        Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.estado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE estado = 'F' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
        dgPedidos.Columns(8).Visible = False
        dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPedidos.Visible = True
        conexionmy.Close()
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked = True Then
            cargoTodosPedidos()
        End If
    End Sub

    Private Sub rbPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPendientes.CheckedChanged
        If rbPendientes.Checked = True Then
            cargoPediPendiente()
        End If
    End Sub

    Private Sub rbAceptados_CheckedChanged(sender As Object, e As EventArgs) Handles rbAceptados.CheckedChanged
        If rbAceptados.Checked = True Then
            cargoPediAlbaran()
        End If
    End Sub

    Private Sub rbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbFactura.CheckedChanged
        If rbFactura.Checked = True Then
            cargoPediFactura()
        End If
    End Sub

    Private Sub txCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()

            Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.eliminado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE clientes.nombre LIKE'%" & txCliente.Text & "%' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
            dgPedidos.Columns(8).Visible = False
            dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgPedidos.Visible = True
            conexionmy.Close()

        End If
    End Sub

    Private Sub txNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()

            Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.eliminado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE pedido_cab.num_pedido LIKE '" & txNumero.Text & "%' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
            dgPedidos.Columns(8).Visible = False
            dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgPedidos.Visible = True
            conexionmy.Close()

        End If
    End Sub

    Private Sub txReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()

            Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.eliminado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE pedido_cab.referencia LIKE'%" & txReferencia.Text & "%' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
            dgPedidos.Columns(8).Visible = False
            dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgPedidos.Visible = True
            conexionmy.Close()

        End If
    End Sub

    Private Sub txHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txHasta.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim fec1 As Date = txDesde.Text
            Dim fec2 As Date = txHasta.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()

            Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.eliminado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE DATE(pedido_cab.fecha) BETWEEN '" & fec1.ToString("yyyy-MM-dd") & "' AND '" & fec2.ToString("yyyy-MM-dd") & "' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
            dgPedidos.Columns(8).Visible = False
            dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgPedidos.Visible = True
            conexionmy.Close()

        End If
    End Sub

    Private Sub txGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles txGeneral.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()

            Dim consultamy As New MySqlCommand("SELECT pedido_cab.num_pedido, 
                                                    pedido_cab.referencia,
                                                    pedido_cab.fecha, 
                                                    clientes.nombre, 
                                                    pedido_cab.totalbruto, 
                                                    pedido_cab.totalpedido, 
                                                    pedido_cab.clienteID,
                                                    pedido_cab.eliminado, 
                                                    clientes.clienteID 
                                            FROM pedido_cab INNER JOIN clientes ON pedido_cab.clienteID=clientes.clienteID WHERE pedido_cab.referencia LIKE'%" & txReferencia.Text & "%' ORDER BY pedido_cab.num_pedido DESC", conexionmy)

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
            dgPedidos.Columns(8).Visible = False
            dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgPedidos.Visible = True
            conexionmy.Close()

        End If
    End Sub
End Class