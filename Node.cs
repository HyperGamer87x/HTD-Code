using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

	//[HideInInspector]
	public GameObject turret;
	//[HideInInspector]
	public TurretBlueprint turretBlueprint;
	//[HideInInspector]
	public bool upgrade1 = false;
    public bool upgrade2 = false;
    public bool upgrade3 = false;

    public GameObject turretPrefab;
    public GameObject launcherPrefab;
    public GameObject beamerPrefab;
    public GameObject dartlingPrefab;
    public GameObject blasterPrefab;
    public GameObject windPrefab;
    public GameObject grenadePrefab;
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



    private Renderer rend;
	private Color startColor;

    public static int upgradeNO = 0;
    private bool stopSelecting;

    public static bool cancelBuy;
    public static bool notEnoughMoney;

	BuildManager buildManager;


    public static bool playerSetTarget = false;

    public static int killCount;
    public Text killCountText;

    void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
        cancelBuy = false;
        notEnoughMoney = false;
    }

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
        
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
            buildManager.SelectNode(this);
            return;
        }

		if (!buildManager.CanBuild)
			return;

        if (cancelBuy == false)
        {
            BuildTurret(buildManager.GetTurretToBuild());
        }
        else
        {
            return;
        }
	}

	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
            notEnoughMoney = true;
            return;
		}

        PlayerStats.moneyLost = "$" + blueprint.cost.ToString();
        PlayerStats.isMoneyLost = true;
        PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Turret built!");

        playerSetTarget = true;
    }

    public void UpgradeTurret ()
	{
        if (upgrade1 == false && upgrade2 == false && upgrade3 == false)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost1)
            {
                Debug.Log("Not enough money to upgrade that!");
                notEnoughMoney = true;
                return;
            }

            PlayerStats.moneyLost = "$" + turretBlueprint.upgradeCost1.ToString();
            PlayerStats.isMoneyLost = true;
            PlayerStats.Money -= turretBlueprint.upgradeCost1;

            //Get rid of the old turret
            Destroy(turret);

            //Build a new one
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab1, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            upgrade1 = true;

            Debug.Log("Turret upgraded!");
            return;
        }
        if (upgrade1 == true && upgrade2 == false && upgrade3 == false)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost2)
            {
                Debug.Log("Not enough money to upgrade that!");
                notEnoughMoney = true;
                return;
            }

            PlayerStats.moneyLost = "$" + turretBlueprint.upgradeCost2.ToString();
            PlayerStats.isMoneyLost = true;
            PlayerStats.Money -= turretBlueprint.upgradeCost2;

            //Get rid of the old turret
            Destroy(turret);

            //Build a new one
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab2, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            upgrade2 = true;

            Debug.Log("Turret upgraded!");
            return;
        }
        if(upgrade1 == true && upgrade2 == true && upgrade3 == false)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost3)
            {
                Debug.Log("Not enough money to upgrade that!");
                notEnoughMoney = true;
                return;
            }

            PlayerStats.moneyLost = "$" + turretBlueprint.upgradeCost3.ToString();
            PlayerStats.isMoneyLost = true;
            PlayerStats.Money -= turretBlueprint.upgradeCost3;

            //Get rid of the old turret
            Destroy(turret);

            //Build a new one
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab3, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            upgrade3 = true;

            Debug.Log("Turret upgraded!");
            return;
        }

    }

	public void SellTurret()
	{
        PlayerStats.moneyGain = "$" + NodeUI.sellAmountString;
        PlayerStats.isMoneyGain = true;
        PlayerStats.Money += NodeUI.sellAmount;

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
        upgrade1 = false;
        upgrade2 = false;
        upgrade3 = false;
	}

	void OnMouseEnter ()
	{
        //if (Shop.towerWithTarget == true)
        // {

        //playerSetTarget = true;

        //  }

        //

        

        if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

        if (cancelBuy == false)
        {
            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;
                
            }
            else
            {
                rend.material.color = notEnoughMoneyColor;
                
            }
        } else
        {
            
            return;
        }

        


    }

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            cancelBuy = true;
        }
        


        if (BuildManager.whichTurretON == true)
        {
            if (upgradeNO == 0)
            {
                if (BuildManager.somethingSelected == true)
                {
                    if (turretBlueprint.prefab == turretPrefab)
                    {
                        //Debug.Log("T Selected");
                        BuildManager.turretToSelect = 1;
                    }
                    if (turretBlueprint.prefab == launcherPrefab)
                    {
                        //Debug.Log("L Selected");
                        BuildManager.turretToSelect = 2;
                    }
                    if (turretBlueprint.prefab == beamerPrefab)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 3;
                    }
                    if (turretBlueprint.prefab == dartlingPrefab)
                    {
                        //Debug.Log("D Selected");
                        BuildManager.turretToSelect = 4;
                    }
                    if (turretBlueprint.prefab == grenadePrefab)
                    {
                        //Debug.Log("G Selected");
                        BuildManager.turretToSelect = 0;
                    }
                    if (turretBlueprint.prefab == blasterPrefab)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 5;
                    }
                    if (turretBlueprint.prefab == windPrefab)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 6;
                    }
                }
                else
                {
                    return;
                }
            }
            if (upgradeNO == 1)
            {
                if (BuildManager.somethingSelected == true)
                {
                    if (turretBlueprint.upgradedPrefab1 == turretPrefabU1)
                    {
                        //Debug.Log("T Selected");
                        BuildManager.turretToSelect = 11;
                    }
                    if (turretBlueprint.upgradedPrefab1 == launcherPrefabU1)
                    {
                        //Debug.Log("L Selected");
                        BuildManager.turretToSelect = 12;
                    }
                    if (turretBlueprint.upgradedPrefab1 == beamerPrefabU1)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 13;
                    }
                    if (turretBlueprint.upgradedPrefab1 == dartlingPrefabU1)
                    {
                        //Debug.Log("D Selected");
                        BuildManager.turretToSelect = 14;
                    }
                    if (turretBlueprint.prefab == blasterPrefabU1)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 15;
                    }
                    if (turretBlueprint.prefab == windPrefabU1)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 16;
                    }
                }
                else
                {
                    return;
                }
            }
            if (upgradeNO == 2)
            {
                if (BuildManager.somethingSelected == true)
                {
                    if (turretBlueprint.upgradedPrefab2 == turretPrefabU2)
                    {
                        //Debug.Log("T Selected");
                        BuildManager.turretToSelect = 21;
                    }
                    if (turretBlueprint.upgradedPrefab2 == launcherPrefabU2)
                    {
                        //Debug.Log("L Selected");
                        BuildManager.turretToSelect = 22;
                    }
                    if (turretBlueprint.upgradedPrefab2 == beamerPrefabU2)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 23;
                    }
                    if (turretBlueprint.upgradedPrefab2 == dartlingPrefabU2)
                    {
                        //Debug.Log("D Selected");
                        BuildManager.turretToSelect = 24;
                    }
                    if (turretBlueprint.prefab == blasterPrefabU2)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 25;
                    }
                    if (turretBlueprint.prefab == windPrefabU2)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 26;
                    }
                }
                else
                {
                    return;
                }
            }
            if (upgradeNO == 3)
            {
                if (BuildManager.somethingSelected == true)
                {
                    if (turretBlueprint.upgradedPrefab3 == turretPrefabU3)
                    {
                        //Debug.Log("T Selected");
                        BuildManager.turretToSelect = 31;
                    }
                    if (turretBlueprint.upgradedPrefab3 == launcherPrefabU3)
                    {
                        //Debug.Log("L Selected");
                        BuildManager.turretToSelect = 32;
                    }
                    if (turretBlueprint.upgradedPrefab3 == beamerPrefabU3)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 33;
                    }
                    if (turretBlueprint.upgradedPrefab3 == dartlingPrefabU3)
                    {
                        //Debug.Log("D Selected");
                        BuildManager.turretToSelect = 34;
                    }
                    if (turretBlueprint.prefab == blasterPrefabU3)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 35;
                    }
                    if (turretBlueprint.prefab == windPrefabU3)
                    {
                        //Debug.Log("B Selected");
                        BuildManager.turretToSelect = 36;
                    }
                }
                else
                {
                    return;
                }
            }

        } else
        {
            return;
        }
        
        

    }

    public void SelectTurret()
    {
        //Debug.Log("Turret Selected");
    }

    public void SelectLauncher()
    {
        //Debug.Log("Launcher Selected");
    }

    public void SelectBeamer()
    {
        //Debug.Log("Beamer Selected");
    }

    public void SelectDartling()
    {
        //Debug.Log("Dartling Selected");
    }

}
