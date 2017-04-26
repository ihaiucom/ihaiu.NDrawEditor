using UnityEngine;
using System.Collections;


namespace ihaiu.NDraws
{
    public class NDEditorSettings 
    {
        public static string ProductName = "Node Draw Editor";
        public static string RootChart = "Assets/Game/MResources/Chart/"; 

        public static NDEditorStyles.ColorScheme ColorScheme
        {
            get;
            set;
        }

        public static void LoadSettings()
        {
        }
    }

}