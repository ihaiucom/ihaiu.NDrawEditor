using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ihaiu.NDraws
{
    public class NDEditorMenu 
    {
        public class SkillEditorMenu 
        {

            private const string MenuRoot = "Node Draw/"; 

            [MenuItem(MenuRoot + "Node Draw Editor Window", false, 0)]
            public static void OpenSkillEditorWindow()
            {
                NDEditorWindow.OpenWindow();
            }
        }
	
	}
}
