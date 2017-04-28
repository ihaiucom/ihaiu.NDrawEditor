using System;
using UnityEngine;
namespace ihaiu.NDraws
{
    public class NDLogEntry
    {
        private string textWithTimecode;
        public NDLog Log
        {
            get;
            set;
        }
        public NDLogType LogType
        {
            get;
            set;
        }
        public NDChart Fsm
        {
            get
            {
                return this.Log.Chart;
            }
        }
        public NDNode Node
        {
            get;
            set;
        }
        public NDNode SentByNode
        {
            get;
            set;
        }
        public SkillStateAction Action
        {
            get;
            set;
        }
        public NDEvent Event
        {
            get;
            set;
        }
        public NDTransition Transition
        {
            get;
            set;
        }
        public float Time
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
        public string Text2
        {
            get;
            set;
        }
        public int FrameCount
        {
            get;
            set;
        }
       
        public GameObject GameObject
        {
            get;
            set;
        }
        public string GameObjectName
        {
            get;
            set;
        }
        public Texture GameObjectIcon
        {
            get;
            set;
        }
        public string TextWithTimecode
        {
            get
            {
                string arg_2E_0;
                if ((arg_2E_0 = this.textWithTimecode) == null)
                {
                    arg_2E_0 = (this.textWithTimecode = NDTime.FormatTime(this.Time) + " " + this.Text);
                }
                return arg_2E_0;
            }
        }
        public int GetIndex()
        {
            for (int i = 0; i < this.Log.Entries.Count; i++)
            {
                if (this.Log.Entries[i] == this)
                {
                    return i;
                }
            }
            return -1;
        }
        public void DebugLog()
        {
            Debug.Log("Sent By: " + NDlUtility.GetPath(this.SentByNode) + " : " + ((this.Action != null) ? this.Action.Name : "None (Action)"));
        }
    }
}
