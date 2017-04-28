using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
namespace ihaiu.NDraws
{
    [Localizable(false)]
    [Serializable]
    internal class NDDebugger
    {
        internal enum NDStepMode
        {
            StepFrame,
            StepToStateChange,
            StepToAnyStateChange
        }
        private static NDDebugger instance;
        [SerializeField]
        private NDDebugger.NDStepMode stepMode;
        public static NDDebugger Instance
        {
            get
            {
                if (NDDebugger.instance == null)
                {
                    NDDebugger.instance = new NDDebugger();
                    NDDebugger.instance.Init();
                }
                return NDDebugger.instance;
            }
        }
        public NDDebugger.NDStepMode StepMode
        {
            get
            {
                return this.stepMode;
            }
            set
            {
                this.stepMode = value;
            }
        }
        public void Init()
        {
            Application.logMessageReceived -= this.HandleLog;
            Application.logMessageReceived += this.HandleLog;
        }
        public void HandleLog(string logEntry, string stackTrace, LogType type)
        {
//            if (type != null || SkillExecutionStack.get_ExecutingFsm() == null || GameStateTracker.CurrentState == GameState.Stopped || !stackTrace.Contains("HutongGames.PlayMaker") || stackTrace.Contains("HutongGames.PlayMaker.Fsm:LogError(String)"))
//            {
//                return;
//            }
//            SkillExecutionStack.get_ExecutingFsm().DoBreakError(logEntry);
//            NDDebugger.DoBreak();
        }
        public void Update()
        {
//            if (GameStateTracker.CurrentState == GameState.Stopped)
//            {
//                return;
//            }
//            using (List<PlayMakerFSM>.Enumerator enumerator = PlayMakerFSM.get_FsmList().GetEnumerator())
//            {
//                while (enumerator.MoveNext())
//                {
//                    PlayMakerFSM current = enumerator.get_Current();
//                    if (current != null)
//                    {
//                        this.Watch(current.get_Fsm());
//                    }
//                }
//            }
//            if (Skill.get_HitBreakpoint())
//            {
//                NDDebugger.DoBreak();
//            }
        }
        public void Watch(NDChart chart)
        {
//            if (chart.get_SwitchedState())
//            {
//                SkillEditor.RepaintAll();
//                if (FsmEditorSettings.SelectStateOnActivated && SkillEditor.Instance != null && SkillEditor.SelectedFsm == chart)
//                {
//                    SkillEditor.SelectState(chart.get_ActiveState(), false);
//                }
//                chart.set_SwitchedState(false);
//            }
        }
        private static void DoBreak()
        {
//            if (Skill.get_IsErrorBreak())
//            {
//                FsmErrorChecker.AddRuntimeError(Skill.get_LastError());
//            }
//            if (FsmEditorSettings.JumpToBreakpoint && SkillEditor.Instance != null)
//            {
//                SkillEditor.GotoBreakpoint();
//            }
//            Skill.set_HitBreakpoint(false);
//            EditorApplication.set_isPaused(true);
        }
        public void Step()
        {
//            switch (this.StepMode)
//            {
//                case NDDebugger.NDStepMode.StepFrame:
//                    EditorApplication.set_isPaused(false);
//                    EditorApplication.Step();
//                    Skill.set_StepToStateChange(false);
//                    break;
//                case NDDebugger.NDStepMode.StepToStateChange:
//                    EditorApplication.set_isPaused(false);
//                    Skill.set_StepToStateChange(true);
//                    Skill.set_StepFsm(SkillEditor.SelectedFsm);
//                    break;
//                case NDDebugger.NDStepMode.StepToAnyStateChange:
//                    EditorApplication.set_isPaused(false);
//                    Skill.set_StepToStateChange(true);
//                    Skill.set_StepFsm(null);
//                    break;
//            }
//            DebugFlow.UpdateTime();
        }
        public void ResetStep()
        {
//            Skill.set_StepToStateChange(false);
        }
        public void OnDestroy()
        {
//            Application.remove_logMessageReceived(new Application.LogCallback(this.HandleLog));
        }
    }
}
