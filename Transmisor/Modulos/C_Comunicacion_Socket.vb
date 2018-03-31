Imports ClaseSocket

Public Class C_Socket 'cambiar el nombre de esta clase puede ser confuso
    Public Delegate Sub MensajeDelegado(Texto As String, TextBox_Nombre As String)
    Public Event Mensaje As MensajeDelegado

    Public Estado As Integer = 0 '0 - desconectado 1 - conectando 2- conectado 3- Error
    Dim SocketP3D As C_Sockets
    Dim RecepcionEntera As String = ""
    Dim Comandos As EstructuraDatos

    Dim Analizador As C_AnalizadorV2
    Dim Log_Entrada As C_Logg
    Dim Log_Salida As C_Logg

    Public Sub New(Analizador As C_AnalizadorV2, Log_Entrada As C_Logg, Log_Salida As C_Logg)
        Me.Analizador = Analizador
        Me.Log_Entrada = Log_Entrada
        Me.Log_Salida = Log_Salida
    End Sub
    Public Sub Conectar(IP As String, Port As Integer)
        SocketP3D = New C_Sockets
        AddHandler SocketP3D.E_Estado, AddressOf CambioEstado
        AddHandler SocketP3D.E_Recepcion, AddressOf RecepcionDatos
        SocketP3D.Conectar(IP, Port, DELAY_MEDIA_RECEPCION, DELAY_MEDIA_ENVIO, "<")
        Application.DoEvents()
    End Sub
    Public Sub Desconectar()
        SocketP3D.Desconectar()
    End Sub
    Public Sub Encolar(Datos As String)
        Log_Salida.Encolar("A Servidor: ", AZUL_, Datos)
        'LUA REQUIERE ENTER AL FINAL
        SocketP3D.Encolar(Datos & vbCrLf)
    End Sub
    Public Sub CambioEstado(ByVal Estado As Integer)
        Select Case Estado
            Case 1
                Log_Salida.Encolar("Conectando con Simulador")
            Case 2
                Log_Salida.Encolar("Conexion con Simulador establecida")
                'Dibujamos la conexion
                Dibujar_MediadorSimulador(True)
            Case 0
                Log_Salida.Encolar("Conexion con Simulador Cerrada")
                'Dibujamos la desconexion conexion
                Dibujar_MediadorSimulador(False)
            Case Else
                Log_Salida.Encolar(SocketP3D.Mensaje)
                'Dibujamos la desconexion conexion
                Dibujar_MediadorSimulador(False)
        End Select
        Me.Estado = Estado
    End Sub
    Public Sub RecepcionDatos(ByVal Datos_Recepcion As String)
        Log_Entrada.Encolar("", 0, Datos_Recepcion)
        Analizador.Encolar(Datos_Recepcion, "S")
    End Sub
    Protected Sub Escribe(Texto As String)
        'Console.WriteLine("RAISE: " & Rich_Nombre)
        RaiseEvent Mensaje(Texto, "TextSocket")
    End Sub
End Class


