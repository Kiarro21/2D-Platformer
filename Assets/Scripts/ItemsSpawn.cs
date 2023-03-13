using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsList;
    [SerializeField] List<Transform> spawnPositions;
 
    private void Start(){
        OnClickSpawnItems();
    }

    public void OnClickSpawnItems(){
        if (itemsList != null){
            for (int i = 0; i <= itemsList.Count; i++){
                Instantiate(itemsList[Random.Range(0, itemsList.Count)], spawnPositions[i].position, Quaternion.identity);
            }
        }
    }
        
    private void Update() {
        if (Input.GetMouseButtonDown(1)){
            OnClickSpawnItems();
        }
        // if (isSpawn){
        //     Instantiate(itemsList[Random.Range(0, itemsList.Count)], spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);
        //     isSpawn = false;
        // }
    }
}
