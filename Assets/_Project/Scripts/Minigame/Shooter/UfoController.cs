using UnityEngine;

namespace GDC.Shooter
{
    public class UfoController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate = 0.2f; // Sesuaikan dengan kebutuhan permainan

        // Variable untuk menyimpan apakah tombol mouse kiri masih ditekan
        private bool isShooting = false;
        private float nextFireTime = 0f;

        #region MonoBehaviour methods
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
            transform.Translate(movement);

            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8f, 8f);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.5f, 4.5f);
            transform.position = clampedPosition;

            // Input untuk menembak
            if (Input.GetMouseButtonDown(0))
            {
                // Tombol mouse kiri ditekan, atur isShooting menjadi true
                isShooting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                // Tombol mouse kiri dilepas, atur isShooting menjadi false
                isShooting = false;
            }

            // Jika isShooting true dan sudah waktunya menembak, panggil Shoot
            if (isShooting && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        #endregion

        #region Private methods
        private void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        #endregion
    }
}
