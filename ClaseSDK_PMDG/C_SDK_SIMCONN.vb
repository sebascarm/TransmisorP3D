Imports LockheedMartin.Prepar3D.SimConnect
Class C_SDK_SIMCONN
    Public ValoresTHR As StrTHR

    Public Event E_Recepcion(ByVal Parametro As String, Valor As String)


    Public Sub Inicializar_Datos(SimConn As SimConnect)
        Dim ElementoSim As String
        'Dim Pos As Integer = 0
        Dim TiposEstruc = GetType(StrTHR)
        Dim Campos = TiposEstruc.GetFields()
        For Pos As Integer = 0 To Campos.Length - 1
            ElementoSim = Campos(Pos).Name.ToString
            ElementoSim = Convertir(ElementoSim)
            Dim TipoDato As String
            TipoDato = Campos(Pos).FieldType.Name.ToString
            Select Case TipoDato
                Case "Single"
                    SimConn.AddToDataDefinition(StrDefinicion.StrTHR, ElementoSim, "", SFloat, 0, Pos)
                Case "String"
                    SimConn.AddToDataDefinition(StrDefinicion.StrTHR, ElementoSim, "", SString, 0, Pos)
                Case "Boolean"
                    SimConn.AddToDataDefinition(StrDefinicion.StrTHR, ElementoSim, "", SInt, 0, Pos)
            End Select
        Next
        'Registrar estructura
        SimConn.RegisterDataDefineStruct(Of StrTHR)(StrDefinicion.StrTHR)
        ' catch a simobject data request 
        AddHandler SimConn.OnRecvSimobjectData, New SimConnect.RecvSimobjectDataEventHandler(AddressOf S_Rec_DataByte)
        'tipo de envio (cuando hay cambios)
        SimConn.RequestDataOnSimObject(DATA_REQUESTS.REQUEST_1, StrDefinicion.StrTHR, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SIM_FRAME, SIMCONNECT_DATA_REQUEST_FLAG.CHANGED, 0, 0, 0)

    End Sub
    Private Sub S_Rec_DataByte(ByVal sender As SimConnect, ByVal data As SIMCONNECT_RECV_SIMOBJECT_DATA)
        Select Case data.dwRequestID
            Case DATA_REQUESTS.REQUEST_1
                ' Cast the data input to the correct structure type 
                Dim DatosNuevos As StrTHR = CType(data.dwData(0), StrTHR)
                Dim Propiedad As String
                Dim ValorAnt
                Dim ValorNuevo

                Dim TiposEstruc = GetType(StrTHR)
                Dim Campos = TiposEstruc.GetFields()

                For Pos As Integer = 0 To Campos.Length - 1
                    ValorAnt = Campos(Pos).GetValue(ValoresTHR)
                    ValorNuevo = Campos(Pos).GetValue(DatosNuevos)
                    If ValorAnt <> ValorNuevo Then
                        Propiedad = Campos(Pos).Name.ToString
                        'Debug.Print(Propiedad)
                        'Debug.Print(ValorNuevo)
                        'enviamos los datos
                        Dim Val As Single = CType(ValorNuevo, Single)
                        Val = Math.Round(Val, 2)
                        RaiseEvent E_Recepcion(Propiedad, Val.ToString)
                    End If
                Next
                ValoresTHR = DatosNuevos

            Case Else
                Debug.Print("Unknown request ID: " + data.dwRequestID.ToString())
        End Select
    End Sub
    Private Function CONV(ByVal VALOR As Double) As Double
        Dim Resultado
        Resultado = ((VALOR * (17 - 4)) + 4)
        Return Resultado
    End Function
    Private Function Convertir(ByVal Valor As String) As String
        Dim Resultado As String
        Resultado = Valor.Replace("__", ":")
        Resultado = Resultado.Replace("_", " ")
        Return Resultado
    End Function
End Class


