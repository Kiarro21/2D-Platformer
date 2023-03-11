using System;
using UnityEngine;

public class SmallPumpkin : MonoBehaviour
{
   [SerializeField] private ItemsManager itemsManager;

   [SerializeField] private ItemsData itemsData;
    public ItemType itemType = ItemType.SmallPumpkin;
    
    public static Action<ItemType> onCollectItem;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            onCollectItem?.Invoke(itemType);
            DestroyItem();
        }
    }

    private void DestroyItem(){
        Destroy(gameObject);
    }
}
