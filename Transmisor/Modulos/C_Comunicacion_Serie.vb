Imports ClaseSerie
Public Class C_PuertoSerie
    Public Estado As Integer = 0 '0 - desconectado 1 - conectando 2- conectado 3- Error
    Dim Placa As Integer
    Dim PTOSerie As C_Serie
    'objetos
    Dim Analizador As C_AnalizadorV3
    Dim Log_Entrada As C_Logg
    Dim Log_Salida As C_Logg
    Public Sub New(Analizador As C_AnalizadorV3, Log_Entrada As C_Logg, Log_Salida As C_Logg)
        'Objetos
        Me.Analizador = Analizador
        Me.Log_Entrada = Log_Entrada
        Me.Log_Salida = Log_Salida
        PTOSerie = New C_Serie
        AddHandler PTOSerie.E_Estado, AddressOf CambioEstado
        AddHandler PTOSerie.E_Recepcion, AddressOf RecepcionDatos
    End Sub
    Public Sub Conectar(COM As String, Numero_Placa As Integer, Baudios As Integer)
        If Me.Estado <> 2 Then 'REVISAMOS ACA QUE NO ESTE CONECTADO, DESDE EL PUERTO TENDRIAMOS ERROR
            Me.Placa = Numero_Placa
            PTOSerie.Conectar(COM, Baudios, DELAY_SERIE_RECEPCION, DELAY_SERIE_ENVIO, "<")
            Application.DoEvents()
        Else
            Log_Salida.Encolar("Placa " & Placa & " previamente conectada")
        End If
    End Sub
    Public Sub Desconectar()
        If (Estado = 2) Then
            PTOSerie.Desconectar()
        End If
    End Sub
    Public Sub Encolar(Datos As String)
        If Estado = 2 Then
            Log_Salida.Encolar("A  Placa " & Placa & ": ", VERDE_, Datos)
            PTOSerie.Encolar(Datos)
        Else
            Log_Salida.Encolar("DROP Placa: ", ROJO_, Datos)
        End If
    End Sub
    Public Sub CambioEstado(ByVal Estado As Integer)
        Select Case Estado
            Case 1
                Log_Salida.Encolar("Conectando con Placa " & Placa)
            Case 2
                Log_Salida.Encolar("Conexion con Placa " & Placa & " establecida")
                'Dibujamos la conexion
                If Placa = 1 Then
                    Dibujar_MediadorArduino(True)
                Else
                    Dibujar_MediadorFeudrino(True)
                End If
            Case 0
                Log_Salida.Encolar("Conexion con Placa " & Placa & " cerrada")
                'Dibujamos la conexion
                If Placa = 1 Then
                    Dibujar_MediadorArduino(False)
                Else
                    Dibujar_MediadorFeudrino(False)
                End If
            Case Else
                Log_Salida.Encolar(PTOSerie.Mensaje)
                'Dibujamos la conexion
                If Placa = 1 Then
                    Dibujar_MediadorArduino(False)
                Else
                    Dibujar_MediadorFeudrino(False)
                End If
        End Select
        Me.Estado = Estado
    End Sub
    Public Sub RecepcionDatos(ByVal Datos_Recepcion As String)
        Log_Entrada.Encolar("", 0, Datos_Recepcion)
        If Placa = 1 Then
            'Arduino
            Analizador.Encolar(Datos_Recepcion, "A")
        Else
            'Feudrino
            Analizador.Encolar(Datos_Recepcion, "F")
        End If
    End Sub
End Class


