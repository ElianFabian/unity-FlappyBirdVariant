using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class DisplayCharacterController : MonoBehaviour
    {
        Image _image;



        private void Awake()
        {
            _image = GetComponent<Image>();
        }



        public void UpdateCharacterImage(Sprite characterSprite)
        {
            _image.sprite = characterSprite;
        }
    }
}
