Imports ClaseSDK_PMDG
Public Class C_ComSim
    Public Estado As Integer = 0 '0 - desconectado 1 - conectando 2- conectado 3- Error
    Public ModulosValidos As C_SDK.S_ModulosValidos
    'Dim SDK As C_SDK_PMDG
    Dim SDK As C_SDK
    Dim Analizador As C_AnalizadorV3
    Dim Log_Entrada As C_Logg
    Dim Log_Salida As C_Logg
    Public Sub New(Analizador As C_AnalizadorV3, Log_Entrada As C_Logg, Log_Salida As C_Logg)
        Me.Analizador = Analizador
        Me.Log_Entrada = Log_Entrada
        Me.Log_Salida = Log_Salida
    End Sub
    Public Sub ActualizarModulos()
        If SDK IsNot Nothing Then
            SDK.ModulosValidos = ModulosValidos
            SDK.ActualizarModulos()
        End If
    End Sub
    Public Sub Conectar(IP As String, Port As Integer, Handle As IntPtr)
        If SDK Is Nothing Then ' revisamos que no exista una instancia
            SDK = New C_SDK
            'SDK.ModulosValidos = ModulosValidos
            AddHandler SDK.E_Estado, AddressOf CambioEstado
            AddHandler SDK.E_Recepcion, AddressOf RecepcionDatos
            SDK.Conectar(Handle)
            Application.DoEvents()
        Else
            Log_Salida.Encolar("Simulador actualmente conectado")
        End If
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
            Case 3
                'Error
                Log_Salida.Encolar(SDK.Mensaje, ROJO_)
            Case Else
                'Log_Salida.Encolar(SocketP3D.Mensaje)
                'Dibujamos la desconexion conexion
                Dibujar_MediadorSimulador(False)
        End Select
        Me.Estado = Estado
    End Sub
    Public Sub Desconectar()
        If Me.Estado <> 0 Then
            SDK.Desconectar()
            SDK = Nothing 'liberamos la instancia
        Else
            Log_Salida.Encolar("Simulador actualmente desconectado")
        End If
    End Sub
    Public Sub RecepcionDatos(ByVal Parametro As String, Valor As String)
        Dim Datos_Recepcion As String
        Dim Traduccion As String
        Datos_Recepcion = Parametro & "=" & Valor
        Traduccion = TRADUCTOR.Traducir(Parametro, Valor)
        If Traduccion <> "" Then
            Log_Entrada.Encolar("", 0, Datos_Recepcion)
            Analizador.Encolar(Traduccion, "S")
        Else
            'no se encontro traduccion
            Log_Entrada.Encolar("", 0, Datos_Recepcion, ROJO_)
        End If
    End Sub
    Public Sub RecibirWin()
        If SDK IsNot Nothing Then
            SDK.Recibir()
        End If
    End Sub
    Public Sub EnviarDatos(Comando As String)
        Log_Salida.Encolar("A Servidor: ", AZUL_, Comando)
        'SDK.Enviar(Comando)
    End Sub
End Class
