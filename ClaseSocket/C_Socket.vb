Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Public Class C_Sockets
    Public Event E_Estado(ByVal Estado As Integer)
    Public Event E_Recepcion(ByVal Datos_Recepcion As String)

    Public Estado As Integer
    'Public Estado As Integer = 0 '0 - desconectado 1 - conectando 2- conectado 3- Error
    Public Mensaje As String = ""
    Public Datos_Recepcion As String = ""
    Dim IP As String
    Dim Port As Integer
    Dim Cliente As Boolean = False 'cliente o servidor
    Dim DELAY_RECEPCION As Integer
    Dim DELAY_ENVIO As Integer
    'variables socket
    Dim VC_ColaEnvio As New Queue()
    Dim VC_TCPClient As New System.Net.Sockets.TcpClient()
    Dim VC_TCPServer As TcpListener
    Dim VC_Stream As NetworkStream
    Dim BufferRecepcion As String
    Dim FinRecepcion As String
    Public Sub Conectar(IP As String, Port As Integer, Retardo_Escucha As Integer, Retardo_Envio As Integer, Optional FindeRecepcion As String = "")
        Me.IP = IP
        Me.Port = Port
        Me.Cliente = True
        Me.DELAY_RECEPCION = Retardo_Escucha
        Me.DELAY_ENVIO = Retardo_Envio
        Me.FinRecepcion = FindeRecepcion
        'Creamos proceso de conexion en background para no trabar la ejecucion
        Dim Proc_Conectar As New Thread(AddressOf Proceso_Conectar) With {
            .IsBackground = True}
        Proc_Conectar.Start()
    End Sub
    Public Sub Escuchar(IP As String, Port As Integer, Retardo_Escucha As Integer, Retardo_Envio As Integer, Optional FindeRecepcion As String = "")
        Me.IP = IP
        Me.Port = Port
        Me.Cliente = False
        Me.DELAY_RECEPCION = Retardo_Escucha
        Me.DELAY_ENVIO = Retardo_Envio
        Me.FinRecepcion = FindeRecepcion
        'Creamos proceso de conexion en background para no trabar la ejecucion
        If Estado = 1 Then
            Mensaje = "El equiop ya se encuentra en Escucha"
        Else
            Dim Proc_Escuchar As New Thread(AddressOf Proceso_Escuchar) With {
            .IsBackground = True}
            Proc_Escuchar.Start()
        End If
    End Sub
    Public Sub Desconectar()
        If Estado <> 0 Then
            Estado = 0
            VC_TCPClient.Close()
            If Cliente = False Then
                VC_TCPServer.Stop()
            End If
            'RaiseEvent E_Estado(Estado)
        End If
    End Sub
    Private Sub Proceso_Conectar()
        Try
            'Realizamos la conexion
            Estado = 1
            Mensaje = "CONECTANDO"
            RaiseEvent E_Estado(Estado)
            'lo creamos en el momonto por si lo hemos cerrado
            VC_TCPClient = New System.Net.Sockets.TcpClient()
            VC_TCPClient.Connect(IP, Port)
            'conexion establecida en este punt
            Estado = 2
            Mensaje = "CONECTADO"
            RaiseEvent E_Estado(Estado)
            VC_Stream = VC_TCPClient.GetStream()
            'Creamos proceso de recepcion
            Dim Proc_Receptor As New Thread(AddressOf Proceso_Receptor) With {
                .IsBackground = True}
            Proc_Receptor.Start()
            'Creamos proceso de envio
            Dim Proc_Enviador As New Thread(AddressOf Proceso_Enviador) With {
                .IsBackground = True}
            Proc_Enviador.Start()
        Catch
            Select Case Err.Number
                Case 5
                    Mensaje = "El equipo remoto no se encuentra escuchando"
                    Estado = 0
                    RaiseEvent E_Estado(Estado)
                Case Else
                    Mensaje = "Error en conexion: " & Err.Number & " " & Err.Description
                    Estado = 3
                    RaiseEvent E_Estado(Estado)
            End Select
        End Try
    End Sub
    Private Sub Proceso_Escuchar()
        Dim Direccion_IP As IPAddress = IPAddress.Parse(IP)
        Try
            'Realizamos la conexion
            Estado = 1
            RaiseEvent E_Estado(Estado)
            VC_TCPServer = New TcpListener(Direccion_IP, Port)
            'Iniciamos la escucha
            VC_TCPServer.Start()
            'Proceso bloqueado hasta que entre una conexion
            VC_TCPClient = VC_TCPServer.AcceptTcpClient
            VC_Stream = VC_TCPClient.GetStream()
            Mensaje = "Conexion Establecida"
            'esperamos para que se emita el log en local
            Thread.Sleep(100)
            'Estando en conectado
            Estado = 2
            RaiseEvent E_Estado(Estado)
            'Iniciamos proceso de enviador
            Dim Proc_Enviador = New Thread(AddressOf Proceso_Enviador) With {
                .IsBackground = True}
            Proc_Enviador.Start()
            'Iniciamos proceso de Recepcion
            Dim Proc_Receptor = New Thread(AddressOf Proceso_Receptor) With {
                .IsBackground = True}
            Proc_Receptor.Start()
        Catch
            Select Case Err.Number
                Case 5
                    Mensaje = "Conexion Cerrada"
                    Estado = 0
                    RaiseEvent E_Estado(Estado)
                Case Else
                    Estado = 3
                    Mensaje = "Socket Error: " & Err.Number & " " & Err.Description
                    RaiseEvent E_Estado(Estado)
            End Select
        End Try
    End Sub
    Private Sub Proceso_Receptor() 'sirve para el cliente y el servidor
        'Dim Lectura As New BinaryReader(C_Stream)
        Dim ByteLectura(10240) As Byte
        Dim Recepcion As String
        'debido a que el tamano en windows 10 es diferente lo especificamos
        VC_TCPClient.ReceiveBufferSize = 10240
        While Estado = 2
            Try
                'la lectura es bloqueante
                VC_Stream.Read(ByteLectura, 0, CInt(VC_TCPClient.ReceiveBufferSize))
                Recepcion = (System.Text.Encoding.UTF8.GetString(ByteLectura))
                'eliminamos caracteres nulos
                Recepcion = Recepcion.Replace(vbNullChar, "")
                ' R console.WriteLine("Remoto_Input: " & Recepcion)
                Console.WriteLine(Recepcion)
                Array.Clear(ByteLectura, ByteLectura.GetLowerBound(0), ByteLectura.Length)
                'ANALISIS DE RECEPCION
                If Recepcion = "" Then 'posible cierre de conexion del mediador
                    VC_TCPClient.Close()
                    Mensaje = "Conexion Cerrada"
                    Estado = 3
                    If Cliente = False Then
                        VC_TCPServer.Stop()
                    End If
                    RaiseEvent E_Estado(Estado)
                End If
                If Recepcion.Length = 1 Then
                    ' R console.WriteLine("Recepcion BASURA: " & Recepcion)
                    Recepcion = ""
                End If
                If Recepcion <> "" Then
                    Datos_Recepcion = Recepcion
                    'Analisis
                    SubAnalisisRecepcion(Datos_Recepcion)
                End If
                'dormir 10 ms
                Thread.Sleep(DELAY_RECEPCION)
            Catch
                Select Case Err.Number
                    Case 57
                        VC_TCPClient.Close()
                        Mensaje = "Conexion Cerrada"
                        Estado = 0
                        If Cliente = False Then
                            VC_TCPServer.Stop()
                        End If
                        RaiseEvent E_Estado(Estado)
                    Case Else
                        Mensaje = "Error Socket: " & Err.Number & " " & Err.Description
                        Estado = 3
                        RaiseEvent E_Estado(Estado)
                End Select
            End Try
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
    Public Sub Encolar(Datos As String)
        VC_ColaEnvio.Enqueue(Datos)
    End Sub
    Private Sub Proceso_Enviador()
        'Este proceso se encuentra leyendo elementos en cola para enviar
        Dim Bloqueo As Boolean = False
        Dim CantidadCola As Integer
        Dim DatosEnviar As String
        Dim Encode As Encoding = Encoding.UTF8
        Dim Escritura As New BinaryWriter(VC_Stream, Encode)
        Dim Longitud As Integer
        While Estado = 2
            If Bloqueo = False Then
                Bloqueo = True
                CantidadCola = VC_ColaEnvio.Count
                If CantidadCola > 0 Then
                    Try
                        DatosEnviar = CStr(VC_ColaEnvio.Dequeue)
                        Longitud = DatosEnviar.Length
                        'esta modificacion hace que no se emita basuta
                        Dim ByteEsc() As Byte = System.Text.Encoding.UTF8.GetBytes(DatosEnviar)
                        Escritura.Write(ByteEsc, 0, ByteEsc.Length)
                    Catch
                        Select Case Err.Number
                            Case 5
                                Mensaje = "Socket Warning: Cola Vacía"
                            Case Else
                                Mensaje = "Socket - Error: " & Err.Number & " " & Err.Description
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
End Class
