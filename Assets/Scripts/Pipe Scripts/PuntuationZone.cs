using UnityEngine;



namespace Assets.Scripts.PipeScripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PuntuationZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.IncrementScore();

            Destroy(gameObject);
        }
    }
}
