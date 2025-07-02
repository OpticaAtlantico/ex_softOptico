Public Interface IRepositorio_Generico(Of Entity As Class)
    Function GetAll() As IEnumerable(Of Entity) 'Para obtener todos los Registros
    Function Add(entity As Entity) As Integer 'Para almacenar nuevo registro
    Function Edit(entity As Entity) As Integer 'Para actualizar datos del registro
    Function Remove(id As Integer) As Integer 'Para eliminar datos

    Function GetAllUserPass(user As String, pass As String) As IEnumerable(Of Entity)
End Interface
