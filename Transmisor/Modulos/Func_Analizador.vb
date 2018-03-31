Module Func_Analizador
    Public Function Obtener_Buffer_Estructura(Datos As String, Fin_de_Comando As String) As EstructuraDatos
        Dim PosFin As Integer
        Dim Resultado_Inicio As String = ""
        Dim Resultado_Fin As String = ""
        Dim Longitud As Integer
        Dim Longitud_FinComando As Integer
        Longitud_FinComando = Fin_de_Comando.Length
        PosFin = InStrRev(Datos, Fin_de_Comando)
        If PosFin > 0 Then
            'final encontrado 'primer parte
            Longitud = PosFin
            Resultado_Inicio = Mid(Datos, 1, Longitud + Longitud_FinComando - 1)
            ' R console.WriteLine("Total de comandos enteros: " & Resultado_Inicio)
            Longitud = Datos.Length
            If (PosFin + Longitud_FinComando - 1) < Longitud Then ' segunda parte encontrada
                Resultado_Fin = Mid(Datos, PosFin + Longitud_FinComando)
            End If
        Else
            Resultado_Fin = Datos
        End If
        Obtener_Buffer_Estructura.Inicio = Resultado_Inicio
        Obtener_Buffer_Estructura.Final = Resultado_Fin
    End Function
    Public Function Obtener_Comando(Datos As String, Fin_de_Comando As String) As EstructuraDatos
        Dim PosFin As Integer
        Dim Longitud As Integer
        Dim Resultado_Inicio As String = ""
        Dim Resultado_Fin As String = ""
        Dim Long_FinComando As Integer
        Long_FinComando = Fin_de_Comando.Length
        PosFin = InStr(Datos, Fin_de_Comando)

        If PosFin > 0 Then ' se encontro fin
            'final encontrado 'primer parte
            Longitud = PosFin
            Resultado_Inicio = Mid(Datos, 1, Longitud + Long_FinComando - 1) 'dejamos el texto o patron de fin de comando
            Longitud = Datos.Length
            If (PosFin + Long_FinComando - 1) < Longitud Then ' segunda parte encontrada
                Resultado_Fin = Mid(Datos, PosFin + Long_FinComando)
            End If
        End If
        ' R console.WriteLine("Primer comando: " & Resultado_Inicio)
        Obtener_Comando.Inicio = Resultado_Inicio
        Obtener_Comando.Final = Resultado_Fin
    End Function
    Public Function Almacenar_Comando(Comando As String) As EstructuraComando
        Dim Longitud As Integer
        'encabezado
        Almacenar_Comando.Encabezado_Total = ""
        Almacenar_Comando.Encabezado_Origen = ""
        Almacenar_Comando.Encabezado_Secuencia = ""
        'comando
        Almacenar_Comando.Comando_Total = ""
        Almacenar_Comando.Comando_Destino = ""
        Almacenar_Comando.Comando_Modulo = ""
        Almacenar_Comando.Comando_Tipo = ""
        Almacenar_Comando.Comando_Nombre = ""
        'resultado
        Almacenar_Comando.Resultado = ""
        Longitud = Comando.Length
        If Longitud > 18 Then
            'encabezado
            Almacenar_Comando.Encabezado_Total = Mid(Comando, 1, 5)
            Almacenar_Comando.Encabezado_Origen = Mid(Comando, 2, 1)
            Almacenar_Comando.Encabezado_Secuencia = Mid(Comando, 3, 2)
            'comando
            Almacenar_Comando.Comando_Total = Mid(Comando, 6)
            Almacenar_Comando.Comando_Destino = Mid(Comando, 7, 1)
            Almacenar_Comando.Comando_Modulo = Mid(Comando, 8, 3)
            Almacenar_Comando.Comando_Tipo = Mid(Comando, 12, 1)
            Almacenar_Comando.Comando_Nombre = Mid(Comando, 13, 4)
            'resultado
            Almacenar_Comando.Resultado = Mid(Comando, 18, Longitud - 18)
        End If
    End Function
    Public Function Almacenar_Logs(Datos As String) As EstructuraLogs
        Dim Longitud As Integer
        'comando
        Almacenar_Logs.TipoLog = ""
        Almacenar_Logs.Texto1 = ""
        Almacenar_Logs.Color1 = ""
        Almacenar_Logs.Texto2 = ""
        Almacenar_Logs.Color2 = ""

        Longitud = Datos.Length
        If Longitud > 18 Then
            'almacenamos
            Almacenar_Logs.TipoLog = Obtener_Valor(Datos, "TIPOLOG", "'")
            Almacenar_Logs.Texto1 = Obtener_Valor(Datos, "TEXTO1", "'")
            Almacenar_Logs.Color1 = Obtener_Valor(Datos, "COLOR1", "'")
            Almacenar_Logs.Texto2 = Obtener_Valor(Datos, "TEXTO2", "'")
            Almacenar_Logs.Color2 = Obtener_Valor(Datos, "COLOR2", "'")
        End If
    End Function
    Public Function Validos(Dato As String, Valores_Validos() As String) As Boolean
        Dim ValorEncontrado As Boolean = False
        For Each Valor In Valores_Validos
            If Valor = Dato Then
                ValorEncontrado = True
                Exit For
            End If
        Next
        Validos = ValorEncontrado
    End Function
    Public Function Armar_Sender(Paquete As String, Comando_Estructurado As EstructuraComando, Secuencia As Integer) As String
        Dim Texto As String
        Dim SecuenciaTexto As String
        SecuenciaTexto = Secuencia_a_String(Secuencia)
        Texto = "[" & Comando_Estructurado.Encabezado_Origen
        Texto &= SecuenciaTexto
        Texto &= "]"
        Texto &= Comando_Estructurado.Comando_Total
        'Texto &= "="
        'Texto &= Comando_Estructurado.Resultado
        'Texto &= "<"
        Armar_Sender = Paquete & Texto
    End Function
    Public Function Armar_SenderV2(Comando_Estructurado As EstructuraComando, Secuencia As Integer) As String
        Dim Texto As String
        Dim SecuenciaTexto As String
        SecuenciaTexto = Secuencia_a_String(Secuencia)
        Texto = "[" & Comando_Estructurado.Encabezado_Origen
        Texto &= SecuenciaTexto
        Texto &= "]"
        Texto &= Comando_Estructurado.Comando_Total
        Armar_SenderV2 = Texto
    End Function
    Private Function Secuencia_a_String(Secuencia As Integer) As String
        Dim Texto As String = ""
        If Secuencia < 10 Then
            Texto = "0" & CStr(Secuencia)
        Else
            Texto = CStr(Secuencia)
        End If
        Secuencia_a_String = Texto
    End Function
    Public Sub EjecutarComando(Comando As String)
        Select Case Comando
            'COMANDOS QUE RECIBE EL MEDIADOR del REMOTO
            Case "Bot_ConectSimulador"
                'ConectarSimulador()
            Case "Bot_DescSimulador"
                DesconectarSimulador()
            Case "Bot_Placa1"
                ConectarPlaca1()
            Case "Bot_Placa2"
                ConectarPlaca2()
            Case "Placas_Desc"
                DesconectarPlaca1()
                DesconectarPlaca2()
            Case "CoEncenderTH"
                EnviaraSimulador(">SENC_THR__=1<")
            Case "CoEncenderMCP"
                EnviaraSimulador(">SENC_MCP__=1<")
            Case "CoEncenderMIP"
                EnviaraSimulador(">SENC_MIP__=1<")
            Case "CoEncenderYOK"
                EnviaraSimulador(">SENC_YOK__=1<")
            Case "CoEncenderFIR"
                EnviaraSimulador(">SENC_FIR__=1<")
            Case "CoScreen"
                ObtenetPantallaMediador()
                'COMANDOS DE PETICIONES
            Case "PedirConfiguracónToolStripMenuItem"
                PedidodeConfguracion()

        End Select
    End Sub
    Public Sub EjecutarDibujo(Comando As String, Activo As Integer)
        Dim ValActivo As Boolean
        If Activo = 1 Then
            ValActivo = True
        Else
            ValActivo = False
        End If
        Select Case Comando
            Case "Dibujar_MediadorSimulador"
                Dibujar_MediadorSimulador(ValActivo)
            Case "Dibujar_MediadorServidor"
                Dibujar_MediadorServidor(ValActivo)
            Case "Dibujar_MediadorArduino"
                Dibujar_MediadorArduino(ValActivo)
            Case "Dibujar_MediadorFeudrino"
                Dibujar_MediadorFeudrino(ValActivo)
            Case "Dibujar_MediadorDisplayMed"
                Dibujar_MediadorDisplayMed(ValActivo)
            Case "Dibujar_MediadorDisplay1"
                Dibujar_MediadorDisplay1(ValActivo)
            Case "Dibujar_MediadorDisplay2"
                Dibujar_MediadorDisplay2(ValActivo)

        End Select
    End Sub

End Module
