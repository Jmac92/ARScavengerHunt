using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField] List<ItemsDetails> items;
    [SerializeField] Transform itemsParent;
    public ItemsDetails collectedItems;
    private ItemDisplay[] display;
    public Button closeInventoryList;
 
    void Update()
    {
        if (itemsParent != null)
            display = itemsParent.GetComponentsInChildren<ItemDisplay>();
        UpdateData();

        Button button = closeInventoryList.GetComponent<Button>();
        button.onClick.AddListener(CloseInventoryList);
    }


    public void AddItem(string itemName)
    {
        Instantiate(collectedItems);
        collectedItems.itemName = itemName;
        
        items.Add(collectedItems);
    }

    void CloseInventoryList()
    {
        gameObject.SetActive(false);
    }

    private void UpdateData()
    {
        int i = 0;
        for (; i < items.Count && i < display.Length; i++)
        {
            display[i].Item = items[i];
        }
        for (; i < display.Length; i++)
        {
            display[i].Item = null;
        }
    }


}
