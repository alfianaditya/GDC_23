using System;
using System.Collections.Generic;
using UnityEngine;

namespace GDC.ObjectPooling
{
    /// <summary>
    /// Stores poolable objects.
    /// </summary>
    public class ObjectPool<T>
    {
        private List<PoolableObject<T>> objectList;
		private Dictionary<T, PoolableObject<T>> objectLookup;
		private Func<T> factoryFunc;



        #region Public methods
        public ObjectPool(Func<T> factoryFunc, int initialSize)
		{
			this.factoryFunc = factoryFunc;

			objectList = new List<PoolableObject<T>>(initialSize);
			objectLookup = new Dictionary<T, PoolableObject<T>>(initialSize);

			Initialize(initialSize);
		}



		public T GetItem()
		{
			PoolableObject<T> poolableObject = null;

            foreach (PoolableObject<T> obj in objectList)
            {
                if (obj.Used)
                {
                    continue;
                }

                else
                {
                    poolableObject = obj;
                    break;
                }
            }

			if (poolableObject == null)
			{
				poolableObject = CreatePoolableObject();
			}

			poolableObject.Use();
			objectLookup.Add(poolableObject.Item, poolableObject);

			return poolableObject.Item;
		}



		public void ReleaseItem(object item)
		{
			ReleaseItem((T) item);
		}



		public void ReleaseItem(T item)
		{
			if (objectLookup.ContainsKey(item))
			{
				PoolableObject<T> poolableObject = objectLookup[item];
				poolableObject.Release();
				objectLookup.Remove(item);
			}
            
			else
			{
				Debug.LogWarning($"This object pool does not contain the item provided: {item}");
			}
		}



		public int Count
		{
			get { return objectList.Count; }
		}



		public int CountUsedItems
		{
			get { return objectLookup.Count; }
		}
        #endregion



        
        #region Private methods
        private PoolableObject<T> CreatePoolableObject()
		{
			PoolableObject<T> poolableObject = new PoolableObject<T>();
			poolableObject.Item = factoryFunc();
			objectList.Add(poolableObject);
            
			return poolableObject;
		}



        private void Initialize(int capacity)
		{
			for (int i = 0; i < capacity; i++)
			{
				CreatePoolableObject();
			}
		}
        #endregion
    }
}
