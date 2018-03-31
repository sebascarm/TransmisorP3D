'Import required for StructurLayout
Imports System.Runtime.InteropServices
Public Class C_PMDG
    Public Const PMDG_NGX_DATA_NAME = "PMDG_NGX_Data"
    Public Const PMDG_NGX_CONTROL_NAME = "PMDG_NGX_Control"
    Public Enum PMDGIDs
        PMDG_NGX_DATA_ID = &H4E477831
        PMDG_NGX_DATA_DEFINITION = &H4E477832
        PMDG_NGX_CONTROL_ID = &H4E477833
        PMDG_NGX_CONTROL_DEFINITION = &H4E477834
    End Enum
    Public Enum Data_Request_ID
        DATA_REQUEST
        CONTROL_REQUEST
        AIR_PATH_REQUEST
    End Enum

    'Do not change this Structure, SimConnect will give you wrong Values!
    <StructLayout(LayoutKind.Sequential, Pack:=4, CharSet:=CharSet.Ansi)>
    Public Structure PMDG_NGX_Data
        'Aft overhead
        'ADIRU
        Public IRS_DisplaySelector As Byte              ' Positions 0..4
        Public IRS_SysDisplay_R As Byte                 ' false: L  true: R
        Public IRS_annunGPS As Byte

        Public IRS_annunALIGN1 As Byte
        Public IRS_annunALIGN2 As Byte

        Public IRS_annunON_DC1 As Byte
        Public IRS_annunON_DC2 As Byte

        Public IRS_annunFAULT1 As Byte
        Public IRS_annunFAULT2 As Byte

        Public IRS_annunDC_FAI1 As Byte
        Public IRS_annunDC_FAI2 As Byte

        Public IRS_ModeSelector1 As Byte    '0: OFF  1: ALIGN  2: NAV  3: ATT
        Public IRS_ModeSelector2 As Byte    '0: OFF  1: ALIGN  2: NAV  3: ATT

        'PSEU
        Public WARN_annunPSEU As Byte

        'Service Interphone
        Public COMM_ServiceInterphoneSw As Byte

        'Lights
        Public LTS_DomeWhiteSw As Byte                  'Lights > 0: DIM  1: OFF  2: BRIGHT

        'Engine
        Public ENG_EECSwitch1 As Byte
        Public ENG_EECSwitch2 As Byte

        Public ENG_annunREVERSER1 As Byte
        Public ENG_annunREVERSER2 As Byte

        Public ENG_annunENGINE_CONTROL1 As Byte
        Public ENG_annunENGINE_CONTROL2 As Byte

        Public ENG_annunALTN1 As Byte
        Public ENG_annunALTN2 As Byte

        'Oxygen
        Public OXY_Needle As Byte                'Position 0...240
        Public OXY_SwNormal As Byte              'true: NORMAL  false: ON
        Public OXY_annunPASS_OXY_ON As Byte

        'Gear
        Public GEAR_annunOvhdLEFT As Byte
        Public GEAR_annunOvhdNOSE As Byte
        Public GEAR_annunOvhdRIGHT As Byte

        'Flight recorder
        Public FLTREC_SwNormal As Byte           'true: NORMAL  false: TEST
        Public FLTREC_annunOFF As Byte

        'Forward overhead
        'Flight Controls

        Public FCTL_FltControl_Sw1 As Byte  '0: STBY/RUD  1: OFF  2: ON
        Public FCTL_FltControl_Sw2 As Byte  '0: STBY/RUD  1: OFF  2: ON

        Public FCTL_Spoiler_Sw1 As Byte     'true: ON  false: OFF  
        Public FCTL_Spoiler_Sw2 As Byte     'true: ON  false: OFF  

        Public FCTL_YawDamper_Sw As Byte
        Public FCTL_AltnFlaps_Sw_ARM As Byte             'true: ARM  false: OFF
        Public FCTL_AltnFlaps_Control_Sw As Byte         '0: UP  1: OFF  2: DOWN

        Public FCTL_annunFC_LOW_PRESSURE1 As Byte  'FLT CONTROL
        Public FCTL_annunFC_LOW_PRESSURE2 As Byte  'FLT CONTROL

        Public FCTL_annunYAW_DAMPER As Byte
        Public FCTL_annunLOW_QUANTITY As Byte
        Public FCTL_annunLOW_PRESSURE As Byte
        Public FCTL_annunLOW_STBY_RUD_ON As Byte
        Public FCTL_annunFEEL_DIFF_PRESS As Byte
        Public FCTL_annunSPEED_TRIM_FAIL As Byte
        Public FCTL_annunMACH_TRIM_FAIL As Byte
        Public FCTL_annunAUTO_SLAT_FAIL As Byte

        'Navigation/Displays
        Public NAVDIS_VHFNavSelector As Byte             '0: BOTH ON 1  1: NORMAL  2: BOTH ON 2
        Public NAVDIS_IRSSelector As Byte                '0: BOTH ON L  1: NORMAL  2: BOTH ON R
        Public NAVDIS_FMCSelector As Byte                '0: BOTH ON L  1: NORMAL  2: BOTH ON R
        Public NAVDIS_SourceSelector As Byte             '0: ALL ON 1   1: AUTO    2: ALL ON 2
        Public NAVDIS_ControlPaneSelector As Byte        '0: BOTH ON 1  1: NORMAL  2: BOTH ON 2

        'Fuel
        Public FUEL_FuelTempNeedle As Single         'Value
        Public FUEL_CrossFeedSw As Byte

        Public FUEL_PumpFwdSw1 As Byte  'left fwd / right fwd
        Public FUEL_PumpFwdSw2 As Byte  'left fwd / right fwd

        Public FUEL_PumpAftSw1 As Byte  'left aft / right aft
        Public FUEL_PumpAftSw2 As Byte  'left aft / right aft

        Public FUEL_PumpCtrSw1 As Byte  'ctr left / ctr right
        Public FUEL_PumpCtrSw2 As Byte  'ctr left / ctr right

        Public FUEL_annunENG_VALVE_CLOSED1 As Byte
        Public FUEL_annunENG_VALVE_CLOSED2 As Byte

        Public FUEL_annunSPAR_VALVE_CLOSED1 As Byte
        Public FUEL_annunSPAR_VALVE_CLOSED2 As Byte

        Public FUEL_annunFILTER_BYPASS1 As Byte
        Public FUEL_annunFILTER_BYPASS2 As Byte

        Public FUEL_annunXFEED_VALVE_OPEN As Byte

        Public FUEL_annunLOWPRESS_Fwd1 As Byte
        Public FUEL_annunLOWPRESS_Fwd2 As Byte

        Public FUEL_annunLOWPRESS_Aft1 As Byte
        Public FUEL_annunLOWPRESS_Aft2 As Byte

        Public FUEL_annunLOWPRESS_Ctr1 As Byte
        Public FUEL_annunLOWPRESS_Ctr2 As Byte

        'Electrical
        Public ELEC_annunBAT_DISCHARGE As Byte
        Public ELEC_annunTR_UNIT As Byte
        Public ELEC_annunELEC As Byte
        Public ELEC_DCMeterSelector As Byte              '0: STBY PWR  1: BAT BUS ... 7: TEST
        Public ELEC_ACMeterSelector As Byte              '0: STBY PWR  1: GND PWR ... 6: TEST
        Public ELEC_BatSelector As Byte                  '0: OFF  1: BAT  2: ON
        Public ELEC_CabUtilSw As Byte
        Public ELEC_IFEPassSeatSw As Byte

        Public ELEC_annunDRIVE1 As Byte
        Public ELEC_annunDRIVE2 As Byte

        Public ELEC_annunSTANDBY_POWER_OFF As Byte

        Public ELEC_IDGDisconnectSw1 As Byte
        Public ELEC_IDGDisconnectSw2 As Byte

        Public ELEC_StandbyPowerSelector As Byte         '0: BAT  1: OFF  2: AUTO
        Public ELEC_annunGRD_POWER_AVAILABLE As Byte
        Public ELEC_GrdPwrSw As Byte
        Public ELEC_BusTransSw_AUTO As Byte

        Public ELEC_GenSw1 As Byte
        Public ELEC_GenSw2 As Byte

        Public ELEC_APUGenSw1 As Byte
        Public ELEC_APUGenSw2 As Byte

        Public ELEC_annunTRANSFER_BUS_OFF1 As Byte
        Public ELEC_annunTRANSFER_BUS_OFF2 As Byte

        Public ELEC_annunSOURCE_OFF1 As Byte
        Public ELEC_annunSOURCE_OFF2 As Byte

        Public ELEC_annunGEN_BUS_OFF1 As Byte
        Public ELEC_annunGEN_BUS_OFF2 As Byte

        Public ELEC_annunAPU_GEN_OFF_BUS As Byte

        'APU
        Public APU_EGTNeedle As Single                    'Value
        Public APU_annunMAINT As Byte
        Public APU_annunLOW_OIL_PRESSURE As Byte
        Public APU_annunFAULT As Byte
        Public APU_annunOVERSPEED As Byte

        'Wipers
        Public OH_WiperLSelector As Byte           '0: PARK  1: INT  2: LOW  3:HIGH
        Public OH_WiperRSelector As Byte           '0: PARK  1: INT  2: LOW  3:HIGH

        'Center overhead controls & indicators
        Public LTS_CircuitBreakerKnob As Byte          'Position 0...150
        Public LTS_OvereadPanelKnob As Byte        'Position 0...150
        Public AIR_EquipCoolingSupplyNORM As Byte
        Public AIR_EquipCoolingExhaustNORM As Byte
        Public AIR_annunEquipCoolingSupplyOFF As Byte
        Public AIR_annunEquipCoolingExhaustOFF As Byte
        Public LTS_annunEmerNOT_ARMED As Byte
        Public LTS_EmerExitSelector As Byte        '0: OFF  1: ARMED  2: ON
        Public COMM_NoSmokingSelector As Byte          '0: OFF  1: AUTO   2: ON
        Public COMM_FastenBeltsSelector As Byte       '0: OFF  1: AUTO   2: ON
        Public COMM_annunCALL As Byte
        Public COMM_annunPA_IN_USE As Byte

        'Anti-ice

        Public ICE_annunOVERHEAT1 As Byte
        Public ICE_annunOVERHEAT2 As Byte
        Public ICE_annunOVERHEAT3 As Byte
        Public ICE_annunOVERHEAT4 As Byte

        Public ICE_annunON1 As Byte
        Public ICE_annunON2 As Byte
        Public ICE_annunON3 As Byte
        Public ICE_annunON4 As Byte

        Public ICE_WindowHeatSw1 As Byte
        Public ICE_WindowHeatSw2 As Byte
        Public ICE_WindowHeatSw3 As Byte
        Public ICE_WindowHeatSw4 As Byte

        Public ICE_annunCAPT_PITOT As Byte
        Public ICE_annunL_ELEV_PITOT As Byte
        Public ICE_annunL_ALPHA_VANE As Byte
        Public ICE_annunL_TEMP_PROBE As Byte
        Public ICE_annunFO_PITOT As Byte
        Public ICE_annunR_ELEV_PITOT As Byte
        Public ICE_annunR_ALPHA_VANE As Byte
        Public ICE_annunAUX_PITOT As Byte

        Public ICE_TestProbeHeatSw1 As Byte
        Public ICE_TestProbeHeatSw2 As Byte

        Public ICE_annunVALVE_OPEN1 As Byte
        Public ICE_annunVALVE_OPEN2 As Byte

        Public ICE_annunCOWL_ANTI_ICE1 As Byte
        Public ICE_annunCOWL_ANTI_ICE2 As Byte

        Public ICE_annunCOWL_VALVE_OPEN1 As Byte
        Public ICE_annunCOWL_VALVE_OPEN2 As Byte

        Public ICE_WingAntiIceSw As Byte

        Public ICE_EngAntiIceSw1 As Byte
        Public ICE_EngAntiIceSw2 As Byte

        'Hydraulics

        Public HYD_annunLOW_PRESS_eng1 As Byte
        Public HYD_annunLOW_PRESS_eng2 As Byte

        Public HYD_annunLOW_PRESS_elec1 As Byte
        Public HYD_annunLOW_PRESS_elec2 As Byte

        Public HYD_annunOVERHEAT_elec1 As Byte
        Public HYD_annunOVERHEAT_elec2 As Byte

        Public HYD_PumpSw_eng1 As Byte
        Public HYD_PumpSw_eng2 As Byte

        Public HYD_PumpSw_elec1 As Byte
        Public HYD_PumpSw_elec2 As Byte

        'Air systems
        Public AIR_TempSourceSelector As Byte               'Positions 0..6
        Public AIR_TrimAirSwitch As Byte

        Public AIR_annunZoneTemp1 As Byte
        Public AIR_annunZoneTemp2 As Byte
        Public AIR_annunZoneTemp3 As Byte

        Public AIR_annunDualBleed As Byte
        Public AIR_annunRamDoorL As Byte
        Public AIR_annunRamDoorR As Byte

        Public AIR_RecircFanSwitch1 As Byte
        Public AIR_RecircFanSwitch2 As Byte

        Public AIR_PackSwitch1 As Byte
        Public AIR_PackSwitch2 As Byte

        Public AIR_BleedAirSwitch1 As Byte
        Public AIR_BleedAirSwitch2 As Byte

        Public AIR_APUBleedAirSwitch As Byte
        Public AIR_IsolationValveSwitch As Byte

        Public AIR_annunPackTripOff1 As Byte
        Public AIR_annunPackTripOff2 As Byte

        Public AIR_annunWingBodyOverheat1 As Byte
        Public AIR_annunWingBodyOverheat2 As Byte

        Public AIR_annunBleedTripOff1 As Byte
        Public AIR_annunBleedTripOff2 As Byte

        Public AIR_FltAltWindow As UInt32
        Public AIR_LandAltWindow As UInt32
        Public AIR_OutflowValveSwitch As UInt32          '0=CLOSE  1=NEUTRAL  2=OPEN
        Public AIR_PressurizationModeSelector As UInt32      '0=AUTO  1=ALTN  2=MAN

        'Bottom overhead
        Public LTS_LandingLtRetractableSw1 As Byte  '0: RETRACT  1: EXTEND  2: ON
        Public LTS_LandingLtRetractableSw2 As Byte  '0: RETRACT  1: EXTEND  2: ON

        Public LTS_LandingLtFixedSw1 As Byte
        Public LTS_LandingLtFixedSw2 As Byte

        Public LTS_RunwayTurnoffSw1 As Byte
        Public LTS_RunwayTurnoffSw2 As Byte

        Public LTS_TaxiSw As Byte
        Public APU_Selector As Byte               '0: OFF  1: ON  2: START

        Public ENG_StartSelector1 As Byte           '0: GRD  1: OFF  2: CONT  3: FLT       
        Public ENG_StartSelector2 As Byte           '0: GRD  1: OFF  2: CONT  3: FLT       

        Public ENG_IgnitionSelector As Byte           '0: IGN L  1: BOTH  2: IGN R
        Public LTS_LogoSw As Byte
        Public LTS_PositionSw As Byte                     '0: STEADY  1: OFF  2: STROBE&STEADY
        Public LTS_AntiCollisionSw As Byte
        Public LTS_WingSw As Byte
        Public LTS_WheelWellSw As Byte

        'Glareshield
        'Warnings
        Public WARN_annunFIRE_WARN1 As Byte
        Public WARN_annunFIRE_WARN2 As Byte

        Public WARN_annunMASTER_CAUTION1 As Byte
        Public WARN_annunMASTER_CAUTION2 As Byte

        Public WARN_annunFLT_CONT As Byte
        Public WARN_annunIRS As Byte
        Public WARN_annunFUEL As Byte
        Public WARN_annunELEC As Byte
        Public WARN_annunAPU As Byte
        Public WARN_annunOVHT_DET As Byte
        Public WARN_annunANTI_ICE As Byte
        Public WARN_annunHYD As Byte
        Public WARN_annunDOORS As Byte
        Public WARN_annunENG As Byte
        Public WARN_annunOVERHEAD As Byte
        Public WARN_annunAIR_COND As Byte

        'EFIS control panels
        Public EFIS_MinsSelBARO1 As Byte
        Public EFIS_MinsSelBARO2 As Byte

        Public EFIS_BaroSelHPA1 As Byte
        Public EFIS_BaroSelHPA2 As Byte

        Public EFIS_VORADFSel11 As Byte         '0: VOR  1: OFF  2: ADF
        Public EFIS_VORADFSel12 As Byte         '0: VOR  1: OFF  2: ADF

        Public EFIS_VORADFSel21 As Byte         '0: VOR  1: OFF  2: ADF 
        Public EFIS_VORADFSel22 As Byte         '0: VOR  1: OFF  2: ADF 

        Public EFIS_ModeSel1 As Byte            '0: APP  1: VOR  2: MAP  3: PLAn
        Public EFIS_ModeSel2 As Byte            '0: APP  1: VOR  2: MAP  3: PLAn

        Public EFIS_RangeSel1 As Byte           '0: 5 ... 7: 640
        Public EFIS_RangeSel2 As Byte           '0: 5 ... 7: 640

        'Mode control panel
        '<MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public MCP_Course As Byte
        '<MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public MCP_Course As UShort
        Public MCP_Course1 As UShort
        Public MCP_Course2 As UShort
        Public MCP_IASMach As Single                        ' Mach if < 10.0
        Public MCP_IASBlank As Byte
        Public MCP_IASOverspeedFlash As Byte
        Public MCP_IASUnderspeedFlash As Byte
        Public MCP_Heading As UShort
        Public MCP_Altitude As UShort
        Public MCP_VertSpeed As Short
        Public MCP_VertSpeedBlank As Byte

        Public MCP_FDSw1 As Byte
        Public MCP_FDSw2 As Byte

        Public MCP_ATArmSw As Byte
        Public MCP_BankLimitSel As Byte                 '0: 10 ... 4: 3
        Public MCP_DisengageBar As Byte

        Public MCP_annunFD1 As Byte
        Public MCP_annunFD2 As Byte

        Public MCP_annunATArm As Byte
        Public MCP_annunN1 As Byte
        Public MCP_annunSPEED As Byte
        Public MCP_annunVNAV As Byte
        Public MCP_annunLVL_CHG As Byte
        Public MCP_annunHDG_SEL As Byte
        Public MCP_annunLNAV As Byte
        Public MCP_annunVOR_LOC As Byte
        Public MCP_annunAPP As Byte
        Public MCP_annunALT_HOLD As Byte
        Public MCP_annunVS As Byte
        Public MCP_annunCMD_A As Byte
        Public MCP_annunCWS_A As Byte
        Public MCP_annunCMD_B As Byte
        Public MCP_annunCWS_B As Byte

        'Forward panel
        Public MAIN_NoseWheelSteeringSwNORM As Byte     ' false: ALT

        Public MAIN_annunBELOW_GS1 As Byte
        Public MAIN_annunBELOW_GS2 As Byte

        Public MAIN_MainPanelDUSel1 As Byte '0: OUTBD PFD ... 4 MFD for Capt; reverse sequence for FO
        Public MAIN_MainPanelDUSel2 As Byte '0: OUTBD PFD ... 4 MFD for Capt; reverse sequence for FO

        Public MAIN_LowerDUSel1 As Byte '0: ENG PRI ... 2 ND for Capt; reverse sequence for FO
        Public MAIN_LowerDUSel2 As Byte '0: ENG PRI ... 2 ND for Capt; reverse sequence for FO

        Public MAIN_annunAP1 As Byte
        Public MAIN_annunAP2 As Byte

        Public MAIN_annunAT1 As Byte
        Public MAIN_annunAT2 As Byte

        Public MAIN_annunFMC1 As Byte
        Public MAIN_annunFMC2 As Byte

        Public MAIN_DisengageTestSelector1 As Byte  '0: 1  1: OFF  2: 2
        Public MAIN_DisengageTestSelector2 As Byte  '0: 1  1: OFF  2: 2

        Public MAIN_annunSPEEDBRAKE_ARMED As Byte
        Public MAIN_annunSPEEDBRAKE_DO_NOT_ARM As Byte
        Public MAIN_annunSPEEDBRAKE_EXTENDED As Byte
        Public MAIN_annunSTAB_OUT_OF_TRIM As Byte
        Public MAIN_LightsSelector As Byte              '0: TEST  1: BRT  2: DIM
        Public MAIN_RMISelector1_VOR As Byte
        Public MAIN_RMISelector2_VOR As Byte
        Public MAIN_N1SetSelector As Byte               '0: 2  1: 1  2: AUTO  3: BOTH
        Public MAIN_SpdRefSelector As Byte              '0: SET  1: AUTO  2: V1  3: VR  4: WT  5: VREF  6: Bug  
        Public MAIN_FuelFlowSelector As Byte                '0: RESET  1: RATE  2: USED
        Public MAIN_AutobrakeSelector As Byte               '0: RTO  1: OFF ... 5: MAX
        Public MAIN_annunANTI_SKID_INOP As Byte
        Public MAIN_annunAUTO_BRAKE_DISARM As Byte
        Public MAIN_annunLE_FLAPS_TRANSIT As Byte
        Public MAIN_annunLE_FLAPS_EXT As Byte

        Public MAIN_TEFlapsNeedle1 As Single   'Value
        Public MAIN_TEFlapsNeedle2 As Single   'Value

        Public MAIN_annunGEAR_transit1 As Byte
        Public MAIN_annunGEAR_transit2 As Byte
        Public MAIN_annunGEAR_transit3 As Byte

        Public MAIN_annunGEAR_locked1 As Byte
        Public MAIN_annunGEAR_locked2 As Byte
        Public MAIN_annunGEAR_locked3 As Byte

        Public MAIN_GearLever As Byte                   '0: UP  1: OFF  2: DOWN
        Public MAIN_BrakePressNeedle As Single                          'Value 

        Public HGS_annun_AIII As Byte
        Public HGS_annun_NO_AIII As Byte
        Public HGS_annun_FLARE As Byte
        Public HGS_annun_RO As Byte
        Public HGS_annun_RO_CTN As Byte
        Public HGS_annun_RO_ARM As Byte
        Public HGS_annun_TO As Byte
        Public HGS_annun_TO_CTN As Byte
        Public HGS_annun_APCH As Byte
        Public HGS_annun_TO_WARN As Byte
        Public HGS_annun_Bar As Byte
        Public HGS_annun_FAIL As Byte

        'Lower forward panel

        Public LTS_MainPanelKnob1 As Byte  'Position 0...150
        Public LTS_MainPanelKnob2 As Byte  'Position 0...150

        Public LTS_BackgroundKnob As Byte               ' Position 0...150
        Public LTS_AFDSFloodKnob As Byte                ' Position 0...150

        Public LTS_OutbdDUBrtKnob1 As Byte  'Position 0...127
        Public LTS_OutbdDUBrtKnob2 As Byte  'Position 0...127

        Public LTS_InbdDUBrtKnob1 As Byte  'Position 0...127   
        Public LTS_InbdDUBrtKnob2 As Byte  'Position 0...127   

        Public LTS_InbdDUMapBrtKnob1 As Byte  'Position 0...127
        Public LTS_InbdDUMapBrtKnob2 As Byte  'Position 0...127

        Public LTS_UpperDUBrtKnob As Byte               ' Position 0...127
        Public LTS_LowerDUBrtKnob As Byte               ' Position 0...127
        Public LTS_LowerDUMapBrtKnob As Byte                ' Position 0...127

        Public GPWS_annunINOP As Byte
        Public GPWS_FlapInhibitSw_NORM As Byte
        Public GPWS_GearInhibitSw_NORM As Byte
        Public GPWS_TerrInhibitSw_NORM As Byte

        'Control Stand
        Public CDU_annunEXEC1 As Byte
        Public CDU_annunEXEC2 As Byte

        Public CDU_annunCALL1 As Byte
        Public CDU_annunCALL2 As Byte

        Public CDU_annunFAIL1 As Byte
        Public CDU_annunFAIL2 As Byte

        Public CDU_annunMSG1 As Byte
        Public CDU_annunMSG2 As Byte

        Public CDU_annunOFST1 As Byte
        Public CDU_annunOFST2 As Byte

        Public CDU_BrtKnob1 As Byte    'Position 0...127
        Public CDU_BrtKnob2 As Byte    'Position 0...127

        Public TRIM_StabTrimMainElecSw_NORMAL As Byte
        Public TRIM_StabTrimAutoPilotSw_NORMAL As Byte
        Public PED_annunParkingBrake As Byte

        Public FIRE_OvhtDetSw1 As Byte '0: A  1: NORMAL  2: B
        Public FIRE_OvhtDetSw2 As Byte '0: A  1: NORMAL  2: B

        Public FIRE_annunENG_OVERHEAT1 As Byte
        Public FIRE_annunENG_OVERHEAT2 As Byte

        Public FIRE_DetTestSw As Byte                   '0: FAULT/INOP  1: neutral  2: OVHT/FIRE

        Public FIRE_HandlePos1 As Byte '0: In  1: Blocked  2: Out  3: Turned Left  4: Turned right
        Public FIRE_HandlePos2 As Byte '0: In  1: Blocked  2: Out  3: Turned Left  4: Turned right
        Public FIRE_HandlePos3 As Byte '0: In  1: Blocked  2: Out  3: Turned Left  4: Turned right

        Public FIRE_HandleIlluminated1 As Byte
        Public FIRE_HandleIlluminated2 As Byte
        Public FIRE_HandleIlluminated3 As Byte

        Public FIRE_annunWHEEL_WELL As Byte
        Public FIRE_annunFAULT As Byte
        Public FIRE_annunAPU_DET_INOP As Byte
        Public FIRE_annunAPU_BOTTLE_DISCHARGE As Byte

        Public FIRE_annunBOTTLE_DISCHARGE1 As Byte
        Public FIRE_annunBOTTLE_DISCHARGE2 As Byte

        Public FIRE_ExtinguisherTestSw As Byte          ' 0: 1  1: neutral  2: 2

        Public FIRE_annunExtinguisherTest1 As Byte   'Left, Right, APU
        Public FIRE_annunExtinguisherTest2 As Byte   'Left, Right, APU
        Public FIRE_annunExtinguisherTest3 As Byte   'Left, Right, APU

        Public CARGO_annunExtTest1 As Byte           'Fwd, Aft
        Public CARGO_annunExtTest2 As Byte           'Fwd, Aft

        Public CARGO_DetSelect1 As Byte              '0: A  1: ORM  2: B
        Public CARGO_DetSelect2 As Byte              '0: A  1: ORM  2: B

        Public CARGO_ArmedSw1 As Byte
        Public CARGO_ArmedSw2 As Byte

        Public CARGO_annunFWD As Byte
        Public CARGO_annunAFT As Byte
        Public CARGO_annunDETECTOR_FAULT As Byte
        Public CARGO_annunDISCH As Byte

        Public HGS_annunRWY As Byte
        Public HGS_annunGS As Byte
        Public HGS_annunFAULT As Byte
        Public HGS_annunCLR As Byte

        Public XPDR_XpndrSelector_2 As Byte             ' false: 1  true: 2
        Public XPDR_AltSourceSel_2 As Byte              ' false: 1  true: 2
        Public XPDR_ModeSel As Byte                     ' 0: STBY  1: ALT RPTG OFF ... 4: TA/RA
        Public XPDR_annunFAIL As Byte

        Public LTS_PedFloodKnob As Byte                 ' Position 0...150
        Public LTS_PedPanelKnob As Byte                 ' Position 0...150

        Public TRIM_StabTrimSw_NORMAL As Byte
        Public PED_annunLOCK_FAIL As Byte
        Public PED_annunAUTO_UNLK As Byte
        Public PED_FltDkDoorSel As Byte                 ' 0: UNLKD  1 AUTO pushed in  2: AUTO  3: DENY


        'Additional variable: used by FS2Crew
        Public ENG_StartValve1 As Byte    'true: valve open
        Public ENG_StartValve2 As Byte    'true: valve open

        Public AIR_DuctPress1 As Single   'PSI
        Public AIR_DuctPress2 As Single   'PSI

        Public COMM_Attend_PressCount As Byte             ' incremented with each button press
        Public COMM_GrdCall_PressCount As Byte            ' incremented with each button press

        Public COMM_SelectedMic1 As Byte  'array: 0=capt, 1=F/O, 2=observer.
        Public COMM_SelectedMic2 As Byte  'array: 0=capt, 1=F/O, 2=observer.
        Public COMM_SelectedMic3 As Byte  'array: 0=capt, 1=F/O, 2=observer.

        'values: 0=VHF1  1=VHF2  2=VHF3  3=HF1  4=HF2  5=FLT  6=SVC  7=PA
        Public FUEL_QtyCenter As Single          'LBS
        Public FUEL_QtyLeft As Single            'LBS
        Public FUEL_QtyRight As Single           'LBS
        Public IRS_aligned As Byte           ' at least one IRU is aligned
        Public AircraftModel As Byte             ' 1: -600  2: -700  3: -700WL  4: -800  5: -800WL  6: -900  7: -900ER
        Public WeightInKg As Byte            ' false: LBS  true: KG
        Public GPWS_V1CallEnabled As Byte        ' GPWS V1 cDOOR_annunLEFT_FWD_OVERWINGallout option enabled
        Public GroundConnAvailable As Byte       ' can connect/disconnect ground air/electrics

        Public FMC_TakeoffFlaps As Byte           ' degrees, 0 if not set
        Public FMC_V1 As Byte                  ' knots, 0 if not set
        Public FMC_VR As Byte                  ' knots, 0 if not set
        Public FMC_V2 As Byte                  ' knots, 0 if not set
        Public FMC_LandingFlaps As Byte            ' degrees, 0 if not set
        Public FMC_LandingVREF As Byte         ' knots, 0 if not set
        Public FMC_CruiseAlt As UShort         ' ft, 0 if not set
        Public FMC_LandingAltitude As Short        ' ft; -32767 if not available
        Public FMC_TransitionAlt As UShort      ' ft
        Public FMC_TransitionLevel As UShort        ' ft
        Public FMC_PerfInputComplete As Byte
        Public FMC_DistanceToTOD As Single      ' nm; 0.0 if passed, negative if n/a
        Public FMC_DistanceToDest As Single     ' nm; negative if n/a

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Public FMC_flightNumber As Char()

        'New variables for SP2
        Public COMM_ReceiverSwitches1 As UInt32    'Bit flags for selector receivers (see ACP_SEL_RECV_VHF1 etc): [0]=Capt, [1]=FO, [2]=Overhead
        Public COMM_ReceiverSwitches2 As UInt32    'Bit flags for selector receivers (see ACP_SEL_RECV_VHF1 etc): [0]=Capt, [1]=FO, [2]=Overhead
        Public COMM_ReceiverSwitches3 As UInt32    'Bit flags for selector receivers (see ACP_SEL_RECV_VHF1 etc): [0]=Capt, [1]=FO, [2]=Overhead

        Public MAIN_annunAP_Amber1 As Byte         'Amber color
        Public MAIN_annunAP_Amber2 As Byte         'Amber color

        Public MAIN_annunAT_Amber1 As Byte         'Amber color
        Public MAIN_annunAT_Amber2 As Byte         'Amber color

        Public ICE_WindowHeatTestSw As Integer      '0: OVHT  1: Neutral  2: PWR TEST
        Public DOOR_annunFWD_ENTRY As Byte
        Public DOOR_annunFWD_SERVICE As Byte
        Public DOOR_annunAIRSTAIR As Byte
        Public DOOR_annunLEFT_FWD_OVERWING As Byte
        Public DOOR_annunRIGHT_FWD_OVERWING As Byte
        Public DOOR_annunFWD_CARGO As Byte
        Public DOOR_annunEQUIP As Byte
        Public DOOR_annunLEFT_AFT_OVERWING As Byte
        Public DOOR_annunRIGHT_AFT_OVERWING As Byte
        Public DOOR_annunAFT_CARGO As Byte
        Public DOOR_annunAFT_ENTRY As Byte
        Public DOOR_annunAFT_SERVICE As Byte
        Public AIR_annunAUTO_FAIL As Byte
        Public AIR_annunOFFSCHED_DESCENT As Byte
        Public AIR_annunALTN As Byte
        Public AIR_annunMANUAL As Byte
        Public AIR_CabinAltNeedle As Single        'Value - ft
        Public AIR_CabinDPNeedle As Single         'Value - PSI
        Public AIR_CabinVSNeedle As Single         'Value - ft/min
        Public AIR_CabinValveNeedle As Single      'Value - 0 (closed) .. 1 (open)
        Public AIR_TemperatureNeedle As Single     'Value - degrees C

        Public AIR_DuctPressNeedle1 As Single      'Value - degrees C
        Public AIR_DuctPressNeedle2 As Single      'Value - degrees C
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=13)> Public ELEC_MeterDisplayTop As Char()      'Top line of the display:    3 groups of 4 digits (Or symbols) + terminating zero 
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=13)> Public ELEC_MeterDisplayBottom As Char()   'Bottom line of the display
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public IRS_DisplayLeft As Char()            'Left display string, zero terminated
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public IRS_DisplayRight As Char()           'Right display string, zero terminated
        Public IRS_DisplayShowsDots As Byte                 'True If the degrees And Decimal dot symbols are shown On the IRS display

        '<MarshalAs(UnmanagedType.ByValArray, SizeConst:=156)> Public reserved As Byte()

    End Structure


    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)>
    Public Structure PMDG_NGX_Control
        Public [Event] As PMDGEvents ' "Event" is used in VB.Net -> "[Event]"
        Public Parameter As UInt32
    End Structure

    'Events and ID's
    Public Const MOUSE_FLAG_RIGHTSINGLE As UInt32 = &H80000000UI
    Public Const MOUSE_FLAG_MIDDLESINGLE As UInt32 = &H40000000
    Public Const MOUSE_FLAG_LEFTSINGLE As UInt32 = &H20000000
    Public Const MOUSE_FLAG_RIGHTDOUBLE As UInt32 = &H10000000
    Public Const MOUSE_FLAG_MIDDLEDOUBLE As UInt32 = &H8000000
    Public Const MOUSE_FLAG_LEFTDOUBLE As UInt32 = &H4000000
    Public Const MOUSE_FLAG_RIGHTDRAG As UInt32 = &H2000000
    Public Const MOUSE_FLAG_MIDDLEDRAG As UInt32 = &H1000000
    Public Const MOUSE_FLAG_LEFTDRAG As UInt32 = &H800000
    Public Const MOUSE_FLAG_MOVE As UInt32 = &H400000
    Public Const MOUSE_FLAG_DOWN_REPEAT As UInt32 = &H200000
    Public Const MOUSE_FLAG_RIGHTRELEASE As UInt32 = &H80000
    Public Const MOUSE_FLAG_MIDDLERELEASE As UInt32 = &H40000
    Public Const MOUSE_FLAG_LEFTRELEASE As UInt32 = &H20000
    Public Const MOUSE_FLAG_WHEEL_FLIP As UInt32 = &H10000      'invert direction of mouse wheel
    Public Const MOUSE_FLAG_WHEEL_SKIP As UInt32 = &H8000      'look at next 2 rect for mouse wheel commands 
    Public Const MOUSE_FLAG_WHEEL_UP As UInt32 = &H4000
    Public Const MOUSE_FLAG_WHEEL_DOWN As UInt32 = &H2000
    'Eventos ID realmente usados
    Public Enum PMDGEventID As UInt32
        MOUSE_FLAG_RIGHTSINGLE = &H80000000UI
        MOUSE_FLAG_MIDDLESINGLE = &H40000000
        MOUSE_FLAG_LEFTSINGLE = &H20000000
        MOUSE_FLAG_RIGHTDOUBLE = &H10000000
        MOUSE_FLAG_MIDDLEDOUBLE = &H8000000
        MOUSE_FLAG_LEFTDOUBLE = &H4000000
        MOUSE_FLAG_RIGHTDRAG = &H2000000
        MOUSE_FLAG_MIDDLEDRAG = &H1000000
        MOUSE_FLAG_LEFTDRAG = &H800000
        MOUSE_FLAG_MOVE = &H400000
        MOUSE_FLAG_DOWN_REPEAT = &H200000
        MOUSE_FLAG_RIGHTRELEASE = &H80000
        MOUSE_FLAG_MIDDLERELEASE = &H40000
        MOUSE_FLAG_LEFTRELEASE = &H20000
        MOUSE_FLAG_WHEEL_FLIP = &H10000      'invert direction of mouse wheel
        MOUSE_FLAG_WHEEL_SKIP = &H8000      'look at next 2 rect for mouse wheel commands 
        MOUSE_FLAG_WHEEL_UP = &H4000
        MOUSE_FLAG_WHEEL_DOWN = &H2000
        'ID CORTOS (RESUMIDOS)
        UP = &H4000
        DOWN = &H2000
    End Enum

    Public Const THIRD_PARTY_EVENT_ID_MIN As UInt32 = &H11000   'equals to 69632


    'EVENTS
    Public Enum PMDGEvents As UInteger
        'Public Enum PMDGEvents As UInt32

        'Overhead - Electric
        OH_ELEC_BATTERY_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 1)   '01 - BAT Switch
        OH_ELEC_BATTERY_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 2)   '02 - BAT Switch Guard 


        OH_ELEC_DC_METER = (THIRD_PARTY_EVENT_ID_MIN + 3)       ' 03 - DC SOURCE Knob					
        OH_ELEC_AC_METER = (THIRD_PARTY_EVENT_ID_MIN + 4)       ' 04 - AC SOURCE Knob					
        OH_ELEC_GALLEY = (THIRD_PARTY_EVENT_ID_MIN + 974)   ' 974- GALLEY Switch [-600/700 only]				
        OH_ELEC_CAB_UTIL = (THIRD_PARTY_EVENT_ID_MIN + 5)       ' 05 - CAB UTIL Switch	[-800/900 only]			
        OH_ELEC_IFE = (THIRD_PARTY_EVENT_ID_MIN + 6)        ' 06 - IFE/PASS Switch	[-800/900 only]
        OH_ELEC_STBY_PWR_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 10)       ' 10 - STANDBY POWER Switch 
        OH_ELEC_STBY_PWR_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 11)        ' 11 - STANDBY POWER Switch Guard
        OH_ELEC_DISCONNECT_1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 12)       ' 12 - GEN DRIVE DISC Left Switch		
        OH_ELEC_DISCONNECT_1_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 13)        ' 13 - GEN DRIVE DISC Left Guard		
        OH_ELEC_DISCONNECT_2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 14)       ' 14 - GEN DRIVE DISC Right Switch	
        OH_ELEC_DISCONNECT_2_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 15)        ' 15 - GEN DRIVE DISC Right Guard 	
        OH_ELEC_GRD_PWR_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 17)        ' 17 - GROUND POWER Switch
        OH_ELEC_BUS_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 18)       ' 18 - BUS TRANSFER Switch 	
        OH_ELEC_BUS_TRANSFER_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 19)        ' 19 - BUS TRANSFER Guard
        OH_ELEC_GEN1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 27)       ' 27 - GENERATOR Left Switch
        OH_ELEC_APU_GEN1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 28)       ' 28 - APU GENERATOR Left Switch
        OH_ELEC_APU_GEN2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 29)       ' 29 - APU GENERATOR RIGHT Switch
        OH_ELEC_GEN2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 30)       ' 30 - GENERATOR RIGHT Switch
        OH_ELEC_MAINT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 93)      ' 93 - ELEC MAINT Switch 

        'Overhead - FUEL Panel
        OH_FUEL_PUMP_1_AFT = (THIRD_PARTY_EVENT_ID_MIN + 37)        ' 37 - FUEL PUMP LEFT AFT Switch 
        OH_FUEL_PUMP_1_FORWARD = (THIRD_PARTY_EVENT_ID_MIN + 38)        ' 38 - FUEL PUMP LEFT FWD Switch 
        OH_FUEL_PUMP_2_FORWARD = (THIRD_PARTY_EVENT_ID_MIN + 39)        ' 39 - FUEL PUMP RIGHT FWD Switch 
        OH_FUEL_PUMP_2_AFT = (THIRD_PARTY_EVENT_ID_MIN + 40)        ' 40 - FUEL PUMP RIGHT AFT Switch 
        OH_FUEL_PUMP_L_CENTER = (THIRD_PARTY_EVENT_ID_MIN + 45)     ' 45 - FUEL PUMP CENTER LEFT Switch 
        OH_FUEL_PUMP_R_CENTER = (THIRD_PARTY_EVENT_ID_MIN + 46)     ' 46 - FUEL PUMP CENTER LEFT Switch 
        OH_FUEL_CROSSFEED = (THIRD_PARTY_EVENT_ID_MIN + 49)             ' 49 - CROSSFEED Selector 

        'Overhead - LIGHTS Panel
        OH_LAND_LIGHTS_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 110)
        OH_LIGHTS_L_RETRACT = (THIRD_PARTY_EVENT_ID_MIN + 111)
        OH_LIGHTS_R_RETRACT = (THIRD_PARTY_EVENT_ID_MIN + 112)
        OH_LIGHTS_L_FIXED = (THIRD_PARTY_EVENT_ID_MIN + 113)
        OH_LIGHTS_R_FIXED = (THIRD_PARTY_EVENT_ID_MIN + 114)
        OH_LIGHTS_L_TURNOFF = (THIRD_PARTY_EVENT_ID_MIN + 115)
        OH_LIGHTS_R_TURNOFF = (THIRD_PARTY_EVENT_ID_MIN + 116)
        OH_LIGHTS_TAXI = (THIRD_PARTY_EVENT_ID_MIN + 117)
        OH_LIGHTS_APU_START = (THIRD_PARTY_EVENT_ID_MIN + 118)
        OH_LIGHTS_L_ENGINE_START = (THIRD_PARTY_EVENT_ID_MIN + 119)
        OH_LIGHTS_IGN_SEL = (THIRD_PARTY_EVENT_ID_MIN + 120)
        OH_LIGHTS_R_ENGINE_START = (THIRD_PARTY_EVENT_ID_MIN + 121)
        OH_LIGHTS_LOGO = (THIRD_PARTY_EVENT_ID_MIN + 122)
        OH_LIGHTS_POS_STROBE = (THIRD_PARTY_EVENT_ID_MIN + 123)
        OH_LIGHTS_ANT_COL = (THIRD_PARTY_EVENT_ID_MIN + 124)
        OH_LIGHTS_WING = (THIRD_PARTY_EVENT_ID_MIN + 125)
        OH_LIGHTS_WHEEL_WELL = (THIRD_PARTY_EVENT_ID_MIN + 126)
        OH_LIGHTS_COMPASS = (THIRD_PARTY_EVENT_ID_MIN + 982)

        'Overhead - Center Part 
        OH_CB_LIGHT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 94)       ' CIRCUIT BREAKER Light Control
        OH_PANEL_LIGHT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 95)        ' PANEL Light Control Decrease
        OH_EC_SUPPLY_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 96)       ' EQUIPMENT COOLING SUPPLY Switch
        OH_EC_EXHAUST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 97)      ' EQUIPMENT COOLING EXHAUST Switch
        OH_EMER_EXIT_LIGHT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 100)    ' EMERGENCY EXIT LIGHTS Switch 
        OH_EMER_EXIT_LIGHT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 101)         ' EMERGENCY EXIT LIGHTS Guard
        OH_NO_SMOKING_LIGHT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 103)   ' NO SMOKING Switch
        OH_FASTEN_BELTS_LIGHT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 104) ' FASTEN BELTS Switch

        'Overhead - Miscellaneous
        OH_ATTND_CALL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 105) ' ATTENDANT CALL Switch 
        OH_GRND_CALL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 106)  ' GROUND CALL Switch 
        OH_WIPER_LEFT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 36)     ' LEFT WIPER Control 
        OH_WIPER_RIGHT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 109)   ' RIGHT WIPER Control
        OH_EFIS_HDG_REF_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 6920)  ' 692A - Heading Reference Switch Toggle - note: ...

        'Overhead - NAVDSP
        OH_NAVDSP_DISPLAYS_SOURCE_SEL = (THIRD_PARTY_EVENT_ID_MIN + 58) ' DISPLAYS SOURCE Selector 
        OH_NAVDSP_CONTROL_PANEL_SEL = (THIRD_PARTY_EVENT_ID_MIN + 59)   ' CONTROL PANEL Select Switch 
        OH_NAVDSP_FMC_SEL = (THIRD_PARTY_EVENT_ID_MIN + 60)             ' FMC Source Select Switch
        OH_NAVDSP_IRS_SEL = (THIRD_PARTY_EVENT_ID_MIN + 61)             ' IRS Transfer Switch 
        OH_NAVDSP_VHF_NAV_SEL = (THIRD_PARTY_EVENT_ID_MIN + 62)         ' VHF NAV Transfer Switch 

        'Overhead - FLTCTRL
        OH_YAW_DAMPER = (THIRD_PARTY_EVENT_ID_MIN + 63) ' YAW DAMPER Switch 
        OH_ALT_FLAPS_MASTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 73)    ' ALTERNATE FLAPS Master Switch 
        OH_ALT_FLAPS_MASTER_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 74) ' ALTERNATE FLAPS Master Guard 
        OH_SPOILER_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 65)   ' SPOILER A Switch 		
        OH_SPOILER_A_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 66)    ' SPOILER A Guard 
        OH_SPOILER_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 67)   ' SPOILER B Switch 
        OH_SPOILER_B_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 68)    ' SPOILER B Guard 
        OH_ALT_FLAPS_POS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 75)   ' ALTERNATE FLAPS Position Switch
        OH_FCTL_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 78)  ' FLIGHT CONTROL A Switch Decrease	
        OH_FCTL_A_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 79)   ' FLIGHT CONTROL A Guard 
        OH_FCTL_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 80)  ' FLIGHT CONTROL B Switch Decrease
        OH_FCTL_B_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 81)   ' FLIGHT CONTROL B Guard 

        'Overhead - CVR
        OH_CVR_TEST = (THIRD_PARTY_EVENT_ID_MIN + 178)
        OH_CVR_ERASE = (THIRD_PARTY_EVENT_ID_MIN + 180)

        'Overhead - HYD
        OH_HYD_ENG1 = (THIRD_PARTY_EVENT_ID_MIN + 165)
        OH_HYD_ELEC2 = (THIRD_PARTY_EVENT_ID_MIN + 167)
        OH_HYD_ELEC1 = (THIRD_PARTY_EVENT_ID_MIN + 168)
        OH_HYD_ENG2 = (THIRD_PARTY_EVENT_ID_MIN + 166)

        'Overhead - ICE
        OH_ICE_WINDOW_HEAT_1 = (THIRD_PARTY_EVENT_ID_MIN + 135)
        OH_ICE_WINDOW_HEAT_2 = (THIRD_PARTY_EVENT_ID_MIN + 136)
        OH_ICE_WINDOW_HEAT_3 = (THIRD_PARTY_EVENT_ID_MIN + 138)
        OH_ICE_WINDOW_HEAT_4 = (THIRD_PARTY_EVENT_ID_MIN + 139)
        OH_ICE_WINDOW_HEAT_TEST = (THIRD_PARTY_EVENT_ID_MIN + 137)
        OH_ICE_PROBE_HEAT_1 = (THIRD_PARTY_EVENT_ID_MIN + 140)
        OH_ICE_PROBE_HEAT_2 = (THIRD_PARTY_EVENT_ID_MIN + 141)
        OH_ICE_TAT_TEST = (THIRD_PARTY_EVENT_ID_MIN + 142) ' was used for "CAPT PITOT" annunciator light
        OH_ICE_WING_ANTIICE = (THIRD_PARTY_EVENT_ID_MIN + 156)
        OH_ICE_ENGINE_ANTIICE_1 = (THIRD_PARTY_EVENT_ID_MIN + 157)
        OH_ICE_ENGINE_ANTIICE_2 = (THIRD_PARTY_EVENT_ID_MIN + 158)

        'Overhead - PNEU  -600/700 panel only
        OH_AIRCOND_TEMP_SOURCE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 187)
        OH_AIRCOND_TEMP_SELECTOR_CONT = (THIRD_PARTY_EVENT_ID_MIN + 191)
        OH_AIRCOND_TEMP_SELECTOR_CABIN = (THIRD_PARTY_EVENT_ID_MIN + 192)
        OH_AIRCOND_TYPE_600_LAST = OH_AIRCOND_TEMP_SELECTOR_CABIN

        '-800/900 panel only
        OH_AIRCOND_TEMP_SOURCE_SELECTOR_800 = (THIRD_PARTY_EVENT_ID_MIN + 313)
        OH_AIRCOND_TEMP_SELECTOR_CONT_800 = (THIRD_PARTY_EVENT_ID_MIN + 305)
        OH_AIRCOND_TEMP_SELECTOR_FWD_800 = (THIRD_PARTY_EVENT_ID_MIN + 306)
        OH_AIRCOND_TEMP_SELECTOR_AFT_800 = (THIRD_PARTY_EVENT_ID_MIN + 307)
        OH_AIRCOND_TRIM_AIR_SWITCH_800 = (THIRD_PARTY_EVENT_ID_MIN + 311)

        OH_BLEED_RECIRC_FAN_L_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 872)
        OH_BLEED_RECIRC_FAN_R_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 196)
        OH_BLEED_OVHT_TEST_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 199)
        OH_BLEED_PACK_L_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 200)
        OH_BLEED_PACK_R_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 201)
        OH_BLEED_ISOLATION_VALVE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 202)
        OH_BLEED_TRIP_RESET_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 209)
        OH_BLEED_ENG_1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 210)
        OH_BLEED_APU_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 211)
        OH_BLEED_ENG_2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 212)

        'Overhead - Cabin Press
        OH_PRESS_FLT_ALT_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 218)
        OH_PRESS_LAND_ALT_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 220)
        OH_PRESS_VALVE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 222)
        OH_PRESS_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 223)

        'Overhead - Cabin Alt
        OH_CAB_ALT_HORN_CUTOUT_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 183)

        'Aft Overhead - LE Devices
        OH_LE_DEVICES_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 224)

        'Aft Overhead - Service Interphone Switch
        OH_SERVICE_INTERPHONE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 257)

        'Aft Overhead - Dome Switch
        OH_DOME_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 258)

        'Aft Overhead - ISDU panel
        ISDU_DSPL_SEL = (THIRD_PARTY_EVENT_ID_MIN + 229)    ' ISDU DiSPLay SELector
        ISDU_FIRST = ISDU_DSPL_SEL
        ISDU_DSPL_SEL_BRT = (THIRD_PARTY_EVENT_ID_MIN + 230) ' ISDU DiSPLay SELector BRT (Brightness)
        ISDU_SYS_DSPL = (THIRD_PARTY_EVENT_ID_MIN + 231)    ' ISDU SYS DSPL  
        ISDU_KBD_1 = (THIRD_PARTY_EVENT_ID_MIN + 232)   ' ISDU KEYBOARD 1
        ISDU_KBD_2 = (THIRD_PARTY_EVENT_ID_MIN + 233)   ' ISDU KEYBOARD 2 or N
        ISDU_KBD_3 = (THIRD_PARTY_EVENT_ID_MIN + 234)   ' ISDU KEYBOARD 3
        ISDU_KBD_4 = (THIRD_PARTY_EVENT_ID_MIN + 235)   ' ISDU KEYBOARD 4 or W
        ISDU_KBD_5 = (THIRD_PARTY_EVENT_ID_MIN + 236)   ' ISDU KEYBOARD 5 or H
        ISDU_KBD_6 = (THIRD_PARTY_EVENT_ID_MIN + 237)   ' ISDU KEYBOARD 6 or E
        ISDU_KBD_7 = (THIRD_PARTY_EVENT_ID_MIN + 238)   ' ISDU KEYBOARD 7
        ISDU_KBD_8 = (THIRD_PARTY_EVENT_ID_MIN + 239)   ' ISDU KEYBOARD 8 or S
        ISDU_KBD_9 = (THIRD_PARTY_EVENT_ID_MIN + 240)   ' ISDU KEYBOARD 9
        ISDU_KBD_ENT = (THIRD_PARTY_EVENT_ID_MIN + 241) ' ISDU KEYBOARD ENTer
        ISDU_KBD_0 = (THIRD_PARTY_EVENT_ID_MIN + 243)   ' ISDU KEYBOARD 0
        ISDU_KBD_CLR = (THIRD_PARTY_EVENT_ID_MIN + 244) ' ISDU KEYBOARD CLR
        IRU_MSU_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 255) ' LEFT IRS Mode Selector Unit 
        IRU_MSU_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 256)    ' RIGHT IRS Mode Selector Unit
        ISDU_LAST = IRU_MSU_RIGHT

        WLAN_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 888)
        WLAN_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 889)

        'Aft Overhead - Engine control
        OH_EEC_L_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 267)
        OH_EEC_L_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 268)
        OH_EEC_R_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 270)
        OH_EEC_R_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 271)

        'Aft Overhead - Oxygen
        OH_OXY_PASS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 264)
        OH_OXY_PASS_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 265)
        OH_OXY_TEST_RESET_SWITCH_L = (THIRD_PARTY_EVENT_ID_MIN + 983)
        OH_OXY_TEST_RESET_SWITCH_R = (THIRD_PARTY_EVENT_ID_MIN + 9832)
        OH_OXY_RED_BUTTON_L = (THIRD_PARTY_EVENT_ID_MIN + 9831)
        OH_OXY_RED_BUTTON_R = (THIRD_PARTY_EVENT_ID_MIN + 9833)

        'Aft Overhead - Flt Rec & Warning
        OH_FLTREC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 298)
        OH_FLTREC_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 299)
        OH_WARNING_TEST_MACH_IAS_1_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 301)
        OH_WARNING_TEST_MACH_IAS_2_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 302)
        OH_WARNING_TEST_STALL_1_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 303)
        OH_WARNING_TEST_STALL_2_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 304)

        'Overhead - test gauge
        OH_TRIM_AIR_SWITCH_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 15200)      ' user clicks a switch
        OH_WING_BODY_OVERHEAT_TEST_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 15201)    ' user pushes a pushbutton 

        'Integrated Standby Flight Display - ISFD
        ISFD_APP = (THIRD_PARTY_EVENT_ID_MIN + 987)
        ISFD_HP_IN = (THIRD_PARTY_EVENT_ID_MIN + 986)
        ISFD_PLUS = (THIRD_PARTY_EVENT_ID_MIN + 988)
        ISFD_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 989)
        ISFD_ATT_RST = (THIRD_PARTY_EVENT_ID_MIN + 990)
        ISFD_BARO = (THIRD_PARTY_EVENT_ID_MIN + 991)
        ISFD_BARO_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 993)

        'Analog standby instruments
        STANDBY_ADI_APPR_MODE = (THIRD_PARTY_EVENT_ID_MIN + 474)
        STANDBY_ADI_CAGE_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 476)
        STANDBY_ALT_BARO_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 492)
        RMI_LEFT_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 497)
        RMI_RIGHT_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 498)

        'MCP
        MCP_COURSE_SELECTOR_L = (THIRD_PARTY_EVENT_ID_MIN + 376)
        MCP_FD_SWITCH_L = (THIRD_PARTY_EVENT_ID_MIN + 378)
        MCP_AT_ARM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 380)
        MCP_N1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 381)
        MCP_SPEED_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 382)
        MCP_CO_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 383)
        MCP_SPEED_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 384)
        MCP_VNAV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 386)
        MCP_SPD_INTV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 387)
        MCP_BANK_ANGLE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 389)
        MCP_HEADING_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 390)
        MCP_LVL_CHG_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 391)
        MCP_HDG_SEL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 392)
        MCP_APP_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 393)
        MCP_ALT_HOLD_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 394)
        MCP_VS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 395)
        MCP_VOR_LOC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 396)
        MCP_LNAV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 397)
        MCP_ALTITUDE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 400)
        MCP_VS_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 401)
        MCP_CMD_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 402)
        MCP_CMD_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 403)
        MCP_CWS_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 404)
        MCP_CWS_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 405)
        MCP_DISENGAGE_BAR = (THIRD_PARTY_EVENT_ID_MIN + 406)
        MCP_FD_SWITCH_R = (THIRD_PARTY_EVENT_ID_MIN + 407)
        MCP_COURSE_SELECTOR_R = (THIRD_PARTY_EVENT_ID_MIN + 409)
        MCP_ALT_INTV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 885)

        'EFIS Captain control panel
        '---------NOTE: Order in captain and F/O sides must be same, and events in both sides must increase by 1-------
        EFIS_CPT_MINIMUMS = (THIRD_PARTY_EVENT_ID_MIN + 355)
        EFIS_CPT_FIRST = EFIS_CPT_MINIMUMS
        EFIS_CPT_MINIMUMS_RADIO_BARO = (THIRD_PARTY_EVENT_ID_MIN + 356)
        EFIS_CPT_MINIMUMS_RST = (THIRD_PARTY_EVENT_ID_MIN + 357)
        EFIS_CPT_VOR_ADF_SELECTOR_L = (THIRD_PARTY_EVENT_ID_MIN + 358)
        EFIS_CPT_MODE = (THIRD_PARTY_EVENT_ID_MIN + 359)
        EFIS_CPT_MODE_CTR = (THIRD_PARTY_EVENT_ID_MIN + 360)
        EFIS_CPT_RANGE = (THIRD_PARTY_EVENT_ID_MIN + 361)
        EFIS_CPT_RANGE_TFC = (THIRD_PARTY_EVENT_ID_MIN + 362)
        EFIS_CPT_FPV = (THIRD_PARTY_EVENT_ID_MIN + 363)
        EFIS_CPT_MTRS = (THIRD_PARTY_EVENT_ID_MIN + 364)
        EFIS_CPT_BARO = (THIRD_PARTY_EVENT_ID_MIN + 365)
        EFIS_CPT_BARO_IN_HPA = (THIRD_PARTY_EVENT_ID_MIN + 366)
        EFIS_CPT_BARO_STD = (THIRD_PARTY_EVENT_ID_MIN + 367)
        EFIS_CPT_VOR_ADF_SELECTOR_R = (THIRD_PARTY_EVENT_ID_MIN + 368)
        EFIS_CPT_WXR = (THIRD_PARTY_EVENT_ID_MIN + 369)
        EFIS_CPT_STA = (THIRD_PARTY_EVENT_ID_MIN + 370)
        EFIS_CPT_WPT = (THIRD_PARTY_EVENT_ID_MIN + 371)
        EFIS_CPT_ARPT = (THIRD_PARTY_EVENT_ID_MIN + 372)
        EFIS_CPT_DATA = (THIRD_PARTY_EVENT_ID_MIN + 373)
        EFIS_CPT_POS = (THIRD_PARTY_EVENT_ID_MIN + 374)
        EFIS_CPT_TERR = (THIRD_PARTY_EVENT_ID_MIN + 375)
        EFIS_CPT_LAST = EFIS_CPT_TERR

        'EFIS F/O control panels
        EFIS_FO_MINIMUMS = (THIRD_PARTY_EVENT_ID_MIN + 411)
        EFIS_FO_FIRST = EFIS_FO_MINIMUMS
        EFIS_FO_MINIMUMS_RADIO_BARO = (THIRD_PARTY_EVENT_ID_MIN + 412)
        EFIS_FO_MINIMUMS_RST = (THIRD_PARTY_EVENT_ID_MIN + 413)
        EFIS_FO_VOR_ADF_SELECTOR_L = (THIRD_PARTY_EVENT_ID_MIN + 414)
        EFIS_FO_MODE = (THIRD_PARTY_EVENT_ID_MIN + 415)
        EFIS_FO_MODE_CTR = (THIRD_PARTY_EVENT_ID_MIN + 416)
        EFIS_FO_RANGE = (THIRD_PARTY_EVENT_ID_MIN + 417)
        EFIS_FO_RANGE_TFC = (THIRD_PARTY_EVENT_ID_MIN + 418)
        EFIS_FO_FPV = (THIRD_PARTY_EVENT_ID_MIN + 419)
        EFIS_FO_MTRS = (THIRD_PARTY_EVENT_ID_MIN + 420)
        EFIS_FO_BARO = (THIRD_PARTY_EVENT_ID_MIN + 421)
        EFIS_FO_BARO_IN_HPA = (THIRD_PARTY_EVENT_ID_MIN + 422)
        EFIS_FO_BARO_STD = (THIRD_PARTY_EVENT_ID_MIN + 423)
        EFIS_FO_VOR_ADF_SELECTOR_R = (THIRD_PARTY_EVENT_ID_MIN + 424)
        EFIS_FO_WXR = (THIRD_PARTY_EVENT_ID_MIN + 425)
        EFIS_FO_STA = (THIRD_PARTY_EVENT_ID_MIN + 426)
        EFIS_FO_WPT = (THIRD_PARTY_EVENT_ID_MIN + 427)
        EFIS_FO_ARPT = (THIRD_PARTY_EVENT_ID_MIN + 428)
        EFIS_FO_DATA = (THIRD_PARTY_EVENT_ID_MIN + 429)
        EFIS_FO_POS = (THIRD_PARTY_EVENT_ID_MIN + 430)
        EFIS_FO_TERR = (THIRD_PARTY_EVENT_ID_MIN + 431)
        EFIS_FO_LAST = EFIS_FO_TERR

        'Display select panels
        DSP_CPT_BELOW_GS_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 327)  ' CAPT Side BELOW GS INHIBIT Pushbutton
        DSP_CPT_MAIN_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 335) ' CAPT side MAIN PANEL DISPLAY UNITS (MAIN PANEL DUs) Selector 
        DSP_CPT_LOWER_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 336)    ' CAPT side LOWER DISPLAY UNIT (LOWER DU) Selector 
        DSP_CPT_DISENGAGE_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 342)    ' CAPT side DISENGAGE LIGHTS TEST switch
        DSP_CPT_AP_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 339)  ' CAPT Side AP RESET Pushbutton
        DSP_CPT_AT_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 340)  ' CAPT Side AT RESET Pushbutton
        DSP_CPT_FMC_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 341) ' CAPT Side FMC RESET Pushbutton
        DSP_CPT_MASTER_LIGHTS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 346) ' MASTER LIGHTS & TEST switch
        DSP_CPT_LAST = DSP_CPT_MASTER_LIGHTS_SWITCH ' Keep this the last of CAPT side DSP panel items and before the F/O DSP panel items start
        DSP_FO_MAIN_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 440)  ' FO side MAIN PANEL DISPLAY UNITS (MAIN PANEL DUs) Selector 
        DSP_FO_LOWER_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 441) ' FO side LOWER DISPLAY UNIT (LOWER DU) Selector 
        DSP_FO_DISENGAGE_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 442) ' FO side DISENGAGE LIGHTS TEST switch
        DSP_FO_FMC_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 443)  ' FO Side FMC RESET Pushbutton
        DSP_FO_AT_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 444)   ' FO Side AT RESET Pushbutton
        DSP_FO_AP_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 445)   ' FO Side AP RESET Pushbutton
        DSP_FO_BELOW_GS_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 446)   ' FO Side BELOW GS INHIBIT Pushbutton

        'Main panel misc
        MPM_AUTOBRAKE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 460)
        MPM_MFD_SYS_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 462)
        MPM_MFD_ENG_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 463)
        MPM_MFD_C_R_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 4621)
        MPM_SPEED_REFERENCE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 464)
        MPM_SPEED_REFERENCE_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 465)
        MPM_N1SET_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 466)
        MPM_N1SET_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 467)
        MPM_FUEL_FLOW_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 468)

        'Gear panel
        GEAR_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 455)
        GEAR_LEVER_OFF = (THIRD_PARTY_EVENT_ID_MIN + 4551)
        GEAR_LEVER_UNLOCK = (THIRD_PARTY_EVENT_ID_MIN + 4552)

        'Nose Wheel Steering
        NOSE_WHEEL_STEERING_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 325)
        NOSE_WHEEL_STEERING_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 326)
        TILLER = (THIRD_PARTY_EVENT_ID_MIN + 975)

        'Warning/caution
        FIRE_WARN_LIGHT_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 347)   ' 347 - Master Fire Warning (FIRE WARN) Light Left Switch Toggle
        MASTER_CAUTION_LIGHT_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 348)  ' 348 - MASTER CAUTION Light Left Switch Toggle
        FIRE_WARN_LIGHT_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 439)
        MASTER_CAUTION_LIGHT_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 438)
        SYSTEM_ANNUNCIATOR_PANEL_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 349)
        SYSTEM_ANNUNCIATOR_PANEL_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 437)

        'Lower Main
        LWRMAIN_CAPT_MAIN_PANEL_BRT = (THIRD_PARTY_EVENT_ID_MIN + 328)
        LWRMAIN_CAPT_OUTBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 329)
        LWRMAIN_CAPT_INBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 330)
        LWRMAIN_CAPT_INBD_DU_INNER_BRT = (THIRD_PARTY_EVENT_ID_MIN + 331)
        LWRMAIN_CAPT_LOWER_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 332)
        LWRMAIN_CAPT_LOWER_DU_INNER_BRT = (THIRD_PARTY_EVENT_ID_MIN + 333)
        LWRMAIN_CAPT_UPPER_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 334)
        LWRMAIN_CAPT_BACKGROUND_BRT = (THIRD_PARTY_EVENT_ID_MIN + 337)
        LWRMAIN_CAPT_AFDS_BRT = (THIRD_PARTY_EVENT_ID_MIN + 338)
        LWRMAIN_FO_INBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 507)
        LWRMAIN_FO_INBD_DU_INNER_BRT = (THIRD_PARTY_EVENT_ID_MIN + 508)
        LWRMAIN_FO_MAIN_PANEL_BRT = (THIRD_PARTY_EVENT_ID_MIN + 510)
        LWRMAIN_FO_OUTBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 509)

        'GPWS
        GPWS_SYS_TEST_BTN = (THIRD_PARTY_EVENT_ID_MIN + 500)
        GPWS_FLAP_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 501)
        GPWS_FLAP_INHIBIT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 502)
        GPWS_GEAR_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 503)
        GPWS_GEAR_INHIBIT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 504)
        GPWS_TERR_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 505)
        GPWS_TERR_INHIBIT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 506)

        'Chronometers
        CHRONO_L_CHR = (THIRD_PARTY_EVENT_ID_MIN + 314)
        CHRONO_L_TIME_DATE = (THIRD_PARTY_EVENT_ID_MIN + 315)
        CHRONO_L_SET = (THIRD_PARTY_EVENT_ID_MIN + 316)
        CHRONO_L_PLUS = (THIRD_PARTY_EVENT_ID_MIN + 317)
        CHRONO_L_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 318)
        CHRONO_L_RESET = (THIRD_PARTY_EVENT_ID_MIN + 320)
        CHRONO_L_ET = (THIRD_PARTY_EVENT_ID_MIN + 321)
        CHRONO_R_CHR = (THIRD_PARTY_EVENT_ID_MIN + 523)
        CHRONO_R_TIME_DATE = (THIRD_PARTY_EVENT_ID_MIN + 524)
        CHRONO_R_SET = (THIRD_PARTY_EVENT_ID_MIN + 525)
        CHRONO_R_PLUS = (THIRD_PARTY_EVENT_ID_MIN + 526)
        CHRONO_R_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 527)
        CHRONO_R_RESET = (THIRD_PARTY_EVENT_ID_MIN + 529)
        CHRONO_R_ET = (THIRD_PARTY_EVENT_ID_MIN + 530)
        CLOCK_L = (THIRD_PARTY_EVENT_ID_MIN + 890)
        CLOCK_R = (THIRD_PARTY_EVENT_ID_MIN + 893)

        'Control Stand
        CONTROL_STAND_TRIM_WHEEL = (THIRD_PARTY_EVENT_ID_MIN + 678)
        CONTROL_STAND_SPEED_BRAKE_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 679)
        CONTROL_STAND_SPEED_BRAKE_LEVER_DOWN = (THIRD_PARTY_EVENT_ID_MIN + 6791)
        CONTROL_STAND_SPEED_BRAKE_LEVER_ARM = (THIRD_PARTY_EVENT_ID_MIN + 6792)
        CONTROL_STAND_SPEED_BRAKE_LEVER_50PCT = (THIRD_PARTY_EVENT_ID_MIN + 6793)
        CONTROL_STAND_SPEED_BRAKE_LEVER_FLT_DET = (THIRD_PARTY_EVENT_ID_MIN + 6794)
        CONTROL_STAND_SPEED_BRAKE_LEVER_UP = (THIRD_PARTY_EVENT_ID_MIN + 6795)
        CONTROL_STAND_REV_THRUST1_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 680)
        CONTROL_STAND_REV_THRUST2_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 681)
        CONTROL_STAND_FWD_THRUST1_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 683)
        CONTROL_STAND_FWD_THRUST2_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 686)
        CONTROL_STAND_TOGA1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 684)
        CONTROL_STAND_TOGA2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 687)
        CONTROL_STAND_AT1_DISENGAGE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 682)
        CONTROL_STAND_AT2_DISENGAGE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 685)
        CONTROL_STAND_ENG1_START_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 688)
        CONTROL_STAND_ENG2_START_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 689)
        CONTROL_STAND_PARK_BRAKE_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 693)
        CONTROL_STAND_STABTRIM_ELEC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 709)
        CONTROL_STAND_STABTRIM_ELEC_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 710)
        CONTROL_STAND_STABTRIM_AP_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 711)
        CONTROL_STAND_STABTRIM_AP_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 712)
        CONTROL_STAND_HORN_CUTOUT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 713)
        CONTROL_STAND_FLAPS_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 714)
        CONTROL_STAND_FLAPS_LEVER_0 = (THIRD_PARTY_EVENT_ID_MIN + 7141)
        CONTROL_STAND_FLAPS_LEVER_1 = (THIRD_PARTY_EVENT_ID_MIN + 7142)
        CONTROL_STAND_FLAPS_LEVER_2 = (THIRD_PARTY_EVENT_ID_MIN + 7143)
        CONTROL_STAND_FLAPS_LEVER_5 = (THIRD_PARTY_EVENT_ID_MIN + 7144)
        CONTROL_STAND_FLAPS_LEVER_10 = (THIRD_PARTY_EVENT_ID_MIN + 7145)
        CONTROL_STAND_FLAPS_LEVER_15 = (THIRD_PARTY_EVENT_ID_MIN + 7146)
        CONTROL_STAND_FLAPS_LEVER_25 = (THIRD_PARTY_EVENT_ID_MIN + 7147)
        CONTROL_STAND_FLAPS_LEVER_30 = (THIRD_PARTY_EVENT_ID_MIN + 7148)
        CONTROL_STAND_FLAPS_LEVER_40 = (THIRD_PARTY_EVENT_ID_MIN + 7149)

        'FLT  DK DOOR Panel
        FLT_DK_DOOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 834)
        STAB_TRIM_OVRD_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 830)
        STAB_TRIM_OVRD_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 831)

        'VHF Panels
        NAV1_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 729)
        NAV1_FIRST = NAV1_TRANSFER_SWITCH
        NAV1_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 731)
        NAV1_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 732)
        NAV1_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 733)
        NAV1_LAST = NAV1_OUTER_SELECTOR
        NAV2_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 845)
        NAV2_FIRST = NAV2_TRANSFER_SWITCH
        NAV2_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 847)
        NAV2_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 848)
        NAV2_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 849)
        NAV2_LAST = NAV2_INNER_SELECTOR

        'ADF Panel
        ADF_MODE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 818)
        ADF_TONE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 820)
        ADF_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 822)
        ADF_MIDDLE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 823)
        ADF_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 824)
        ADF_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 827)

        'SELCAL Panel
        SELCAL_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 812)
        SELCAL_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 813)
        SELCAL_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 814)
        SELCAL_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 937)
        SELCAL_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 938)

        'COMM Panels
        COM1_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 721)
        COM1_START_RANGE1 = COM1_TRANSFER_SWITCH
        COM1_HF_SENSOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 724)
        COM1_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 725)
        COM1_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 726)
        COM1_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 727)
        COM1_END_RANGE1 = COM1_INNER_SELECTOR
        COM1_PNL_OFF_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 903)
        COM1_START_RANGE2 = COM1_PNL_OFF_SWITCH
        COM1_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 904)
        COM1_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 906)
        COM1_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 908)
        COM1_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 910)
        COM1_AM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 912)
        COM1_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 914)
        COM1_END_RANGE2 = COM1_HF2_SWITCH

        COM2_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 837)
        COM2_START_RANGE1 = COM2_TRANSFER_SWITCH
        COM2_HF_SENSOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 840)
        COM2_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 841)
        COM2_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 842)
        COM2_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 843)
        COM2_END_RANGE1 = COM2_INNER_SELECTOR
        COM2_PNL_OFF_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 924)
        COM2_START_RANGE2 = COM2_PNL_OFF_SWITCH
        COM2_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 925)
        COM2_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 927)
        COM2_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 929)
        COM2_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 931)
        COM2_AM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 933)
        COM2_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 935)
        COM2_END_RANGE2 = COM2_HF2_SWITCH

        COM3_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 946)
        COM3_START_RANGE1 = COM3_TRANSFER_SWITCH
        COM3_HF_SENSOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 949)
        COM3_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 950)
        COM3_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 951)
        COM3_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 952)
        COM3_END_RANGE1 = COM3_INNER_SELECTOR
        COM3_PNL_OFF_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 953)
        COM3_START_RANGE2 = COM3_PNL_OFF_SWITCH
        COM3_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 954)
        COM3_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 956)
        COM3_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 958)
        COM3_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 960)
        COM3_AM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 962)
        COM3_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 964)
        COM3_END_RANGE2 = COM3_HF2_SWITCH

        'Audio Control Panels
        'Captain ACP (at aft electronic panel)
        ACP_CAPT_MIC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 734)
        ACP_CAPT_MIC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 735)
        ACP_CAPT_MIC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 877) ' out of order
        ACP_CAPT_MIC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 878) ' out of order
        ACP_CAPT_MIC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 879) ' out of order
        ACP_CAPT_MIC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 736)
        ACP_CAPT_MIC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 737)
        ACP_CAPT_MIC_PA = (THIRD_PARTY_EVENT_ID_MIN + 738)

        ACP_CAPT_REC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 739)
        ACP_CAPT_REC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 740)
        ACP_CAPT_REC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 741)
        ACP_CAPT_REC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 742)
        ACP_CAPT_REC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 880) ' out of order
        ACP_CAPT_REC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 743)
        ACP_CAPT_REC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 744)
        ACP_CAPT_REC_PA = (THIRD_PARTY_EVENT_ID_MIN + 745)
        ACP_CAPT_REC_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 746)
        ACP_CAPT_REC_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 747)
        ACP_CAPT_REC_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 748)
        ACP_CAPT_REC_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 749)
        ACP_CAPT_REC_MKR = (THIRD_PARTY_EVENT_ID_MIN + 750)
        ACP_CAPT_REC_SPKR = (THIRD_PARTY_EVENT_ID_MIN + 751)

        ACP_CAPT_RT_IC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 752)
        ACP_CAPT_MASK_BOOM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 753)
        ACP_CAPT_FILTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 754)
        ACP_CAPT_ALT_NORM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 755)

        ACP_CAPT_FIRST1 = ACP_CAPT_MIC_VHF1
        ACP_CAPT_LAST1 = ACP_CAPT_ALT_NORM_SWITCH
        ACP_CAPT_FIRST2 = ACP_CAPT_MIC_VHF3
        ACP_CAPT_LAST2 = ACP_CAPT_REC_HF2

        'F/O ACP (at aft electronic panel)
        ACP_FO_MIC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 850)
        ACP_FO_MIC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 851)
        ACP_FO_MIC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 881) ' out of order
        ACP_FO_MIC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 882)  ' out of order
        ACP_FO_MIC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 883)  ' out of order
        ACP_FO_MIC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 852)
        ACP_FO_MIC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 853)
        ACP_FO_MIC_PA = (THIRD_PARTY_EVENT_ID_MIN + 854)

        ACP_FO_REC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 855)
        ACP_FO_REC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 856)
        ACP_FO_REC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 857)
        ACP_FO_REC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 858)
        ACP_FO_REC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 884)  ' out of order
        ACP_FO_REC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 859)
        ACP_FO_REC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 860)
        ACP_FO_REC_PA = (THIRD_PARTY_EVENT_ID_MIN + 861)
        ACP_FO_REC_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 862)
        ACP_FO_REC_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 863)
        ACP_FO_REC_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 864)
        ACP_FO_REC_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 865)
        ACP_FO_REC_MKR = (THIRD_PARTY_EVENT_ID_MIN + 866)
        ACP_FO_REC_SPKR = (THIRD_PARTY_EVENT_ID_MIN + 867)

        ACP_FO_VOL_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 1862) ' 1000 added for volume rotation event
        ACP_FO_VOL_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 1863)
        ACP_FO_VOL_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 1864)
        ACP_FO_VOL_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 1865)
        ACP_FO_VOL_MKR = (THIRD_PARTY_EVENT_ID_MIN + 1866)

        ACP_FO_RT_IC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 868)
        ACP_FO_MASK_BOOM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 869)
        ACP_FO_FILTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 870)
        ACP_FO_ALT_NORM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 871)

        ACP_FO_FIRST1 = ACP_FO_MIC_VHF1
        ACP_FO_LAST1 = ACP_FO_ALT_NORM_SWITCH
        ACP_FO_FIRST2 = ACP_FO_MIC_VHF3
        ACP_FO_LAST2 = ACP_FO_REC_HF2

        'Observer ACP(at aft electronic panel)
        ACP_OBS_MIC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 291)
        ACP_OBS_MIC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 292)
        ACP_OBS_MIC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 293)
        ACP_OBS_MIC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 294)
        ACP_OBS_MIC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 295)
        ACP_OBS_MIC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 296)
        ACP_OBS_MIC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 297)
        ACP_OBS_MIC_PA = (THIRD_PARTY_EVENT_ID_MIN + 873) ' out of order

        ACP_OBS_REC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 286)
        ACP_OBS_REC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 287)
        ACP_OBS_REC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 874) ' out of order
        ACP_OBS_REC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 875) ' out of order
        ACP_OBS_REC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 876) ' out of order
        ACP_OBS_REC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 288)
        ACP_OBS_REC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 289)
        ACP_OBS_REC_PA = (THIRD_PARTY_EVENT_ID_MIN + 290)
        ACP_OBS_REC_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 280)
        ACP_OBS_REC_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 281)
        ACP_OBS_REC_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 282)
        ACP_OBS_REC_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 283)
        ACP_OBS_REC_MKR = (THIRD_PARTY_EVENT_ID_MIN + 284)
        ACP_OBS_REC_SPKR = (THIRD_PARTY_EVENT_ID_MIN + 285)

        ACP_OBS_VOL_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 1280) ' 1000 added for volume rotation event
        ACP_OBS_VOL_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 1281)
        ACP_OBS_VOL_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 1282)
        ACP_OBS_VOL_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 1283)
        ACP_OBS_VOL_MKR = (THIRD_PARTY_EVENT_ID_MIN + 1284)

        ACP_OBS_RT_IC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 276)
        ACP_OBS_MASK_BOOM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 277)
        ACP_OBS_FILTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 278)
        ACP_OBS_ALT_NORM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 279)

        ACP_OBS_FIRST1 = ACP_OBS_RT_IC_SWITCH
        ACP_OBS_LAST1 = ACP_OBS_MIC_SVC
        ACP_OBS_FIRST2 = ACP_OBS_MIC_PA
        ACP_OBS_LAST2 = ACP_OBS_REC_HF2

        'TCAS
        TCAS_XPNDR = (THIRD_PARTY_EVENT_ID_MIN + 798)
        TCAS_MODE = (THIRD_PARTY_EVENT_ID_MIN + 800)
        TCAS_TEST = (THIRD_PARTY_EVENT_ID_MIN + 801)
        TCAS_ALTSOURCE = (THIRD_PARTY_EVENT_ID_MIN + 803)
        TCAS_KNOB1 = (THIRD_PARTY_EVENT_ID_MIN + 804)
        TCAS_KNOB2 = (THIRD_PARTY_EVENT_ID_MIN + 805)
        TCAS_IDENT = (THIRD_PARTY_EVENT_ID_MIN + 806)
        TCAS_KNOB4 = (THIRD_PARTY_EVENT_ID_MIN + 807)
        TCAS_KNOB3 = (THIRD_PARTY_EVENT_ID_MIN + 808)

        'HUD control panel
        HUD_MODE = (THIRD_PARTY_EVENT_ID_MIN + 770)
        HUD_STB = (THIRD_PARTY_EVENT_ID_MIN + 771)
        HUD_RWY = (THIRD_PARTY_EVENT_ID_MIN + 772)
        HUD_GS = (THIRD_PARTY_EVENT_ID_MIN + 773)
        HUD_CLR = (THIRD_PARTY_EVENT_ID_MIN + 775)
        HUD_BRT = (THIRD_PARTY_EVENT_ID_MIN + 776)
        HUD_DIM = (THIRD_PARTY_EVENT_ID_MIN + 777)
        HUD_1 = (THIRD_PARTY_EVENT_ID_MIN + 778)
        HUD_2 = (THIRD_PARTY_EVENT_ID_MIN + 779)
        HUD_3 = (THIRD_PARTY_EVENT_ID_MIN + 780)
        HUD_4 = (THIRD_PARTY_EVENT_ID_MIN + 781)
        HUD_5 = (THIRD_PARTY_EVENT_ID_MIN + 782)
        HUD_6 = (THIRD_PARTY_EVENT_ID_MIN + 783)
        HUD_7 = (THIRD_PARTY_EVENT_ID_MIN + 784)
        HUD_8 = (THIRD_PARTY_EVENT_ID_MIN + 785)
        HUD_9 = (THIRD_PARTY_EVENT_ID_MIN + 786)
        HUD_0 = (THIRD_PARTY_EVENT_ID_MIN + 788)
        HUD_ENTER = (THIRD_PARTY_EVENT_ID_MIN + 787)
        HUD_TEST = (THIRD_PARTY_EVENT_ID_MIN + 789)
        HUD_STOW = (THIRD_PARTY_EVENT_ID_MIN + 979)
        HUD_BRIGTHNESS = (THIRD_PARTY_EVENT_ID_MIN + 980)
        HUD_AUTO_MAN = (THIRD_PARTY_EVENT_ID_MIN + 981)

        'HUD Annunciator Panel
        HGS_FAIL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 522)

        'CDU
        CDU_L_L1 = (THIRD_PARTY_EVENT_ID_MIN + 534)
        CDU_L_L2 = (THIRD_PARTY_EVENT_ID_MIN + 535)
        CDU_L_L3 = (THIRD_PARTY_EVENT_ID_MIN + 536)
        CDU_L_L4 = (THIRD_PARTY_EVENT_ID_MIN + 537)
        CDU_L_L5 = (THIRD_PARTY_EVENT_ID_MIN + 538)
        CDU_L_L6 = (THIRD_PARTY_EVENT_ID_MIN + 539)
        CDU_L_R1 = (THIRD_PARTY_EVENT_ID_MIN + 540)
        CDU_L_R2 = (THIRD_PARTY_EVENT_ID_MIN + 541)
        CDU_L_R3 = (THIRD_PARTY_EVENT_ID_MIN + 542)
        CDU_L_R4 = (THIRD_PARTY_EVENT_ID_MIN + 543)
        CDU_L_R5 = (THIRD_PARTY_EVENT_ID_MIN + 544)
        CDU_L_R6 = (THIRD_PARTY_EVENT_ID_MIN + 545)
        CDU_L_INIT_REF = (THIRD_PARTY_EVENT_ID_MIN + 546)
        CDU_L_RTE = (THIRD_PARTY_EVENT_ID_MIN + 547)
        CDU_L_CLB = (THIRD_PARTY_EVENT_ID_MIN + 548)
        CDU_L_CRZ = (THIRD_PARTY_EVENT_ID_MIN + 549)
        CDU_L_DES = (THIRD_PARTY_EVENT_ID_MIN + 550)
        CDU_L_MENU = (THIRD_PARTY_EVENT_ID_MIN + 551)
        CDU_L_LEGS = (THIRD_PARTY_EVENT_ID_MIN + 552)
        CDU_L_DEP_ARR = (THIRD_PARTY_EVENT_ID_MIN + 553)
        CDU_L_HOLD = (THIRD_PARTY_EVENT_ID_MIN + 554)
        CDU_L_PROG = (THIRD_PARTY_EVENT_ID_MIN + 555)
        CDU_L_EXEC = (THIRD_PARTY_EVENT_ID_MIN + 556)
        CDU_L_N1_LIMIT = (THIRD_PARTY_EVENT_ID_MIN + 557)
        CDU_L_FIX = (THIRD_PARTY_EVENT_ID_MIN + 558)
        CDU_L_PREV_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 559)
        CDU_L_NEXT_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 560)
        CDU_L_1 = (THIRD_PARTY_EVENT_ID_MIN + 561)
        CDU_L_2 = (THIRD_PARTY_EVENT_ID_MIN + 562)
        CDU_L_3 = (THIRD_PARTY_EVENT_ID_MIN + 563)
        CDU_L_4 = (THIRD_PARTY_EVENT_ID_MIN + 564)
        CDU_L_5 = (THIRD_PARTY_EVENT_ID_MIN + 565)
        CDU_L_6 = (THIRD_PARTY_EVENT_ID_MIN + 566)
        CDU_L_7 = (THIRD_PARTY_EVENT_ID_MIN + 567)
        CDU_L_8 = (THIRD_PARTY_EVENT_ID_MIN + 568)
        CDU_L_9 = (THIRD_PARTY_EVENT_ID_MIN + 569)
        CDU_L_DOT = (THIRD_PARTY_EVENT_ID_MIN + 570)
        CDU_L_0 = (THIRD_PARTY_EVENT_ID_MIN + 571)
        CDU_L_PLUS_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 572)
        CDU_L_A = (THIRD_PARTY_EVENT_ID_MIN + 573)
        CDU_L_B = (THIRD_PARTY_EVENT_ID_MIN + 574)
        CDU_L_C = (THIRD_PARTY_EVENT_ID_MIN + 575)
        CDU_L_D = (THIRD_PARTY_EVENT_ID_MIN + 576)
        CDU_L_E = (THIRD_PARTY_EVENT_ID_MIN + 577)
        CDU_L_F = (THIRD_PARTY_EVENT_ID_MIN + 578)
        CDU_L_G = (THIRD_PARTY_EVENT_ID_MIN + 579)
        CDU_L_H = (THIRD_PARTY_EVENT_ID_MIN + 580)
        CDU_L_I = (THIRD_PARTY_EVENT_ID_MIN + 581)
        CDU_L_J = (THIRD_PARTY_EVENT_ID_MIN + 582)
        CDU_L_K = (THIRD_PARTY_EVENT_ID_MIN + 583)
        CDU_L_L = (THIRD_PARTY_EVENT_ID_MIN + 584)
        CDU_L_M = (THIRD_PARTY_EVENT_ID_MIN + 585)
        CDU_L_N = (THIRD_PARTY_EVENT_ID_MIN + 586)
        CDU_L_O = (THIRD_PARTY_EVENT_ID_MIN + 587)
        CDU_L_P = (THIRD_PARTY_EVENT_ID_MIN + 588)
        CDU_L_Q = (THIRD_PARTY_EVENT_ID_MIN + 589)
        CDU_L_R = (THIRD_PARTY_EVENT_ID_MIN + 590)
        CDU_L_S = (THIRD_PARTY_EVENT_ID_MIN + 591)
        CDU_L_T = (THIRD_PARTY_EVENT_ID_MIN + 592)
        CDU_L_U = (THIRD_PARTY_EVENT_ID_MIN + 593)
        CDU_L_V = (THIRD_PARTY_EVENT_ID_MIN + 594)
        CDU_L_W = (THIRD_PARTY_EVENT_ID_MIN + 595)
        CDU_L_X = (THIRD_PARTY_EVENT_ID_MIN + 596)
        CDU_L_Y = (THIRD_PARTY_EVENT_ID_MIN + 597)
        CDU_L_Z = (THIRD_PARTY_EVENT_ID_MIN + 598)
        CDU_L_SPACE = (THIRD_PARTY_EVENT_ID_MIN + 599)
        CDU_L_DEL = (THIRD_PARTY_EVENT_ID_MIN + 600)
        CDU_L_SLASH = (THIRD_PARTY_EVENT_ID_MIN + 601)
        CDU_L_CLR = (THIRD_PARTY_EVENT_ID_MIN + 602)
        CDU_L_BRITENESS = (THIRD_PARTY_EVENT_ID_MIN + 605)

        CDU_R_L1 = (THIRD_PARTY_EVENT_ID_MIN + 606)
        CDU_R_L2 = (THIRD_PARTY_EVENT_ID_MIN + 607)
        CDU_R_L3 = (THIRD_PARTY_EVENT_ID_MIN + 608)
        CDU_R_L4 = (THIRD_PARTY_EVENT_ID_MIN + 609)
        CDU_R_L5 = (THIRD_PARTY_EVENT_ID_MIN + 610)
        CDU_R_L6 = (THIRD_PARTY_EVENT_ID_MIN + 611)
        CDU_R_R1 = (THIRD_PARTY_EVENT_ID_MIN + 612)
        CDU_R_R2 = (THIRD_PARTY_EVENT_ID_MIN + 613)
        CDU_R_R3 = (THIRD_PARTY_EVENT_ID_MIN + 614)
        CDU_R_R4 = (THIRD_PARTY_EVENT_ID_MIN + 615)
        CDU_R_R5 = (THIRD_PARTY_EVENT_ID_MIN + 616)
        CDU_R_R6 = (THIRD_PARTY_EVENT_ID_MIN + 617)
        CDU_R_INIT_REF = (THIRD_PARTY_EVENT_ID_MIN + 618)
        CDU_R_RTE = (THIRD_PARTY_EVENT_ID_MIN + 619)
        CDU_R_CLB = (THIRD_PARTY_EVENT_ID_MIN + 620)
        CDU_R_CRZ = (THIRD_PARTY_EVENT_ID_MIN + 621)
        CDU_R_DES = (THIRD_PARTY_EVENT_ID_MIN + 622)
        CDU_R_MENU = (THIRD_PARTY_EVENT_ID_MIN + 623)
        CDU_R_LEGS = (THIRD_PARTY_EVENT_ID_MIN + 624)
        CDU_R_DEP_ARR = (THIRD_PARTY_EVENT_ID_MIN + 625)
        CDU_R_HOLD = (THIRD_PARTY_EVENT_ID_MIN + 626)
        CDU_R_PROG = (THIRD_PARTY_EVENT_ID_MIN + 627)
        CDU_R_EXEC = (THIRD_PARTY_EVENT_ID_MIN + 628)
        CDU_R_N1_LIMIT = (THIRD_PARTY_EVENT_ID_MIN + 629)
        CDU_R_FIX = (THIRD_PARTY_EVENT_ID_MIN + 630)
        CDU_R_PREV_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 631)
        CDU_R_NEXT_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 632)
        CDU_R_1 = (THIRD_PARTY_EVENT_ID_MIN + 633)
        CDU_R_2 = (THIRD_PARTY_EVENT_ID_MIN + 634)
        CDU_R_3 = (THIRD_PARTY_EVENT_ID_MIN + 635)
        CDU_R_4 = (THIRD_PARTY_EVENT_ID_MIN + 636)
        CDU_R_5 = (THIRD_PARTY_EVENT_ID_MIN + 637)
        CDU_R_6 = (THIRD_PARTY_EVENT_ID_MIN + 638)
        CDU_R_7 = (THIRD_PARTY_EVENT_ID_MIN + 639)
        CDU_R_8 = (THIRD_PARTY_EVENT_ID_MIN + 640)
        CDU_R_9 = (THIRD_PARTY_EVENT_ID_MIN + 641)
        CDU_R_DOT = (THIRD_PARTY_EVENT_ID_MIN + 642)
        CDU_R_0 = (THIRD_PARTY_EVENT_ID_MIN + 643)
        CDU_R_PLUS_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 644)
        CDU_R_A = (THIRD_PARTY_EVENT_ID_MIN + 645)
        CDU_R_B = (THIRD_PARTY_EVENT_ID_MIN + 646)
        CDU_R_C = (THIRD_PARTY_EVENT_ID_MIN + 647)
        CDU_R_D = (THIRD_PARTY_EVENT_ID_MIN + 648)
        CDU_R_E = (THIRD_PARTY_EVENT_ID_MIN + 649)
        CDU_R_F = (THIRD_PARTY_EVENT_ID_MIN + 650)
        CDU_R_G = (THIRD_PARTY_EVENT_ID_MIN + 651)
        CDU_R_H = (THIRD_PARTY_EVENT_ID_MIN + 652)
        CDU_R_I = (THIRD_PARTY_EVENT_ID_MIN + 653)
        CDU_R_J = (THIRD_PARTY_EVENT_ID_MIN + 654)
        CDU_R_K = (THIRD_PARTY_EVENT_ID_MIN + 655)
        CDU_R_L = (THIRD_PARTY_EVENT_ID_MIN + 656)
        CDU_R_M = (THIRD_PARTY_EVENT_ID_MIN + 657)
        CDU_R_N = (THIRD_PARTY_EVENT_ID_MIN + 658)
        CDU_R_O = (THIRD_PARTY_EVENT_ID_MIN + 659)
        CDU_R_P = (THIRD_PARTY_EVENT_ID_MIN + 660)
        CDU_R_Q = (THIRD_PARTY_EVENT_ID_MIN + 661)
        CDU_R_R = (THIRD_PARTY_EVENT_ID_MIN + 662)
        CDU_R_S = (THIRD_PARTY_EVENT_ID_MIN + 663)
        CDU_R_T = (THIRD_PARTY_EVENT_ID_MIN + 664)
        CDU_R_U = (THIRD_PARTY_EVENT_ID_MIN + 665)
        CDU_R_V = (THIRD_PARTY_EVENT_ID_MIN + 666)
        CDU_R_W = (THIRD_PARTY_EVENT_ID_MIN + 667)
        CDU_R_X = (THIRD_PARTY_EVENT_ID_MIN + 668)
        CDU_R_Y = (THIRD_PARTY_EVENT_ID_MIN + 669)
        CDU_R_Z = (THIRD_PARTY_EVENT_ID_MIN + 670)
        CDU_R_SPACE = (THIRD_PARTY_EVENT_ID_MIN + 671)
        CDU_R_DEL = (THIRD_PARTY_EVENT_ID_MIN + 672)
        CDU_R_SLASH = (THIRD_PARTY_EVENT_ID_MIN + 673)
        CDU_R_CLR = (THIRD_PARTY_EVENT_ID_MIN + 674)
        CDU_R_BRITENESS = (THIRD_PARTY_EVENT_ID_MIN + 677)

        'Fire protection panel
        FIRE_OVHT_DET_SWITCH_1 = (THIRD_PARTY_EVENT_ID_MIN + 694)
        FIRE_DETECTION_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 696)
        FIRE_HANDLE_ENGINE_1_TOP = (THIRD_PARTY_EVENT_ID_MIN + 697)
        FIRE_HANDLE_ENGINE_1_BOTTOM = (THIRD_PARTY_EVENT_ID_MIN + 6971)
        FIRE_HANDLE_APU_TOP = (THIRD_PARTY_EVENT_ID_MIN + 698)
        FIRE_HANDLE_APU_BOTTOM = (THIRD_PARTY_EVENT_ID_MIN + 6981)
        FIRE_HANDLE_ENGINE_2_TOP = (THIRD_PARTY_EVENT_ID_MIN + 699)
        FIRE_HANDLE_ENGINE_2_BOTTOM = (THIRD_PARTY_EVENT_ID_MIN + 6991)
        FIRE_BELL_CUTOUT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 704)
        FIRE_OVHT_DET_SWITCH_2 = (THIRD_PARTY_EVENT_ID_MIN + 705)
        FIRE_EXTINGUISHER_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 715)
        FIRE_UNLOCK_SWITCH_ENGINE_1 = (THIRD_PARTY_EVENT_ID_MIN + 976)
        FIRE_UNLOCK_SWITCH_APU = (THIRD_PARTY_EVENT_ID_MIN + 977)
        FIRE_UNLOCK_SWITCH_ENGINE_2 = (THIRD_PARTY_EVENT_ID_MIN + 978)

        'Cargo Fire
        CARGO_FIRE_DET_SEL_SWITCH_FWD = (THIRD_PARTY_EVENT_ID_MIN + 760)
        CARGO_FIRE_DET_SEL_SWITCH_AFT = (THIRD_PARTY_EVENT_ID_MIN + 761)
        CARGO_FIRE_ARM_SWITCH_FWD = (THIRD_PARTY_EVENT_ID_MIN + 764)
        CARGO_FIRE_ARM_SWITCH_AFT = (THIRD_PARTY_EVENT_ID_MIN + 766)
        CARGO_FIRE_DISC_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 767)
        CARGO_FIRE_DISC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 768)
        CARGO_FIRE_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 769)

        'Flight controls - pedestal
        FCTL_AILERON_TRIM = (THIRD_PARTY_EVENT_ID_MIN + 810)
        FCTL_RUDDER_TRIM = (THIRD_PARTY_EVENT_ID_MIN + 811)

        'Pedestal Lights Controls
        PED_FLOOD_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 756)
        PED_PANEL_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 757)

        'Custom shortcut special events
        LDG_LIGHTS_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 14000)
        TURNOFF_LIGHTS_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 14001)
        COCKPIT_LIGHTS_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 14002)
        COCKPIT_LIGHTS_ON = (THIRD_PARTY_EVENT_ID_MIN + 14003)
        COCKPIT_LIGHTS_OFF = (THIRD_PARTY_EVENT_ID_MIN + 14004)
        DOOR_FWD_L = (THIRD_PARTY_EVENT_ID_MIN + 14005)
        DOOR_FWD_R = (THIRD_PARTY_EVENT_ID_MIN + 14006)
        DOOR_AFT_L = (THIRD_PARTY_EVENT_ID_MIN + 14007)
        DOOR_AFT_R = (THIRD_PARTY_EVENT_ID_MIN + 14008)
        DOOR_OVERWING_EXIT_L = (THIRD_PARTY_EVENT_ID_MIN + 14009)
        DOOR_OVERWING_EXIT_R = (THIRD_PARTY_EVENT_ID_MIN + 14010)
        DOOR_CARGO_FWD = (THIRD_PARTY_EVENT_ID_MIN + 14013)  'note number skip to match eDoors enum
        DOOR_CARGO_AFT = (THIRD_PARTY_EVENT_ID_MIN + 14014)
        DOOR_EQUIPMENT_HATCH = (THIRD_PARTY_EVENT_ID_MIN + 14015)
        DOOR_AIRSTAIR = (THIRD_PARTY_EVENT_ID_MIN + 14016)

        'Yoke Animations
        YOKE_L_COUNTER_1 = (THIRD_PARTY_EVENT_ID_MIN + 998) ' Counters (digits left to right)  
        YOKE_L_COUNTER_2 = (THIRD_PARTY_EVENT_ID_MIN + 999)
        YOKE_L_COUNTER_3 = (THIRD_PARTY_EVENT_ID_MIN + 1000)
        YOKE_R_COUNTER_1 = (THIRD_PARTY_EVENT_ID_MIN + 1001)
        YOKE_R_COUNTER_2 = (THIRD_PARTY_EVENT_ID_MIN + 1002)
        YOKE_R_COUNTER_3 = (THIRD_PARTY_EVENT_ID_MIN + 1003)
        YOKE_L_AP_DISC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 1004)   ' AP Disconnect switches
        YOKE_R_AP_DISC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 1005)

        'MCP Direct Control 
        MCP_CRS_L_SET = (THIRD_PARTY_EVENT_ID_MIN + 14500)  ' Sets MCP course specified by the event parameter
        MCP_CRS_R_SET = (THIRD_PARTY_EVENT_ID_MIN + 14501)
        MCP_IAS_SET = (THIRD_PARTY_EVENT_ID_MIN + 14502)    ' Sets MCP IAS, if IAS mode is active
        MCP_MACH_SET = (THIRD_PARTY_EVENT_ID_MIN + 14503)   ' Sets MCP MACH (if active) to parameter*0.01 (e.g. send 78 to set M0.78)
        MCP_HDG_SET = (THIRD_PARTY_EVENT_ID_MIN + 14504)    ' Sets new heading, commands the shortest turn
        MCP_ALT_SET = (THIRD_PARTY_EVENT_ID_MIN + 14505)
        MCP_VS_SET = (THIRD_PARTY_EVENT_ID_MIN + 14506)     ' Sets MCP VS (if VS window open) to parameter-10000 (e.g. send 8200 for -1800fpm)

        'Panel system events
        CTRL_ACCELERATION_DISABLE = (THIRD_PARTY_EVENT_ID_MIN + 14600)
        CTRL_ACCELERATION_ENABLE = (THIRD_PARTY_EVENT_ID_MIN + 14600)

    End Enum
    Public Enum SIMCONNECT_GROUP_PRIORITY As UInteger
        HIGHEST = 1
        HIGHEST_MASKABLE = 10000000
        STANDARD = 1900000000
        [DEFAULT] = 2000000000
        LOWEST = 4000000000UI
    End Enum
End Class
