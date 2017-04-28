using System;
using UnityEditor;
using UnityEngine;
namespace ihaiu.NDraws
{
    public class Keyboard
    {
        private static bool resetFocus;
        public static bool IsGuiEventKeyboardShortcut()
        {
            if (GUIUtility.keyboardControl != 0)
            {
                return false;
            }
            int controlID = GUIUtility.GetControlID(1, FocusType.Keyboard);
            return Event.current.GetTypeForControl(controlID) == EventType.KeyDown;
        }
        public static void ResetFocus()
        {
            resetFocus = true;
        }
        public static void Update()
        {
            if (resetFocus)
            {
                GUIUtility.keyboardControl = 0;
                resetFocus = false;
            }
        }
        public static bool AltAction()
        {
            return Action() && Alt();
        }
        public static bool Alt()
        {
            return (Event.current.modifiers & EventModifiers.Alt) == EventModifiers.Alt;
        }
        public static bool Control()
        {
            return (Event.current.modifiers & EventModifiers.Control) == EventModifiers.Control;
        }
        public static bool Action()
        {
            return EditorGUI.actionKey;
        }
        public static bool EnterKeyPressed()
        {
            return Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter;
        }
        public static bool CommitKeyPressed()
        {
            return Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter;
        }
    }
}
