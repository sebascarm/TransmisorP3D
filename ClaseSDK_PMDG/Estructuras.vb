Imports System.Runtime.InteropServices
Public Module Estructuras
    Public Const SString = LockheedMartin.Prepar3D.SimConnect.SIMCONNECT_DATATYPE.STRING256
    Public Const SFloat = LockheedMartin.Prepar3D.SimConnect.SIMCONNECT_DATATYPE.FLOAT32
    Public Const SInt = LockheedMartin.Prepar3D.SimConnect.SIMCONNECT_DATATYPE.INT32

    Enum StrDefinicion
        StrTHR = 1
    End Enum
    Enum DataRecepcion
        Recepcion_1 = 1
    End Enum
    Enum DATA_REQUESTS
        REQUEST_1
    End Enum
    ' This is how you declare a data structure so that simconnect knows how to fill it/read it. 
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=1)>
    Structure StrTHR
        ' This is how you declare a fixed size string 
        '<MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public GENERAL_ENG_THROTTLE_LEVER_POSITION__1 As Single
        Public GENERAL_ENG_THROTTLE_LEVER_POSITION__2 As Single
        Public SPOILERS_HANDLE_POSITION As Single
        Public ELEVATOR_TRIM_POSITION As Single
        Public BRAKE_PARKING_POSITION As Boolean
        Public YAW_STRING_PCT_EXTENDED As Single

        'Public latitude As Double
    End Structure

    Enum EVENTS
        'PITOT_TOGGLE
        FLAPS_INCR
        FLAPS_DECR
        FLAPS_UP
        FLAPS_DOWN

    End Enum
    Enum NOTIFICATION_GROUPS
        GROUP0
    End Enum
End Module
