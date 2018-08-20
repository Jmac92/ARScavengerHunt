using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public Text ScoreText;
    private int score = 0;
    private string scoreOutput = "Score: ";

	// Use this for initialization
	void Start () {
        score = 0;
        ScoreText.text = scoreOutput + score;
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "High")

        {
            score += 10;
            ScoreText.text = scoreOutput + score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Mid")

        {
            score += 5;
            ScoreText.text = scoreOutput + score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Low")

        {
            score += 2;
            ScoreText.text = scoreOutput + score;
            Destroy(collision.gameObject);
        }

    }
}

