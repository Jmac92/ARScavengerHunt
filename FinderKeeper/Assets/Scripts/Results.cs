using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {
    public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = EndGame.finalScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
