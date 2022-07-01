using System;
using UnityEngine;

namespace Assets.Scripts.BaseClasses
{
    public class BaseVariableSO<T> : BaseDescriptionSO, ISerializationCallbackReceiver
    {
        public T initialValue;

        [NonSerialized]
        public T value;



        public void OnBeforeSerialize()
        {
            value = initialValue;
        }

        public void OnAfterDeserialize() { }
    }
}
