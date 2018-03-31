Module Equipo
    Public Delegate Sub MensajeDelegado(Elemento_Etiqueta As String, Color As Color)
    Public Event Mensaje As MensajeDelegado
    Public Delegate Sub MensajeDelegadoLinea(Elemento_Nombre As String, Estilo As BorderStyle)
    Public Event MensajeLinea As MensajeDelegadoLinea
    Public Sub Inciar_Equipo()
        Call Dibujar_Equipo("MEDIADOR", True)

    End Sub
    Public Sub Dibujar_Mediador(Activo As Boolean)
        'DIBUJA MEDIADOR O REMOTO (EL EQUIPO ES UNO DE LOS 2)
        If Activo Then
            Call Dibujar_Equipo("MEDIADOR", True)
            Call Dibujar_Equipo("REMOTE", False)
        Else
            Call Dibujar_Equipo("MEDIADOR", False)
            Call Dibujar_Equipo("REMOTE", True)
        End If
    End Sub
    Public Sub Dibujar_ConexionconMediador(Activo As Boolean)
        Call Dibujar_Equipo("MEDIADOR", Activo)
        Call Dibujar_Linea("MEDIADOR-REMOTO", Activo)
    End Sub
    Public Sub Dibujar_ConexionconRemoto(Activo As Boolean)
        Call Dibujar_Equipo("REMOTE", Activo)
        Call Dibujar_Linea("MEDIADOR-REMOTO", Activo)
    End Sub
    Public Sub Dibujar_MediadorSimulador(Activo As Boolean)
        'Activo = dibuja o borra segun el estado
        Call Dibujar_Equipo("SIMULADOR", Activo)
        Call Dibujar_Linea("MEDIADOR-SIMULADOR", Activo)
        'Enviar a remoto
        Call EnviarDibujo("Dibujar_MediadorSimulador", Activo)
    End Sub
    Public Sub Dibujar_MediadorServidor(Activo As Boolean)
        Call Dibujar_Equipo("SERVIDOR", Activo)
        Call Dibujar_Linea("MEDIADOR-SERVIDOR", Activo)
        Call EnviarDibujo("Dibujar_MediadorServidor", Activo)
    End Sub
    Public Sub Dibujar_MediadorArduino(Activo As Boolean)
        Call Dibujar_Equipo("ARDUINO", Activo)
        Call Dibujar_Linea("MEDIADOR-ARDUINO", Activo)
        Call EnviarDibujo("Dibujar_MediadorArduino", Activo)
    End Sub
    Public Sub Dibujar_MediadorFeudrino(Activo As Boolean)
        Call Dibujar_Equipo("FEUDRINO", Activo)
        Call Dibujar_Linea("MEDIADOR-FEUDRINO", Activo)
        Call EnviarDibujo("Dibujar_MediadorFeudrino", Activo)
    End Sub
    'DISPLAYS
    Public Sub Dibujar_MediadorDisplayMed(Activo As Boolean)
        Call Dibujar_Equipo("DISPLAYMED", Activo)
        Call Dibujar_Linea("MEDIADOR-DISPLAYMED", Activo)
        Call EnviarDibujo("Dibujar_MediadorDisplayMed", Activo)
    End Sub
    Public Sub Dibujar_MediadorDisplay1(Activo As Boolean)
        Call Dibujar_Equipo("DISPLAY1", Activo)
        Call Dibujar_Linea("MEDIADOR-DISPLAY1", Activo)
        Call EnviarDibujo("Dibujar_MediadorDisplay1", Activo)
    End Sub
    Public Sub Dibujar_MediadorDisplay2(Activo As Boolean)
        Call Dibujar_Equipo("DISPLAY2", Activo)
        Call Dibujar_Linea("MEDIADOR-DISPLAY2", Activo)
        Call EnviarDibujo("Dibujar_MediadorDisplay2", Activo)
    End Sub

    Public Sub EnviarDibujo(Sender As String, Activo As Boolean)
        'REVISAMOS SI ES VIABLE ENVIAR AL EQUIPO REMOTO
        If (SOCK_MEDIADOR.Estado = 2) And (SOCK_MEDIADOR.Mediador = True) Then
            Dim StrActivo As String
            If Activo Then
                StrActivo = "1"
            Else
                StrActivo = "0"
            End If
            'Enviar al remoto los dibujos
            Call SOCK_MEDIADOR.Encolar("TIPOLOG='DIBUJAR', TEXTO1='" & Sender & "', COLOR1='" & StrActivo & "'[FIN]")
        End If
    End Sub
    Private Sub Dibujar_Equipo(Equipo As String, Estado As Boolean)
        Dim Color As Color
        Select Case Estado
            Case True
                Color = Color.Green
            Case False
                Color = Color.Silver
        End Select
        Escribe(Equipo, Color)
    End Sub
    Private Sub Dibujar_Linea(Linea As String, Estado As Boolean)
        Dim Estilo As BorderStyle
        Select Case Estado
            Case True
                Estilo = CType(Drawing2D.DashStyle.Solid, BorderStyle)
            Case False
                Estilo = CType(Drawing2D.DashStyle.Dot, BorderStyle)
        End Select
        EscribeLinea(Linea, Estilo)
    End Sub
    Private Sub Escribe(Elemento_Etiqueta As String, Color As Color)
        RaiseEvent Mensaje(Elemento_Etiqueta, Color)
    End Sub
    Private Sub EscribeLinea(Elemento_Nombre As String, Estilo As BorderStyle)
        RaiseEvent MensajeLinea(Elemento_Nombre, Estilo)
    End Sub
    Public Sub ObtenetPantallaMediador()
        Dim CantPantallas As Integer
        Dim Resolucion As String
        'borrar todas las pantallas
        Dibujar_MediadorDisplayMed(False)
        Dibujar_MediadorDisplay1(False)
        Dibujar_MediadorDisplay2(False)

        CantPantallas = Screen.AllScreens.Count

        For Pant = 0 To CantPantallas - 1
            Resolucion = CStr(Screen.AllScreens(Pant).Bounds.Width) & " x " & CStr(Screen.AllScreens(Pant).Bounds.Height)
            'CONFIGURACION ACEPTADA PARA MEDIADOR
            Select Case Pant
                Case 0
                    LOGGENERAL.Encolar("PANTALLA MED: " & Resolucion, VERDE_)
                    Dibujar_MediadorDisplayMed(True)
                Case = 1
                    If Resolucion = "1024 x 768" Then
                        LOGGENERAL.Encolar("PANTALLA 1: " & Resolucion, VERDE_)
                        Dibujar_MediadorDisplay1(True)
                    Else
                        LOGGENERAL.Encolar("PANTALLA 1: " & Resolucion, ROJO_)
                    End If
                Case = 2
                    If Resolucion = "1024 x 768" Then
                        LOGGENERAL.Encolar("PANTALLA 2: " & Resolucion, VERDE_)
                        Dibujar_MediadorDisplay2(True)
                    Else
                        LOGGENERAL.Encolar("PANTALLA 2: " & Resolucion, ROJO_)
                    End If
            End Select
        Next

    End Sub
End Module
