using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
	public void LoadScene(string sceneName)
	{
		if (sceneName == null)
			Debug.Log("<color=orange>"+gameObject.name+": No Scene Name Was given for LoadScene function!</color>");

        if (SceneManager.GetActiveScene().name == "Ready" && !!GameManager.Instance)
        {
            //GameManager.Instance.ResetTimer();
            PlayerPrefs.SetFloat("sceneTime", 0);
            PlayerPrefs.SetInt("hasTimerStarted", 0);
        }

        if (SceneManager.GetActiveScene().name == "ARMode" && !!SoundManager.Instance)
            SoundManager.Instance.StopAll();

		SceneManager.LoadScene(sceneName); //load a scene
	}
}
