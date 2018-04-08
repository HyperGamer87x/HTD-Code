using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour {

    public GameObject cameraSelection;
    public GameObject cameraSelection2;
    public GameObject targetSelection;
    public Button changeCamera;
    public static bool isCameraSelectionVisible = false;

    public Button slantedCameraBtn;
    public Button originalCameraBtn;
    public Button turretCameraBtn;

    public GameObject overlay;
    public bool billActive;
    public bool nodeUICamActive;

    public GameObject slantedCamera;
    public GameObject originalCamera;
    public GameObject turretCamera;
    public GameObject billCamera;
    public GameObject spareCamera;
    public GameObject nodeUICamera;
    public static int cameraNumber;

    public GameObject turretPrefab;
    public GameObject launcherPrefab;
    public GameObject beamerPrefab;
    public GameObject dartlingPrefab;
    public GameObject blasterPrefab;
    public GameObject windPrefab;
    public GameObject turretPrefabU1;
    public GameObject launcherPrefabU1;
    public GameObject beamerPrefabU1;
    public GameObject dartlingPrefabU1;
    public GameObject blasterPrefabU1;
    public GameObject windPrefabU1;
    public GameObject turretPrefabU2;
    public GameObject launcherPrefabU2;
    public GameObject beamerPrefabU2;
    public GameObject dartlingPrefabU2;
    public GameObject windPrefabU2;
    public GameObject blasterPrefabU2;
    public GameObject turretPrefabU3;
    public GameObject launcherPrefabU3;
    public GameObject beamerPrefabU3;
    public GameObject dartlingPrefabU3;
    public GameObject blasterPrefabU3;
    public GameObject windPrefabU3;

    public Vector3 turretPositionOffset;
    public Vector3 launcherPositionOffset;
    public Vector3 beamerPositionOffset;
    public Vector3 dartlingPositionOffset;
    public Vector3 blasterPositionOffset;
    public Vector3 windPositionOffset;
    public Vector3 turretPositionOffsetU1;
    public Vector3 launcherPositionOffsetU1;
    public Vector3 beamerPositionOffsetU1;
    public Vector3 dartlingPositionOffsetU1;
    public Vector3 blasterPositionOffsetU1;
    public Vector3 windPositionOffsetU1;
    public Vector3 turretPositionOffsetU2;
    public Vector3 launcherPositionOffsetU2;
    public Vector3 beamerPositionOffsetU2;
    public Vector3 dartlingPositionOffsetU2;
    public Vector3 blasterPositionOffsetU2;
    public Vector3 windPositionOffsetU2;
    public Vector3 turretPositionOffsetU3;
    public Vector3 launcherPositionOffsetU3;
    public Vector3 beamerPositionOffsetU3;
    public Vector3 dartlingPositionOffsetU3;
    public Vector3 blasterPositionOffsetU3;
    public Vector3 windPositionOffsetU3;
    public Vector3 rotation;

    public static Vector3 turretSelectedNodePosition;
    public static Vector3 launcherSelectedNodePosition;
    public static Vector3 beamerSelectedNodePosition;
    public static Vector3 dartlingSelectedNodePosition;
    public static Vector3 blasterSelectedNodePosition;
    public static Vector3 windSelectedNodePosition;
    public static Vector3 turretSelectedNodePositionU1;
    public static Vector3 launcherSelectedNodePositionU1;
    public static Vector3 beamerSelectedNodePositionU1;
    public static Vector3 dartlingSelectedNodePositionU1;
    public static Vector3 blasterSelectedNodePositionU1;
    public static Vector3 windSelectedNodePositionU1;
    public static Vector3 turretSelectedNodePositionU2;
    public static Vector3 launcherSelectedNodePositionU2;
    public static Vector3 beamerSelectedNodePositionU2;
    public static Vector3 dartlingSelectedNodePositionU2;
    public static Vector3 blasterSelectedNodePositionU2;
    public static Vector3 windSelectedNodePositionU2;
    public static Vector3 turretSelectedNodePositionU3;
    public static Vector3 launcherSelectedNodePositionU3;
    public static Vector3 beamerSelectedNodePositionU3;
    public static Vector3 dartlingSelectedNodePositionU3;
    public static Vector3 blasterSelectedNodePositionU3;
    public static Vector3 windSelectedNodePositionU3;
    public static Quaternion selectedNodeRotation;

    public GameObject shopCanvas;
    public GameObject livesTopCanvas;

    public GameObject attention;

    public static bool tipsShown;
    public GameObject tipsGO;

    [Header("TurretCAM")]
    public Vector3 turretPosition;
    public static float range;

    public GameObject warningGO;
    public Text warningText;

    void Start () {
        cameraSelection.SetActive(false);
        cameraSelection2.SetActive(false);
        slantedCameraBtn.interactable = false;
        originalCameraBtn.interactable = true;
        turretCameraBtn.interactable = true;
        overlay.SetActive(false);
        slantedCamera.SetActive(false);
        originalCamera.SetActive(false);
        turretCamera.SetActive(false);
        billCamera.SetActive(true);
        spareCamera.SetActive(false);
        cameraNumber = 1;
        shopCanvas.SetActive(true);
        billActive = true;
        nodeUICamActive = false;

        if (GameManager.applyHints == true)
        {
            tipsShown = true;
            tipsGO.SetActive(true);
        }
        else
        {
            tipsShown = false;
            tipsGO.SetActive(false);
        }

        
        warningGO.SetActive(false);

    }

    public void ChangeCameraButtonSelected ()
    {
        if (GameManager.sceneIndex != 3)
        {
            if (isCameraSelectionVisible == false)
            {
                cameraSelection.SetActive(true);
                cameraSelection2.SetActive(false);
                isCameraSelectionVisible = true;

                if (ChangeTarget.isTargetSelectionVisible == true)
                {
                    ChangeTarget.isTargetSelectionVisible = false;
                    targetSelection.SetActive(false);
                }
                return;
            }
            if (isCameraSelectionVisible == true)
            {
                cameraSelection.SetActive(false);
                isCameraSelectionVisible = false;
                return;
            }
        }
        if (GameManager.sceneIndex == 3)
        {
            if (isCameraSelectionVisible == false)
            {
                cameraSelection2.SetActive(true);
                cameraSelection.SetActive(false);
                isCameraSelectionVisible = true;

                if (ChangeTarget.isTargetSelectionVisible == true)
                {
                    ChangeTarget.isTargetSelectionVisible = false;
                    targetSelection.SetActive(false);
                }
                return;
            }
            if (isCameraSelectionVisible == true)
            {
                cameraSelection2.SetActive(false);
                isCameraSelectionVisible = false;
                return;
            }
        }
        
    }

    public void SlantedCamera ()
    {
        slantedCamera.SetActive(true);
        originalCamera.SetActive(false);
        turretCamera.SetActive(false);
        billCamera.SetActive(false);
        spareCamera.SetActive(false);
        nodeUICamera.SetActive(false);
        overlay.SetActive(true);
        slantedCameraBtn.interactable = false;
        originalCameraBtn.interactable = true;
        turretCameraBtn.interactable = true;
        cameraNumber = 1;
        shopCanvas.SetActive(true);
        livesTopCanvas.SetActive(true);
        billActive = true;
        nodeUICamActive = false;
        return;
    }

    public void OriginalCamera()
    {
        slantedCamera.SetActive(false);
        originalCamera.SetActive(true);
        turretCamera.SetActive(false);
        billCamera.SetActive(false);
        spareCamera.SetActive(false);
        nodeUICamera.SetActive(false);
        slantedCameraBtn.interactable = true;
        originalCameraBtn.interactable = false;
        turretCameraBtn.interactable = true;
        cameraNumber = 2;
        shopCanvas.SetActive(true);
        livesTopCanvas.SetActive(true);
    }

    public void TurretCamera()
    {
        slantedCamera.SetActive(false);
        originalCamera.SetActive(false);
        turretCamera.SetActive(true);
        billCamera.SetActive(false);
        spareCamera.SetActive(false);
        nodeUICamera.SetActive(false);
        slantedCameraBtn.interactable = true;
        originalCameraBtn.interactable = true;
        turretCameraBtn.interactable = false;
        SelectedTurretCAM();
        cameraNumber = 3;
        shopCanvas.SetActive(false);
        livesTopCanvas.SetActive(false);
    }

    public void BillCamera ()
    {
        slantedCamera.SetActive(false);
        originalCamera.SetActive(false);
        turretCamera.SetActive(false);
        billCamera.SetActive(true);
        nodeUICamera.SetActive(false);
        spareCamera.SetActive(false);
        cameraNumber = 4;
        overlay.SetActive(false);
        billActive = false;
        
    }

    public void SpareCamera()
    {
        slantedCamera.SetActive(false);
        originalCamera.SetActive(false);
        turretCamera.SetActive(false);
        billCamera.SetActive(false);
        spareCamera.SetActive(true);
        nodeUICamera.SetActive(false);
        slantedCameraBtn.interactable = true;
        originalCameraBtn.interactable = false;
        turretCameraBtn.interactable = true;
        cameraNumber = 5;
        shopCanvas.SetActive(true);
        livesTopCanvas.SetActive(true);
    }

    public void NodeUICamera()
    {
        slantedCamera.SetActive(false);
        originalCamera.SetActive(false);
        turretCamera.SetActive(false);
        billCamera.SetActive(false);
        spareCamera.SetActive(false);
        nodeUICamera.SetActive(true);
        slantedCameraBtn.interactable = true;
        originalCameraBtn.interactable = false;
        turretCameraBtn.interactable = true;
        cameraNumber = 6;
        shopCanvas.SetActive(false);
        livesTopCanvas.SetActive(true);
        nodeUICamActive = true;
    }

    void SelectedTurretCAM()
    {
        //Non-Upgraded

        if (Node.upgradeNO == 0)
        {
            if (NodeUI.target.turretBlueprint.prefab == turretPrefab)
            {
                range = 16f;

                turretSelectedNodePosition = BuildManager.selectedNode.transform.position + turretPositionOffset;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = turretSelectedNodePosition;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == launcherPrefab)
            {
                range = 26f;

                launcherSelectedNodePosition = BuildManager.selectedNode.transform.position + launcherPositionOffset;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = launcherSelectedNodePosition;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == beamerPrefab)
            {
                range = 21f;

                beamerSelectedNodePosition = BuildManager.selectedNode.transform.position + beamerPositionOffset;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = beamerSelectedNodePosition;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == dartlingPrefab)
            {
                range = 21f;

                dartlingSelectedNodePosition = BuildManager.selectedNode.transform.position + dartlingPositionOffset;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = dartlingSelectedNodePosition;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == blasterPrefab)
            {
                range = 16f;

                blasterSelectedNodePosition = BuildManager.selectedNode.transform.position + blasterPositionOffset;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = blasterSelectedNodePosition;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == windPrefab)
            {
                range = 16f;

                windSelectedNodePosition = BuildManager.selectedNode.transform.position + windPositionOffset;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = windSelectedNodePosition;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
        }

        //Upgrade 1

        if (Node.upgradeNO == 1)
        {
            if (NodeUI.target.turretBlueprint.upgradedPrefab1 == turretPrefabU1)
            {
                range = 21f;

                turretSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + turretPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = turretSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab1 == launcherPrefabU1)
            {
                range = 36f;

                launcherSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + launcherPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = launcherSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab1 == beamerPrefabU1)
            {
                range = 29f;

                beamerSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + beamerPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = beamerSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab1 == dartlingPrefabU1)
            {
                range = 26f;

                dartlingSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + dartlingPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = dartlingSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == blasterPrefabU1)
            {
                range = 21f;

                blasterSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + blasterPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = blasterSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == windPrefabU1)
            {
                range = 21f;

                windSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + windPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = windSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
        }

        //Upgrade 2

        if (Node.upgradeNO == 2)
        {
            if (NodeUI.target.turretBlueprint.upgradedPrefab2 == turretPrefabU2)
            {
                range = 21f;

                turretSelectedNodePositionU2 = BuildManager.selectedNode.transform.position + turretPositionOffsetU2;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = turretSelectedNodePositionU2;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab2 == launcherPrefabU2)
            {
                range = 41f;

                launcherSelectedNodePositionU2 = BuildManager.selectedNode.transform.position + launcherPositionOffsetU2;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = launcherSelectedNodePositionU2;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab2 == beamerPrefabU2)
            {
                range = 34f;

                beamerSelectedNodePositionU2 = BuildManager.selectedNode.transform.position + beamerPositionOffsetU2;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = beamerSelectedNodePositionU2;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab2 == dartlingPrefabU2)
            {
                range = 31f;

                dartlingSelectedNodePositionU2 = BuildManager.selectedNode.transform.position + dartlingPositionOffsetU2;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = dartlingSelectedNodePositionU2;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == blasterPrefabU2)
            {
                range = 31f;

                blasterSelectedNodePositionU1 = BuildManager.selectedNode.transform.position + blasterPositionOffsetU1;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = blasterSelectedNodePositionU1;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == windPrefabU2)
            {
                range = 31f;

                windSelectedNodePositionU2 = BuildManager.selectedNode.transform.position + windPositionOffsetU2;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = windSelectedNodePositionU2;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
        }

        //Upgrade 3

        if (Node.upgradeNO == 3)
        {
            if (NodeUI.target.turretBlueprint.upgradedPrefab3 == turretPrefabU3)
            {
                range = 31f;

                turretSelectedNodePositionU3 = BuildManager.selectedNode.transform.position + turretPositionOffsetU3;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = turretSelectedNodePositionU3;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab3 == launcherPrefabU3)
            {
                range = 46f;

                launcherSelectedNodePositionU3 = BuildManager.selectedNode.transform.position + launcherPositionOffsetU3;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = launcherSelectedNodePositionU3;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab3 == beamerPrefabU3)
            {
                range = 41f;

                beamerSelectedNodePositionU3 = BuildManager.selectedNode.transform.position + beamerPositionOffsetU3;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = beamerSelectedNodePositionU3;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.upgradedPrefab3 == dartlingPrefabU3)
            {
                range = 36f;

                dartlingSelectedNodePositionU3 = BuildManager.selectedNode.transform.position + dartlingPositionOffsetU3;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = dartlingSelectedNodePositionU3;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == blasterPrefabU3)
            {
                range = 36f;

                blasterSelectedNodePositionU3 = BuildManager.selectedNode.transform.position + blasterPositionOffsetU3;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = blasterSelectedNodePositionU3;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
            if (NodeUI.target.turretBlueprint.prefab == windPrefabU3)
            {
                range = 36f;

                windSelectedNodePositionU3 = BuildManager.selectedNode.transform.position + windPositionOffsetU3;
                selectedNodeRotation = Quaternion.Euler(rotation.x, 0f, 0f);
                turretCamera.transform.position = windSelectedNodePositionU3;
                turretCamera.transform.rotation = selectedNodeRotation;
                return;
            }
        }

    }

    private void Update()
    {
        if (BuildManager.somethingSelected == false)
        {
            if (nodeUICamActive == true)
            {
                SlantedCamera();
            }
        }

        if (BuildManager.somethingSelected == false && cameraNumber != 3)
        {
            cameraSelection.SetActive(false);
            cameraSelection2.SetActive(false);
        }

        if (cameraNumber == 3 && Bill.attentionPerspect == true)
        {
            attention.SetActive(true);
        } else
        {
            attention.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (WaveSpawner.EnemiesAlive == 0 && Bill.canPlay == true)
            {
                Toggle();
            } 
            
        }
        if (Bill.canPlay == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                SlantedCamera();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                OriginalCamera();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                if (GameManager.sceneIndex == 3)
                {
                    SpareCamera();
                } else
                {
                    warningText.text = "CAMERA 3 IS NOT AVAILABLE IN THIS LEVEL";
                    StartCoroutine("WarningInformation");
                }
                 
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                
                if (BuildManager.somethingSelected == true)
                {
                    TurretCamera();
                } else
                {
                    warningText.text = "TURRET PERSPECTIVE CAN ONLY BE USED WHEN A TURRET IS SELECTED";
                    StartCoroutine("WarningInformation");
                }
                    
                
                
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                ToggleTips();
            }

            if (tipsShown == true)
            {
                tipsGO.SetActive(true);
            } else
            {
                tipsGO.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (GameManager.sceneIndex == 3)
            {
                if (BuildManager.somethingSelected == true)
                {
                    ToggleNodeUICam();
                } else
                {
                    warningText.text = "YOU CAN ONLY TOGGLE TURRET UI WHEN A TOWER IS SELECTED";
                    StartCoroutine("WarningInformation");
                    return;
                }
                
            } else
            {
                warningText.text = "THIS KEY IS NOT NEEDED TO TOGGLE THE TURRET UI IN THIS LEVEL";
                StartCoroutine("WarningInformation");
            }
        }

        if (Node.notEnoughMoney == true)
        {
            warningText.text = "NOT ENOUGH MONEY";
            StartCoroutine("WarningInformation");
            Node.notEnoughMoney = false;
        }

        if (GameManager.oldSceneIndex != GameManager.sceneIndex)
        {
            if (GameManager.applyHints == true)
            {
                tipsShown = true;
            } else
            {
                tipsShown = false;
            }
            
            GameManager.oldSceneIndex = GameManager.sceneIndex;
        }

        
    }

    void Toggle()
    {
        if (billActive == true)
        {
            BillCamera();
            return;
        } else
        {
            SlantedCamera();
            return;
        }

    }

    void ToggleNodeUICam()
    {
        if (nodeUICamActive == false)
        {
            NodeUICamera();
            return;
        } else
        {
            SlantedCamera();
            return;
        }
    }

    void ToggleTips()
    {
        if (PauseMenu.paused == false)
        {
            if (GameManager.applyHints == true)
            {
                if (tipsShown == true)
                {
                    tipsShown = false;
                    return;
                }
                else
                {
                    tipsShown = true;
                    return;
                }
            }
        } else
        {
            tipsShown = false;
        }
        
        
    }

    IEnumerator WarningInformation()
    {
        warningGO.SetActive(true);
        yield return new WaitForSeconds(6f);
        warningGO.SetActive(false);
        
    }

   

}
