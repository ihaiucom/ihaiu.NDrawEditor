using System;
using System.Collections.Generic;
using UnityEngine;
namespace ihaiu.NDraws
{
    public class NDLog
    {
        private const int MaxLogSize = 100000;
        private static readonly List<NDLog> Logs;
        private static bool loggingEnabled;
        private List<NDLogEntry> entries = new List<NDLogEntry>();
        public static bool LoggingEnabled
        {
            get
            {
                return NDLog.loggingEnabled;
            }
            set
            {
                NDLog.loggingEnabled = value;
            }
        }
        public static bool MirrorDebugLog
        {
            get;
            set;
        }
        public static bool EnableDebugFlow
        {
            get;
            set;
        }
        public NDChart Chart
        {
            get;
            private set;
        }
        public List<NDLogEntry> Entries
        {
            get
            {
                return this.entries;
            }
        }
        public bool Resized
        {
            get;
            set;
        }
        static NDLog()
        {
            NDLog.Logs = new List<NDLog>();
            NDLog.loggingEnabled = true;
            NDLog.loggingEnabled = !Application.isEditor;
        }
        private NDLog(NDChart chart)
        {
            this.Chart = chart;
        }
        public static NDLog GetLog(NDChart chart)
        {
            if (chart == null)
            {
                return null;
            }
            using (List<NDLog>.Enumerator enumerator = NDLog.Logs.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDLog current = enumerator.Current;
                    if (current.Chart == chart)
                    {
                        return current;
                    }
                }
            }
            NDLog fsmLog = new NDLog(chart);
            NDLog.Logs.Add(fsmLog);
            return fsmLog;
        }
        public static void ClearLogs()
        {
            using (List<NDLog>.Enumerator enumerator = NDLog.Logs.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDLog current = enumerator.Current;
                    current.Clear();
                }
            }
        }
        private void AddEntry(NDLogEntry entry, bool sendToUnityLog = false)
        {
            entry.Log = this;
            entry.Time = NDTime.RealtimeSinceStartup;
            entry.FrameCount = Time.frameCount;
           
            this.entries.Add(entry);
            if (this.entries.Count > 100000)
            {
                this.entries.RemoveRange(0, 10000);
                this.Resized = true;
            }
            switch (entry.LogType)
            {
                case NDLogType.Warning:
                    Debug.LogWarning(this.FormatUnityLogString(entry.Text));
                    return;
                case NDLogType.Error:
                    Debug.LogError(this.FormatUnityLogString(entry.Text));
                    return;
                default:
                    if ((NDLog.MirrorDebugLog || sendToUnityLog) && entry.LogType != NDLogType.Transition)
                    {
                        Debug.Log(this.FormatUnityLogString(entry.Text));
                    }
                    return;
            }
        }
       
        public void LogEvent(NDEvent ndEvent, NDNode node)
        {
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.Event,
                    Node = node,
//                    SentByState = Skill.EventData.SentByState,
//                    Action = Skill.EventData.SentByAction,
                    Event = ndEvent,
                    Text = "EVENT: " + ndEvent.Name
                };
            this.AddEntry(entry, false);
        }
        public void LogSendEvent(NDNode node, NDEvent fsmEvent, NDNode eventTarget)
        {
            if (node == null || fsmEvent == null || fsmEvent.IsSystemEvent)
            {
                return;
            }
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.SendEvent,
                    Node = node,
                    Event = fsmEvent,
                    Text = "SEND EVENT: " + fsmEvent.Name
//                    EventTarget = new SkillEventTarget(eventTarget)
                };
            this.AddEntry(entry, false);
        }
        public void LogExitState(NDNode node)
        {
            if (node == null)
            {
                return;
            }
            NDLogEntry fsmLogEntry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.ExitState,
                    Node = node,
                    Text = string.Concat(new string[]
                        {
                            "EXIT: ",
                            node.Name,
                            " [",
//                            string.Format("{0:f2}", NDTime.RealtimeSinceStartup - node.RealStartTime),
                            string.Format("{0:f2}", NDTime.RealtimeSinceStartup),
                            "s]"
                        })
                };
         
            this.AddEntry(fsmLogEntry, false);
        }
        public void LogEnterState(NDNode node)
        {
            if (node == null)
            {
                return;
            }
            NDLogEntry fsmLogEntry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.EnterState,
                    Node = node,
                    Text = "ENTER: " + node.Name
                };
         
            this.AddEntry(fsmLogEntry, false);
        }
        public void LogTransition(NDNode fromNode, NDTransition transition)
        {
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.Transition,
                    Node = fromNode,
                    Transition = transition
                };
            this.AddEntry(entry, false);
        }
        public void LogBreak()
        {
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.Break,
//                    Node = SkillExecutionStack.ExecutingState,
//                    Text = "BREAK: " + SkillExecutionStack.ExecutingStateName
                };
            Debug.Log("BREAK: " + this.FormatUnityLogString("Breakpoint"));
            this.AddEntry(entry, false);
        }
        public void LogAction(NDLogType logType, string text, bool sendToUnityLog = false)
        {
//            if (SkillExecutionStack.ExecutingAction != null)
//            {
//                NDLogEntry entry = new NDLogEntry
//                    {
//                        Log = this,
//                        LogType = logType,
//                        Node = SkillExecutionStack.ExecutingState,
//                        Action = SkillExecutionStack.ExecutingAction,
//                        Text = SkillUtility.StripNamespace(SkillExecutionStack.ExecutingAction.ToString()) + " : " + text
//                    };
//                this.AddEntry(entry, sendToUnityLog);
//                return;
//            }
            switch (logType)
            {
                case NDLogType.Info:
                    Debug.Log(text);
                    return;
                case NDLogType.Warning:
                    Debug.LogWarning(text);
                    return;
                case NDLogType.Error:
                    Debug.LogError(text);
                    return;
                default:
                    Debug.Log(text);
                    return;
            }
        }
        public void Log(NDLogType logType, string text)
        {
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = logType,
//                    Node = SkillExecutionStack.ExecutingState,
                    Text = text
                };
            this.AddEntry(entry, false);
        }
        public void LogStart(NDNode startNode)
        {
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.Start,
                    Node = startNode,
                    Text = "START"
                };
            this.AddEntry(entry, false);
        }
        public void LogStop()
        {
            NDLogEntry entry = new NDLogEntry
                {
                    Log = this,
                    LogType = NDLogType.Stop,
                    Text = "STOP"
                };
            this.AddEntry(entry, false);
        }
        public void Log(string text)
        {
            this.Log(NDLogType.Info, text);
        }
        public void LogWarning(string text)
        {
            this.Log(NDLogType.Warning, text);
        }
        public void LogError(string text)
        {
            this.Log(NDLogType.Error, text);
        }
        private string FormatUnityLogString(string text)
        {
//            string text2 = Skill.GetFullFsmLabel(this.Chart);
//            if (SkillExecutionStack.ExecutingState != null)
//            {
//                text2 = text2 + " : " + SkillExecutionStack.ExecutingStateName;
//            }
//            if (SkillExecutionStack.ExecutingAction != null)
//            {
//                text2 += SkillExecutionStack.ExecutingAction.Name;
//            }
//            return text2 + " : " + text;
            return text;
        }
        public void Clear()
        {
            if (this.entries != null)
            {
                this.entries.Clear();
            }
        }
        public void OnDestroy()
        {
            NDLog.Logs.Remove(this);
            this.Clear();
            this.entries = null;
            this.Chart = null;
        }
    }
}
