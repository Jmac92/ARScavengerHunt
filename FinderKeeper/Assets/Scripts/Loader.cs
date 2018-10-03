using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;

    public GameObject soundManager;

    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.Instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameManager);

        //Do the same for the soundManager
        if (SoundManager.Instance == null)

            //Instantiate soundManager prefab
            Instantiate(soundManager);
    }
}
