using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour {
    public GameObject inventoryList;
    public Button openInventoryList;

    private void Awake()
    {
        if (inventoryList== null)
            inventoryList = GameObject.Find("InventoryList");

        if (openInventoryList == null)
            openInventoryList = GameObject.Find("itemButton").GetComponent<Button>();
    }

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
