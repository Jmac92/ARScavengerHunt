using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemsCollected : MonoBehaviour {
    public Text CollectedText;
    private int CollectedItems = 0;
    private string CollectedItemsOutput = "Items: ";

	// Use this for initialization
	void Start () {
        CollectedItems = 0;
        CollectedText.text = CollectedItemsOutput + CollectedItems + "/5";
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}

