Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frAlbaran
    Public Shared lineas As Int16
    Public Shared pos As Integer
    Public Shared flagEdit As String = "N"
    Public Shared lineasEdit As New List(Of lineasEditadas)
    Public Shared lineasElim As New List(Of lineasEliminadas)
    Public Shared artiEdit As String
    Public Shared cantIni As Decimal
    Public Shared cantFin As Decimal
    Public Shared cantidadInicialEdit As String = "N"
    Public Shared serieIni As String
    Public Shared posicion As Integer
    Public Shared newLinea As String = "N"
    Public Shared editNumber As String = "N"
    Public Shared artiLote As String
    Public Shared numero_impresion As Integer
    Public Shared codigo_cliente_impresion As Integer


    Private Sub frAlbaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        'cargoTodosAlbaranes()
        'GroupBox5.Visible = False
        btBuscar.Visible = False



        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport()
    End Sub
    Public Sub deshabilitarBotones()
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = False
        cmdDelete.Enabled = False
        'cmdImprimir.Enabled = False
        cmdPDF.Enabled = False
        cmdMail.Enabled = False
        cmdAlbaran.Enabled = False
        cmdToldos.Enabled = False
        cmdCliente.Enabled = False
        cmdRentabilidad.Enabled = False
        cmdLineas.Enabled = False
    End Sub
    Public Sub cargoTodosAlbaranes()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.eliminado,
                                                    albaran_cab.serie, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE eliminado = 'N' AND serie = '1' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgAlbaranes.DataSource = bind
            dgAlbaranes.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

            dgAlbaranes.Columns(0).HeaderText = "NUMERO"
            dgAlbaranes.Columns(0).Name = "Column1"
            dgAlbaranes.Columns(0).FillWeight = 90
            dgAlbaranes.Columns(0).MinimumWidth = 90
            dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
            dgAlbaranes.Columns(1).Name = "Column2"
            dgAlbaranes.Columns(1).FillWeight = 190
            dgAlbaranes.Columns(1).MinimumWidth = 190
            dgAlbaranes.Columns(2).HeaderText = "FECHA"
            dgAlbaranes.Columns(2).Name = "Column3"
            dgAlbaranes.Columns(2).FillWeight = 90
            dgAlbaranes.Columns(2).MinimumWidth = 90
            dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
            dgAlbaranes.Columns(3).Name = "Column4"
            dgAlbaranes.Columns(3).FillWeight = 300
            dgAlbaranes.Columns(3).MinimumWidth = 300
            dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
            dgAlbaranes.Columns(4).Name = "Column5"
            dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgAlbaranes.Columns(4).FillWeight = 90
            dgAlbaranes.Columns(4).MinimumWidth = 90
            dgAlbaranes.Columns(5).HeaderText = "TOTAL"
            dgAlbaranes.Columns(5).Name = "Column6"
            dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgAlbaranes.Columns(5).FillWeight = 90
            dgAlbaranes.Columns(5).MinimumWidth = 90
            dgAlbaranes.Columns(6).Visible = False
            dgAlbaranes.Columns(7).Visible = False
            dgAlbaranes.Columns(8).Visible = False
            dgAlbaranes.Columns(9).Visible = False
            dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgAlbaranes.Visible = True
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga de albaranes. Revisa los datos introducidos.")
            Exit Sub
        End Try


        conexionmy.Close()
    End Sub
    Public Sub limpiarFormulario()
        txtNumpres.Text = ""
        txNumpresBk.Text = ""
        txFecha.Text = ""
        txReferenciapres.Text = ""
        txBultos.Text = 0
        txNumcli.Text = ""
        txClientepres.Text = ""
        txAgente.Text = ""
        txUsuario.Text = vCodUser
        txEmpresa.Text = vEmpresa
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
        dgLineasPres2.Rows.Clear()
    End Sub

    Private Sub cmdLineas_ButtonClick(sender As Object, e As EventArgs) Handles cmdLineas.ButtonClick

        newLinea = "S"
        If txNumcli.Text = "" Then
            MsgBox("Antes de añadir líneas al albarán es necesario seleccionar un cliente")
            formCli = "A"
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
                Try
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
                    dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(11).Value = ""
                    dgLineasPres1.Focus()
                    dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(2)
                    dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(2).Selected = True
                Catch ex As Exception
                    MsgBox("Se ha producido un error al crear una nueva línea en el albarán. Revisa los datos.")
                    Exit Sub
                End Try

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
                Try
                    lineas = lineas + 1
                    dgLineasPres2.Rows.Add()
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(0).Value = lineas
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = 1
                    cantidadInicialEdit = "S"
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
                Catch ex As Exception
                    MsgBox("Se ha producido un error al crear una nueva línea en el albarán. Revisa los datos.")
                    Exit Sub
                End Try

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
            Try
                dgLineasPres1.Rows.Insert(dgLineasPres1.CurrentRow.Index)
                renumerar()
                dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.CurrentRow.Index - 1).Cells(2)

                pos = dgLineasPres1.CurrentRow.Index

                dgLineasPres1.CurrentRow.Cells(4).Value = 1
                dgLineasPres1.CurrentRow.Cells(5).Value = 0
                dgLineasPres1.CurrentRow.Cells(6).Value = 0
                dgLineasPres1.CurrentRow.Cells(7).Value = 0
                dgLineasPres1.CurrentRow.Cells(8).Value = txDtocli.Text
                dgLineasPres1.CurrentRow.Cells(9).Value = 0
                dgLineasPres1.CurrentRow.Cells(10).Value = 0
                dgLineasPres1.CurrentRow.Cells(11).Value = ""
            Catch ex As Exception
                MsgBox("Se ha producido un error al insertar una nueva línea en el albarán. Revisa los datos.")
                Exit Sub
            End Try

        Else
            For Each row As DataGridViewRow In dgLineasPres2.Rows
                If row.Cells(3).Value Is Nothing Then
                    MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                    Exit Sub
                End If
            Next
            Try
                dgLineasPres2.Rows.Insert(dgLineasPres2.CurrentRow.Index)
                renumerar()
                dgLineasPres2.CurrentCell = dgLineasPres2.Rows(dgLineasPres2.CurrentRow.Index - 1).Cells(2)

                pos = dgLineasPres2.CurrentRow.Index

                dgLineasPres2.CurrentRow.Cells(4).Value = 1
                cantidadInicialEdit = "S"
                dgLineasPres2.CurrentRow.Cells(5).Value = 0
                dgLineasPres2.CurrentRow.Cells(6).Value = 0
                dgLineasPres2.CurrentRow.Cells(7).Value = 0
                dgLineasPres2.CurrentRow.Cells(8).Value = txDtocli.Text
                dgLineasPres2.CurrentRow.Cells(9).Value = 0
                dgLineasPres2.CurrentRow.Cells(10).Value = 0
                dgLineasPres2.CurrentRow.Cells(11).Value = ""
            Catch ex As Exception
                MsgBox("Se ha producido un error al insertar una nueva línea en el albarán. Revisa los datos.")
                Exit Sub
            End Try

        End If

        newLinea = "N"
    End Sub
    Public Sub renumerar()
        lineas = 0
        If flagEdit = "N" Then
            Try
                For Each row As DataGridViewRow In dgLineasPres1.Rows
                    lineas = lineas + 1
                    row.Cells(0).Value = lineas

                Next
            Catch ex As Exception
                MsgBox("Se ha producido un error al renumerar las lineas del albaran.")
                Exit Sub
            End Try

        Else
            Try
                For Each row As DataGridViewRow In dgLineasPres2.Rows
                    lineas = lineas + 1
                    row.Cells(0).Value = lineas

                Next
            Catch ex As Exception
                MsgBox("Se ha producido un error al renumerar las lineas del albaran.")
                Exit Sub
            End Try

        End If
    End Sub
    Public Sub recalcularTotales()
        Dim totalLinea As Decimal = 0
        Dim dtoLinea As Decimal = 0
        Dim ivaLinea As Decimal = 0
        Dim reclinea As Decimal = 0

        If flagEdit = "N" Then
            Try
                For Each row2 As DataGridViewRow In dgLineasPres1.Rows
                    totalLinea = Math.Round(totalLinea, 2, MidpointRounding.AwayFromZero) + Math.Round(Decimal.Parse(row2.Cells(9).Value), 2, MidpointRounding.AwayFromZero)
                    dtoLinea = Math.Round(dtoLinea, 2, MidpointRounding.AwayFromZero) + (Math.Round(Decimal.Parse(row2.Cells(9).Value), 2, MidpointRounding.AwayFromZero) * Math.Round(Decimal.Parse(row2.Cells(8).Value), 2, MidpointRounding.AwayFromZero)) / 100
                Next
            Catch ex As Exception
                MsgBox("Se ha producido un error al recalcular los totales de la línea. Revise los datos")
                Exit Sub
            End Try
        Else
            Try
                For Each row2 As DataGridViewRow In dgLineasPres2.Rows
                    'Math.Round(numero, 2, MidpointRounding.AwayFromZero)
                    totalLinea = Math.Round(totalLinea, 2, MidpointRounding.AwayFromZero) + Math.Round(Decimal.Parse(row2.Cells(9).Value), 2, MidpointRounding.AwayFromZero)
                    dtoLinea = Math.Round(dtoLinea, 2, MidpointRounding.AwayFromZero) + (Math.Round(Decimal.Parse(row2.Cells(9).Value), 2, MidpointRounding.AwayFromZero) * Math.Round(Decimal.Parse(row2.Cells(8).Value), 2, MidpointRounding.AwayFromZero)) / 100
                Next
            Catch ex As Exception
                MsgBox("Se ha producido un error al recalcular los totales de la línea. Revise los datos")
                Exit Sub
            End Try

        End If

        Try
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
        Catch ex As Exception
            MsgBox("Se ha producido un error al recalcular los totales de la línea. Revise los datos")
            Exit Sub
        End Try
    End Sub
    Public Sub actualizarLinea()
        If flagEdit = "N" Then
            If dgLineasPres1.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal
                Dim medida As Decimal
                Try
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
                Catch ex As Exception
                    MsgBox("Se ha producido un error al acualizar la línea del albarán. Revisa los datos")
                    Exit Sub
                End Try
            End If
        Else
            If dgLineasPres2.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal
                Dim medida As Decimal

                Try
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
                Catch ex As Exception
                    MsgBox("Se ha producido un error al acualizar la línea del albarán. Revisa los datos")
                    Exit Sub
                End Try
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
        formCli = "A"
        frVerClientes.Show()
    End Sub

    Private Sub dgLineasPres1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "A"
            frVerArticulos.Show()
        End If
        If (dgLineasPres1.CurrentRow.Index = 0) Then

        Else
            pos = dgLineasPres1.CurrentRow.Index
        End If
    End Sub

    Private Sub ELIMINARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARToolStripMenuItem.Click
        If flagEdit = "N" Then
            Try
                dgLineasPres1.Rows.RemoveAt(dgLineasPres1.CurrentRow.Index)
                renumerar()
                recalcularTotales()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la eliminación de líneas de albarán. Revise los datos")
                Exit Sub
            End Try
            'renumerar()
            'recalcularTotales()
        Else
            'Cargo los datos de la linea para el control de stocks
            Try
                If dgLineasPres2.CurrentRow.Cells(11).Value = "" Then
                    artiEdit = dgLineasPres2.CurrentRow.Cells(2).Value
                    artiLote = "N"
                Else
                    artiEdit = dgLineasPres2.CurrentRow.Cells(11).Value
                    artiLote = "S"
                End If

                cantIni = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
                cantFin = 0
                lineasEdit.Add(New lineasEditadas() With {.codigoArt = artiEdit, .cantAntes = cantIni, .cantDespues = cantFin, .esLote = artiLote})

                dgLineasPres2.Rows.RemoveAt(dgLineasPres2.CurrentRow.Index)
                renumerar()
                recalcularTotales()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la eliminación de líneas de albarán y actualización de stocks. Revise los datos")
                Exit Sub
            End Try

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
        dgLineasPres1.Enabled = True
        cbSerie.Text = "S1"
        cbEstado.Text = "NO FACTURADO"
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
            Dim fechapag As Date
            Dim vPagado As String
            If ckPagado.Checked = True Then
                vPagado = "S"
                fechapag = dtpFechaPago.Value
            Else
                vPagado = "N"
            End If


            'Guardo cabecera y actualizo número de presupuesto
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Try
                If vPagado = "S" Then
                    Dim cmd As New MySqlCommand("INSERT INTO albaran_cab (num_albaran, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, fechapago, referencia, bultos, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalalbaran, facturado, pagado) VALUES (" + txtNumpres.Text + ", '" + vSerie + "'," + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "', '" + fechapag.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txBultos.Text + "', '" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', 'N',  '" + vPagado + "')", conexionmy)
                    cmd.ExecuteNonQuery()
                Else
                    Dim cmd As New MySqlCommand("INSERT INTO albaran_cab (num_albaran, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, bultos, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalalbaran, facturado, pagado) VALUES (" + txtNumpres.Text + ", '" + vSerie + "'," + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txBultos.Text + "', '" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', 'N',  '" + vPagado + "')", conexionmy)
                    cmd.ExecuteNonQuery()
                End If
            Catch ex As Exception
                MsgBox("Se ha producido un error en la grabación de la cabecera del albarán. Revise los datos")
                Exit Sub
            End Try

            If cbSerie.Text = "S1" Then
                Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_albaran = '" + txtNumpres.Text + "'", conexionmy)
                Try
                    cmdActualizar.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización del número del albarán en el archivo de configuración. Revise los datos")
                    Exit Sub
                End Try

            Else
                Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_albaran_2 = '" + txtNumpres.Text + "'", conexionmy)
                Try
                    cmdActualizar.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización del número del albarán en el archivo de configuración. Revise los datos")
                    Exit Sub
                End Try

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
                cmdLinea.CommandText = "INSERT INTO albaran_linea (num_albaran, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, lote) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', '" + row.Cells(11).Value + "')"

                Try
                    cmdLinea.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la grabación de las líneas del albarán. Revise los datos")
                    Exit Sub
                End Try


                If row.Cells(11).Value = "" Then
                    Try
                        descontarStock(arti, lincant)
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la actualización del stock de artículos. Revise los datos")
                        Exit Sub
                    End Try
                Else
                    Try
                        vLote = row.Cells(11).Value
                        descontarStockLote(vLote, lincant)
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la actualización del stock de artículos. Revise los datos")
                        Exit Sub
                    End Try
                End If
            Next

            conexionmy.Close()

            deshabilitarBotonesLight()
            'limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodosAlbaranes()
            'tabPresupuestos.SelectTab(0)
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
            Dim vPagado As String

            Dim fecha As Date = txFecha.Text
            Dim fechapag As Date
            Dim vEstado As String
            If cbEstado.Text = "FACTURADO" Then
                vEstado = "F"
            Else
                vEstado = "N"
            End If
            If ckPagado.Checked = True Then
                vPagado = "S"
                fechapag = dtpFechaPago.Value
            Else
                vPagado = "N"
            End If

            'Guardo cabecera y actualizo número de presupuesto

            If vSerie = serieIni Then
                Try
                    If vPagado = "S" Then
                        Dim cmd As New MySqlCommand("UPDATE albaran_cab SET fecha = '" + fecha.ToString("yyyy-MM-dd") + "', fechapago = '" + fechapag.ToString("yyyy-MM-dd") + "', clienteID = " + txNumcli.Text + ", agenteID = " + txAgente.Text + ", usuarioID = " + txUsuario.Text + ", empresaID = " + txEmpresa.Text + ", referencia = '" + txReferenciapres.Text + "', bultos = '" + txBultos.Text + "', observaciones = '" + txObserva.Text + "', totalbruto = '" + guardo_impbru + "', totaldto = '" + guardo_impdto + "', totaliva = '" + guardo_impiva + "', totalrecargo = '" + guardo_imprec + "', totalalbaran = '" + guardo_imptot + "', serie = '" + vSerie + "', facturado = '" + vEstado + "', pagado = '" + vPagado + "' WHERE num_albaran = " + txtNumpres.Text + "", conexionmy)
                        cmd.ExecuteNonQuery()
                    Else
                        Dim cmd As New MySqlCommand("UPDATE albaran_cab SET fecha = '" + fecha.ToString("yyyy-MM-dd") + "', clienteID = " + txNumcli.Text + ", agenteID = " + txAgente.Text + ", usuarioID = " + txUsuario.Text + ", empresaID = " + txEmpresa.Text + ", referencia = '" + txReferenciapres.Text + "', bultos = '" + txBultos.Text + "', observaciones = '" + txObserva.Text + "', totalbruto = '" + guardo_impbru + "', totaldto = '" + guardo_impdto + "', totaliva = '" + guardo_impiva + "', totalrecargo = '" + guardo_imprec + "', totalalbaran = '" + guardo_imptot + "', serie = '" + vSerie + "', facturado = '" + vEstado + "', pagado = '" + vPagado + "' WHERE num_albaran = " + txtNumpres.Text + "", conexionmy)
                        cmd.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización del número de albarán en el archivo de configuración. Revise los datos")
                    Exit Sub
                End Try
            Else
                Dim cmdEliminarLin As New MySqlCommand("DELETE FROM albaran_linea WHERE num_albaran = '" + txtNumpres.Text + "'", conexionmy)
                Try
                    cmdEliminarLin.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización de las líneas de albarán. Revise los datos")
                    Exit Sub
                End Try
                Dim cmdEliminarCab As New MySqlCommand("DELETE FROM albaran_cab WHERE num_albaran = '" + txtNumpres.Text + "'", conexionmy)
                Try
                    cmdEliminarCab.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización de la cabecera del albarán (Err_1050). Revise los datos")
                    Exit Sub
                End Try

                cargoNumero()
                Try
                    If vPagado = "S" Then
                        Dim cmd As New MySqlCommand("INSERT INTO albaran_cab (num_albaran, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, fechapago, referencia, bultos, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalalbaran, facturado) VALUES (" + txtNumpres.Text + ", '" + vSerie + "'," + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "', '" + fechapag.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txBultos.Text + "','" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "', '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', 'N')", conexionmy)
                        cmd.ExecuteNonQuery()
                    Else
                        Dim cmd As New MySqlCommand("INSERT INTO albaran_cab (num_albaran, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, bultos, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalalbaran, facturado) VALUES (" + txtNumpres.Text + ", '" + vSerie + "'," + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + txReferenciapres.Text + "', '" + txBultos.Text + "','" + txObserva.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "', '" + guardo_impiva + "', '" + guardo_imprec + "', '" + guardo_imptot + "', 'N')", conexionmy)
                        cmd.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización de la cabecera del albarán (Err_1051). Revise los datos")
                    Exit Sub
                End Try

                If cbSerie.Text = "S1" Then
                    Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_albaran = '" + txtNumpres.Text + "'", conexionmy)
                    Try
                        cmdActualizar.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la actualización de la cabecera del albarán (Err_1052). Revise los datos")
                        Exit Sub
                    End Try

                Else
                    Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_albaran_2 = '" + txtNumpres.Text + "'", conexionmy)
                    Try
                        cmdActualizar.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la actualización de la cabecera del albarán (Err_1053). Revise los datos")
                        Exit Sub
                    End Try
                End If
            End If

            Dim cmdEliminar As New MySqlCommand("DELETE FROM albaran_linea WHERE num_albaran = '" + txtNumpres.Text + "'", conexionmy)
            Try
                cmdEliminar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización de las líneas del albarán (Err_1054). Revise los datos")
                Exit Sub
            End Try


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
                cmdLinea.CommandText = "INSERT INTO albaran_linea (num_albaran, linea, codigo, descripcion, cantidad, ancho_largo, m2_ml, precio, descuento, ivalinea, importe, totalinea, lote) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(2).Value + "', '" + row.Cells(3).Value + "', '" + guardo_lincant + "', '" + guardo_linancho + "', '" + guardo_linmetros + "', '" + guardo_linprec + "', '" + guardo_lindto + "', '" + guardo_liniva + "', '" + guardo_linimporte + "', '" + guardo_lintotal + "', '" + row.Cells(11).Value + "')"
                Try
                    cmdLinea.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la actualización de las líneas del albarán (Err_1055). Revise los datos")
                    Exit Sub
                End Try
            Next
            conexionmy.Close()

            If lineasEdit.Count > 0 Then
                For Each itemlineas As lineasEditadas In lineasEdit
                    If itemlineas.esLote = "N" Then
                        Try
                            aumentarStock(itemlineas.codigoArt, itemlineas.cantAntes)
                            descontarStock(itemlineas.codigoArt, itemlineas.cantDespues)
                        Catch ex As Exception
                            MsgBox("Se ha producido un error en la actualización de stocks (Err_1060). Revise los datos")
                            Exit Sub
                        End Try

                    Else
                        Try
                            'vLote = row.Cells(11).Value
                            aumentarStockLote(itemlineas.codigoArt, itemlineas.cantAntes)
                            descontarStockLote(itemlineas.codigoArt, itemlineas.cantDespues)
                        Catch ex As Exception
                            MsgBox("Se ha producido un error en la actualización de stocks (Err_1061). Revise los datos")
                            Exit Sub
                        End Try
                    End If
                Next
            End If
            lineasEdit.Clear()

            deshabilitarBotonesLight()
            'limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodosAlbaranes()
            'tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub
    Public Sub cargoNumero()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim numid As Int32

        If cbSerie.Text = "S1" Then
            Dim cmdLastId As New MySqlCommand("SELECT num_albaran FROM configuracion  ", conexionmy)
            Try
                numid = cmdLastId.ExecuteScalar()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la carga del número de albarán (Err_1071). Revise los datos")
                Exit Sub
            End Try
        Else
            Dim cmdLastId As New MySqlCommand("SELECT num_albaran_2 FROM configuracion  ", conexionmy)
            Try
                numid = cmdLastId.ExecuteScalar()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la carga del número de albarán (Err_1072). Revise los datos")
                Exit Sub
            End Try
        End If

        txtNumpres.Text = numid + 1

        conexionmy.Close()

    End Sub
    Public Sub cargoAlbaran()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCab As New MySqlCommand

        Dim cmdCli As New MySqlCommand

        Dim rdrCab As MySqlDataReader

        Dim rdrCli As MySqlDataReader


        cmdCab = New MySqlCommand("SELECT * FROM albaran_cab WHERE num_albaran = '" + txtNumpres.Text + "'", conexionmy)

        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        Try
            rdrCab = cmdCab.ExecuteReader
            rdrCab.Read()
            txFecha.Text = rdrCab("fecha")
            If IsDBNull(rdrCab("fechapago")) = True Then
                dtpFechaPago.Text = Today
            Else
                dtpFechaPago.Text = rdrCab("fechapago")
            End If
            txNumcli.Text = rdrCab("clienteID")
            txAgente.Text = rdrCab("agenteID")
            txUsuario.Text = rdrCab("usuarioID")
            txEmpresa.Text = rdrCab("empresaID")
            txReferenciapres.Text = rdrCab("referencia")
            txBultos.Text = rdrCab("bultos")
            txObserva.Text = rdrCab("observaciones")
            If rdrCab("serie") = "1" Then
                cbSerie.Text = "S1"
                serieIni = "1"
            Else
                cbSerie.Text = "S2"
                serieIni = "2"
            End If
            If rdrCab("facturado") = "N" Then
                cbEstado.Text = "NO FACTURADO"
            Else
                cbEstado.Text = "FACTURADO"
                cmdAlbaran.Enabled = False
            End If
            cbEstado.Enabled = True
            If rdrCab("pagado") = "S" Then
                ckPagado.Checked = True
            Else
                ckPagado.Checked = False
            End If
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga del albarán (Err_1082). Revise los datos")
            Exit Sub
        End Try

        rdrCab.Close()

        cmdCli = New MySqlCommand("SELECT * FROM clientes WHERE clienteID = '" + txNumcli.Text + "'", conexionmy)

        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        Try
            rdrCli = cmdCli.ExecuteReader
            rdrCli.Read()

            txNumcli.Text = rdrCli("clienteID")
            txClientepres.Text = rdrCli("nombre")
            txDtocli.Text = rdrCli("descuento")
            txRecargo.Text = rdrCli("recargo")
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga del albarán (Err_1083). Revise los datos")
            Exit Sub
        End Try

        rdrCli.Close()

        conexionmy.Close()
        cargoEnvios()

    End Sub
    Public Sub cargoLineas()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT albaran_linea.linea,
                                            albaran_linea.codigo,
                                            albaran_linea.descripcion,
                                            albaran_linea.cantidad,
                                            albaran_linea.ancho_largo,
                                            albaran_linea.m2_ml,
                                            albaran_linea.precio,
                                            albaran_linea.descuento,
                                            albaran_linea.ivalinea,
                                            albaran_linea.importe,
                                            albaran_linea.totalinea,
                                            albaran_linea.lote,
                                            albaran_linea.num_albaran
                                            FROM albaran_linea WHERE num_albaran = '" + txtNumpres.Text + "' ORDER BY albaran_linea.linea", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        Try
            rdrLin = cmdLinea.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga del albarán (Err_1084). Revise los datos")
            Exit Sub
        End Try
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                Try
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
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la carga del albarán (Err_1091). Revise los datos")
                    Exit Sub
                End Try

            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()

        recalcularTotales()
    End Sub

    Private Sub dgLineasPres2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellClick
        If (e.ColumnIndex = 1) Then
            formArti = "A"
            frVerArticulos.Show()
        End If
        If (e.ColumnIndex = 12) Then
            formArti = "A"
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
            Try
                If dgLineasPres2.CurrentRow.Cells(11).Value = "" Then
                    artiEdit = dgLineasPres2.CurrentRow.Cells(2).Value
                    artiLote = "N"
                Else
                    artiEdit = dgLineasPres2.CurrentRow.Cells(11).Value
                    artiLote = "S"
                End If
                cantFin = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
                If cantidadInicialEdit = "S" Then
                    cantIni = cantIni - 1
                End If
                'MsgBox(cantIni & " - " & cantFin)
                lineasEdit.Add(New lineasEditadas() With {.codigoArt = artiEdit, .cantAntes = cantIni, .cantDespues = cantFin, .esLote = artiLote})
            Catch ex As Exception
                MsgBox("Se ha producido un error en la edición del grid (Err_1092). Revise los datos")
                Exit Sub
            End Try
            cantidadInicialEdit = "N"
        End If
        If (e.ColumnIndex = 2) Then
            Dim vRef As String = dgLineasPres2.CurrentCell.Value
            cargarArticulos(vRef)
            actualizarLinea()
            recalcularTotales()
            If dgLineasPres2.CurrentRow.Cells(11).Value = "" Then
                artiEdit = dgLineasPres2.CurrentRow.Cells(2).Value
                artiLote = "N"
            Else
                artiEdit = dgLineasPres2.CurrentRow.Cells(11).Value
                artiLote = "S"
            End If
            cantFin = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
            lineasEdit.Add(New lineasEditadas() With {.codigoArt = artiEdit, .cantAntes = cantIni, .cantDespues = cantFin, .esLote = artiLote})
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

            Try
                Dim cmdLastId As New MySqlCommand("SELECT ref_proveedor, stock FROM articulos2 WHERE ref_proveedor = '" + codArti + "'", conexionmy)
                Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
                reader.Read()

                Dim stock As String = (reader.GetString(1) - unidades).ToString
                reader.Close()

                Dim cmdActualizo As New MySqlCommand("UPDATE articulos2 SET stock = '" + stock + "' WHERE ref_proveedor = '" + codArti + "'", conexionmy)
                cmdActualizo.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización del stock (Err_1093). Revise los datos")
                Exit Sub
            End Try

            conexionmy.Close()
        End If

    End Sub
    Public Sub aumentarStock(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Try
                Dim cmdLastId As New MySqlCommand("SELECT ref_proveedor, stock FROM articulos2 WHERE ref_proveedor = '" + codArti + "'", conexionmy)
                Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
                reader.Read()
                Dim stock As String = (reader.GetString(1) + unidades).ToString
                reader.Close()

                Dim cmdActualizo As New MySqlCommand("UPDATE articulos2 SET stock = '" + stock + "' WHERE ref_proveedor = '" + codArti + "'", conexionmy)
                cmdActualizo.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización del stock (Err_1094). Revise los datos")
                Exit Sub
            End Try

            conexionmy.Close()
        End If
    End Sub
    Private Sub dgLineasPres2_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellEnter
        If (e.ColumnIndex = 4) Then
            If dgLineasPres2.CurrentRow.Cells(11).Value = "" Then
                Try
                    artiEdit = dgLineasPres2.CurrentRow.Cells(2).Value
                    cantIni = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la edición del grid (Err_1095). Revise los datos")
                    Exit Sub
                End Try
            Else
                Try
                    artiEdit = dgLineasPres2.CurrentRow.Cells(11).Value
                    cantIni = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la edición del grid (Err_1096). Revise los datos")
                    Exit Sub
                End Try
            End If
        End If
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
                    Try
                        value1 = dgLineasPres1.CurrentRow.Cells(4).EditedFormattedValue.ToString
                        value1 = value1.Replace(".", ",")
                        If value1 <> "" Then
                            Dim cellValue As Decimal = CType(value1, Decimal)
                            dgLineasPres1.CurrentRow.Cells(4).Value = cellValue
                        End If
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la edición del grid (Err_1097). Revise los datos")
                        Exit Sub
                    End Try

                End If
                If (e.ColumnIndex = 7) Then
                    Try
                        value2 = dgLineasPres1.CurrentRow.Cells(7).EditedFormattedValue.ToString
                        value2 = value2.Replace(".", ",")
                        If value2 <> "" Then
                            Dim cellValue As Decimal = CType(value2, Decimal)
                            dgLineasPres1.CurrentRow.Cells(7).Value = cellValue
                        End If
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la edición del grid (Err_1098). Revise los datos")
                        Exit Sub
                    End Try

                End If
                If (e.ColumnIndex = 8) Then
                    Try
                        value3 = dgLineasPres1.CurrentRow.Cells(8).EditedFormattedValue.ToString
                        value3 = value3.Replace(".", ",")
                        If value3 <> "" Then
                            Dim cellValue As Decimal = CType(value3, Decimal)
                            dgLineasPres1.CurrentRow.Cells(8).Value = cellValue
                        End If
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la edición del grid (Err_1099). Revise los datos")
                        Exit Sub
                    End Try
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
                    Try
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
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la edición de los datos del grid (Err_1101). Revise los datos")
                        Exit Sub
                    End Try

                End If
                If (e.ColumnIndex = 7) Then
                    Try
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
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la edición de los datos del grid (Err_1102). Revise los datos")
                        Exit Sub
                    End Try

                End If
                If (e.ColumnIndex = 8) Then
                    Try
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
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la edición de los datos del grid (Err_1103). Revise los datos")
                        Exit Sub
                    End Try

                End If
            End If
        End If
    End Sub
    Public Sub cargoEnvios()
        cbEnvio.ResetText()

        Dim cn As MySqlConnection
        Dim cm As MySqlCommand

        Dim da As MySqlDataAdapter
        Dim ds As DataSet
        cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        cn.Open()
        Try
            cm = New MySqlCommand("SELECT envioID, clienteID, localidad, provincia, concat_ws(' - ',cpostal, domicilio) AS direccion FROM envios WHERE clienteID = '" & txNumcli.Text & "'", cn)


            cm.CommandType = CommandType.Text
            cm.Connection = cn

            da = New MySqlDataAdapter(cm)
            ds = New DataSet()
            da.Fill(ds)


            cbEnvio.DataSource = ds.Tables(0)
            cbEnvio.DisplayMember = ds.Tables(0).Columns("direccion").ToString
            cbEnvio.ValueMember = "envioID"
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga de direcciones de envío (Err_1104). Revise los datos")
            Exit Sub
        End Try


        cn.Close()
    End Sub
    Public Sub cargarArticulos(refer As String)
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCli As New MySqlCommand
        Dim rdrArt As MySqlDataReader
        cmdCli = New MySqlCommand("SELECT ref_proveedor,referencia,descripcion,pvp,iva,medidaID,familia FROM articulos2 WHERE ref_proveedor = '" & refer & "'", conexionmy)


        cmdCli.CommandType = CommandType.Text
        cmdCli.Connection = conexionmy
        Try
            rdrArt = cmdCli.ExecuteReader
            rdrArt.Read()
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga de artículos (Err_1105). Revise los datos")
            Exit Sub
        End Try


        If rdrArt.HasRows = True Then
            If flagEdit = "N" Then
                Try
                    dgLineasPres1.CurrentRow.Cells(3).Value = rdrArt("descripcion")
                    dgLineasPres1.CurrentRow.Cells(4).Value = 1
                    If rdrArt("familia") = 7 Or rdrArt("familia") = 3 Then
                        dgLineasPres1.CurrentRow.Cells(5).Value = rdrArt("medidaID") / 100
                        dgLineasPres1.CurrentRow.Cells(6).Value = dgLineasPres1.CurrentRow.Cells(4).Value * dgLineasPres1.CurrentRow.Cells(5).Value
                    Else
                        dgLineasPres1.CurrentRow.Cells(5).Value = 0
                        dgLineasPres1.CurrentRow.Cells(6).Value = 0
                    End If
                    dgLineasPres1.CurrentRow.Cells(7).Value = rdrArt("pvp")
                    dgLineasPres1.CurrentRow.Cells(8).Value = txDtocli.Text
                    dgLineasPres1.CurrentRow.Cells(9).Value = 0
                    dgLineasPres1.CurrentRow.Cells(10).Value = 0
                    dgLineasPres1.CurrentRow.Cells(11).Value = ""
                    txIva.Text = rdrArt("iva")
                    'dgLineasPres1.CurrentCell = dgLineasPres1.CurrentRow.Cells(4)
                    'dgLineasPres1.BeginEdit(True)
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la carga de artículos (Err_1106). Revise los datos")
                    Exit Sub
                End Try

            Else
                Try
                    dgLineasPres2.CurrentRow.Cells(3).Value = rdrArt("descripcion")
                    dgLineasPres2.CurrentRow.Cells(4).Value = 1
                    If rdrArt("familia") = 7 Or rdrArt("familia") = 3 Then
                        dgLineasPres2.CurrentRow.Cells(5).Value = rdrArt("medidaID") / 100
                        dgLineasPres2.CurrentRow.Cells(6).Value = dgLineasPres2.CurrentRow.Cells(4).Value * dgLineasPres2.CurrentRow.Cells(5).Value
                    Else
                        dgLineasPres2.CurrentRow.Cells(5).Value = 0
                        dgLineasPres2.CurrentRow.Cells(6).Value = 0
                    End If

                    dgLineasPres2.CurrentRow.Cells(7).Value = rdrArt("pvp")
                    dgLineasPres2.CurrentRow.Cells(8).Value = txDtocli.Text
                    dgLineasPres2.CurrentRow.Cells(9).Value = 0
                    dgLineasPres2.CurrentRow.Cells(10).Value = 0
                    dgLineasPres2.CurrentRow.Cells(11).Value = ""
                    txIva.Text = rdrArt("iva")
                    'dgLineasPres2.CurrentCell = dgLineasPres2.CurrentRow.Cells(4)
                    'dgLineasPres2.BeginEdit(True)
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la carga de artículos (Err_1107). Revise los datos")
                    Exit Sub
                End Try
            End If
        Else
        End If

        rdrArt.Close()

        conexionmy.Close()
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim respuesta As String
        respuesta = MsgBox("El borrado de albaranes es una acción no recuperable. ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdEliminar As New MySqlCommand("DELETE FROM albaran_cab WHERE num_albaran = '" + txtNumpres.Text + "'", conexionmy)
            Try
                cmdEliminar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la eliminación del albarán (Err_1110). Revise los datos")
                Exit Sub
            End Try


            eliminarAlbaranEditStock()

            Dim cmdEliminarLineas As New MySqlCommand("DELETE FROM albaran_linea WHERE num_albaran = '" + txtNumpres.Text + "'", conexionmy)
            Try
                cmdEliminarLineas.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la eliminación del albarán (Err_1111). Revise los datos")
                Exit Sub
            End Try


            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodosAlbaranes()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"

        End If
    End Sub

    Private Sub cmdAlbaran_Click(sender As Object, e As EventArgs) Handles cmdAlbaran.Click
        'Convertir Albarán en Factura
        Dim vSelecSerie As String
        If tscbSeries.Text = "S1" Then
            vSelecSerie = 1
        ElseIf tscbSeries.Text = "S1" Then
            vSelecSerie = 2
        Else
            MsgBox("La serie seleccionada no es correcta. Selecciona una serie disponible")
            Exit Sub
        End If
        Dim respuesta As String
        respuesta = MsgBox("La conversión a Factura no es reversible. ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            txNumpresBk.Text = txtNumpres.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand
            cmd.CommandType = System.Data.CommandType.Text


            cargoNumeroConversion("F")
            Dim vFecha As Date = txFecha.Text
            Dim vFechaHoy As Date = Today
            Dim vBruto As String = Replace(txImpBruto.Text.ToString, ".", "")
            Dim guardo_vBruto As String = Replace(vBruto.ToString, ",", ".")

            Dim vDto As String = Replace(txImpDto.Text.ToString, ".", "")
            Dim guardo_vDto As String = Replace(vDto.ToString, ",", ".")

            Dim vIva As String = Replace(txImpIva.Text.ToString, ".", "")
            Dim guardo_vIva As String = Replace(vIva.ToString, ",", ".")

            Dim vRec As String = Replace(txImpRecargo.Text.ToString, ".", "")
            Dim guardo_vRec As String = Replace(vRec.ToString, ",", ".")

            Dim vTotal As String = Replace(txTotalAlbaran.Text.ToString, ".", "")
            Dim guardo_vTotal As String = Replace(vTotal.ToString, ",", ".")

            cmd.CommandText = "INSERT INTO factura_cab (num_factura, serie, clienteID, envioID, empresaID, agenteID, usuarioID, fecha, referencia, observaciones, totalbruto, totaldto, totaliva, totalrecargo, totalfactura, manual, eliminado, num_albaran) VALUES (" + txtNumpres.Text + " , '" + vSelecSerie + "', " + txNumcli.Text + ", " + cbEnvio.SelectedValue.ToString + ", " + txEmpresa.Text + ", " + txAgente.Text + ", " + txUsuario.Text + ", '" + vFechaHoy.ToString("yyyy-MM-dd") + "', '" + txReferenciapres.Text + "', '" + txObserva.Text + "', '" + guardo_vBruto + "', '" + guardo_vDto + "', '" + guardo_vIva + "', '" + guardo_vRec + "', '" + guardo_vTotal + "', 'N', 'N', " + txNumpresBk.Text + ")"
            cmd.Connection = conexionmy
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la conversión del albarán (Err_1121). Revise los datos")
                Exit Sub
            End Try


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
                Try
                    cmdLinea.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la conversión del albarán (Err_1122). Revise los datos")
                    Exit Sub
                End Try


            Next


            Try
                If vSelecSerie = "1" Then
                    Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura = '" + txtNumpres.Text + "'  ", conexionmy)
                    cmdActualizar.ExecuteNonQuery()
                Else
                    Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_factura_2 = '" + txtNumpres.Text + "'  ", conexionmy)
                    cmdActualizar.ExecuteNonQuery()
                End If

            Catch ex As Exception
                MsgBox("Se ha producido un error en la conversión del albarán (Err_1123). Revise los datos")
                Exit Sub
            End Try


            'Borro la cabecera y las lineas del presupuesto

            Dim cmdEliminar As New MySqlCommand("UPDATE albaran_cab SET facturado = 'S' WHERE num_albaran = '" + txNumpresBk.Text + "'", conexionmy)
            Try
                cmdEliminar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la conversión del albarán (Err_1124). Revise los datos")
                Exit Sub
            End Try

            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodosAlbaranes()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        Else
            cargoTodosAlbaranes()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub
    Public Sub cargoNumeroConversion(tipoDoc As String)

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Try
            If tscbSeries.Text = "S1" Then
                Dim cmdLastId As New MySqlCommand("SELECT num_factura FROM configuracion  ", conexionmy)
                Dim numid As Int32

                numid = cmdLastId.ExecuteScalar()

                txtNumpres.Text = numid + 1
            ElseIf tscbSeries.Text = "S2" Then
                Dim cmdLastId As New MySqlCommand("SELECT num_factura_2 FROM configuracion  ", conexionmy)
                Dim numid As Int32

                numid = cmdLastId.ExecuteScalar()

                txtNumpres.Text = numid + 1
            End If

        Catch ex As Exception
            MsgBox("Se ha producido un error en la conversión del albarán (Err_1125). Revise los datos")
            Exit Sub
        End Try


        conexionmy.Close()

    End Sub
    Public Sub descontarStockLote(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Try
                Dim cmdLastId As New MySqlCommand("SELECT referencia, stock, lote FROM lotes WHERE lote = '" + codArti + "'", conexionmy)
                Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
                reader.Read()

                Dim stock As String = (reader.GetString(1) - unidades).ToString
                reader.Close()
                Dim linstock As String
                Dim guardo_linstock As String
                linstock = stock.ToString
                guardo_linstock = Replace(linstock, ",", ".")

                Dim cmdActualizo As New MySqlCommand("UPDATE lotes SET stock = '" + guardo_linstock + "' WHERE lote = '" + codArti + "'", conexionmy)
                cmdActualizo.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización del stock en lotes del albarán (Err_1131). Revise los datos")
                Exit Sub
            End Try

            conexionmy.Close()
        End If

    End Sub
    Public Sub aumentarStockLote(codArti As String, unidades As Decimal)
        If codArti <> "" Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Try
                Dim cmdLastId As New MySqlCommand("SELECT referencia, stock, lote FROM lotes WHERE lote = '" + codArti + "'", conexionmy)
                Dim reader As MySqlDataReader = cmdLastId.ExecuteReader()
                reader.Read()

                Dim stock As String = (reader.GetString(1) + unidades).ToString
                reader.Close()
                Dim linstock As String
                Dim guardo_linstock As String
                linstock = stock.ToString
                guardo_linstock = Replace(linstock, ",", ".")
                Dim cmdActualizo As New MySqlCommand("UPDATE lotes SET stock = '" + guardo_linstock + "' WHERE lote = '" + codArti + "'", conexionmy)
                cmdActualizo.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización del stock en lotes del albarán (Err_1132). Revise los datos")
                Exit Sub
            End Try

            conexionmy.Close()
        End If

    End Sub

    Private Sub cmdContado_Click(sender As Object, e As EventArgs) Handles cmdContado.Click
        'Modificar la cabecera para guardar como albaran de contado
        'Cambio el código del cliente por 999999 y guardo el cliene original en campo -clave
        Dim respuesta As String
        respuesta = MsgBox("¿Está seguro de que quiere convertir este Albarán en una Venta de contado?", vbYesNo)
        If respuesta = vbYes Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand("UPDATE albaran_cab SET clienteID = '999999', clave = " + txNumcli.Text + " WHERE num_albaran = " + txtNumpres.Text + "", conexionmy)
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización como albarán de contado (Err_1133). Revise los datos")
                Exit Sub
            End Try
            cargoTodosAlbaranes()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        Else
            cargoTodosAlbaranes()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If

    End Sub
    Private Sub dgAlbaranes_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgAlbaranes.CellDoubleClick
        limpiarFormulario()
        cmdLineas.Enabled = True
        cmdGuardar.Enabled = True
        cmdCancelar.Enabled = True
        cmdCliente.Enabled = True
        cmdAlbaran.Enabled = True


        txtNumpres.Text = dgAlbaranes.CurrentRow.Cells("Column1").Value.ToString
        tabPresupuestos.SelectTab(1)
        flagEdit = "S"
        dgLineasPres1.Visible = False
        dgLineasPres2.Visible = True
        dgLineasPres2.Rows.Clear()


        cargoAlbaran()
        cargoLineas()
        cmdDelete.Enabled = True
        recalcularTotales()
    End Sub

    Private Sub btPagos_Click(sender As Object, e As EventArgs) Handles btPagos.Click
        pnPagos.Visible = True
        cargoPagos()
        txFechaCobro.Text = ""
        txImporteCobro.Text = 0
        txConceptoCobro.Text = ""
        txFechaCobro.Focus()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnPagos.Visible = False

    End Sub
    Public Sub cargoPagos()
        dgCobros.Rows.Clear()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT cobrosacuenta.fecha,
                                            cobrosacuenta.importe,
                                            cobrosacuenta.concepto,
                                            cobrosacuenta.documentoID,
                                            cobrosacuenta.cobroID
                                            FROM cobrosacuenta WHERE documentoID = '" + txtNumpres.Text + "' ORDER BY cobroID", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        Try
            rdrLin = cmdLinea.ExecuteReader
            If rdrLin.HasRows Then
                Do While rdrLin.Read()
                    lineas = lineas + 1
                    dgCobros.Rows.Add()
                    dgCobros.Rows(dgCobros.Rows.Count - 1).Cells(0).Value = rdrLin("fecha")
                    dgCobros.Rows(dgCobros.Rows.Count - 1).Cells(1).Value = rdrLin("importe")
                    dgCobros.Rows(dgCobros.Rows.Count - 1).Cells(2).Value = rdrLin("concepto")
                    dgCobros.Rows(dgCobros.Rows.Count - 1).Cells(3).Value = rdrLin("documentoID")
                    dgCobros.Rows(dgCobros.Rows.Count - 1).Cells(4).Value = rdrLin("cobroID")
                Loop
            Else
            End If
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga de pagos en el albarán (Err_1134). Revise los datos")
            Exit Sub
        End Try


        rdrLin.Close()
        conexionmy.Close()
        calcularPendiente()

    End Sub

    Private Sub btRegistrar_Click(sender As Object, e As EventArgs) Handles btRegistrar.Click
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim fecha As Date = txFechaCobro.Text
        Dim impbru As String = txImporteCobro.Text
        Dim guardo_impbru As String = Replace(impbru, ",", ".")

        Dim cmd As New MySqlCommand("INSERT INTO cobrosacuenta (documentoID, fecha, importe, concepto) VALUES (" + txtNumpres.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + guardo_impbru + "', '" + txConceptoCobro.Text + "')", conexionmy)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Se ha producido un error en el registro de cobros del albarán (Err_1141). Revise los datos")
            Exit Sub
        End Try


        conexionmy.Close()
        dgCobros.Rows.Clear()

        cargoPagos()
        txFechaCobro.Text = ""
        txImporteCobro.Text = 0
        txConceptoCobro.Text = ""
        calcularPendiente()
    End Sub
    Public Sub calcularPendiente()
        Dim vPendiente As Decimal = 0
        Dim vtoRow As New DataGridViewRow
        Dim varImporte As Decimal = 0
        Try
            For Each vtoRow In dgCobros.Rows

                varImporte = varImporte + vtoRow.Cells(1).Value

            Next
            txPendienteCobro.Text = Decimal.Parse(txTotalAlbaran.Text) - varImporte
            If Decimal.Parse(txPendienteCobro.Text) = 0 Then
                btRegistrar.Enabled = False
            Else
                btRegistrar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Se ha producido un error en el cálculo de cobros pendientes del albarán (Err_1142). Revise los datos")
            Exit Sub
        End Try


    End Sub

    Private Sub btCancelPago_Click(sender As Object, e As EventArgs) Handles btCancelPago.Click

        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdEliminarLin As New MySqlCommand("DELETE FROM cobrosacuenta WHERE cobroID = '" + dgCobros.CurrentRow.Cells(4).Value.ToString + "'", conexionmy)
        Try
            cmdEliminarLin.ExecuteNonQuery()

            dgCobros.Rows.RemoveAt(dgCobros.CurrentRow.Index)
        Catch ex As Exception
            MsgBox("Se ha producido un error en la cancelación de pagos del albarán (Err_1143). Revise los datos")
            Exit Sub
        End Try

        cargoPagos()
        txFechaCobro.Text = ""
        txImporteCobro.Text = 0
        txConceptoCobro.Text = ""
        calcularPendiente()

    End Sub

    Private Sub txImporteCobro_Leave(sender As Object, e As EventArgs) Handles txImporteCobro.Leave
        Dim vImporte As Decimal
        vImporte = Decimal.Parse(txImporteCobro.Text)
        txImporteCobro.Text = vImporte.ToString("0.00")
    End Sub
    Public Sub eliminarAlbaranEditStock()

        Dim row As New DataGridViewRow
        For Each row In dgLineasPres2.Rows
            Try
                If row.Cells(11).Value = "" Then
                    artiEdit = row.Cells(2).Value
                    cantIni = Decimal.Parse(row.Cells(4).Value)
                    aumentarStock(artiEdit, cantIni)
                Else
                    artiEdit = row.Cells(11).Value
                    cantIni = Decimal.Parse(row.Cells(4).Value)
                    aumentarStockLote(artiEdit, cantIni)
                End If
            Catch ex As Exception
                MsgBox("Se ha producido un error en la actualización de stocks (Err_1151). Revise los datos")
                Exit Sub
            End Try

        Next

    End Sub

    Private Sub dgLineasPres2_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgLineasPres2.CellBeginEdit
        If (e.ColumnIndex = 4) Or (e.ColumnIndex = 7) Or (e.ColumnIndex = 8) Then
            editNumber = "S"
        End If
    End Sub
    Public Sub cargoAlbaFactura()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.facturado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE facturado = 'S' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en la carga de albaranes facturados (Err_1161). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked = True Then
            cargoTodosAlbaranes()
        End If
    End Sub

    Private Sub rbPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPendientes.CheckedChanged
        If rbPendientes.Checked = True Then
            cargoAlbaFactura()
        End If
    End Sub

    Private Sub txCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txCliente.KeyDown
        'If e.KeyCode = Keys.Enter Then

        'End If
    End Sub

    Private Sub txNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txNumero.KeyDown
        'If e.KeyCode = Keys.Enter Then

        'End If
    End Sub

    Private Sub txReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txReferencia.KeyDown
        'If e.KeyCode = Keys.Enter Then

        'End If
    End Sub

    Private Sub txHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txHasta.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim fec1 As Date = txDesde.Text
            Dim fec2 As Date = txHasta.Text

            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
            conexionmy.Open()
            Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE DATE(albaran_cab.fecha) BETWEEN '" & fec1.ToString("yyyy-MM-dd") & "' AND '" & fec2.ToString("yyyy-MM-dd") & "' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

            Dim readermy As MySqlDataReader
            Dim dtable As New DataTable
            Dim bind As New BindingSource()

            Try
                readermy = consultamy.ExecuteReader
            Catch ex As Exception
                MsgBox("Se ha producido un error en el filtro de fechas en el albarán (Err_1165). Revise los datos")
                Exit Sub
            End Try

            dtable.Load(readermy, LoadOption.OverwriteChanges)

            bind.DataSource = dtable

            dgAlbaranes.DataSource = bind
            dgAlbaranes.EnableHeadersVisualStyles = False
            Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
            styCabeceras.BackColor = Color.Beige
            styCabeceras.ForeColor = Color.Black
            styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
            dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

            dgAlbaranes.Columns(0).HeaderText = "NUMERO"
            dgAlbaranes.Columns(0).Name = "Column1"
            dgAlbaranes.Columns(0).FillWeight = 90
            dgAlbaranes.Columns(0).MinimumWidth = 90
            dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
            dgAlbaranes.Columns(1).Name = "Column2"
            dgAlbaranes.Columns(1).FillWeight = 190
            dgAlbaranes.Columns(1).MinimumWidth = 190
            dgAlbaranes.Columns(2).HeaderText = "FECHA"
            dgAlbaranes.Columns(2).Name = "Column3"
            dgAlbaranes.Columns(2).FillWeight = 90
            dgAlbaranes.Columns(2).MinimumWidth = 90
            dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
            dgAlbaranes.Columns(3).Name = "Column4"
            dgAlbaranes.Columns(3).FillWeight = 300
            dgAlbaranes.Columns(3).MinimumWidth = 300
            dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
            dgAlbaranes.Columns(4).Name = "Column5"
            dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgAlbaranes.Columns(4).FillWeight = 90
            dgAlbaranes.Columns(4).MinimumWidth = 90
            dgAlbaranes.Columns(5).HeaderText = "TOTAL"
            dgAlbaranes.Columns(5).Name = "Column6"
            dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgAlbaranes.Columns(5).FillWeight = 90
            dgAlbaranes.Columns(5).MinimumWidth = 90
            dgAlbaranes.Columns(6).Visible = False
            dgAlbaranes.Columns(7).Visible = False
            dgAlbaranes.Columns(8).Visible = False
            dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgAlbaranes.Visible = True

            conexionmy.Close()
        End If
    End Sub

    Private Sub txGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles txGeneral.KeyDown
        'If e.KeyCode = Keys.Enter Then

        'End If
    End Sub

    Private Sub dgLineasPres1_KeyDown(sender As Object, e As KeyEventArgs) Handles dgLineasPres1.KeyDown
        If e.KeyCode = Keys.Down And dgLineasPres1.CurrentRow.Index = dgLineasPres1.RowCount - 1 Then
            newLinea = "S"
        If txNumcli.Text = "" Then
            MsgBox("Antes de añadir líneas al albarán es necesario seleccionar un cliente")
            formCli = "A"
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
                    Try
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
                        dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(11).Value = ""
                        dgLineasPres1.Focus()
                        dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(2)
                        dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(2).Selected = True
                    Catch ex As Exception
                        MsgBox("Se ha producido un error en la creación de una nueva línea del albarán (Err_1171). Revise los datos")
                        Exit Sub
                    End Try

                End If
            End If
        End If
        newLinea = "N"
    End Sub

    Private Sub dgLineasPres2_KeyDown(sender As Object, e As KeyEventArgs) Handles dgLineasPres2.KeyDown
        If e.KeyCode = Keys.Down And dgLineasPres2.CurrentRow.Index = dgLineasPres2.RowCount - 1 Then
            newLinea = "S"
            If txNumcli.Text = "" Then
                MsgBox("Antes de añadir líneas al albarán es necesario seleccionar un cliente")
                formCli = "A"
                frVerClientes.Show()
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
                Try
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
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(11).Value = ""
                    dgLineasPres2.Focus()
                    dgLineasPres2.CurrentCell = dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(2)
                    dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(2).Selected = True
                Catch ex As Exception
                    MsgBox("Se ha producido un error en la creación de una nueva línea del albarán (Err_1172). Revise los datos")
                    Exit Sub
                End Try

            End If
        End If
        newLinea = "N"
    End Sub

    Private Sub rbNofacturados_CheckedChanged(sender As Object, e As EventArgs) Handles rbNofacturados.CheckedChanged
        If rbNofacturados.Checked = True Then
            cargoAlbNoFactu()
        End If
    End Sub
    Private Sub cargoAlbNoFactu()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.facturado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE facturado = 'N' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de albaranes no facturados(Err_1171). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub rbSerie1_CheckedChanged(sender As Object, e As EventArgs) Handles rbSerie1.CheckedChanged
        If rbSerie1.Checked = True Then
            cargoAlbSerie1()
        End If
    End Sub
    Private Sub cargoAlbSerie1()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.serie, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE serie = '1' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de albaranes de serie 1(Err_1172). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub rbSerie2_CheckedChanged(sender As Object, e As EventArgs) Handles rbSerie2.CheckedChanged
        If rbSerie2.Checked = True Then
            cargoAlbSerie2()
        End If
    End Sub
    Private Sub cargoAlbSerie2()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.serie, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE serie = '2' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de albaranes de serie 2(Err_1173). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub cargoAlbPagado()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.pagado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE pagado = 'S' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de albaranes no pagados(Err_1171). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub rbPagados_CheckedChanged(sender As Object, e As EventArgs) Handles rbPagados.CheckedChanged
        If rbPagados.Checked = True Then
            cargoAlbPagado()
        End If
    End Sub

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        numero_impresion = CInt(txtNumpres.Text)
        codigo_cliente_impresion = CInt(txNumcli.Text)
        tabPresupuestos.SelectedIndex = 2


        Me.clientesTableAdapter.Fill(Me.dsAlbaranes.clientes, codigo_cliente_impresion)
        'TODO: esta línea de código carga datos en la tabla 'dsPresupuesto.presupuesto_cab' Puede moverla o quitarla según sea necesario.
        Me.albaran_cabTableAdapter.Fill(Me.dsAlbaranes.albaran_cab, numero_impresion)
        'TODO: esta línea de código carga datos en la tabla 'dsPresupuesto.presupuesto_linea' Puede moverla o quitarla según sea necesario.
        Me.albaran_lineaTableAdapter.Fill(Me.dsAlbaranes.albaran_linea, numero_impresion)

        If cbSerie.Text = "S1" Then
            Me.ReportViewer1.Visible = True
            Me.ReportViewer2.Visible = False
            Me.ReportViewer1.Dock = DockStyle.Fill
            Me.ReportViewer1.RefreshReport()

        Else
            Me.ReportViewer2.Visible = True
            Me.ReportViewer1.Visible = False
            Me.ReportViewer2.Dock = DockStyle.Fill
            Me.ReportViewer2.RefreshReport()
        End If
    End Sub

    Private Sub frAlbaran_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        launcher.AlbaranesToolStripMenuItem.Enabled = True
    End Sub
    Public Sub deshabilitarBotonesLight()
        cmdGuardar.Enabled = False
        'cmdCancelar.Enabled = False
        cmdDelete.Enabled = False
        'cmdImprimir.Enabled = False
        'cmdPDF.Enabled = False
        'cmdMail.Enabled = False
        cmdAlbaran.Enabled = False
        cmdToldos.Enabled = False
        cmdCliente.Enabled = False
        cmdRentabilidad.Enabled = False
        cmdLineas.Enabled = False
    End Sub

    Private Sub txCliente_TextChanged(sender As Object, e As EventArgs) Handles txCliente.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE clientes.nombre LIKE'%" & txCliente.Text & "%' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de clientes (Err_1162). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub txNumero_TextChanged(sender As Object, e As EventArgs) Handles txNumero.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE albaran_cab.num_albaran LIKE '" & txNumero.Text & "%' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de números de albarán (Err_1163). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub txReferencia_TextChanged(sender As Object, e As EventArgs) Handles txReferencia.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE albaran_cab.referencia LIKE'%" & txReferencia.Text & "%' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro de referencias en el albarán (Err_1164). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub

    Private Sub txGeneral_TextChanged(sender As Object, e As EventArgs) Handles txGeneral.TextChanged
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT albaran_cab.num_albaran, 
                                                    albaran_cab.referencia,
                                                    albaran_cab.fecha, 
                                                    clientes.nombre, 
                                                    albaran_cab.totalbruto, 
                                                    albaran_cab.totalalbaran, 
                                                    albaran_cab.clienteID,
                                                    albaran_cab.eliminado, 
                                                    clientes.clienteID
                                            FROM albaran_cab INNER JOIN clientes ON albaran_cab.clienteID=clientes.clienteID WHERE albaran_cab.referencia LIKE'%" & txReferencia.Text & "%' ORDER BY albaran_cab.num_albaran DESC", conexionmy)

        Dim readermy As MySqlDataReader
        Dim dtable As New DataTable
        Dim bind As New BindingSource()

        Try
            readermy = consultamy.ExecuteReader
        Catch ex As Exception
            MsgBox("Se ha producido un error en el filtro general de albaranes (Err_1166). Revise los datos")
            Exit Sub
        End Try

        dtable.Load(readermy, LoadOption.OverwriteChanges)

        bind.DataSource = dtable

        dgAlbaranes.DataSource = bind
        dgAlbaranes.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.Beige
        styCabeceras.ForeColor = Color.Black
        styCabeceras.Font = New Font("Verdana", 9, FontStyle.Bold)
        dgAlbaranes.ColumnHeadersDefaultCellStyle = styCabeceras

        dgAlbaranes.Columns(0).HeaderText = "NUMERO"
        dgAlbaranes.Columns(0).Name = "Column1"
        dgAlbaranes.Columns(0).FillWeight = 90
        dgAlbaranes.Columns(0).MinimumWidth = 90
        dgAlbaranes.Columns(1).HeaderText = "REFERENCIA"
        dgAlbaranes.Columns(1).Name = "Column2"
        dgAlbaranes.Columns(1).FillWeight = 190
        dgAlbaranes.Columns(1).MinimumWidth = 190
        dgAlbaranes.Columns(2).HeaderText = "FECHA"
        dgAlbaranes.Columns(2).Name = "Column3"
        dgAlbaranes.Columns(2).FillWeight = 90
        dgAlbaranes.Columns(2).MinimumWidth = 90
        dgAlbaranes.Columns(3).HeaderText = "CLIENTE"
        dgAlbaranes.Columns(3).Name = "Column4"
        dgAlbaranes.Columns(3).FillWeight = 300
        dgAlbaranes.Columns(3).MinimumWidth = 300
        dgAlbaranes.Columns(4).HeaderText = "IMPORTE"
        dgAlbaranes.Columns(4).Name = "Column5"
        dgAlbaranes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(4).FillWeight = 90
        dgAlbaranes.Columns(4).MinimumWidth = 90
        dgAlbaranes.Columns(5).HeaderText = "TOTAL"
        dgAlbaranes.Columns(5).Name = "Column6"
        dgAlbaranes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgAlbaranes.Columns(5).FillWeight = 90
        dgAlbaranes.Columns(5).MinimumWidth = 90
        dgAlbaranes.Columns(6).Visible = False
        dgAlbaranes.Columns(7).Visible = False
        dgAlbaranes.Columns(8).Visible = False
        dgAlbaranes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAlbaranes.Visible = True

        conexionmy.Close()
    End Sub
End Class
