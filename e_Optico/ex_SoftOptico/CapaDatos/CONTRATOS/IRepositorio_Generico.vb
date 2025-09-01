Public Interface IRepositorio_Generico(Of Entity As Class)
    Function GetAll() As IEnumerable(Of Entity) 'Para obtener todos los regitros de una entidad
    Function Add(entity As Entity) As Integer  'Para insertar un nuevo registro
    Function Edit(entity As Entity) As Integer 'Para actualizar un registro existente 
    Function Remove(id As Integer) As Integer 'Para eliminar un registro por su ID    
End Interface
