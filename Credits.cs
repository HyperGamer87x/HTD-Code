using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public AudioSource creditMusic;

    public Scrollbar creditRoll;
    public bool isRolling;
    public bool startCredits;

    public SceneFader sceneFader;
    public string mainMenu;

    private void Start()
    {
        creditMusic.Play();
        startCredits = false;
        isRolling = true;
        creditRoll.value = 1f;
        StartCoroutine("StartCredits");
        InvokeRepeating("RollCredits", 0f, 0.0002f);
    }

    void RollCredits()
    {
        if (startCredits == true)
        {
            if (isRolling == true)
            {
                if (creditRoll.value > 0.02f)
                {
                    creditRoll.value = creditRoll.value - 0.000048f;
                }
                if (creditRoll.value == 0.02f || creditRoll.value < 0.02f)
                {
                    StartCoroutine("FinishCredits");
                    isRolling = false;
                }
            }
            else
            {
                return;
            }
        } else
        {
            return;
        }
        
    }

    IEnumerator FinishCredits()
    {
        yield return new WaitForSeconds(6f);
        sceneFader.FadeTo(mainMenu);
    }

    IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(5.35f);
        startCredits = true;
    }
}
