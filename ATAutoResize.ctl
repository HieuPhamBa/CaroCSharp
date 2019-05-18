VERSION 5.00
Begin VB.UserControl ATAutoResize 
   CanGetFocus     =   0   'False
   ClientHeight    =   720
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   750
   FillStyle       =   0  'Solid
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   InvisibleAtRuntime=   -1  'True
   Picture         =   "ATAutoResize.ctx":0000
   ScaleHeight     =   720
   ScaleWidth      =   750
   ToolboxBitmap   =   "ATAutoResize.ctx":2132
End
Attribute VB_Name = "ATAutoResize"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
Private Type ControlSettings
    IndexValue                       As Long
    LeftValue                        As Single
    TopValue                         As Single
    WidthValue                       As Single
    HeightValue                      As Single
    FontSizeValue                    As Single
End Type
Private State                    As Boolean
Private FontResize               As Boolean
Private AspectRatio43            As Boolean
Private HM                       As Long
Private WM                       As Long
Private AspectRatioValue43       As Double
Private CtrlTot                  As Long
Private ControlsOnForm()         As ControlSettings
Private ParentWidth              As Single
Private ParentHeight             As Single
Private WithEvents ParentForm    As Form
Attribute ParentForm.VB_VarHelpID = -1
Public Property Get AspectRatioValue() As Double
    On Error GoTo ErrorTrap
    AspectRatioValue = AspectRatioValue43
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.AspectRatioValue" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Let AspectRatioValue(ByVal Value As Double)
    On Error GoTo ErrorTrap
    AspectRatioValue43 = Value
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.AspectRatioValue" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Get Enabled() As Boolean
    On Error GoTo ErrorTrap
    Enabled = State
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.Enabled" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Let Enabled(ByVal Value As Boolean)
    On Error GoTo ErrorTrap
    State = Value
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.Enabled" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Get FontResizable() As Boolean
    On Error GoTo ErrorTrap
    FontResizable = FontResize
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.FontResizable" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Let FontResizable(ByVal Value As Boolean)
    On Error GoTo ErrorTrap
    FontResize = Value
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.FontResizable" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Get HMin() As Long
    On Error GoTo ErrorTrap
    HMin = HM
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.HMin" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Let HMin(ByVal Value As Long)
    On Error GoTo ErrorTrap
    HM = Value
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.HMin" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Get KeepAspectRatio() As Boolean
    On Error GoTo ErrorTrap
    KeepAspectRatio = AspectRatio43
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.KeepAspectRatio" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Let KeepAspectRatio(ByVal Value As Boolean)
    On Error Resume Next
    AspectRatio43 = Value
'if AspectRation enabled, calculates the AspectRatio Value
    If Value Then
        AspectRatioValue = UserControl.Extender.Parent.Height / UserControl.Extender.Parent.Width
    Else
        AspectRatioValue = 0
    End If
    PropertyChanged "KeepAspectRatio"
    On Error GoTo 0
End Property
Private Sub ParentForm_Load()
    On Error GoTo ErrorTrap
    CtrlTot = 0
    StoreOriginalSettings
Exit Sub
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.ParentForm_Load" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Sub
Private Sub ParentForm_Resize()
    On Error GoTo ErrorTrap
'Triggered when the form containing the autoresize control is resized
'If reduced to icon dont't resize
    If ParentForm.WindowState = 1 Then
        GoTo OneExit
    End If
'If the autoresize control is disabled don't resize
    If Not Enabled Then
        GoTo OneExit
    End If
'If form height < than value assigned to HMIN force the parent height to HMIN
    If ParentForm.Height < HMin Then
        ParentForm.Height = HMin
    End If
'same as above for widtyh
    If ParentForm.Width < WMin Then
        ParentForm.Width = WMin
    End If
    UpdateControls 'Resize the controls on the form
