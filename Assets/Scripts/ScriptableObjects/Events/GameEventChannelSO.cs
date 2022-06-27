using System;
using UnityEngine;



namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "GameEventChannel", menuName = "Custom Event Channels/Game Event Channel")]
    public class GameEventChannelSO : ScriptableObject
    {
        public event Action
            OnGameOver,
            OnGamePaused,
            OnGameResumed,
            OnGameRestarted;
        public event Action<string> OnSceneChanged;
        public event Action<int>    OnScoreChanged;



        public void RaiseGameOverEvent() => OnGameOver?.Invoke();
        public void RaiseGamePausedEvent() => OnGamePaused?.Invoke();
        public void RaiseGameResumedEvent() => OnGameResumed?.Invoke();
        public void RaiseGameRestartedEvent() => OnGameRestarted?.Invoke();
        public void RaiseSceneChangedEvent(string sceneName) => OnSceneChanged?.Invoke(sceneName);
        public void RaiseScoreChangedEvent(int newScore) => OnScoreChanged?.Invoke(newScore);
    }
}
