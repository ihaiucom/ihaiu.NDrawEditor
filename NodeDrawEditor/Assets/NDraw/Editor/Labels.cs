using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEditor;
using UnityEngine;
namespace ihaiu.NDraws
{
    [Localizable(false)]
    public static class Labels
    {
        private static readonly Dictionary<string, string>      niceVariableNames = new Dictionary<string, string>();
        private static readonly Dictionary<Type, string>        shortTypeNames = new Dictionary<Type, string>();
        private static readonly Dictionary<Type, string>        actionNames = new Dictionary<Type, string>();
        private static readonly Dictionary<Type, string>        typeTooltips = new Dictionary<Type, string>();
        private static readonly Dictionary<NDChart, string>         chartName = new Dictionary<NDChart, string>();
        private static readonly Dictionary<NDChart, string>         chartFullName = new Dictionary<NDChart, string>();
        public static void Update(NDChart chart)
        {
            if (chart == null)
            {
                return;
            }
            Labels.chartName.Remove(chart);
            Labels.chartFullName.Remove(chart);
        }
        public static string NicifyVariableName(string name)
        {
            string text;
            if (Labels.niceVariableNames.TryGetValue(name, out text))
            {
                return text;
            }
            text = ObjectNames.NicifyVariableName(name);
            text = text.Replace("Vector 2", "Vector2 ");
            text = text.Replace("Vector 3", "Vector3 ");
            text = text.Replace("GUI", "GUI ");
            text = text.Replace("GUI Layout", "GUILayout");
            text = text.Replace("ITween", "iTween");
            text = text.Replace("IPhone", "iPhone");
            text = text.Replace("i Phone", "iPhone");
            text = text.Replace("Player Prefs", "PlayerPrefs");
            text = text.Replace("Network View ", "NetworkView ");
            text = text.Replace("Master Server ", "MasterServer ");
            text = text.Replace("Rpc ", "RPC ");
            text = text.Replace("Collision 2d", "Collision2D");
            text = text.Replace("Trigger 2d", "Trigger2D");
            Labels.niceVariableNames.Add(name, text);
            return text;
        }
        public static string StripNamespace(string name)
        {
            return name.Substring(name.LastIndexOf(".", 4) + 1);
        }
        public static string StripUnityEngineNamespace(string name)
        {
            if (name.IndexOf("UnityEngine.", 4) != 0)
            {
                return name;
            }
            return name.Replace("UnityEngine.", "");
        }
        public static string FormatTime(float time)
        {
            DateTime dateTime = new DateTime(Convert.ToInt64(Mathf.Max(time, 0f) * 1E+07f), 0);
            return dateTime.ToString("mm:ss:ff");
        }
        public static string GenerateUniqueLabelWithNumber(List<string> labels, string label)
        {
            int num = 2;
            string text = label;
            while (labels.Contains(label))
            {
                label = string.Concat(new object[]
                    {
                        text,
                        " (",
                        num++,
                        ")"
                    });
            }
            return label;
        }
        public static string GenerateUniqueLabel(List<string> labels, string label)
        {
            while (labels.Contains(label))
            {
                label += " ";
            }
            return label;
        }
        public static string NicifyParameterName(string name)
        {
            return Labels.NicifyVariableName(Labels.StripNamespace(name));
        }
        public static string GetNodeLabel(string stateName)
        {
            if (!string.IsNullOrEmpty(stateName))
            {
                return stateName;
            }
            return "None (Node)";
        }
        public static GUIContent GetEventLabel(NDTransition transition)
        {
            NDEditorContent.EventLabel.text         = "...";
            NDEditorContent.EventLabel.tooltip      = "";
            if (!NDEvent.IsNullOrEmpty(transition.NodeEvent))
            {
                NDEditorContent.EventLabel.text = transition.NodeEvent.Name;
            }
            return NDEditorContent.EventLabel;
        }
        public static string GetCurrentNodeLabel(NDChart chart)
        {
            if (EditorApplication.isPlaying)
            {
                if (chart.ActiveNode != null)
                {
                    return chart.ActiveNode.Name;
                }
                return "No Active Node";
            }
            else
            {
                NDNode node = chart.StartNode;
                if (node != null)
                {
                    return node.Name;
                }
                return "No Start Node";
            }
        }
        public static string GetChartLabel(NDChart chart)
        {
            if (chart == null)
            {
                return "None (Fsm)";
            }
            string text;
            if (Labels.chartName.TryGetValue(chart, out text))
            {
                return text;
            }
            text = (chart.IsSubChart ? (chart.Host.Name + " : " + chart.Name) : chart.Name);
            int fsmNameIndex = Labels.GetChartNameIndex(chart);
            if (fsmNameIndex > 0)
            {
                object obj = text;
                text = string.Concat(new object[]
                    {
                        obj,
                        " (",
                        fsmNameIndex + 1,
                        ")"
                    });
            }
            Labels.chartName.Add(chart, text);
            return text;
        }
      
