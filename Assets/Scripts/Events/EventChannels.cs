using Assets.Scripts.PlayerScripts;
using System;
using UnityEngine;



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

    public static class PlayerEvents
    {
        public static event Action OnJump;

        public static void RaiseJumpEvent() => OnJump?.Invoke();
    }

    public static class PlayerCollisionEvents
    {
        public static event Action<Player, Collider2D> OnScoreZoneTriggerEnter2D;
        public static event Action<Player, Collider2D> OnDeathZoneTriggerEnter2D;


        public static void RaiseScoreZoneTriggerEnter2DEvent(Player player, Collider2D collision)
        {
            OnScoreZoneTriggerEnter2D?.Invoke(player, collision);
        }

        public static void RaiseDeathZoneTriggerEnter2DEvent(Player player, Collider2D collision)
        {
            OnDeathZoneTriggerEnter2D?.Invoke(player, collision);
        }
    }
}
