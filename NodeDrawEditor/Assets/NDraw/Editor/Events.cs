using System;
using System.Collections.Generic;
using UnityEngine;
namespace ihaiu.NDraws
{
    public static class Events
    {
      
        public static bool FsmStateRespondsToEvent(NDNode state, NDEvent fsmEvent)
        {
            if (NDEvent.IsNullOrEmpty(fsmEvent))
            {
                return false;
            }
//            SkillTransition[] globalTransitions = state.get_Fsm().get_GlobalTransitions();
//            for (int i = 0; i < globalTransitions.Length; i++)
//            {
//                SkillTransition fsmTransition = globalTransitions[i];
//                if (fsmTransition.get_EventName() == fsmEvent.get_Name())
//                {
//                    bool result = true;
//                    return result;
//                }
//            }
//            NDTransition[] transitions = state.Transitions;
//            for (int j = 0; j < transitions.Length; j++)
//            {
//                SkillTransition fsmTransition2 = transitions[j];
//                if (fsmTransition2.get_EventName() == fsmEvent.get_Name())
//                {
//                    bool result = true;
//                    return result;
//                }
//            }
            return false;
        }

        public static bool FsmRespondsToEvent(NDChart chart, NDEvent ndEvent)
        {
            return chart != null && !NDEvent.IsNullOrEmpty(ndEvent) && Events.FsmRespondsToEvent(chart, ndEvent.Name);
        }

        public static bool FsmRespondsToEvent(NDChart fsm, string fsmEventName)
        {
            if (fsm == null || string.IsNullOrEmpty(fsmEventName))
            {
                return false;
            }
//            NDTransition[] globalTransitions = fsm.GlobalTransitions;
//            for (int i = 0; i < globalTransitions.Length; i++)
//            {
//                NDTransition fsmTransition = globalTransitions[i];
//                if (fsmTransition.get_EventName() == fsmEventName)
//                {
//                    bool result = true;
//                    return result;
//                }
//            }

//            List<NDNode> nodes = fsm.Nodes;
//            for (int j = 0; j < nodes.Count; j++)
//            {
//                NDNode fsmState = nodes[j];
//                List<NDTransition> transitions = fsmState.Transitions;
//                for (int k = 0; k < transitions.Count; k++)
//                {
//                    NDTransition fsmTransition2 = transitions[k];
//                    if (fsmTransition2.EventName == fsmEventName)
//                    {
//                        bool result = true;
//                        return result;
//                    }
//                }
//            }
            return false;
        }
        public static List<NDEvent> GetGlobalEventList()
        {
            List<NDEvent> list = new List<NDEvent>();
            using (List<NDEvent>.Enumerator enumerator = NDEvent.EventList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDEvent current = enumerator.Current;
                    if (current.IsGlobal)
                    {
                        list.Add(current);
                    }
                }
            }
            return list;
        }
        public static List<NDEvent> GetGlobalEventList(NDChart chart)
        {
            if (chart == null)
            {
                return Events.GetGlobalEventList();
            }
            List<NDEvent> list = new List<NDEvent>();
            List<NDEvent> events = chart.Events;
            for (int i = 0; i < events.Count; i++)
            {
                NDEvent fsmEvent = events[i];
                if (fsmEvent.IsGlobal)
                {
                    list.Add(fsmEvent);
                }
            }
            return list;
        }
        public static List<NDEvent> GetEventList(NDChart chart)
        {
            if (chart != null)
            {
                return Events.GetGlobalEventList(chart);
            }
            return Events.GetGlobalEventList();
        }
       
        public static List<NDEvent> GetEventList(GameObject go)
        {
            return Events.GetGlobalEventList();
        }

        public static GUIContent[] GetEventNamesFromList(List<NDEvent> eventList)
        {
            List<GUIContent> list = new List<GUIContent>();
            list.Add(new GUIContent(Strings.Label_None));
            List<GUIContent> list2 = list;
            using (List<NDEvent>.Enumerator enumerator = eventList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDEvent current = enumerator.Current;
                    list2.Add(new GUIContent(current.Name));
                }
            }
            return list2.ToArray();
        }
        public static bool EventListContainsEventName(List<NDEvent> eventList, string fsmEventName)
        {
            using (List<NDEvent>.Enumerator enumerator = eventList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDEvent current = enumerator.Current;
                    if (current.Name == fsmEventName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
