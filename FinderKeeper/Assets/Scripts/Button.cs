using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public Image icon;
    public Sprite sprite01;
    public Sprite sprite02;
    public bool active = true;

	// Use this for initialization
	void Start () {
        icon.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Lock()
    {
        active = !active;
        if (active == false)
        {
            icon.overrideSprite = sprite01;
        }
        else
        {
            icon.overrideSprite = sprite02;
        }
    }
}
