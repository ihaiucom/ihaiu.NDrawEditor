using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ihaiu.NDraws
{
    public class NDEditorGUILayout 
    {
        public static bool ToolWindowsCommonGUI(EditorWindow window)
        {
//            if (NDEditor.Instance == null)
//            {
//                window.Close();
//                return false;
//            }
//            if (NDEditorGUILayout.DoToolWindowsDisabledGUI())
//            {
//                return false;
//            }
//            if (EditorApplication.isCompiling)
//            {
//                GUI.enabled = false;
//            }
//
//            NDEditorStyles.Init();
//            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.F1 )
//            {
//                EditorCommands.ToggleShowHints();
//                return false;
//            }
//            EditorGUI.indentLevel = 0;
            return true;
        }

        private static bool DoToolWindowsDisabledGUI()
        {
//            if (NDEditorGUILayout.DoEditorDisabledGUI())
//            {
//                return true;
//            }
//            if (EditorApplication.isPlaying && NDEditorSettings.DisableToolWindowsWhenPlaying)
//            {
//                GUILayout.Label(Strings.Label_Tool_Windows_disabled_when_playing, new GUILayoutOption[0]);
//                NDEditorSettings.DisableToolWindowsWhenPlaying = !GUILayout.Toggle(!NDEditorSettings.DisableToolWindowsWhenPlaying, Strings.Label_Enable_Tool_Windows_When_Playing, new GUILayoutOption[0]);
//                if (GUI.changed)
//                {
//                    NDEditorSettings.SaveSettings();
//                }
//                return NDEditorSettings.DisableToolWindowsWhenPlaying;
//            }
            return false;
        }

        public static bool DoEditorDisabledGUI()
        {
//            if (EditorApplication.isPlaying && NDEditorSettings.DisableEditorWhenPlaying)
//            {
//                GUILayout.Label(Strings.Label_Editor_disabled_when_playing, new GUILayoutOption[0]);
//                NDEditorSettings.DisableEditorWhenPlaying = !GUILayout.Toggle(!NDEditorSettings.DisableEditorWhenPlaying, Strings.Label_Enable_Editor_When_Playing, new GUILayoutOption[0]);
//                if (GUI.changed)
//                {
//                    NDEditorSettings.SaveSettings();
//                }
//                return NDEditorSettings.DisableEditorWhenPlaying;
//            }
            return false;
        }
    }
}
