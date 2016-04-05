Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frFacturaManual
    Public Shared lineas As Int16
    Public Shared pos As Integer
    Public Shared flagEdit As String = "N"
    Public Shared lineasEdit As New List(Of lineasEditadas)
    Public Shared lineasElim As New List(Of lineasEliminadas)
    Public Shared artiEdit As String
    Public Shared cantIni As Decimal
    Public Shared cantFin As Decimal
    Public Shared serieIni As String
    Public Shared fechadiapago As Date
    Public Shared vtosEdit As New List(Of vtosEditados)
    Public Shared newLinea As String = "N"
    Public Shared editNumber As String = "N"
    Private Sub frFacturaManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deshabilitarBotones()
        grPlazos.Visible = False


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
    Public Sub cargoTodasFacturas()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE eliminado = 'N' ORDER BY factura_cab.num_factura DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgFacturas.DataSource = bind
        dgFacturas.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

        dgFacturas.Columns(0).HeaderText = "NUMERO"
        dgFacturas.Columns(0).Name = "Column1"
        dgFacturas.Columns(0).FillWeight = 90
        dgFacturas.Columns(0).MinimumWidth = 90
        dgFacturas.Columns(1).HeaderText = "REFERENCIA"
        dgFacturas.Columns(1).Name = "Column2"
        dgFacturas.Columns(1).FillWeight = 190
        dgFacturas.Columns(1).MinimumWidth = 190
        dgFacturas.Columns(2).HeaderText = "FECHA"
        dgFacturas.Columns(2).Name = "Column3"
        dgFacturas.Columns(2).FillWeight = 90
        dgFacturas.Columns(2).MinimumWidth = 90
        dgFacturas.Columns(3).HeaderText = "CLIENTE"
        dgFacturas.Columns(3).Name = "Column4"
        dgFacturas.Columns(3).FillWeight = 300
        dgFacturas.Columns(3).MinimumWidth = 300
        dgFacturas.Columns(4).HeaderText = "IMPORTE"
        dgFacturas.Columns(4).Name = "Column5"
        dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(4).FillWeight = 90
        dgFacturas.Columns(4).MinimumWidth = 90
        dgFacturas.Columns(5).HeaderText = "TOTAL"
        dgFacturas.Columns(5).Name = "Column6"
        dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(5).FillWeight = 90
        dgFacturas.Columns(5).MinimumWidth = 90
        dgFacturas.Columns(6).Visible = False
        dgFacturas.Columns(7).Visible = False
        dgFacturas.Columns(8).Visible = False
        dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgFacturas.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub limpiarFormulario()
        txtNumpres.Text = ""
        txFecha.Text = ""
        txReferenciapres.Text = ""
        txNumcli.Text = ""
        txClientepres.Text = ""
        txAgente.Text = ""
        txRecargo.Text = ""
        txDtocli.Text = ""
        txIva.Text = "21.00"
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
        grPlazos.Visible = False

    End Sub

    Private Sub cmdLineas_ButtonClick(sender As Object, e As EventArgs) Handles cmdLineas.ButtonClick

        newLinea = "S"
        If txNumcli.Text = "" Then
            MsgBox("Antes de añadir líneas a la factura es necesario seleccionar un cliente")
            formCli = "F"
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
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(4).Value = 1
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(7).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(8).Value = txDtocli.Text
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(9).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(10).Value = 0
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
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = 1
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(7).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(8).Value = txDtocli.Text
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(9).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(10).Value = 0
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

            dgLineasPres1.CurrentRow.Cells(4).Value = 1
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
                    MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
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
        formCli = "F"
        frVerClientes.Show()
    End Sub

    Private Sub dgLineasPres1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "F"
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
        dgLineasPres1.Visible = True
        dgLineasPres1.Enabled = True
        cbSerie.Text = "S1"
        'cbEstado.Text = "NO FACTURADO"
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
        Dim vSerie As String
        If cbSerie.Text = "S1" Then
            vSerie = "1"
        Else
            vSerie = "2"
        End If
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

            'Guardo cabecera y actualizo número de presupuesto
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand("INSERT INTO factura_cab (num_factura, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalfactura, manual, formapago) VALUES (" + txtNumpres.Text + ", '" + vSerie + "'," + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', 'S', " + cbFormapago.SelectedValue.ToString + ")", conexionmy)
            cmd.ExecuteNonQuery()
            If cbSerie.Text = "S1" Then
                Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura = '" + txtNumpres.Text + "'", conexionmy)
                cmdActualizar.ExecuteNonQuery()
            Else
                Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura_2 = '" + txtNumpres.Text + "'", conexionmy)
                cmdActualizar.ExecuteNonQuery()
            End If


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
            Dim vLote As String


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
                cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "')"

                cmdLinea.ExecuteNonQuery()
                descontarStock(arti, lincant)

            Next

            conexionmy.Close()

            grabarVencimientos()

            deshabilitarBotones()
            limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodasFacturas()
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

            'Guardo cabecera y actualizo número de presupuesto

            If vSerie = serieIni Then
                Dim cmd As New MySqlCommand("UPDATE factura_cab SET fecha = '" + fecha.ToString("yyyy-MM-dd") + "', clienteID = " + txNumcli.Text + ", agenteID = " + txAgente.Text + ", referencia = '" + txReferenciapres.Text + "', observaciones = '" + txObserva.Text + "', totalbruto = '" + guardo_impbru + "', totaldto = '" + guardo_impdto + "', totaliva = '" + guardo_impiva + "', totalrecargo = '" + guardo_imprec + "', totalfactura = '" + guardo_imptot + "', serie = '" + vSerie + "', formapago = '" + cbFormapago.SelectedIndex.ToString + "' WHERE num_factura = " + txtNumpres.Text + "", conexionmy)
                cmd.ExecuteNonQuery()

            Else
                Dim cmdEliminarLin As New MySqlCommand("DELETE FROM factura_linea WHERE num_factura = '" + txtNumpres.Text + "'", conexionmy)
                cmdEliminarLin.ExecuteNonQuery()
                Dim cmdEliminarCab As New MySqlCommand("DELETE FROM factura_cab WHERE num_factura = '" + txtNumpres.Text + "'", conexionmy)
                cmdEliminarCab.ExecuteNonQuery()
                cargoNumero()
                Dim cmd As New MySqlCommand("INSERT INTO factura_cab (num_factura, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalfactura, manual) VALUES (" + txtNumpres.Text + ", '" + vSerie + "'," + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', 'S')", conexionmy)
                cmd.ExecuteNonQuery()
                If cbSerie.Text = "S1" Then
                    Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura = '" + txtNumpres.Text + "'", conexionmy)
                    cmdActualizar.ExecuteNonQuery()
                Else
                    Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura_2 = '" + txtNumpres.Text + "'", conexionmy)
                    cmdActualizar.ExecuteNonQuery()
                End If

            End If

            Dim cmdEliminar As New MySqlCommand("DELETE FROM factura_linea WHERE num_factura = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

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
            Dim vLote As String

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
                cmdLinea.CommandText = "INSERT INTO factura_linea (num_factura, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "')"

                cmdLinea.ExecuteNonQuery()


            Next

            conexionmy.Close()

            If lineasEdit.Count > 0 Then
                For Each itemlineas As lineasEditadas In lineasEdit
                    If row.Cells(11).Value = "" Then
                        aumentarStock(itemlineas.codigoArt, itemlineas.cantAntes)
                        descontarStock(itemlineas.codigoArt, itemlineas.cantDespues)
                    Else
                        vLote = row.Cells(11).Value
                        aumentarStockLote(itemlineas.codigoArt, itemlineas.cantAntes)
                        descontarStockLote(itemlineas.codigoArt, itemlineas.cantDespues)
                    End If

                Next
            End If

            lineasEdit.Clear()


            deshabilitarBotones()
            limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodasFacturas()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub
    Public Sub cargoNumero()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim numid As Int32

        If cbSerie.Text = "S1" Then
            Dim cmdLastId As New MySqlCommand("SELECT num_factura FROM configuracion  ", conexionmy)
            numid = cmdLastId.ExecuteScalar()
        Else
            Dim cmdLastId As New MySqlCommand("SELECT num_factura_2 FROM configuracion  ", conexionmy)
            numid = cmdLastId.ExecuteScalar()
        End If

        txtNumpres.Text = numid + 1

        conexionmy.Close()

    End Sub
    Public Sub cargoFactura()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCab As New MySqlCommand

        Dim cmdCli As New MySqlCommand

        Dim rdrCab As MySqlDataReader

        Dim rdrCli As MySqlDataReader

        Dim vForma As Int16

        cmdCab = New MySqlCommand("SELECT * FROM factura_cab WHERE num_factura = '" + txtNumpres.Text + "'", conexionmy)

        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        rdrCab.Read()
        txFecha.Text = rdrCab("fecha")
        txNumcli.Text = rdrCab("clienteID")
        txAgente.Text = rdrCab("agenteID")
        txReferenciapres.Text = rdrCab("referencia")
        txObserva.Text = rdrCab("observaciones")

        If rdrCab("serie") = "1" Then
            cbSerie.Text = "S1"
            serieIni = "1"
        Else
            cbSerie.Text = "S2"
            serieIni = "2"
        End If

        cargoFormaPago()
        vForma = rdrCab("formapago")

        Select Case vForma
            Case 1
                cbFormapago.SelectedIndex = 0
            Case 2
                cbFormapago.SelectedIndex = 1
            Case 3
                cbFormapago.SelectedIndex = 2
            Case 4
                cbFormapago.SelectedIndex = 3
            Case 5
                cbFormapago.SelectedIndex = 4
            Case 6
                cbFormapago.SelectedIndex = 5
            Case 7
                cbFormapago.SelectedIndex = 6
            Case 8
                cbFormapago.SelectedIndex = 7
            Case 9
                cbFormapago.SelectedIndex = 8
        End Select

        btRecalcular.Enabled = False
        cargarVencimientos()

        rdrCab.Close()


        cmdCli = New MySqlCommand("SELECT * FROM clientes WHERE clienteID = '" + txNumcli.Text + "'", conexionmy)

        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        rdrCli = cmdCli.ExecuteReader
        rdrCli.Read()

        txNumcli.Text = rdrCli("clienteID")
        txClientepres.Text = rdrCli("nombre")
        txDtocli.Text = rdrCli("descuento")
        txDiapago.Text = rdrCli("diapago")
        rdrCli.Close()

        conexionmy.Close()
        cargoEnvios()
    End Sub
    Public Sub cargoLineas()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT factura_linea.linea,
                                            factura_linea.codigo,
                                            factura_linea.descripcion,
                                            factura_linea.cantidad,
                                            factura_linea.ancho_largo,
                                            factura_linea.m2_ml,
                                            factura_linea.precio,
                                            factura_linea.descuento,
                                            factura_linea.ivalinea,
                                            factura_linea.importe,
                                            factura_linea.totalinea,
                                            factura_linea.lote,
                                            factura_linea.num_factura
                                            FROM factura_linea WHERE num_factura = '" + txtNumpres.Text + "' ORDER BY factura_linea.linea", conexionmy)

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
            formArti = "F"
            frVerArticulos.Show()
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
    Public Sub descontarStock(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLastId As New MySqlCommand("SELECT ref_proveedor, stock FROM articulos2 WHERE ref_proveedor = '" + codArti + "'", conexionmy)
            Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
            reader.Read()

            Dim stock As String = (reader.GetString(1) - unidades).ToString
            reader.Close()

            Dim cmdActualizo As New MySqlCommand("UPDATE articulos2 SET stock = '" + stock + "' WHERE ref_proveedor = '" + codArti + "'", conexionmy)
            cmdActualizo.ExecuteNonQuery()

            conexionmy.Close()
        End If
    End Sub
    Public Sub aumentarStock(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLastId As New MySqlCommand("SELECT ref_proveedor, stock FROM articulos2 WHERE ref_proveedor = '" + codArti + "'", conexionmy)
            Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
            reader.Read()

            Dim stock As String = (reader.GetString(1) + unidades).ToString
            reader.Close()

            Dim cmdActualizo As New MySqlCommand("UPDATE articulos2 SET stock = '" + stock + "' WHERE ref_proveedor = '" + codArti + "'", conexionmy)
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

    Private Sub btRecalcular_Click(sender As Object, e As EventArgs) Handles btRecalcular.Click
        grPlazos.Visible = True
        recalcularPlazos()
        btActualizar.Enabled = True

    End Sub

    Private Sub cmdMostrarAgente_Click(sender As Object, e As EventArgs) Handles cmdMostrarAgente.Click
        grPlazos.Visible = True
        btActualizar.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        grPlazos.Visible = False

    End Sub
    Public Sub recalcularPlazos()
        'Recalcular lo plazos de pago y el grid con los vencimientos
        dgPlazos.Rows.Clear()

        If txDiapago.Text = "" Then
            MsgBox("Para calcular los vencimientos es necesario introducir un día de pago")
        Else
            Dim vDia As String
            Dim vMes As String
            Dim vYear As String
            Dim vFechahoy As String = txFecha.Text



            vDia = txDiapago.Text
            vMes = vFechahoy.Substring(3, 2)
            vYear = vFechahoy.Substring(6, 4)
            fechadiapago = vDia + "/" + vMes + "/" + vYear


            If cbFormapago.SelectedValue = 1 Then
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = txFecha.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red
            End If
            If cbFormapago.SelectedValue = 2 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red
            End If
            If cbFormapago.SelectedValue = 3 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red
            End If
            If cbFormapago.SelectedValue = 4 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo As Date = DateAdd(DateInterval.Month, 3, fechahoy)
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red
            End If
            If cbFormapago.SelectedValue = 5 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo1 As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                Dim fechaplazo2 As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                Dim vImportePlazo As Decimal
                vImportePlazo = Decimal.Parse(txTotalAlbaran.Text) / 2

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo1.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red
            End If
            If cbFormapago.SelectedValue = 6 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo1 As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                Dim fechaplazo2 As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                Dim fechaplazo3 As Date = DateAdd(DateInterval.Month, 3, fechahoy)
                Dim vImportePlazo As Decimal
                vImportePlazo = Decimal.Parse(txTotalAlbaran.Text) / 3

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo1.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

            End If
            If cbFormapago.SelectedValue = 7 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo1 As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                Dim fechaplazo2 As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                Dim fechaplazo3 As Date = DateAdd(DateInterval.Month, 3, fechahoy)
                Dim fechaplazo4 As Date = DateAdd(DateInterval.Month, 4, fechahoy)
                Dim vImportePlazo As Decimal
                vImportePlazo = Decimal.Parse(txTotalAlbaran.Text) / 4

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo1.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo4.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

            End If
            If cbFormapago.SelectedValue = 8 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo1 As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                Dim fechaplazo2 As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                Dim fechaplazo3 As Date = DateAdd(DateInterval.Month, 3, fechahoy)
                Dim fechaplazo4 As Date = DateAdd(DateInterval.Month, 4, fechahoy)
                Dim fechaplazo5 As Date = DateAdd(DateInterval.Month, 5, fechahoy)
                Dim vImportePlazo As Decimal
                vImportePlazo = Decimal.Parse(txTotalAlbaran.Text) / 5

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo1.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo4.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo5.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

            End If
            If cbFormapago.SelectedValue = 9 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo1 As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                Dim fechaplazo2 As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                Dim fechaplazo3 As Date = DateAdd(DateInterval.Month, 3, fechahoy)
                Dim fechaplazo4 As Date = DateAdd(DateInterval.Month, 4, fechahoy)
                Dim fechaplazo5 As Date = DateAdd(DateInterval.Month, 5, fechahoy)
                Dim fechaplazo6 As Date = DateAdd(DateInterval.Month, 6, fechahoy)
                Dim vImportePlazo As Decimal
                vImportePlazo = Decimal.Parse(txTotalAlbaran.Text) / 6

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo1.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo4.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo5.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo6.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. referencia:" + txReferenciapres.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red

            End If
        End If
        recalcularPendiente()
    End Sub
    Public Sub grabarVencimientos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim vPagado As String
        Dim orden As Int16 = 0
        Dim linImporte As String
        Dim vtoRow As New DataGridViewRow


        If ckPagado.Checked = True Then
            vPagado = "S"
        Else
            vPagado = "N"
        End If

        For Each vtoRow In dgPlazos.Rows
            orden = orden + 1

            Dim vVtoPagado As String
            Dim fecha As Date = vtoRow.Cells(0).Value
            linImporte = vtoRow.Cells(2).Value.ToString

            If vtoRow.Cells(3).Style.BackColor = Color.Red Then
                vVtoPagado = "N"
            Else
                vVtoPagado = "S"
            End If

            Dim cmd As New MySqlCommand("INSERT INTO vto_cobros (documentoID, tipodoc, concepto, vencimiento, importe, orden, pagado) VALUES (" + txtNumpres.Text + ", 'F', '" + vtoRow.Cells(1).Value + "', '" + fecha.ToString("yyyy-MM-dd") + "', '" + linImporte + "', '" + orden.ToString + "', '" + vVtoPagado + "')", conexionmy)
            cmd.ExecuteNonQuery()
        Next
        conexionmy.Close()

    End Sub

    Private Sub ckPagado_CheckedChanged(sender As Object, e As EventArgs) Handles ckPagado.CheckedChanged
        If ckPagado.Checked = True Then
            cbFormapago.SelectedIndex = 0
            Dim vFechahoy As String = txFecha.Text
            Dim vDia As String
            vDia = vFechahoy.Substring(0, 2)
            txDiapago.Text = vDia
            dgPlazos.Rows.Clear()
            recalcularPlazos()
            cbFormapago.Enabled = False
            txDiapago.Enabled = False
        Else
            cbFormapago.Enabled = True
            txDiapago.Enabled = True
        End If
    End Sub

    Private Sub dgFacturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFacturas.CellDoubleClick
        limpiarFormulario()
        cmdLineas.Enabled = True
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdCliente.Enabled = True

        txtNumpres.Text = dgFacturas.CurrentRow.Cells("Column1").Value.ToString
        tabPresupuestos.SelectTab(1)
        flagEdit = "S"
        dgLineasPres1.Visible = False
        dgLineasPres2.Visible = True
        dgLineasPres2.Rows.Clear()


        cargoFactura()
        cargoLineas()
        cmdDelete.Enabled = True
        recalcularTotales()
    End Sub
    Public Sub cargoFormaPago()
        cbFormapago.ResetText()

        Dim cn As MySqlConnection
        Dim cm As MySqlCommand

        Dim da As MySqlDataAdapter
        Dim ds As DataSet
        cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        cn.Open()
        cm = New MySqlCommand("SELECT formaID, formapago FROM formapago", cn)


        cm.CommandType = CommandType.Text
        cm.Connection = cn

        da = New MySqlDataAdapter(cm)
        ds = New DataSet()
        da.Fill(ds)


        cbFormapago.DataSource = ds.Tables(0)
        cbFormapago.DisplayMember = ds.Tables(0).Columns("formapago").ToString
        cbFormapago.ValueMember = "formaID"

        cn.Close()
    End Sub

    Private Sub cbFormapago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFormapago.SelectedIndexChanged
        btRecalcular.Enabled = True

    End Sub
    Public Sub editarVencimientos()

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        'Eliminar plazos anteriores
        Dim cmdEliminar As New MySqlCommand("DELETE FROM vto_cobros WHERE documentoID = '" + txtNumpres.Text + "'", conexionmy)
        cmdEliminar.ExecuteNonQuery()


        'Grabar nuevos vencimientos
        grabarVencimientos()


    End Sub
    Public Sub cargarVencimientos()
        dgPlazos.Rows.Clear()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCli As New MySqlCommand
        Dim rdrArt As MySqlDataReader
        cmdCli = New MySqlCommand("SELECT * FROM vto_cobros WHERE tipodoc = 'F' AND documentoID = '" & txtNumpres.Text & "' ORDER BY orden", conexionmy)
        Dim vtoRow As New DataGridViewRow
        Dim vPendiente As Decimal = 0


        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        rdrArt = cmdCli.ExecuteReader
        'rdrArt.Read()

        If rdrArt.HasRows = True Then
            Do While rdrArt.Read()
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = rdrArt("vencimiento")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = rdrArt("concepto")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = rdrArt("importe")
                If rdrArt("pagado") = "N" Then
                    dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Red
                    vPendiente = vPendiente + rdrArt("importe")
                Else
                    dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(3).Style.BackColor = Color.Green
                End If
            Loop

        Else
            MsgBox("No se han registrado vencimientos")
        End If
        txPendiente.Text = vPendiente

        Dim varLinea As Int16 = 0
        Dim varFactura As String
        Dim varVto As Date
        Dim varConcepto As String
        Dim varImporte As Decimal
        Dim varPagado As String

        For Each vtoRow In dgPlazos.Rows
            varLinea = varLinea + 1
            varFactura = txtNumpres.Text
            varVto = vtoRow.Cells(0).Value.ToString
            varConcepto = vtoRow.Cells(1).Value
            varImporte = vtoRow.Cells(2).Value
            If vtoRow.Cells(3).Style.BackColor = Color.Red Then
                varPagado = "N"
            Else
                varPagado = "S"
            End If

            vtosEdit.Add(New vtosEditados() With {.vtoLinea = varLinea, .vtoFactura = varFactura, .vtoVencimiento = varVto, .vtoConcepto = varConcepto, .vtoImporte = varImporte, .vtoPagado = varPagado})
        Next

        rdrArt.Close()

        conexionmy.Close()

    End Sub

    Private Sub dgPlazos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPlazos.CellDoubleClick
        If (e.ColumnIndex = 3) Then
            If dgPlazos.CurrentRow.Cells(3).Style.BackColor = Color.Red Then
                dgPlazos.CurrentRow.Cells(3).Style.BackColor = Color.Green
                recalcularPendiente()
                btActualizar.Enabled = True
            Else
                dgPlazos.CurrentRow.Cells(3).Style.BackColor = Color.Red
            End If
        End If
    End Sub
    Public Sub recalcularPendiente()
        Dim vPendiente As Decimal = 0
        Dim vtoRow As New DataGridViewRow
        Dim varImporte As Decimal = 0

        For Each vtoRow In dgPlazos.Rows
            If vtoRow.Cells(3).Style.BackColor = Color.Red Then
                varImporte = varImporte + vtoRow.Cells(2).Value
            End If
        Next
        txPendiente.Text = varImporte
    End Sub

    Private Sub btActualizar_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        editarVencimientos()
        btActualizar.Enabled = False
        grPlazos.Visible = False
    End Sub
    Public Sub eliminarFacturaEditStock()


        Dim row As New DataGridViewRow
        For Each row In dgLineasPres2.Rows
            artiEdit = row.Cells(2).Value
            cantIni = Decimal.Parse(row.Cells(4).Value)
            'MsgBox(cantIni)
            'lineasElim.Add(New lineasEliminadas() With {.codigoArtDel = artiEdit, .cantAntesDel = cantIni})
            If row.Cells(11).Value = "" Then
                aumentarStock(artiEdit, cantIni)
            Else
                aumentarStockLote(artiEdit, cantIni)
            End If
        Next
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim respuesta As String
        respuesta = MsgBox("El borrado de facturas es una acción no recuperable. ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdEliminar As New MySqlCommand("DELETE FROM factura_cab WHERE num_factura = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

            eliminarFacturaEditStock()

            Dim cmdEliminarLineas As New MySqlCommand("DELETE FROM factura_linea WHERE num_factura = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminarLineas.ExecuteNonQuery()

            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodasFacturas()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"

        End If
    End Sub
    Public Sub descontarStockLote(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLastId As New MySqlCommand("SELECT referencia, stock, lote FROM lotes WHERE lote = '" + codArti + "'", conexionmy)
            Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
            reader.Read()

            Dim stock As String = (reader.GetString(1) - unidades).ToString
            reader.Close()

            Dim cmdActualizo As New MySqlCommand("UPDATE lotes SET stock = '" + stock + "' WHERE lote = '" + codArti + "'", conexionmy)
            cmdActualizo.ExecuteNonQuery()

            conexionmy.Close()
        End If

    End Sub
    Public Sub aumentarStockLote(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdLastId As New MySqlCommand("SELECT referencia, stock, lote FROM lotes WHERE lote = '" + codArti + "'", conexionmy)
            Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
            reader.Read()

            Dim stock As String = (reader.GetString(1) + unidades).ToString
            reader.Close()

            Dim cmdActualizo As New MySqlCommand("UPDATE lotes SET stock = '" + stock + "' WHERE lote = '" + codArti + "'", conexionmy)
            cmdActualizo.ExecuteNonQuery()

            conexionmy.Close()
        End If

    End Sub

    Private Sub dgLineasPres2_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgLineasPres2.CellBeginEdit
        If (e.ColumnIndex = 4) Or (e.ColumnIndex = 7) Or (e.ColumnIndex = 8) Then
            editNumber = "S"
        End If
    End Sub
    Public Sub cargoFactuManual()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.manual, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE manual = 'S' ORDER BY factura_cab.num_factura DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgFacturas.DataSource = bind
        dgFacturas.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

        dgFacturas.Columns(0).HeaderText = "NUMERO"
        dgFacturas.Columns(0).Name = "Column1"
        dgFacturas.Columns(0).FillWeight = 90
        dgFacturas.Columns(0).MinimumWidth = 90
        dgFacturas.Columns(1).HeaderText = "REFERENCIA"
        dgFacturas.Columns(1).Name = "Column2"
        dgFacturas.Columns(1).FillWeight = 190
        dgFacturas.Columns(1).MinimumWidth = 190
        dgFacturas.Columns(2).HeaderText = "FECHA"
        dgFacturas.Columns(2).Name = "Column3"
        dgFacturas.Columns(2).FillWeight = 90
        dgFacturas.Columns(2).MinimumWidth = 90
        dgFacturas.Columns(3).HeaderText = "CLIENTE"
        dgFacturas.Columns(3).Name = "Column4"
        dgFacturas.Columns(3).FillWeight = 300
        dgFacturas.Columns(3).MinimumWidth = 300
        dgFacturas.Columns(4).HeaderText = "IMPORTE"
        dgFacturas.Columns(4).Name = "Column5"
        dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(4).FillWeight = 90
        dgFacturas.Columns(4).MinimumWidth = 90
        dgFacturas.Columns(5).HeaderText = "TOTAL"
        dgFacturas.Columns(5).Name = "Column6"
        dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(5).FillWeight = 90
        dgFacturas.Columns(5).MinimumWidth = 90
        dgFacturas.Columns(6).Visible = False
        dgFacturas.Columns(7).Visible = False
        dgFacturas.Columns(8).Visible = False
        dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgFacturas.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub cargoFactuAuto()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.manual, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE manual = 'N' ORDER BY factura_cab.num_factura DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgFacturas.DataSource = bind
        dgFacturas.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

        dgFacturas.Columns(0).HeaderText = "NUMERO"
        dgFacturas.Columns(0).Name = "Column1"
        dgFacturas.Columns(0).FillWeight = 90
        dgFacturas.Columns(0).MinimumWidth = 90
        dgFacturas.Columns(1).HeaderText = "REFERENCIA"
        dgFacturas.Columns(1).Name = "Column2"
        dgFacturas.Columns(1).FillWeight = 190
        dgFacturas.Columns(1).MinimumWidth = 190
        dgFacturas.Columns(2).HeaderText = "FECHA"
        dgFacturas.Columns(2).Name = "Column3"
        dgFacturas.Columns(2).FillWeight = 90
        dgFacturas.Columns(2).MinimumWidth = 90
        dgFacturas.Columns(3).HeaderText = "CLIENTE"
        dgFacturas.Columns(3).Name = "Column4"
        dgFacturas.Columns(3).FillWeight = 300
        dgFacturas.Columns(3).MinimumWidth = 300
        dgFacturas.Columns(4).HeaderText = "IMPORTE"
        dgFacturas.Columns(4).Name = "Column5"
        dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(4).FillWeight = 90
        dgFacturas.Columns(4).MinimumWidth = 90
        dgFacturas.Columns(5).HeaderText = "TOTAL"
        dgFacturas.Columns(5).Name = "Column6"
        dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(5).FillWeight = 90
        dgFacturas.Columns(5).MinimumWidth = 90
        dgFacturas.Columns(6).Visible = False
        dgFacturas.Columns(7).Visible = False
        dgFacturas.Columns(8).Visible = False
        dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgFacturas.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub cargoFactuAbonos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.manual, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE manual = 'A' ORDER BY factura_cab.num_factura DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()


        readermy = consultamy.ExecuteReader
        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgFacturas.DataSource = bind
        dgFacturas.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

        dgFacturas.Columns(0).HeaderText = "NUMERO"
        dgFacturas.Columns(0).Name = "Column1"
        dgFacturas.Columns(0).FillWeight = 90
        dgFacturas.Columns(0).MinimumWidth = 90
        dgFacturas.Columns(1).HeaderText = "REFERENCIA"
        dgFacturas.Columns(1).Name = "Column2"
        dgFacturas.Columns(1).FillWeight = 190
        dgFacturas.Columns(1).MinimumWidth = 190
        dgFacturas.Columns(2).HeaderText = "FECHA"
        dgFacturas.Columns(2).Name = "Column3"
        dgFacturas.Columns(2).FillWeight = 90
        dgFacturas.Columns(2).MinimumWidth = 90
        dgFacturas.Columns(3).HeaderText = "CLIENTE"
        dgFacturas.Columns(3).Name = "Column4"
        dgFacturas.Columns(3).FillWeight = 300
        dgFacturas.Columns(3).MinimumWidth = 300
        dgFacturas.Columns(4).HeaderText = "IMPORTE"
        dgFacturas.Columns(4).Name = "Column5"
        dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(4).FillWeight = 90
        dgFacturas.Columns(4).MinimumWidth = 90
        dgFacturas.Columns(5).HeaderText = "TOTAL"
        dgFacturas.Columns(5).Name = "Column6"
        dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgFacturas.Columns(5).FillWeight = 90
        dgFacturas.Columns(5).MinimumWidth = 90
        dgFacturas.Columns(6).Visible = False
        dgFacturas.Columns(7).Visible = False
        dgFacturas.Columns(8).Visible = False
        dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgFacturas.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked = True Then
            cargoTodasFacturas()
        End If
    End Sub

    Private Sub rbPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPendientes.CheckedChanged
        If rbPendientes.Checked = True Then
            cargoFactuAbonos()
        End If
    End Sub

    Private Sub rbManual_CheckedChanged(sender As Object, e As EventArgs) Handles rbManual.CheckedChanged
        If rbManual.Checked = True Then
            cargoFactuManual()
        End If
    End Sub

    Private Sub rbAutomaticas_CheckedChanged(sender As Object, e As EventArgs) Handles rbAutomaticas.CheckedChanged
        If rbAutomaticas.Checked = True Then
            cargoFactuAuto()
        End If
    End Sub

    Private Sub txCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE clientes.nombre LIKE'%" & txCliente.Text & "%' ORDER BY factura_cab.num_factura DESC", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()


            readermy = consultamy.ExecuteReader
            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgFacturas.DataSource = bind
            dgFacturas.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

            dgFacturas.Columns(0).HeaderText = "NUMERO"
            dgFacturas.Columns(0).Name = "Column1"
            dgFacturas.Columns(0).FillWeight = 90
            dgFacturas.Columns(0).MinimumWidth = 90
            dgFacturas.Columns(1).HeaderText = "REFERENCIA"
            dgFacturas.Columns(1).Name = "Column2"
            dgFacturas.Columns(1).FillWeight = 190
            dgFacturas.Columns(1).MinimumWidth = 190
            dgFacturas.Columns(2).HeaderText = "FECHA"
            dgFacturas.Columns(2).Name = "Column3"
            dgFacturas.Columns(2).FillWeight = 90
            dgFacturas.Columns(2).MinimumWidth = 90
            dgFacturas.Columns(3).HeaderText = "CLIENTE"
            dgFacturas.Columns(3).Name = "Column4"
            dgFacturas.Columns(3).FillWeight = 300
            dgFacturas.Columns(3).MinimumWidth = 300
            dgFacturas.Columns(4).HeaderText = "IMPORTE"
            dgFacturas.Columns(4).Name = "Column5"
            dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(4).FillWeight = 90
            dgFacturas.Columns(4).MinimumWidth = 90
            dgFacturas.Columns(5).HeaderText = "TOTAL"
            dgFacturas.Columns(5).Name = "Column6"
            dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(5).FillWeight = 90
            dgFacturas.Columns(5).MinimumWidth = 90
            dgFacturas.Columns(6).Visible = False
            dgFacturas.Columns(7).Visible = False
            dgFacturas.Columns(8).Visible = False
            dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgFacturas.Visible = True

            conexionmy.Close()
        End If
    End Sub

    Private Sub txNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE factura_cab.num_factura LIKE '" & txNumero.Text & "%' ORDER BY factura_cab.num_factura DESC", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()


            readermy = consultamy.ExecuteReader
            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgFacturas.DataSource = bind
            dgFacturas.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

            dgFacturas.Columns(0).HeaderText = "NUMERO"
            dgFacturas.Columns(0).Name = "Column1"
            dgFacturas.Columns(0).FillWeight = 90
            dgFacturas.Columns(0).MinimumWidth = 90
            dgFacturas.Columns(1).HeaderText = "REFERENCIA"
            dgFacturas.Columns(1).Name = "Column2"
            dgFacturas.Columns(1).FillWeight = 190
            dgFacturas.Columns(1).MinimumWidth = 190
            dgFacturas.Columns(2).HeaderText = "FECHA"
            dgFacturas.Columns(2).Name = "Column3"
            dgFacturas.Columns(2).FillWeight = 90
            dgFacturas.Columns(2).MinimumWidth = 90
            dgFacturas.Columns(3).HeaderText = "CLIENTE"
            dgFacturas.Columns(3).Name = "Column4"
            dgFacturas.Columns(3).FillWeight = 300
            dgFacturas.Columns(3).MinimumWidth = 300
            dgFacturas.Columns(4).HeaderText = "IMPORTE"
            dgFacturas.Columns(4).Name = "Column5"
            dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(4).FillWeight = 90
            dgFacturas.Columns(4).MinimumWidth = 90
            dgFacturas.Columns(5).HeaderText = "TOTAL"
            dgFacturas.Columns(5).Name = "Column6"
            dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(5).FillWeight = 90
            dgFacturas.Columns(5).MinimumWidth = 90
            dgFacturas.Columns(6).Visible = False
            dgFacturas.Columns(7).Visible = False
            dgFacturas.Columns(8).Visible = False
            dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgFacturas.Visible = True

            conexionmy.Close()
        End If
    End Sub

    Private Sub txReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE factura_cab.referencia LIKE'%" & txReferencia.Text & "%' ORDER BY factura_cab.num_factura DESC", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()


            readermy = consultamy.ExecuteReader
            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgFacturas.DataSource = bind
            dgFacturas.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

            dgFacturas.Columns(0).HeaderText = "NUMERO"
            dgFacturas.Columns(0).Name = "Column1"
            dgFacturas.Columns(0).FillWeight = 90
            dgFacturas.Columns(0).MinimumWidth = 90
            dgFacturas.Columns(1).HeaderText = "REFERENCIA"
            dgFacturas.Columns(1).Name = "Column2"
            dgFacturas.Columns(1).FillWeight = 190
            dgFacturas.Columns(1).MinimumWidth = 190
            dgFacturas.Columns(2).HeaderText = "FECHA"
            dgFacturas.Columns(2).Name = "Column3"
            dgFacturas.Columns(2).FillWeight = 90
            dgFacturas.Columns(2).MinimumWidth = 90
            dgFacturas.Columns(3).HeaderText = "CLIENTE"
            dgFacturas.Columns(3).Name = "Column4"
            dgFacturas.Columns(3).FillWeight = 300
            dgFacturas.Columns(3).MinimumWidth = 300
            dgFacturas.Columns(4).HeaderText = "IMPORTE"
            dgFacturas.Columns(4).Name = "Column5"
            dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(4).FillWeight = 90
            dgFacturas.Columns(4).MinimumWidth = 90
            dgFacturas.Columns(5).HeaderText = "TOTAL"
            dgFacturas.Columns(5).Name = "Column6"
            dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(5).FillWeight = 90
            dgFacturas.Columns(5).MinimumWidth = 90
            dgFacturas.Columns(6).Visible = False
            dgFacturas.Columns(7).Visible = False
            dgFacturas.Columns(8).Visible = False
            dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgFacturas.Visible = True

            conexionmy.Close()
        End If
    End Sub

    Private Sub txHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txHasta.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim fec1 As Date = txDesde.Text
            Dim fec2 As Date = txHasta.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE DATE(factura_cab.fecha) BETWEEN '" & fec1.ToString("yyyy-MM-dd") & "' AND '" & fec2.ToString("yyyy-MM-dd") & "' ORDER BY factura_cab.num_factura DESC", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()


            readermy = consultamy.ExecuteReader
            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgFacturas.DataSource = bind
            dgFacturas.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

            dgFacturas.Columns(0).HeaderText = "NUMERO"
            dgFacturas.Columns(0).Name = "Column1"
            dgFacturas.Columns(0).FillWeight = 90
            dgFacturas.Columns(0).MinimumWidth = 90
            dgFacturas.Columns(1).HeaderText = "REFERENCIA"
            dgFacturas.Columns(1).Name = "Column2"
            dgFacturas.Columns(1).FillWeight = 190
            dgFacturas.Columns(1).MinimumWidth = 190
            dgFacturas.Columns(2).HeaderText = "FECHA"
            dgFacturas.Columns(2).Name = "Column3"
            dgFacturas.Columns(2).FillWeight = 90
            dgFacturas.Columns(2).MinimumWidth = 90
            dgFacturas.Columns(3).HeaderText = "CLIENTE"
            dgFacturas.Columns(3).Name = "Column4"
            dgFacturas.Columns(3).FillWeight = 300
            dgFacturas.Columns(3).MinimumWidth = 300
            dgFacturas.Columns(4).HeaderText = "IMPORTE"
            dgFacturas.Columns(4).Name = "Column5"
            dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(4).FillWeight = 90
            dgFacturas.Columns(4).MinimumWidth = 90
            dgFacturas.Columns(5).HeaderText = "TOTAL"
            dgFacturas.Columns(5).Name = "Column6"
            dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(5).FillWeight = 90
            dgFacturas.Columns(5).MinimumWidth = 90
            dgFacturas.Columns(6).Visible = False
            dgFacturas.Columns(7).Visible = False
            dgFacturas.Columns(8).Visible = False
            dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgFacturas.Visible = True

            conexionmy.Close()
        End If
    End Sub

    Private Sub txGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles txGeneral.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT factura_cab.num_factura, 
                                                    factura_cab.referencia,
                                                    factura_cab.fecha, 
                                                    clientes.nombre, 
                                                    factura_cab.totalbruto, 
                                                    factura_cab.totalfactura, 
                                                    factura_cab.clienteID,
                                                    factura_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM factura_cab INNER JOIN clientes ON factura_cab.clienteID=clientes.clienteID WHERE factura_cab.referencia LIKE'%" & txReferencia.Text & "%' ORDER BY factura_cab.num_factura DESC", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()


            readermy = consultamy.ExecuteReader
            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgFacturas.DataSource = bind
            dgFacturas.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgFacturas.ColumnHeadersDefaultCellStyle = styCabeceras

            dgFacturas.Columns(0).HeaderText = "NUMERO"
            dgFacturas.Columns(0).Name = "Column1"
            dgFacturas.Columns(0).FillWeight = 90
            dgFacturas.Columns(0).MinimumWidth = 90
            dgFacturas.Columns(1).HeaderText = "REFERENCIA"
            dgFacturas.Columns(1).Name = "Column2"
            dgFacturas.Columns(1).FillWeight = 190
            dgFacturas.Columns(1).MinimumWidth = 190
            dgFacturas.Columns(2).HeaderText = "FECHA"
            dgFacturas.Columns(2).Name = "Column3"
            dgFacturas.Columns(2).FillWeight = 90
            dgFacturas.Columns(2).MinimumWidth = 90
            dgFacturas.Columns(3).HeaderText = "CLIENTE"
            dgFacturas.Columns(3).Name = "Column4"
            dgFacturas.Columns(3).FillWeight = 300
            dgFacturas.Columns(3).MinimumWidth = 300
            dgFacturas.Columns(4).HeaderText = "IMPORTE"
            dgFacturas.Columns(4).Name = "Column5"
            dgFacturas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(4).FillWeight = 90
            dgFacturas.Columns(4).MinimumWidth = 90
            dgFacturas.Columns(5).HeaderText = "TOTAL"
            dgFacturas.Columns(5).Name = "Column6"
            dgFacturas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgFacturas.Columns(5).FillWeight = 90
            dgFacturas.Columns(5).MinimumWidth = 90
            dgFacturas.Columns(6).Visible = False
            dgFacturas.Columns(7).Visible = False
            dgFacturas.Columns(8).Visible = False
            dgFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgFacturas.Visible = True

            conexionmy.Close()
        End If
    End Sub
End Class