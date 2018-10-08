using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleARMode : MonoBehaviour {

    public Canvas ARCanvas;
    public static bool isARActive;
    
    // Use this for initialization
	void Awake () {
        HideARCanvas();
        isARActive = false;
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void ShowARCanvas()
    {
        if (ARCanvas != null)
        {
            ARCanvas.gameObject.SetActive(true);
            isARActive = true;
        }
    }

    public void HideARCanvas()
    {
        if (ARCanvas != null)
        {
            ARCanvas.gameObject.SetActive(false);
            isARActive = false;
        }
    }

}
