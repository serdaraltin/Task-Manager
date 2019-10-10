Imports System.Diagnostics
Public Class Form1
  
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()
        For Each ps As Process In Process.GetProcesses(My.Computer.Name)
            Dim items As ListViewItem = New ListViewItem(ps.Id.ToString())
            items.SubItems.Add(ps.ProcessName)
            items.SubItems.Add(FormatNumber(Math.Round(ps.PagedMemorySize64 / 1024), 0).ToString())
            Try
                items.SubItems.Add(ps.MainModule.FileName)
            Catch
                items.SubItems.Add("n/a")
            End Try
            items.SubItems.Add(ps.Threads.Count)

            ListView1.Items.Add(items)
        Next
    End Sub

End Class
