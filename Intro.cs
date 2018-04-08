using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public SceneFader sceneFader;
    public string warning;

    void Start ()
    {
        StartCoroutine("PlayIntro");
	}

    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(13f);
        sceneFader.FadeTo(warning);
    }
	
}
