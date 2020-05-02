Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Error, debes ingresar al menos un nombre o apellido")
        Else

            Dim conexion As MySqlConnection
            conexion = New MySqlConnection

            Dim cmd As New MySqlCommand

            conexion.ConnectionString = "server=localhost; database=encuesta;Uid=root;Pwd=;"

            Try
                conexion.Open()
                cmd.Connection = conexion

                cmd.CommandText = "INSERT INTO encuesta_series(nombre,apellido,seriefav) VALUES(@nombre,@apellido,@seriefav)"
                cmd.Prepare()

                cmd.Parameters.AddWithValue("@nombre", TextBox1.Text)
                cmd.Parameters.AddWithValue("@apellido", TextBox2.Text)
                cmd.Parameters.AddWithValue("@seriefav", ComboBox1.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Alumno ingresado con exito")
                TextBox1.Clear()
                TextBox2.Clear()
                conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
End Class
