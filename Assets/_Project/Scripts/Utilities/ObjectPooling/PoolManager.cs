using System;
using System.Collections.Generic;
using UnityEngine;
using GDC.Utilities;

namespace GDC.ObjectPooling
{
    /// <summary>
    /// Handles object pool behaviour.
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<GameObject, ObjectPool<GameObject>> prefabLookup;
        private Dictionary<GameObject, ObjectPool<GameObject>> instanceLookup;



        #region MonoBehaviour methods
        protected override void Awake()
        {
            base.Awake();

            prefabLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
            instanceLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
        }
        #endregion



        #region Private methods
        private void initializePool(GameObject prefab, int size)
        {
            if (prefabLookup.ContainsKey(prefab))
            {
                throw new Exception($"Pool for prefab {prefab.name} has already been created");
            }

            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(() => { return InstantiatePrefab(prefab); }, size);
            prefabLookup[prefab] = pool;
        }



        private GameObject spawnObject(GameObject prefab)
        {
            return spawnObject(prefab, Vector3.zero, Quaternion.identity);
        }



        private GameObject spawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (!prefabLookup.ContainsKey(prefab))
            {
                initializePool(prefab, 1);
            }

            ObjectPool<GameObject> pool = prefabLookup[prefab];

            GameObject clone = pool.GetItem();
            clone.transform.SetPositionAndRotation(position, rotation);
            clone.SetActive(true);

            instanceLookup.Add(clone, pool);
            return clone;
        }



        private void releaseObject(GameObject clone)
        {
            clone.SetActive(false);

            if (instanceLookup.ContainsKey(clone))
            {
                instanceLookup[clone].ReleaseItem(clone);
                instanceLookup.Remove(clone);
            }

            else
            {
                Debug.LogWarning($"No pool contains the object: {clone.name}");
            }
        }



        private GameObject InstantiatePrefab(GameObject prefab)
        {
            GameObject obj = Instantiate(prefab) as GameObject;
            return obj;
        }
        #endregion



        #region Static API
        public static void InitializePool(GameObject prefab, int size)
        {
            Instance.initializePool(prefab, size);
        }



        public static GameObject SpawnObject(GameObject prefab)
        {
            return Instance.spawnObject(prefab);
        }



        public static GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Instance.spawnObject(prefab, position, rotation);
        }



        public static void ReleaseObject(GameObject clone)
        {
            Instance.releaseObject(clone);
        }
        #endregion
    }
}
