using UnityEngine;



namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Pipe : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.SetGameOver();
        }
    }
}
