using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenCloseMenu : MonoBehaviour {

    public GameObject menuPanel;

    // Use this for initialization

    void Start()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }
    // Update is called once per frame



    public void OpenAndCloseMenu()
    {
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }
}
