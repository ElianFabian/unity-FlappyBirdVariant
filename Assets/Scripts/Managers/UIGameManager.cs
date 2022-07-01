using UnityEngine;

namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class UIGameManager : MonoBehaviour
    {
        #region Unity event functions

        private void Start()
        {
            HideMouseCursor();
        }

        #endregion

        #region Methods

        public void ShowMouseCursor() => Cursor.visible = true;

        public void HideMouseCursor() => Cursor.visible = false;

        #endregion
    }
}
