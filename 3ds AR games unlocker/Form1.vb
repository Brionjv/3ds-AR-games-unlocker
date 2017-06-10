Public Class Form1
    Dim filepath As String
    Dim fdialog As New Form2
    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Dim open As New OpenFileDialog
        open.Title = "Open menu file"
        fdialog.Label1.Text = "Open menu file" & vbNewLine & "Backup your save before use" & vbNewLine & "3ds AR games unlocker"
        fdialog.ShowDialog()
        open.ShowDialog()
        filepath = open.FileName
        Readfile()
        Unlockmenu()
    End Sub
    Private Sub Readfile()
        Try
        Catch ex As Exception
            fdialog.Label1.Text = "menu file not load" & vbNewLine & "Be sure to open the correct file"
            fdialog.ShowDialog()
        End Try
    End Sub
    Private Sub Unlockmenu()
        Try
            Dim Writer As New PackageIO.Writer(filepath, PackageIO.Endian.Little)
            Writer.Position = &H0
            Writer.WriteUInt32(33488899)
            Writer.Position = &H4
            Writer.WriteUInt32(392232963)
            fdialog.Label1.Text = "All AR games unlocked" & vbNewLine & "(3ds AR games unlocker can be closed)"
            fdialog.ShowDialog()
        Catch ex As Exception
            fdialog.Label1.Text = "Failed to unlock all AR games"
            fdialog.ShowDialog()
        End Try
    End Sub
End Class
