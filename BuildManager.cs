using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

    public static bool somethingSelected = false;
    public static bool nodeDeselected = true;

    private TurretBlueprint turretToBuild;
	public static Node selectedNode;

    public static int turretToSelect;
    public static bool whichTurretON = false;
    public GameObject turretPrefab;
    public GameObject launcherPrefab;
    public GameObject beamerPrefab;
    public GameObject dartlingPrefab;
    public GameObject grenadePrefab;
    public GameObject blasterPrefab;
    public GameObject windPrefab;


    public NodeUI nodeUI;
    public Node target;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    private void Start()
    {
        InvokeRepeating("SlowUpdate", 0f, 0.5f);
    }

    public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}
        
        somethingSelected = true;
		selectedNode = node;
		turretToBuild = null;
        whichTurretON = true;

        nodeUI.SetTarget(node);
        
	}

	public void DeselectNode()
	{
        somethingSelected = false;
        selectedNode = null;
		nodeUI.Hide();
        nodeDeselected = true;
        whichTurretON = false;
        PathNodes.deselectNow = false;
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;

		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild ()
	{
		return turretToBuild;
	}

    void SlowUpdate()
    {
        if (PathNodes.deselectNow == true)
        {
            DeselectNode();
        }
    }

}
