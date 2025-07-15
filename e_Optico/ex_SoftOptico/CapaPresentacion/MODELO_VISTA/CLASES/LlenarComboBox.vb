Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports CapaDatos
Imports Microsoft.Data.SqlClient

Public Class LlenarComboBox
    Inherits Repositorio

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

    Public Sub Cargar(combo As cl_ComboBoxLabelUI, sql As String, textField As String, valueField As String)
        If combo Is Nothing Then
            Throw New ArgumentNullException(NameOf(combo), "El control ComboBoxUI no está inicializado")
        End If

        ' Si tu Items no está instanciado, inicialízalo aquí:
        ' If combo.Items Is Nothing Then combo.Items = New List(Of Object)

        combo.OrbitalCombo.Items.Clear()

        Dim items As List(Of ComboItem) = ObtenerItems(sql, textField, valueField)
        For Each item In items
            combo.OrbitalCombo.Items.Add(item.ToString())
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



'PASO 1 COMO IMPLEMENTARLO EN EL FORMULARIO

'Private Sub FormCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'    Dim manager As New ComboBoxUIManager()
'    Dim sql As String = "SELECT IdCategoria, Nombre FROM Categorias"
'    manager.Cargar(ComboBoxUI1, sql, "Nombre", "IdCategoria")
'End Sub



'PASO 2: COMO OBTENER EL ITEM O ID SELECCIONADO

'Private Sub ComboBoxUI1_SelectedIndexChanged(sender As Object, e As EventArgs) _
'Handles ComboBoxUI1.SelectedIndexChanged

'    Dim item As ComboBoxUIManager.ComboItem =
'    TryCast(ComboBoxUI1.SelectedItem, ComboBoxUIManager.ComboItem)

'    If item IsNot Nothing Then
'        Dim idSeleccionado = item.Valor
'        MessageBox.Show("ID seleccionado: " & idSeleccionado.ToString())
'    End If
'End Sub
