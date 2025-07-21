Imports System.Windows.Controls
Imports Microsoft.Data.SqlClient

Public Module GridSQLLoader

    ''' <summary>
    ''' Carga un DataTable desde una consulta SQL y lo pasa al grid orbital
    ''' </summary>
    Public Sub CargarDesdeSQL(grid As DataGridViewUI, conexionSQL As String, consultaSQL As String)
        Try
            Using cnx As New SqlConnection(conexionSQL)
                cnx.Open()
                Using cmd As New SqlCommand(consultaSQL, cnx)
                    Dim dt As New DataTable()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    grid.CargarDatos(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error orbital al cargar datos desde SQL:" & vbCrLf & ex.Message, "SQL Loader", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Como usarlo
    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim conexionOrbital = "Server=.;Database=EmpresaOrbital;Integrated Security=true;"
    '    Dim consultaOrbital = "SELECT Id, NombreCompleto AS Nombre, CorreoElectronico AS Correo FROM Clientes"

    '    GridSQLLoader.CargarDesdeSQL(gridUI, conexionOrbital, consultaOrbital)
    'End Sub

End Module
