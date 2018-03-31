Public Class C_GestorArchivo
    Public C_Archivo As String
    Public Sub New()   'constructor
        ' R console.WriteLine("Clase Gestor de Archivos Instanciada")
    End Sub
    Public Sub Cargar(ByVal Nombre_Archivo As String)
        Dim Path As String
        Dim Ruta As String
        C_Archivo = ""
        'leer configuración
        'Path = Application.StartupPath
        Path = My.Computer.FileSystem.CurrentDirectory
        Ruta = Path & "\" & Nombre_Archivo
        Dim Archivo As New System.IO.StreamReader(Ruta)
        C_Archivo = Archivo.ReadToEnd()
        Archivo.Close()
    End Sub
    Public Function ObtenerValor(Busqueda As String) As String
        Dim PosicionIni As Integer
        Dim PosicionFin As Integer
        Dim PosicionResultadoIni As Integer
        Dim PosicionResultadoFin As Integer
        Dim Longitud As Integer
        Dim Resultado As String
        PosicionIni = InStr(1, C_Archivo, Busqueda)
        If PosicionIni > 0 Then
            PosicionFin = PosicionIni + Busqueda.Length - 1
            PosicionResultadoIni = PosicionFin + 1
            PosicionResultadoFin = InStr(PosicionResultadoIni, C_Archivo, vbCrLf)
            If PosicionResultadoFin > 0 Then
                Longitud = PosicionResultadoFin - PosicionResultadoIni
                Resultado = Mid(C_Archivo, PosicionResultadoIni, Longitud)
            Else
                Resultado = "-1"
            End If
        Else
            Resultado = "-1"
        End If
        ObtenerValor = Trim(Resultado)
    End Function
    Public Sub Guardar(Nombre_Archivo As String)
        Dim Ruta As String
        Dim Path As String
        'leer configuración para cargar todo lo actual en memoria
        Path = My.Computer.FileSystem.CurrentDirectory
        Ruta = Path & "\" & Nombre_Archivo
        Dim Archivo As New System.IO.StreamReader(Ruta)
        C_Archivo = Archivo.ReadToEnd()
        Archivo.Close()
        'Guardar backup
        Dim ArchivoSave As New IO.StreamWriter(Ruta & ".bak")
        ArchivoSave.Write(C_Archivo)
        ArchivoSave.Close()
    End Sub
    Public Sub Agregar(Comando As String, ValorNuevo As String)
        C_Archivo = RemplazarLinea(C_Archivo, Comando, ValorNuevo)
    End Sub
    Public Sub Cerrar(Nombre_Archivo As String)
        Dim Ruta As String
        Dim Path As String
        Path = My.Computer.FileSystem.CurrentDirectory
        Ruta = Path & "\" & Nombre_Archivo
        Dim ArchivoSave As New IO.StreamWriter(Ruta)
        ArchivoSave.Write(C_Archivo)
        ArchivoSave.Close()
        MsgBox("Datos almacenados, se guardo una copia de seguridad como .bak")
    End Sub
    Private Function RemplazarLinea(Archivo As String, Comando As String, ValorNuevo As String) As String
        Dim TextoTemp As String
        Dim PosicionIni As Integer
        Dim PosicionFin As Integer
        Dim Resultado As String
        PosicionIni = InStr(1, Archivo, Comando)
        If PosicionIni > 0 Then
            PosicionFin = InStr(PosicionIni, Archivo, Chr(13) & Chr(10))
            TextoTemp = Mid(Archivo, PosicionIni, PosicionFin - PosicionIni)
            Resultado = Replace(Archivo, TextoTemp, Comando & " " & ValorNuevo)
            RemplazarLinea = Resultado
        Else
            'NO SE ENCONTRO LO AGREGAMOS
            TextoTemp = Comando & " " & ValorNuevo
            Resultado = Archivo & Chr(13) & Chr(10) & TextoTemp
            RemplazarLinea = Resultado
        End If

    End Function

End Class
