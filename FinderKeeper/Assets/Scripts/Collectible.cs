using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    // Use this for initialization
    void Awake () {
        Id = -1;
        IsCollected = false;
	}
	
	// Update is called once per frame
	void Update () {
        bool isInCollectionList = GameManager.Instance.HasItemBeenCollected(Id);
        
        if (isInCollectionList)
        {
            gameObject.SetActive(false);
        }

        if (Id >= 0) {
            Debug.Log("ID: " + Id);
        }
	}

    public int Id { get; set; }

    public bool IsCollected { get; set; }

    public bool IsVisibleOnMap { get; set; }

    public string LatLong { get; set; }
}
