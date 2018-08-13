using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour {

    public Text scoreText;
    public GameObject collectionPanel = null;
    public GameObject InventoryList;
    public Button collectionButton;

    private Inventory _inventory;
    private int _score = 0;
    private string _scoreOutput = "Score = ";
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

    void OnCollisionEnter(Collision collision)
    {
        _collectedItem = collision.gameObject;
        ShowCollectionPanel();
    }

    // Use this for initialization
    void Start () {
        HideCollectionPanel();
        _score = 0;
        scoreText.text = _scoreOutput + _score;

        Button btn = collectionButton.GetComponent<Button>();
        btn.onClick.AddListener(CollectionOnClick);
    }

    void CollectionOnClick() {
        if (_collectedItem.tag == "High")

        {
            _score += 10;
            scoreText.text = _scoreOutput + _score;
            _inventory = InventoryList.GetComponent<Inventory>();
            _inventory.Add("High");
            Destroy(_collectedItem);
        }
        if (_collectedItem.tag == "Mid")

        {
            _score += 5;
            scoreText.text = _scoreOutput + _score;
            _inventory = InventoryList.GetComponent<Inventory>();
            _inventory.Add("Mid");
            Destroy(_collectedItem);
        }
        if (_collectedItem.tag == "Low")

        {
            _score += 2;
            scoreText.text = _scoreOutput + _score;
            _inventory = InventoryList.GetComponent<Inventory>();
            _inventory.Add("Low");
            Destroy(_collectedItem);
        }
        HideCollectionPanel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
