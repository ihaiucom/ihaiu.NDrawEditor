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
//            this.DoGameStateIcon();
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
//            this.zoom = this.canvasView.SetZoom(SkillEditor.Selection.Zoom);
//            this.InitScale(this.zoom);
//            this.canvasView.SetContentScrollPosition(SkillEditor.Selection.ScrollPosition);
//            this.UpdateVisibility();
//            NDGraphView.Repaint(true);
        }



        private void DrawBackground()
        {
//            if (this.eventType == 7)
//            {
//                SkillEditorStyles.Background.Draw(this.view, false, false, false, false);
//                if (this.canvasView.TakingScreenshot && !this.canvasView.ScreenshotFirstTile)
//                {
//                    return;
//                }
//                if (FsmEditorSettings.EnableWatermarks)
//                {
//                    this.DrawWatermark();
//                }
//                if (SkillEditor.SelectedFsm == null)
//                {
//                    this.DoSelectionHints();
//                }
//                else
//                {
//                    string text = (SkillEditor.SelectedTemplate != null) ? string.Format(Strings.get_Label_Selected_Template(), SkillEditor.SelectedTemplate.get_name()) : Labels.GetFullFsmLabel(SkillEditor.SelectedFsm);
//                    this.DoLargeWatermarkText(text);
//                    if (FsmEditorSettings.ShowFsmDescriptionInGraphView)
//                    {
//                        this.DrawFsmDescription(SkillEditor.SelectedFsm);
//                    }
//                }
//            }
//            if (!Application.get_isPlaying() && SkillEditor.SelectedFsmComponent != null && SkillEditor.SelectedFsmComponent.get_FsmTemplate() != null && GUI.Button(this.view, Strings.get_FsmGraphView_Click_to_Edit_Template(), SkillEditorStyles.CenteredLabel))
//            {
//                SkillEditor.SelectFsm(SkillEditor.SelectedFsmComponent.get_FsmTemplate().fsm);
//            }
        }
    }
}
