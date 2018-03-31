Imports System.Threading
Public Class ClienteFSX
    Private Sub CargarConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarConfiguraciónToolStripMenuItem.Click
        Call LeerConfiguracionConexion()
    End Sub
    Private Sub GuardarConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarConfiguraciónToolStripMenuItem.Click
        GuardarConfiguracionConexion()
    End Sub
    Private Sub PedirConfiguracónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedirConfiguracónToolStripMenuItem.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComandoMenu(sender)
        End If
    End Sub
    Private Sub EnviarConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarConfiguraciónToolStripMenuItem.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            'ejecuta el proceso directo de envio de configuracion, el mismo que realizaria el mediador
            PedidodeConfguracion()
        End If
    End Sub
    Private Sub Bot_ConectServidor_Click(sender As Object, e As EventArgs) Handles Bot_ConectServidor.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            ConectarServidor()
        End If
    End Sub
    Private Sub Bot_ConectSimulador_Click(sender As Object, e As EventArgs) Handles Bot_ConectSimulador.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            ConectarSimulador(Me.Handle)
        End If
    End Sub
    Private Sub Bot_DescSimulador_Click(sender As Object, e As EventArgs) Handles Bot_DescSimulador.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            Call DesconectarSimulador()
        End If
    End Sub
    Private Sub Bot_Placa1_Click(sender As Object, e As EventArgs) Handles Bot_Placa1.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            ConectarPlaca1()
        End If
    End Sub
    Private Sub Bot_Placa2_Click(sender As Object, e As EventArgs) Handles Bot_Placa2.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            ConectarPlaca2()
        End If
    End Sub
    Private Sub Placas_Desc_Click(sender As Object, e As EventArgs) Handles Placas_Desc.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            EnviarPlaca1("[M00]>1ENC_ALL__=0<")
            EnviarPlaca2("[M00]>2ENC_ALL__=0<")
            Thread.Sleep(200)
            Call DesconectarPlaca1()
            Call DesconectarPlaca2()
        End If
    End Sub
    Private Sub CoEncenderTH_Click(sender As Object, e As EventArgs) Handles CoEncenderTH.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            SIMCON.ModulosValidos.THR = True
            SIMCON.ActualizarModulos()
            'EnviaraSimulador(">SENC_THR__=1<")
        End If
    End Sub
    Private Sub CoEncenderMCP_Click(sender As Object, e As EventArgs) Handles CoEncenderMCP.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            SIMCON.ModulosValidos.MCP = True
            SIMCON.ActualizarModulos()
            'EnviaraSimulador(">SENC_MCP__=1<")
        End If
    End Sub
    Private Sub CoEncenderMIP_Click(sender As Object, e As EventArgs) Handles CoEncenderMIP.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            SIMCON.ModulosValidos.MIP = True
            SIMCON.ActualizarModulos()
            'EnviaraSimulador(">SENC_MIP__=1<")
        End If
    End Sub
    Private Sub CoEncenderYOK_Click(sender As Object, e As EventArgs) Handles CoEncenderYOK.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            SIMCON.ModulosValidos.yok = True
            SIMCON.ActualizarModulos()
            'EnviaraSimulador(">SENC_YOK__=1<")
        End If
    End Sub
    Private Sub CoEncenderFIR_Click(sender As Object, e As EventArgs) Handles CoEncenderFIR.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            SIMCON.ModulosValidos.FIR = True
            SIMCON.ActualizarModulos()
            'EnviaraSimulador(">SENC_FIR__=1<")
        End If
    End Sub
    Private Sub CoScreen_Click(sender As Object, e As EventArgs) Handles CoScreen.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            Call ObtenetPantallaMediador()
        End If
    End Sub
    Private Sub EncSimulador_Click(sender As Object, e As EventArgs) Handles EncSimulador.Click
        If (SOCK_MEDIADOR.Remoto) And (SOCK_MEDIADOR.Estado = 2) Then
            EnviarComando(sender)
        Else
            EnviaraServidor("ESTADO_SIMULADOR")
            'EnviaraServidor("ENCENDER_SIMULADOR")
        End If
    End Sub
    Private Sub ClienteFSX_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Reajustar_tamanos(RiEstado, Me)
        Reajustar_tamanos(RiBufferSerie1, Me)
        Reajustar_tamanos(RiBufferSerie2, Me)
        Reajustar_tamanos(RiBufferSocket, Me)
    End Sub
    Private Sub RadioMediador_CheckedChanged(sender As Object, e As EventArgs) Handles RadioMediador.CheckedChanged
        If RadioMediador.Checked Then
            Bot_Med_Conexion.Text = "Escuchar"
            Call Dibujar_Mediador(True)
        Else
            Bot_Med_Conexion.Text = "Conectar"
            Call Dibujar_Mediador(False)
        End If
    End Sub

    Private Sub Bot_Med_Conexion_Click(sender As Object, e As EventArgs) Handles Bot_Med_Conexion.Click
        Select Case RadioMediador.Checked
            Case True
                Call EscucharMediador()
            Case False
                Call ConectarMediador()
        End Select

    End Sub
    Private Sub Bot_Med_Desconexion_Click(sender As Object, e As EventArgs) Handles Bot_Med_Desconexion.Click
        Call DesconectarMediador()
    End Sub

    Private Sub TeHost_TextChanged(sender As Object, e As EventArgs) Handles TeHost.TextChanged
        IP = TeHost.Text
    End Sub

    Private Sub MostrarWarningsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarWarningsToolStripMenuItem.Click
        If MostrarWarningsToolStripMenuItem.Checked = False Then
            MostrarWarningsToolStripMenuItem.Checked = True
            VER_WARNING = True
        Else
            MostrarWarningsToolStripMenuItem.Checked = False
            VER_WARNING = False
        End If

    End Sub

    Private Sub LimpiarLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarLogsToolStripMenuItem.Click
        RiEstado.Text = ""
        RiBufferSerie1.Text = ""
        RiBufferSerie2.Text = ""
        RiBufferSocket.Text = ""

    End Sub
    Private Sub Bot_Env_Servidor_Click(sender As Object, e As EventArgs) Handles Bot_Env_Servidor.Click
        EnviaraSimulador(T_EnviarServidor.Text)
    End Sub
    Private Sub Bot_Env_Placa_Click(sender As Object, e As EventArgs) Handles Bot_Env_Placa.Click
        EnviarPlaca1(T_EnviarPlaca.Text)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EnviarPlaca2(T_EnviarPlaca.Text)
    End Sub
    'PROCESO INICIAL (ACA ARRANCA EL PROGRAMA)
    Private Sub ClienteFSX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Transmisor P3D V" & Application.ProductVersion
        CheckForIllegalCrossThreadCalls = False
        AddHandler Equipo.Mensaje, AddressOf Dibujar_Equipo
        AddHandler Equipo.MensajeLinea, AddressOf Dibujar_Linea
        Call Iniciar()
        AddHandler LOGGENERAL.Mensaje, AddressOf Recibir_Mensaje
        AddHandler LOGSERIE1.Mensaje, AddressOf Recibir_Mensaje
        AddHandler LOGSERIE2.Mensaje, AddressOf Recibir_Mensaje
        AddHandler LOGGSOCKET.Mensaje, AddressOf Recibir_Mensaje
        'REVISOR DE MEDIADOR AUTOMATICO
        If MEDIADOR_AUTO And RadioMediador.Checked Then
            Call EscucharMediador()
        End If
    End Sub
    Private Sub Recibir_Mensaje(texto As String, color As Integer, texto2 As String, color2 As Integer, C_IdLogTex As String, Rich_Nombre As String)
        Log_RichBox(texto, color, texto2, color2, C_IdLogTex, Rich_Nombre)
    End Sub
    'DELEGADOS
    Private Delegate Sub Delegado_TextBox(Texto As String, TextBox_Nombre As String)
    Private Delegate Sub Delegado_Log_RichBox(texto As String, color As Integer, texto2 As String, color2 As Integer, C_IdLogTex As String, Rich_Nombre As String) 'declaracion del Delegado
    Private Delegate Sub Delegado_Dibujar_Equipo(Elemento_Etiqueta As String, Color As Color)
    Private Delegate Sub Delegado_Dibujar_Linea(Elemento_Nombre As String, Estilo As BorderStyle)
    Private Sub Dibujar_Equipo(Elemento_Etiqueta As String, Color As Color)
        Dim Elemento As Label = Nothing
        Select Case Elemento_Etiqueta
            Case "MEDIADOR"
                Elemento = Me.LaMediador
            Case "REMOTE"
                Elemento = Me.LaRemote
            Case "SERVIDOR"
                Elemento = Me.LaServidor
            Case "SIMULADOR"
                Elemento = Me.LaSimulador
            Case "ARDUINO"
                Elemento = Me.LaArduino
            Case "FEUDRINO"
                Elemento = Me.LaFeudrino
                'DISPLAYS
            Case "DISPLAYMED"
                Elemento = Me.LaDisplayMed
            Case "DISPLAY1"
                Elemento = Me.LaDisplay1
            Case "DISPLAY2"
                Elemento = Me.LaDisplay2
            Case "DISPLAY3"
                Elemento = Me.LaDisplay3
            Case "DISPLAYSERV"
                Elemento = Me.LaDisplayServ
        End Select

        If Elemento.InvokeRequired Then 'Aqui vemos por quien ha sido invocado el listbox
            Dim d As New Delegado_Dibujar_Equipo(AddressOf Dibujar_Equipo)
            Invoke(d, New Object() {Elemento_Etiqueta, Color})
        Else
            Elemento.BackColor = Color
        End If
    End Sub
    Private Sub Dibujar_Linea(Elemento_Nombre As String, Estilo As BorderStyle)
        Dim Elemento As PowerPacks.LineShape = Nothing
        Select Case Elemento_Nombre
            Case "MEDIADOR-REMOTO"
                Elemento = Me.LinRemote
            Case "MEDIADOR-SIMULADOR"
                Elemento = Me.LinSimulador
            Case "MEDIADOR-SERVIDOR"
                Elemento = Me.LinServidor
            Case "MEDIADOR-ARDUINO"
                Elemento = Me.LinArduino
            Case "MEDIADOR-FEUDRINO"
                Elemento = Me.LinFeudrino
                'displays
            Case "MEDIADOR-DISPLAYMED"
                Elemento = Me.LinDisplayMed
            Case "MEDIADOR-DISPLAY1"
                Elemento = Me.LinDisplay1
            Case "MEDIADOR-DISPLAY2"
                Elemento = Me.LinDisplay2
            Case "MEDIADOR-DISPLAY3"
                Elemento = Me.LinDisplay3
            Case "MEDIADOR-DISPLAYSERV"
                Elemento = Me.LinDisplayServ
        End Select

        If Elemento.Parent.InvokeRequired Then 'Aqui vemos por quien ha sido invocado el listbox
            Dim d As New Delegado_Dibujar_Linea(AddressOf Dibujar_Linea)
            Invoke(d, New Object() {Elemento_Nombre, Estilo})
        Else
            'LinRemote.BorderStyle = Drawing2D.DashStyle.Solid

            Elemento.BorderStyle = CType(Estilo, Drawing2D.DashStyle)
        End If
    End Sub
    Private Sub Log_RichBox(texto As String, color As Integer, texto2 As String, color2 As Integer, C_IdLogTex As String, Rich_Nombre As String)
        Dim Rich As RichTextBox = Nothing '= RiEstado
        'Console.WriteLine("RINAME: " & Rich_Nombre)
        Select Case Rich_Nombre
            Case "RiEstado" : Rich = RiEstado
            Case "RiBufferSerie1" : Rich = RiBufferSerie1
            Case "RiBufferSerie2" : Rich = RiBufferSerie2
            Case "RiBufferSocket" : Rich = RiBufferSocket
        End Select
        If Rich.InvokeRequired Then 'Aqui vemos por quien ha sido invocado el listbox
            Dim d As New Delegado_Log_RichBox(AddressOf Log_RichBox)
            Invoke(d, New Object() {texto, color, texto2, color2, C_IdLogTex, Rich_Nombre})
        Else
            Dim ColorUsar As System.Drawing.Color
            Dim ColorUsar2 As System.Drawing.Color
            Dim Posicion As Integer
            'en caso que sea invocado por un solo hilo agrega el valor correspondiente.
            Rich.SelectionStart = Rich.TextLength
            'Comienzo del dibujo
            'Color
            ColorUsar = System.Drawing.ColorTranslator.FromHtml(CStr(color))
            'ID EN AZUL
            Rich.SelectionColor = AZUL
            Rich.SelectedText = C_IdLogTex
            'GUION EN NEGRO
            Rich.SelectionColor = NEGRO
            Rich.SelectedText = " - "
            'TEXTO 1 EN COLOR A USAR
            Rich.SelectionColor = ColorUsar
            'MOSTRAMOS EL TEXTO (PRIMERA PARTE) / usado A servidor / a Placa
            Rich.SelectedText = texto
            'Existe una segunda parte de texto?
            If texto2 <> "" Then
                ColorUsar2 = System.Drawing.ColorTranslator.FromHtml(CStr(color2))
                Rich.SelectionColor = ColorUsar2
                'CAMBIA LOS ENTES (13 + 10) POR () + 13, LINEA LARGA EN CASO DE RIESTADO
                If Rich_Nombre = "RiEstado" Then
                    texto2 = ENTERS(texto2, True)
                Else
                    texto2 = ENTERS(texto2)
                End If
                'recorremos todo el texto letra por letra
                For I = 1 To texto2.Length
                    Posicion = 1
                    If (Mid(texto2, 1, 1) = ">") Or (Mid(texto2, 1, 1) = "<") Then
                        Rich.SelectionColor = VIOLETA
                    End If
                    If (Mid(texto2, 1, 1) = "(") Or (Mid(texto2, 1, 1) = ")") Then
                        Rich.SelectionColor = VERDE
                        Posicion = 3
                    End If
                    Rich.SelectedText = Mid(texto2, 1, Posicion)
                    texto2 = Mid(texto2, Posicion + 1)
                Next I
                Rich.SelectedText = texto2 'MOSTRAMOS EL TEXTO (SEGUNDA PARTE)
            End If
            Rich.SelectedText = vbCrLf  'mostramos los datos y enter
            Rich.ScrollToCaret()

        End If
    End Sub
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        If m.Msg = &H402 Then
            SIMCON.RecibirWin()
        Else
            MyBase.DefWndProc(m)
        End If
    End Sub

End Class

