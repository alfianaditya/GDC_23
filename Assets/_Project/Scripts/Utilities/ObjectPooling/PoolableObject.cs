namespace GDC.ObjectPooling
{
    /// <summary>
    /// Represents a poolable object.
    /// </summary>
    public class PoolableObject<T>
    {
        public T Item;
        public bool Used { get; private set; }

        #region Public methods
        public void Use()
        {
            Used = true;
        }



        public void Release()
        {
            Used = false;
        }
        #endregion
    }
}
