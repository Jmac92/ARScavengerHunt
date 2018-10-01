using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float maxTime = 300;
    public float sceneTime = 0;
    public bool hasTimerStarted = false;

    private static GameManager _instance;

    // Use this for initialization
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        PlayerPrefs.DeleteKey("maxTime");
        PlayerPrefs.DeleteKey("sceneTime");
        PlayerPrefs.DeleteKey("hasTimerStarted");

        PlayerPrefs.SetFloat("maxTime", maxTime);
        sceneTime = PlayerPrefs.GetFloat("sceneTime");


        DontDestroyOnLoad(gameObject);

        
    }

    private void Update()
    {
        //Keep time once the player has entered the map scene
        if (Convert.ToBoolean(PlayerPrefs.GetInt("hasTimerStarted")))
        {
            sceneTime += Time.deltaTime;
            PlayerPrefs.SetFloat("sceneTime", sceneTime);
        }
        else
        {
            sceneTime = 0;
            PlayerPrefs.SetFloat("sceneTime", sceneTime);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public void ResetTimer() {
        PlayerPrefs.SetFloat("sceneTime", 0);
        PlayerPrefs.SetInt("hasTimerStarted", 0);
    }
}
