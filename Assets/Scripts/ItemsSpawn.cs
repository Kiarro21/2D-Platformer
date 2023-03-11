using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsList;
    [SerializeField] List<Transform> spawnPositions;
    [SerializeField] private bool isSpawn = false;
    private float timeToSpawn = 10f;


    // Start is called before the first frame update
    private void Start(){
        if (itemsList != null){
            Instantiate(itemsList[Random.Range(0, itemsList.Count)], spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);
        }
    }

    private void Update() {
        if (isSpawn){
            Instantiate(itemsList[Random.Range(0, itemsList.Count)], spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);
            isSpawn = false;
        }
    }

    public IEnumerator TimeToSpawn(float time){
        yield return new WaitForSeconds(time);
        isSpawn = true;
    }

    public void isSpawnSet(){
        StartCoroutine(TimeToSpawn(timeToSpawn));
    }
}
