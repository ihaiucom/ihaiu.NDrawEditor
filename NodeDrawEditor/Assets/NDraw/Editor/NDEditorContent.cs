using System;
using UnityEngine;

namespace ihaiu.NDraws
{
    public static class NDEditorContent
    {
        private const string copyShortcut = " %c";
        private const string cutShortcut = " %x";
        private const string pasteShortcut = " %v";
        private const string selectAllShortcut = " %a";
        private static readonly GUIContent tempContent = new GUIContent();
        public static GUIContent FavoritesLabel
        {
            get;
            private set;
        }
        public static GUIContent ManualUpdate
        {
            get;
            private set;
        }
        public static GUIContent KeepDelayedEvents
        {
            get;
            private set;
        }
        public static GUIContent LockFsmButton
        {
            get;
            private set;
        }
        public static GUIContent MenuGraphViewCopyStates
        {
            get;
            private set;
        }
        public static GUIContent MenuGraphViewPasteStates
        {
            get;
            private set;
        }
        public static GUIContent MenuSelectAllActions
        {
            get;
            private set;
        }
        public static GUIContent MenuCopySelectedActions
        {
            get;
            private set;
        }
        public static GUIContent MenuPasteActions
        {
            get;
            private set;
        }
        public static GUIContent EditCategoryLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalVariableName
        {
            get;
            set;
        }
        public static GUIContent GlobalEventName
        {
            get;
            set;
        }
        public static GUIContent FsmBrowserButton
        {
            get;
            private set;
        }
        public static GUIContent RecentButton
        {
            get;
            private set;
        }
        public static GUIContent BackButton
        {
            get;
            private set;
        }
        public static GUIContent ForwardButton
        {
            get;
            private set;
        }
        public static GUIContent StateBrowserButton
        {
            get;
            private set;
        }
        public static GUIContent BrowseButton
        {
            get;
            private set;
        }
        public static GUIContent HelpButton
        {
            get;
            private set;
        }
        public static GUIContent DeleteButton
        {
            get;
            private set;
        }
        public static GUIContent ResetButton
        {
            get;
            private set;
        }
        public static GUIContent UpButton
        {
            get;
            private set;
        }
        public static GUIContent DownButton
        {
            get;
            private set;
        }
        public static GUIContent VariableButton
        {
            get;
            private set;
        }
        public static GUIContent SettingsButton
        {
            get;
            private set;
        }
        public static GUIContent PopupButton
        {
            get;
            private set;
        }
        public static GUIContent Play
        {
            get;
            private set;
        }
        public static GUIContent Pause
        {
            get;
            private set;
        }
        public static GUIContent Step
        {
            get;
            private set;
        }
        public static GUIContent MainToolbarSelectedGO
        {
            get;
            private set;
        }
        public static GUIContent MainToolbarSelectedFSM
        {
            get;
            private set;
        }
        public static GUIContent MainToolbarLock
        {
            get;
            private set;
        }
        public static GUIContent MainToolbarPrefabTypeNone
        {
            get;
            private set;
        }
        public static GUIContent MainToolbarShowMinimap
        {
            get;
            private set;
        }
        public static GUIContent NewVariableLabel
        {
            get;
            private set;
        }
        public static GUIContent EditVariableLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalVariablesLabel
        {
            get;
            private set;
        }
        public static GUIContent VariableNameLabel
        {
            get;
            private set;
        }
        public static GUIContent VariableTypeLabel
        {
            get;
            private set;
        }
        public static GUIContent VariableValueLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalsLabel
        {
            get;
            private set;
        }
        public static GUIContent VariableUseCountLabel
        {
            get;
            private set;
        }
        public static GUIContent TooltipLabel
        {
            get;
            private set;
        }
        public static GUIContent InspectorLabel
        {
            get;
            private set;
        }
        public static GUIContent NetworkSyncNotSupportedLabel
        {
            get;
            private set;
        }
        public static GUIContent EditVariableTypeLabel
        {
            get;
            private set;
        }
        public static GUIContent AddLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalVariablesNameLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalVariablesTypeLabel
        {
            get;
            private set;
        }
        public static GUIContent AddGlobalVariableLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalVariableUseCountLabel
        {
            get;
            private set;
        }
        public static GUIContent EditEventNameLabel
        {
            get;
            private set;
        }
        public static GUIContent AddEventLabel
        {
            get;
            private set;
        }
        public static GUIContent EventInspectorLabel
        {
            get;
            private set;
        }
        public static GUIContent EventBrowserButtonLabel
        {
            get;
            private set;
        }
        public static GUIContent EventBroadcastIcon
        {
            get;
            private set;
        }
        public static GUIContent EventHeaderLabel
        {
            get;
            private set;
        }
        public static GUIContent EventUsedHeaderLabel
        {
            get;
            private set;
        }
        public static GUIContent GlobalEventTooltipLabel
        {
            get;
            private set;
        }
        public static GUIContent DebugToolbarErrorCount
        {
            get;
            private set;
        }
        public static GUIContent DebugToolbarDebug
        {
            get;
            private set;
        }
        public static GUIContent DebugToolbarPrev
        {
            get;
            private set;
        }
        public static GUIContent DebugToolbarNext
        {
            get;
            private set;
        }
        public static GUIContent StateTitleBox
        {
            get;
            private set;
        }
        public static GUIContent StateDescription
        {
            get;
            private set;
        }
        public static GUIContent FsmDescription
        {
            get;
            private set;
        }
        public static GUIContent EventLabel
        {
            get;
            private set;
        }
        public static GUIContent HintGettingStarted
        {
            get;
            private set;
        }
        public static GUIContent HintGraphShortcuts
        {
            get;
            private set;
        }
        public static GUIContent HintGraphCommands
        {
            get;
            private set;
        }
        public static Vector2 HintGettingStartedSize
        {
            get;
            private set;
        }
        public static Vector2 HintGraphShortcutsSize
        {
            get;
            private set;
        }
        public static Vector2 HintGraphCommandsSize
        {
            get;
            private set;
        }
        public static GUIContent BrowseTemplateButton
        {
            get;
            private set;
        }
        public static GUIContent MaxLoopOverrideLabel
        {
            get;
            private set;
        }
        public static GUIContent ShowStateLabelsLabel
        {
            get;
            private set;
        }
        public static GUIContent EnableBreakpointsLabel
        {
            get;
            private set;
        }
        public static GUIContent EnableDebugFlowLabel
        {
            get;
            private set;
        }
        public static GUIContent ResetOnDisableLabel
        {
            get;
            private set;
        }
        public static GUIContent FsmControlsLabel
        {
            get;
            private set;
        }
        public static GUIContent NetworkSyncLabel
        {
            get;
            private set;
        }
        public static GUIContent UseTemplateLabel
        {
            get;
            private set;
        }
        public static GUIContent RefreshTemplateLabel
        {
            get;
            private set;
        }
        public static GUIContent EditFsmButton
        {
            get;
            private set;
        }
        public static GUIContent ConfirmEditPrefabInstance
        {
            get;
            set;
        }
        public static void Init(bool usingProSkin)
        {
            NDEditorContent.FavoritesLabel = new GUIContent(Strings.Label_Favorites, Strings.Tooltip_Favorites);
            NDEditorContent.ManualUpdate = new GUIContent(Strings.Label_Manual_Update, Strings.Tooltip_ManualUpdate);
            NDEditorContent.KeepDelayedEvents = new GUIContent(Strings.Label_KeepDelayedEvents, Strings.Tooltip_KeepDelayedEvents);
            NDEditorContent.LockFsmButton = new GUIContent(Strings.Label_Lock, Strings.Tooltip_Lock_and_password_protect_FSM);
            NDEditorContent.ConfirmEditPrefabInstance = new GUIContent(Strings.Label_Confirm_Editing_Prefab_Instances, Strings.Tooltip_Disable_editing_of_prefab_intances);
            NDEditorContent.EditFsmButton = new GUIContent(Strings.Label_Edit, Strings.Tooltip_Edit_in_the_PlayMaker_Editor);
            NDEditorContent.RefreshTemplateLabel = new GUIContent(Strings.Label_Refresh_Template, Strings.Tooltip_Refresh_Template);
            NDEditorContent.UseTemplateLabel = new GUIContent(Strings.Label_Use_Template, Strings.Tooltip_Use_Template);
            NDEditorContent.BrowseTemplateButton = new GUIContent(Strings.Label_Browse, Strings.Tooltip_Browse_Templates);
//            NDEditorContent.MaxLoopOverrideLabel = new GUIContent(Strings.Label_Max_Loop_Override, Strings.Tooltip_Max_Loop_Override);
//            NDEditorContent.ShowStateLabelsLabel = new GUIContent(Strings.NDEditorSettings_Show_State_Labels_in_Game_View, Strings.Tooltip_Show_State_Label);
//            NDEditorContent.EnableBreakpointsLabel = new GUIContent(Strings.Label_Enable_Breakpoints, Strings.Tooltip_Enable_Breakpoints);
//            NDEditorContent.EnableDebugFlowLabel = new GUIContent(Strings.NDEditorSettings_Enable_DebugFlow, Strings.NDEditorSettings_Enable_DebugFlow_Tooltip);
//            NDEditorContent.ResetOnDisableLabel = new GUIContent(Strings.Label_Reset_On_Disable, Strings.Tooltip_Reset_On_Disable);
//            NDEditorContent.FsmControlsLabel = new GUIContent(Strings.Label_Controls, Strings.Tooltip_Controls);
//            NDEditorContent.NetworkSyncLabel = new GUIContent(Strings.Label_Network_Sync, Strings.Tooltip_Variables_Set_To_Network_Sync);
//            NDEditorContent.MenuGraphViewCopyStates = new GUIContent(Strings.Menu_GraphView_Copy_States() + " %c");
//            NDEditorContent.MenuGraphViewPasteStates = new GUIContent(Strings.Menu_GraphView_Paste_States() + " %v");
//            NDEditorContent.MenuSelectAllActions = new GUIContent(Strings.Menu_Select_All_Actions() + " %a");
//            NDEditorContent.MenuPasteActions = new GUIContent(Strings.Menu_Paste_Actions() + " %v");
//            NDEditorContent.MenuCopySelectedActions = new GUIContent(Strings.Menu_Copy_Selected_Actions() + " %c");
//            NDEditorContent.EditCategoryLabel = new GUIContent(Strings.Category, Strings.Category_Tooltip);
//            NDEditorContent.GlobalVariableName = new GUIContent(Strings.Variable, Strings.Variable_Tooltip_Warning);
//            NDEditorContent.GlobalEventName = new GUIContent(Strings.Event, Strings.Event_Tooltip_Warning);
//            NDEditorContent.StateBrowserButton = new GUIContent(Files.LoadTextureFromDll("browserIcon", 14, 14), Strings.Command_State_Browser);
//            NDEditorContent.HelpButton = new GUIContent(Files.LoadTextureFromDll("helpIcon", 14, 14), Strings.Tooltip_Doc_Button);
//            NDEditorContent.Play = new GUIContent(Files.LoadTextureFromDll("playButton", 17, 17));
//            NDEditorContent.Pause = new GUIContent(Files.LoadTextureFromDll("pauseButton", 17, 17));
//            NDEditorContent.Step = new GUIContent(Files.LoadTextureFromDll("stepButton", 17, 17));
//            NDEditorContent.NewVariableLabel = new GUIContent(Strings.Label_New_Variable, Strings.Tooltip_New_Variable);
//            NDEditorContent.EditVariableLabel = new GUIContent(Strings.Label_Name);
//            NDEditorContent.GlobalVariablesLabel = new GUIContent(Strings.Label_Global_Variables, Strings.Tooltip_Global_Variables);
//            NDEditorContent.VariableNameLabel = new GUIContent(Strings.Label_Name, Strings.Tooltip_Variable_Name);
//            NDEditorContent.VariableTypeLabel = new GUIContent(Strings.Label_Type, Strings.Tooltip_Variable_Type);
//            NDEditorContent.VariableValueLabel = new GUIContent(Strings.Label_Value);
//            NDEditorContent.GlobalsLabel = new GUIContent(Strings.Label_Globals, Strings.Tooltip_Globals);
//            NDEditorContent.VariableUseCountLabel = new GUIContent(Strings.Label_Used, Strings.Tooltip_Variable_Used_Count);
//            NDEditorContent.TooltipLabel = new GUIContent(Strings.Label_Tooltip, Strings.Tooltip_Tooltip);
//            NDEditorContent.InspectorLabel = new GUIContent(Strings.Label_Inspector, Strings.Tooltip_Inspector);
//            NDEditorContent.NetworkSyncLabel = new GUIContent(Strings.Label_Network_Sync, Strings.Tooltip_Network_Sync);
//            NDEditorContent.NetworkSyncNotSupportedLabel = new GUIContent(Strings.Label_Network_Sync, Strings.Tooltip_Network_Sync_Not_Supported);
//            NDEditorContent.EditVariableTypeLabel = new GUIContent(Strings.Label_Variable_Type, Strings.Tooltip_Edit_Variable_Type);
//            NDEditorContent.AddLabel = new GUIContent(Strings.Label_Add);
//            NDEditorContent.GlobalVariablesNameLabel = new GUIContent(Strings.Label_Name, Strings.Tooltip_Global_Variables_Header);
//            NDEditorContent.GlobalVariablesTypeLabel = new GUIContent(Strings.Label_Type, Strings.Tooltip_Global_Variables_Type);
//            NDEditorContent.AddGlobalVariableLabel = new GUIContent(Strings.Label_New_Variable, Strings.Tooltip_Add_Global_Variable);
//            NDEditorContent.GlobalVariableUseCountLabel = new GUIContent(Strings.Label_Used, Strings.Tooltip_Global_Variables_Used_Count);
//            NDEditorContent.EditEventNameLabel = new GUIContent(Strings.Label_Event_Name, Strings.Tooltip_EventManager_Edit_Event);
//            NDEditorContent.AddEventLabel = new GUIContent(Strings.Label_Add_Event, Strings.Tooltip_EventManager_Add_Event);
//            NDEditorContent.EventInspectorLabel = new GUIContent(Strings.Label_Inspector, Strings.Tooltip_EventManager_Inspector_Checkbox);
//            NDEditorContent.EventBrowserButtonLabel = new GUIContent(Strings.Command_Event_Browser, Strings.Tooltip_Event_Browser_Button_in_Events_Tab);
//            NDEditorContent.EventBroadcastIcon = new GUIContent(FsmEditorStyles.BroadcastIcon, Strings.Tooltip_Global_Event_Flag);
//            NDEditorContent.EventHeaderLabel = new GUIContent(Strings.Label_Event, Strings.Tooltip_Event_GUI);
//            NDEditorContent.EventUsedHeaderLabel = new GUIContent(Strings.Label_Used, Strings.Tooltip_Events_Used_By_States);
//            NDEditorContent.GlobalEventTooltipLabel = new GUIContent("", Strings.Label_Global);
//            if (usingProSkin)
//            {
//                NDEditorContent.FsmBrowserButton = new GUIContent(Files.LoadTextureFromDll("browserIcon", 14, 14), Strings.Tooltip_Editor_Windows);
//                NDEditorContent.BackButton = new GUIContent(Files.LoadTextureFromDll("backIcon", 10, 14), "Select Previous FSM");
//                NDEditorContent.ForwardButton = new GUIContent(Files.LoadTextureFromDll("forwardIcon", 10, 14), "Select Next FSM");
//                NDEditorContent.RecentButton = new GUIContent(Files.LoadTextureFromDll("recentIcon", 10, 14), Strings.MainToolbar_Recent);
//                NDEditorContent.DeleteButton = new GUIContent(Files.LoadTextureFromDll("deleteIcon", 17, 14), Strings.Command_Delete);
//                NDEditorContent.ResetButton = new GUIContent(Files.LoadTextureFromDll("deleteIcon", 17, 14), Strings.Command_Reset);
//                NDEditorContent.UpButton = new GUIContent(Files.LoadTextureFromDll("upIcon", 17, 14), Strings.Command_Move_Up);
//                NDEditorContent.DownButton = new GUIContent(Files.LoadTextureFromDll("downIcon", 17, 14), Strings.Command_Move_Down);
//                NDEditorContent.VariableButton = new GUIContent(Files.LoadTextureFromDll("variableIcon", 17, 14), Strings.Option_Use_Variable);
//                NDEditorContent.SettingsButton = new GUIContent(Files.LoadTextureFromDll("settingsIcon", 14, 12), Strings.Command_Settings);
//                NDEditorContent.BrowseButton = new GUIContent(Files.LoadTextureFromDll("browseIcon", 17, 14), Strings.Command_Browse);
//                NDEditorContent.MainToolbarShowMinimap = new GUIContent(Files.LoadTextureFromDll("minimapIcon", 14, 14), Strings.Tooltip_Toggle_Minimap);
//                NDEditorContent.PopupButton = new GUIContent(Files.LoadTextureFromDll("browseIcon", 17, 14), "");
//            }
//            else
//            {
//                NDEditorContent.FsmBrowserButton = new GUIContent(Files.LoadTextureFromDll("browserIcon_indie", 14, 14), Strings.Tooltip_Editor_Windows);
//                NDEditorContent.BackButton = new GUIContent(Files.LoadTextureFromDll("backIcon_indie", 10, 14));
//                NDEditorContent.ForwardButton = new GUIContent(Files.LoadTextureFromDll("forwardIcon_indie", 10, 14));
//                NDEditorContent.RecentButton = new GUIContent(Files.LoadTextureFromDll("recentIcon_indie", 10, 14), Strings.MainToolbar_Recent);
//                NDEditorContent.DeleteButton = new GUIContent(Files.LoadTextureFromDll("deleteIcon_indie", 17, 14), Strings.Command_Delete);
//                NDEditorContent.ResetButton = new GUIContent(Files.LoadTextureFromDll("deleteIcon_indie", 17, 14), Strings.Command_Reset);
//                NDEditorContent.UpButton = new GUIContent(Files.LoadTextureFromDll("upIcon_indie", 17, 14), Strings.Command_Move_Up);
//                NDEditorContent.DownButton = new GUIContent(Files.LoadTextureFromDll("downIcon_indie", 17, 14), Strings.Command_Move_Down);
//                NDEditorContent.VariableButton = new GUIContent(Files.LoadTextureFromDll("variableIcon_indie", 17, 14), Strings.Option_Use_Variable);
//                NDEditorContent.SettingsButton = new GUIContent(Files.LoadTextureFromDll("settingsIcon_indie", 14, 12), Strings.Command_Settings);
//                NDEditorContent.BrowseButton = new GUIContent(Files.LoadTextureFromDll("browseIcon_indie", 17, 14), Strings.Command_Browse);
//                NDEditorContent.MainToolbarShowMinimap = new GUIContent(Files.LoadTextureFromDll("minimapIcon_indie", 14, 14), Strings.Tooltip_Toggle_Minimap);
//                NDEditorContent.PopupButton = new GUIContent(Files.LoadTextureFromDll("browseIcon_indie", 17, 14), "");
//            }
//            NDEditorContent.DebugToolbarErrorCount = new GUIContent("", Strings.DebugToolbar_Error_Count_Tooltip);
//            NDEditorContent.DebugToolbarDebug = new GUIContent(Strings.DebugToolbar_Label_Debug, Strings.DebugToolbar_Label_Debug_Tooltip);
//            NDEditorContent.DebugToolbarPrev = new GUIContent(Strings.DebugToolbar_Button_Prev, Strings.DebugToolbar_Button_Prev_Toolrip);
//            NDEditorContent.DebugToolbarNext = new GUIContent(Strings.DebugToolbar_Button_Next, Strings.DebugToolbar_Button_Next_Tooltip);
//            NDEditorContent.StateTitleBox = new GUIContent();
//            NDEditorContent.StateDescription = new GUIContent();
//            NDEditorContent.FsmDescription = new GUIContent();
//            NDEditorContent.EventLabel = new GUIContent();
//            NDEditorContent.MainToolbarSelectedGO = new GUIContent();
//            NDEditorContent.MainToolbarSelectedFSM = new GUIContent();
//            NDEditorContent.MainToolbarLock = new GUIContent(Strings.Command_Lock_Selected_FSM, Strings.Tooltip_Lock_Selected_FSM);
//            NDEditorContent.MainToolbarPrefabTypeNone = new GUIContent(Strings.Label_Select, Strings.Command_Select_GameObject);
//            NDEditorContent.HintGettingStarted = new GUIContent(Strings.Hint_GraphView_Getting_Started);
//            NDEditorContent.HintGraphShortcuts = new GUIContent((Application.platform() == null) ? Strings.Hint_GraphView_Shortcuts_OSX() : Strings.Hint_GraphView_Shortcuts);
//            NDEditorContent.HintGraphCommands = new GUIContent(Strings.Hint_GraphView_Shortcut_Description);
//            NDEditorContent.HintGettingStartedSize = NDEditorContent.CalcLineWrappedContentSize(NDEditorContent.HintGettingStarted, FsmEditorStyles.HintBox);
//            NDEditorContent.HintGraphShortcutsSize = NDEditorContent.CalcLineWrappedContentSize(NDEditorContent.HintGraphShortcuts, FsmEditorStyles.HintBox);
//            NDEditorContent.HintGraphCommandsSize = NDEditorContent.CalcLineWrappedContentSize(NDEditorContent.HintGraphCommands, FsmEditorStyles.HintBox);
        }


        public static GUIContent TempContent(string text, string tooltip = "")
        {
            NDEditorContent.tempContent.text = text;
            NDEditorContent.tempContent.tooltip = tooltip;
            return NDEditorContent.tempContent;
        }
        private static Vector2 CalcLineWrappedContentSize(GUIContent content, GUIStyle guiStyle)
        {
            float num;
            float num2;
            guiStyle.CalcMinMaxWidth(content, out num, out num2);
            return new Vector2(num2, guiStyle.CalcHeight(content, num2));
        }
    }
}
