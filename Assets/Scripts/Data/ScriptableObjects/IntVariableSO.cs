using Assets.Scripts.BaseClasses;
using UnityEngine;

namespace Assets.Scripts.Data.ScriptableObjects
{
    // From: https://unity.com/es/how-to/architect-game-code-scriptable-objects

    [CreateAssetMenu(menuName = "Data/Int Variable")]
    public class IntVariableSO : BaseVariableSO<int> { }
}
