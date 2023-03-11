using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin :MonoBehaviour
{
    [SerializeField] private ItemsManager itemsManager;
    [SerializeField] private ItemsSpawn itemsSpawn;

    private void Start() {
        itemsManager = GameObject.Find("ItemsManager").GetComponent<ItemsManager>();
        itemsSpawn = GameObject.Find("ItemsSpawner").GetComponent<ItemsSpawn>();
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            itemsManager.AddItem(gameObject);
            itemsSpawn.isSpawnSet();
            HideItem();
        }
    }

    

    private void HideItem(){
        gameObject.SetActive(false);
    }

}
