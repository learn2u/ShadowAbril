Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim NewMDIChild As New Form2()
        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me
        'Form2.IsMdiContainer = False
        'Display the new form.
        NewMDIChild.Show()
        Button1.Visible = False
    End Sub
End Class
