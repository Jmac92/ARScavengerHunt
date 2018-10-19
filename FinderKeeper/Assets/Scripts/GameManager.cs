using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float maxTime = 300;
    public float sceneTime = 0;
    public bool hasTimerStarted = false;

    private int _currentItemId;

    private List<Collectible> _collectedItems;
    private List<Collectible> _courseItems;

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

        _collectedItems = new List<Collectible>();
        _courseItems = new List<Collectible>();


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

        if (sceneTime >= maxTime)
            StopTimer();
    }

    void OnApplicationPause(bool paused)
    {
        var timeWhenClosed = 0;
        if (paused) {
            timeWhenClosed = DateTime.UtcNow.Second;
        } else {
            var timeDifference = DateTime.UtcNow.Second - timeWhenClosed;
            sceneTime = sceneTime + (timeDifference);
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

    public int CurrentItemId
    {
        get
        {
            return _currentItemId;
        }

        set
        {
            _currentItemId = value;
        }
    }

    public void ResetTimer() {
        PlayerPrefs.SetInt("hasTimerStarted", 0);
        PlayerPrefs.SetFloat("sceneTime", 0);
    }

    public void StopTimer()
    {
        PlayerPrefs.SetInt("hasTimerStarted", 0);
    }

    public List<Collectible> GetCollectedItems()
    {
        return _collectedItems;
    }

    public Collectible GetCollectedItem(int id)
    {
        foreach (Collectible item in _collectedItems) {
            if (item.Id == id)
                return item;
        }
        return null;
    }

    public void AddCollectedItem(Collectible item)
    {
        if(!_collectedItems.Contains(item))
            _collectedItems.Add(item);
    }

    public void RemoveCollectedItem(int id)
    {
        foreach (Collectible item in _collectedItems)
        {
            if (item.Id == id)
                _collectedItems.Remove(item);
        }
    }

    public void ClearCollectedItems()
    {
        _collectedItems.Clear();
    }

    public bool HasItemBeenCollected(int id)
    {
        foreach (Collectible item in _collectedItems)
        {
            if (item.Id == id)
                return true;
        }
        return false;
    }


    public List<Collectible> GetCourseItems()
    {
        return _courseItems;
    }

    public Collectible GetCourseItem(int id)
    {
        foreach (Collectible item in _courseItems)
        {
            if (item.Id == id)
                return item;
        }
        return null;
    }

    public void AddCourseItem(Collectible item)
    {
        bool idFound = false;
        foreach(Collectible itm in _courseItems)
        {
            if (item.Id == itm.Id)
            {
                idFound = true;
                continue;
            }
        }

        if (!idFound)
            _courseItems.Add(item);
    }
}
