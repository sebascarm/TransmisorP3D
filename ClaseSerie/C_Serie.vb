Imports System.IO
Imports System.Threading
Public Class C_Serie
    ''' <summary>
    ''' Evento que devuelve un cambio de estado (Integer)
    ''' Resultados: 0-Desconectado 1-Conectando 2-Conectado 3-Error
    ''' </summary>
    ''' <param name="Estado">0-Desconectado 1-Conectando 2-Conectado 3-Error</param>
    Public Event E_Estado(ByVal Estado As Integer)
    Public Event E_Recepcion(ByVal Datos_Recepcion As String)

    Public Estado As Integer = 0 '0 - desconectado 1 - conectando 2- conectado 3- Error
    Public Mensaje As String = ""

    Dim COM As String
    Dim Baudios As Integer
    Dim PuertoSerie As System.IO.Ports.SerialPort = New Ports.SerialPort

    Dim DELAY_RECEPCION As Integer
    Dim DELAY_ENVIO As Integer

    Dim C_ColaEnvio As New Queue()
    Dim C_ColaRecepcion As New Queue()
    Dim BufferRecepcion As String
    Dim FinRecepcion As String
    ''' <summary>
    ''' Conexion Serie
    ''' </summary>
    ''' <param name="COM">Puerto Serie</param>
    ''' <param name="Baudios">Baudios</param>
    ''' <param name="Retardo_Escucha">Retardo de la cola de escucha en milisegundos</param>
    ''' <param name="Retardo_Envio">Retardo de la cola de envio en milisegundos</param>
    ''' <param name="FindeRecepcion">Caracter de Fin de comando, vacio por defecto, Ademas del caracter de fin el { tambien es fin de comando</param>
    ''' <remarks>Establece comunicacion a travez del puerto serie</remarks>
    Public Sub Conectar(COM As String, Baudios As Integer, Retardo_Escucha As Integer, Retardo_Envio As Integer, Optional FindeRecepcion As String = "")
        Me.COM = COM
        Me.Baudios = Baudios
        Me.DELAY_RECEPCION = Retardo_Escucha
        Me.DELAY_ENVIO = Retardo_Envio
        Me.FinRecepcion = FindeRecepcion
        Try
            'Estado en proceso de conexion
            Estado = 1
            Mensaje = "CONECTANDO"
            RaiseEvent E_Estado(Estado)
            PuertoSerie.ParityReplace = &H3B                    ' replace ";" when parity error occurs 
            'C_Log_Salida.Encolar("paridad")
            PuertoSerie.PortName = "COM" & Me.COM
            PuertoSerie.BaudRate = Me.Baudios
            PuertoSerie.Parity = IO.Ports.Parity.None
            PuertoSerie.DataBits = 8
            PuertoSerie.DtrEnable = True
            PuertoSerie.StopBits = IO.Ports.StopBits.One
            PuertoSerie.Handshake = IO.Ports.Handshake.None
            PuertoSerie.RtsEnable = False
            PuertoSerie.ReceivedBytesThreshold = 1
            'C_PuertoSerie.NewLine = vbCr         ' CR must be the last char in frame. This terminates the SerialPort.readLine 
            PuertoSerie.ReadTimeout = 1000
            PuertoSerie.Open()
            'Estado Conectado
            Estado = 2
            Mensaje = "CONECTADO"
            RaiseEvent E_Estado(Estado)
            'Creamos proceso de recepcion
            Dim Proceso_Recepcion As New Thread(AddressOf Proceso_Receptor_Serie) With {
                .IsBackground = True}
            Proceso_Recepcion.Start()
            'Creamos proceso de envio
            Dim Proceso_Envio As New Thread(AddressOf Proceso_Enviador_Serie) With {
                .IsBackground = True}
            Proceso_Envio.Start()
        Catch
            PuertoSerie.Close()
            Mensaje = "Error en Conexion Serie COM" & COM
            Estado = 3
            RaiseEvent E_Estado(Estado)
        End Try
    End Sub
    Public Sub Desconectar()
        If Estado <> 0 Then
            If PuertoSerie.IsOpen Then
                Estado = 0
                PuertoSerie.Close()
                Mensaje = "DESCONECTADO"
                RaiseEvent E_Estado(Estado)
            End If
        End If
    End Sub
    Public Sub Encolar(Datos As String)
        C_ColaEnvio.Enqueue(Datos)
    End Sub
    Private Sub Proceso_Receptor_Serie()
        Dim Recepcion As String
        Dim BytesL As Integer
        Dim PlacaSTR As String = ""
        While Estado = 2
            Try
                BytesL = PuertoSerie.BytesToRead
                If BytesL > 0 Then
                    'cargamos los datos
                    Recepcion = PuertoSerie.ReadExisting()
                    'Analisis
                    SubAnalisisRecepcion(Recepcion)
                End If
                'dormir 10 ms
                Thread.Sleep(DELAY_RECEPCION)
            Catch
                PuertoSerie.Close()
                Mensaje = "Error Puerto Serie COM " & COM & ": " & Err.Number & " " & Err.Description
                Estado = 3
                RaiseEvent E_Estado(Estado)
            End Try
        End While
    End Sub
    Private Sub Proceso_Enviador_Serie()
        'Este proceso se encuentra leyendo elementos en cola para enviar
        Dim Bloqueo As Boolean = False
        Dim CantidadCola As Integer
        Dim DatosEnviar As String = ""
        While Estado = 2
            If Bloqueo = False Then
                Bloqueo = True
                CantidadCola = C_ColaEnvio.Count
                If CantidadCola > 0 Then
                    Try
                        'ENVIAR AL PUERTO SERIE
                        DatosEnviar = CStr(C_ColaEnvio.Dequeue)
                        PuertoSerie.Write(DatosEnviar)
                    Catch
                        Select Case Err.Number
                            Case 5
                                Mensaje = "Serie Warning: Cola Vacía"
                            Case Else
                                Mensaje = "Serie COM " & COM & " - Error: " & Err.Number & " " & Err.Description
                                Estado = 3
                                RaiseEvent E_Estado(Estado)
                        End Select
                    End Try
                End If
            End If
            'dormir 10 ms
            Thread.Sleep(DELAY_ENVIO)
            Bloqueo = False
        End While
    End Sub
    Private Sub SubAnalisisRecepcion(Datos As String)
        Dim Pos As Integer
        Dim Envio As String
        If FinRecepcion = "" Then
            'sin analisis de fin 
            RaiseEvent E_Recepcion(Datos)
        Else
            'con analisis de fin
            BufferRecepcion += Datos
            Pos = BufferRecepcion.IndexOf(FinRecepcion)
            If Pos = -1 Then
                Pos = BufferRecepcion.IndexOf("}")
            End If
            Do While Pos > -1
                'encontrado
                Envio = BufferRecepcion.Substring(0, Pos + 1)
                'enviar
                RaiseEvent E_Recepcion(Envio)
                'Recomponer el buffer
                If BufferRecepcion.Length > Pos + 1 Then
                    BufferRecepcion = BufferRecepcion.Substring(Pos + 1)
                Else
                    'no quedan mas datos
                    BufferRecepcion = ""
                End If
                'recargamos la posicion
                Pos = BufferRecepcion.IndexOf(FinRecepcion)
            Loop
        End If
    End Sub
End Class

