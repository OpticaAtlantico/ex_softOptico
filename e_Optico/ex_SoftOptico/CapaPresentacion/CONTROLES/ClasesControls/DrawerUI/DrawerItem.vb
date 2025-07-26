Imports FontAwesome.Sharp

Public Enum DrawerGroup
    Ventas
    Compras
    Inventario
End Enum

Public Structure DrawerItem
    Public Property Text As String
    Public Property Icon As IconChar
    'Public Property Handler As EventHandler
    Public Property CallBack As Action
End Structure
