Module Func_EdicionTexto
    Public Function Eliminar_Enter(Texto As String) As String
        Dim Resultado As String
        Resultado = Replace(Texto, Chr(13), "")
        Resultado = Replace(Resultado, Chr(10), "")
        Eliminar_Enter = Resultado
    End Function
    Public Function Eliminar_Omitidos(Texto As String) As String
        Dim Ini As Integer
        Dim Fin As Integer
        Dim Resultado As String
        Ini = Texto.IndexOf("{")
        'Fin = Texto.IndexOf("}")
        Fin = Texto.LastIndexOf("}")
        If (Ini > -1) And (Fin > Ini) Then
            'Resultado = Mid(Texto, Ini + 1, (Fin + 1) - Ini)
            'Resultado = Mid(Texto, 1, Ini) & Mid(Texto, Fin + 2)
            Resultado = Mid(Texto, 1, Ini) & Mid(Texto, Fin + 2)
            'MsgBox(Resultado & " ini = " & Ini & " fin = " & Fin)
        Else
            Resultado = Texto
        End If
        Eliminar_Omitidos = Resultado
    End Function
    Public Sub Desencolar(Cola As String, ByRef Resul1 As String, ByRef Optional Resul2 As String = "", ByRef Optional Resul3 As String = "", ByRef Optional Resul4 As String = "")
        Dim PosIni As Integer
        Dim PosFin As Integer
        Dim Largo As Integer
        Dim LargoTmp As Integer
        Dim Resultado As String
        Dim Texto As String
        Resul1 = Cola
        Resul2 = ""
        Resul3 = ""
        Resul4 = ""
        Texto = Cola
        PosIni = InStr(Texto, "'")
        Largo = Len(Cola)
        For I = 1 To 4
            If (PosIni > 0) And (Largo > PosIni + 1) Then
                PosFin = InStr(PosIni + 1, Texto, "'")
                If PosFin > 0 Then
                    LargoTmp = PosFin - 1 - PosIni
                    Resultado = Mid(Texto, PosIni + 1, LargoTmp)
                    Select Case I
                        Case 1
                            Resul1 = Resultado
                        Case 2
                            Resul2 = Resultado
                        Case 3
                            Resul3 = Resultado
                        Case 4
                            Resul4 = Resultado
                    End Select
                    Texto = Mid(Texto, PosFin + 1)
                    PosIni = InStr(Texto, "'")
                    Largo = Len(Cola)
                Else
                    I = 4
                End If
            Else
                I = 4
            End If
        Next I
    End Sub
    Public Function Obtener_Valor(Datos As String, Busqueda As String, Delimitador As String) As String
        Dim Resultado As String
        Dim PosIni As Integer
        Dim PosFin As Integer
        Dim Longitud As Integer
        PosIni = InStr(Datos, Busqueda)
        If PosIni > 0 Then 'posicion inicial encontrada
            PosIni = PosIni + Busqueda.Length + 2 'buscamos el principio de datos a partir de la comilla simple ='
            PosFin = InStr(PosIni, Datos, Delimitador) 'buscamos el final a partir de la comilla simple '
            If PosFin > 0 Then ' posicion final encontrada
                Longitud = PosFin - PosIni
                Resultado = Mid(Datos, PosIni, Longitud)
            Else
                Resultado = ""
            End If
        Else
            Resultado = ""
        End If
        Obtener_Valor = Resultado
    End Function
    Public Function ENTERS(Texto As String, Optional Linea_Larga As Boolean = False) As String
        Dim Longitud As Integer
        Dim TextoEspacio As String
        Dim TextoFinal As String
        'REMPLAZA LOS ENTERS CHR13 + CR10 POR ( )
        TextoEspacio = ""
        Texto = Replace(Texto, Chr(13), "(")
        Texto = Replace(Texto, Chr(10), ")" & Chr(13) & "_____")
        'Remplazamos visualmente los envios al servidor que van sin enters (todos juntos) 
        If Linea_Larga Then
            Texto = Replace(Texto, "<[", "<" & Chr(13) & "_________________" & "[")
        Else
            Texto = Replace(Texto, "<[", "<" & Chr(13) & "_____" & "[")
        End If
        'Remplazamos si agregamos espacios al final
        Longitud = Texto.Length
        If Longitud > 4 Then
            TextoEspacio = Mid(Texto, Longitud - 4)
        End If
        If TextoEspacio = "_____" Then
            Texto = Mid(Texto, 1, Longitud - 5)
        End If
        'borramos el enter final si existe
        Longitud = Texto.Length
        TextoFinal = Mid(Texto, Longitud)
        If TextoFinal = vbCr Then
            Texto = Mid(Texto, 1, Longitud - 1)
        End If
        ENTERS = Texto
    End Function

End Module
