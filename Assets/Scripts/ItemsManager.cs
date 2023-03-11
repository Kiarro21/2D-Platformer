using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public List<GameObject> curruntItems;

    public void AddItem(GameObject item){
        curruntItems.Add(item);
    }
}
