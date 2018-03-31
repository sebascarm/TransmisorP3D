Module Inicio
    'MEDIADOR AUTO
    Public MEDIADOR_AUTO As Boolean = False
    'MODULOS CONECTADOS
    Public THR_CONECTADO As Boolean = False
    Public MCP_CONECTADO As Boolean = False
    Public MIP_CONECTADO As Boolean = False
    Public YOK_CONECTADO As Boolean = False
    Public FIR_CONECTADO As Boolean = False
    'variables de conexion remota
    Public CONECTADO_REMOTO_CLIENTE As Boolean
    Public CONECTADO_REMOTO_SERVIDOR As Boolean
    Public BUFFER_REMOTO As String
    'variables de logs
    Public LOGGENERAL As C_Logg
    Public LOGSERIE1 As C_Logg
    Public LOGSERIE2 As C_Logg
    Public LOGGSOCKET As C_Logg
    'Clase Analizador
    Public ANALIZADOR As C_AnalizadorV3
    Public ANALIZADOR_REMOTO As C_Analizador_Remoto
    'Clase Puertos
    'Public SOCKET As C_Socket
    Public SIMCON As C_ComSim
    Public SERIE1 As C_PuertoSerie
    Public SERIE2 As C_PuertoSerie
    Public SOCK_MEDIADOR As C_Soket_Mediador
    Public SOCK_SERVIDOR As C_Soket_Mediador
    Public SOCK_COMANDOS As C_Socket_Comando
    'VARIABLES DE CONEXION
    Public IP As String
    Public PORT As String
    Public COM1 As String
    Public COM2 As String
    'VARIBLES VISIBLES DE LOGS
    Public VER_WARNING As Boolean = False
    'variables de retardo
    Public DELAY_SOCK_ENVIO As Integer
    Public DELAY_SOCK_RECEPCION As Integer
    Public DELAY_SERIE_ENVIO As Integer
    public DELAY_SERIE_RECEPCION As Integer
    Public DELAY_MEDIA_ENVIO as Integer
    Public DELAY_MEDIA_RECEPCION As Integer
    'clase TRADUCTOR
    Public TRADUCTOR As C_Traductor
    Public Sub Iniciar()
        'instanciamos los logs
        LOGGENERAL = New C_Logg(ClienteFSX.RiEstado)
        LOGSERIE1 = New C_Logg(ClienteFSX.RiBufferSerie1)
        LOGSERIE2 = New C_Logg(ClienteFSX.RiBufferSerie2)
        LOGGSOCKET = New C_Logg(ClienteFSX.RiBufferSocket)
        'instanciamos el analizador
        ANALIZADOR = New C_AnalizadorV3()
        ANALIZADOR_REMOTO = New C_Analizador_Remoto
        'instanciamos el socket Y COM
        SIMCON = New C_ComSim(ANALIZADOR, LOGGSOCKET, LOGGENERAL)
        SERIE1 = New C_PuertoSerie(ANALIZADOR, LOGSERIE1, LOGGENERAL)
        SERIE2 = New C_PuertoSerie(ANALIZADOR, LOGSERIE2, LOGGENERAL)
        SOCK_MEDIADOR = New C_Soket_Mediador()
        SOCK_SERVIDOR = New C_Soket_Mediador()
        SOCK_COMANDOS = New C_Socket_Comando()
        'instanciamos el traductor
        TRADUCTOR = New C_Traductor()

        'Iniciamos el analizador (necesita los parametros de salida) - referencia cruzada
        ANALIZADOR.Iniciar(SIMCON, SERIE1, SERIE2)
        'ANALIZADOR.Iniciar(SOCKET, SERIE1, SERIE2)
        'ANALIZADOR.Iniciar(SIMCON, SERIE1, SERIE2)
        'leer archivo de configuracion
        Call LeerConfiguracionConexion()
        'asignar valores
        IP = ClienteFSX.TeHost.Text
        PORT = ClienteFSX.TePort.Text
        COM1 = ClienteFSX.TCom1.Text
        COM2 = ClienteFSX.TCom2.Text
        'cargar dibujo inicial
        Inciar_Equipo()
    End Sub
End Module

