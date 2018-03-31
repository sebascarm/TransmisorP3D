Imports System.Threading
Public Class C_Logg
    Public Delegate Sub MensajeDelegado(texto As String, color As Integer, texto2 As String, color2 As Integer, C_IdLogTex As String, Rich_Nombre As String)
    Public Event Mensaje As MensajeDelegado
    Dim C_Cadena As String
    Dim C_IDlog As Integer
    Dim C_IdLogTex As String
    Dim C_RichText As RichTextBox
    Dim C_ColaEntrada As New Queue()
    Dim BloqueoEscritura As Boolean = False
    Public Sub New(RichText As RichTextBox)   'constructor
        ' R console.WriteLine("Creando Log " & RichText.Name)
        C_RichText = RichText
        'Creamos proceso de recepcion
        Dim Proceso_Recepcion_Log As New Thread(AddressOf Proceso_LeerCola) With {
            .IsBackground = True}
        Proceso_Recepcion_Log.Start()
    End Sub
    Public Sub Encolar(Texto1 As String, Optional Color1 As Integer = 0, Optional Texto2 As String = "", Optional Color2 As Integer = 0)
        Dim Texto As String
        Texto = "'" & Texto1 & "','" & Color1 & "','" & Texto2 & "','" & Color2 & "'"
        C_ColaEntrada.Enqueue(Texto)
    End Sub
    Private Sub Proceso_LeerCola()
        'Este proceso se encuentra leyendo elementos en cola para enviar
        Dim Bloqueo As Boolean = False
        Dim CantidadCola As Integer
        Dim Datos As String
        Dim Text1 As String = ""
        Dim Color1 As String = ""
        Dim Text2 As String = ""
        Dim Color2 As String = ""
        'Dim Escritura As New BinaryWriter(C_Stream)
        Do
            If Bloqueo = False Then
                Bloqueo = True
                CantidadCola = C_ColaEntrada.Count
                If CantidadCola > 0 Then
                    Try
                        ' R console.WriteLine("cantidad en cola LOG: " & CantidadCola)
                        Datos = CStr(C_ColaEntrada.Dequeue)
                        Desencolar(Datos, Text1, Color1, Text2, Color2)
                        If Color1 = "" Then Color1 = "0"
                        If Color2 = "" Then Color2 = "0"
                        Call Escribir(Text1, CInt(Color1), Text2, CInt(Color2))
                        ' R console.WriteLine("Log Escribir: " & Datos)
                    Catch
                        Select Case Err.Number
                            Case 13
                                Console.WriteLine("LOG - ERROR (conversion a int) RICH:" & C_RichText.Name & " COLOR1: " & Color1 & " COLOR2: " & Color2)
                            Case 5
                                Console.WriteLine("LOG Warning: Cola Vacía")
                            Case Else
                                Console.WriteLine("LOG - Error: " & Err.Number & " " & Err.Description)
                        End Select
                    End Try
                End If
            End If
            'dormir 10 ms
            Thread.Sleep(10)
            Bloqueo = False
        Loop
    End Sub
    Private Sub Escribir(Texto As String, Optional Color As Integer = 0, Optional Texto2 As String = "", Optional Color2 As Integer = 0)
        Dim Cadena As String
        Dim Tipo As String = ""

        'REVISAMOS SI tenemos que enviar el log al remoto
        If (SOCK_MEDIADOR.Estado = 2) And (SOCK_MEDIADOR.Mediador = True) Then
            Select Case C_RichText.Name
                Case "RiEstado" : Tipo = "LOGGENERAL"
                Case "RiBufferSerie1" : Tipo = "LOGSERIE1"
                Case "RiBufferSerie2" : Tipo = "LOGSERIE2"
                Case "RiBufferSocket" : Tipo = "LOGSOCKET"
            End Select
            Cadena = "TIPOLOG='" & Tipo & "', TEXTO1='" & Texto & "', COLOR1='" & Color & "', TEXTO2='" & Texto2 & "', COLOR2='" & Color2 & "'[FIN]"
            ' R console.WriteLine(Cadena)
            Call SOCK_MEDIADOR.Encolar(Cadena)
        End If

        'Dim RichLong As Integer
        C_IDlog = C_IDlog + 1
        If C_IDlog = 100 Then C_IDlog = 0
        If C_IDlog < 10 Then
            C_IdLogTex = "0" & C_IDlog
        Else
            C_IdLogTex = CStr(C_IDlog)
        End If
        'Console.WriteLine("RI NAME: " & C_RichText.Name)
        Call Escribe(Texto, Color, Texto2, Color2, C_IdLogTex, C_RichText.Name)

    End Sub
    Protected Sub Escribe(texto As String, color As Integer, texto2 As String, color2 As Integer, C_IdLogTex As String, Rich_Nombre As String)
        'Console.WriteLine("RAISE: " & Rich_Nombre)
        RaiseEvent Mensaje(texto, color, texto2, color2, C_IdLogTex, Rich_Nombre)
    End Sub

End Class


