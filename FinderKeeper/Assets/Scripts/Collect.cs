using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour {

    public Text itemsText;
    public GameObject collectionPanel = null;
    public GameObject InventoryList;
    public Button collectionButton;

    private Inventory _inventory;
    private int _Items = 0;
    private string _itemOutput;
    private GameObject _collectedItem = null;
    


    public void ShowCollectionPanel() {
        if (collectionPanel != null) {
            collectionPanel.SetActive(true);
        }
    }

    public void HideCollectionPanel()
    {
        if (collectionPanel != null)
        {
            collectionPanel.SetActive(false);
        }
    }

    // Use this for initialization
    void Awake () {
        HideCollectionPanel();
        _Items = 0;
    }

    void CollectionOnClick() {
        if (_collectedItem.tag == "Low")
        {
            _Items += 1;
            itemsText.text = _itemOutput + _Items + "/5";
            _inventory = InventoryList.GetComponent<Inventory>();
            _inventory.DarkenImage();
            Destroy(_collectedItem.transform.parent.gameObject);
            
        }
        HideCollectionPanel();  
    }

    private void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.tag == "Low") {
                    _collectedItem = raycastHit.transform.gameObject;
                    ShowCollectionPanel();
                }
            }
        }
        if (_Items == 5)
        {

        }
    }
}
