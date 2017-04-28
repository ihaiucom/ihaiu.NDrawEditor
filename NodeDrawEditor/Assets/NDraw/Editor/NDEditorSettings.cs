using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace ihaiu.NDraws
{
    [Serializable]
    internal static class NDEditorSettings
    {
        private enum categories
        {
            General,
            GraphView,
            ErrorChecking,
            Debugging,
            Colors
        }
        public const string ProductUrl = "http://blog.ihaiu.com/unity-NodeDrawEditor";
        public const string OnlineStoreUrl = "http://blog.ihaiu.com/unity-NodeDrawEditor";
        public const string AssetStoreUrl = "http://blog.ihaiu.com/unity-NodeDrawEditor";
        public const int MaxStateNameLength = 100;
        public const float GraphViewMinZoom = 0.3f;
        public const float GraphViewMaxZoom = 1f;
        private static bool settingsLoaded;
        public static string ProductName = "Node Draw Editor";
        public static string ProductCopyright = "© ihaiu.com";
        [Localizable(false)]
        private static readonly string[] supportedCultures = new string[]
            {
                "en-US",
                "zh-CN",
                "zh-TW",
                "nl",
                "fr-FR",
                "de-DE",
                "it",
                "ja-JP",
                "pt-BR",
                "es-ES",
                "sv-SE"
            };
        [Localizable(false)]
        private static readonly string[] cultureNames = new string[]
            {
                "English",
                "Chinese Simplified",
                "Chinese Traditional",
                "Dutch",
                "French",
                "German",
                "Italian",
                "Japanese",
                "Portuguese Brazilian",
                "Spanish",
                "Swedish"
            };
        private static int selectedCulture;
        private static string selectedCultureName;
        private static string selectedCultureTranslators;
        private static bool selectedCultureSupportedInMenus;
        private static categories selectedCategory;
        private static bool showStateLabelsInGameView;
        private static Vector2 scrollPosition;
        public static int ActionBrowserRecentSize
        {
            get;
            set;
        }
        public static NDDebugger.NDStepMode DebuggerStepMode
        {
            get;
            set;
        }
        public static bool DisableUndoRedo
        {
            get;
            set;
        }
        public static bool MaximizeFileCompatibility
        {
            get;
            set;
        }
        public static bool DrawAssetThumbnail
        {
            get;
            set;
        }
        public static bool DrawLinksBehindStates
        {
            get;
            set;
        }
        public static bool DimFinishedActions
        {
            get;
            set;
        }
        public static bool AutoRefreshFsmInfo
        {
            get;
            set;
        }
        public static bool ConfirmEditingPrefabInstances
        {
            get;
            set;
        }
        public static bool DrawFrameAroundGraph
        {
            get;
            set;
        }
        public static bool GraphViewShowMinimap
        {
            get;
            set;
        }
        public static float GraphViewMinimapSize
        {
            get;
            set;
        }
        public static string ScreenshotsPath
        {
            get;
            set;
        }
        public static bool ShowStateDescription
        {
            get;
            set;
        }
        public static bool ShowActionParameters
        {
            get;
            set;
        }
        public static bool DebugActionParameters
        {
            get;
            set;
        }
        public static bool DebugVariables
        {
            get;
            set;
        }
        public static bool HideUnusedEvents
        {
            get;
            set;
        }
        public static bool ShowActionPreview
        {
            get;
            set;
        }
        public static int SelectedActionCategory
        {
            get;
            set;
        }
        public static bool SelectFSMInGameView
        {
            get;
            set;
        }
        public static Color DebugLookAtColor
        {
            get;
            set;
        }
        public static Color DebugRaycastColor
        {
            get;
            set;
        }
        public static bool HideUnusedParams
        {
            get;
            set;
        }
        public static bool AutoAddPlayMakerGUI
        {
            get;
            set;
        }
        public static bool DimUnusedActionParameters
        {
            get;
            set;
        }
        public static bool AddPrefabLabel
        {
            get;
            set;
        }
        public static bool UnloadPrefabs
        {
            get;
            set;
        }
        public static bool AutoLoadPrefabs
        {
            get;
            set;
        }
        public static int StateMaxWidth
        {
            get;
            set;
        }
        public static bool ShowScrollBars
        {
            get;
            set;
        }
        public static bool EnableWatermarks
        {
            get;
            set;
        }
        public static int SnapGridSize
        {
            get;
            set;
        }
        public static bool SnapToGrid
        {
            get;
            set;
        }
        public static bool EnableLogging
        {
            get;
            set;
        }
        public static bool ColorLinks
        {
            get;
            set;
        }
        public static bool HideObsoleteActions
        {
            get;
            set;
        }
        public static bool LockGraphView
        {
            get;
            set;
        }
        public static GraphViewLinkStyle GraphViewLinkStyle
        {
            get;
            private set;
        }
        public static string StartStateName
        {
            get;
            private set;
        }
        public static string NewStateName
        {
            get;
            private set;
        }
        public static int GameStateIconSize
        {
            get;
            private set;
        }
        public static bool AutoSelectGameObject
        {
            get;
            private set;
        }
        public static bool SelectStateOnActivated
        {
            get;
            private set;
        }
        public static bool JumpToBreakpoint
        {
            get;
            private set;
        }
        public static bool FrameSelectedState
        {
            get;
            private set;
        }
        public static bool SyncLogSelection
        {
            get;
            private set;
        }
        public static bool BreakpointsEnabled
        {
            get;
            set;
        }
        public static bool ShowFsmDescriptionInGraphView
        {
            get;
            private set;
        }
        public static bool ShowCommentsInGraphView
        {
            get;
            private set;
        }
        public static bool DrawPlaymakerGizmos
        {
            get;
            set;
        }
        public static bool DrawPlaymakerGizmoInHierarchy
        {
            get;
            set;
        }
        public static bool ShowEditWhileRunningWarning
        {
            get;
            private set;
        }
        public static bool MirrorDebugLog
        {
            get;
            private set;
        }
        public static float EdgeScrollSpeed
        {
            get;
            set;
        }
        public static float EdgeScrollZone
        {
            get;
            set;
        }
        public static int MaxLoopCount
        {
            get;
            set;
        }
        public static NDEditorStyles.ColorScheme ColorScheme
        {
            get;
            set;
        }
        public static bool ShowStateLabelsInGameView
        {
            get;
            set;
        }
        public static bool EnableRealtimeErrorChecker
        {
            get;
            set;
        }
        public static bool DisableErrorCheckerWhenPlaying
        {
            get;
            set;
        }
        public static bool CheckForRequiredComponent
        {
            get;
            set;
        }
        public static bool CheckForRequiredField
        {
            get;
            set;
        }
        public static bool CheckForTransitionMissingEvent
        {
            get;
            set;
        }
        public static bool CheckForTransitionMissingTarget
        {
            get;
            set;
        }
        public static bool CheckForDuplicateTransitionEvent
        {
            get;
            set;
        }
        public static bool CheckForMouseEventErrors
        {
            get;
            set;
        }
        public static bool CheckForCollisionEventErrors
        {
            get;
            set;
        }
        public static bool CheckForEventNotUsed
        {
            get;
            set;
        }
        public static bool CheckForPrefabRestrictions
        {
            get;
            set;
        }
        public static bool CheckForObsoleteActions
        {
            get;
            set;
        }
        public static bool CheckForMissingActions
        {
            get;
            set;
        }
        public static bool CheckForNetworkSetupErrors
        {
            get;
            set;
        }
        public static bool DisableActionBrowerWhenPlaying
        {
            get;
            set;
        }
        public static bool DisableEventBrowserWhenPlaying
        {
            get;
            set;
        }
        public static bool DisableEditorWhenPlaying
        {
            get;
            set;
        }
        public static bool DisableInspectorWhenPlaying
        {
            get;
            set;
        }
        public static bool DisableToolWindowsWhenPlaying
        {
            get;
            set;
        }
        public static bool ShowHints
        {
            get;
            set;
        }
        public static bool CloseActionBrowserOnEnter
        {
            get;
            set;
        }
        public static bool AutoRefreshActionUsage
        {
            get;
            set;
        }
        public static bool LogPauseOnSelect
        {
            get;
            set;
        }
        public static bool LogShowSentBy
        {
            get;
            set;
        }
        public static bool LogShowExit
        {
            get;
            set;
        }
        public static bool LogShowTimecode
        {
            get;
            set;
        }
        public static bool EnableDebugFlow
        {
            get;
            set;
        }
        public static bool EnableTransitionEffects
        {
            get;
            set;
        }
        public static bool ShowStateLoopCounts
        {
            get;
            set;
        }
        public static int ConsoleActionReportSortOptionIndex
        {
            get;
            set;
        }
        public static bool LoadAllPrefabs
        {
            get;
            set;
        }
        public static bool SelectNewVariables
        {
            get;
            set;
        }
        public static bool FsmBrowserShowFullPath
        {
            get;
            set;
        }
        public static bool MouseWheelScrollsGraphView
        {
            get;
            set;
        }
        public static float GraphViewZoomSpeed
        {
            get;
            set;
        }
        public static void OnGUI()
        {
            selectedCategory = (categories)EditorGUILayout.EnumPopup(selectedCategory, new GUILayoutOption[0]);
            NDEditorGUILayout.Divider(new GUILayoutOption[0]);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, new GUILayoutOption[0]);
            EditorGUIUtility.labelWidth = 180;
            bool changed = GUI.changed;
            GUI.changed = false;
            switch (selectedCategory)
            {
                case categories.General:
                    DoGeneralSettings();
                    break;
                case categories.GraphView:
                    DoGraphViewSettings();
                    break;
                case categories.ErrorChecking:
                    DoErrorCheckSettings();
                    break;
                case categories.Debugging:
                    DoDebuggingSettings();
                    break;
                case categories.Colors:
                    DoColorSettings();
                    break;
            }
            if (GUI.changed)
            {
                ValidateSettings();
                ApplySettings();
                SaveSettings();
            }
            else
            {
                GUI.changed = changed;
            }
            GUILayout.EndScrollView();
            NDEditorGUILayout.Divider(new GUILayoutOption[0]);
            EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
            if (GUILayout.Button(Strings.get_FsmEditorSettings_Restore_Default_Settings(), new GUILayoutOption[0]))
            {
                ResetDefaults();
                SaveSettings();
            }
            if (SkillEditorGUILayout.HelpButton("Online Help"))
            {
                EditorCommands.OpenWikiPage(WikiPages.Preferences);
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
        private static void DoColorSettings()
        {
            GUILayout.Label(Strings.get_FsmEditorSettings_Default_Colors(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            for (int i = 0; i < 8; i++)
            {
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                PlayMakerPrefs.get_ColorNames()[i] = EditorGUILayout.TextField(PlayMakerPrefs.get_ColorNames()[i], new GUILayoutOption[0]);
                PlayMakerPrefs.get_Colors()[i] = EditorGUILayout.ColorField(PlayMakerPrefs.get_Colors()[i], new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
            }
            if (GUILayout.Button(Strings.get_FsmEditorSettings_Reset_Default_Colors(), new GUILayoutOption[0]))
            {
                PlayMakerPrefs.get_Instance().ResetDefaultColors();
                Keyboard.ResetFocus();
                GUI.set_changed(true);
            }
            GUILayout.Label(Strings.get_FsmEditorSettings_Custom_Colors(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            for (int j = 8; j < 24; j++)
            {
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                PlayMakerPrefs.get_ColorNames()[j] = EditorGUILayout.TextField(PlayMakerPrefs.get_ColorNames()[j], new GUILayoutOption[0]);
                PlayMakerPrefs.get_Colors()[j] = EditorGUILayout.ColorField(PlayMakerPrefs.get_Colors()[j], new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
            }
            EditorGUILayout.HelpBox(Strings.get_FsmEditorSettings_Custom_Colors_Name_Hint(), 1);
            if (GUI.get_changed())
            {
                SavePlayMakerPrefs();
            }
        }
        private static void SavePlayMakerPrefs()
        {
            PlayMakerPrefs.SaveChanges();
            EditorUtility.SetDirty(PlayMakerPrefs.get_Instance());
            if (!AssetDatabase.Contains(PlayMakerPrefs.get_Instance()))
            {
                string text = Path.Combine(SkillPaths.ResourcesPath, "PlayMakerPrefs.asset");
                SkillEditor.CreateAsset(PlayMakerPrefs.get_Instance(), ref text);
                Debug.Log(Strings.get_FsmEditorSettings_Creating_PlayMakerPrefs_Asset() + text);
            }
        }
        private static void DoDebuggingSettings()
        {
            if (ShowHints)
            {
                GUILayout.Box(Strings.get_Hint_Debugger_Settings(), SkillEditorStyles.HintBox, new GUILayoutOption[0]);
            }
            ShowStateLabelsInGameView = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_State_Labels_in_Game_View(), Strings.get_FsmEditorSettings_DoDebuggingSettings_Show_State_Labels_Tooltip()), ShowStateLabelsInGameView);
            EnableLogging = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Enable_Logging(), Strings.get_FsmEditorSettings_Enable_Logging_Tooltip()), EnableLogging);
            EnableDebugFlow = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Enable_DebugFlow(), Strings.get_FsmEditorSettings_Enable_DebugFlow_Tooltip()), EnableDebugFlow);
            EnableTransitionEffects = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Enable_Transition_Effects(), Strings.get_FsmEditorSettings_Enable_Transition_Effects_Tooltip()), EnableTransitionEffects);
            JumpToBreakpoint = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Jump_to_Breakpoint_Error(), Strings.get_FsmEditorSettings_Jump_to_Breakpoint_Error_Tooltip()), JumpToBreakpoint);
            MirrorDebugLog = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Forward_Playmaker_Log_to_Unity_Log(), Strings.get_FsmEditorSettings_Forward_Playmaker_Log_to_Unity_Log_Tooltip()), MirrorDebugLog);
            DebugLookAtColor = EditorGUILayout.ColorField(Strings.get_FsmEditorSettings_Debug_Look_At_Color(), DebugLookAtColor, new GUILayoutOption[0]);
            DebugRaycastColor = EditorGUILayout.ColorField(Strings.get_FsmEditorSettings_Debug_Raypick_Color(), DebugRaycastColor, new GUILayoutOption[0]);
        }
        private static void DoErrorCheckSettings()
        {
            if (ShowHints)
            {
                GUILayout.Box(Strings.get_Hint_Error_Checker_Settings(), SkillEditorStyles.HintBox, new GUILayoutOption[0]);
            }
            bool changed = GUI.get_changed();
            EnableRealtimeErrorChecker = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Enable_Real_Time_Error_Checker(), Strings.get_FsmEditorSettings_Enable_Real_Time_Error_Checker_Tooltip()), EnableRealtimeErrorChecker);
            DisableErrorCheckerWhenPlaying = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Disable_Error_Checker_When_Game_Is_Playing(), Strings.get_FsmEditorSettings_Disable_Error_Checker_When_Game_Is_Playing_Tooltip()), DisableErrorCheckerWhenPlaying);
            CheckForRequiredComponent = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Required_Components(), Strings.get_FsmEditorSettings_Check_for_Required_Components_Tooltip()), CheckForRequiredComponent);
            CheckForRequiredField = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Required_Action_Fields(), Strings.get_FsmEditorSettings_Check_for_Required_Action_Fields_Tooltip()), CheckForRequiredField);
            CheckForEventNotUsed = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Events_Not_Used_by_Target_FSM(), Strings.get_FsmEditorSettings_Check_for_Events_Not_Used_by_Target_FSM_Tooltip()), CheckForEventNotUsed);
            CheckForTransitionMissingEvent = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Transitions_Missing_Events(), Strings.get_FsmEditorSettings_Check_for_Transitions_Missing_Events_Tooltip()), CheckForTransitionMissingEvent);
            CheckForTransitionMissingTarget = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Transitions_Missing_Targets(), Strings.get_FsmEditorSettings_Check_for_Transitions_Missing_Targets_Tooltip()), CheckForTransitionMissingTarget);
            CheckForDuplicateTransitionEvent = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Duplicate_Transition_Events(), Strings.get_FsmEditorSettings_Check_for_Duplicate_Transition_Events_Tooltip()), CheckForDuplicateTransitionEvent);
            CheckForMouseEventErrors = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Setup_Errors_With_Mouse_Events(), Strings.get_FsmEditorSettings_Check_for_Setup_Errors_With_Mouse_Events_Tooltip()), CheckForMouseEventErrors);
            CheckForCollisionEventErrors = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Setup_Errors_With_Collision_Events(), Strings.get_FsmEditorSettings_Check_for_Setup_Errors_With_Collision_Events_Tooltip()), CheckForCollisionEventErrors);
            CheckForPrefabRestrictions = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Prefab_Restrictions(), Strings.get_FsmEditorSettings_Check_for_Prefab_Restrictions_Tooltip()), CheckForPrefabRestrictions);
            CheckForObsoleteActions = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Obsolete_Actions(), Strings.get_FsmEditorSettings_Check_for_Obsolete_Actions_Tooltip()), CheckForObsoleteActions);
            CheckForMissingActions = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Missing_Actions(), Strings.get_FsmEditorSettings_Check_for_Missing_Actions_Tooltip()), CheckForMissingActions);
            CheckForNetworkSetupErrors = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Check_for_Network_Setup_Errors(), Strings.get_FsmEditorSettings_Check_for_Network_Setup_Errors_Tooltip()), CheckForNetworkSetupErrors);
            if (GUI.get_changed())
            {
                FsmErrorChecker.Refresh();
                SkillEditor.RepaintAll();
                return;
            }
            GUI.set_changed(changed);
        }
        private static void DoGeneralSettings()
        {
            if (ShowHints)
            {
                GUILayout.Box(Strings.get_FsmEditorHint_General_Settings(), SkillEditorStyles.HintBox, new GUILayoutOption[0]);
            }
            int num = EditorGUILayout.Popup(Strings.get_Label_Language(), selectedCulture, cultureNames, new GUILayoutOption[0]);
            if (num != selectedCulture)
            {
                SetCulture(num);
            }
            if (selectedCultureTranslators != "")
            {
                EditorGUILayout.HelpBox(Strings.get_FsmEditorSettings_Translators() + selectedCultureTranslators, 0);
            }
            if (!selectedCultureSupportedInMenus)
            {
                EditorGUILayout.HelpBox(Strings.get_FsmEditorSettings_Selected_language_not_yet_supported_in_menus(), 0);
            }
            GUILayout.Label(Strings.get_FsmEditorSettings_Category_Components_and_Gizmos(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            AutoAddPlayMakerGUI = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Auto_Add_PlayMakerGUI_to_Scene(), Strings.get_FsmEditorSettings_Auto_Add_PlayMakerGUI_to_Scene_Tooltip()), AutoAddPlayMakerGUI);
            ShowStateLabelsInGameView = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_State_Labels_in_Game_View(), Strings.get_FsmEditorSettings_DoDebuggingSettings_Show_State_Labels_Tooltip()), ShowStateLabelsInGameView);
            bool flag = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Draw_Playmaker_Gizmos_in_Scene_View(), Strings.get_FsmEditorSettings_Draw_Playmaker_Gizmos_in_Scene_View_Tooltip()), DrawPlaymakerGizmos);
            if (flag != DrawPlaymakerGizmos)
            {
                DrawPlaymakerGizmos = flag;
                PlayMakerFSM.set_DrawGizmos(flag);
                GUI.set_changed(true);
            }
            flag = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Draw_Playmaker_Gizmos_in_Hierarchy(), Strings.get_FsmEditorSettings_Draw_Playmaker_Gizmos_in_Hierarchy_Tooltip()), DrawPlaymakerGizmoInHierarchy);
            if (flag != DrawPlaymakerGizmoInHierarchy)
            {
                Gizmos.EnableHierarchyItemGizmos = flag;
                DrawPlaymakerGizmoInHierarchy = flag;
                EditorApplication.RepaintHierarchyWindow();
            }
            GUILayout.Label(Strings.get_FsmEditorSettings_Category_When_Game_Is_Playing(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            ShowEditWhileRunningWarning = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_Editing_While_Running_Warning(), Strings.get_FsmEditorSettings_Show_Editing_While_Running_Warning_Tooltip()), ShowEditWhileRunningWarning);
            DisableEditorWhenPlaying = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Disable_PlayMaker_Editor_When_Game_Is_Playing(), Strings.get_FsmEditorSettings_Disable_PlayMaker_Editor_When_Game_Is_Playing_Tooltip()), DisableEditorWhenPlaying);
            DisableInspectorWhenPlaying = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Disable_the_Inspector_Panel_When_Game_Is_Playing(), Strings.get_FsmEditorSettings_Disable_the_Inspector_Panel_When_Game_Is_Playing_Tooltip()), DisableInspectorWhenPlaying);
            DisableToolWindowsWhenPlaying = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Disable_Tool_Windows_When_Game_Is_Playing(), Strings.get_FsmEditorSettings_Disable_Tool_Windows_When_Game_Is_Playing_Tooltip()), DisableToolWindowsWhenPlaying);
            DisableErrorCheckerWhenPlaying = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Disable_Error_Checker_When_Game_Is_Playing(), Strings.get_FsmEditorSettings_Disable_Error_Checker_When_Game_Is_Playing_Tooltip()), DisableErrorCheckerWhenPlaying);
            DimFinishedActions = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Dim_Finished_Actions(), Strings.get_FsmEditorSettings_Dim_Finished_Actions_Tooltip()), DimFinishedActions);
            GUILayout.Label(Strings.get_FsmEditorSettings_Category_Selection(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            AutoSelectGameObject = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Select_GameObject_When_FSM_Selected(), Strings.get_FsmEditorSettings_Select_GameObject_When_FSM_Selected_Tooltip()), AutoSelectGameObject);
            SelectStateOnActivated = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Select_State_On_Activated(), Strings.get_FsmEditorSettings_Select_State_On_Activated_Tooltip()), SelectStateOnActivated);
            FrameSelectedState = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Auto_Frame_Selected_State(), Strings.get_FsmEditorSettings_Auto_Frame_Selected_State_Tooltip()), FrameSelectedState);
            SelectFSMInGameView = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Select_Game_Objects_With_FSMs_in_Game_View(), Strings.get_FsmEditorSettings_Select_Game_Objects_With_FSMs_in_Game_View_Tooltip()), SelectFSMInGameView);
            GUILayout.Label(Strings.get_FsmEditorSettings_Category_Prefabs(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            ConfirmEditingPrefabInstances = SkillEditorGUILayout.RightAlignedToggle(SkillEditorContent.ConfirmEditPrefabInstance, ConfirmEditingPrefabInstances);
            LoadAllPrefabs = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Load_All_PlayMakerFSM_Prefabs_When_Refactoring(), Strings.get_FsmEditorSettings_Load_All_PlayMakerFSM_Prefabs_When_Refactoring_Tooltip()), LoadAllPrefabs);
            AutoLoadPrefabs = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Auto_Load_Prefabs_in_Scene(), Strings.get_FsmEditorSettings_Auto_Load_Prefabs_in_Scene_Tooltip()), AutoLoadPrefabs);
            AddPrefabLabel = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Add_Prefab_Labels(), Strings.get_FsmEditorSettings_Add_Prefab_Labels_Tooltip()), AddPrefabLabel);
            GUILayout.Label(Strings.get_FsmEditorSettings_Cetegory_Paths(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            GUILayout.Label(new GUIContent(Strings.get_FsmEditorSettings_FSM_Screenshots_Directory(), Strings.get_FsmEditorSettings_FSM_Screenshots_Directory_Tooltip()), new GUILayoutOption[0]);
            ScreenshotsPath = EditorGUILayout.TextField(ScreenshotsPath, new GUILayoutOption[0]);
            GUILayout.Label(Strings.get_FsmEditorSettings_Experimental(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            DisableUndoRedo = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Disable_Undo_Redo(), Strings.get_FsmEditorSettings_Disable_Undo_Redo_Tooltip()), DisableUndoRedo);
        }
        [Localizable(false)]
        private static void SetCulture(int cultureIndex)
        {
            if (cultureIndex >= cultureNames.Length)
            {
                cultureIndex = 0;
            }
            selectedCulture = cultureIndex;
            selectedCultureName = cultureNames[cultureIndex];
            selectedCultureTranslators = GetTranslators(selectedCultureName);
            selectedCultureSupportedInMenus = true;
            selectedCultureName == "Japanese";
            Strings.set_Culture(new CultureInfo(supportedCultures[cultureIndex]));
            InspectorPanel.Init();
            BugReportWindow.frequencyChoices = new string[]
                {
                    Strings.get_BugReportWindow_FrequencyChoices_Always(),
                    Strings.get_BugReportWindow_FrequencyChoices_Sometimes__but_not_always(),
                    Strings.get_BugReportWindow_FrequencyChoices_This_is_the_first_time()
                };
            SkillEditorStyles.Reinitialize();
            SkillEditor.RepaintAll();
            SaveSettings();
            SkillEditor.ChangeLanguage();
        }
        [Localizable(false)]
        private static string GetTranslators(string cultureName)
        {
            if (cultureName != null)
            {
                if (<PrivateImplementationDetails>{9F518054-9A7A-4388-8A0B-9CF872B8F518}.$$method0x6000671-1 == null)
                {
                    Dictionary<string, int> expr_1B = new Dictionary<string, int>(11);
                    expr_1B.Add("English", 0);
                    expr_1B.Add("Chinese Simplified", 1);
                    expr_1B.Add("Chinese Traditional", 2);
                    expr_1B.Add("Dutch", 3);
                    expr_1B.Add("French", 4);
                    expr_1B.Add("German", 5);
                    expr_1B.Add("Italian", 6);
                    expr_1B.Add("Japanese", 7);
                    expr_1B.Add("Spanish", 8);
                    expr_1B.Add("Swedish", 9);
                    expr_1B.Add("Portuguese Brazilian", 10);
                    <PrivateImplementationDetails>{9F518054-9A7A-4388-8A0B-9CF872B8F518}.$$method0x6000671-1 = expr_1B;
                }
                int num;
                if (<PrivateImplementationDetails>{9F518054-9A7A-4388-8A0B-9CF872B8F518}.$$method0x6000671-1.TryGetValue(cultureName, ref num))
                {
                    switch (num)
                    {
                        case 0:
                            return "";
                        case 1:
                            return "黄峻";
                        case 2:
                            return "黄峻";
                        case 3:
                            return "VisionaiR3D";
                        case 4:
                            return "Jean Fabre";
                        case 5:
                            return "Steven 'Nightreaver' Barthen, Marc 'Dreamora' Schaerer";
                        case 6:
                            return "Marcello Gavioli";
                        case 7:
                            return "gamesonytablet";
                        case 8:
                            return "Eugenio 'Ryo567' Martínez";
                        case 9:
                            return "Damiangto";
                        case 10:
                            return "Nilton Felicio, Andre Dantas Lima";
                    }
                }
            }
            return "";
        }
        private static void DoGraphViewSettings()
        {
            if (ShowHints)
            {
                GUILayout.Box(Strings.get_Hint_Graph_View_Settings(), SkillEditorStyles.HintBox, new GUILayoutOption[0]);
            }
            GUILayout.Label(Strings.get_FsmEditorSettings_Category_Graph_Styles(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            SkillEditorStyles.ColorScheme colorScheme = (SkillEditorStyles.ColorScheme)EditorGUILayout.EnumPopup(new GUIContent(Strings.get_FsmEditorSettings_Color_Scheme(), Strings.get_FsmEditorSettings_Color_Scheme_Tooltip()), ColorScheme, new GUILayoutOption[0]);
            if (colorScheme != ColorScheme)
            {
                ColorScheme = colorScheme;
                SkillEditorStyles.Init();
            }
            GraphViewLinkStyle = (GraphViewLinkStyle)EditorGUILayout.EnumPopup(new GUIContent(Strings.get_FsmEditorSettings_Link_Style(), Strings.get_FsmEditorSettings_Link_Style_Tooltip()), GraphViewLinkStyle, new GUILayoutOption[0]);
            ColorLinks = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Color_Links_With_State_Color(), Strings.get_FsmEditorSettings_Color_Links_With_State_Color_Tooltip()), ColorLinks);
            EnableWatermarks = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Enable_Watermarks(), Strings.get_FsmEditorSettings_Enable_Watermarks_Tooltip()), EnableWatermarks);
            ShowFsmDescriptionInGraphView = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_FSM_Description_in_Graph_View(), ""), ShowFsmDescriptionInGraphView);
            bool flag = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_Comments_in_Graph_View(), Strings.get_FsmEditorSettings_Show_Comments_in_Graph_View_Tooltip()), ShowCommentsInGraphView);
            if (flag != ShowCommentsInGraphView)
            {
                ShowCommentsInGraphView = flag;
                SkillEditor.GraphView.UpdateAllStateSizes();
                GUI.set_changed(true);
            }
            DrawFrameAroundGraph = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Draw_Frame_Around_FSM()), DrawFrameAroundGraph);
            DrawLinksBehindStates = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Draw_Links_Behind_States()), DrawLinksBehindStates);
            GUILayout.Label(Strings.get_FsmEditorSettings_Scrolling(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            MouseWheelScrollsGraphView = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Mouse_Wheel_Scrolls_Graph_View(), Strings.get_FsmEditorSettings_DoGraphViewSettings_Tooltip()), MouseWheelScrollsGraphView);
            ShowScrollBars = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_Scrollbars_All_The_Time(), Strings.get_FsmEditorSettings_Show_Scrollbars_All_The_Time_Tooltip()), ShowScrollBars);
            EdgeScrollSpeed = EditorGUILayout.FloatField(new GUIContent(Strings.get_FsmEditorSettings_Edge_Scroll_Speed(), Strings.get_FsmEditorSettings_Edge_Scroll_Speed_Tooltip()), EdgeScrollSpeed, new GUILayoutOption[0]);
            GraphViewZoomSpeed = EditorGUILayout.FloatField(new GUIContent(Strings.get_FsmEditorSettings_Zoom_Speed(), Strings.get_FsmEditorSettings_DoGraphViewSettings_Zoom_Speed_Tooltip()), GraphViewZoomSpeed, new GUILayoutOption[0]);
            GUILayout.Label(Strings.get_FsmEditorSettings_Minimap(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            GraphViewShowMinimap = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Show_Minimap()), GraphViewShowMinimap);
            GraphViewMinimapSize = EditorGUILayout.FloatField(new GUIContent(Strings.get_FsmEditorSettings_Minimap_Size(), Strings.get_FsmEditorSettings_Minimap_Size_Tooltip()), GraphViewMinimapSize, new GUILayoutOption[0]);
            GraphViewMinimapSize = Mathf.Clamp(GraphViewMinimapSize, 50f, 1000f);
            GUILayout.Label(Strings.get_FsmEditorSettings_Category_Editing(), EditorStyles.get_boldLabel(), new GUILayoutOption[0]);
            NewStateName = EditorGUILayout.TextField(new GUIContent(Strings.get_FsmEditorSettings_New_State_Name(), Strings.get_FsmEditorSettings_New_State_Name_Tooltip()), NewStateName, new GUILayoutOption[0]);
            int num = EditorGUILayout.IntField(new GUIContent(Strings.get_FsmEditorSettings_Max_State_Width(), Strings.get_FsmEditorSettings_Max_State_Width_Tooltip()), StateMaxWidth, new GUILayoutOption[0]);
            if (num != StateMaxWidth)
            {
                StateMaxWidth = num;
                SkillEditor.GraphView.UpdateAllStateSizes();
            }
            SnapGridSize = EditorGUILayout.IntField(new GUIContent(Strings.get_FsmEditorSettings_Snap_Grid_Size(), Strings.get_FsmEditorSettings_Snap_Grid_Size_Tooltip()), SnapGridSize, new GUILayoutOption[0]);
            SnapToGrid = SkillEditorGUILayout.RightAlignedToggle(new GUIContent(Strings.get_FsmEditorSettings_Snap_To_Grid()), SnapToGrid);
        }
        private static void ResetDefaults()
        {
            DisableUndoRedo = false;
            MaximizeFileCompatibility = true;
            DrawAssetThumbnail = true;
            DrawLinksBehindStates = true;
            DimFinishedActions = true;
            ConfirmEditingPrefabInstances = true;
            ShowStateLoopCounts = false;
            GraphViewZoomSpeed = 0.01f;
            MouseWheelScrollsGraphView = false;
            GraphViewLinkStyle = GraphViewLinkStyle.BezierLinks;
            NewStateName = Strings.get_FsmEditorSettings_Default_State_Name();
            AutoSelectGameObject = true;
            SelectStateOnActivated = true;
            JumpToBreakpoint = true;
            MirrorDebugLog = false;
            ShowEditWhileRunningWarning = true;
            SelectFSMInGameView = true;
            ShowFsmDescriptionInGraphView = true;
            ShowCommentsInGraphView = true;
            DrawPlaymakerGizmos = true;
            DrawPlaymakerGizmoInHierarchy = true;
            AutoAddPlayMakerGUI = true;
            DimUnusedActionParameters = false;
            DebugLookAtColor = Color.get_yellow();
            DebugRaycastColor = Color.get_red();
            ShowHints = true;
            CloseActionBrowserOnEnter = false;
            SelectNewVariables = true;
            AddPrefabLabel = true;
            LoadAllPrefabs = true;
            AutoLoadPrefabs = true;
            UnloadPrefabs = true;
            StateMaxWidth = 400;
            ShowScrollBars = true;
            EnableWatermarks = true;
            ColorLinks = false;
            SnapGridSize = 16;
            SnapToGrid = false;
            EnableLogging = true;
            HideUnusedEvents = false;
            EdgeScrollSpeed = 1f;
            EdgeScrollZone = 100f;
            EnableRealtimeErrorChecker = true;
            DisableErrorCheckerWhenPlaying = true;
            CheckForRequiredComponent = true;
            CheckForRequiredField = true;
            CheckForEventNotUsed = true;
            CheckForTransitionMissingEvent = true;
            CheckForTransitionMissingTarget = true;
            CheckForDuplicateTransitionEvent = true;
            CheckForMouseEventErrors = true;
            CheckForCollisionEventErrors = true;
            CheckForPrefabRestrictions = true;
            CheckForObsoleteActions = true;
            CheckForMissingActions = true;
            CheckForNetworkSetupErrors = true;
            DisableEditorWhenPlaying = false;
            DisableInspectorWhenPlaying = false;
            DisableToolWindowsWhenPlaying = true;
            DisableActionBrowerWhenPlaying = false;
            DisableEventBrowserWhenPlaying = false;
            ScreenshotsPath = Strings.get_FsmEditorSettings_Default_Screenshots_Path();
            EnableDebugFlow = true;
            ApplySettings();
        }
        [Localizable(false)]
        public static void SaveSettings()
        {
            if (!settingsLoaded)
            {
                Debug.LogWarning("PlayMaker: Attempting to SaveSettings before LoadSettings.");
                return;
            }
            ValidateSettings();
            EditorPrefs.SetInt("PlayMaker.ActionBrowserRecentSize", ActionBrowserRecentSize);
            EditorPrefs.SetInt("PlayMaker.DebuggerStepMode", (int)DebuggerStepMode);
            EditorPrefs.SetBool("PlayMaker.DisableUndoRedo", DisableUndoRedo);
            EditorPrefs.SetBool("PlayMaker.MaximizeFileCompatibility", MaximizeFileCompatibility);
            EditorPrefs.SetBool("PlayMaker.DrawAssetThumbnail", DrawAssetThumbnail);
            EditorPrefs.SetBool("PlayMaker.DrawLinksBehindStates", DrawLinksBehindStates);
            EditorPrefs.SetBool("PlayMaker.DimFinishedActions", DimFinishedActions);
            EditorPrefs.SetBool("PlayMaker.AutoRefreshFsmInfo", AutoRefreshFsmInfo);
            EditorPrefs.SetBool("PlayMaker.ConfirmEditingPrefabInstances", ConfirmEditingPrefabInstances);
            EditorPrefs.SetBool("PlayMaker.ShowStateLoopCounts", ShowStateLoopCounts);
            EditorPrefs.SetBool("PlayMaker.DrawFrameAroundGraph", DrawFrameAroundGraph);
            EditorPrefs.SetBool("PlayMaker.GraphViewShowMinimap", GraphViewShowMinimap);
            EditorPrefs.SetFloat("PlayMaker.GraphViewMinimapSize", GraphViewMinimapSize);
            EditorPrefs.SetFloat("PlayMaker.GraphViewZoomSpeed", GraphViewZoomSpeed);
            EditorPrefs.SetBool("PlayMaker.MouseWheelScrollsGraphView", MouseWheelScrollsGraphView);
            EditorPrefs.SetString("PlayMaker.Language", supportedCultures[selectedCulture]);
            EditorPrefs.SetString("PlayMaker.ScreenshotsPath", ScreenshotsPath);
            EditorPrefs.SetString("PlayMaker.StartStateName", StartStateName);
            EditorPrefs.SetString("PlayMaker.NewStateName", NewStateName);
            EditorPrefs.SetBool("PlayMaker.AutoSelectGameObject", AutoSelectGameObject);
            EditorPrefs.SetBool("PlayMaker.SelectStateOnActivated", SelectStateOnActivated);
            EditorPrefs.SetBool("PlayMaker.GotoBreakpoint", JumpToBreakpoint);
            EditorPrefs.SetInt("PlayMaker.GameStateIconSize", GameStateIconSize);
            EditorPrefs.SetBool("PlayMaker.FrameSelectedState", FrameSelectedState);
            EditorPrefs.SetBool("PlayMaker.SyncLogSelection", SyncLogSelection);
            EditorPrefs.SetBool("PlayMaker.BreakpointsEnabled", BreakpointsEnabled);
            EditorPrefs.SetBool("PlayMaker.MirrorDebugLog", MirrorDebugLog);
            EditorPrefs.SetBool("PlayMaker.LockGraphView", LockGraphView);
            EditorPrefs.SetInt("PlayMaker.GraphLinkStyle", (int)GraphViewLinkStyle);
            EditorPrefs.SetBool("PlayMaker.ShowFsmDescriptionInGraphView", ShowFsmDescriptionInGraphView);
            EditorPrefs.SetBool("PlayMaker.ShowCommentsInGraphView", ShowCommentsInGraphView);
            EditorPrefs.SetBool("PlayMaker.ShowStateLabelsInGameView", ShowStateLabelsInGameView);
            EditorPrefs.SetBool("PlayMaker.ShowStateDescription", ShowStateDescription);
            EditorPrefs.SetBool("PlayMaker.ShowActionParameters", ShowActionParameters);
            EditorPrefs.SetBool("PlayMaker.DebugActionParameters", DebugActionParameters);
            EditorPrefs.SetBool("PlayMaker.DrawPlaymakerGizmos", DrawPlaymakerGizmos);
            EditorPrefs.SetBool("PlayMaker.DrawPlaymakerGizmoInHierarchy", DrawPlaymakerGizmoInHierarchy);
            EditorPrefs.SetBool("PlayMaker.ShowEditWhileRunningWarning", ShowEditWhileRunningWarning);
            EditorPrefs.SetBool("PlayMaker.HideUnusedEvents", HideUnusedEvents);
            EditorPrefs.SetBool("PlayMaker.ShowActionPreview", ShowActionPreview);
            EditorPrefs.SetInt("PlayMaker.SelectedActionCategory", SelectedActionCategory);
            EditorPrefs.SetBool("PlayMaker.SelectFSMInGameView", SelectFSMInGameView);
            EditorPrefs.SetInt("PlayMaker.DebugLookAtColor", PackColorIntoInt(DebugLookAtColor));
            EditorPrefs.SetInt("PlayMaker.DebugRaycastColor", PackColorIntoInt(DebugRaycastColor));
            EditorPrefs.SetBool("PlayMaker.HideUnusedParams", HideUnusedParams);
            EditorPrefs.SetBool("PlayMaker.EnableRealtimeErrorChecker", EnableRealtimeErrorChecker);
            EditorPrefs.SetBool("PlayMaker.AutoAddPlayMakerGUI", AutoAddPlayMakerGUI);
            EditorPrefs.SetBool("PlayMaker.DimUnusedParameters", DimUnusedActionParameters);
            EditorPrefs.SetBool("PlayMaker.AddPrefabLabel", AddPrefabLabel);
            EditorPrefs.SetBool("PlayMaker.AutoLoadPrefabs", AutoLoadPrefabs);
            EditorPrefs.SetBool("PlayMaker.LoadAllPrefabs", LoadAllPrefabs);
            EditorPrefs.SetBool("PlayMaker.UnloadPrefabs", UnloadPrefabs);
            EditorPrefs.SetInt("PlayMaker.StateMaxWidth", StateMaxWidth);
            EditorPrefs.SetBool("PlayMaker.ShowScrollBars", ShowScrollBars);
            EditorPrefs.SetBool("PlayMaker.ShowWatermark", EnableWatermarks);
            EditorPrefs.SetInt("PlayMaker.SnapGridSize", SnapGridSize);
            EditorPrefs.SetBool("PlayMaker.SnapToGrid", SnapToGrid);
            EditorPrefs.SetBool("PlayMaker.EnableLogging", EnableLogging);
            EditorPrefs.SetBool("PlayMaker.DisableErrorCheckerWhenPlaying", DisableErrorCheckerWhenPlaying);
            EditorPrefs.SetBool("PlayMaker.ColorLinks", ColorLinks);
            EditorPrefs.SetBool("PlayMaker.HideObsoleteActions", HideObsoleteActions);
            EditorPrefs.SetFloat("PlayMaker.EdgeScrollSpeed", EdgeScrollSpeed);
            EditorPrefs.SetFloat("PlayMaker.AutoPanZone", EdgeScrollZone);
            EditorPrefs.SetBool("PlayMaker.CheckForRequiredComponent", CheckForRequiredComponent);
            EditorPrefs.SetBool("PlayMaker.CheckForRequiredField", CheckForRequiredField);
            EditorPrefs.SetBool("PlayMaker.CheckForTransitionMissingEvent", CheckForTransitionMissingEvent);
            EditorPrefs.SetBool("PlayMaker.CheckForTransitionMissingTarget", CheckForTransitionMissingTarget);
            EditorPrefs.SetBool("PlayMaker.CheckForDuplicateTransitionEvent", CheckForDuplicateTransitionEvent);
            EditorPrefs.SetBool("PlayMaker.CheckForMouseEventErrors", CheckForMouseEventErrors);
            EditorPrefs.SetBool("PlayMaker.CheckForCollisionEventErrors", CheckForCollisionEventErrors);
            EditorPrefs.SetBool("PlayMaker.CheckForEventNotUsed", CheckForEventNotUsed);
            EditorPrefs.SetBool("PlayMaker.CheckForPrefabRestrictions", CheckForPrefabRestrictions);
            EditorPrefs.SetBool("PlayMaker.CheckForObsoleteActions", CheckForObsoleteActions);
            EditorPrefs.SetBool("PlayMaker.CheckForMissingActions", CheckForMissingActions);
            EditorPrefs.SetBool("PlayMaker.CheckForNetworkSetupErrors", CheckForNetworkSetupErrors);
            EditorPrefs.SetInt("PlayMaker.ColorScheme", (int)ColorScheme);
            EditorPrefs.SetBool("PlayMaker.DisableEditorWhenPlaying", DisableEditorWhenPlaying);
            EditorPrefs.SetBool("PlayMaker.DisableInspectorWhenPlaying", DisableInspectorWhenPlaying);
            EditorPrefs.SetBool("PlayMaker.DisableToolWindowsWhenPlaying", DisableToolWindowsWhenPlaying);
            EditorPrefs.SetBool("PlayMaker.DisableActionBrowerWhenPlaying", DisableActionBrowerWhenPlaying);
            EditorPrefs.SetBool("PlayMaker.DisableEventBrowserWhenPlaying", DisableEventBrowserWhenPlaying);
            EditorPrefs.SetBool("PlayMaker.ShowHints", ShowHints);
            EditorPrefs.SetBool("PlayMaker.CloseActionBrowserOnEnter", CloseActionBrowserOnEnter);
            EditorPrefs.SetBool("PlayMaker.LogPauseOnSelect", LogPauseOnSelect);
            EditorPrefs.SetBool("PlayMaker.LogShowSentBy", LogShowSentBy);
            EditorPrefs.SetBool("PlayMaker.LogShowExit", LogShowExit);
            EditorPrefs.SetBool("PlayMaker.LogShowTimecode", LogShowTimecode);
            EditorPrefs.SetBool("PlayMaker.EnableDebugFlow", EnableDebugFlow);
            EditorPrefs.SetBool("PlayMaker.EnableTransitionEffects", EnableTransitionEffects);
            EditorPrefs.SetInt("PlayMaker.ConsoleActionReportSortOptionIndex", ConsoleActionReportSortOptionIndex);
            EditorPrefs.SetBool("PlayMaker.DebugVariables", DebugVariables);
            EditorPrefs.SetBool("PlayMaker.SelectNewVariables", SelectNewVariables);
            EditorPrefs.SetBool("PlayMaker.FsmBrowserShowFullPath", FsmBrowserShowFullPath);
            EditorPrefs.SetBool("PlayMaker.AutoRefreshActionUsage", AutoRefreshActionUsage);
            SkillEditor.Repaint(true);
        }
        [Localizable(false)]
        public static void LoadSettings()
        {
            if (settingsLoaded)
            {
                return;
            }
            settingsLoaded = true;
            selectedCulture = 0;
            string @string = EditorPrefs.GetString("PlayMaker.Language", "");
            for (int i = 0; i < supportedCultures.Length; i++)
            {
                string text = supportedCultures[i];
                if (text == @string)
                {
                    selectedCulture = i;
                }
            }
            ActionBrowserRecentSize = EditorPrefs.GetInt("PlayMaker.ActionBrowserRecentSize", 20);
            DebuggerStepMode = (NDDebugger.NDStepMode)EditorPrefs.GetInt("PlayMaker.DebuggerStepMode", 0);
            DisableUndoRedo = EditorPrefs.GetBool("PlayMaker.DisableUndoRedo", false);
            MaximizeFileCompatibility = EditorPrefs.GetBool("PlayMaker.MaximizeFileCompatibility", true);
            DrawAssetThumbnail = EditorPrefs.GetBool("PlayMaker.DrawAssetThumbnail", true);
            DrawLinksBehindStates = EditorPrefs.GetBool("PlayMaker.DrawLinksBehindStates", true);
            DimFinishedActions = EditorPrefs.GetBool("PlayMaker.DimFinishedActions", true);
            AutoRefreshFsmInfo = EditorPrefs.GetBool("PlayMaker.AutoRefreshFsmInfo", true);
            ConfirmEditingPrefabInstances = EditorPrefs.GetBool("PlayMaker.ConfirmEditingPrefabInstances", true);
            ShowStateLoopCounts = EditorPrefs.GetBool("PlayMaker.ShowStateLoopCounts", false);
            DrawFrameAroundGraph = EditorPrefs.GetBool("PlayMaker.DrawFrameAroundGraph", false);
            GraphViewShowMinimap = EditorPrefs.GetBool("PlayMaker.GraphViewShowMinimap", true);
            GraphViewMinimapSize = EditorPrefs.GetFloat("PlayMaker.GraphViewMinimapSize", 300f);
            GraphViewZoomSpeed = EditorPrefs.GetFloat("PlayMaker.GraphViewZoomSpeed", 0.01f);
            MouseWheelScrollsGraphView = EditorPrefs.GetBool("PlayMaker.MouseWheelScrollsGraphView", false);
            ScreenshotsPath = EditorPrefs.GetString("PlayMaker.ScreenshotsPath", "PlayMaker/Screenshots");
            DebugVariables = EditorPrefs.GetBool("PlayMaker.DebugVariables", false);
            ConsoleActionReportSortOptionIndex = EditorPrefs.GetInt("PlayMaker.ConsoleActionReportSortOptionIndex", 1);
            LogPauseOnSelect = EditorPrefs.GetBool("PlayMaker.LogPauseOnSelect", true);
            LogShowSentBy = EditorPrefs.GetBool("PlayMaker.LogShowSentBy", true);
            LogShowExit = EditorPrefs.GetBool("PlayMaker.LogShowExit", true);
            LogShowTimecode = EditorPrefs.GetBool("PlayMaker.LogShowTimecode", false);
            ShowHints = EditorPrefs.GetBool("PlayMaker.ShowHints", true);
            CloseActionBrowserOnEnter = EditorPrefs.GetBool("PlayMaker.CloseActionBrowserOnEnter", false);
            DisableEditorWhenPlaying = EditorPrefs.GetBool("PlayMaker.DisableEditorWhenPlaying", false);
            DisableInspectorWhenPlaying = EditorPrefs.GetBool("PlayMaker.DisableInspectorWhenPlaying", false);
            DisableToolWindowsWhenPlaying = EditorPrefs.GetBool("PlayMaker.DisableToolWindowsWhenPlaying", true);
            DisableActionBrowerWhenPlaying = EditorPrefs.GetBool("PlayMaker.DisableActionBrowerWhenPlaying", false);
            DisableEventBrowserWhenPlaying = EditorPrefs.GetBool("PlayMaker.DisableEventBrowserWhenPlaying", false);
            ColorScheme = (SkillEditorStyles.ColorScheme)EditorPrefs.GetInt("PlayMaker.ColorScheme", 0);
            EnableRealtimeErrorChecker = EditorPrefs.GetBool("PlayMaker.EnableRealtimeErrorChecker", true);
            CheckForRequiredComponent = EditorPrefs.GetBool("PlayMaker.CheckForRequiredComponent", true);
            CheckForRequiredField = EditorPrefs.GetBool("PlayMaker.CheckForRequiredField", true);
            CheckForEventNotUsed = EditorPrefs.GetBool("PlayMaker.CheckForEventNotUsed", true);
            CheckForTransitionMissingEvent = EditorPrefs.GetBool("PlayMaker.CheckForTransitionMissingEvent", true);
            CheckForTransitionMissingTarget = EditorPrefs.GetBool("PlayMaker.CheckForTransitionMissingTarget", true);
            CheckForDuplicateTransitionEvent = EditorPrefs.GetBool("PlayMaker.CheckForDuplicateTransitionEvent", true);
            CheckForMouseEventErrors = EditorPrefs.GetBool("PlayMaker.CheckForMouseEventErrors", true);
            CheckForCollisionEventErrors = EditorPrefs.GetBool("PlayMaker.CheckForCollisionEventErrors", true);
            CheckForPrefabRestrictions = EditorPrefs.GetBool("PlayMaker.CheckForPrefabRestrictions", true);
            CheckForObsoleteActions = EditorPrefs.GetBool("PlayMaker.CheckForObsoleteActions", true);
            CheckForMissingActions = EditorPrefs.GetBool("PlayMaker.CheckForMissingActions", true);
            CheckForNetworkSetupErrors = EditorPrefs.GetBool("PlayMaker.CheckForNetworkSetupErrors", true);
            EdgeScrollZone = EditorPrefs.GetFloat("PlayMaker.AutoPanZone", 100f);
            EdgeScrollSpeed = EditorPrefs.GetFloat("PlayMaker.EdgeScrollSpeed", 1f);
            HideObsoleteActions = EditorPrefs.GetBool("PlayMaker.HideObsoleteActions", true);
            ColorLinks = EditorPrefs.GetBool("PlayMaker.ColorLinks", false);
            DisableErrorCheckerWhenPlaying = EditorPrefs.GetBool("PlayMaker.DisableErrorCheckerWhenPlaying", true);
            EnableLogging = EditorPrefs.GetBool("PlayMaker.EnableLogging", true);
            SnapGridSize = EditorPrefs.GetInt("PlayMaker.SnapGridSize", 16);
            SnapToGrid = EditorPrefs.GetBool("PlayMaker.SnapToGrid", false);
            ShowScrollBars = EditorPrefs.GetBool("PlayMaker.ShowScrollBars", true);
            EnableWatermarks = EditorPrefs.GetBool("PlayMaker.ShowWatermark", true);
            StateMaxWidth = EditorPrefs.GetInt("PlayMaker.StateMaxWidth", 400);
            AddPrefabLabel = EditorPrefs.GetBool("PlayMaker.AddPrefabLabel", true);
            AutoLoadPrefabs = EditorPrefs.GetBool("PlayMaker.AutoLoadPrefabs", true);
            LoadAllPrefabs = EditorPrefs.GetBool("PlayMaker.LoadAllPrefabs", true);
            UnloadPrefabs = EditorPrefs.GetBool("PlayMaker.UnloadPrefabs", true);
            StartStateName = EditorPrefs.GetString("PlayMaker.StartStateName", "State 1");
            NewStateName = EditorPrefs.GetString("PlayMaker.NewStateName", Strings.get_FsmEditorSettings_Default_State_Name());
            AutoSelectGameObject = EditorPrefs.GetBool("PlayMaker.AutoSelectGameObject", true);
            SelectStateOnActivated = EditorPrefs.GetBool("PlayMaker.SelectStateOnActivated", true);
            JumpToBreakpoint = EditorPrefs.GetBool("PlayMaker.GotoBreakpoint", true);
            GameStateIconSize = EditorPrefs.GetInt("PlayMaker.GameStateIconSize", 32);
            FrameSelectedState = EditorPrefs.GetBool("PlayMaker.FrameSelectedState", false);
            SyncLogSelection = EditorPrefs.GetBool("PlayMaker.SyncLogSelection", true);
            BreakpointsEnabled = EditorPrefs.GetBool("PlayMaker.BreakpointsEnabled", true);
            MirrorDebugLog = EditorPrefs.GetBool("PlayMaker.MirrorDebugLog", false);
            LockGraphView = EditorPrefs.GetBool("PlayMaker.LockGraphView", false);
            GraphViewLinkStyle = (GraphViewLinkStyle)EditorPrefs.GetInt("PlayMaker.GraphLinkStyle", 0);
            ShowFsmDescriptionInGraphView = EditorPrefs.GetBool("PlayMaker.ShowFsmDescriptionInGraphView", true);
            ShowCommentsInGraphView = EditorPrefs.GetBool("PlayMaker.ShowCommentsInGraphView", true);
            ShowStateLabelsInGameView = EditorPrefs.GetBool("PlayMaker.ShowStateLabelsInGameView", true);
            DrawPlaymakerGizmos = EditorPrefs.GetBool("PlayMaker.DrawPlaymakerGizmos", true);
            DrawPlaymakerGizmoInHierarchy = EditorPrefs.GetBool("PlayMaker.DrawPlaymakerGizmoInHierarchy", true);
            ShowEditWhileRunningWarning = EditorPrefs.GetBool("PlayMaker.ShowEditWhileRunningWarning", true);
            ShowStateDescription = EditorPrefs.GetBool("PlayMaker.ShowStateDescription", true);
            ShowActionParameters = true;
            DebugActionParameters = EditorPrefs.GetBool("PlayMaker.DebugActionParameters", false);
            HideUnusedEvents = EditorPrefs.GetBool("PlayMaker.HideUnusedEvents", false);
            ShowActionPreview = EditorPrefs.GetBool("PlayMaker.ShowActionPreview", true);
            SelectedActionCategory = EditorPrefs.GetInt("PlayMaker.SelectedActionCategory", 0);
            SelectFSMInGameView = EditorPrefs.GetBool("PlayMaker.SelectFSMInGameView", true);
            DebugLookAtColor = UnpackColorFromInt(EditorPrefs.GetInt("PlayMaker.DebugLookAtColor", PackColorIntoInt(Color.get_gray())));
            DebugRaycastColor = UnpackColorFromInt(EditorPrefs.GetInt("PlayMaker.DebugRaycastColor", PackColorIntoInt(Color.get_gray())));
            HideUnusedParams = EditorPrefs.GetBool("PlayMaker.HideUnusedParams", false);
            AutoAddPlayMakerGUI = EditorPrefs.GetBool("PlayMaker.AutoAddPlayMakerGUI", true);
            DimUnusedActionParameters = EditorPrefs.GetBool("PlayMaker.DimUnusedParameters", false);
            SelectNewVariables = EditorPrefs.GetBool("PlayMaker.SelectNewVariables", true);
            FsmBrowserShowFullPath = EditorPrefs.GetBool("PlayMaker.FsmBrowserShowFullPath", true);
            EnableDebugFlow = EditorPrefs.GetBool("PlayMaker.EnableDebugFlow", true);
            EnableTransitionEffects = EditorPrefs.GetBool("PlayMaker.EnableTransitionEffects", true);
            AutoRefreshActionUsage = EditorPrefs.GetBool("PlayMaker.AutoRefreshActionUsage", true);
            ValidateSettings();
            ApplySettings();
            SaveSettings();
        }
        private static void ValidateSettings()
        {
            if (string.IsNullOrEmpty(NewStateName) || StateMaxWidth == 0)
            {
                Debug.LogWarning(Strings.get_FsmEditorSettings_Preferences_Reset());
                ResetDefaults();
            }
            EdgeScrollSpeed = Mathf.Clamp(EdgeScrollSpeed, 0.1f, 10f);
        }
        private static void ApplySettings()
        {
            NDDebugger.Instance.StepMode = DebuggerStepMode;
            SkillLog.set_MirrorDebugLog(MirrorDebugLog);
            SkillLog.set_LoggingEnabled(EnableLogging);
            SkillLog.set_EnableDebugFlow(EnableDebugFlow);
            Skill.set_BreakpointsEnabled(BreakpointsEnabled);
            PlayMakerFSM.set_DrawGizmos(DrawPlaymakerGizmos);
            Skill.set_DebugLookAtColor(DebugLookAtColor);
            Skill.set_DebugRaycastColor(DebugRaycastColor);
            PlayMakerGUI.set_EnableStateLabels(ShowStateLabelsInGameView);
            SetCulture(selectedCulture);
            if (SkillEditor.Instance != null)
            {
                SkillEditor.GraphView.ApplySettings();
            }
        }
        public static int PackColorIntoInt(Color color)
        {
            int num = (int)(color.r * 255f);
            int num2 = (int)(color.g * 255f);
            int num3 = (int)(color.b * 255f);
            return num << 16 | num2 << 8 | num3;
        }
        public static Color UnpackColorFromInt(int packedValue)
        {
            int num = packedValue >> 16;
            int num2 = packedValue >> 8 & 255;
            int num3 = packedValue & 255;
            return new Color((float)num / 255f, (float)num2 / 255f, (float)num3 / 255f, 1f);
        }
    }
}
