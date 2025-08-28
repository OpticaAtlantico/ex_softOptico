Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports CapaDatos
Imports Microsoft.Data.SqlClient

Public Class LlenarComboBox
    Inherits Repositorio
    Public SQL_PROVEEDOR As String = "SELECT * FROM VCProveedor"
    Public SQL_TIPOPAGO As String = "SELECT * FROM VCTipoPago"
    Public SQL_SUCURSALES As String = "SELECT * FROM VCUbicaciones"
    Public SQL_CARGOEMPLEADOS As String = "SELECT * FROM VCCargoEmpleado"

    Public SQL_CATEGORIAPRODUCTOS As String = "SELECT * FROM VCategoria"
    Public SQL_SUBCATEGORIAPRODUCTOS As String = "SELECT * FROM VSubCategoria WHERE CategoriaID = @IDCategoria"

    Public Class ComboItem
        Public Property Texto As String
        Public Property Valor As Object
        Public Sub New(texto As String, valor As Object)
            Me.Texto = texto
            Me.Valor = valor
        End Sub
        Public Overrides Function ToString() As String
            Return Texto
        End Function
    End Class

    Public Sub Cargar(combo As ComboBoxLabelUI, sql As String, textField As String, valueField As String)
        If combo Is Nothing Then
            Throw New ArgumentNullException(NameOf(combo), "El control ComboBoxUI no está inicializado")
        End If

        ' Si tu Items no está instanciado, inicialízalo aquí:
        ' If combo.Items Is Nothing Then combo.Items = New List(Of Object)

        combo.OrbitalCombo.Items.Clear()

        Dim items As List(Of ComboItem) = ObtenerItems(sql, textField, valueField)
        For Each item In items
            combo.OrbitalCombo.Items.Add(item)
        Next
    End Sub

    Private Function ObtenerItems(sql As String, textField As String, valueField As String) As List(Of ComboItem)
        Dim lista As New List(Of ComboItem)()
        Try
            Using con As SqlConnection = ObtenerConexion()
                con.Open()
                Using cmd As New SqlCommand(sql, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            lista.Add(New ComboItem(
                                reader(textField).ToString(),
                                reader(valueField)
                            ))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener datos: " & ex.Message,
                            "WilmerUI", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return lista
    End Function
End Class

