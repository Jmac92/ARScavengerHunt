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
        if (IsCollected)
        {
            gameObject.SetActive(false);
        }
	}

    public string Id { get; set; }

    public bool IsCollected { get; set; }

    public bool IsVisibleOnMap { get; set; }

    public string LatLong { get; set; }
}
