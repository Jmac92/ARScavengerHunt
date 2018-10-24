using System;
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

        Vector3 playerPos = player.transform.localPosition;
        Vector3 objectPos = gameObject.transform.localPosition;
        Vector3 difference = new Vector3(objectPos.x - playerPos.x, 0, objectPos.z - playerPos.z);

        float distance = difference.magnitude;

        if (!ToggleARMode.isARActive && distance < 2.5f)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            Collectible item = GameManager.Instance.GetCollectedItem(gameObject.name);
            if (item != null)
                item.IsVisibleOnMap = true;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);

            Collectible item = GameManager.Instance.GetCollectedItem(gameObject.name);
            if (item != null)
                item.IsVisibleOnMap = false;
        }
    }
    
}
