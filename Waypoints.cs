using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static Transform[] points;
    public static int route;

    public static int wavepointIndex;

    void Awake ()
	{
        

        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

    }

    private void Update()
    {
        if (WaveSpawner.canChangeTrail == true)
        {
            if (GameManager.sceneIndex == 3)
            {
                route = Random.Range(1, 5);

                if (route == 1)
                {
                    wavepointIndex = 0;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 2)
                {
                    wavepointIndex = 48;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 3)
                {
                    wavepointIndex = 101;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 4)
                {
                    wavepointIndex = 151;
                    WaveSpawner.canChangeTrail = false;
                }
            }

            if (GameManager.sceneIndex == 4)
            {
                route = Random.Range(1, 3);

                if (route == 1)
                {
                    wavepointIndex = 0;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 2)
                {
                    wavepointIndex = 9;
                    WaveSpawner.canChangeTrail = false;
                }
                
            }
            if (GameManager.sceneIndex == 5)
            {
                route = Random.Range(1, 3);

                if (route == 1)
                {
                    wavepointIndex = 0;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 2)
                {
                    wavepointIndex = 15;
                    WaveSpawner.canChangeTrail = false;
                }

            }
            if (GameManager.sceneIndex == 6)
            {
                route = Random.Range(1, 4);

                if (route == 1)
                {
                    wavepointIndex = 0;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 2)
                {
                    wavepointIndex = 23;
                    WaveSpawner.canChangeTrail = false;
                }
                if (route == 3)
                {
                    wavepointIndex = 47;
                    WaveSpawner.canChangeTrail = false;
                }
            }
            if (GameManager.sceneIndex != 3 && GameManager.sceneIndex != 4 && GameManager.sceneIndex != 5)
            {
                route = 1;

                if (route == 1)
                {
                    wavepointIndex = 0;
                    WaveSpawner.canChangeTrail = false;
                }
                
            }

            
        }
    }

}
