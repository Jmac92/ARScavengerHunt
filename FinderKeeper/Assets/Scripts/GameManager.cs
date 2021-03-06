﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float maxTime = 300;
    public float sceneTime = 0;
    public bool hasTimerStarted = false;

    private string _currentItemId;

    private List<Collectible> _collectedItems;
    private List<Collectible> _courseItems;

    private static GameManager _instance;

    private int _timeClosed;
    private int _timeDifference;

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
            sceneTime += Time.unscaledDeltaTime;
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

    public string CurrentItemId
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

    public Collectible GetCollectedItem(string id)
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

    public void RemoveCollectedItem(string id)
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

    public bool HasItemBeenCollected(string id)
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

    public Collectible GetCourseItem(string id)
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

    public void UpdateCourseItem(string id, Collectible newItem)
    {
        Collectible oldItem = GetCourseItem(id);
        oldItem.IsCollected = newItem.IsCollected;
        oldItem.IsVisibleOnMap = newItem.IsVisibleOnMap;
        oldItem.LatLong = newItem.LatLong;
    }

    public void Reset()
    {
        ClearCollectedItems();
        ResetTimer();
    }
}
