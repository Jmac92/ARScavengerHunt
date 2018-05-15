using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeScript : MonoBehaviour {
    public Text TimeText;
    public float MaxTime = 300;
    public float SceneTime = 0;
    private string TimeOutput = "REMAINING TIME : ";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SceneTime += Time.deltaTime;
        TimeText.text = TimeOutput + (Mathf.RoundToInt(MaxTime - SceneTime)).ToString();

    }
}
