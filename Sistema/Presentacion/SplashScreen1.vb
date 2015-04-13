Public NotInheritable Class SplashScreen1


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            frmprofesor.Show()
            Me.Hide()
            ProgressBar1.Value = 0
        End If
    End Sub
End Class
