Public Class frmAlumnos
    Private dt As New DataTable


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()

    End Sub

    Public Sub limpiar()
        btnguardar.Visible = True
        btneditar.Visible = False
        txtnombrealumno.Text = ""
        txtapellidoalumno.Text = ""
        txtdni.Text = ""
        txtdomicilioalumno.Text = ""
        txttelefono.Text = ""
        txtidalumno.Text = ""

    End Sub



    Private Sub mostrar()
        Try
            Dim func As New falumnos
            dt = func.mostrar
            datalistado.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                datalistado.DataSource = dt
                txtbuscar.Enabled = True
                datalistado.ColumnHeadersVisible = True
                inexistente.Visible = False
            Else
                datalistado.DataSource = Nothing
                txtbuscar.Enabled = False
                datalistado.ColumnHeadersVisible = False
                inexistente.Visible = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        btnnuevo.Visible = True
        btneditar.Visible = False
        buscar()


    End Sub

    Private Sub buscar()
        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = cbocampo.Text & " like '" & txtbuscar.Text & "%'"

            If dv.Count <> 0 Then
                inexistente.Visible = False
                datalistado.DataSource = dv
                ocultar_columnas()


            Else
                inexistente.Visible = True
                datalistado.DataSource = Nothing

            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ocultar_columnas()
        datalistado.Columns(1).Visible = False


    End Sub

    Private Sub txtnombrealumno_TextChanged(sender As Object, e As EventArgs) Handles txtnombrealumno.TextChanged
       
    End Sub

    Private Sub txtnombrealumno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnombrealumno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el nombre del alumno")
        End If
    End Sub

    Private Sub txtapellidoalumno_TextChanged(sender As Object, e As EventArgs) Handles txtapellidoalumno.TextChanged

    End Sub

    Private Sub txtapellidoalumno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtapellidoalumno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el apellido del alumno")
        End If
    End Sub

    Private Sub txtdomicilioalumno_TextChanged(sender As Object, e As EventArgs) Handles txtdomicilioalumno.TextChanged

    End Sub

    Private Sub txtdomicilioalumno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtdomicilioalumno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el domicilio del alumno")
        End If
    End Sub

    Private Sub txtdni_TextChanged(sender As Object, e As EventArgs) Handles txtdni.TextChanged

    End Sub

    Private Sub txtdni_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtdni.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el DNI del alumno")
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged

    End Sub

    Private Sub TextBox4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txttelefono.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el telefono del alumno")
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        limpiar()
        mostrar()

    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If Me.ValidateChildren = True And txtnombrealumno.Text <> "" And txtapellidoalumno.Text <> "" And txtdomicilioalumno.Text <> "" And txtdni.Text <> "" And txttelefono.Text <> "" Then
            Try
                Dim dts As New valumno
                Dim func As New falumnos

                dts.gnombre = txtnombrealumno.Text
                dts.gapellido = txtapellidoalumno.Text
                dts.gdomicilio = txtdomicilioalumno.Text
                dts.gdni = txtdni.Text
                dts.gtelefono = txttelefono.Text

                If func.insertar(dts) Then

                    MessageBox.Show("Alumno registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    mostrar()
                    limpiar()
                Else
                    MessageBox.Show("Alumno NO FUE registrado, intente nuevamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Falta ingresar algunos datos", "Guardando Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class