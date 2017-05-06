using UnityEngine;
using System.Collections;
namespace ihaiu.NDraws
{
    public class NDlUtility 
    {
        public static string StripNamespace(string name)
        {
            if (name == null)
            {
                return "[missing name]";
            }
            return name.Substring(name.LastIndexOf(".", 4) + 1);
        }
        public static string GetPath(NDNode node)
        {
            if (node == null)
            {
                return "[missing state]";
            }
            return ((node.Chart != null) ? node.Chart.Name : "[missing FSM]") + ": " + node.Name + ": ";
        }
        public static string GetPath(NDNode node, NDNodeAction action)
        {
            if (action == null)
            {
                return GetPath(node) + "[missing action] ";
            }
            return GetPath(node) + action.GetType().Name + ": ";
        }
        public static string GetPath(NDNode node, NDNodeAction action, string parameter)
        {
            return GetPath(node, action) + parameter + ": ";
        }
        public static string GetFullFsmLabel(NDChart chart)
        {
            if (chart == null)
            {
                return "None (Chart)";
            }
            if (chart.UsedInTemplate != null)
            {
                return "Template: " + chart.UsedInTemplate.name;
            }
           
            return  GetChartLabel(chart);
        }
       
        public static string GetChartLabel(NDChart chart)
        {
            if (chart != null)
            {
                return chart.Name;
            }
            return "None (Fsm)";
        }
    }

}