using UnityEngine;

[CreateAssetMenu(menuName = "Create Item/New Item")]
public class ItemsData : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public bool isNew = false;

}
