Module conexiones
    Public Sub ConectarServidor()
        'realizamos la conexion
        Dim S_IP As String
        Dim S_Port As Integer
        S_IP = ClienteFSX.TeHost.Text
        S_Port = CInt(ClienteFSX.TePortControl.Text)
        'realizamos la conexion usamos la clase mediador con una instancia nueva
        SOCK_COMANDOS.Comando_Conectar(S_IP, S_Port, LOGGENERAL, ANALIZADOR_REMOTO)
        'ANALIZADOR_REMOTO.Iniciar(LOGGENERAL, LOGSERIE1, LOGSERIE2, LOGGSOCKET)
    End Sub
    Public Sub ConectarSimulador(Handle As IntPtr)
        'realizamos la conexion
        SIMCON.Conectar(IP, CInt(PORT), Handle)
    End Sub
    Public Sub DesconectarSimulador()
        SIMCON.Desconectar()
    End Sub
    Public Sub ConectarPlaca1()
        'M_Conexion tiene el valor si conector
        SERIE1.Conectar(COM1, 1, 19200)
    End Sub
    Public Sub DesconectarPlaca1()
        SERIE1.Desconectar()
    End Sub
    Public Sub ConectarPlaca2()
        'M_Conexion tiene el valor si conector
        SERIE2.Conectar(COM2, 2, 19200)
    End Sub
    Public Sub DesconectarPlaca2()
        SERIE2.Desconectar()
    End Sub
    Public Sub EnviaraSimulador(Datos As String)
        If SIMCON.Estado <> 0 Then
            Dim DatoEnviar As String
            DatoEnviar = Datos
            'DatoEnviar = DatoEnviar   'ENVIAMOS 1 SOLO ENTER AL SERVIDOR (ponemos el enter)
            SIMCON.EnviarDatos(DatoEnviar)
        Else
            LOGGENERAL.Encolar("Simulador desconectado", ROJO_)
        End If
    End Sub
    Public Sub EnviarPlaca1(Datos As String)
        If SERIE1.Estado = 2 Then
            Dim DatoEnviar As String
            DatoEnviar = Datos
            SERIE1.Encolar(DatoEnviar)
        Else
            LOGGENERAL.Encolar("Serie 1 desconectado", ROJO_)
        End If
    End Sub
    Public Sub EnviarPlaca2(Datos As String)
        If SERIE2.Estado = 2 Then
            Dim DatoEnviar As String
            DatoEnviar = Datos
            SERIE2.Encolar(DatoEnviar)
        Else
            LOGGENERAL.Encolar("Serie 2 desconectado", ROJO_)
        End If
    End Sub
    Public Sub EscucharMediador()
        Dim M_IP As String
        Dim M_Port As Integer
        'Dim SOCK_MEDIADOR As C_Soket_Mediador
        M_IP = ClienteFSX.TeHostRemoto.Text
        M_Port = CInt(ClienteFSX.TePortRemoto.Text)
        'realizamos la conexion
        'SOCK_MEDIADOR = New C_Soket_Mediador()
        SOCK_MEDIADOR.Mediador_Escuchar(M_IP, M_Port, LOGGENERAL, ANALIZADOR_REMOTO)
        ANALIZADOR_REMOTO.Iniciar(LOGGENERAL, LOGSERIE1, LOGSERIE2, LOGGSOCKET)
    End Sub
    Public Sub ConectarMediador()
        Dim M_IP As String
        Dim M_Port As Integer
        M_IP = ClienteFSX.TeHostRemoto.Text
        M_Port = CInt(ClienteFSX.TePortRemoto.Text)
        'realizamos la conexion
        'SOCK_MEDIADOR.Remoto_Conectar(M_IP, M_Port, LOGGENERAL, LOGSERIE1, LOGSERIE2, LOGGSOCKET)
        SOCK_MEDIADOR.Remoto_Conectar(M_IP, M_Port, LOGGENERAL, ANALIZADOR_REMOTO)
        ANALIZADOR_REMOTO.Iniciar(LOGGENERAL, LOGSERIE1, LOGSERIE2, LOGGSOCKET)
    End Sub
    Public Sub DesconectarMediador()
        SOCK_MEDIADOR.Desconectar()
    End Sub
    Public Sub EnviarComando(Sender As Object)
        Dim Boton As Button = CType(Sender, Button)
        Dim Nombre As String = Boton.Name
        'R console.WriteLine(Nombre)
        Call SOCK_MEDIADOR.Encolar("TIPOLOG='COMANDO', TEXTO1='" & Nombre & "'[FIN]")
    End Sub
    Public Sub EnviarComandoMenu(Sender As Object)
        Dim Menu As ToolStripMenuItem = CType(Sender, ToolStripMenuItem)
        Dim Nombre As String = Menu.Name
        ' R console.WriteLine(Nombre)
        Call SOCK_MEDIADOR.Encolar("TIPOLOG='COMANDO', TEXTO1='" & Nombre & "'[FIN]")
    End Sub
    Public Sub EnviarArchivo(Archivo As String, Datos As String)
        Call SOCK_MEDIADOR.Encolar("TIPOLOG='ARCHIVO', TEXTO1='" & Archivo & "', TEXTO2='" & DATOS & "'[FIN]")
    End Sub
    Public Sub EnviaraServidor(Comando As String)
        Call SOCK_COMANDOS.Encolar("TIPOLOG='COM_REMOTO', TEXTO1='" & Comando & "'[FIN]")
    End Sub
End Module

