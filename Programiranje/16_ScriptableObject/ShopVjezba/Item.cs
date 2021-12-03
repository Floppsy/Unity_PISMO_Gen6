using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    public Text itemName;

    public void Prikazi()
    {
        Debug.Log(itemData.GetName);
        itemName.text = itemData.GetName;
        Debug.Log(itemData.GetDescription);
        Debug.Log(itemData.GetLevel);
        Debug.Log(itemData.GetSize);
        Debug.Log(itemData.GetPrice);
    }
}
