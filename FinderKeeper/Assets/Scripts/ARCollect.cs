using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARCollect : MonoBehaviour {

    public ParticleSystem confetti;
    private GameObject _collectedItem = null;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (_collectedItem != null) {
            confetti.transform.parent = transform;
        }

        //touch input - use this block for the app
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.tag == "Low")
                {
                    _collectedItem = raycastHit.transform.gameObject;
                    CollectItem(_collectedItem);
                }
            }
        }

        //mouse input -use this block for testing
        //if (Input.GetMouseButtonUp(0))
        //{
        //    Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit raycastHit;
        //    if (Physics.Raycast(raycast, out raycastHit))
        //    {
        //        if (raycastHit.collider.tag == "Low")
        //        {
        //            _collectedItem = raycastHit.transform.gameObject;
        //            CollectItem(_collectedItem);
        //        }
        //    }
        //}
    }

    private void CollectItem(GameObject item) {
        item.GetComponent<MeshRenderer>().enabled = false;
        SoundManager.Instance.PlaySound("PartyPopper");

        confetti.Play();

        Invoke("ReturnToMap", 3);
    }

    private void ReturnToMap()
    {
        SceneManager.LoadScene("map");
    }
}
