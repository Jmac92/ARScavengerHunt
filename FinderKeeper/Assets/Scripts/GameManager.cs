using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public float maxTime = 300;
    public float sceneTime = 0;
    public bool hasTimerStarted = false;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)

        Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    //public float MaxTime {
    //    get { return _maxTime; }
    //    set { _maxTime = value; }
    //}

    //public float SceneTime {
    //    get { return _sceneTime; }
    //    set { _sceneTime = value; }
    //}

    //public bool HasTimerStarted {
    //    get { return _hasTimerStarted; }
    //    set { _hasTimerStarted = value; }
    //}

    private void Update()
    {
        if (hasTimerStarted)
        {
            sceneTime += Time.deltaTime;
        }
    }
}
