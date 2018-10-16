using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
    public Animator fadeIn;
    public Animator fadeOut;

    void Start()
    {
        fadeIn.SetTrigger("FadeIn");

    }
    public void LoadScene(string sceneName)
	{
        fadeOut.SetTrigger("FadeOut");
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
        
        StartCoroutine(LoadNextScene(sceneName)); //load a scene
	}
    public IEnumerator LoadNextScene(string name)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);
    }
}
