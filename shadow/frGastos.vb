Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frGastos
    Public Shared lineas As Int16
    Public Shared pos As Integer
    Public Shared flagEdit As String = "N"
    Public Shared lineasEdit As New List(Of lineasEditadas)
    Public Shared artiEdit As String
    Public Shared cantIni As Decimal
    Public Shared cantFin As Decimal
    Public Shared serieIni As String
    Public Shared vTotal As String
    Public Shared fechadiapago As Date
    Public Shared newLinea As String = "N"
    Public Shared editNumber As String = "N"
    Private Sub frGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        cargoTodosGastos()
    End Sub
    Public Sub deshabilitarBotones()
        cmdGuardar.Enabled = False
        cmdCancelar.Enabled = False
        cmdDelete.Enabled = False
        cmdImprimir.Enabled = False
        cmdPDF.Enabled = False
        cmdMail.Enabled = False
        cmdCliente.Enabled = False
        cmdLineas.Enabled = False
    End Sub
    Public Sub cargoTodosGastos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos + "; Convert Zero Datetime=True")
        conexionmy.Open()
        Dim consultamy As New MySqlCommand("SELECT gastos_cab.num_gasto, 
                                                    gastos_cab.fecha, 
                                                    proveedores.nombre, 
                                                    gastos_cab.totalbruto, 
                                                    gastos_cab.totalgasto, 
                                                    gastos_cab.proveedorID, 
                                                    proveedores.proveedorID 
                                            FROM gastos_cab INNER JOIN proveedores ON gastos_cab.proveedorID=proveedores.proveedorID ORDER BY gastos_cab.num_gasto DESC", conexionmy)

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
        dgPedidos.Columns(1).HeaderText = "FECHA"
        dgPedidos.Columns(1).Name = "Column3"
        dgPedidos.Columns(1).FillWeight = 90
        dgPedidos.Columns(1).MinimumWidth = 90
        dgPedidos.Columns(2).HeaderText = "PROVEEDOR"
        dgPedidos.Columns(2).Name = "Column4"
        dgPedidos.Columns(2).FillWeight = 300
        dgPedidos.Columns(2).MinimumWidth = 300
        dgPedidos.Columns(3).HeaderText = "IMPORTE"
        dgPedidos.Columns(3).Name = "Column5"
        dgPedidos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgPedidos.Columns(3).FillWeight = 90
        dgPedidos.Columns(3).MinimumWidth = 90
        dgPedidos.Columns(4).HeaderText = "TOTAL"
        dgPedidos.Columns(4).Name = "Column6"
        dgPedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgPedidos.Columns(4).FillWeight = 90
        dgPedidos.Columns(4).MinimumWidth = 90
        dgPedidos.Columns(5).Visible = False
        dgPedidos.Columns(6).Visible = False
        dgPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPedidos.Visible = True

        conexionmy.Close()
    End Sub
    Public Sub limpiarFormulario()
        txtNumpres.Text = ""
        txFecha.Text = ""
        txNumcli.Text = ""
        txFraProv.Text = ""
        txClientepres.Text = ""
        txDtocli.Text = ""
        txIva.Text = "21.00"
        'cbEstado.Text = "SUELDOS Y SALARIOS"
        ckPagado.Checked = False
        ckExento.Checked = False
        ckIva.Checked = False
        txDni.Text = ""
        txImpBruto.Text = 0
        txImpDto.Text = 0
        txImponible.Text = 0
        txImpIva.Text = 0
        txImpRecargo.Text = 0
        txImpRetencion.Text = 0
        txPorcRet.Text = 0
        txPorcRet.Visible = False
        txTotalAlbaran.Text = 0
        'cbFormapago.Text = "CONTADO"
        txDiaspago.Text = ""
        tsBotones.Focus()
        cmdNuevo.Select()
        dgLineasPres1.Rows.Clear()
        dgPlazos.Rows.Clear()
    End Sub

    Private Sub cmdLineas_ButtonClick(sender As Object, e As EventArgs) Handles cmdLineas.ButtonClick
        newLinea = "S"
        If txNumcli.Text = "" Then
            MsgBox("Antes de añadir líneas de gastos es necesario seleccionar un proveedor")
            formCli = "G"
            frVerProveedores.Show()
        Else
            If flagEdit = "N" Then
                If dgLineasPres1.RowCount = 0 Then
                    lineas = 0
                End If
                For Each row As DataGridViewRow In dgLineasPres1.Rows
                    If row.Cells(2).Value Is Nothing Then
                        MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                        Exit Sub
                    End If
                Next
                lineas = lineas + 1
                dgLineasPres1.Rows.Add()
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(0).Value = lineas
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(3).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(4).Value = txDtocli.Text
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres1.Focus()
                dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(1)
                dgLineasPres1.Rows(dgLineasPres1.Rows.Count - 1).Cells(1).Selected = True
            Else
                If dgLineasPres2.RowCount = 0 Then
                    lineas = 0
                End If
                For Each row As DataGridViewRow In dgLineasPres2.Rows
                    If row.Cells(2).Value Is Nothing Then
                        MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                        Exit Sub
                    End If
                Next
                lineas = lineas + 1
                dgLineasPres2.Rows.Add()
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(0).Value = lineas
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(3).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = txDtocli.Text
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(5).Value = 0
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(6).Value = 0
                dgLineasPres2.Focus()
                dgLineasPres2.CurrentCell = dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(1)
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(1).Selected = True
            End If

        End If
        newLinea = "N"
    End Sub

    Private Sub INSERTARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTARToolStripMenuItem.Click
        newLinea = "S"
        If flagEdit = "N" Then
            For Each row As DataGridViewRow In dgLineasPres1.Rows
                If row.Cells(2).Value Is Nothing Then
                    MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                    Exit Sub
                End If
            Next
            dgLineasPres1.Rows.Insert(dgLineasPres1.CurrentRow.Index)
            renumerar()
            dgLineasPres1.CurrentCell = dgLineasPres1.Rows(dgLineasPres1.CurrentRow.Index - 1).Cells(1)

            pos = dgLineasPres1.CurrentRow.Index

            dgLineasPres1.CurrentRow.Cells(3).Value = 0
            dgLineasPres1.CurrentRow.Cells(4).Value = txDtocli.Text
            dgLineasPres1.CurrentRow.Cells(5).Value = 0
            dgLineasPres1.CurrentRow.Cells(6).Value = 0

        Else
            For Each row As DataGridViewRow In dgLineasPres2.Rows
                If row.Cells(2).Value Is Nothing Then
                    MsgBox("No se pueden añadir líneas nuevas hasta completar las lineas anteriores. Introduzca una descripción")
                    Exit Sub
                End If
            Next
            dgLineasPres2.Rows.Insert(dgLineasPres2.CurrentRow.Index)
            renumerar()
            dgLineasPres2.CurrentCell = dgLineasPres2.Rows(dgLineasPres2.CurrentRow.Index - 1).Cells(1)

            pos = dgLineasPres2.CurrentRow.Index

            dgLineasPres2.CurrentRow.Cells(3).Value = 0
            dgLineasPres2.CurrentRow.Cells(4).Value = txDtocli.Text
            dgLineasPres2.CurrentRow.Cells(5).Value = 0
            dgLineasPres2.CurrentRow.Cells(6).Value = 0

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
                totalLinea = totalLinea + Decimal.Parse(row2.Cells(6).Value)
                dtoLinea = dtoLinea + (Decimal.Parse(row2.Cells(5).Value) * Decimal.Parse(row2.Cells(4).Value)) / 100
            Next
        Else
            For Each row2 As DataGridViewRow In dgLineasPres2.Rows
                totalLinea = totalLinea + Decimal.Parse(row2.Cells(6).Value)
                dtoLinea = dtoLinea + (Decimal.Parse(row2.Cells(5).Value) * Decimal.Parse(row2.Cells(4).Value)) / 100
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

        If ckRetencion.Checked = True Then
            mostrarRetencion()
        End If

    End Sub
    Public Sub actualizarLinea()
        If flagEdit = "N" Then
            If dgLineasPres1.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal


                total2 = Decimal.Parse(dgLineasPres1.CurrentRow.Cells(3).Value) * Decimal.Parse(dgLineasPres1.CurrentRow.Cells(5).Value)
                dto2 = (total2 * Decimal.Parse(dgLineasPres1.CurrentRow.Cells(4).Value)) / 100

                totaldef = (total2 - dto2).ToString("0.00")

                dgLineasPres1.CurrentRow.Cells(6).Value = totaldef
            End If
        Else
            If dgLineasPres2.CurrentRow IsNot Nothing Then
                Dim total2 As Decimal
                Dim dto2 As Decimal
                Dim totaldef As Decimal


                total2 = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(3).Value) * Decimal.Parse(dgLineasPres2.CurrentRow.Cells(5).Value)
                dto2 = (total2 * Decimal.Parse(dgLineasPres2.CurrentRow.Cells(4).Value)) / 100


                totaldef = (total2 - dto2).ToString("0.00")

                dgLineasPres2.CurrentRow.Cells(6).Value = totaldef
            End If
        End If


    End Sub

    Private Sub dgLineasPres1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellEndEdit
        If (e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5) Then
            actualizarLinea()
            recalcularTotales()
        End If
    End Sub

    Private Sub dgLineasPres1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellClick
        pos = dgLineasPres1.CurrentRow.Index
    End Sub

    Private Sub cmdCliente_ButtonClick(sender As Object, e As EventArgs) Handles cmdCliente.ButtonClick
        formCli = "G"
        frVerProveedores.Show()
    End Sub

    Private Sub ELIMINARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELIMINARToolStripMenuItem.Click
        If flagEdit = "N" Then
            dgLineasPres1.Rows.RemoveAt(dgLineasPres1.CurrentRow.Index)
            renumerar()
            recalcularTotales()
        Else

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
        dgLineasPres1.Enabled = True
        cargoEpigrafes()
        cargoFormaPago()
        txFecha.Text = Format(Today, "ddMMyyyy")
        txFraProv.Focus()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdNuevo.Enabled = True
        deshabilitarBotones()
        limpiarFormulario()
        If flagEdit = "S" Then
            dgLineasPres2.Rows.Clear()
            dgPlazos.Rows.Clear()
            flagEdit = "N"
        Else
            dgLineasPres1.Rows.Clear()
            dgPlazos.Rows.Clear()
        End If
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
            Dim imprecargo As String = Replace(txImpRecargo.Text.ToString, ".", "")
            Dim guardo_imprecargo As String = Replace(imprecargo, ",", ".")
            Dim impretencion As String = Replace(txImpRetencion.Text.ToString, ".", "")
            Dim guardo_impretencion As String = Replace(impretencion, ",", ".")
            Dim porcretencion As String = Replace(txPorcRet.Text.ToString, ".", "")
            Dim guardo_porcretencion As String = Replace(porcretencion, ",", ".")

            Dim fecha As Date = txFecha.Text
            Dim vPagado As String
            Dim vExento As String
            Dim vIvainc As String
            Dim vRetencion As String


            If ckPagado.Checked = True Then
                vPagado = "S"
            Else
                vPagado = "N"
            End If

            If ckExento.Checked = True Then
                vExento = "S"
            Else
                vExento = "N"
            End If

            If ckIva.Checked = True Then
                vIvainc = "S"
            Else
                vIvainc = "N"
            End If

            If ckRetencion.Checked = True Then
                vRetencion = "S"
            Else
                vRetencion = "N"
            End If

            'Guardo cabecera y actualizo número de presupuesto
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand("INSERT INTO gastos_cab (num_gasto, proveedorID, empresaID, usuarioID, fecha, fraproveedor, pagado, exento, ivaincluido, retiene, epigrafeID, epigrafe, retencion, totalretencion, formaID, formapago, diaspago, totalbruto, totaldto, totaliva, totalgasto, totalrecargo) VALUES (" + txtNumpres.Text + ", " + txNumcli.Text + ", " + txEmpresa.Text + ", " + txUsuario.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + txFraProv.Text + "', '" + vPagado + "', '" + vExento + "', '" + vIvainc + "', '" + vRetencion + "', " + cbEstado.SelectedValue.ToString + ", '" + cbEstado.Text + "', '" + guardo_porcretencion + "', '" + guardo_impretencion + "', " + cbFormapago.SelectedValue.ToString + ", '" + cbFormapago.Text + "', '" + txDiaspago.Text + "', '" + guardo_impbru + "', '" + guardo_impdto + "',  '" + guardo_impiva + "', '" + guardo_imptot + "', '" + guardo_imprecargo + "')", conexionmy)
            cmd.ExecuteNonQuery()

            Dim cmdActualizar As New MySqlCommand("UPDATE configuracion SET num_gasto = '" + txtNumpres.Text + "'", conexionmy)
            cmdActualizar.ExecuteNonQuery()



            'Guardo líneas del presupuesto

            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow

            Dim lincant As String
            Dim guardo_lincant As String
            Dim linprec As String
            Dim guardo_linprec As String
            Dim lindto As String
            Dim guardo_lindto As String
            Dim liniva As String
            Dim guardo_liniva As String
            Dim lintotal As String
            Dim guardo_lintotal As String
            Dim arti As String

            For Each row In dgLineasPres1.Rows


                lincant = Decimal.Parse(row.Cells(3).Value).ToString("0.00")
                guardo_lincant = Replace(lincant, ",", ".")

                linprec = row.Cells(5).Value.ToString
                guardo_linprec = Replace(linprec, ",", ".")

                lindto = row.Cells(4).Value.ToString
                guardo_lindto = Replace(lindto, ",", ".")

                liniva = txIva.Text
                guardo_liniva = Replace(liniva, ",", ".")

                lintotal = row.Cells(6).Value.ToString
                guardo_lintotal = Replace(lintotal, ",", ".")

                arti = row.Cells(2).Value

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO gastos_linea (num_gasto, linea, codigo, descripcion, cantidad, descuento, importe, totalinea, ivalinea) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(1).Value + "', '" + row.Cells(2).Value + "', '" + guardo_lincant + "', '" + guardo_lindto + "', '" + guardo_linprec + "', '" + guardo_lintotal + "', '" + guardo_liniva + "')"

                cmdLinea.ExecuteNonQuery()
                'descontarStock(arti, lincant)

            Next

            conexionmy.Close()

            grabarVencimientos()


            deshabilitarBotones()
            limpiarFormulario()
            cmdNuevo.Enabled = True
            cargoTodosGastos()
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
            Dim imprecargo As String = Replace(txImpRecargo.Text.ToString, ".", "")
            Dim guardo_imprecargo As String = Replace(imprecargo, ",", ".")
            Dim impretencion As String = Replace(txImpRetencion.Text.ToString, ".", "")
            Dim guardo_impretencion As String = Replace(impretencion, ",", ".")
            Dim porcretencion As String = Replace(txPorcRet.Text.ToString, ".", "")
            Dim guardo_porcretencion As String = Replace(porcretencion, ",", ".")

            Dim fecha As Date = txFecha.Text
            Dim vPagado As String
            Dim vExento As String
            Dim vIvainc As String
            Dim vRetencion As String


            If ckPagado.Checked = True Then
                vPagado = "S"
            Else
                vPagado = "N"
            End If

            If ckExento.Checked = True Then
                vExento = "S"
            Else
                vExento = "N"
            End If

            If ckIva.Checked = True Then
                vIvainc = "S"
            Else
                vIvainc = "N"
            End If

            If ckRetencion.Checked = True Then
                vRetencion = "S"
            Else
                vRetencion = "N"
            End If

            'Guardo cabecera y actualizo número de presupuesto


            Dim cmd As New MySqlCommand("UPDATE gastos_cab SET fecha = '" + fecha.ToString("yyyy-MM-dd") + "', proveedorID = " + txNumcli.Text + ", pagado = '" + vPagado + "',  ivaincluido = '" + vIvainc + "', exento = '" + vExento + "', retiene = '" + vRetencion + "', totalbruto = '" + guardo_impbru + "', totaldto = '" + guardo_impdto + "', totaliva = '" + guardo_impiva + "', totalgasto = '" + guardo_imptot + "', retencion = '" + guardo_porcretencion + "', totalretencion = '" + guardo_impretencion + "' WHERE num_gasto = " + txtNumpres.Text + "", conexionmy)
            cmd.ExecuteNonQuery()


            'Guardo líneas del presupuesto

            Dim cmdEliminar As New MySqlCommand("DELETE FROM gastos_linea WHERE num_gasto = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

            Dim cmdLinea As New MySqlCommand
            Dim row As New DataGridViewRow

            Dim lincant As String
            Dim guardo_lincant As String
            Dim linprec As String
            Dim guardo_linprec As String
            Dim lindto As String
            Dim guardo_lindto As String
            Dim liniva As String
            Dim guardo_liniva As String
            Dim lintotal As String
            Dim guardo_lintotal As String
            Dim arti As String

            For Each row In dgLineasPres2.Rows


                lincant = Decimal.Parse(row.Cells(3).Value).ToString("0.00")
                guardo_lincant = Replace(lincant, ",", ".")

                linprec = row.Cells(5).Value.ToString
                guardo_linprec = Replace(linprec, ",", ".")

                lindto = row.Cells(4).Value.ToString
                guardo_lindto = Replace(lindto, ",", ".")

                liniva = txIva.Text
                guardo_liniva = Replace(liniva, ",", ".")

                lintotal = row.Cells(6).Value.ToString
                guardo_lintotal = Replace(lintotal, ",", ".")

                arti = row.Cells(2).Value

                cmdLinea.Connection = conexionmy
                cmdLinea.CommandText = "INSERT INTO gastos_linea (num_gasto, linea, codigo, descripcion, cantidad, descuento, importe, totalinea, ivalinea) VALUES ('" + txtNumpres.Text + "', " + row.Cells(0).Value.ToString + ", '" + row.Cells(1).Value + "', '" + row.Cells(2).Value + "', '" + guardo_lincant + "', '" + guardo_lindto + "', '" + guardo_linprec + "', '" + guardo_lintotal + "', '" + guardo_liniva + "')"

                cmdLinea.ExecuteNonQuery()


            Next

            Dim cmdEliminarVto As New MySqlCommand("DELETE FROM vto_gastos WHERE gastoID = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminarVto.ExecuteNonQuery()

            conexionmy.Close()

            grabarVencimientos()

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
            cargoTodosGastos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"
        End If
    End Sub
    Public Sub cargoNumero()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()

        Dim numid As Int32


        Dim cmdLastId As New MySqlCommand("SELECT num_gasto FROM configuracion  ", conexionmy)
        numid = cmdLastId.ExecuteScalar()


        txtNumpres.Text = numid + 1

        conexionmy.Close()

    End Sub
    Public Sub cargoGasto()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdCab As New MySqlCommand

        Dim cmdCli As New MySqlCommand

        Dim rdrCab As MySqlDataReader

        Dim rdrCli As MySqlDataReader


        cmdCab = New MySqlCommand("SELECT * FROM gastos_cab WHERE num_gasto = '" + txtNumpres.Text + "'", conexionmy)

        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        rdrCab.Read()
        txFecha.Text = rdrCab("fecha")
        txNumcli.Text = rdrCab("proveedorID")
        txFraProv.Text = rdrCab("fraproveedor")

        If rdrCab("pagado") = "S" Then
            ckPagado.Checked = True
        Else
            ckPagado.Checked = False
        End If

        If rdrCab("exento") = "S" Then
            ckExento.Checked = True
        Else
            ckExento.Checked = False
        End If

        If rdrCab("ivaincluido") = "S" Then
            ckIva.Checked = True
        Else
            ckIva.Checked = False
        End If
        If rdrCab("retiene") = "S" Then
            ckRetencion.Checked = True
            txPorcRet.Text = rdrCab("retencion")
            txPorcRet.Visible = True
        Else
            ckRetencion.Checked = False
        End If


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
        cargoFormaPago()
        cargoVencimientos()
    End Sub
    Public Sub cargoLineas()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT gastos_linea.linea,
                                            gastos_linea.codigo,
                                            gastos_linea.descripcion,
                                            gastos_linea.cantidad,
                                            gastos_linea.descuento,
                                            gastos_linea.ivalinea,
                                            gastos_linea.importe,
                                            gastos_linea.totalinea,
                                            gastos_linea.num_gasto
                                            FROM gastos_linea WHERE num_gasto = '" + txtNumpres.Text + "' ORDER BY gastos_linea.linea", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        rdrLin = cmdLinea.ExecuteReader
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                lineas = lineas + 1
                dgLineasPres2.Rows.Add()
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(0).Value = rdrLin("linea")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(1).Value = rdrLin("codigo")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(2).Value = rdrLin("descripcion")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(3).Value = rdrLin("cantidad")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(4).Value = rdrLin("descuento")
                'dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(9).Value = rdrLin("ivalinea")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(5).Value = rdrLin("importe")
                dgLineasPres2.Rows(dgLineasPres2.Rows.Count - 1).Cells(6).Value = rdrLin("totalinea")

            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()

        recalcularTotales()
    End Sub

    Private Sub dgLineasPres2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellClick
        pos = dgLineasPres2.CurrentRow.Index
    End Sub

    Private Sub dgLineasPres2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellEndEdit
        If (e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5) Then
            actualizarLinea()
            recalcularTotales()
        End If
        If (e.ColumnIndex = 3) Then
            cantFin = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(3).Value)
            lineasEdit.Add(New lineasEditadas() With {.codigoArt = artiEdit, .cantAntes = cantIni, .cantDespues = cantFin})
        End If
    End Sub
    Public Sub recalcularDescuentos()
        For Each row2 As DataGridViewRow In dgLineasPres2.Rows
            row2.Cells(4).Value = Decimal.Parse(txDtocli.Text).ToString("0.00")
            actualizarLinea()
        Next
        recalcularTotales()

    End Sub

    Private Sub dgLineasPres2_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellEnter
        If (e.ColumnIndex = 3) Then
            artiEdit = dgLineasPres2.CurrentRow.Cells(1).Value
            cantIni = Decimal.Parse(dgLineasPres2.CurrentRow.Cells(3).Value)
        End If
    End Sub
    Public Sub cargoEpigrafes()
        cbEstado.ResetText()

        Dim cn As MySqlConnection
        Dim cm As MySqlCommand

        Dim da As MySqlDataAdapter
        Dim ds As DataSet
        cn = New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)

        cn.Open()
        cm = New MySqlCommand("SELECT epigrafeID, epigrafe FROM epigrafes", cn)


        cm.CommandType = CommandType.Text
        cm.Connection = cn

        da = New MySqlDataAdapter(cm)
        ds = New DataSet()
        da.Fill(ds)


        cbEstado.DataSource = ds.Tables(0)
        cbEstado.DisplayMember = ds.Tables(0).Columns("epigrafe").ToString
        cbEstado.ValueMember = "epigrafeID"

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

                If (e.ColumnIndex = 3) Then
                    value1 = dgLineasPres1.CurrentRow.Cells(3).EditedFormattedValue.ToString
                    value1 = value1.Replace(".", ",")
                    If value1 <> "" Then
                        Dim cellValue As Decimal = CType(value1, Decimal)
                        dgLineasPres1.CurrentRow.Cells(3).Value = cellValue
                    End If
                End If
                If (e.ColumnIndex = 4) Then
                    value2 = dgLineasPres1.CurrentRow.Cells(4).EditedFormattedValue.ToString
                    value2 = value2.Replace(".", ",")
                    If value2 <> "" Then
                        Dim cellValue As Decimal = CType(value2, Decimal)
                        dgLineasPres1.CurrentRow.Cells(4).Value = cellValue
                    End If
                End If
                If (e.ColumnIndex = 5) Then
                    value3 = dgLineasPres1.CurrentRow.Cells(5).EditedFormattedValue.ToString
                    value3 = value3.Replace(".", ",")
                    If value3 <> "" Then
                        Dim cellValue As Decimal = CType(value3, Decimal)
                        dgLineasPres1.CurrentRow.Cells(5).Value = cellValue
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgLineasPres1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres1.CellLeave
        If (e.ColumnIndex = 5) Then
            tsBotones.Focus()
            cmdLineas.Select()
        End If
    End Sub

    Private Sub dgLineasPres2_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellLeave
        If (e.ColumnIndex = 5) Then
            tsBotones.Focus()
            cmdLineas.Select()
        End If
    End Sub

    Private Sub dgLineasPres2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgLineasPres2.CellValueChanged
        If newLinea = "N" Then
            Dim value1 As String = ""
            Dim value2 As String = ""
            Dim value3 As String = ""
            If dgLineasPres1.CurrentCell Is Nothing Then
                Exit Sub
            Else

                If (e.ColumnIndex = 3) Then
                    If editNumber = "S" Then
                        value1 = dgLineasPres2.CurrentRow.Cells(3).EditedFormattedValue.ToString
                        value1 = value1.Replace(".", ",")
                    Else
                        value1 = Replace(dgLineasPres2.CurrentRow.Cells(3).EditedFormattedValue.ToString, ".", "")
                    End If
                    If value1 <> "" Then
                        Dim cellValue As Decimal = CType(value1, Decimal)
                        dgLineasPres1.CurrentRow.Cells(3).Value = cellValue
                    End If
                End If
                If (e.ColumnIndex = 4) Then
                    If editNumber = "S" Then
                        value2 = dgLineasPres2.CurrentRow.Cells(4).EditedFormattedValue.ToString
                        value2 = value2.Replace(".", ",")
                    Else
                        value2 = Replace(dgLineasPres2.CurrentRow.Cells(4).EditedFormattedValue.ToString, ".", "")
                    End If
                    If value2 <> "" Then
                        Dim cellValue As Decimal = CType(value2, Decimal)
                        dgLineasPres1.CurrentRow.Cells(4).Value = cellValue
                    End If
                End If
                If (e.ColumnIndex = 5) Then
                    If editNumber = "S" Then
                        value3 = dgLineasPres2.CurrentRow.Cells(5).EditedFormattedValue.ToString
                        value3 = value3.Replace(".", ",")
                    Else
                        value3 = Replace(dgLineasPres2.CurrentRow.Cells(5).EditedFormattedValue.ToString, ".", "")
                    End If
                    If value3 <> "" Then
                        Dim cellValue As Decimal = CType(value3, Decimal)
                        dgLineasPres1.CurrentRow.Cells(5).Value = cellValue
                    End If
                    editNumber = "N"
                End If
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim respuesta As String
        respuesta = MsgBox("El borrado de gastos es una acción no recuperable. También se eliminarán vencimientos ¿Está seguro?", vbYesNo)
        If respuesta = vbYes Then
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()

            Dim cmdEliminar As New MySqlCommand("DELETE FROM gastos_cab WHERE num_gasto = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminar.ExecuteNonQuery()

            Dim cmdEliminarLineas As New MySqlCommand("DELETE FROM gastos_linea WHERE num_gasto = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminarLineas.ExecuteNonQuery()

            Dim cmdEliminarVto As New MySqlCommand("DELETE FROM vto_gastos WHERE gastoID = '" + txtNumpres.Text + "'", conexionmy)
            cmdEliminarLineas.ExecuteNonQuery()

            conexionmy.Close()
            deshabilitarBotones()
            limpiarFormulario()
            dgLineasPres2.Rows.Clear()
            cmdNuevo.Enabled = True
            cargoTodosGastos()
            tabPresupuestos.SelectTab(0)
            flagEdit = "N"

        End If
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
    Public Sub recalcularPlazos()
        'Recalcular lo plazos de pago y el grid con los vencimientos
        dgPlazos.Rows.Clear()

        If txDiaspago.Text = "" Then
            MsgBox("Para calcular los vencimientos es necesario introducir un día de pago")
        Else
            Dim vDia As String
            Dim vMes As String
            Dim vYear As String
            Dim vFechahoy As String = txFecha.Text


            vDia = txDiaspago.Text
            vMes = vFechahoy.Substring(3, 2)
            vYear = vFechahoy.Substring(6, 4)
            fechadiapago = vDia + "/" + vMes + "/" + vYear


            If cbFormapago.SelectedValue = 1 Then
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = txFecha.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
            End If
            If cbFormapago.SelectedValue = 2 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
            End If
            If cbFormapago.SelectedValue = 3 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
            End If
            If cbFormapago.SelectedValue = 4 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo As Date = DateAdd(DateInterval.Month, 3, fechahoy)
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = txTotalAlbaran.Text
            End If
            If cbFormapago.SelectedValue = 5 Then
                Dim fechahoy As Date = fechadiapago
                Dim fechaplazo1 As Date = DateAdd(DateInterval.Month, 1, fechahoy)
                Dim fechaplazo2 As Date = DateAdd(DateInterval.Month, 2, fechahoy)
                Dim vImportePlazo As Decimal
                vImportePlazo = Decimal.Parse(txTotalAlbaran.Text) / 2

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo1.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")
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
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

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
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo4.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

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
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo4.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo5.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

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
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo2.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo3.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo4.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo5.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = fechaplazo6.ToString("dd/MM/yyyy")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = "Pago fra. " + txFraProv.Text
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = vImportePlazo.ToString("0.00")

            End If
        End If
    End Sub

    Private Sub btRecalcular_Click(sender As Object, e As EventArgs) Handles btRecalcular.Click
        recalcularPlazos()
    End Sub
    Public Sub calcularRetencion()
        txPorcRet.Visible = True
        txPorcRet.Text = 0

    End Sub

    Private Sub ckRetencion_CheckedChanged(sender As Object, e As EventArgs) Handles ckRetencion.CheckedChanged
        If ckRetencion.Checked = True Then
            calcularRetencion()
            vTotal = txTotalAlbaran.Text
        Else
            txPorcRet.Text = 0
            txPorcRet.Visible = False
            txImpRetencion.Text = 0
            txTotalAlbaran.Text = vTotal
        End If
    End Sub

    Private Sub txPorcRet_Leave(sender As Object, e As EventArgs) Handles txPorcRet.Leave
        recalcularTotales()
    End Sub

    Private Sub ckPagado_CheckedChanged(sender As Object, e As EventArgs) Handles ckPagado.CheckedChanged
        If ckPagado.Checked = True Then
            cbFormapago.SelectedIndex = 0
            Dim vFechahoy As String = txFecha.Text
            Dim vDia As String
            vDia = vFechahoy.Substring(0, 2)
            txDiaspago.Text = vDia
            dgPlazos.Rows.Clear()
            recalcularPlazos()
            cbFormapago.Enabled = False
            txDiaspago.Enabled = False
        Else
            cbFormapago.Enabled = True
            txDiaspago.Enabled = True
        End If
    End Sub
    Public Sub grabarVencimientos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim vPagado As String
        Dim orden As Int16 = 0
        Dim linImporte As String
        Dim guardo_linimporte As String

        If ckPagado.Checked = True Then
            vPagado = "S"
        Else
            vPagado = "N"
        End If

        For Each row In dgPlazos.Rows
            orden = orden + 1

            Dim fecha As Date = row.Cells(0).Value
            linImporte = Decimal.Parse(row.Cells(2).Value).ToString("0.00")
            guardo_linimporte = Replace(linImporte, ",", ".")

            Dim cmd As New MySqlCommand("INSERT INTO vto_gastos (gastoID, fecha, concepto, importe, orden, pagado) VALUES (" + txtNumpres.Text + ", '" + fecha.ToString("yyyy-MM-dd") + "',  '" + row.Cells(1).Value + "', '" + guardo_linimporte + "', '" + orden.ToString + "', '" + vPagado + "')", conexionmy)
            cmd.ExecuteNonQuery()
        Next
        conexionmy.Close()

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


        cargoGasto()
        cargoLineas()
        cmdDelete.Enabled = True
        recalcularTotales()
    End Sub
    Public Sub cargoVencimientos()
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim cmdLinea As New MySqlCommand

        cmdLinea = New MySqlCommand("SELECT vto_gastos.fecha,
                                            vto_gastos.concepto,
                                            vto_gastos.importe
                                            FROM vto_gastos WHERE gastoID = '" + txtNumpres.Text + "' ORDER BY vto_gastos.orden", conexionmy)

        cmdLinea.CommandType = CommandType.Text
        cmdLinea.Connection = conexionmy

        Dim rdrLin As MySqlDataReader
        rdrLin = cmdLinea.ExecuteReader
        If rdrLin.HasRows Then
            Do While rdrLin.Read()
                lineas = lineas + 1
                dgPlazos.Rows.Add()
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(0).Value = rdrLin("fecha")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(1).Value = rdrLin("concepto")
                dgPlazos.Rows(dgPlazos.Rows.Count - 1).Cells(2).Value = rdrLin("importe")
            Loop
        Else

        End If

        rdrLin.Close()
        conexionmy.Close()

    End Sub
    Public Sub mostrarRetencion()
        Dim vRetencion As Decimal = 0
        Dim vTotalMinusRetencion As Decimal = 0
        Dim vPorc As Decimal


        vRetencion = (Decimal.Parse(txImponible.Text) * Decimal.Parse(txPorcRet.Text)) / 100
        vTotalMinusRetencion = Decimal.Parse(txTotalAlbaran.Text) - vRetencion

        txImpRetencion.Text = vRetencion.ToString("0.00")
        txTotalAlbaran.Text = vTotalMinusRetencion.ToString("0.00")
        vPorc = txPorcRet.Text
        txPorcRet.Text = vPorc.ToString("0.00")
    End Sub

    Private Sub dgLineasPres2_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgLineasPres2.CellBeginEdit
        If (e.ColumnIndex = 3) Or (e.ColumnIndex = 4) Or (e.ColumnIndex = 5) Then
            editNumber = "S"
        End If
    End Sub
End Class