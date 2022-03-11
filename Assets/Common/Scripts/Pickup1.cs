using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup1 : MonoBehaviour
{
    [SerializeField] Item.Type type;
    [SerializeField] GameObject pickupPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Inventory>(out Inventory inventory))
        {
            if(inventory.AddItem(type))
            {
                if(pickupPrefab)
                {
                    Instantiate(pickupPrefab, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
