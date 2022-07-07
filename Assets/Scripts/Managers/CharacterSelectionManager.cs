using Assets.Scripts.Events.ScriptableObjects;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Data.ScriptableObjects;

namespace Assets.Scripts.Managers
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        [SerializeField] Sprite[] _characterSprites;

        [Scene]
        [SerializeField] string _gameScene;

        [SerializeField] SpriteEventChannelSO _onUpdateSelectedCharacterSprite;

        [SerializeField] PlayerDataSO _playerData;

        int _currentIndex = 0;



        Sprite CurrentCharacterSprite => _characterSprites[_currentIndex];



        public void Next()
        {
            _currentIndex = GetCycledIndex(_currentIndex + 1);

            _onUpdateSelectedCharacterSprite.RaiseEvent(CurrentCharacterSprite);
        }

        public void Previous()
        {
            _currentIndex = GetCycledIndex(_currentIndex - 1);

            _onUpdateSelectedCharacterSprite.RaiseEvent(CurrentCharacterSprite);
        }

        public void GoToGame()
        {
            SetPlayerCharacter();

            SceneManager.LoadSceneAsync(_gameScene);
        }


        void SetPlayerCharacter() => _playerData.playerSprite = CurrentCharacterSprite;

        int GetCycledIndex(int index) => Mod(index, _characterSprites.Length);

        /// <summary>
        /// Modulus for negative numbers.
        /// </summary>
        int Mod(int n, int m) => (n%m + m) % m;
    }
}