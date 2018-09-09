using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveObject : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Debug.Log("Don't Destroy", gameObject);
        DontDestroyChildOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void DontDestroyChildOnLoad(GameObject child)
    {
        Transform parentTransform = child.transform;

        // If this object doesn't have a parent then its the root transform.
        while (parentTransform.parent != null)
        {
            // Keep going up the chain.
            parentTransform = parentTransform.parent;
        }
        GameObject.DontDestroyOnLoad(parentTransform.gameObject);
    }
}
