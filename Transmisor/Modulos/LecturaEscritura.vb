Module LecturaEscritura
    Public Sub LeerConfiguracionConexion()
        Dim Mediador As String
        Dim Arch_Config As C_GestorArchivo = New C_GestorArchivo()
        Arch_Config.Cargar("config.cfg")
        With ClienteFSX
            .TCom1.Text = Arch_Config.ObtenerValor("COM1:")
            .TCom2.Text = Arch_Config.ObtenerValor("COM2:")
            .TeHost.Text = Arch_Config.ObtenerValor("SERVIDOR:")
            .TePortControl.Text = Arch_Config.ObtenerValor("PUERTO_CONTROL:")
            .TePort.Text = Arch_Config.ObtenerValor("PUERTO:")
            .TeHostRemoto.Text = Arch_Config.ObtenerValor("SERVIDOR_REMOTO:")
            .TePortRemoto.Text = Arch_Config.ObtenerValor("PUERTO_REMOTO:")
            'retardos
            .TeSockEnvio.Text = Arch_Config.ObtenerValor("DELAY_SOCK_ENVIO:")
            .TeSockRecep.Text = Arch_Config.ObtenerValor("DELAY_SOCK_RECEPCION:")
            .TeSerieEnvio.Text = Arch_Config.ObtenerValor("DELAY_SERIE_ENVIO:")
            .TeSerieRecep.Text = Arch_Config.ObtenerValor("DELAY_SERIE_RECEPCION:")
            .TeMediaEnvio.Text = Arch_Config.ObtenerValor("DELAY_MEDIA_ENVIO:")
            .TeMediaRecep.Text = Arch_Config.ObtenerValor("DELAY_MEDIA_RECEPCION:")
            'MEDIADOR AUTO CONEXION
            Mediador = Arch_Config.ObtenerValor("MEDIADOR:")
            If Mediador = "AUTO" Then
                MEDIADOR_AUTO = True
            End If
            'asignamos los retardos a las variables globales
            DELAY_SOCK_ENVIO = CInt(.TeSockEnvio.Text)
            DELAY_SOCK_RECEPCION = CInt(.TeSockRecep.Text)
            DELAY_SERIE_ENVIO = CInt(.TeSerieEnvio.Text)
            DELAY_SERIE_RECEPCION = CInt(.TeSerieRecep.Text)
            DELAY_MEDIA_ENVIO = CInt(.TeMediaEnvio.Text)
            DELAY_MEDIA_RECEPCION = CInt(.TeMediaRecep.Text)
        End With
    End Sub
    Public Sub GuardarConfiguracionConexion()
        Dim Arch_Guardar As C_GestorArchivo = New C_GestorArchivo()
        Arch_Guardar.Guardar("config.cfg")
        With ClienteFSX
            Arch_Guardar.Agregar("COM1:", .TCom1.Text)
            Arch_Guardar.Agregar("COM2:", .TCom2.Text)
            Arch_Guardar.Agregar("SERVIDOR:", .TeHost.Text)
            Arch_Guardar.Agregar("PUERTO:", .TePort.Text)
            Arch_Guardar.Agregar("SERVIDOR_REMOTO:", .TeHostRemoto.Text)
            Arch_Guardar.Agregar("PUERTO_REMOTO:", .TePortRemoto.Text)
            Arch_Guardar.Agregar("PUERTO_CONTROL:", .TePortControl.Text)
            'retardos
            Arch_Guardar.Agregar("DELAY_SOCK_ENVIO:", .TeSockEnvio.Text)
            Arch_Guardar.Agregar("DELAY_SOCK_RECEPCION:", .TeSockRecep.Text)
            Arch_Guardar.Agregar("DELAY_SERIE_ENVIO:", .TeSerieEnvio.Text)
            Arch_Guardar.Agregar("DELAY_SERIE_RECEPCION:", .TeSerieRecep.Text)
            Arch_Guardar.Agregar("DELAY_MEDIA_ENVIO:", .TeMediaEnvio.Text)
            Arch_Guardar.Agregar("DELAY_MEDIA_RECEPCION:", .TeMediaRecep.Text)
        End With
        Arch_Guardar.Cerrar("config.cfg")
    End Sub
    Public Sub PedidodeConfguracion()
        Dim Valores As String
        Dim Arch_Cargar As C_GestorArchivo = New C_GestorArchivo()
        Arch_Cargar.Cargar("config.cfg")
        Valores = Arch_Cargar.C_Archivo
        EnviarArchivo("config.cfg", Valores)
    End Sub
    Public Sub AlmacenarRecepcion(Archivo As String, Contenido As String)
        Dim Arch_Guardar As C_GestorArchivo = New C_GestorArchivo()
        Arch_Guardar.Guardar(Archivo)
        'remplazamos el contenido del archivo por el nuevo contenido
        Arch_Guardar.C_Archivo = Contenido
        Arch_Guardar.Cerrar(Archivo)
    End Sub
End Module
