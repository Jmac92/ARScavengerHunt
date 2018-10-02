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
	
	// Update is called once per frame
	void Update () {
	}

    public void OpenInventoryList()
    {
        inventoryList.SetActive(!inventoryList.activeInHierarchy);
    }
}
