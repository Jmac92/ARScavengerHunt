using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour {

    public Text ScoreText;
    public GameObject CollectionPanel = null;

    private bool _isCollectionPanelOpen = false;
    private int _score = 0;
    private string _scoreOutput = "Score = ";

    public void ToggleCollectionPanel() {
        _isCollectionPanelOpen = !_isCollectionPanelOpen;

        SetCollectionPanelVisibility();
    }

    private void SetCollectionPanelVisibility() {
        if (CollectionPanel != null) {
            CollectionPanel.SetActive(_isCollectionPanelOpen);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ToggleCollectionPanel();
        if (collision.gameObject.tag == "High")

        {
            _score += 10;
            ScoreText.text = _scoreOutput + _score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Mid")

        {
            _score += 5;
            ScoreText.text = _scoreOutput + _score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Low")

        {
            _score += 2;
            ScoreText.text = _scoreOutput + _score;
            Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		CollectionPanel.SetActive(false);
        _score = 0;
        ScoreText.text = _scoreOutput + _score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
