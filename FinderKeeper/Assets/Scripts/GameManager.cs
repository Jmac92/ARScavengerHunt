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

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            DontDestroyOnLoad(_instance);

            return _instance;
        }
    }
}
