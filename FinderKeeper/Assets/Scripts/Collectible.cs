using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    // Use this for initialization
    void Awake () {
        Id = "";
        IsCollected = false;
	}
	
	// Update is called once per frame
	void Update () {
        bool isInCollectionList = GameManager.Instance.HasItemBeenCollected(Id);
        if (IsCollected)
        {
            Debug.Log("DESTROYING " + Id);
            Destroy(gameObject);
        }

        if (isInCollectionList)
        {
            Debug.Log("DESTROYING " + Id);
            Destroy(gameObject);
        }

        if (Id != "") {
            Debug.Log("ID: " + Id);
        }
	}

    public string Id { get; set; }

    public bool IsCollected { get; set; }
}
