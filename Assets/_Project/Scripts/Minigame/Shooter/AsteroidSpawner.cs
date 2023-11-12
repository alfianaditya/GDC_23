using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDC.Shooter
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private int numberOfAsteroids = 5;
        [SerializeField] private float spawnInterval = 2f;
        [SerializeField] private float minSpeed = 2f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float minY = -4.5f;
        [SerializeField] private float maxY = 4.5f;

        #region MonoBehaviour Methods
        private void Start()
        {
            InvokeRepeating("SpawnAsteroid", 0f, spawnInterval);
        }
        #endregion

        #region Private Methods
        private void SpawnAsteroid()
        {
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                // Menentukan posisi awal asteroid di sisi kanan
                float spawnY = Random.Range(minY, maxY);
                Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);

                // Menciptakan asteroid
                GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

                // Menentukan kecepatan asteroid secara acak
                float asteroidSpeed = Random.Range(minSpeed, maxSpeed);

                // Memberikan kecepatan asteroid ke komponen Rigidbody2D (atau sesuaikan dengan komponen yang Anda gunakan)
                Rigidbody2D rb2d = asteroid.GetComponent<Rigidbody2D>();
                if (rb2d != null)
                {
                    rb2d.velocity = new Vector2(-asteroidSpeed, 0f);
                }
                else
                {
                    Debug.LogWarning("Rigidbody2D not found on asteroid prefab.");
                }
            }
        }
        #endregion
    }
}

