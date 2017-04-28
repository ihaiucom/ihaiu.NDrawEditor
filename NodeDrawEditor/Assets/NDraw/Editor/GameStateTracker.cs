using System;
using UnityEditor;
namespace ihaiu.NDraws
{
    internal static class GameStateTracker
    {
        public static GameState CurrentState
        {
            get;
            private set;
        }
        public static GameState PreviousState
        {
            get;
            private set;
        }
        public static bool StateChanged
        {
            get
            {
                return GameStateTracker.CurrentState != GameStateTracker.PreviousState;
            }
        }
        public static void Update()
        {
            GameStateTracker.PreviousState = GameStateTracker.CurrentState;
            GameStateTracker.CurrentState = GameStateTracker.GetCurrentState();
        }
        private static GameState GetCurrentState()
        {
            if (EditorApplication.isPaused)
            {
                if (NDChart.IsErrorBreak)
                {
                    return GameState.Error;
                }
                if (NDChart.IsBreak)
                {
                    return GameState.Break;
                }
                return GameState.Paused;
            }
            else
            {
                if (!EditorApplication.isPlaying)
                {
                    return GameState.Stopped;
                }
                return GameState.Running;
            }
        }
    }
}
