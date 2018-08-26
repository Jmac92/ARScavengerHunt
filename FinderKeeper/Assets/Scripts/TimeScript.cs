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
            End();
        }

        if (ItemText.text == "Items = 5/5")
        {
            End();
        }
        else
        {
            TimeText.text = TimeOutput + (Mathf.RoundToInt(MaxTime - SceneTime)).ToString();
        }
    }

    void End()
    {
        EndGame.finalScore = ItemText.text;
        EndPanel.SetActive(true);
    }
}
