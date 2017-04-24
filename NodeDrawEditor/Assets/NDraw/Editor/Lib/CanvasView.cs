using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ihaiu.NDraws
{
    public class CanvasView 
    {
        public class Marker
        {
            public Vector2 pos;
            public Color color;
        }

        private EditorWindow parentWindow;
        private bool viewRectInitialized;

        private float contentMargin = 0.5f;

        public float ContentMargin
        {
            get
            {
                return this.contentMargin;
            }
            set
            {
                this.contentMargin = value;
            }
        }

        public void Init(EditorWindow window)
        {
            this.parentWindow = window;
            this.viewRectInitialized = false;
        }
    }

}