Public Class frmprofesor
    Private dt As New DataTable


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarprof()

    End Sub

    Public Sub limpiar()
        btnguardar.Visible = True
        btneditar.Visible = False
        txtnombreprofesor.Text = ""
        txtapellidoprofesor.Text = ""
        txtdomicilioprofesor.Text = ""
        txttelefono.Text = ""
        txtiprofesor.Text = ""

    End Sub



    Private Sub mostrarprof()
        Try
            Dim func As New profesores
            dt = func.mostrarprof
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

    Private Sub txtnombrealumno_TextChanged(sender As Object, e As EventArgs) Handles txtnombreprofesor.TextChanged, txtnombreprofesor.TextChanged

    End Sub

    Private Sub txtnombreprofesor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnombreprofesor.Validating, txtnombreprofesor.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el nombre del profesor")
        End If
    End Sub

    Private Sub txtapellidoprofesor_TextChanged(sender As Object, e As EventArgs) Handles txtapellidoprofesor.TextChanged, txtapellidoprofesor.TextChanged

    End Sub

    Private Sub txtapellidoprofesor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtapellidoprofesor.Validating, txtapellidoprofesor.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el apellido del profesor")
        End If
    End Sub

    Private Sub txtdomicilioprofesor_TextChanged(sender As Object, e As EventArgs) Handles txtdomicilioprofesor.TextChanged, txtdomicilioprofesor.TextChanged

    End Sub

    Private Sub txtdomicilioprofesor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtdomicilioprofesor.Validating, txtdomicilioprofesor.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el domicilio del profesor")
        End If
    End Sub


    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged

    End Sub

    Private Sub TextBox4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txttelefono.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erroricono.SetError(sender, "")
        Else
            Me.erroricono.SetError(sender, "Ingrese el telefono del profesor")
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        limpiar()
        mostrarprof()

    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If Me.ValidateChildren = True And txtnombreprofesor.Text <> "" And txtapellidoprofesor.Text <> "" And txtdomicilioprofesor.Text <> "" And txttelefono.Text <> "" Then
            Try
                Dim dts As New vprofesores
                Dim func As New profesores

                dts.gnombre = txtnombreprofesor
                dts.gapellido = txtapellidoprofesor.Text
                dts.gdomicilio = txtdomicilioprofesor.Text
                dts.gtelefono = txttelefono.Text

                If func.insertar(dts) Then

                    MessageBox.Show("Profesor registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    mostrarprof()
                    limpiar()
                Else
                    MessageBox.Show("Profesor NO FUE registrado, intente nuevamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Falta ingresar algunos datos", "Guardando Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cbocampo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocampo.SelectedIndexChanged

    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar los datos seleccionados", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In datalistado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("idprofesor").Value)

                        Dim vdb As New vprofesores
                        Dim func As New profesores
                        vdb.gidprofesor = onekey


                        If func.eliminar(vdb) Then
                        Else
                            MessageBox.Show("Profesor no fue eliminado", "Eliminando Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                Next
                Call mostrarprof()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Cancelando eliminacion de registros", "Eliminando Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call mostrarprof()
        End If
        limpiar()
        cbeliminar.CheckState = CheckState.Unchecked
    End Sub

    Private Sub datalistado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datalistado.CellClick
        txtiprofesor.Text = datalistado.SelectedCells.Item(1).Value
        txtnombreprofesor.Text = datalistado.SelectedCells.Item(2).Value
        txtapellidoprofesor.Text = datalistado.SelectedCells.Item(3).Value
        txtdomicilioprofesor.Text = datalistado.SelectedCells.Item(4).Value
        txttelefono.Text = datalistado.SelectedCells.Item(5).Value
        btneditar.Visible = True
        btnguardar.Visible = False
    End Sub

   Private Sub datalistado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datalistado.CellContentClick
        If e.ColumnIndex = Me.datalistado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.datalistado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea editar los datos del profesor?", "Modificando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then

            If Me.ValidateChildren = True And txtnombreprofesor.Text <> "" And txtapellidoprofesor.Text <> "" And txtdomicilioprofesor.Text <> "" And txttelefono.Text <> "" And txtiprofesor.Text <> "" Then
                Try
                    Dim dts As New vprofesores
                    Dim func As New profesores
                    dts.gidprofesor = txtiprofesor.Text

                    dts.gnombre = txtnombreprofesor.Text
                    dts.gapellido = txtapellidoprofesor.Text
                    dts.gdomicilio = txtdomicilioprofesor.Text
                    dts.gtelefono = txttelefono.Text

                    If func.editar(dts) Then

                        MessageBox.Show("Profesor modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mostrarprof()
                        limpiar()
                    Else
                        MessageBox.Show("Profesor NO FUE modificado, intente nuevamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("Falta ingresar algunos datos", "Modificando Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub cbeliminar_CheckedChanged(sender As Object, e As EventArgs) Handles cbeliminar.CheckedChanged
        If cbeliminar.CheckState = CheckState.Checked Then
            datalistado.Columns.Item("Eliminar").Visible = True
        Else
            datalistado.Columns.Item("Eliminar").Visible = False

        End If

    End Sub
End Class



