Imports LockheedMartin.Prepar3D.SimConnect
Imports System.Runtime.InteropServices
Public Class C_SDK_PMDG
    Public Event E_Estado(ByVal Estado As Integer, Mensaje As String)
    Public Event E_Recepcion(ByVal Parametro As String, Valor As String)
    Public Modulos As New List(Of String)

    Dim Estado As Integer = 0
    Dim Mensaje As String = ""
    Dim Control As C_PMDG.PMDG_NGX_Control
    Dim PMDG_NGX_DATA As C_PMDG.PMDG_NGX_Data
    Dim TablaDatos As New DataTable
    '    Dim SimConn As SimConnect


    Public Sub New()
        'Agregamos los campos a la tabla de los datos delos offsets
        TablaDatos.Columns.Add("Propiedad")
        TablaDatos.Columns.Add("Valor")
        For Each Campos In GetType(C_PMDG.PMDG_NGX_Data).GetFields()
            TablaDatos.Rows.Add(Campos.Name, "-")
        Next
    End Sub

    Public Sub Inicializar_Datos(SimConn As SimConnect)
        'SimConn = Sim_Coneccion
        'Set up Data connection
        'Add Handler's to get incomming Data
        AddHandler SimConn.OnRecvOpen, New SimConnect.RecvOpenEventHandler(AddressOf Rec_Conexion)
        AddHandler SimConn.OnRecvQuit, New SimConnect.RecvQuitEventHandler(AddressOf Rec_Quit)
        AddHandler SimConn.OnRecvException, New SimConnect.RecvExceptionEventHandler(AddressOf Rec_Error)

        'AddHandler SimConn.OnRecvSimobjectDataBytype, New SimConnect.RecvSimobjectDataBytypeEventHandler(AddressOf Rec_DataByte)
        AddHandler SimConn.OnRecvEvent, New SimConnect.RecvEventEventHandler(AddressOf Rec_Evento)
        AddHandler SimConn.OnRecvClientData, New SimConnect.RecvClientDataEventHandler(AddressOf Recibir_Datos)

        'Asociacion de Nombre con ID (Pos de Memoria)
        '                        NOMBRE PMDG_NGX_Data   , POS MEMORIA INICIAL           
        SimConn.MapClientDataNameToID(C_PMDG.PMDG_NGX_DATA_NAME, C_PMDG.PMDGIDs.PMDG_NGX_DATA_ID)
        'Agrega el offset y tamaño en bytes a la definicion de datos (Pos memoria de la def de datos = ID+1
        '                            'POS MEMORIA de la def de datos   ,offset, tamaño o tipo               
        SimConn.AddToClientDataDefinition(C_PMDG.PMDGIDs.PMDG_NGX_DATA_DEFINITION, 0, Marshal.SizeOf(PMDG_NGX_DATA), 0, 0)
        'Registrar estructura
        '                recepcion datos simconn        , Estructura          POS MEMO Definicion de datos (Estructura)
        SimConn.RegisterStruct(Of SIMCONNECT_RECV_CLIENT_DATA, C_PMDG.PMDG_NGX_Data)(C_PMDG.PMDGIDs.PMDG_NGX_DATA_DEFINITION)
        'Requisito de recepcion de datos en area creada por otro cliente (PMDG)
        '                    Pos memo inicial (data ID)   , Data Req ID enum                 ,POS MEMO def datos                    , periodo de envio, start, intervalo,
        SimConn.RequestClientData(C_PMDG.PMDGIDs.PMDG_NGX_DATA_ID, C_PMDG.Data_Request_ID.DATA_REQUEST, C_PMDG.PMDGIDs.PMDG_NGX_DATA_DEFINITION, SIMCONNECT_CLIENT_DATA_PERIOD.ON_SET, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0)
    End Sub
    Public Sub Inicializar_Control(SimConn As SimConnect)
        'Set up Control connection
        Control.Event = 0
        Control.Parameter = 0
        SimConn.MapClientDataNameToID(C_PMDG.PMDG_NGX_CONTROL_NAME, C_PMDG.PMDGIDs.PMDG_NGX_CONTROL_ID)
        SimConn.AddToClientDataDefinition(C_PMDG.PMDGIDs.PMDG_NGX_CONTROL_DEFINITION, 0, Marshal.SizeOf(Control), 0, 0)
        SimConn.RequestClientData(C_PMDG.PMDGIDs.PMDG_NGX_CONTROL_ID, C_PMDG.Data_Request_ID.CONTROL_REQUEST, C_PMDG.PMDGIDs.PMDG_NGX_CONTROL_DEFINITION, SIMCONNECT_CLIENT_DATA_PERIOD.ON_SET, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0)
    End Sub
    Private Sub Rec_Conexion(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_OPEN)
        Estado = 2
        Mensaje = "Conectado"
        RaiseEvent E_Estado(Estado, Mensaje)
    End Sub
    Private Sub Rec_Quit(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_QUIT)
        Estado = 0
        Mensaje = "Desconectado por el Servidor"
        RaiseEvent E_Estado(Estado, Mensaje)
    End Sub
    Private Sub Rec_Error(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_EXCEPTION)
        Estado = 3
        Mensaje = "Error, Cod:" & data.dwException.ToString & " Index:" & data.dwIndex
        RaiseEvent E_Estado(Estado, Mensaje)
    End Sub
    Private Sub Rec_DataByte(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE)

    End Sub
    Private Sub Rec_Evento(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_EVENT)
        'DisplayText("Event:" & data.uEventID.ToString, "info", 10)
    End Sub
    Private Sub Recibir_Datos(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_CLIENT_DATA)
        Select Case data.dwRequestID
            Case C_PMDG.Data_Request_ID.DATA_REQUEST
                Dim Datos As C_PMDG.PMDG_NGX_Data = DirectCast(data.dwData(0), C_PMDG.PMDG_NGX_Data)
                Dim TipoEstruc = GetType(C_PMDG.PMDG_NGX_Data)
                Dim Campos = TipoEstruc.GetFields()
                Dim ModuloLeido As String
                Dim PrevioValor As String
                Dim NuevoValor As String
                'Add recived Data to DataTable 
                For I As Integer = 0 To Campos.Length - 1
                    ModuloLeido = TablaDatos.Rows(I)(0)
                    'revisamos si es un elemento aceptado
                    If ValidarEnvio(ModuloLeido) Then
                        NuevoValor = Campos(I).GetValue(Datos)
                        PrevioValor = TablaDatos.Rows(I)(1).ToString
                        'revisamos si cambio el valor
                        If PrevioValor <> NuevoValor Then
                            TablaDatos.Rows(I)(1) = NuevoValor
                            'enviamos los datos
                            RaiseEvent E_Recepcion(ModuloLeido, NuevoValor)
                        End If
                    End If
                Next

                'DisplayText("DataConnection Data recived", "debug", 10)
            Case C_PMDG.Data_Request_ID.CONTROL_REQUEST
                'DisplayText("ControlConnection Data recived", "debug", 10)
            Case Else
                'DisplayText("Unknown Request ID |DwRId: " & data.dwRequestID, "debug", 5)
        End Select
    End Sub
    Private Function ValidarEnvio(Elemento As String) As Boolean
        Dim ElementoParcial As String
        ElementoParcial = Elemento.ToString.Substring(0, 4)
        For Each Valor In Modulos
            If Valor = ElementoParcial Then
                Return True
                Exit For
            End If
        Next Valor
        Return False
    End Function
End Class
