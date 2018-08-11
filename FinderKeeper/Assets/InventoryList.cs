using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour {
    public GameObject inventoryList;
    public Button openInventoryList;

	// Use this for initialization
	void Start () {
        if (inventoryList != null)
            inventoryList.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
        Button button = openInventoryList.GetComponent<Button>();
        button.onClick.AddListener(OpenInventoryList);
	}

    void OpenInventoryList()
    {
        inventoryList.SetActive(true);
    }
}
