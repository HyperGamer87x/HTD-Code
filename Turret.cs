using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Turret : MonoBehaviour {

	private Transform target;
	private Enemy targetEnemy;

	[Header("General")]

	public float range = 15f;

	[Header("Use Bullets (default)")]
	public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public float fireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Use Laser")]
	public bool useLaser = false;
    public bool laserBeamer = false;
    public static bool laserBeamerStatic = false;

    public int damageOverTime = 30;
	public float slowAmount = .5f;

	public LineRenderer lineRenderer;
    public LineRenderer lineRenderer2;
	public ParticleSystem impactEffect;
	public Light impactLight;
    public ParticleSystem impactEffect2;
    public Light impactLight2;
    public ParticleSystem impactEffect3;
    public Light impactLight3;

    [Header("Use TargetSet")]
    public bool useTargetSet = false;
    public GameObject targetLocation;
    public Transform targetSetTransform;
    public static Vector3 targetPrefab;
    public GameObject targetGO;
    public static bool showTarget;

    [Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";
    public string enemyIceTag = "Enemy_Ice";
    public string enemyMetalTag = "Enemy_Metal";

    public Transform partToRotate;
	public float turnSpeed = 10f;

	public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;

    public bool has2FP;
    public bool has3FP;
    public bool has4FP;

    public bool has2LR;

    public Button CloseButton;

    public float health;

    public bool isOff = false;

    public static bool newTarget = false;

    public static bool laserOn;

    public int killCount;

    // Use this for initialization
    void Start () {
        laserOn = false;

        killCount = 0;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //enemyPositionMin.transform.position.(-4f, 2f, -5f);
        //enemyPositionMax.transform.position.(-3.188742f, 2.016339f, -4.85884f);

    }

    void UpdateTarget ()
	{
        if (GameManager.GameIsOver == false)
        {
            if (isOff == false)
            {
                if (!useTargetSet)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
                    GameObject[] enemiesIce = GameObject.FindGameObjectsWithTag(enemyIceTag);
                    GameObject[] enemiesMetal = GameObject.FindGameObjectsWithTag(enemyMetalTag);
                    float shortestDistance = Mathf.Infinity;
                    GameObject nearestEnemy = null;
                    foreach (GameObject enemy in enemies)
                    {
                        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distanceToEnemy < shortestDistance)
                        {
                            shortestDistance = distanceToEnemy;
                            nearestEnemy = enemy;
                        }
                    }

                    foreach (GameObject enemy in enemiesIce)
                    {
                        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distanceToEnemy < shortestDistance)
                        {
                            shortestDistance = distanceToEnemy;
                            nearestEnemy = enemy;
                        }
                    }

                    foreach (GameObject enemy in enemiesMetal)
                    {
                        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distanceToEnemy < shortestDistance)
                        {
                            shortestDistance = distanceToEnemy;
                            nearestEnemy = enemy;
                        }
                    }

                    if (nearestEnemy != null && shortestDistance <= range)
                    {
                        target = nearestEnemy.transform;
                        targetEnemy = nearestEnemy.GetComponent<Enemy>();
                        //enemyPositionMin.transform.position = nearestEnemy.transform.position;
                        //if (enemy.transform.position == enemyPositionMax.transform.position)
                        //{
                        //  Debug.Log("het");
                        //}
                    }
                    else
                    {
                        target = null;
                    }
                } else
                {
                    if (WaveSpawner.EnemiesAlive != 0)
                    {
                        ShootForSetTarget();
                    } else
                    {
                        return;
                    }
                }
                
            }
        }
        

    }

	// Update is called once per frame
	void Update () {

        laserBeamerStatic = laserBeamer;
    
        targetLocation.transform.position = PathNodes.targetPos;
        targetSetTransform = targetLocation.transform;
        targetGO.transform.position = PathNodes.targetPos;

        if (showTarget == true)
        {
            targetGO.SetActive(true);
        } else
        {
            targetGO.SetActive(false);
        }

        if (isOff == false)
        {
            //health = TurretBlueprint.health;
            
        

            if (target == null)
            {
                if (useLaser)
                {
                    if (lineRenderer.enabled)
                    {
                        laserOn = false;
                        lineRenderer.enabled = false;
                        impactEffect.Stop();
                        impactLight.enabled = false;
                        impactEffect2.Stop();
                        impactLight2.enabled = false;
                        impactEffect3.Stop();
                        impactLight3.enabled = false;

                        if (has2LR == true)
                        {
                            lineRenderer2.enabled = false;
                        }



                    }
                }

                return;
            }

            LockOnTarget();

            if (useLaser)
            {
                Laser();
                
            }
            else
            {
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }

                fireCountdown -= Time.deltaTime;
            }

            //if (target.transform.position == fence.transform.position)
            {
                //Debug.Log("Enemy Spotted");
            }
        }

        if (isOff == true)
        {

        }

	}

	void LockOnTarget ()
	{
        if (isOff == false)
        {
            if (!useTargetSet)
            {
                Vector3 dir = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            } else
            {
                Vector3 dir = targetLocation.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
            
        }

	}

	void Laser ()
	{
        if (isOff == false)
        {

            targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
            targetEnemy.Slow(slowAmount);

            if (!lineRenderer.enabled)
            {
                laserOn = true;
                lineRenderer.enabled = true;
                impactEffect.Play();
                impactLight.enabled = true;
                impactEffect2.Play();
                impactLight2.enabled = true;
                impactEffect3.Play();
                impactLight3.enabled = true;

                if (has2LR == true)
                {
                    lineRenderer2.enabled = true;
                }
            }

            lineRenderer.SetPosition(0, firePoint1.position);
            lineRenderer.SetPosition(1, target.position);

            if (has2LR == true)
            {
                lineRenderer2.SetPosition(0, firePoint2.position);
                lineRenderer2.SetPosition(1, target.position);
            }

            Vector3 dir = firePoint1.position - target.position;

            impactEffect.transform.position = target.position + dir.normalized;

            impactEffect.transform.rotation = Quaternion.LookRotation(dir);

            impactEffect2.transform.position = target.position + dir.normalized;

            impactEffect2.transform.rotation = Quaternion.LookRotation(dir);

            impactEffect3.transform.position = target.position + dir.normalized;

            impactEffect3.transform.rotation = Quaternion.LookRotation(dir);


        }

        
	}

	void Shoot ()
	{
        if (isOff == false)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            
            if (bullet != null)
                bullet.Seek(target);
            
            
           

            StartCoroutine(MultipleBullets());

            if (newTarget == true)
            {
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
                bullet = bulletGO.GetComponent<Bullet>();

                if (bullet != null)
                    bullet.Seek(target);

                StartCoroutine(MultipleBullets());

                newTarget = false;

            }

        }

	}

    void ShootForSetTarget()
    {
        if (isOff == false)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(targetSetTransform);
            

            StartCoroutine(MultipleBullets());

            if (newTarget == true)
            {
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
                bullet = bulletGO.GetComponent<Bullet>();

                if (bullet != null)
                    bullet.Seek(targetSetTransform);

                StartCoroutine(MultipleBullets());

                newTarget = false;

            }
            LockOnTarget();

        }
    }

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

    IEnumerator MultipleBullets ()
    {
        if (has2FP == true)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
            Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

            if (bullet2 != null)
                bullet2.Seek(target);
        }
        if (has3FP == true)
        {
            yield return new WaitForSeconds(0.15f);
            GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
            Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

            if (bullet2 != null)
                bullet2.Seek(target);

            yield return new WaitForSeconds(0.15f);
            GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab3, firePoint3.position, firePoint3.rotation);
            Bullet bullet3 = bulletGO3.GetComponent<Bullet>();

            if (bullet3 != null)
                bullet3.Seek(target);
        }
        if (has4FP == true)
        {
            yield return new WaitForSeconds(0.05f);
            GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
            Bullet bullet2 = bulletGO2.GetComponent<Bullet>();

            if (bullet2 != null)
                bullet2.Seek(target);

            yield return new WaitForSeconds(0.05f);
            GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab3, firePoint3.position, firePoint3.rotation);
            Bullet bullet3 = bulletGO3.GetComponent<Bullet>();

            if (bullet3 != null)
                bullet3.Seek(target);

            yield return new WaitForSeconds(0.05f);
            GameObject bulletGO4 = (GameObject)Instantiate(bulletPrefab4, firePoint4.position, firePoint4.rotation);
            Bullet bullet4 = bulletGO4.GetComponent<Bullet>();

            if (bullet4 != null)
                bullet4.Seek(target);
        }
    }

}
