Public Class valumno
    Dim idalumno, curso1, curso2, curso3 As Integer
    Dim nombre, apellido, domicilio, telefono, dni As String


    'seteer y geteer

    Public Property gidalumno
        Get
            Return idalumno
        End Get
        Set(ByVal value)
            idalumno = value
        End Set
    End Property

    Public Property gnombre
        Get
            Return nombre
        End Get
        Set(ByVal value)
            nombre = value
        End Set
    End Property

    Public Property gapellido
        Get
            Return apellido
        End Get
        Set(ByVal value)
            apellido = value
        End Set
    End Property

    Public Property gdomicilio
        Get
            Return domicilio
        End Get
        Set(ByVal value)
            domicilio = value
        End Set
    End Property

    Public Property gtelefono
        Get
            Return telefono
        End Get
        Set(ByVal value)
            telefono = value
        End Set
    End Property

    Public Property gdni
        Get
            Return dni
        End Get
        Set(ByVal value)
            dni = value
        End Set
    End Property

    'constructores

    Public Sub New()

    End Sub

    Public Sub New(ByVal idalumno As Integer, ByVal nombre As String, ByRef apellido As String, ByVal domicilio As String, ByVal telefono As String, ByVal dni As String)
        gidalumno = idalumno
        gnombre = nombre
        gapellido = apellido
        gdomicilio = domicilio
        gtelefono = telefono
        gdni = dni



    End Sub
End Class
