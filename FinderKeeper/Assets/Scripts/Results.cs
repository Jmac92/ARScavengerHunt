using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {
	[SerializeField]
    Text scoreText;

	[SerializeField]
	Text messageText;

	// Use this for initialization
	void Start () {
		scoreText.text = "You found: " + EndGame.finalScore;

		switch (EndGame.finalScore)
		{
			case "5/5":
				messageText.text = "Impressive!";
				break;
			case "4/5":
				messageText.text = "So close!";
				break;
			case "3/5":
				messageText.text = "Well done!";
				break;	
			default:
				messageText.text = "Better luck next time!";
				break;
		}
	}
}
