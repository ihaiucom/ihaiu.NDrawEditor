using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
namespace ihaiu.NDraws
{
	public static class EditorCommands
	{
        [Localizable(false)]
        public static void SearchWikiHelp(NDNodeAction action)
        {
            string text = Labels.NicifyVariableName(Labels.StripNamespace(action.ToString()));
            Application.OpenURL("http://blog.ihaiu.com?ixWiki=1&pg=pgSearchWiki&qWiki=title:" + text);
        }
        [Localizable(false)]
        public static void SearchWikiHelp(string topic)
        {
            Application.OpenURL("http://blog.ihaiu.com?ixWiki=1&pg=pgSearchWiki&qWiki=" + topic);
        }
        public static void OpenWikiPage(NDNodeAction action)
        {
            HelpUrlAttribute attribute = CustomAttributeHelpers.GetAttribute<HelpUrlAttribute>(action.GetType());
            if (attribute != null)
            {
                Application.OpenURL(attribute.Url);
                return;
            }
            string topic = Labels.StripNamespace(action.ToString());
            if (!EditorCommands.OpenWikiPage(topic))
            {
                EditorCommands.SearchWikiHelp(action);
            }
        }
	}
}
