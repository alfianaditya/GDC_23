using UnityEngine;

namespace GDC.Shooter
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        void Start()
        {
            // Berikan velocity ke peluru
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }

        void Update()
        {
            // Hapus peluru jika telah keluar dari layar
            if (transform.position.x > 10f)
            {
                Destroy(gameObject);
            }
        }

        // Dijalankan ketika ada collision dengan objek lain
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Periksa apakah objek yang ditabrak adalah asteroid
            if (other.CompareTag("Asteroid"))
            {
                // Hancurkan asteroid dan peluru
                Destroy(other.gameObject); // Hancurkan asteroid
                Destroy(gameObject); // Hancurkan peluru
            }
        }
    }
}
