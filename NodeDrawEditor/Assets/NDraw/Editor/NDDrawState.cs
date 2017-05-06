using System;
using UnityEngine;
namespace ihaiu.NDraws
{
    internal static class NDDrawState
    {
        public static DrawState GetDrawNode(NDChart chart)
        {
            if (chart == null || !chart.Active || chart.Finished)
            {
                return DrawState.Normal;
            }
            return GetDrawNode(chart, false, chart.Active, NDChart.BreakAtchart == chart, false);
        }
        public static DrawState GetDrawNode(NDChart chart, NDNode node, NDNodeAction action)
        {
            if (chart == null)
            {
                return DrawState.Normal;
            }
            if (!Application.isPlaying)
            {
                return DrawState.Normal;
            }
            if (!node.Active || !action.Active)
            {
                return DrawState.Normal;
            }
            if (GameStateTracker.CurrentState == GameState.Break)
            {
                return DrawState.Normal;
            }
            if (GameStateTracker.CurrentState == GameState.Paused)
            {
                return DrawState.Paused;
            }
            if (GameStateTracker.CurrentState == GameState.Running)
            {
                return DrawState.Active;
            }
            if (GameStateTracker.CurrentState == GameState.Error)
            {
                return DrawState.Error;
            }
            return DrawState.Normal;
        }
        public static DrawState GetchartStateDrawState(NDChart chart, NDNode node, bool selected)
        {
            bool active = chart.ActiveNode == node && chart.Active;
            bool isBreakpoint = NDChart.BreakAtnode == node;
            return GetDrawNode(chart, selected, active, isBreakpoint, false);
        }
        public static DrawState GetchartTransitionDrawState(NDChart chart, NDTransition transition, bool selected)
        {
            bool active = false;
            if (chart.SwitchedState || NDChart.BreakAtchart == chart)
            {
                active = (chart.LastTransition == transition && chart.Active);
            }
            return GetDrawNode(chart, selected, active, false, false);
        }
        private static DrawState GetDrawNode(NDChart chart, bool selected, bool active, bool isBreakpoint, bool invalid)
        {
            if (invalid)
            {
                return DrawState.Error;
            }
            switch (GameStateTracker.CurrentState)
            {
                case GameState.Running:
                    if (active)
                    {
                        return DrawState.Active;
                    }
                    break;
                case GameState.Break:
                    if (NDChart.BreakAtchart == chart && isBreakpoint)
                    {
                        return DrawState.Breakpoint;
                    }
                    if (active)
                    {
                        return DrawState.Paused;
                    }
                    break;
                case GameState.Paused:
                    if (active)
                    {
                        return DrawState.Paused;
                    }
                    break;
                case GameState.Error:
                    if (NDChart.BreakAtchart == chart && isBreakpoint)
                    {
                        return DrawState.Error;
                    }
                    if (active)
                    {
                        return DrawState.Paused;
                    }
                    break;
            }
            if (!selected)
            {
                return DrawState.Normal;
            }
            return DrawState.Selected;
        }
    }
}