OneExit:
Exit Sub
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.ParentForm_Resize" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Sub
Private Sub StoreOriginalSettings()
'This routine runs just once (when the form is loaded)
Dim i         As Integer
Dim Controllo As Control
    On Error Resume Next
'If not running exit
    If Not Ambient.UserMode Then
        GoTo TwoExit
    End If
    ParentWidth = ParentForm.ScaleWidth 'save the original size of the form
    ParentHeight = ParentForm.ScaleHeight
    For i = 0 To ParentForm.Controls.Count - 1  'Loop to check all the controls on the form
        Set Controllo = ParentForm.Controls(i)
        If TypeName(Controllo) = "StatusBar" Then 'if the control is a status bar
'it will be resized only if the Align property is set to none
            If Controllo.Align > 0 Then
                GoTo Skip
            End If
'You can add here other controls that have similar properties
        End If
'The Tag property set to NO prevent the control from resizing
        If Controllo.Tag = "NO" Then
            GoTo Skip
        End If
        CtrlTot = CtrlTot + 1   'Variable to keep the number of controls to resize
        ReDim Preserve ControlsOnForm(1 To CtrlTot)
'Redim the array containing the data needed for resizing
        With ControlsOnForm(CtrlTot)
            .IndexValue = i 'save the index of the control
            If TypeName(Controllo) = "Line" Then
'the line control doesn't have Left, Top.... properties, so you must manage it differently
'you can add here other particular controls - the ones that don't have standard properties
                .LeftValue = Controllo.x1 'save the original size
                .TopValue = Controllo.y1
                .WidthValue = Controllo.x2
                .HeightValue = Controllo.y2
            Else
                If Controllo.Left < 0 And TypeName(Controllo.Container) = "SSTab" Then
                    .LeftValue = Controllo.Left + 75000
'add 75000 to record the correct position of controls not located in the current tab
                Else
                    .LeftValue = Controllo.Left 'save the original size
                End If
                .TopValue = Controllo.Top
                .WidthValue = Controllo.Width
                .HeightValue = Controllo.Height
                .FontSizeValue = Controllo.Font.Size
            End If
        End With
Skip:
    Next i
    On Error GoTo 0
TwoExit:
End Sub
Private Sub UpdateControls()
Dim i                As Integer
Dim FFactor          As Single
Dim WFactor          As Single
Dim HFactor          As Single
Static ChangingRatio As Boolean
    On Error Resume Next
'if not running exit
    If Not Ambient.UserMode Then
        GoTo ThreeExit
    End If
'prevent recursive calls if KeepAspectRatio is True
    If ChangingRatio Then
        GoTo ThreeExit
    End If
    If KeepAspectRatio And AspectRatioValue > 0 And ParentForm.WindowState = 0 Then
'if the form is not icon or maximized
        ChangingRatio = True
        ParentForm.Height = AspectRatioValue * ParentForm.Width
'change the form height to keep aspect ratio
        ChangingRatio = False
    End If
    WFactor = ParentForm.ScaleWidth / ParentWidth
'calculates the increasing or decreasing factor to use
    HFactor = ParentForm.ScaleHeight / ParentHeight
'set the font increasing or decreasing factor to the minimum width-height factor
    If WFactor < HFactor Then
        FFactor = WFactor
    Else
        FFactor = HFactor
    End If
    For i = 1 To CtrlTot 'loop through the controls included in the ControlsOnForm array
        With ControlsOnForm(i)
            If TypeName(ParentForm.Controls(.IndexValue)) = "Line" Then
'if it's a line manage it differently
'if you added other controls in the StoreOriginalSettings routine
'add the same controls here
                ParentForm.Controls(.IndexValue).x1 = .LeftValue * WFactor
                ParentForm.Controls(.IndexValue).y1 = .TopValue * HFactor
                ParentForm.Controls(.IndexValue).x2 = .WidthValue * WFactor
                ParentForm.Controls(.IndexValue).y2 = .HeightValue * HFactor
            Else
