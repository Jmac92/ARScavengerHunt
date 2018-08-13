using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject HighScoreCube;
    public GameObject MidScoreCube;
    public GameObject LowScoreCube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Random.Range(0,50000) < 10)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-10.0f,10.0f),
                this.transform.position.y,
                this.transform.position.z + Random.Range(-10.0f, 10.0f));

            Instantiate(HighScoreCube, pos, Quaternion.identity);
        }
        if (Random.Range(0, 25000) < 10)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-7.0f, 7.0f),
                this.transform.position.y,
                this.transform.position.z + Random.Range(-7.0f, 7.0f));

            Instantiate(MidScoreCube, pos, Quaternion.identity);
        }
        if (Random.Range(0, 10000) < 10)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f),
                this.transform.position.y,
                this.transform.position.z + Random.Range(-4.0f, 4.0f));

            Instantiate(LowScoreCube, pos, Quaternion.identity);
        }
    }
}
