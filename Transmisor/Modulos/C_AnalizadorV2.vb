Imports System.Threading
Public Class C_AnalizadorV2
    Dim C_ColaEntrada As New Queue()
    Dim SECUENCIA_SOCKET As Integer = 0
    Dim SECUENCIA_SERIE1 As Integer = 0
    Dim SECUENCIA_SERIE2 As Integer = 0

    Dim SECUENCIA_ENVIO_SOCKET As Integer = 0
    Dim SECUENCIA_ENVIO_SERIE1 As Integer = 0
    Dim SECUENCIA_ENVIO_SERIE2 As Integer = 0

    Public Socket_Salida As C_Socket
    Public Serie1_Salida As C_PuertoSerie
    Public Serie2_Salida As C_PuertoSerie

    Public Sub Iniciar(Socket_Salida As C_Socket, Serie1_Salida As C_PuertoSerie, Serie2_Salida As C_PuertoSerie)
        Me.Socket_Salida = Socket_Salida
        Me.Serie1_Salida = Serie1_Salida
        Me.Serie2_Salida = Serie2_Salida
        Dim Proc_Recepcion_Analisis As New Thread(AddressOf Proceso_LeerCola) With {
        .IsBackground = True}
        Proc_Recepcion_Analisis.Start()
    End Sub
    Public Sub Encolar(Datos As String, Origen As String)
        Dim Texto As String
        Texto = "'" & Datos & "','" & Origen & "'"
        C_ColaEntrada.Enqueue(Texto)
    End Sub
    Private Sub Proceso_LeerCola()
        'Este proceso se encuentra leyendo elementos en cola para enviar
        Dim Bloqueo As Boolean = False
        Dim CantidadCola As Integer
        Dim Datos As String
        Dim Comandos As String = ""
        Dim Origen As String = ""
        Do
            If Bloqueo = False Then
                Bloqueo = True
                CantidadCola = C_ColaEntrada.Count
                If CantidadCola > 0 Then
                    Try
                        Datos = CStr(C_ColaEntrada.Dequeue)
                        Desencolar(Datos, Comandos, Origen)
                        Call Analizar(Comandos, Origen)
                    Catch
                        Select Case Err.Number
                            Case 5
                                LOGGENERAL.Encolar("Analizador Warning: Cola Vacía", ROJO_)
                            Case Else
                                LOGGENERAL.Encolar("Analizador - Error Lectura Cola: " & Err.Number & " " & Err.Description, ROJO_)
                        End Select
                    End Try
                End If
            End If
            'dormir 10 ms
            Thread.Sleep(20)
            Bloqueo = False
        Loop
    End Sub
    Private Sub Analizar(Datos As String, Origen As String) 'Aqui entra un comando unico
        Dim Comando_Estructura As EstructuraComando
        Dim Analisis As EstructuraAnalisis
        'Eliminar elemetos a Omitir
        Datos = Eliminar_Omitidos(Datos)
        'Eliminamos los Enters si existen
        Datos = Eliminar_Enter(Datos)
        'Analizamos si quedaron datos para el analisis (probablemente solo tenemos datos omitidos
        If Datos <> "" Then
            'Desglosamos el comando
            Comando_Estructura = Almacenar_Comando(Datos)
            'Analisis del comando
            Analisis = Analizar_Comando(Comando_Estructura)
            If Analisis.Aceptado Then
                If Analisis.Warning <> "" Then
                    LOGGENERAL.Encolar("Warning Analisis: " & Analisis.Warning, ROJO_)
                End If
                'Analisis aceptado
                Call Analizar_Secuencia(Comando_Estructura)
                'enviar al sender
                Call Sender(Comando_Estructura)
            Else
                'comando error
                LOGGENERAL.Encolar("Error Analisis: " & Analisis.Warning, ROJO_)
            End If
        End If
    End Sub
    Private Sub Analizar_Secuencia(Comando As EstructuraComando)
        Dim Secuencia As String
        Dim Secuencia_Numerica As Integer
        Dim Origen As String
        Dim Comparador As Integer
        'Elemento
        Secuencia = Comando.Encabezado_Secuencia
        Origen = Comando.Encabezado_Origen
        'Obtener la secuencia de comparacion
        Comparador = Secuencia_Comparador(Origen)
        'Comparacion
        Secuencia_Numerica = CInt(Secuencia)
        If Secuencia_Numerica <> Comparador Then
            'secuencia inicial?
            If Secuencia_Numerica = 0 Then
                Console.WriteLine("Secuencia reiniciada - Origen: " & Origen)
            Else
                'secuencia incorrecta
                LOGGENERAL.Encolar("Err Secuencia - Esperado: " & CStr(Comparador) & " Recibido: " & CStr(Secuencia_Numerica) & " Origen: " & Origen, ROJO_)
            End If
            'Reajustamos la secuencia
            Ajustar_Secuencia(Origen, Secuencia_Numerica + 1)
        Else
            'Secuencia correcta - incrementar el secuenciador
            Incremetar_Secuencia(Origen)
        End If
    End Sub
    Private Sub Ajustar_Secuencia(Origen As String, Nuevo_valor As Integer)
        Select Case Origen
            Case "S"
                SECUENCIA_SOCKET = Nuevo_valor
            Case "A"
                SECUENCIA_SERIE1 = Nuevo_valor
            Case "F"
                SECUENCIA_SERIE2 = Nuevo_valor
        End Select
    End Sub
    Private Function Secuencia_Comparador(Origen As String) As Integer
        Dim Comparador As Integer = 0
        Select Case Origen
            Case "S"
                Comparador = SECUENCIA_SOCKET
            Case "A"
                Comparador = SECUENCIA_SERIE1
            Case "F"
                Comparador = SECUENCIA_SERIE2
        End Select
        Secuencia_Comparador = Comparador
    End Function
    Private Sub Incremetar_Secuencia(origen As String)
        Select Case origen
            Case "S"
                SECUENCIA_SOCKET += 1
                If SECUENCIA_SOCKET = 100 Then SECUENCIA_SOCKET = 0
            Case "A"
                SECUENCIA_SERIE1 += 1
                If SECUENCIA_SERIE1 = 100 Then SECUENCIA_SERIE1 = 0
            Case "F"
                SECUENCIA_SERIE2 += 1
                If SECUENCIA_SERIE2 = 100 Then SECUENCIA_SERIE2 = 0
        End Select
    End Sub
    Private Sub Incremetar_Secuencia_Envio(origen As String)
        Select Case origen
            Case "S"
                SECUENCIA_ENVIO_SOCKET += 1
                If SECUENCIA_ENVIO_SOCKET = 100 Then SECUENCIA_ENVIO_SOCKET = 0
            Case "1"
                SECUENCIA_ENVIO_SERIE1 += 1
                If SECUENCIA_ENVIO_SERIE1 = 100 Then SECUENCIA_ENVIO_SERIE1 = 0
            Case "2"
                SECUENCIA_ENVIO_SERIE2 += 1
                If SECUENCIA_ENVIO_SERIE2 = 100 Then SECUENCIA_ENVIO_SERIE2 = 0
            Case "0"
                SECUENCIA_ENVIO_SERIE1 += 1
                SECUENCIA_ENVIO_SERIE2 += 1
                If SECUENCIA_ENVIO_SERIE1 = 100 Then SECUENCIA_ENVIO_SERIE1 = 0
                If SECUENCIA_ENVIO_SERIE2 = 100 Then SECUENCIA_ENVIO_SERIE2 = 0
        End Select
    End Sub
    Private Function Analizar_Comando(Comando As EstructuraComando) As EstructuraAnalisis
        Dim Valores_Validos() As String
        Dim Analizar As Boolean = True
        Analizar_Comando.Aceptado = True
        Analizar_Comando.Warning = ""
        'Analisis de encabezado (INICIO)
        If (Mid(Comando.Encabezado_Total, 1, 1) <> "[") Then
            Analizar = False
            Analizar_Comando.Warning = "Error: Falta inicio de encabezado: " & CStr(Comando.Comando_Total)
        End If
        'Analisis de encabezado (FINAL)
        If (Analizar) AndAlso (Mid(Comando.Encabezado_Total, 5, 1) <> "]") Then
            Analizar = False
            Analizar_Comando.Warning = "Error: Falta final de encabezado"
        End If
        'Analisis de encabezado (ORIGEN)
        If (Analizar) Then
            ReDim Valores_Validos(0)
            Valores_Validos = {"S", "A", "F", "M"}
            If Not Validos(Comando.Encabezado_Origen, Valores_Validos) Then
                Analizar = False
                Analizar_Comando.Warning = "Error: Origen desconocido: '" & Comando.Encabezado_Origen & "'"
            End If
        End If
        'Analisis de encabezado (SECUENCIA)
        If (Analizar) AndAlso Not IsNumeric(Comando.Encabezado_Secuencia) Then
            Analizar = False
            Analizar_Comando.Warning = "Error: Secuencia no numerica"
        End If
        'Analisis de COMANDO (INCIO)
        If (Analizar) AndAlso (Mid(Comando.Comando_Total, 1, 1) <> ">") Then
            Analizar = False
            Analizar_Comando.Warning = "Error: Falta inicio de comando"
        End If
        'Analisis de Comando (DESTINO)
        If (Analizar) Then
            ReDim Valores_Validos(0)
            Valores_Validos = {"1", "2", "0", "S", "M"}
            If Not Validos(Comando.Comando_Destino, Valores_Validos) Then
                Analizar = False
                Analizar_Comando.Warning = "Error: Destino no reconocido:: " & Comando.Comando_Destino
            End If
        End If
        'Analisis de Comando (MODULO)
        If (Analizar) Then
            ReDim Valores_Validos(0)
            Valores_Validos = {"ERR", "ENC", "MCP", "THR", "MIP", "YOK", "FIR"}
            If Not Validos(Comando.Comando_Modulo, Valores_Validos) Then
                Analizar = True
                Analizar_Comando.Warning = "Warning: Modulo Desconocido: '" & Comando.Comando_Modulo & "'"
            End If
        End If
        'Analisis de Comando (Varios)
        If (Analizar) AndAlso (Mid(Comando.Comando_Total, 6, 1) <> "_") Then
            Analizar = False
            Analizar_Comando.Warning = "Error: Guion de modulo erroneo: '" & Mid(Comando.Comando_Total, 6, 1) & "'"
        End If
        'Analisis de Comando (Varios)
        If (Analizar) AndAlso (Mid(Comando.Comando_Total, 12, 1) <> "=") Then
            Analizar = False
            Analizar_Comando.Warning = "Error: Igualdad de modulo erroneo: '" & Mid(Comando.Comando_Total, 13, 1) & "'"
        End If
        Analizar_Comando.Aceptado = Analizar
    End Function
    Private Sub Sender(Comando As EstructuraComando)
        Dim Destino As String
        Dim Indice As Integer = 0
        Dim Paquete_Servidor As String = ""
        Dim Paquete_Serie1 As String = ""
        Dim Paquete_Serie2 As String = ""
        Dim Paquete As String = ""
        'Armado de los paquetes
        Destino = Comando.Comando_Destino
        Call Incremetar_Secuencia_Envio(Destino)
        Select Case Destino
            Case "1"
                'Enviamos el comando
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE1)
                Serie1_Salida.Encolar(Paquete)
            Case "2"
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE2)
                'Enviamos el comando
                Serie2_Salida.Encolar(Paquete)
            Case "0"
                'Enviamos el comando
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE1)
                Serie1_Salida.Encolar(Paquete)
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE2)
                Serie2_Salida.Encolar(Paquete)
            Case "S"
                'Enviamos el comando
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SOCKET)
                Socket_Salida.Encolar(Paquete)
        End Select
    End Sub

End Class