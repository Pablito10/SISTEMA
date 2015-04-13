Public Class vprofesores
    Dim idprofesor As Integer
    Dim nombre, apellido, domicilio, telefono As String


    'seter y geteer
    Public Property gidprofesor
        Get
            Return idprofesor
        End Get
        Set(value)
            idprofesor = value

        End Set
    End Property

    Public Property gnombre
        Get
            Return nombre
        End Get
        Set(value)
            nombre = value
        End Set
    End Property

    Public Property gapellido
        Get
            Return apellido
        End Get
        Set(value)
            apellido = value
        End Set
    End Property

    Public Property gdomicilio
        Get
            Return domicilio
        End Get
        Set(value)
            domicilio = value
        End Set
    End Property

    Public Property gtelefono
        Get
            Return telefono
        End Get
        Set(value)
            telefono = value
        End Set
    End Property

    'constructor
    Public Sub New()

    End Sub

    Public Sub New(ByVal idprofesor As Integer, ByVal nombre As String, ByVal apellido As String, ByVal domicilio As String, ByVal telefono As String)
        gidprofesor = idprofesor
        gnombre = nombre
        gapellido = apellido
        gdomicilio = domicilio
        gtelefono = telefono
    End Sub

End Class
