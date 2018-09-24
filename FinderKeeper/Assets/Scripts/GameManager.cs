using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public Text itemsText;
    public GameObject collectionPanel = null;
    public GameObject InventoryList;
    public Button collectionButton;

    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (itemsText == null)
            itemsText = GameObject.Find("ItemsCollected").GetComponent<Text>();
        if (collectionPanel == null)
            collectionPanel = GameObject.Find("CollectionPanel");
        if (InventoryList == null)
            InventoryList = GameObject.Find("InventoryList");
        if (collectionPanel == null)
            collectionPanel = GameObject.Find("CollectionPanel");
        if (collectionButton == null)
            collectionButton = GameObject.Find("CollectionButton").GetComponent<Button>();

        //collectionButton.onClick.AddListener(CollectionOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
