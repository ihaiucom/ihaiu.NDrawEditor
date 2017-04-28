using System;
using UnityEngine;
namespace ihaiu.NDraws
{
    public static class NDTime
    {
        private static bool firstUpdateHasHappened;
        private static float totalEditorPlayerPausedTime;
        private static float realtimeLastUpdate;
        private static int frameCountLastUpdate;
        public static float RealtimeSinceStartup
        {
            get
            {
                if (NDTime.firstUpdateHasHappened)
                {
                    if (Time.realtimeSinceStartup < NDTime.totalEditorPlayerPausedTime)
                    {
                        NDTime.totalEditorPlayerPausedTime = 0f;
                    }
                    return Time.realtimeSinceStartup - NDTime.totalEditorPlayerPausedTime;
                }
                NDTime.totalEditorPlayerPausedTime = Time.realtimeSinceStartup;
                return 0f;
            }
        }
        public static void RealtimeBugFix()
        {
            NDTime.firstUpdateHasHappened = true;
        }
        public static void Update()
        {
            float realtimeSinceStartup = Time.realtimeSinceStartup;
            if (Time.frameCount == NDTime.frameCountLastUpdate)
            {
                NDTime.totalEditorPlayerPausedTime += realtimeSinceStartup - NDTime.realtimeLastUpdate;
            }
            NDTime.frameCountLastUpdate = Time.frameCount;
            NDTime.realtimeLastUpdate = Time.realtimeSinceStartup;
        }
        public static string FormatTime(float time)
        {
            DateTime dateTime = new DateTime((long)(time * 1E+07f));
            return dateTime.ToString("mm:ss:ff");
        }
        public static void DebugLog()
        {
            Debug.Log("LastFrameCount: " + NDTime.frameCountLastUpdate);
            Debug.Log("PausedTime: " + NDTime.totalEditorPlayerPausedTime);
            Debug.Log("Realtime: " + NDTime.RealtimeSinceStartup);
        }
    }
}
