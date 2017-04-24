using UnityEngine;
using System.Collections;


namespace ihaiu.NDraws
{
    public class NDEditorWindow : BaseEditorWindow
    {

        public static void OpenWindow()
        {
            GetWindow<NDEditorWindow>();
        }

        private static NDEditorWindow instance;
        public static bool IsOpen()
        {
            return instance != null;
        }


        public NDEditor ndEditor;

        public override void Initialize()
        {
            instance = this;

            if (ndEditor == null)
            {
                ndEditor = new NDEditor();
            }

            ndEditor.InitWindow(this);
            ndEditor.OnEnable();
        }


        override public void DoGUI()
        {
            ndEditor.OnGUI();
        }
    }

}