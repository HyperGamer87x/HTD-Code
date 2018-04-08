using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamer;
    public TurretBlueprint dartlingGun;
    public TurretBlueprint targetBomber;
    public TurretBlueprint iceBlaster;
    public TurretBlueprint windGen;
    public TurretBlueprint airBoomer;

    public static bool towerWithTarget;

    BuildManager buildManager;

	void Start ()
	{
        towerWithTarget = false;
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret ()
	{
        towerWithTarget = false;
        Debug.Log("Standard Turret Selected");
        Node.cancelBuy = false;
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissileLauncher()
	{
        towerWithTarget = false;
        Debug.Log("Missile Launcher Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void SelectLaserBeamer()
	{
        towerWithTarget = false;
        Debug.Log("Laser Beamer Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(laserBeamer);
	}

    public void SelectDartlingGun()
    {
        towerWithTarget = false;
        Debug.Log("Dartling Gun Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(dartlingGun);
    }

    public void SelectTargetBomber()
    {
        towerWithTarget = true;
        Debug.Log("Grenade Launcher Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(targetBomber);
    }

    public void SelectIceBlaster()
    {
        towerWithTarget = false;
        Debug.Log("Ice Blaster Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(iceBlaster);
    }

    public void SelectWindGen()
    {
        towerWithTarget = false;
        Debug.Log("Wind Generator Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(windGen);
    }

    public void SelectAirBoomer()
    {
        towerWithTarget = false;
        Debug.Log("Air Boomer Selected");
        Node.cancelBuy = false;
        buildManager.SelectTurretToBuild(airBoomer);
    }
}
