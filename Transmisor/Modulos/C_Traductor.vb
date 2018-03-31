Public Class C_Traductor
    Dim Dicc As New Dictionary(Of String, String)
    Public Sub New()
        'MCP----------------------------------------------------------------
        'LEDS PRIMARIOS
        Dicc.Add("MCP_annunATArm", "1MCP_LATAR")
        Dicc.Add("MCP_annunFD1", "1MCP_LFD1_")
        Dicc.Add("MCP_annunFD2", "1MCP_LFD2_")
        'LEDS DE BOTONES
        Dicc.Add("MCP_annunN1", "1MCP_LN1__")
        Dicc.Add("MCP_annunSPEED", "1MCP_LSPEE")
        Dicc.Add("MCP_annunVNAV", "1MCP_LVNAV")
        Dicc.Add("MCP_annunLVL_CHG", "1MCP_LLVLC")
        Dicc.Add("MCP_annunHDG_SEL", "1MCP_LHDGS")
        Dicc.Add("MCP_annunLNAV", "1MCP_LLNAV")
        Dicc.Add("MCP_annunVOR_LOC", "1MCP_LVORL")
        Dicc.Add("MCP_annunAPP", "1MCP_LAPP_")
        Dicc.Add("MCP_annunALT_HOLD", "1MCP_LALTH")
        Dicc.Add("MCP_annunVS", "1MCP_LVS__")
        Dicc.Add("MCP_annunCMD_A", "1MCP_LCMDA")
        Dicc.Add("MCP_annunCWS_A", "1MCP_LCWSA")
        Dicc.Add("MCP_annunCMD_B", "1MCP_LCMDB")
        Dicc.Add("MCP_annunCWS_B", "1MCP_LCWSB")
        'DISPLAYS
        Dicc.Add("MCP_Course1", "1MCP_DCOU1")
        Dicc.Add("MCP_Course2", "1MCP_DCOU2")
        Dicc.Add("MCP_IASMach", "1MCP_DIASM")
        Dicc.Add("MCP_Heading", "1MCP_DHEAD")
        Dicc.Add("MCP_Altitude", "1MCP_DALTI")
        Dicc.Add("MCP_VertSpeed", "1MCP_DVS__")
        'PANTALLAS APAGADAS --- 
        Dicc.Add("MCP_IASBlank", "1MCP_BIASM")
        Dicc.Add("MCP_VertSpeedBlank", "1MCP_BVS__")
        'PANTALLAS FLASH --- 
        Dicc.Add("MCP_IASOverspeedFlash", "1MCP_FOVSP")
        Dicc.Add("MCP_IASUnderspeedFlash", "1MCP_FUNSP")

        'THR---------------------------------------------------------------
        Dicc.Add("PED_annunParkingBrake", "2THR_PKBRK")
        'Dicc.Add("THR_ElevatorTrim", "2TH_TRIM_=") offset ipc

        'MIP---------------------------------------------------------------
        '-- MIP CENTRAL
        Dicc.Add("MAIN_annunANTI_SKID_INOP", "2MIP_ASKID=")
        Dicc.Add("MAIN_annunAUTO_BRAKE_DISARM", "2MIP_ABRKD=")
        Dicc.Add("MAIN_annunLE_FLAPS_TRANSIT", "2MIP_FLTRA=")
        Dicc.Add("MAIN_annunLE_FLAPS_EXT", "2MIP_FLEXT=")
        Dicc.Add("MAIN_TEFlapsNeedle1", "2MIP_FLAP_=")
        'Dicc.Add("MAIN_TEFlapsNeedle2", "2MI_FLAP_=") no se usa
        'MIP GEAR	
        Dicc.Add("MAIN_annunGEAR_transit1", "2MIP_GTRLE=")
        Dicc.Add("MAIN_annunGEAR_transit2", "2MIP_GTRNO=")
        Dicc.Add("MAIN_annunGEAR_transit3", "2MIP_GTRRI=")
        Dicc.Add("MAIN_annunGEAR_locked1", "2MIP_GLOLE=")
        Dicc.Add("MAIN_annunGEAR_locked2", "2MIP_GLONO=")
        Dicc.Add("MAIN_annunGEAR_locked3", "2MIP_GLORI=")
        'MIP YAW DAMPER	
        Dicc.Add("YawDamper", "2MI_YAWDA=")
        'MIP PANEL SUPERIOR IZQUIERDO
        Dicc.Add("MAIN_annunBELOW_GS1", "2MIP_LBGS1=")
        Dicc.Add("MAIN_annunAP1", "2MIP_LAP1R=")
        Dicc.Add("MAIN_annunAP_Amber1", "2MIP_LAP1A=")
        Dicc.Add("MAIN_annunAT1", "2MIP_LAT1R=")
        Dicc.Add("MAIN_annunAT_Amber1", "2MIP_LAT1A=")
        Dicc.Add("MAIN_annunFMC1", "2MIP_LFMC1=")
        Dicc.Add("MAIN_annunSPEEDBRAKE_ARMED", "2MIP_LBRAR=")
        Dicc.Add("MAIN_annunSPEEDBRAKE_DO_NOT_ARM", "2MIP_LBRNO=")
        Dicc.Add("MAIN_annunSTAB_OUT_OF_TRIM", "2MIP_LSOUT=")

        'FIRE------------------------------------------------------------------
        Dicc.Add("FIRE_annunENG_OVERHEAT1", "2FIR_LENG1=")
        Dicc.Add("FIRE_annunENG_OVERHEAT2", "2FIR_LENG2=")
        Dicc.Add("FIRE_HandleIlluminated1", "2FIR_LHAN1=")
        Dicc.Add("FIRE_HandleIlluminated2", "2FIR_LHAN2=")
        Dicc.Add("FIRE_HandleIlluminated3", "2FIR_LHAN3=")
        Dicc.Add("FIRE_annunWHEEL_WELL", "2FIR_LWHEE=")
        Dicc.Add("FIRE_annunFAULT", "2FIR_LFAUL=")
        Dicc.Add("FIRE_annunAPU_DET_INOP", "2FIR_LDINO=")
        Dicc.Add("FIRE_annunAPU_BOTTLE_DISCHARGE", "2FIR_LAPUB=")
        Dicc.Add("FIRE_annunBOTTLE_DISCHARGE1", "2FIR_LBOT1=")
        Dicc.Add("FIRE_annunBOTTLE_DISCHARGE2", "2FIR_LBOT2=")
        Dicc.Add("FIRE_annunExtinguisherTest1", "2FIR_LTES1=")
        Dicc.Add("FIRE_annunExtinguisherTest2", "2FIR_LTES2=")
        Dicc.Add("FIRE_annunExtinguisherTest3", "2FIR_LTES3=")

    End Sub
    Public Function Traducir(Parametro As String, Valor As String) As String
        Dim Resul As String = ""
        If Dicc.TryGetValue(Parametro, Resul) Then
            'almacenado en resul si lo encontro

        End If
        If Resul <> "" Then
            Return "[S00]>" & Resul & "=" & Valor & "<"
        Else
            Return ""
        End If
    End Function
End Class
