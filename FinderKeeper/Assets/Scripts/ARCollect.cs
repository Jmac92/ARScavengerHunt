using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCollect : MonoBehaviour {

    public ParticleSystem confetti;
    private GameObject _collectedItem = null;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
    }

    private void CollectItem(GameObject item) {
        item.GetComponent<MeshRenderer>().enabled = false;
        confetti.Play();
    }
}
