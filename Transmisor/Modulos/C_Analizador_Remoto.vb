Imports System.Threading
Public Class C_Analizador_Remoto
    'CADENA DE DATOS:
    'TIPOLOG='Tipo', TEXTO1='Texto', COLOR1='Color1', TEXTO2='Texto2', COLOR2='Color2'[FIN]"
    'TIPOLOG='COMANDO', TEXTO1='BOTON_A', COLOR1='0', TEXTO2='', COLOR2=''[FIN]"

    Public Iniciado As Boolean = False
    Dim BUFFER As String
    Public Log_General As C_Logg
    Public Log_Serie1 As C_Logg
    Public Log_Serie2 As C_Logg
    Public Log_Socket As C_Logg
    Dim C_ColaEntrada As New Queue()
    Public Sub Iniciar(Log_General As C_Logg, Log_Serie1 As C_Logg, Log_Serie2 As C_Logg, Log_Socket As C_Logg)
        Me.Log_General = Log_General
        Me.Log_Serie1 = Log_Serie1
        Me.Log_Serie2 = Log_Serie2
        Me.Log_Socket = Log_Socket
        ' R console.WriteLine("Iniciando Analizador Remoto")
        'Creamos proceso de recepcion
        Dim Proc_Recepcion_Analisis As New Thread(AddressOf Proceso_LeerCola) With {
        .IsBackground = True}
        Proc_Recepcion_Analisis.Start()
        'parametro de inicio
        Me.Iniciado = True
    End Sub
    Public Sub Encolar(Datos As String)
        C_ColaEntrada.Enqueue(Datos)
    End Sub
    Private Sub Proceso_LeerCola()
        'Este proceso se encuentra leyendo elementos en cola para enviar
        Dim CantidadCola As Integer
        Dim Datos As String
        Dim Comandos As String = ""
        Dim Origen As String = ""
        Do
            CantidadCola = C_ColaEntrada.Count
            If CantidadCola > 0 Then
                Try
                    Datos = CStr(C_ColaEntrada.Dequeue)
                    Call Analizar(Datos)
                Catch
                    Select Case Err.Number
                        Case 5
                            If VER_WARNING Then
                                LOGGENERAL.Encolar("Analizador Remoto Warning: Cola Vacía", ROJO_)
                            End If
                            Console.WriteLine("Analizador Remoto Warning: Cola Vacía")
                        Case Else
                            LOGGENERAL.Encolar("Analizador Remoto - Error Lectura Cola: " & Err.Number & " " & Err.Description, ROJO_)
                    End Select
                End Try
            End If
            'dormir 10 ms
            Thread.Sleep(20)
        Loop
    End Sub
    Private Sub Analizar(Datos As String)
        Dim TiempoIni As DateTime
        Dim TiempoFin As DateTime
        Dim Buffer_Total As String
        Dim Buffer_Estructura As EstructuraDatos
        Dim Comando As EstructuraDatos
        Dim Comando_Unico As String
        Dim Comando_Estructura As EstructuraLogs
        Dim Matriz_Comandos(200) As EstructuraLogs
        Dim Analisis As EstructuraAnalisis
        Dim Indice As Integer = 0
        TiempoIni = Now()
        Console.WriteLine("Analizar Datos: " & Datos & "-")
        Buffer_Total = Agregar_Buffer_Total(Datos)
        'Obtenemos la primer parte (todos los comandos enteros) y la parte final (pedazo de comando incompleto)
        Console.WriteLine("Analizar Buffer Total: " & Buffer_Total & "-")
        Buffer_Estructura = Obtener_Buffer_Estructura(Buffer_Total, "[FIN]")
        'Obtenemos el primer comando del buffer
        Comando = Obtener_Comando(Buffer_Estructura.Inicio, "[FIN]")
        Comando_Unico = Comando.Inicio
        'Bucle de proceso de cada comando
        While Comando_Unico <> ""
            'Desglosamos el comando y guardamos en matriz
            Comando_Estructura = Almacenar_Logs(Comando_Unico)
            'Analisis del comando
            Analisis = Analizar_Comando(Comando_Estructura)
            If Analisis.Aceptado Then
                'almacenar y revisar si tenemos warning
                Matriz_Comandos(Indice) = Comando_Estructura
                Indice += 1
                'indice mayor a 200 para almacenar en matriz / limite
                If Indice > 199 Then
                    Indice = 199
                    LOGGENERAL.Encolar("Error Limite de Matriz superado", ROJO_)
                End If
                If Analisis.Warning <> "" Then
                    LOGGENERAL.Encolar("Warning Analisis: " & Analisis.Warning, ROJO_)
                End If
            Else
                'comando error
                LOGGENERAL.Encolar("Error Analisis: " & Analisis.Warning, ROJO_)
            End If
            'revisamos si nos quedan comandos
            If Comando.Final = "" Then
                Comando_Unico = ""
            Else
                Comando = Obtener_Comando(Comando.Final, "[FIN]")
                Comando_Unico = Comando.Inicio
            End If
        End While
        'almacenamos en el buffer si quedo una porcion incompleta
        If Buffer_Estructura.Final <> "" Then
            Agregar_en_Buffer(Buffer_Estructura.Final)
        End If
        'enviar al sender
        Call Sender(Matriz_Comandos)
        'control de tiempo
        TiempoFin = Now()
        ' R console.WriteLine(TiempoFin - TiempoIni)
    End Sub
    Private Function Analizar_Comando(Comando As EstructuraLogs) As EstructuraAnalisis
        Dim Valores_Validos() As String
        Dim Analizar As Boolean = True
        Analizar_Comando.Aceptado = True
        Analizar_Comando.Warning = ""
        'anlisis de tipo de log
        ReDim Valores_Validos(0)
        Valores_Validos = {"LOGGENERAL", "LOGSERIE1", "LOGSERIE2", "LOGSOCKET", "COMANDO", "ARCHIVO", "DIBUJAR"}
        If Not Validos(Comando.TipoLog, Valores_Validos) Then
            Analizar = False
            Analizar_Comando.Warning = "Error: tipo de Log no reconocido: '" & Comando.TipoLog & "'"
        End If
        Analizar_Comando.Aceptado = Analizar
    End Function
    Private Function Agregar_Buffer_Total(Buffer_Inicial As String) As String
        Dim Buffer_Temp As String = ""
        Buffer_Temp = BUFFER & Buffer_Inicial
        Agregar_Buffer_Total = Buffer_Temp
    End Function
    Private Sub Agregar_en_Buffer(Datos As String)
        BUFFER = BUFFER & Datos
    End Sub
    Private Sub Sender(Matriz_Comando() As EstructuraLogs)
        Dim Destino As String
        Dim Indice As Integer = 0
        Dim Texto1 As String
        Dim Color1 As Integer
        Dim Texto2 As String
        Dim Color2 As Integer

        'Armado de los paquetes
        Destino = Matriz_Comando(Indice).TipoLog
        Do While Destino <> ""
            Texto1 = Matriz_Comando(Indice).Texto1
            If Matriz_Comando(Indice).Color1 = "" Then
                Matriz_Comando(Indice).Color1 = "0"
            Else
                Color1 = CInt(Matriz_Comando(Indice).Color1)
            End If
            Texto2 = Matriz_Comando(Indice).Texto2
            If Matriz_Comando(Indice).Color2 = "" Then
                Matriz_Comando(Indice).Color2 = "0"
            Else
                Color2 = CInt(Matriz_Comando(Indice).Color2)
            End If
            'MENSAJES QUE LLEGAN AL EQUIPO REMOTO O AL MEDIADOR
            Select Case Destino 'TIPOLOG=
                Case "LOGGENERAL"
                    Log_General.Encolar(Texto1, Color1, Texto2, Color2)
                Case "LOGSERIE1"
                    Log_Serie1.Encolar(Texto1, Color1, Texto2, Color2)
                Case "LOGSERIE2"
                    Log_Serie2.Encolar(Texto1, Color1, Texto2, Color2)
                Case "LOGSOCKET"
                    Log_Socket.Encolar(Texto1, Color1, Texto2, Color2)
                Case "COMANDO"
                    'botones y peticiones especiales (PRECIONAR BOTON / EJEMPLO PEDIDO DE ARCHIVO)
                    EjecutarComando(Texto1)
                Case "ARCHIVO"
                    'RECEPCION DE ARCHIVOS
                    AlmacenarRecepcion(Texto1, Texto2)
                Case "DIBUJAR"
                    'DIBUJO DE CONEXIONES
                    EjecutarDibujo(Texto1, Color1)
            End Select
            Indice += 1
            Destino = Matriz_Comando(Indice).TipoLog
        Loop

    End Sub
End Class

