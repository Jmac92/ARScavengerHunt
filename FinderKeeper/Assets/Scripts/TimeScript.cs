using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {
    public Text TimeText;
    public Text ItemText;
    public float MaxTime = 300;
    public float SceneTime = 0;
    public GameObject EndPanel;
    private bool timeStop = false;

    private void Awake()
    {
    }

    // Use this for initialization
    protected void Start () {
		EndPanel.SetActive(false);
        timeStop = false;
        Debug.Log("MANAGER: " + (GameManager.instance != null));
        GameManager.instance.maxTime = MaxTime;
        GameManager.instance.sceneTime = SceneTime;
        GameManager.instance.hasTimerStarted = true;
	}
	
	// Update is called once per frame
	protected void Update () {
        SceneTime = GameManager.instance.sceneTime;

        string min = Mathf.Floor(SceneTime / 60).ToString("00");
        string sec = Mathf.Floor(SceneTime % 60).ToString("00");
      
        
        if (SceneTime >= MaxTime)
        {
            timeStop = true;
            End();
        }

        if (ItemText.text == "Items = 5/5")
        {
            End();
        }
        else
        {
            TimeText.text = min + ":" + sec;
        }
    }

    void End()
    {
        EndGame.finalScore = ItemText.text;
        EndPanel.SetActive(true);
    }
}
