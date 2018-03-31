Imports System.Threading
Public Class C_AnalizadorV3
    Dim C_ColaEntrada As New Queue()

    Dim SECUENCIA_ENVIO_SOCKET As Integer = 0
    Dim SECUENCIA_ENVIO_SERIE1 As Integer = 0
    Dim SECUENCIA_ENVIO_SERIE2 As Integer = 0

    Dim _ComSim_Salida As C_ComSim
    Dim _Serie1_Salida As C_PuertoSerie
    Dim _Serie2_Salida As C_PuertoSerie

    Public Sub Iniciar(Sim_Salida As C_ComSim, Serie1_Salida As C_PuertoSerie, Serie2_Salida As C_PuertoSerie)
        _ComSim_Salida = Sim_Salida
        _Serie1_Salida = Serie1_Salida
        _Serie2_Salida = Serie2_Salida
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
            'dormir 10 ms parametro que se deberia configurar
            Thread.Sleep(10)
            Bloqueo = False
        Loop
    End Sub
    Private Sub Analizar(Datos As String, Origen As String) 'Aqui entra un comando unico
        Dim Comando_Estructura As EstructuraComando
        'Dim Analisis As EstructuraAnalisis
        Select Case Origen
            ' ORIGEN SERVIDOR
            Case "S"
                'SIN CONTROL, YA QUE LO RECIBE ESTE MISMO SOFTWARE
                Comando_Estructura = Almacenar_Comando(Datos)
                Call Sender(Comando_Estructura)

        End Select
    End Sub
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
                _Serie1_Salida.Encolar(Paquete)
            Case "2"
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE2)
                'Enviamos el comando
                _Serie2_Salida.Encolar(Paquete)
            Case "0"
                'Enviamos el comando
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE1)
                _Serie1_Salida.Encolar(Paquete)
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SERIE2)
                _Serie2_Salida.Encolar(Paquete)
            Case "S"
                'Enviamos el comando
                Paquete = Armar_SenderV2(Comando, SECUENCIA_ENVIO_SOCKET)
                _ComSim_Salida.EnviarDatos(Paquete)
                'Socket_Salida.Encolar(Paquete)
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

End Class
