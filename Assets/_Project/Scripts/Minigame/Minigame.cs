using UnityEngine;

namespace GDC.Minigame
{
    /// <summary>
    /// Handles minigame UI.
    /// </summary>
    public class Minigame : MonoBehaviour
    {
        [SerializeField] private GameObject Item;
        [SerializeField] private GameObject ItemDrop;
        [SerializeField] private int Range;
        Vector2 ItemPos;

        [SerializeField] private GameObject MinigameObject;
        [SerializeField] private GameObject Anim;
        

        #region MonoBehaviour methods
        void Start()
        {
            ItemPos = Item.transform.position;
        }
        #endregion

        #region Public methods

        public void ItemDrag()
        {
            Item.transform.position = Input.mousePosition;
        }

        public void ItemEndDrag()
        {
            float distance = Vector3.Distance(Item.transform.localPosition, ItemDrop.transform.localPosition);
            if (distance < Range)
            {
                Item.transform.position = ItemDrop.transform.position;
                Minigames();
            }
            else
            {
                Item.transform.position = ItemPos;
            }

        }
        #endregion


        #region Private methods
        private void Minigames()
        {
            Anim.SetActive(true);
            MinigameObject.SetActive(false);
        }

        #endregion
    }
}
