using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

namespace ihaiu.NDraws
{
    public class NDEditor 
    {

        public delegate void RepaintDelegate();
        public delegate void UpdateDelegate();

        public static NDEditor Instance
        {
            get
            {
                return NDEditor.instance;
            }
        }


        internal static NDGraphView GraphView
        {
            get
            {
                return NDEditor.instance.graphView;
            }
        }

        public static EditorWindow Window
        {
            get
            {
                if (NDEditor.instance != null)
                {
                    return NDEditor.instance.window;
                }
                return null;
            }
        }

       
        public static bool SelectedChartIsLocked
        {
            get
            {
                return false;
            }
        }



        public static NDEditor.RepaintDelegate   OnRepaint;
        public static NDEditor.UpdateDelegate    OnUpdate;

        private static NDEditor instance;

        [SerializeField]
        private bool initializedOnce;
        private static bool playerStarting;
        private static bool playerStopping;
        private readonly NDGraphView graphView;
       

        public  bool            Initialized;
        private EditorWindow    window;





        public NDEditor()
        {
            NDEditor.instance = this;
            this.graphView = new NDGraphView();
        }


        public void InitWindow(EditorWindow fsmEditorWindow)
        {
            this.window = fsmEditorWindow;
            this.window.titleContent = new GUIContent(NDEditorSettings.ProductName);
            this.window.minSize = new Vector2(800f, 200f);
            this.window.wantsMouseMove = true;
            this.Initialized = true;
        }

        public void OnEnable()
        {
            NDEditor.OnUpdate = (NDEditor.UpdateDelegate)Delegate.Remove(NDEditor.OnUpdate, new NDEditor.UpdateDelegate(this.FirstUpdate));
            NDEditor.OnUpdate = (NDEditor.UpdateDelegate)Delegate.Combine(NDEditor.OnUpdate, new NDEditor.UpdateDelegate(this.FirstUpdate));


            if (!this.initializedOnce)
            {
                this.initializedOnce = true;
            }

            this.graphView.Init();
        }

        public void OnGUI()
        {

            this.graphView.EnableEditing();
            this.graphView.OnGUI(new Rect(0, 0, this.window.position.width, this.window.position.height));

        }
        private void FirstUpdate()
        {
            if (!Application.isPlaying)
            {
            }
            NDEditor.OnUpdate = (NDEditor.UpdateDelegate)Delegate.Remove(NDEditor.OnUpdate, new NDEditor.UpdateDelegate(this.FirstUpdate));
        }
        public void Update()
        {

            if (NDEditor.playerStarting || this.window == null)
            {
                return;
            }
            if (NDEditor.OnUpdate != null)
            {
                NDEditor.OnUpdate();
            }

            this.graphView.Update();
        }


        public void OnHierarchyChange()
        {
            if (this.graphView.IsDragging)
            {
                return;
            }
        }

        private void ResetViews()
        {
            this.graphView.RefreshView();
        }
    }
}
