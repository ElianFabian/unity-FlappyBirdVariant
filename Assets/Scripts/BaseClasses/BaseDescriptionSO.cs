using UnityEngine;

namespace Assets.Scripts.BaseClasses
{
    public class BaseDescriptionSO : ScriptableObject
    {
        [SerializeField]
        [TextArea] string _description;
    }
}
