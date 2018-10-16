using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TimeScript : MonoBehaviour {
    public Text TimeText;
    public Text ItemText;
    public float MaxTime = 300;
    public float SceneTime = 0;
    public GameObject EndPanel;
    private bool timeStop = false;
    

    // Use this for initialization
    protected void Start () {
		EndPanel.SetActive(false);
        timeStop = false;
        MaxTime = PlayerPrefs.GetFloat("maxTime");
        PlayerPrefs.SetInt("hasTimerStarted", 1);
	}
	
	// Update is called once per frame
	private void Update () {
        bool hasTimerStarted = Convert.ToBoolean(PlayerPrefs.GetInt("hasTimerStarted"));
        SceneTime = PlayerPrefs.GetFloat("sceneTime");

        string min = Mathf.Floor(Mathf.Round(MaxTime - SceneTime) / 60).ToString("00");
        string sec = Mathf.Floor(Mathf.Round(MaxTime - SceneTime) % 60).ToString("00");

        if (SceneTime >= MaxTime || ItemText.text == "5/5")
        {
            timeStop = true;
            End();
        }

        if (hasTimerStarted && !timeStop)
            TimeText.text = min + ":" + sec;
        else
            TimeText.text = "00:00";
    }

    void End()
    {
        if (!Convert.ToBoolean(PlayerPrefs.GetInt("hasTimerStarted"))) {
            PlayerPrefs.SetFloat("sceneTime", 300);
        }
        Transitions.finalScore = ItemText.text;
        EndPanel.SetActive(true);
    }
}
