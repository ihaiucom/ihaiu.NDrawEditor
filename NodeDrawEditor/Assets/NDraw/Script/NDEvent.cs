using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
namespace ihaiu.NDraws
{
	[Serializable]
	public class NDEvent : IComparable, INameable
    {
        [SerializeField]
        private static List<string> _globalEvents = new List<string>();
		private static List<NDEvent> eventList;
		private static readonly object syncObj = new object();
		[SerializeField]
		private string name;
		[SerializeField]
		private bool isSystemEvent;
		[SerializeField]
		private bool isGlobal;
		
		public static List<string> globalEvents
		{
			get
			{
                return _globalEvents;
			}
		}
		public static List<NDEvent> EventList
		{
			get
			{
				if (NDEvent.eventList == null)
				{
					NDEvent.Initialize();
				}
				return NDEvent.eventList;
			}
			private set
			{
				NDEvent.eventList = value;
			}
		}
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
		public bool IsSystemEvent
		{
			get
			{
				return this.isSystemEvent;
			}
			set
			{
				this.isSystemEvent = value;
			}
		}
		public bool IsMouseEvent
		{
			get
			{
				return this == NDEvent.MouseDown || this == NDEvent.MouseDrag || this == NDEvent.MouseEnter || this == NDEvent.MouseExit || this == NDEvent.MouseOver || this == NDEvent.MouseUp || this == NDEvent.MouseUpAsButton;
			}
		}
		public bool IsApplicationEvent
		{
			get
			{
				return this == NDEvent.ApplicationFocus || this == NDEvent.ApplicationPause;
			}
		}
		public bool IsGlobal
		{
			get
			{
				return this.isGlobal;
			}
			set
			{
				if (value)
				{
					if (!NDEvent.globalEvents.Contains(this.name))
					{
						NDEvent.globalEvents.Add(this.name);
					}
				}
				else
				{
					NDEvent.globalEvents.RemoveAll((string m) => m == this.name);
				}
				this.isGlobal = value;
				NDEvent.SanityCheckEventList();
			}
		}
		public string Path
		{
			get;
			set;
		}
		public static NDEvent BecameInvisible
		{
			get;
			private set;
		}
		public static NDEvent BecameVisible
		{
			get;
			private set;
		}
		public static NDEvent CollisionEnter
		{
			get;
			private set;
		}
		public static NDEvent CollisionExit
		{
			get;
			private set;
		}
		public static NDEvent CollisionStay
		{
			get;
			private set;
		}
		public static NDEvent CollisionEnter2D
		{
			get;
			private set;
		}
		public static NDEvent CollisionExit2D
		{
			get;
			private set;
		}
		public static NDEvent CollisionStay2D
		{
			get;
			private set;
		}
		public static NDEvent ControllerColliderHit
		{
			get;
			private set;
		}
		public static NDEvent Finished
		{
			get;
			private set;
		}
		public static NDEvent LevelLoaded
		{
			get;
			private set;
		}
		public static NDEvent MouseDown
		{
			get;
			private set;
		}
		public static NDEvent MouseDrag
		{
			get;
			private set;
		}
		public static NDEvent MouseEnter
		{
			get;
			private set;
		}
		public static NDEvent MouseExit
		{
			get;
			private set;
		}
		public static NDEvent MouseOver
		{
			get;
			private set;
		}
		public static NDEvent MouseUp
		{
			get;
			private set;
		}
		public static NDEvent MouseUpAsButton
		{
			get;
			private set;
		}
		public static NDEvent TriggerEnter
		{
			get;
			private set;
		}
		public static NDEvent TriggerExit
		{
			get;
			private set;
		}
		public static NDEvent TriggerStay
		{
			get;
			private set;
		}
		public static NDEvent TriggerEnter2D
		{
			get;
			private set;
		}
		public static NDEvent TriggerExit2D
		{
			get;
			private set;
		}
		public static NDEvent TriggerStay2D
		{
			get;
			private set;
		}
		public static NDEvent ApplicationFocus
		{
			get;
			private set;
		}
		public static NDEvent ApplicationPause
		{
			get;
			private set;
		}
		public static NDEvent ApplicationQuit
		{
			get;
			private set;
		}
		public static NDEvent ParticleCollision
		{
			get;
			private set;
		}
		public static NDEvent JointBreak
		{
			get;
			private set;
		}
		public static NDEvent JointBreak2D
		{
			get;
			private set;
		}
		public static NDEvent PlayerConnected
		{
			get;
			private set;
		}
		public static NDEvent ServerInitialized
		{
			get;
			private set;
		}
		public static NDEvent ConnectedToServer
		{
			get;
			private set;
		}
		public static NDEvent PlayerDisconnected
		{
			get;
			private set;
		}
		public static NDEvent DisconnectedFromServer
		{
			get;
			private set;
		}
		public static NDEvent FailedToConnect
		{
			get;
			private set;
		}
		public static NDEvent FailedToConnectToMasterServer
		{
			get;
			private set;
		}
		public static NDEvent MasterServerEvent
		{
			get;
			private set;
		}
		public static NDEvent NetworkInstantiate
		{
			get;
			private set;
		}
		private static void Initialize()
		{
			NDEvent.eventList = new List<NDEvent>();
			NDEvent.AddSystemEvents();
			NDEvent.AddGlobalEvents();
		}
		public static bool IsNullOrEmpty(NDEvent fsmEvent)
		{
			return fsmEvent == null || string.IsNullOrEmpty(fsmEvent.name);
		}
		public NDEvent(string name)
		{
			object obj;
			Monitor.Enter(obj = NDEvent.syncObj);
			try
			{
				this.name = name;
				if (!NDEvent.EventListContainsEvent(NDEvent.EventList, name))
				{
					NDEvent.EventList.Add(this);
				}
			}
			finally
			{
				Monitor.Exit(obj);
			}
		}
		public NDEvent(NDEvent source)
		{
			object obj;
			Monitor.Enter(obj = NDEvent.syncObj);
			try
			{
				this.name = source.name;
				this.isSystemEvent = source.isSystemEvent;
				this.isGlobal = source.isGlobal;
				NDEvent fsmEvent = NDEvent.EventList.Find((NDEvent x) => x.name == this.name);
				if (fsmEvent == null)
				{
					NDEvent.EventList.Add(this);
				}
				else
				{
					fsmEvent.isGlobal |= this.isGlobal;
				}
			}
			finally
			{
				Monitor.Exit(obj);
			}
		}
		int IComparable.CompareTo(object obj)
		{
			NDEvent fsmEvent = (NDEvent)obj;
			if (this.isSystemEvent && !fsmEvent.isSystemEvent)
			{
				return -1;
			}
			if (!this.isSystemEvent && fsmEvent.isSystemEvent)
			{
				return 1;
			}
			return string.CompareOrdinal(this.name, fsmEvent.name);
		}
		public static bool EventListContainsEvent(List<NDEvent> fsmEventList, string fsmEventName)
		{
			object obj;
			Monitor.Enter(obj = NDEvent.syncObj);
			bool result;
			try
			{
				if (fsmEventList == null || string.IsNullOrEmpty(fsmEventName))
				{
					result = false;
				}
				else
				{
                    for (int i = 0; i < fsmEventList.Count; i++)
					{
						if (fsmEventList[i].Name == fsmEventName)
						{
							result = true;
							return result;
						}
					}
					result = false;
				}
			}
			finally
			{
				Monitor.Exit(obj);
			}
			return result;
		}
		public static void RemoveEventFromEventList(NDEvent fsmEvent)
		{
			if (fsmEvent.isSystemEvent)
			{
				Debug.LogError("RemoveEventFromEventList: Trying to delete System Event: " + fsmEvent.Name);
			}
			NDEvent.EventList.Remove(fsmEvent);
		}
		public static NDEvent FindEvent(string eventName)
		{
			object obj;
			Monitor.Enter(obj = NDEvent.syncObj);
			NDEvent result;
			try
			{
                for (int i = 0; i < NDEvent.EventList.Count; i++)
				{
					NDEvent fsmEvent = NDEvent.EventList[i];
					if (fsmEvent.name == eventName)
					{
						result = fsmEvent;
						return result;
					}
				}
				result = null;
			}
			finally
			{
				Monitor.Exit(obj);
			}
			return result;
		}
		public static bool IsEventGlobal(string eventName)
		{
			return NDEvent.globalEvents.Contains(eventName);
		}
		public static bool EventListContains(string eventName)
		{
			return NDEvent.FindEvent(eventName) != null;
		}
		public static NDEvent GetFsmEvent(string eventName)
		{
			object obj;
			Monitor.Enter(obj = NDEvent.syncObj);
			NDEvent result;
			try
			{
                for (int i = 0; i < NDEvent.EventList.Count; i++)
				{
					NDEvent fsmEvent = NDEvent.EventList[i];
					if (string.CompareOrdinal(fsmEvent.Name, eventName) == 0)
					{
                        result = fsmEvent;
						return result;
					}
				}
				NDEvent fsmEvent2 = new NDEvent(eventName);
                result =fsmEvent2;
			}
			finally
			{
				Monitor.Exit(obj);
			}
			return result;
		}
		public static NDEvent GetFsmEvent(NDEvent fsmEvent)
		{
			if (fsmEvent == null)
			{
				return null;
			}
			object obj;
			Monitor.Enter(obj = NDEvent.syncObj);
			NDEvent result;
			try
			{
                for (int i = 0; i < NDEvent.EventList.Count; i++)
				{
					NDEvent fsmEvent2 = NDEvent.EventList[i];
					if (string.CompareOrdinal(fsmEvent2.Name, fsmEvent.Name) == 0)
					{
                        result = fsmEvent2;
						return result;
					}
				}
				if (fsmEvent.isSystemEvent)
				{
					Debug.LogError("Missing System Event: " + fsmEvent.Name);
				}
				result = NDEvent.AddFsmEvent(fsmEvent);
			}
			finally
			{
				Monitor.Exit(obj);
			}
			return result;
		}
		public static NDEvent AddFsmEvent(NDEvent fsmEvent)
		{
			NDEvent.EventList.Add(fsmEvent);
			return fsmEvent;
		}
		private static void AddSystemEvents()
		{
			NDEvent.Finished = NDEvent.AddSystemEvent("FINISHED", "System Events");
			NDEvent.BecameInvisible = NDEvent.AddSystemEvent("BECAME INVISIBLE", "System Events");
			NDEvent.BecameVisible = NDEvent.AddSystemEvent("BECAME VISIBLE", "System Events");
			NDEvent.LevelLoaded = NDEvent.AddSystemEvent("LEVEL LOADED", "System Events");
			NDEvent.MouseDown = NDEvent.AddSystemEvent("MOUSE DOWN", "System Events");
			NDEvent.MouseDrag = NDEvent.AddSystemEvent("MOUSE DRAG", "System Events");
			NDEvent.MouseEnter = NDEvent.AddSystemEvent("MOUSE ENTER", "System Events");
			NDEvent.MouseExit = NDEvent.AddSystemEvent("MOUSE EXIT", "System Events");
			NDEvent.MouseOver = NDEvent.AddSystemEvent("MOUSE OVER", "System Events");
			NDEvent.MouseUp = NDEvent.AddSystemEvent("MOUSE UP", "System Events");
			NDEvent.MouseUpAsButton = NDEvent.AddSystemEvent("MOUSE UP AS BUTTON", "System Events");
			NDEvent.CollisionEnter = NDEvent.AddSystemEvent("COLLISION ENTER", "System Events");
			NDEvent.CollisionExit = NDEvent.AddSystemEvent("COLLISION EXIT", "System Events");
			NDEvent.CollisionStay = NDEvent.AddSystemEvent("COLLISION STAY", "System Events");
			NDEvent.ControllerColliderHit = NDEvent.AddSystemEvent("CONTROLLER COLLIDER HIT", "System Events");
			NDEvent.TriggerEnter = NDEvent.AddSystemEvent("TRIGGER ENTER", "System Events");
			NDEvent.TriggerExit = NDEvent.AddSystemEvent("TRIGGER EXIT", "System Events");
			NDEvent.TriggerStay = NDEvent.AddSystemEvent("TRIGGER STAY", "System Events");
			NDEvent.CollisionEnter2D = NDEvent.AddSystemEvent("COLLISION ENTER 2D", "System Events");
			NDEvent.CollisionExit2D = NDEvent.AddSystemEvent("COLLISION EXIT 2D", "System Events");
			NDEvent.CollisionStay2D = NDEvent.AddSystemEvent("COLLISION STAY 2D", "System Events");
			NDEvent.TriggerEnter2D = NDEvent.AddSystemEvent("TRIGGER ENTER 2D", "System Events");
			NDEvent.TriggerExit2D = NDEvent.AddSystemEvent("TRIGGER EXIT 2D", "System Events");
			NDEvent.TriggerStay2D = NDEvent.AddSystemEvent("TRIGGER STAY 2D", "System Events");
			NDEvent.PlayerConnected = NDEvent.AddSystemEvent("PLAYER CONNECTED", "Network Events");
			NDEvent.ServerInitialized = NDEvent.AddSystemEvent("SERVER INITIALIZED", "Network Events");
			NDEvent.ConnectedToServer = NDEvent.AddSystemEvent("CONNECTED TO SERVER", "Network Events");
			NDEvent.PlayerDisconnected = NDEvent.AddSystemEvent("PLAYER DISCONNECTED", "Network Events");
			NDEvent.DisconnectedFromServer = NDEvent.AddSystemEvent("DISCONNECTED FROM SERVER", "Network Events");
			NDEvent.FailedToConnect = NDEvent.AddSystemEvent("FAILED TO CONNECT", "Network Events");
			NDEvent.FailedToConnectToMasterServer = NDEvent.AddSystemEvent("FAILED TO CONNECT TO MASTER SERVER", "Network Events");
			NDEvent.MasterServerEvent = NDEvent.AddSystemEvent("MASTER SERVER EVENT", "Network Events");
			NDEvent.NetworkInstantiate = NDEvent.AddSystemEvent("NETWORK INSTANTIATE", "Network Events");
			NDEvent.ApplicationFocus = NDEvent.AddSystemEvent("APPLICATION FOCUS", "System Events");
			NDEvent.ApplicationPause = NDEvent.AddSystemEvent("APPLICATION PAUSE", "System Events");
			NDEvent.ApplicationQuit = NDEvent.AddSystemEvent("APPLICATION QUIT", "System Events");
			NDEvent.ParticleCollision = NDEvent.AddSystemEvent("PARTICLE COLLISION", "System Events");
			NDEvent.JointBreak = NDEvent.AddSystemEvent("JOINT BREAK", "System Events");
			NDEvent.JointBreak2D = NDEvent.AddSystemEvent("JOINT BREAK 2D", "System Events");
		}
		private static NDEvent AddSystemEvent(string eventName, string path = "")
		{
			return new NDEvent(eventName)
			{
				IsSystemEvent = true,
				Path = (path == "") ? "" : (path + "/")
			};
		}
		private static void AddGlobalEvents()
		{
            for (int i = 0; i < NDEvent.globalEvents.Count; i++)
			{
				string text = NDEvent.globalEvents[i];
				NDEvent fsmEvent = new NDEvent(text);
				fsmEvent.isGlobal = true;
			}
		}
		public static void SanityCheckEventList()
		{
			using (List<NDEvent>.Enumerator enumerator = NDEvent.EventList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
                    NDEvent current = enumerator.Current;
					if (NDEvent.IsEventGlobal(current.name))
					{
						current.isGlobal = true;
					}
					if (current.isGlobal && !NDEvent.globalEvents.Contains(current.name))
					{
						NDEvent.globalEvents.Add(current.name);
					}
				}
			}
			List<NDEvent> list = new List<NDEvent>();
			using (List<NDEvent>.Enumerator enumerator2 = NDEvent.EventList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
                    NDEvent current2 = enumerator2.Current;
					if (!NDEvent.EventListContainsEvent(list, current2.Name))
					{
						list.Add(current2);
					}
				}
			}
			NDEvent.EventList = list;
		}
	}
}
