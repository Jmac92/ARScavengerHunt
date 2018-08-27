using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField] List<ItemsDetails> items;
    [SerializeField] Transform itemsParent;
    //public ItemsDetails collectedItems;
    [SerializeField] ItemDisplay[] display;
    public Button closeInventoryList;
    private int no = 0;

    private void Awake()
    {
        if (itemsParent != null)
            display = itemsParent.GetComponentsInChildren<ItemDisplay>();
        UpdateData();
    }
    void Update()
    {
        Button button = closeInventoryList.GetComponent<Button>();
        button.onClick.AddListener(CloseInventoryList);
        UpdateData();  
    }

    //Save for future use when player get the ability to add items
    /*public void AddItem(string itemName)
    {
        Instantiate(collectedItems);
        collectedItems.itemName = itemName;
        
        items.Add(collectedItems);
    }*/

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

    public void DarkenImage()
    {

        if (display[no].Item != null && display[no].GetComponent<Image>().color != Color.gray)
        {
            if (display[no].GetComponent<Image>().color == Color.white)
            {
                display[no].GetComponent<Image>().color = Color.gray;
            }
            else
            {
                Debug.Log("You are collecting more than required");
            }
        }
        no += 1;
        
    }


}
