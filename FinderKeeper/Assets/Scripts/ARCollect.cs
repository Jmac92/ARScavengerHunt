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
        SoundManager.Instance.PlaySound("Chime", 1.0f, true);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, transform.position.y + 1, 0, Space.Self);

        if (_collectedItem != null) {
            confetti.transform.parent = transform;
        }

        //touch input - use this block for the app
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        //{
        //    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
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

        //mouse input -use this block for testing
        if (Input.GetMouseButtonUp(0))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
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
    }

    private void CollectItem(GameObject item) {
        item.GetComponent<MeshRenderer>().enabled = false;
        SoundManager.Instance.PlaySound("PartyPopper");

        SoundManager.Instance.StopSound("Chime");

        confetti.Play();

        int currentItem = GameManager.Instance.CurrentItemId;
        Collectible collectible = GameManager.Instance.GetCourseItem(currentItem);
        GameManager.Instance.AddCollectedItem(collectible);

        Invoke("ReturnToMap", 3);
    }

    private void ReturnToMap()
    {
        SoundManager.Instance.StopAll();
        SceneManager.LoadScene("map");
    }
}