        public static string GetFullChartLabel(NDChart chart)
        {
            if (chart == null)
            {
                return "None (Chart)";
            }
           
            string text;
            if (Labels.chartFullName.TryGetValue(chart, out text))
            {
                return text;
            }
            if (chart.UsedInTemplate != null)
            {
                text = "Template: " + chart.UsedInTemplate.name;
            }
            else
            {
                text = Labels.GetChartLabel(chart);
            }
            Labels.chartFullName.Add(chart, text);
            return text;
        }
        public static string GetRuntimeFsmLabel(NDChart chart)
        {
            if (chart == null)
            {
                return "None (FSM)";
            }
           
            return chart.Name;
        }
        public static string GetFullChartLabelWithInstanceID(NDChart chart)
        {
            string text = string.Empty;
           
            return Labels.GetFullChartLabel(chart) + text;
        }
       
        public static GUIContent GetRuntimeFsmLabelToFit(NDChart chart, float width, GUIStyle style)
        {
            string runtimeFsmLabel = Labels.GetRuntimeFsmLabel(chart);
            float x = style.CalcSize(new GUIContent(runtimeFsmLabel)).x;
            if (x < width)
            {
                return new GUIContent(runtimeFsmLabel, runtimeFsmLabel);
            }
            return new GUIContent(chart.Name, runtimeFsmLabel);
        }
        public static string GetFullNodeLabel(NDNode state)
        {
            if (state == null)
            {
                return "None (State)";
            }
            return state.Name;
//            return Labels.GetFullChartLabel(state.get_Fsm()) + " : " + state.get_Name();
        }
       
        public static string GetShortTypeName(Type type)
        {
            if (type == null)
            {
                return "";
            }
            string text;
            if (Labels.shortTypeNames.TryGetValue(type, out text))
            {
                return text;
            }
            text = Labels.StripNamespace(type.FullName);
            Labels.shortTypeNames.Add(type, text);
            return text;
        }
        public static string GetActionLabel(Type actionType)
        {
            if (actionType == null)
            {
                return "";
            }
            string text;
            if (Labels.actionNames.TryGetValue(actionType, out text))
            {
                return text;
            }
            text = Labels.NicifyVariableName(Labels.StripNamespace(actionType.ToString()));
            Labels.actionNames.Add(actionType, text);
            return text;
        }

        public static string GetTypeTooltip(Type type)
        {
            if (type == null)
            {
                return "";
            }
            string text;
            if (Labels.typeTooltips.TryGetValue(type, out text))
            {
                return text;
            }
            text = "Type: ";
            if (type == typeof(NDEvent))
            {
                text += "NDEvent";
            }
                
            Labels.typeTooltips.Add(type, Labels.NicifyTypeTooltip(text));
            return text;
        }


        private static string NicifyTypeTooltip(string tooltip)
        {
            if (tooltip != null)
            {
                if (tooltip == "Single")
                {
                    return Strings.Label_Float;
                }
                if (tooltip == "FsmOwnerDefault")
                {
                    return Strings.Label_GameObject;
                }
            }
            return tooltip;
        }

        public static int GetChartIndex(NDChart chart)
        {
            if (chart == null)
            {
                return -1;
            }
            int num = 0;

           
            return -1;
        }

        public static int GetChartNameIndex(NDChart chart)
        {
            if (chart == null)
            {
                return 0;
            }
            int num = 0;
            return 0;
        }
    }
}
