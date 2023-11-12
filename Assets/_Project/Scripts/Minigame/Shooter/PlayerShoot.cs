using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDC.Minigame.Shooter
{
    /// <summary>
    /// Handles player shooting in the shooter minigame.
    /// </summary>
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;

        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
        }
        #endregion
        
        
        
        #region Private methods
        private void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 10, ForceMode2D.Impulse);
        }



        private void GetInput()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        #endregion
    }
}
