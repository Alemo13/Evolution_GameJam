using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("Pickable"))
            {
                IPickable pickedItem = other.gameObject.GetComponent<IPickable>();
                pickedItem.TakeIt();
            }
        }
    }
}
