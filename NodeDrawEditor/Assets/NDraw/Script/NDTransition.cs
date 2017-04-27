using System;
using UnityEngine;
namespace ihaiu.NDraws
{
	[Serializable]
	public class NDTransition : IEquatable<NDTransition>
	{
		public enum CustomLinkStyle : byte
		{
			Default,
			Bezier,
			Circuit
		}
		public enum CustomLinkConstraint : byte
		{
			None,
			LockLeft,
			LockRight
		}

		[SerializeField]
        private NDEvent nodeEvent;
        [SerializeField]
        private NDNode fromNode;
        [SerializeField]
        private NDNode toNode;


		[SerializeField]
		private NDTransition.CustomLinkStyle linkStyle;
		[SerializeField]
		private NDTransition.CustomLinkConstraint linkConstraint;
		[SerializeField]
		private byte colorIndex;

		public NDEvent NodeEvent
		{
			get
			{
				return this.nodeEvent;
			}
			set
			{
				this.nodeEvent = value;
			}
		}

        public NDNode FromNode
        {
            get
            {
                return fromNode;
            }

            set
            {
                fromNode = value;
            }
        }

        public NDNode ToNode
        {
            get
            {
                return toNode;
            }

            set
            {
                toNode = value;
            }
        }
	
		public NDTransition.CustomLinkStyle LinkStyle
		{
			get
			{
				return this.linkStyle;
			}
			set
			{
				this.linkStyle = value;
			}
		}
		public NDTransition.CustomLinkConstraint LinkConstraint
		{
			get
			{
				return this.linkConstraint;
			}
			set
			{
				this.linkConstraint = value;
			}
		}
		public int ColorIndex
		{
			get
			{
				return (int)this.colorIndex;
			}
			set
			{
				this.colorIndex = (byte)Mathf.Clamp(value, 0, NDPrefs.Colors.Length - 1);
			}
		}
		public string EventName
		{
			get
			{
				if (!NDEvent.IsNullOrEmpty(this.nodeEvent))
				{
					return this.nodeEvent.Name;
				}
				return string.Empty;
			}
		}
		public NDTransition()
		{
		}

        public NDTransition(NDEvent nodeEvent, NDNode fromNode, NDNode toNode)
        {
            this.nodeEvent      = nodeEvent;
            this.fromNode       = fromNode;
            this.toNode         = toNode;
        }

		public NDTransition(NDTransition source)
		{
			this.nodeEvent = source.NodeEvent;
            this.fromNode = source.fromNode;
            this.toNode = source.toNode;
			this.linkStyle = source.linkStyle;
			this.linkConstraint = source.linkConstraint;
			this.colorIndex = source.colorIndex;
		}
		public bool Equals(NDTransition other)
		{
            return !object.ReferenceEquals(other, null) && (object.ReferenceEquals(this, other) || (!(other.fromNode != this.fromNode) && !(other.toNode != this.toNode) && other.EventName == this.EventName));
		}
	}
}
