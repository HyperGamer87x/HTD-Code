using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTarget : MonoBehaviour {

    public GameObject targetSelection;
    public GameObject cameraSelection;
    public static bool isTargetSelectionVisible = false;
    public Button firstTargetBtn;
    public Button lastTargetBtn;
    public Button closeTargetBtn;
    public Button strongTargetBtn;
    public static int targetNumber;

    void Start()
    {
        targetSelection.SetActive(false);
        firstTargetBtn.interactable = true;
        lastTargetBtn.interactable = true;
        closeTargetBtn.interactable = false;
        strongTargetBtn.interactable = true;
        targetNumber = 3;
    }

    public void ChangeTargetButtonSelected()
    {
        if (isTargetSelectionVisible == false)
        {
            targetSelection.SetActive(true);
            isTargetSelectionVisible = true;

            if (Cameras.isCameraSelectionVisible == true)
            {
                Cameras.isCameraSelectionVisible = false;
                cameraSelection.SetActive(false);
            }
            return;
        }
        if (isTargetSelectionVisible == true)
        {
            targetSelection.SetActive(false);
            isTargetSelectionVisible = false;
            return;
        }
    }

    public void FirstButtonSelected ()
    {
        targetNumber = 1;
        return;
    }
    public void LastButtonSelected ()
    {
        targetNumber = 2;
        return;
    }
    public void CloseButtonSelected ()
    {
        targetNumber = 3;
        return;
    }
    public void StrongButtonSelected ()
    {
        targetNumber = 4;
        return;
    }

}
