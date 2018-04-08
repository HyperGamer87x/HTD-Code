using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour {

    public SceneFader sceneFader;
    public string menu;

    void Start()
    {
        StartCoroutine("PlayWarning");
    }

    IEnumerator PlayWarning()
    {
        yield return new WaitForSeconds(8f);
        sceneFader.FadeTo(menu);
    }
}
