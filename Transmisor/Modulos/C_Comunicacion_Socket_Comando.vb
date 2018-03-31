Imports ClaseSocket
Public Class C_Socket_Comando
    Public Estado As Integer
    Dim SocketComando As C_Sockets
    'variables de logs
    Dim Log_Salida As C_Logg
    Dim Analizador_Remoto As C_Analizador_Remoto
    Public Sub Comando_Conectar(IP As String, Port As Integer, Log_Salida As C_Logg, Analizador_Remoto As C_Analizador_Remoto)
        Me.Log_Salida = Log_Salida
        Me.Analizador_Remoto = Analizador_Remoto
        SocketComando = New C_Sockets
        AddHandler SocketComando.E_Estado, AddressOf CambioEstado
        AddHandler SocketComando.E_Recepcion, AddressOf RecepcionDatos
        SocketComando.Conectar(IP, Port, DELAY_MEDIA_RECEPCION, DELAY_MEDIA_ENVIO)
        Application.DoEvents()
    End Sub
    Public Sub Desconectar()
        SocketComando.Desconectar()
    End Sub
    Public Sub CambioEstado(ByVal Estado As Integer)
        Select Case Estado
            Case 1
                Log_Salida.Encolar("Conectando con Servidor")
            Case 2
                Log_Salida.Encolar("Conexion con Servidor establecida")
                'Dibujar conexion
                Call Dibujar_MediadorServidor(True)
            Case 0
                Log_Salida.Encolar("Conexion con Servidor Cerrada")
                'Dibujar conexion
                Call Dibujar_MediadorServidor(False)
            Case Else
                Log_Salida.Encolar(SocketComando.Mensaje)
                'Dibujar conexion
                Call Dibujar_MediadorServidor(False)
        End Select
    End Sub
    Public Sub RecepcionDatos(ByVal Datos_Recepcion As String)
        Analizador_Remoto.Encolar(SocketComando.Datos_Recepcion)
    End Sub
    Public Sub Encolar(Datos As String)
        SocketComando.Encolar(Datos)
    End Sub
End Class
