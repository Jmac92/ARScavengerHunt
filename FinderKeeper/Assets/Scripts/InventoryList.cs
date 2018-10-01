using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour {
    public GameObject inventoryList;

    // Use this for initialization
    void Start () {
        if (inventoryList != null)
            inventoryList.SetActive(false);

    }

    public void OpenInventoryList()
    {
        inventoryList.SetActive(!inventoryList.activeInHierarchy);
    }
}
