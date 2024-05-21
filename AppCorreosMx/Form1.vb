Imports System.Data.SqlClient


Public Class Form1
    Private Sub btnConectar_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Cadena de conexión a la base de datos
        Dim connectionString As String = "Data Source=LESLY;Initial Catalog=CorreosMx;Integrated Security=True"

        ' Crear una nueva conexión
        Dim connection As New SqlConnection(connectionString)

        Try
            ' Abrir la conexión
            connection.Open()
            MessageBox.Show("Conexión exitosa...")

            ' Consulta SQL para obtener datos
            Dim query As String = "SELECT * FROM cpdescarga"

            ' Crear un adaptador de datos
            Dim adapter As New SqlDataAdapter(query, connection)

            ' Crear un DataSet para contener los datos
            Dim dataSet As New DataSet()

            ' Llenar el DataSet con los datos del adaptador
            adapter.Fill(dataSet, "TablaDatos")

            ' Mostrar los datos en el DataGridView
            DataGridView1.DataSource = dataSet.Tables("TablaDatos")

        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos: " & ex.Message)
        Finally
            ' Cerrar la conexión cuando hayas terminado
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
End Class

