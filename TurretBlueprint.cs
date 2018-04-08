using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint {

	public GameObject prefab;
    public int cost;
    public int sellCost;

	public GameObject upgradedPrefab1;
	public int upgradeCost1;
    public int sellCost1;

    public GameObject upgradedPrefab2;
    public int upgradeCost2;
    public int sellCost2;

    public GameObject upgradedPrefab3;
    public int upgradeCost3;
    public int sellCost3;

    public GameObject upgradedPrefab4;
    public int upgradeCost4;
    public int sellCost4;



    public float strtHealth;
    public float health;

    private void Start()
    {
        strtHealth = 200;
        health = 200;
        
    }

    void DrainHealth()
    {
        Debug.Log("this");
        health = health - 1;
        NodeUI.isLosingHealth = false;
    }

    

}
