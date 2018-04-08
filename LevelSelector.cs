using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelSelector : MonoBehaviour {

	public SceneFader sceneFader;

    public string menu;
    public string backyard;
    public string snowtown;
    public string building;
    public string desert;
    public string bonfire;

    public Button[] levelButtons;

    public int randomLevelGenerator;

    //DIFFICULTY
    public static int difficulty;

    public GameObject difficulty1on;
    public GameObject difficulty1off;
    public GameObject difficulty2on;
    public GameObject difficulty2off;
    public GameObject difficulty3on;
    public GameObject difficulty3off;
    public GameObject difficulty4on;
    public GameObject difficulty4off;
    public GameObject difficulty5on;
    public GameObject difficulty5off;

    public GameObject information;

    void Start ()
	{
        //int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        //for (int i = 0; i < levelButtons.Length; i++)
        //{
        //	if (i + 1 > levelReached)
        //		levelButtons[i].interactable = false;
        //}
        information.SetActive(false);
        difficulty = 3;

        InvokeRepeating("UpdateLate", 0f, 0.1f);
    }

    public void Select (string levelName)
	{
		sceneFader.FadeTo(levelName);
        Weather.sceneSwitch = true;

    }

    public void RandomLevel ()
    {
        randomLevelGenerator = Random.Range(1, 6);

        if (randomLevelGenerator == 1)
        {
            sceneFader.FadeTo(backyard);
        }
        if (randomLevelGenerator == 2)
        {
            sceneFader.FadeTo(snowtown);
        }
        if (randomLevelGenerator == 3)
        {
            sceneFader.FadeTo(building);
        }
        if (randomLevelGenerator == 4)
        {
            sceneFader.FadeTo(desert);
        }
        if (randomLevelGenerator == 5)
        {
            sceneFader.FadeTo(bonfire);
        }

        Weather.sceneSwitch = true;
    }

    public void Menu()
    {
        sceneFader.FadeTo(menu);
    }

    public void UpdateLate()
    {
        if (difficulty == 1)
        {
            difficulty1on.SetActive(true);
            difficulty1off.SetActive(false);
            difficulty2on.SetActive(false);
            difficulty2off.SetActive(true);
            difficulty3on.SetActive(false);
            difficulty3off.SetActive(true);
            difficulty4on.SetActive(false);
            difficulty4off.SetActive(true);
            difficulty5on.SetActive(false);
            difficulty5off.SetActive(true);
        }
        if (difficulty == 2)
        {
            difficulty1on.SetActive(false);
            difficulty1off.SetActive(true);
            difficulty2on.SetActive(true);
            difficulty2off.SetActive(false);
            difficulty3on.SetActive(false);
            difficulty3off.SetActive(true);
            difficulty4on.SetActive(false);
            difficulty4off.SetActive(true);
            difficulty5on.SetActive(false);
            difficulty5off.SetActive(true);
        }
        if (difficulty == 3)
        {
            difficulty1on.SetActive(false);
            difficulty1off.SetActive(true);
            difficulty2on.SetActive(false);
            difficulty2off.SetActive(true);
            difficulty3on.SetActive(true);
            difficulty3off.SetActive(false);
            difficulty4on.SetActive(false);
            difficulty4off.SetActive(true);
            difficulty5on.SetActive(false);
            difficulty5off.SetActive(true);
        }
        if (difficulty == 4)
        {
            difficulty1on.SetActive(false);
            difficulty1off.SetActive(true);
            difficulty2on.SetActive(false);
            difficulty2off.SetActive(true);
            difficulty3on.SetActive(false);
            difficulty3off.SetActive(true);
            difficulty4on.SetActive(true);
            difficulty4off.SetActive(false);
            difficulty5on.SetActive(false);
            difficulty5off.SetActive(true);
        }
        if (difficulty == 5)
        {
            difficulty1on.SetActive(false);
            difficulty1off.SetActive(true);
            difficulty2on.SetActive(false);
            difficulty2off.SetActive(true);
            difficulty3on.SetActive(false);
            difficulty3off.SetActive(true);
            difficulty4on.SetActive(false);
            difficulty4off.SetActive(true);
            difficulty5on.SetActive(true);
            difficulty5off.SetActive(false);
        }
    }

    public void DifficultyLevel1 ()
    {
        difficulty = 1;
    }

    public void DifficultyLevel2 ()
    {
        difficulty = 2;
    }

    public void DifficultyLevel3 ()
    {
        difficulty = 3;
    }

    public void DifficultyLevel4 ()
    {
        difficulty = 4;
    }

    public void DifficultyLevel5 ()
    {
        difficulty = 5;
    }

    public void ShowInformation ()
    {
        information.SetActive(true);
    }

    public void HideInformation ()
    {
        information.SetActive(false);
    }


}
