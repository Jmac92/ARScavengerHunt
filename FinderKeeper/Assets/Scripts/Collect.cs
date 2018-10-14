using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Collect : MonoBehaviour {

    public Text itemsText;
    public GameObject collectionPanel = null;
    //public GameObject InventoryList;

    //private Inventory _inventory;
    private int _Items;
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
    void Start () {
        int collectedCount = GameManager.Instance.GetCollectedItems().Count;
        itemsText.text = collectedCount + "/5";
        HideCollectionPanel();
        _Items = collectedCount;
    }

    public void CollectionOnClick() {
        if (_collectedItem.tag == "Low")
        {
            _Items += 1;
            itemsText.text =  _Items + "/5";
            //_inventory = InventoryList.GetComponent<Inventory>();
            //_inventory.WhitenImage();

            if (_collectedItem.GetComponentInParent<Collectible>() != null)
            {
                Debug.Log("COLLECTED " + _collectedItem.transform.parent.name);
                var collectible = _collectedItem.GetComponentInParent<Collectible>();
                collectible.Id = Convert.ToInt32(_collectedItem.transform.parent.name);
                collectible.IsCollected = true;
                collectible.IsVisibleOnMap = false;
                GameManager.Instance.AddCollectedItem(collectible);
            }
            else Debug.Log(_collectedItem.name + " AIN'T NO COLLECTIBLE");

        }
        HideCollectionPanel();  
    }

    private void Update()
    {
        //Touch input - use this block for app
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.tag == "Low")
                {
                    _collectedItem = raycastHit.transform.gameObject;
                    var collectible = _collectedItem.GetComponentInParent<Collectible>();
                    collectible.Id = Convert.ToInt32(_collectedItem.transform.parent.name);
                    collectible.IsCollected = true;
                    collectible.IsVisibleOnMap = false;
                    GameManager.Instance.AddCollectedItem(collectible);
                    SceneManager.LoadScene("ARMode");
                }
            }
        }

        //mouse input - use this block for testing
        if (Input.GetMouseButton(0))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.tag == "Low")
                {
                    _collectedItem = raycastHit.transform.gameObject;
                    var collectible = _collectedItem.GetComponentInParent<Collectible>();
                    collectible.Id = Convert.ToInt32(_collectedItem.transform.parent.name);
                    collectible.IsCollected = true;
                    collectible.IsVisibleOnMap = false;
                    GameManager.Instance.AddCollectedItem(collectible);
                    SceneManager.LoadScene("ARMode");
                }
            }
        }
    }
}
