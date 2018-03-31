Module Estructuras
    Public ROJO As Drawing.Color = Drawing.Color.Red
    Public ROJO_ As Integer = Drawing.Color.Red.ToArgb
    Public AZUL As Drawing.Color = Drawing.Color.Blue
    Public AZUL_ As Integer = Drawing.Color.Blue.ToArgb
    Public NEGRO As Drawing.Color = Drawing.Color.Black
    Public VIOLETA As Drawing.Color = Drawing.Color.Violet
    Public VERDE As Drawing.Color = Drawing.Color.Green
    Public VERDE_ As Integer = Drawing.Color.Green.ToArgb

    Public Structure EstructuraDatos
        Public Inicio As String
        Public Final As String
    End Structure
    Public Structure EstructuraComando
        Public Encabezado_Total As String
        Public Encabezado_Origen As String
        Public Encabezado_Secuencia As String
        Public Comando_Total As String
        Public Comando_Destino As String
        Public Comando_Modulo As String
        Public Comando_Tipo As String
        Public Comando_Nombre As String
        Public Resultado As String
    End Structure
    Public Structure EstructuraAnalisis
        Public Aceptado As Boolean
        Public Warning As String
    End Structure
    Public Structure EstructuraLogs
        Public TipoLog As String
        Public Texto1 As String
        Public Color1 As String
        Public Texto2 As String
        Public Color2 As String
    End Structure
End Module
