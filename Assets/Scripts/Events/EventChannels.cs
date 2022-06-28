using System;



namespace Assets.Scripts.EventChannels
{
    public static class GameEvents
    {
        public static event Action
                OnGameOver,
                OnGamePaused,
                OnGameResumed,
                OnGameRestarted;
        public static event Action<string> OnSceneChanged;
        public static event Action<int>    OnScoreChanged;

        public static void RaiseGameOverEvent() => OnGameOver?.Invoke();
        public static void RaiseGamePausedEvent() => OnGamePaused?.Invoke();
        public static void RaiseGameResumedEvent() => OnGameResumed?.Invoke();
        public static void RaiseGameRestartedEvent() => OnGameRestarted?.Invoke();
        public static void RaiseSceneChangedEvent(string sceneName) => OnSceneChanged?.Invoke(sceneName);
        public static void RaiseScoreChangedEvent(int newScore) => OnScoreChanged?.Invoke(newScore);
    }

    public static class UIEvents
    {
        public static event Action
                BtnGoToMenu_Click,
                BtnTryAgain_Click,
                OnPauseToggled;

        public static void RaiseBtnGoToMenu_ClickEvent() => BtnGoToMenu_Click?.Invoke();
        public static void RaiseBtnTryAgain_ClickEvent() => BtnTryAgain_Click?.Invoke();
        public static void RaisePauseToggledEvent() => OnPauseToggled?.Invoke();
    }
}
