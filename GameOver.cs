using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	public void Retry ()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        WaveSpawner.resetWave = true;
    }

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
        Weather.sceneSwitch = true;
        WaveSpawner.resetWave = true;
    }

}
