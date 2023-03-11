using System;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    [SerializeField] private ItemsManager itemsManager;
    public ItemType itemType = ItemType.Pumpkin;
    
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

    public void Initialize(ItemsManager _itemsManager){
        itemsManager = _itemsManager;
    }

}

