Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Xml
Public Class frCrearLotes
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        LimpiarFormulario()
        dgLotes.Rows.Clear()
        Me.Close()

    End Sub

    Private Sub frCrearLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Inicialización formulario

    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        dgLotes.Rows.Add()
        dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(0).Value = txReferencia.Text
        dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(1).Value = txDescripcion.Text
        dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(2).Value = txLote.Text
        dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(3).Value = txStock.Text
        dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(4).Value = txFecha.Text
        dgLotes.Rows(dgLotes.Rows.Count - 1).Cells(5).Value = txUbicacion.Text
        LimpiarFormulario()
        txLote.Focus()

    End Sub
    Public Sub LimpiarFormulario()
        txLote.Text = ""
        txStock.Text = 0
        txFecha.Text = Format(Today, "ddMMyyyy")
        txUbicacion.Text = ""

    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        dgLotes.Rows.RemoveAt(dgLotes.CurrentRow.Index)
        LimpiarFormulario()
        txLote.Focus()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If dgLotes.RowCount = 0 Then
            MsgBox("No se han registrado lotes para esta referencia")
            txLote.Focus()

        Else
            Dim conexionmy As New MySqlConnection("server=" + vServidor + "; User ID=" + vUsuario + "; database=" + vBasedatos)
            conexionmy.Open()
            Dim cmd As New MySqlCommand
            Dim stock As String
            Dim guardo_stock As String
            Dim row As New DataGridViewRow
            Dim fecha As Date

            For Each row In dgLotes.Rows
                fecha = row.Cells(4).Value.ToString
                stock = row.Cells(3).Value.ToString
                guardo_stock = Replace(stock, ",", ".")

                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "INSERT INTO lotes (referencia, descripcion, lote, stock, stock_inicial, stock_disp, fechaentrada, ubicacion) VALUES ('" + row.Cells(0).Value.ToString + "' , '" + row.Cells(1).Value.ToString + "' , '" + row.Cells(2).Value.ToString + "' , '" + guardo_stock + "' , '" + guardo_stock + "' , '" + guardo_stock + "' , '" + fecha.ToString("yyyy-MM-dd") + "', '" + row.Cells(5).Value.ToString + "')"

                cmd.Connection = conexionmy

                cmd.ExecuteNonQuery()
            Next

            conexionmy.Close()
            LimpiarFormulario()
            dgLotes.Rows.Clear()
            Me.Close()

        End If


    End Sub

    Private Sub txStock_Validated(sender As Object, e As EventArgs) Handles txStock.Validated
        txStock.Text = Decimal.Parse(txStock.Text, 2).ToString("f2")
    End Sub
End Class