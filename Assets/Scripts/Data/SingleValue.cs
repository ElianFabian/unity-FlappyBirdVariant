namespace Assets.Scripts.Data
{
    /// <summary>
    /// Used in event listeners when used in the inspector to avoid passing a primitive value as parameter
    /// </summary>
    /// <typeparam name="T">Primitive type</typeparam>
    public struct SingleValue<T>
    {
        public T value;
    }
}
