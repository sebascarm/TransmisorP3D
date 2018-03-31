Imports LockheedMartin.Prepar3D.SimConnect
Imports ClaseSDK_PMDG
Imports System.Runtime.InteropServices
Public Class C_SDK
    Public Estado As Integer = 0
    Public Mensaje As String = ""
    ''' <summary>
    ''' Estado de la conexion: 0-Desconectado 1-Conectando 2-Conectado 3-Error
    ''' </summary>
    Public Event E_Estado(ByVal Estado As Integer)
    Public Event E_Recepcion(ByVal Parametro As String, Valor As String)
    'para que no existan mas de una instancia del simconnect
    Shared SimConnPMDG As SimConnect
    Shared SimConnSIMM As SimConnect
    'Modulos validos
    Structure S_ModulosValidos
        Dim MCP As Boolean
        Dim THR As Boolean
        Dim MIP As Boolean
        Dim FIR As Boolean
        Dim YOK As Boolean
    End Structure
    Public ModulosValidos As S_ModulosValidos
    'vaiables locales
    Dim Parametro As String
    Dim Valor As String
    Dim Modulos As New List(Of String)
    Dim Control As C_PMDG.PMDG_NGX_Control
    Dim Pmdg_NGX_data As C_PMDG.PMDG_NGX_Data
    'Dim TablaControl As New DataTable
    'Dim TablaDatos As New DataTable
    Dim WM_USER_SIMCONNECT As Integer = &H402

    Dim C_PMDG As C_SDK_PMDG
    Dim C_SIMM As C_SDK_SIMCONN

    Public Sub New()
        'clase PMDG
        C_PMDG = New C_SDK_PMDG 'SE CREA LA TABLA DE DATOS
        C_SIMM = New C_SDK_SIMCONN
    End Sub

    ''' <summary>
    ''' Conexion: Requiere enviar el parametro Handle del formulario
    ''' </summary>
    ''' <param name="Handle">Usar Me.Handle del formulario que envia la conexión</param>
    Public Sub Conectar(Handle As IntPtr)
        'Conexion
        If (SimConnPMDG Is Nothing) And (SimConnSIMM Is Nothing) Then
            Try
                SimConnPMDG = New SimConnect("Cliente_PMDG", Handle, WM_USER_SIMCONNECT, Nothing, 0)
                SimConnSIMM = New SimConnect("Cliente_SIMM", Handle, WM_USER_SIMCONNECT, Nothing, 0)
                'ESCUCHAMOS LOS EVENTOS, CAMBIO DE ESTADO Y REC DE DATOS
                AddHandler C_PMDG.E_Estado, AddressOf CambioEstado
                AddHandler C_PMDG.E_Recepcion, AddressOf Recepcion_Datos
                'de SIM enviamos al mismo modulo
                AddHandler C_SIMM.E_Recepcion, AddressOf Recepcion_Datos
                'INICIALIZAMOS LOS COMPONENTES

                C_SIMM.Inicializar_Datos(SimConnSIMM)

                C_PMDG.Inicializar_Datos(SimConnPMDG)
                C_PMDG.Inicializar_Control(SimConnPMDG)


                Estado = 1
                RaiseEvent E_Estado(Estado)
            Catch
                Mensaje = Replace("Error: " & Err.Number & " " & Err.Description, "'", "")
                Estado = 0
                RaiseEvent E_Estado(Estado)
            End Try
        Else
            Estado = 3
            Mensaje = "El cliente ya se encuentra conectado"
            RaiseEvent E_Estado(Estado)
            Desconectar()
        End If
    End Sub
    Public Sub Desconectar()
        If SimConnPMDG IsNot Nothing Then
            SimConnPMDG.Dispose()
            SimConnPMDG = Nothing
            Estado = 0
            Mensaje = "Desconectado por aplicacion"
            RaiseEvent E_Estado(Estado)

            If SimConnSIMM IsNot Nothing Then
                SimConnPMDG.Dispose()
                SimConnPMDG = Nothing
            End If
        End If
    End Sub
    Public Sub ActualizarModulos()
        Modulos.Clear()
        If ModulosValidos.THR Then Modulos.Add("PED_")
        If ModulosValidos.MIP Then Modulos.Add("MAIN")
        If ModulosValidos.MCP Then Modulos.Add("MCP_")
        If ModulosValidos.FIR Then Modulos.Add("FIRE")
        'enviamos los modulos validos
        C_PMDG.Modulos.Clear()
        C_PMDG.Modulos.AddRange(Modulos)
    End Sub
    ''' <summary>
    ''' Metodo para recibir los datos cuando hay un evento en el formulario origen DefWndProc 
    ''' </summary>
    Public Sub Recibir()
        If SimConnPMDG IsNot Nothing Then
            SimConnPMDG.ReceiveMessage()
        End If
        If SimConnSIMM IsNot Nothing Then
            SimConnSIMM.ReceiveMessage()
        End If
    End Sub
    Public Sub CambioEstado(ByVal EstadoReciv As Integer, MensajeReciv As String)
        'transmitir los cambios de estados recibidos
        Me.Estado = EstadoReciv
        Me.Mensaje = MensajeReciv
        RaiseEvent E_Estado(Estado)
    End Sub
    Public Sub Recepcion_Datos(ByVal ParametroRec As String, ValorRec As String)
        'transmitir los datos recibidos
        Me.Parametro = ParametroRec
        Me.Valor = ValorRec
        RaiseEvent E_Recepcion(Parametro, Valor)
    End Sub

End Class

