using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    [Header("Count of Items")]
    [SerializeField] private int pumpkinCount;
    [SerializeField] private int smallPumpkinCount;

    [Header("Items Text")]
    [SerializeField] private Text pumpkinCountText;
    [SerializeField] private Text smallPumpkinCountText;

    public void AddItem(ItemType type){
        CheckItemType(type);
    }


    private void OnEnable() {
        Pumpkin.onCollectItem += AddItem;
        SmallPumpkin.onCollectItem += AddItem;
    }

    private void OnDisable() {
        Pumpkin.onCollectItem -= AddItem;
        SmallPumpkin.onCollectItem -= AddItem;
    }

    private void CountTextUpdate(ItemType type){
        switch (type)
        {
            case ItemType.Pumpkin:
                pumpkinCountText.text = pumpkinCount.ToString();
                break;
            case ItemType.SmallPumpkin:
                smallPumpkinCountText.text = smallPumpkinCount.ToString();
                break;
        }
    }

    private void CheckItemType(ItemType type){
        switch (type)
        {   
            case ItemType.Pumpkin:
                pumpkinCount++;
                CountTextUpdate(type);
                break;
            case ItemType.SmallPumpkin:
                smallPumpkinCount++;
                CountTextUpdate(type);
                break;
        }
    }

}

public enum ItemType { Pumpkin, SmallPumpkin }
