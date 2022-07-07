using Assets.Scripts.Data.ScriptableObjects;
using Assets.Scripts.Events.ScriptableObjects;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        [SerializeField] PlayerConfigurationSO[] _characterConfigurations;

        [Scene]
        [SerializeField] string _gameScene;

        [SerializeField] SpriteEventChannelSO _onUpdateSelectedCharacterSprite;

        [SerializeField] PlayerDataSO _playerData;

        int _currentIndex = 0;



        Sprite _CurrentCharacterSprite => _characterConfigurations[_currentIndex].playerSprite;



        private void Awake()
        {
            _onUpdateSelectedCharacterSprite.RaiseEvent(_CurrentCharacterSprite);
        }



        public void Next()
        {
            _currentIndex++;
            _currentIndex = GetCycledIndex(_currentIndex);

            _onUpdateSelectedCharacterSprite.RaiseEvent(_CurrentCharacterSprite);

            SetPlayerCharacter();
        }

        public void Previous()
        {
            _currentIndex--;
            _currentIndex = GetCycledIndex(_currentIndex);

            _onUpdateSelectedCharacterSprite.RaiseEvent(_CurrentCharacterSprite);

            SetPlayerCharacter();
        }

        public void GoToGame()
        {
            SceneManager.LoadSceneAsync(_gameScene);
        }



        void SetPlayerCharacter() => _playerData.SetConfiguration(_characterConfigurations[_currentIndex]);

        int GetCycledIndex(int index) => Mod(index, _characterConfigurations.Length);

        /// <summary>
        /// Modulus for negative numbers.
        /// </summary>
        int Mod(int n, int m) => (n%m + m) % m;
    }
}