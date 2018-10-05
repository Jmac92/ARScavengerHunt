using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public Image rotationIcon;
    public Sprite locked;
    public Sprite unlocked;
    private bool _unlock = true;

	// Use this for initialization
	void Start () {
        rotationIcon.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Lock()
    {
        _unlock = !_unlock;
        if (_unlock == false)
        {
            rotationIcon.overrideSprite = locked;
        }
        else
        {
            rotationIcon.overrideSprite = unlocked;
        }
    }
}
