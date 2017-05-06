using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace ihaiu.NDraws
{
    public class NDPaths
    {
        public static string ProjectPath
        {
            get;
            private set;
        }
        public static string RuntimePath
        {
            get;
            private set;
        }
        public static string EditorPath
        {
            get;
            private set;
        }
        public static string EditorResourcesPath
        {
            get;
            private set;
        }
        public static string WatermarksPath
        {
            get;
            private set;
        }
        public static string ResourcesPath
        {
            get;
            private set;
        }
        public static string TemplatesPath
        {
            get;
            private set;
        }
        public static string RuntimeFullPath
        {
            get;
            private set;
        }
        public static string EditorFullPath
        {
            get;
            private set;
        }
        public static string WatermarksFullPath
        {
            get;
            private set;
        }
        public static string ResourcesFullPath
        {
            get;
            private set;
        }
        public static string TemplatesFullPath
        {
            get;
            private set;
        }
        static NDPaths()
        {
            NDPaths.LoadPaths();
            NDPaths.ValidatePaths();
        }
        private static void LoadPaths()
        {
            NDPaths.RuntimePath = NDPaths.FixPath(EditorPrefs.GetString("PlayMakerPaths.RuntimePath", "Assets/PlayMaker/"));
            NDPaths.EditorPath = NDPaths.FixPath(EditorPrefs.GetString("PlayMakerPaths.EditorPath", "Assets/PlayMaker/Editor/"));
            NDPaths.EditorResourcesPath = NDPaths.FixPath(Path.Combine(NDPaths.EditorPath, "Resources"));
            NDPaths.WatermarksPath = NDPaths.FixPath(Path.Combine(NDPaths.EditorPath, "Watermarks"));
            string text = NDPaths.EditorPath.Substring(0, NDPaths.EditorPath.Length - 7);
            NDPaths.ResourcesPath = NDPaths.FixPath(Path.Combine(text, "Resources"));
            NDPaths.TemplatesPath = NDPaths.FixPath(Path.Combine(text, "Templates"));
            NDPaths.ProjectPath = Path.Combine(Application.dataPath, "..\\");
            NDPaths.ProjectPath = NDPaths.FixPath(Path.GetFullPath(NDPaths.ProjectPath));
            NDPaths.RuntimeFullPath = NDPaths.FixPath(Path.GetFullPath(Path.Combine(NDPaths.ProjectPath, NDPaths.RuntimePath)));
            NDPaths.EditorFullPath = NDPaths.FixPath(Path.GetFullPath(Path.Combine(NDPaths.ProjectPath, NDPaths.EditorPath)));
            NDPaths.WatermarksFullPath = NDPaths.FixPath(Path.GetFullPath(Path.Combine(NDPaths.ProjectPath, NDPaths.WatermarksPath)));
            NDPaths.TemplatesFullPath = NDPaths.FixPath(Path.GetFullPath(Path.Combine(NDPaths.ProjectPath, NDPaths.TemplatesPath)));
            NDPaths.ResourcesFullPath = NDPaths.FixPath(Path.GetFullPath(Path.Combine(NDPaths.ProjectPath, NDPaths.ResourcesPath)));
        }
        private static void SavePaths()
        {
            EditorPrefs.SetString("PlayMakerPaths.RuntimePath", NDPaths.RuntimePath);
            EditorPrefs.SetString("PlayMakerPaths.EditorPath", NDPaths.EditorPath);
        }
        private static string FixPath(string path)
        {
            return path.Replace("\\", "/");
        }
        private static void ValidatePaths()
        {
            if (EditorApp.IsSourceCodeVersion)
            {
                NDPaths.ResetPaths();
                return;
            }
            if (!File.Exists(Path.Combine(NDPaths.RuntimeFullPath, "PlayMaker.dll")))
            {
                NDPaths.RuntimeFullPath = NDPaths.FindPath("PlayMaker.dll");
                NDPaths.RuntimePath = new Uri(Application.dataPath).MakeRelativeUri(new Uri(NDPaths.RuntimeFullPath)).ToString();
            }
            if (!File.Exists(Path.Combine(NDPaths.EditorFullPath, "PlayMakerEditor.dll")))
            {
                NDPaths.EditorFullPath = NDPaths.FindPath("PlayMakerEditor.dll");
                NDPaths.EditorPath = new Uri(Application.dataPath).MakeRelativeUri(new Uri(NDPaths.EditorFullPath)).ToString();
            }
            NDPaths.SavePaths();
        }
        public static string GetTemplatesDirectory()
        {
            if (!Directory.Exists(NDPaths.TemplatesFullPath))
            {
                return Application.dataPath;
            }
            return NDPaths.TemplatesFullPath;
        }
        private static string FindPath(string filename)
        {
            string text = string.Empty;
            IEnumerable<FileInfo> files = new DirectoryInfo(Application.dataPath).GetFiles("*.*", 1);
            IEnumerable<FileInfo> enumerable = Enumerable.OrderBy<FileInfo, string>(Enumerable.Where<FileInfo>(files, (FileInfo file) => file.get_Name() == filename), (FileInfo file) => file.get_Name());
            if (Enumerable.Any<FileInfo>(enumerable))
            {
                text = Path.GetDirectoryName(Enumerable.First<FileInfo>(enumerable).FullName);
            }
            if (string.IsNullOrEmpty(text))
            {
                Debug.LogError("PlayMakerPaths: Could not find: " + filename);
            }
            return text;
        }
        private static void ResetPaths()
        {
            NDPaths.RuntimePath = "Assets/NodeDraw/";
            NDPaths.EditorPath = "Assets/NodeDraw/Editor/";
            NDPaths.EditorResourcesPath = "Assets/NodeDraw/Editor/Resources/";
        }
        private static void DebugPaths()
        {
            Debug.Log(string.Concat(new string[]
                {
                    "PlayMakerPaths:\nRuntimePath: ",
                    NDPaths.RuntimePath,
                    "\nRuntimeFullPath: ",
                    NDPaths.RuntimeFullPath,
                    "\nEditorPath: ",
                    NDPaths.EditorPath,
                    "\nEditorFullPath: ",
                    NDPaths.EditorFullPath,
                    "\nEditorResourcesPath: ",
                    NDPaths.EditorResourcesPath,
                    "\nWatermarksPath: ",
                    NDPaths.WatermarksPath,
                    "\nWatermarksFullPath: ",
                    NDPaths.WatermarksFullPath,
                    "\nResourcesPath: ",
                    NDPaths.ResourcesPath,
                    "\nTemplatesPath: ",
                    NDPaths.TemplatesPath,
                    "\nResourcesFullPath: ",
                    NDPaths.ResourcesFullPath,
                    "\nTemplatesFullPath: ",
                    NDPaths.GetTemplatesDirectory()
                }));
        }
    }
}
