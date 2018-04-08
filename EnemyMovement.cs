using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex;

	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

        
        
       target = Waypoints.points[0];
        wavepointIndex = Waypoints.wavepointIndex;

    }

	void Update()
	{

		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

        if (GameManager.sceneIndex == 3)
        {
            if (wavepointIndex == 47)
            {
                EndPath();
            }
            if (wavepointIndex == 100)
            {
                EndPath();
            }
            if (wavepointIndex == 150)
            {
                EndPath();
            }
        }

        if (GameManager.sceneIndex == 4)
        {
            if (wavepointIndex == 8)
            {
                EndPath();
            }
        }

        if (GameManager.sceneIndex == 5)
        {
            if (wavepointIndex == 14)
            {
                EndPath();
            }
        }

        if (GameManager.sceneIndex == 6)
        {
            if (wavepointIndex == 22)
            {
                EndPath();
            }
            if (wavepointIndex == 46)
            {
                EndPath();
            }
            if (wavepointIndex == 70)
            {
                EndPath();
            }
        }



        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
        
		
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
