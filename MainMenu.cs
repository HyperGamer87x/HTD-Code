using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelSelect;
    public string extras;

    public SceneFader sceneFader;

	public void Play ()
	{
        Debug.Log("Play...");
        sceneFader.FadeTo(levelSelect);
    }

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

    public void Extras ()
    {
        sceneFader.FadeTo(extras);
    }

    private void Start()
    {
        GameManager.weatherConditions = true;
        GameManager.hints = true;
    }

}
