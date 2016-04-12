Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frRecalcular
    Private Sub btRecalculoPres_Click(sender As Object, e As EventArgs) Handles btRecalculoPres.Click
        'Recalcular los totales para las cabeceras de presupuestos
        Dim vNumPres As String
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim conexionmy2 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy2.Open()
        Dim conexionmy3 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy3.Open()
        Dim cmdCab As New MySqlCommand
        Dim cmdLin As New MySqlCommand

        Dim rdrCab As MySqlDataReader
        Dim rdrLin As MySqlDataReader

        cmdCab = New MySqlCommand("SELECT * FROM presupuesto_cab ORDER BY num_presupuesto", conexionmy)
        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        If rdrCab.HasRows Then
            Do While rdrCab.Read()
                vNumPres = rdrCab("num_presupuesto")
                Dim vBrutoAcumulado As Decimal = 0
                Dim vDtoAcumulado As Decimal = 0
                Dim vIvaAcumulado As Decimal = 0
                Dim vImporteAcumulado As Decimal = 0
                Dim vTotalPresupuesto As Decimal = 0
                Dim vTotalrecargo As Decimal = 0

                Dim vBrutoAcumuladoST As String
                Dim vDtoAcumuladoST As String
                Dim vIvaAcumuladoST As String
                Dim vImporteAcumuladoST As String
                Dim vTotalPresupuestoST As String
                Dim vTotalrecargoST As String

                cmdLin = New MySqlCommand("SELECT * FROM presupuesto_linea WHERE num_presupuesto = '" + vNumPres + "' ORDER BY linea", conexionmy2)
                cmdLin.CommandType = CommandType.Text
                cmdLin.Connection = conexionmy2
                rdrLin = cmdLin.ExecuteReader
                If rdrLin.HasRows Then
                    Do While rdrLin.Read()
                        Dim vImporteLinea As Decimal = 0
                        Dim vDtoLinea As Decimal = 0
                        Dim vTotalLinea As Decimal = 0
                        Dim vMedidaLinea As Decimal = 0
                        Dim vM2Ml As Decimal = 0

                        'Calculo el importe
                        If rdrLin("ancho_largo") = 0 Then
                            vImporteLinea = rdrLin("cantidad") * rdrLin("precio")
                        Else
                            vMedidaLinea = rdrLin("cantidad") * rdrLin("ancho_largo")
                            vM2Ml = vMedidaLinea
                            vImporteLinea = vM2Ml * rdrLin("precio")
                        End If
                        'Calculo el descuento
                        vDtoLinea = (vImporteLinea * rdrLin("descuento")) / 100
                        'Calculo el total de la linea
                        vTotalLinea = (vImporteLinea - vDtoLinea).ToString("0.00")
                        'Actualizo los acumulados
                        vBrutoAcumulado = (vBrutoAcumulado + vImporteLinea).ToString("0.00")
                        vDtoAcumulado = (vDtoAcumulado + vDtoLinea).ToString("0.00")
                        vImporteAcumulado = (vImporteAcumulado + vTotalLinea).ToString("0.00")
                        vIvaAcumulado = ((vImporteAcumulado * 21) / 100).ToString("0.00")

                        vBrutoAcumuladoST = Replace(vBrutoAcumulado.ToString, ",", ".")
                        vDtoAcumuladoST = Replace(vDtoAcumulado.ToString, ",", ".")
                        vIvaAcumuladoST = Replace(vIvaAcumulado.ToString, ",", ".")
                        vImporteAcumuladoST = Replace(vImporteAcumulado.ToString, ",", ".")
                        vTotalrecargoST = Replace(vTotalrecargo.ToString, ",", ".")

                    Loop

                End If
                rdrLin.Close()
                vTotalPresupuesto = ((vBrutoAcumulado - vDtoAcumulado) + vIvaAcumulado).ToString("0.00")
                vTotalPresupuestoST = Replace(vTotalPresupuesto.ToString, ",", ".")
                Dim cmd As New MySqlCommand("UPDATE presupuesto_cab SET totalbruto = '" + vBrutoAcumuladoST + "', totaldto = '" + vDtoAcumuladoST + "', totaliva = '" + vIvaAcumuladoST + "', totalrecargo = '" + vTotalrecargoST + "', totalpresupuesto = '" + vTotalPresupuestoST + "' WHERE num_presupuesto = '" + vNumPres + "'", conexionmy3)
                cmd.ExecuteNonQuery()
            Loop

        End If
        rdrCab.Close()
        conexionmy.Close()
        conexionmy2.Close()
        conexionmy3.Close()
        MsgBox("La operación se ha realizado con éxito")
        Me.Close()

    End Sub

    Private Sub btRacalculoPed_Click(sender As Object, e As EventArgs) Handles btRacalculoPed.Click
        'Recalcular los totales para las cabeceras de pedidos

        Dim vNumPed As String
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim conexionmy2 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy2.Open()
        Dim conexionmy3 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy3.Open()
        Dim cmdCab As New MySqlCommand
        Dim cmdLin As New MySqlCommand

        Dim rdrCab As MySqlDataReader
        Dim rdrLin As MySqlDataReader

        cmdCab = New MySqlCommand("SELECT * FROM pedido_cab ORDER BY num_pedido", conexionmy)
        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader

        If rdrCab.HasRows Then
            Do While rdrCab.Read()
                vNumPed = rdrCab("num_pedido")
                Dim vBrutoAcumulado As Decimal = 0
                Dim vDtoAcumulado As Decimal = 0
                Dim vIvaAcumulado As Decimal = 0
                Dim vImporteAcumulado As Decimal = 0
                Dim vTotalPedido As Decimal = 0
                Dim vTotalrecargo As Decimal = 0

                Dim vBrutoAcumuladoST As String
                Dim vDtoAcumuladoST As String
                Dim vIvaAcumuladoST As String
                Dim vImporteAcumuladoST As String
                Dim vTotalPedidoST As String
                Dim vTotalrecargoST As String

                cmdLin = New MySqlCommand("SELECT * FROM pedido_linea WHERE num_pedido = '" + vNumPed + "' ORDER BY linea", conexionmy2)
                cmdLin.CommandType = CommandType.Text
                cmdLin.Connection = conexionmy2
                rdrLin = cmdLin.ExecuteReader

                If rdrLin.HasRows Then
                    Do While rdrLin.Read()
                        Dim vImporteLinea As Decimal = 0
                        Dim vDtoLinea As Decimal = 0
                        Dim vTotalLinea As Decimal = 0
                        Dim vMedidaLinea As Decimal = 0
                        Dim vM2Ml As Decimal = 0

                        'Calculo el importe
                        If rdrLin("ancho_largo") = 0 Then
                            vImporteLinea = rdrLin("cantidad") * rdrLin("precio")
                        Else
                            vMedidaLinea = rdrLin("cantidad") * rdrLin("ancho_largo")
                            vM2Ml = vMedidaLinea
                            vImporteLinea = vM2Ml * rdrLin("precio")
                        End If
                        'Calculo el descuento
                        vDtoLinea = (vImporteLinea * rdrLin("descuento")) / 100
                        'Calculo el total de la linea
                        vTotalLinea = (vImporteLinea - vDtoLinea)
                        'Actualizo los acumulados
                        vBrutoAcumulado = (vBrutoAcumulado + vImporteLinea).ToString("0.00")
                        vDtoAcumulado = (vDtoAcumulado + vDtoLinea).ToString("0.00")
                        vImporteAcumulado = (vImporteAcumulado + vTotalLinea).ToString("0.00")
                        vIvaAcumulado = ((vImporteAcumulado * 21) / 100).ToString("0.00")

                        vBrutoAcumuladoST = Replace(vBrutoAcumulado.ToString, ",", ".")
                        vDtoAcumuladoST = Replace(vDtoAcumulado.ToString, ",", ".")
                        vIvaAcumuladoST = Replace(vIvaAcumulado.ToString, ",", ".")
                        vImporteAcumuladoST = Replace(vImporteAcumulado.ToString, ",", ".")
                        vTotalrecargoST = Replace(vTotalrecargo.ToString, ",", ".")
                    Loop

                End If
                rdrLin.Close()
                vTotalPedido = ((vBrutoAcumulado - vDtoAcumulado) + vIvaAcumulado).ToString("0.00")
                vTotalPedidoST = Replace(vTotalPedido.ToString, ",", ".")
                Dim cmd As New MySqlCommand("UPDATE pedido_cab SET totalbruto = '" + vBrutoAcumuladoST + "', totaldto = '" + vDtoAcumuladoST + "', totaliva = '" + vIvaAcumuladoST + "', totalrecargo = '" + vTotalrecargoST + "', totalpedido = '" + vTotalPedidoST + "' WHERE num_pedido = '" + vNumPed + "'", conexionmy3)
                cmd.ExecuteNonQuery()
            Loop

        End If
        rdrCab.Close()
        conexionmy.Close()
        conexionmy2.Close()
        conexionmy3.Close()
        MsgBox("La operación se ha realizado con éxito")
        Me.Close()

    End Sub

    Private Sub btRecalcularAlba_Click(sender As Object, e As EventArgs) Handles btRecalcularAlba.Click
        'Recalcular los totales para las cabeceras de albaranes

        Dim vNumAlb As String
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim conexionmy2 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy2.Open()
        Dim conexionmy3 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy3.Open()
        Dim cmdCab As New MySqlCommand
        Dim cmdLin As New MySqlCommand

        Dim rdrCab As MySqlDataReader
        Dim rdrLin As MySqlDataReader

        cmdCab = New MySqlCommand("SELECT * FROM albaran_cab ORDER BY num_albaran", conexionmy)
        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        If rdrCab.HasRows Then
            Do While rdrCab.Read()
                vNumAlb = rdrCab("num_albaran")
                Dim vBrutoAcumulado As Decimal = 0
                Dim vDtoAcumulado As Decimal = 0
                Dim vIvaAcumulado As Decimal = 0
                Dim vImporteAcumulado As Decimal = 0
                Dim vTotalAlbaran As Decimal = 0
                Dim vTotalrecargo As Decimal = 0

                Dim vBrutoAcumuladoST As String
                Dim vDtoAcumuladoST As String
                Dim vIvaAcumuladoST As String
                Dim vImporteAcumuladoST As String
                Dim vTotalAlbaranST As String
                Dim vTotalrecargoST As String

                cmdLin = New MySqlCommand("SELECT * FROM albaran_linea WHERE num_albaran = '" + vNumAlb + "' ORDER BY linea", conexionmy2)
                cmdLin.CommandType = CommandType.Text
                cmdLin.Connection = conexionmy2
                rdrLin = cmdLin.ExecuteReader
                If rdrLin.HasRows Then
                    Do While rdrLin.Read()
                        Dim vImporteLinea As Decimal = 0
                        Dim vDtoLinea As Decimal = 0
                        Dim vTotalLinea As Decimal = 0
                        Dim vMedidaLinea As Decimal = 0
                        Dim vM2Ml As Decimal = 0

                        'Calculo el importe
                        If rdrLin("ancho_largo") = 0 Then
                            vImporteLinea = rdrLin("cantidad") * rdrLin("precio")
                        Else
                            vMedidaLinea = rdrLin("cantidad") * rdrLin("ancho_largo")
                            vM2Ml = vMedidaLinea
                            vImporteLinea = vM2Ml * rdrLin("precio")
                        End If
                        'Calculo el descuento
                        vDtoLinea = (vImporteLinea * rdrLin("descuento")) / 100
                        'Calculo el total de la linea
                        vTotalLinea = (vImporteLinea - vDtoLinea)
                        'Actualizo los acumulados
                        vBrutoAcumulado = (vBrutoAcumulado + vImporteLinea).ToString("0.00")
                        vDtoAcumulado = (vDtoAcumulado + vDtoLinea).ToString("0.00")
                        vImporteAcumulado = (vImporteAcumulado + vTotalLinea).ToString("0.00")
                        vIvaAcumulado = ((vImporteAcumulado * 21) / 100).ToString("0.00")

                        vBrutoAcumuladoST = Replace(vBrutoAcumulado.ToString, ",", ".")
                        vDtoAcumuladoST = Replace(vDtoAcumulado.ToString, ",", ".")
                        vIvaAcumuladoST = Replace(vIvaAcumulado.ToString, ",", ".")
                        vImporteAcumuladoST = Replace(vImporteAcumulado.ToString, ",", ".")
                        vTotalrecargoST = Replace(vTotalrecargo.ToString, ",", ".")

                    Loop

                End If
                rdrLin.Close()
                vTotalAlbaran = ((vBrutoAcumulado - vDtoAcumulado) + vIvaAcumulado).ToString("0.00")
                vTotalAlbaranST = Replace(vTotalAlbaran.ToString, ",", ".")
                Dim cmd As New MySqlCommand("UPDATE albaran_cab SET totalbruto = '" + vBrutoAcumuladoST + "', totaldto = '" + vDtoAcumuladoST + "', totaliva = '" + vIvaAcumuladoST + "', totalrecargo = '" + vTotalrecargoST + "', totalalbaran = '" + vTotalAlbaranST + "' WHERE num_albaran = '" + vNumAlb + "'", conexionmy3)
                cmd.ExecuteNonQuery()
            Loop

        End If
        rdrCab.Close()
        conexionmy.Close()
        conexionmy2.Close()
        conexionmy3.Close()
        MsgBox("La operación se ha realizado con éxito")
        Me.Close()

    End Sub

    Private Sub btRecalcularFactu_Click(sender As Object, e As EventArgs) Handles btRecalcularFactu.Click
        'Recalcular los totales para las cabeceras de facturas

        Dim vNumFac As String
        Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy.Open()
        Dim conexionmy2 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy2.Open()
        Dim conexionmy3 As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
        conexionmy3.Open()
        Dim cmdCab As New MySqlCommand
        Dim cmdLin As New MySqlCommand

        Dim rdrCab As MySqlDataReader
        Dim rdrLin As MySqlDataReader

        cmdCab = New MySqlCommand("SELECT * FROM factura_cab ORDER BY num_factura", conexionmy)
        cmdCab.CommandType = CommandType.Text
        cmdCab.Connection = conexionmy
        rdrCab = cmdCab.ExecuteReader
        If rdrCab.HasRows Then
            Do While rdrCab.Read()
                vNumFac = rdrCab("num_factura")
                Dim vBrutoAcumulado As Decimal = 0
                Dim vDtoAcumulado As Decimal = 0
                Dim vIvaAcumulado As Decimal = 0
                Dim vImporteAcumulado As Decimal = 0
                Dim vTotalFactura As Decimal = 0
                Dim vTotalrecargo As Decimal = 0

                Dim vBrutoAcumuladoST As String
                Dim vDtoAcumuladoST As String
                Dim vIvaAcumuladoST As String
                Dim vImporteAcumuladoST As String
                Dim vTotalFacturaST As String
                Dim vTotalrecargoST As String


                cmdLin = New MySqlCommand("SELECT * FROM factura_linea WHERE num_factura = '" + vNumFac + "' ORDER BY linea", conexionmy2)
                cmdLin.CommandType = CommandType.Text
                cmdLin.Connection = conexionmy2
                rdrLin = cmdLin.ExecuteReader
                If rdrLin.HasRows Then
                    Do While rdrLin.Read()
                        Dim vImporteLinea As Decimal
                        Dim vDtoLinea As Decimal
                        Dim vTotalLinea As Decimal
                        Dim vMedidaLinea As Decimal
                        Dim vM2Ml As Decimal
                        If rdrLin("articuloID") = 99999 Then
                            'Resultado de la facturacion de albaranes
                        Else
                            'Calculo el importe
                            If rdrLin("ancho_largo") = 0 Then
                                vImporteLinea = rdrLin("cantidad") * rdrLin("precio")
                            Else
                                vMedidaLinea = rdrLin("cantidad") * rdrLin("ancho_largo")
                                vM2Ml = vMedidaLinea
                                vImporteLinea = vM2Ml * rdrLin("precio")
                            End If
                            'Calculo el descuento
                            vDtoLinea = (vImporteLinea * rdrLin("descuento")) / 100
                            'Calculo el total de la linea
                            vTotalLinea = (vImporteLinea - vDtoLinea)
                            'Actualizo los acumulados
                            vBrutoAcumulado = (vBrutoAcumulado + vImporteLinea).ToString("0.00")
                            vDtoAcumulado = (vDtoAcumulado + vDtoLinea).ToString("0.00")
                            vImporteAcumulado = (vImporteAcumulado + vTotalLinea).ToString("0.00")
                            vIvaAcumulado = ((vImporteAcumulado * 21) / 100).ToString("0.00")

                            vBrutoAcumuladoST = Replace(vBrutoAcumulado.ToString, ",", ".")
                            vDtoAcumuladoST = Replace(vDtoAcumulado.ToString, ",", ".")
                            vIvaAcumuladoST = Replace(vIvaAcumulado.ToString, ",", ".")
                            vImporteAcumuladoST = Replace(vImporteAcumulado.ToString, ",", ".")
                            vTotalrecargoST = Replace(vTotalrecargo.ToString, ",", ".")
                        End If


                    Loop

                End If
                rdrLin.Close()
                vTotalFactura = ((vBrutoAcumulado - vDtoAcumulado) + vIvaAcumulado).ToString("0.00")
                vTotalFacturaST = Replace(vTotalFactura.ToString, ",", ".")
                Dim cmd As New MySqlCommand("UPDATE factura_cab SET totalbruto = '" + vBrutoAcumuladoST + "', totaldto = '" + vDtoAcumuladoST + "', totaliva = '" + vIvaAcumuladoST + "', totalrecargo = '" + vTotalrecargoST + "', totalfactura = '" + vTotalFacturaST + "' WHERE num_factura = '" + vNumFac + "'", conexionmy3)
                cmd.ExecuteNonQuery()
            Loop

        End If
        rdrCab.Close()
        conexionmy.Close()
        conexionmy2.Close()
        conexionmy3.Close()
        MsgBox("La operación se ha realizado con éxito")
        Me.Close()

    End Sub
End Class