'resize the fonts if you enabled Font resizing
                If FontResizable Then
                    ParentForm.Controls(.IndexValue).Font.Size = .FontSizeValue * FFactor
                End If
                If ParentForm.Controls(.IndexValue).Left < 0 And TypeName(ParentForm.Controls(.IndexValue).Container) = "SSTab" Then
                    ParentForm.Controls(.IndexValue).Left = .LeftValue * WFactor - 75000
'subtract 75000 to keep controls hidden (the ones not located in the current tab)
                Else
                    ParentForm.Controls(.IndexValue).Left = .LeftValue * WFactor
'resize the control multiplying the original size for the calculated factor
                End If
                ParentForm.Controls(.IndexValue).Top = .TopValue * HFactor
                ParentForm.Controls(.IndexValue).Width = .WidthValue * WFactor
                ParentForm.Controls(.IndexValue).Height = .HeightValue * HFactor
            End If
        End With
    Next i
    On Error GoTo 0
ThreeExit:
End Sub
Private Sub UserControl_InitProperties()
    On Error GoTo ErrorTrap
'Set Default properties values
    FontResizable = True 'Resizing font enabled
    KeepAspectRatio = False 'Keeping aspect ration disabled
    HMin = 3000 'Set the minimum form Height allowed
    WMin = 4800 'Set the minimum form Width allowed
    AspectRatioValue = 0
'You can set it manually or let the program to do it by enabling KeepAspectRatio property
    Enabled = True  'Autoresize Control enabled
    UserControl.Extender.Tag = "NO" 'Don't include this control among the ones to resize
    UserControl.Extender.Name = "Resize"
'Name to assign to Autoresize control when you put it on a form
Exit Sub
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.UserControl_InitProperties" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Sub
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
    On Error GoTo ErrorTrap
    With PropBag
        FontResizable = .ReadProperty("FontResizable", True)
        KeepAspectRatio = .ReadProperty("KeepAspectRatio", False)
        AspectRatioValue = .ReadProperty("AspectRatioValue", 0)
        Enabled = .ReadProperty("Enabled", True)
        HMin = .ReadProperty("HMin", 3000)
        WMin = .ReadProperty("WMin", 4800)
'If not running exit
    End With 'PropBag
    If Ambient.UserMode Then
        Set ParentForm = UserControl.Parent
'ParentForm is the form containing the autoresize control
    End If
Exit Sub
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.UserControl_ReadProperties" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Sub
Private Sub UserControl_Resize()
    On Error GoTo ErrorTrap
    UserControl.Width = 400 'Width of autoresize control
    UserControl.Height = 400 'Height of autoresize control
Exit Sub
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.UserControl_Resize" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Sub
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)
    On Error GoTo ErrorTrap
'Save the values assigned to properties
    With PropBag
        .WriteProperty "FontResizable", FontResizable, True
        .WriteProperty "KeepAspectRatio", KeepAspectRatio, False
        .WriteProperty "AspectRatioValue", AspectRatioValue
        .WriteProperty "HMin", HMin, 3000
        .WriteProperty "WMin", WMin, 4800
        .WriteProperty "Enabled", Enabled, True
    End With 'PropBag
Exit Sub
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.UserControl_WriteProperties" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Sub
Public Property Get WMin() As Long
    On Error GoTo ErrorTrap
    WMin = WM
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.WMin" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
Public Property Let WMin(ByVal Value As Long)
    On Error GoTo ErrorTrap
    WM = Value
Exit Property
ErrorTrap:
    MsgBox "Error Number: " & Err.Number & vbNewLine & _
       Err.Description & vbNewLine & _
       vbNewLine & _
       "Debug Information:" & vbNewLine & _
       "MidiDateBase.AutoResize.WMin" & IIf(Erl > 0, "." & Erl, ""), vbCritical, "Error Occurred"
End Property
':)Code Fixer V3.0.9 (9/15/2005 1:31:17 PM) 20 + 397 = 417 Lines Thanks Ulli for inspiration and lots of code.


