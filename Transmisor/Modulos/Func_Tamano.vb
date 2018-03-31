Module Func_Tamano
    Public Sub Reajustar_tamanos(ByRef RichText As RichTextBox, Form As Form)
        Dim Margen = 50
        Dim Altura = RichText.Top
        Dim Form_Alto = Form.Height
        Dim Alto As Integer
        Alto = Form_Alto - Altura - Margen
        RichText.Height = Alto
    End Sub
End Module
