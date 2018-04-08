using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public string nextLevel = "SnowTown";
	public static int levelToUnlock = 2;

	public SceneFader sceneFader;

    private void Start()
    {
        InvokeRepeating("UpdateNew", 0f, 0.05f);

    }

    public void Continue ()
	{
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo(nextLevel);

        Weather.sceneSwitch = true;
	}

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
        Weather.sceneSwitch = true;
	}

    private void UpdateNew()
    {
        levelToUnlock = GameManager.sceneIndex + 1;
        
        
        
    }

}
