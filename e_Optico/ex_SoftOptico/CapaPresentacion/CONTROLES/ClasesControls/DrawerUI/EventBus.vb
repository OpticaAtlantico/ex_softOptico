' EventBus.vb
Imports System
Imports System.Collections.Generic

Public Module EventBus
    Private listeners As New Dictionary(Of String, List(Of Action(Of Object)))()

    Public Sub [On](eventName As String, callback As Action(Of Object))
        If Not listeners.ContainsKey(eventName) Then
            listeners(eventName) = New List(Of Action(Of Object))()
        End If
        listeners(eventName).Add(callback)
    End Sub

    Public Sub Emit(eventName As String, payload As Object)
        If listeners.ContainsKey(eventName) Then
            For Each cb As Action(Of Object) In listeners(eventName)
                cb.Invoke(payload)
            Next
        End If
    End Sub
End Module
