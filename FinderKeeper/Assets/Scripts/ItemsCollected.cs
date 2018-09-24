using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemsCollected : MonoBehaviour {
    public Text CollectedText;
    private int CollectedItems = 0;
    

	// Use this for initialization
	void Start () {
        CollectedItems = 0;
        CollectedText.text = CollectedItems + "/5";
	}
}

