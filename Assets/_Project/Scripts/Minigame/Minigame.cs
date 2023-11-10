using UnityEngine;
using System.Collections;

namespace GDC.Minigame
{
    /// <summary>
    /// Handles minigame UI.
    /// </summary>
    public class Minigame : MonoBehaviour
    {
        [SerializeField] private GameObject AlatPenyiram;
        [SerializeField] private GameObject Tanaman;
        [SerializeField] private int Range;
        Vector2 ItemPos;
        private Animator Anim;
        

        #region MonoBehaviour methods
        void Start()
        {
            ItemPos = AlatPenyiram.transform.position;
            Anim = AlatPenyiram.GetComponent<Animator>();
        }
        #endregion

        #region Public methods

        public void ItemDrag()
        {
            AlatPenyiram.transform.position = Input.mousePosition;
        }

        public void ItemEndDrag()
        {
            float distance = Vector3.Distance(AlatPenyiram.transform.localPosition, Tanaman.transform.localPosition);
            if (distance < Range)
            {
                AlatPenyiram.transform.position = Tanaman.transform.position;
                Siram();
            }
            else
            {
                AlatPenyiram.transform.position = ItemPos;
            }

        }
        #endregion

        
        #region Private methods
        private void Siram()
        {
            Anim.SetBool("Siram", true);
            StartCoroutine(Wait());
            
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(8);
            Anim.SetBool("Siram", false);
            AlatPenyiram.transform.position = ItemPos;
        }

        #endregion
    }
}