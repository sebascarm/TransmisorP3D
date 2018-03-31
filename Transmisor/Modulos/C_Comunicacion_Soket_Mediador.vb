Imports ClaseSocket
Public Class C_Soket_Mediador
    Public Remoto As Boolean
    Public Mediador As Boolean
    Public Estado As Integer
    Dim SocketRemoto As C_Sockets
    Dim IP As String
    Dim Port As Integer
    'variables de logs
    Dim Log_Salida As C_Logg
    Dim Analizador_Remoto As C_Analizador_Remoto
    Public Sub Remoto_Conectar(IP As String, Port As Integer, Log_Salida As C_Logg, Analizador_Remoto As C_Analizador_Remoto)
        Remoto = True
        Mediador = False
        Me.Log_Salida = Log_Salida
        Me.Analizador_Remoto = Analizador_Remoto
        SocketRemoto = New C_Sockets
        AddHandler SocketRemoto.E_Estado, AddressOf CambioEstado
        AddHandler SocketRemoto.E_Recepcion, AddressOf RecepcionDatos
        SocketRemoto.Conectar(IP, Port, DELAY_MEDIA_RECEPCION, DELAY_MEDIA_ENVIO)
        Application.DoEvents()
    End Sub
    Public Sub Mediador_Escuchar(IP As String, Port As Integer, Log_Salida As C_Logg, Analizador_Remoto As C_Analizador_Remoto)
        Remoto = False
        Mediador = True
        Me.IP = IP
        Me.Port = Port
        Me.Log_Salida = Log_Salida
        Me.Analizador_Remoto = Analizador_Remoto
        SocketRemoto = New C_Sockets
        AddHandler SocketRemoto.E_Estado, AddressOf CambioEstado
        AddHandler SocketRemoto.E_Recepcion, AddressOf RecepcionDatos
        SocketRemoto.Escuchar(IP, Port, DELAY_MEDIA_RECEPCION, DELAY_MEDIA_ENVIO)
        Application.DoEvents()
    End Sub
    Public Sub Desconectar()
        SocketRemoto.Desconectar()
    End Sub
    Public Sub CambioEstado(ByVal Estado As Integer)
        If Remoto Then
            'equipo remoto
            Select Case Estado
                Case 1
                    Log_Salida.Encolar("Conectando con Mediador")
                Case 2
                    Log_Salida.Encolar("Conexion con Mediador establecida")
                    'Dibujamos la conexion
                    Call Dibujar_ConexionconMediador(True)
                Case 0
                    Log_Salida.Encolar("Conexion con Mediador Cerrada")
                    'Dibujamos la conexion
                    Call Dibujar_ConexionconMediador(False)
                Case Else
                    Log_Salida.Encolar(SocketRemoto.Mensaje)
                    'Dibujamos la conexion
                    Call Dibujar_ConexionconMediador(False)
            End Select
        Else
            'equipo mediador
            Select Case Estado
                Case 1
                    Log_Salida.Encolar("Esperando equipo Remoto")
                Case 2
                    Log_Salida.Encolar("Conexion con equipo Remoto establecida")
                    'Dibujamos la conexion
                    Call Dibujar_ConexionconRemoto(True)
                Case 0
                    Log_Salida.Encolar("Conexion con equipo Remoto Cerrada")
                    'Dibujamos la conexion
                    Call Dibujar_ConexionconRemoto(False)
                Case 3
                    Log_Salida.Encolar("Conexion Cerrada por Cliente / Error")
                    'Dibujamos la conexion
                    Call Dibujar_ConexionconRemoto(False)
                    'REVISAMOS SI HAY QUE ESCUCHAR AUTOMATICAMENTE
                    If MEDIADOR_AUTO Then 'ya es mediador no hace falta verificarlo
                        Call Mediador_Escuchar(IP, Port, Log_Salida, Analizador_Remoto)
                    End If
                Case Else
                    Log_Salida.Encolar(SocketRemoto.Mensaje)
            End Select
        End If
        Me.Estado = Estado
    End Sub
    Public Sub RecepcionDatos(ByVal Datos_Recepcion As String)
        Analizador_Remoto.Encolar(SocketRemoto.Datos_Recepcion)
    End Sub
    Public Sub Encolar(Datos As String)
        SocketRemoto.Encolar(Datos)
    End Sub
End Class

