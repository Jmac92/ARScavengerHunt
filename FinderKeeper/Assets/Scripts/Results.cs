using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {
    public Text scoreText;
    private string scoreOutput = "You found: ";

	// Use this for initialization
	void Start () {
		scoreText.text =scoreOutput + EndGame.finalScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
