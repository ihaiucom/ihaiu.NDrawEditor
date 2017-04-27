using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace ihaiu.NDraws
{
    public class NDEditor 
    {
        #region delegate
        public delegate void RepaintDelegate();
        public delegate void UpdateDelegate();
        #endregion

        #region Static Property
        public static NDEditor Instance
        {
            get
            {
                return NDEditor.instance;
            }
        }

        internal static NDSelection Selection
        {
            get
            {
                if (NDEditor.instance == null)
                {
                    return null;
                }
                return NDEditor.instance.selection ?? new NDSelection(null);
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

        public static NDChart SelectedChart
        {
            get
            {
                if (NDEditor.instance != null)
                {
                    return NDEditor.instance.selection.ActiveChart;
                }
                return null;
            }
        }
       
        public static bool SelectedChartIsLocked
        {
            get
            {
                return SelectedChart != null && SelectedChart.Locked;
            }
        }

        public static NDNode SelectedNode
        {
            get
            {
                if (NDEditor.instance != null)
                {
                    return NDEditor.instance.selection.ActiveNode;
                }
                return null;
            }
        }

        public static List<NDNode> SelectedNodes
        {
            get
            {
                if (NDEditor.instance != null)
                {
                    return NDEditor.Selection.Nodes;
                }
                return null;
            }
        }
        public static NDTransition SelectedTransition
        {
            get
            {
                if (NDEditor.instance != null)
                {
                    return NDEditor.Selection.ActiveTransition;
                }
                return null;
            }
        }
        #endregion


        #region Static Attribute
        public static NDEditor.RepaintDelegate   OnRepaint;
        public static NDEditor.UpdateDelegate    OnUpdate;

        private static NDEditor instance;

        private static bool playerStarting;
        private static bool playerStopping;

        private static NDChart selectChartDelayed;
        #endregion

        #region Attribute
        [SerializeField]
        private bool                    initializedOnce;
        private readonly NDGraphView    graphView;

        [SerializeField]
        private NDSelection             selection;
        [SerializeField]
        private NDSelectionHistory      selectionHistory;
       

        public  bool            Initialized;
        private EditorWindow    window;
        #endregion





        #region Method
        public NDEditor()
        {
            NDEditor.instance = this;
            this.graphView          = new NDGraphView();
            this.selectionHistory   = new NDSelectionHistory();
            this.selection          = NDSelection.None;
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
        #endregion


        #region Static Method
    
        public static void SelectNone()
        {
            if (NDEditor.SelectedChart != null)
            {
                NDEditor.Selection.ActiveNode = null;
            }
            if (NDEditor.instance != null)
            {
                NDEditor.instance.selection = NDSelection.None;
                NDEditor.instance.ResetViews();
            }
        }
        public static void SelectChart(NDChart chart)
        {
            if (NDEditor.instance == null)
            {
                NDEditor.selectChartDelayed = chart;
                return;
            }
            Labels.Update(chart);
            if (chart == NDEditor.instance.selection.ActiveChart)
            {
                return;
            }
            NDEditor.SelectNone();
//
//            Keyboard.ResetFocus();
//            NDEditor.instance.fsmSelection = NDEditor.instance.selectionHistory.SelectFsm(chart);
//            PlayMakerGUI.SelectedFSM = NDEditor.SelectedFsm;
//            NDEditor.Builder.SetTarget(NDEditor.SelectedFsm);
//            if (NDEditor.SelectedFsm != null)
//            {
//                NDEditor.GraphView.UpdateGraphSize();
//                NDEditor.GraphView.SanityCheckGraphBounds();
//                NDEditor.GraphView.UpdateVisibility();
//                if (NDEditor.SelectedTemplate == null)
//                {
//                    NDEditor.AutoAddPlayMakerGUI();
//                    if (!EditorApplication.get_isPlayingOrWillChangePlaymode())
//                    {
//                        ActionReport.Remove(NDEditor.SelectedFsmComponent);
//                        NDEditor.SelectedFsm.Reinitialize();
//                    }
//                }
//                if (NDEditor.SelectedState != null)
//                {
//                    NDEditor.SelectedFsm.set_EditState(NDEditor.SelectedState);
//                }
//                if (!NDEditor.SelectedFsm.get_Initialized())
//                {
//                    NDEditor.SelectedFsm.Init(NDEditor.SelectedFsmComponent);
//                }
//                FsmInspector.Init();
//                NDEditor.SanityCheckFsm(NDEditor.SelectedFsm);
//                FsmErrorChecker.CheckFsmForErrors(chart, false);
//            }
//            if (!FsmEditorSettings.LockGraphView && FsmEditorSettings.AutoSelectGameObject)
//            {
//                NDEditor.Selection.SelectActiveFsmGameObject();
//            }
//            if (Application.get_isPlaying() && FsmEditorSettings.SelectStateOnActivated && NDEditor.SelectedFsm != null)
//            {
//                NDEditor.SelectState(NDEditor.SelectedFsm.get_ActiveState(), true);
//            }
//            VariableManager.SortVariables(NDEditor.SelectedFsm);
//            DebugFlow.SyncFsmLog(NDEditor.SelectedFsm);
//            Skill.set_StepToStateChange(false);
//            NDEditor.instance.ResetViews();
//            NDEditor.Repaint(true);
//            NDEditor.RepaintAll();
        }
        #endregion
    }
}
