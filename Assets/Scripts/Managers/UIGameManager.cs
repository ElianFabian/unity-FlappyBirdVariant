using UnityEngine;

namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class UIGameManager : MonoBehaviour
    {
        #region Methods

        public void ShowMouseCursor() => Cursor.visible = true;

        public void HideMouseCursor() => Cursor.visible = false;

        #endregion
    }
}
