using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNodes : MonoBehaviour {

    public static bool deselectNow;

    public static Vector3 targetPos;
    public Vector3 offset;

    public bool onMouseDown;

    void Start()
     {
        deselectNow = false;

        InvokeRepeating("IsPressedFunction", 0f, 0.6f);

    }

    private void Update()
    {

    }

    void IsPressedFunction()
    {
        StartCoroutine(IsPressed());
    }


    void OnMouseExit()
    {
        Turret.showTarget = false;
    }

    private void OnMouseEnter()
    {
        if (Node.playerSetTarget == true)
        {
            offset.y = 2f;

            targetPos = this.transform.position + offset;

            Node.cancelBuy = true;

            Turret.showTarget = true;
            //Turret.targetGO.transform.position = targetPos;

        }
    }

    private void OnMouseDown()
    {
        if (onMouseDown == true)
        {
            if (Node.playerSetTarget == true)
            {
                Node.playerSetTarget = false;

                onMouseDown = false;
            }
        }
        
    }

    IEnumerator IsPressed()
    {
        
        yield return new WaitForSeconds(0.5f);
        if (Node.playerSetTarget == true)
        {
            onMouseDown = true;

        }
    }

}
