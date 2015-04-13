Imports System.Data.SqlClient

Public Class profesores
    Inherits conexion
    Dim cmd As New SqlCommand

    Public Function mostrarprof() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrar_profesor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()

        End Try


    End Function

    Public Function insertar(ByRef dts As vprofesores) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insertar_profesor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@nombre", dts.gnombre)
            cmd.Parameters.AddWithValue("@apelllido", dts.gapellido)
            cmd.Parameters.AddWithValue("@domicilio", dts.gdomicilio)
            cmd.Parameters.AddWithValue("@telefono", dts.gtelefono)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()

        End Try
    End Function

    Public Function editar(ByRef dts As vprofesores) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("editar_profesor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@idprofesor", dts.gidprofesor)
            cmd.Parameters.AddWithValue("@nombre", dts.gnombre)
            cmd.Parameters.AddWithValue("@apellido", dts.gapellido)
            cmd.Parameters.AddWithValue("@domicilio", dts.gdomicilio)
            cmd.Parameters.AddWithValue("@telefono", dts.gtelefono)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()

        End Try
    End Function

    Public Function eliminar(ByVal dts As vprofesores) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("eliminar_profesor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn

            cmd.Parameters.Add("@idprofesor", SqlDbType.NVarChar, 50).Value = dts.gidprofesor
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function




End Class
