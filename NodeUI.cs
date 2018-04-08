using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;
    public GameObject ui2;

    public static Node[] node;

	public Text upgradeCost;
	public Button upgradeButton;

	public static Node target;

    public GameObject rangeImage;
    public Vector3 positionOffset;
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
    public GameObject blasterPrefabU2;
    public GameObject windPrefabU2;
    public GameObject turretPrefabU3;
    public GameObject launcherPrefabU3;
    public GameObject beamerPrefabU3;
    public GameObject dartlingPrefabU3;
    public GameObject blasterPrefabU3;
    public GameObject windPrefabU3;
    private bool somethingSelected = false;

    public GameObject turretImage;
    public GameObject turretU1Image;
    public GameObject turretU2Image;
    public GameObject turretU3Image;
    public GameObject launcherImage;
    public GameObject launcherU1Image;
    public GameObject launcherU2Image;
    public GameObject launcherU3Image;
    public GameObject beamerImage;
    public GameObject beamerU1Image;
    public GameObject beamerU2Image;
    public GameObject beamerU3Image;
    public GameObject dartlingImage;
    public GameObject dartlingU1Image;
    public GameObject dartlingU2Image;
    public GameObject dartlingU3Image;
    public GameObject blasterImage;
    public GameObject blasterU1Image;
    public GameObject blasterU2Image;
    public GameObject blasterU3Image;
    public GameObject windImage;
    public GameObject windU1Image;
    public GameObject windU2Image;
    public GameObject windU3Image;

    public static bool isLosingHealth;

    public static string sellAmountString;
    public static int sellAmount;
    public Text sellAmountText;

    private void Start()
    {
        turretImage.SetActive(true);
        turretU1Image.SetActive(false);
        turretU2Image.SetActive(false);
        turretU3Image.SetActive(false);
        launcherImage.SetActive(false);
        launcherU1Image.SetActive(false);
        launcherU2Image.SetActive(false);
        launcherU3Image.SetActive(false);
        beamerImage.SetActive(false);
        beamerU1Image.SetActive(false);
        beamerU2Image.SetActive(false);
        beamerU3Image.SetActive(false);
        dartlingImage.SetActive(false);
        dartlingU1Image.SetActive(false);
        dartlingU2Image.SetActive(false);
        dartlingU3Image.SetActive(false);
        blasterImage.SetActive(false);
        blasterU1Image.SetActive(false);
        blasterU2Image.SetActive(false);
        blasterU3Image.SetActive(false);
        windImage.SetActive(false);
        windU1Image.SetActive(false);
        windU2Image.SetActive(false);
        windU3Image.SetActive(false);


        InvokeRepeating("UpdateNew", 0f, 0.05f);

    }

    public void SetTarget (Node _target)
	{
		target = _target;

        //transform.position = target.GetBuildPosition();

        if (!target.upgrade1 && !target.upgrade2 && !target.upgrade3)
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost1;
			upgradeButton.interactable = true;
            Node.upgradeNO = 0;
		}
        if (target.upgrade1 && !target.upgrade2 && !target.upgrade3)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost2;
            upgradeButton.interactable = true;
            Node.upgradeNO = 1;
		}
        if (target.upgrade1 && target.upgrade2 && !target.upgrade3)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost3;
            upgradeButton.interactable = true;
            Node.upgradeNO = 2;

        }
        if (target.upgrade1 && target.upgrade2 && target.upgrade3)
        {
            upgradeCost.text = "END OF UPGRADES";
            upgradeButton.interactable = false;
            Node.upgradeNO = 3;

        }

        

        ui.SetActive(true);
        ui2.SetActive(true);
        somethingSelected = true;
	}

	public void Hide ()
	{
		ui.SetActive(false);
        ui2.SetActive(false);
        UpgradeDescription.isInformationShown = false;
        UpgradeDescription.isStatisticsShown = false;
        somethingSelected = false;
	}

	public void Upgrade ()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell ()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}

    public void UpdateNew()
    {
        MoneyBack();

        if (somethingSelected == true)
        {
            if (Node.upgradeNO == 0)
            {
                if (target.turretBlueprint.prefab == turretPrefab)
                {
                    UpgradeDescription.towerNumber = 1;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(4.2f, 4.2f, 4.2f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Turret Selected");
                    turretImage.SetActive(true);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 100;
                    return;
                }
                if (target.turretBlueprint.prefab == launcherPrefab)
                {
                    UpgradeDescription.towerNumber = 2;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(6.4f, 6.4f, 6.4f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Launcher Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(true);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 150;
                    return;
                }
                if (target.turretBlueprint.prefab == beamerPrefab)
                {
                    UpgradeDescription.towerNumber = 3;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(5.3f, 5.3f, 5.3f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Beamer Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(true);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 225;
                    return;
                }
                if (target.turretBlueprint.prefab == dartlingPrefab)
                {
                    UpgradeDescription.towerNumber = 4;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(5.3f, 5.3f, 5.3f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Dartling Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(true);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 250;
                    return;
                }
                if (target.turretBlueprint.prefab == blasterPrefab)
                {
                    UpgradeDescription.towerNumber = 5;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(4.2f, 4.2f, 4.2f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Blaster Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(true);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 100;
                    return;
                }
                if (target.turretBlueprint.prefab == windPrefab)
                {
                    UpgradeDescription.towerNumber = 6;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(4.2f, 4.2f, 4.2f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Wind Gen Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(true);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 100;
                    return;
                }
            }
            if (Node.upgradeNO == 1)
            {
                if (target.turretBlueprint.upgradedPrefab1 == turretPrefabU1)
                {
                    UpgradeDescription.towerNumber = 11;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(5.3f, 5.3f, 5.3f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(true);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 250;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab1 == launcherPrefabU1)
                {
                    UpgradeDescription.towerNumber = 12;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(8.6f, 8.6f, 8.6f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(true);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 400;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab1 == beamerPrefabU1)
                {
                    UpgradeDescription.towerNumber = 13;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(7f, 7f, 7f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(true);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 375;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab1 == dartlingPrefabU1)
                {
                    UpgradeDescription.towerNumber = 14;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(6.4f, 6.4f, 6.4f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(true);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 500;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab1 == blasterPrefabU1)
                {
                    UpgradeDescription.towerNumber = 15;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(5.3f, 5.3f, 5.3f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(true);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 300;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab1 == windPrefabU1)
                {
                    UpgradeDescription.towerNumber = 16;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(4.2f, 4.2f, 4.2f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(true);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 100;
                    return;
                }
            }
            if (Node.upgradeNO == 2)
            {
                if (target.turretBlueprint.upgradedPrefab2 == turretPrefabU2)
                {
                    UpgradeDescription.towerNumber = 21;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(5.3f, 5.3f, 5.3f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(true);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 500;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab2 == launcherPrefabU2)
                {
                    UpgradeDescription.towerNumber = 22;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(9.7f, 9.7f, 9.7f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(true);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1000;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab2 == beamerPrefabU2)
                {
                    UpgradeDescription.towerNumber = 23;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(8.1f, 8.1f, 5.6f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(true);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1000;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab2 == dartlingPrefabU2)
                {
                    UpgradeDescription.towerNumber = 24;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(true);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1000;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab2 == blasterPrefabU2)
                {
                    UpgradeDescription.towerNumber = 25;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(true);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 600;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab2 == windPrefabU2)
                {
                    UpgradeDescription.towerNumber = 26;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(4.2f, 4.2f, 4.2f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Wind Gen Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(true);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 100;
                    return;
                }
            }
            if (Node.upgradeNO == 3)
            {
                if (target.turretBlueprint.upgradedPrefab3 == turretPrefabU3)
                {
                    UpgradeDescription.towerNumber = 31;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(8.6f, 8.6f, 8.6f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(true);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1250;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab3 == launcherPrefabU3)
                {
                    UpgradeDescription.towerNumber = 32;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(10.8f, 10.8f, 10.8f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(true);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1500;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab3 == beamerPrefabU3)
                {
                    UpgradeDescription.towerNumber = 33;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(9.7f, 9.7f, 9.7f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(true);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1925;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab3 == dartlingPrefabU3)
                {
                    UpgradeDescription.towerNumber = 34;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(8.6f, 8.6f, 8.6f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(true);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1750;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab3 == blasterPrefabU3)
                {
                    UpgradeDescription.towerNumber = 35;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(true);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(false);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 1100;
                    return;
                }
                if (target.turretBlueprint.upgradedPrefab3 == windPrefabU3)
                {
                    UpgradeDescription.towerNumber = 36;

                    Cameras.turretSelectedNodePosition = BuildManager.selectedNode.transform.position + positionOffset;
                    rangeImage.gameObject.transform.localScale = new Vector3(4.2f, 4.2f, 4.2f);
                    rangeImage.transform.position = Cameras.turretSelectedNodePosition;

                    Debug.Log("Wind Gen Selected");
                    turretImage.SetActive(false);
                    turretU1Image.SetActive(false);
                    turretU2Image.SetActive(false);
                    turretU3Image.SetActive(false);
                    launcherImage.SetActive(false);
                    launcherU1Image.SetActive(false);
                    launcherU2Image.SetActive(false);
                    launcherU3Image.SetActive(false);
                    beamerImage.SetActive(false);
                    beamerU1Image.SetActive(false);
                    beamerU2Image.SetActive(false);
                    beamerU3Image.SetActive(false);
                    dartlingImage.SetActive(false);
                    dartlingU1Image.SetActive(false);
                    dartlingU2Image.SetActive(false);
                    dartlingU3Image.SetActive(false);
                    blasterImage.SetActive(false);
                    blasterU1Image.SetActive(false);
                    blasterU2Image.SetActive(false);
                    blasterU3Image.SetActive(false);
                    windImage.SetActive(false);
                    windU1Image.SetActive(false);
                    windU2Image.SetActive(false);
                    windU3Image.SetActive(true);
                    BuildManager.whichTurretON = false;

                    target.turretBlueprint.sellCost = 100;
                    return;
                }
            }  
        } else
        {
            return;
        }

        
        if (WaveSpawner.EnemiesAlive > 0)
        {
            InvokeRepeating("DrainHealth", 0f, 0.5f);
            
        }


    }

    void DrainHealth()
    {
        isLosingHealth = true;
    }

    public void MoneyBack()
    {
        if (BuildManager.somethingSelected == true)
        {
            sellAmount = target.turretBlueprint.sellCost;

            sellAmountString = sellAmount.ToString();
            sellAmountText.text = "$" + sellAmountString;
        } else
        {
            return;
        }
        
    }

}
