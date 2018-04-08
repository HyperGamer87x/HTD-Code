using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceDrop : MonoBehaviour {

    //public Animator _anim;
    //public string MyTrigger;

    public GameObject fence;
    public GameObject fenceAnimated;
    public GameObject enemyEmpty;

    

    private void Start()
    {
        fence.SetActive(true);
        fenceAnimated.SetActive(false);

        InvokeRepeating("UpdateNew", 0f, 0.05f);

    }

    private void UpdateNew()
    {
        //if (Turret.enemyPosition (0, 0, 0)) 
        

        //if (enemyEmpty.transform.position = fence.transform.position)
        //{
         //   Debug.Log("!");
          //  fence.SetActive(false);
         //   fenceAnimated.SetActive(true);
        //}
    }

    

}


