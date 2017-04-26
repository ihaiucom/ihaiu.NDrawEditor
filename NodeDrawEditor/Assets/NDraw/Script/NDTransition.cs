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
		private NDEvent fsmEvent;
		[SerializeField]
		private string toState;
		[SerializeField]
		private NDTransition.CustomLinkStyle linkStyle;
		[SerializeField]
		private NDTransition.CustomLinkConstraint linkConstraint;
		[SerializeField]
		private byte colorIndex;
		public NDEvent FsmEvent
		{
			get
			{
				return this.fsmEvent;
			}
			set
			{
				this.fsmEvent = value;
			}
		}
		public string ToState
		{
			get
			{
				return this.toState;
			}
			set
			{
				this.toState = value;
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
				if (!NDEvent.IsNullOrEmpty(this.fsmEvent))
				{
					return this.fsmEvent.Name;
				}
				return string.Empty;
			}
		}
		public NDTransition()
		{
		}
		public NDTransition(NDTransition source)
		{
			this.fsmEvent = source.FsmEvent;
			this.toState = source.toState;
			this.linkStyle = source.linkStyle;
			this.linkConstraint = source.linkConstraint;
			this.colorIndex = source.colorIndex;
		}
		public bool Equals(NDTransition other)
		{
			return !object.ReferenceEquals(other, null) && (object.ReferenceEquals(this, other) || (!(other.toState != this.toState) && other.EventName == this.EventName));
		}
	}
}
