using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {
    public Text TimeText;
    public Text ScoreText;
    public float MaxTime = 300;
    public float SceneTime = 0;
    public GameObject EndPanel;
    private string TimeOutput = "REMAINING TIME:\n";


	// Use this for initialization
	void Start () {
		EndPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        SceneTime += Time.deltaTime;
        if (SceneTime >= MaxTime)
        {
            EndGame.finalScore = ScoreText.text;
            EndPanel.SetActive(true);
        }
        else
        {
            TimeText.text = TimeOutput + (Mathf.RoundToInt(MaxTime - SceneTime)).ToString();
        }
    }
}
