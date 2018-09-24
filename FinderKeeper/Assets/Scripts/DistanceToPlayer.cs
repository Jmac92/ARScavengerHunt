using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToPlayer : MonoBehaviour {
    // Use this for initialization

	void Start () {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = (gameObject.transform.position - player.transform.position).magnitude;
        if (!ToggleARMode.isARActive && dist < 15.0f)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        //Debug.Log(string.Format("Distance between {0} and {1} is: {2}",gameObject, player, dist));
    }
    
}
