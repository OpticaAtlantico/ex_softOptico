Imports CapaDatos
Imports CapaEntidad

Public Class LoginModel

    Private repositorio As IRepositorio_Login

    ' Constructor por defecto
    Public Sub New()
        repositorio = New Repositorio_Login()
    End Sub

    Public Function FindByUserPass(user As String, pass As String) As IEnumerable(Of TLogin)
        Return GetUserPass(user, pass).Where(Function(x) x.Usuario = user AndAlso x.Clave = pass)
    End Function

    Public Function FindById(id As Integer) As IEnumerable(Of TLogin)
        Return GetLogin().FindAll(Function(emp) Convert.ToString(emp.LoginID).Contains(id))
    End Function

    Public Function GetLogin() As List(Of TLogin)
        Dim loginListViewModel = New List(Of TLogin)
        Dim listaLoginDataModel = repositorio.GetAll()
        Try
            For Each item As TLogin In listaLoginDataModel
                Dim loginModel = New TLogin With {
                    .LoginID = item.LoginID,
                    .EmpleadoID = item.EmpleadoID,
                    .UbicacionID = item.UbicacionID,
                    .RolID = item.RolID,
                    .Usuario = item.Usuario,
                    .Clave = item.Clave,
                    .Estado = item.Estado,
                    .FechaRegistro = item.FechaRegistro
                }
                loginListViewModel.Add(loginModel)
            Next
        Catch ex As Exception
            Throw New Exception("Error al obtener los registros de login: " & ex.Message)
        End Try
        Return loginListViewModel
    End Function

    Public Function GetUserPass(usuario As String, clave As String) As List(Of TLogin)
        Dim loginListViewModel = New List(Of TLogin)
        Dim listaLoginDataModel = repositorio.GetAllUserPass(usuario, clave)
        Try
            For Each item As TLogin In listaLoginDataModel
                Dim loginModel = New TLogin With {
                    .LoginID = item.LoginID,
                    .EmpleadoID = item.EmpleadoID,
                    .UbicacionID = item.UbicacionID,
                    .RolID = item.RolID,
                    .Usuario = item.Usuario,
                    .Clave = item.Clave,
                    .Estado = item.Estado,
                    .FechaRegistro = item.FechaRegistro
                }
                loginListViewModel.Add(loginModel)
            Next
        Catch ex As Exception
            Throw New Exception("Error al obtener el usuario y contraseña: " & ex.Message)
        End Try
        Return loginListViewModel
    End Function

End Class
