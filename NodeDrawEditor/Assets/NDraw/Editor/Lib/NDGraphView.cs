using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ihaiu.NDraws
{
    public class NDGraphView 
    {

        private enum DraggingMode
        {
            None,
            State,
            Transition,
            Selection,
            Minimap
        }
        private enum DragConstraint
        {
            None,
            X,
            Y
        }

        private NDGraphView.DraggingMode draggingMode;
        private readonly CanvasView canvasView;
        private Vector2 graphSize;
        private Rect view;
        private float zoom = 1f;
        private Event currentEvent;
        private EventType eventType;

        public bool IsDragging
        {
            get
            {
                return this.draggingMode != NDGraphView.DraggingMode.None;
            }
        }

        public NDGraphView()
        {
            this.canvasView = new CanvasView
                {
                    ContentMargin = 300f
                };
        }

        public void Init()
        {
            this.canvasView.Init(NDEditor.Window);
            this.RefreshView();
        }

        public void EnableEditing()
        {
//            NDGraphView.editingDisabled = false;
        }

        public void DisableEditing(string reason)
        {
//            NDGraphView.editingDisabled = true;
//            NDGraphView.editingDisabledReason = reason;
        }

        public void OnGUI(Rect area)
        {
            if (NDEditor.SelectedChartIsLocked)
            {
                GUILayout.Label("LOCKED", new GUILayoutOption[0]);
            }

            EditorGUI.BeginDisabledGroup(NDEditor.SelectedChartIsLocked);
            this.view = area;
            this.currentEvent = Event.current;
            this.eventType = this.currentEvent.type;
            this.DrawBackground();
//            this.DoCanvasView();
//            this.DoMinimap();
            this.DoGameStateIcon();
//            this.DrawFrame();
//            this.DrawHintBox();
//            this.DoDebugText();
            EditorGUI.EndDisabledGroup();
        }

        public void Update()
        {
//            this.canvasView.Update();
//            if (NDGraphView.updateVisibility)
//            {
//                this.DoUpdateVisibility();
//            }
        }

        public void RefreshView()
        {
//            this.UpdateGraphSize();
//            this.zoom = this.canvasView.SetZoom(NDEditor.Selection.Zoom);
//            this.InitScale(this.zoom);
//            this.canvasView.SetContentScrollPosition(NDEditor.Selection.ScrollPosition);
//            this.UpdateVisibility();
//            NDGraphView.Repaint(true);
        }



        private void DrawBackground()
        {
//            if (this.eventType == 7)
//            {
//                NDEditorStyles.Background.Draw(this.view, false, false, false, false);
//                if (this.canvasView.TakingScreenshot && !this.canvasView.ScreenshotFirstTile)
//                {
//                    return;
//                }
//                if (FsmEditorSettings.EnableWatermarks)
//                {
//                    this.DrawWatermark();
//                }
//                if (NDEditor.SelectedFsm == null)
//                {
//                    this.DoSelectionHints();
//                }
//                else
//                {
//                    string text = (NDEditor.SelectedTemplate != null) ? string.Format(Strings.get_Label_Selected_Template(), NDEditor.SelectedTemplate.get_name()) : Labels.GetFullFsmLabel(NDEditor.SelectedFsm);
//                    this.DoLargeWatermarkText(text);
//                    if (FsmEditorSettings.ShowFsmDescriptionInGraphView)
//                    {
//                        this.DrawFsmDescription(NDEditor.SelectedFsm);
//                    }
//                }
//            }
//            if (!Application.get_isPlaying() && NDEditor.SelectedFsmComponent != null && NDEditor.SelectedFsmComponent.get_FsmTemplate() != null && GUI.Button(this.view, Strings.get_FsmGraphView_Click_to_Edit_Template(), NDEditorStyles.CenteredLabel))
//            {
//                NDEditor.SelectFsm(NDEditor.SelectedFsmComponent.get_FsmTemplate().fsm);
//            }
        }

        private void DoGameStateIcon()
        {
//            if (NDEditor.SelectedChart == null || !EditorApplication.isPlaying)
//            {
//                return;
//            }
            float num = (float)NDEditorSettings.GameStateIconSize ;
            Rect rect = new Rect(10f, this.view.height - num, num, num + 20f);
//            if (NDEditor.SelectChart.get_Active() && !NDEditor.SelectChart.get_Finished())
//            {
//                Texture2D texture2D = NDEditorStyles.GetGameStateIcons()[(int)GameStateTracker.CurrentState];
//                if (texture2D != null && GUI.Button(rect, texture2D, GUIStyle.none))
//                {
//                    switch (GameStateTracker.CurrentState)
//                    {
//                        case GameState.Running:
//                            EditorApplication.isPaused = true;
//                            break;
//                        case GameState.Break:
//                        case GameState.Error:
//                            NDEditor.GotoBreakpoint();
//                            break;
//                        case GameState.Paused:
//                            EditorApplication.isPaused = false;
//                            break;
//                    }
//                }
//            }
            Color color         = GUI.color;
            DrawState drawState = NDDrawState.GetDrawNode(NDEditor.SelectedChart);
            GUI.color           = NDEditorStyles.HighlightColors[(int)drawState];
            rect.y              = rect.y - 3f;
            rect.width          = this.view.width - rect.width;

            string text;
            if (!NDEditor.SelectedChart.Active)
            {
                rect.x      = 5;
                text        = Strings.Label_DISABLED;
                GUI.color   = NDEditorStyles.LargeWatermarkText.normal.textColor;
            }
            else
            {
                if (NDEditor.SelectedChart.Finished)
                {
                    rect.x      = 5;
                    text        = Strings.Label_FINISHED;
                    GUI.color   = NDEditorStyles.LargeWatermarkText.normal.textColor;
                }
                else
                {
                    rect.x = 45;

//                    if (DebugFlow.ActiveAndScrubbing)
//                    {
//                        text = ((DebugFlow.DebugState != null) ? DebugFlow.DebugState.get_Name() : (" " + Strings.get_Label_None_In_Table()));
//                    }
//                    else
                    {
                        text = NDEditor.SelectedChart.ActiveNodeName;
                    }
                }
            }
            GUI.Box(rect, text, NDEditorStyles.LargeText);
            GUI.color = color;


        }
    }
}
