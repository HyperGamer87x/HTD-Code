using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;

	public int damage = 50;

	public float explosionRadius = 0f;
    public float slowAmount = 0f;
    public float slowTime = 0f;
    public static float slowAmountStatic;
    public static float slowTimeStatic;
	public GameObject impactEffect;

    public static bool bulletHit;
    public static bool missileHit;

    private void Start()
    {
        bulletHit = false;
    }

    public void Seek (Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void Update () {

        slowAmountStatic = slowAmount;
        slowTimeStatic = slowTime;

        if (target == null)
		{
            //Destroy(gameObject);
            gameObject.SetActive(false);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	void HitTarget ()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

		if (explosionRadius > 0f)
		{
			Explode();
            missileHit = true;
		} else
		{
			Damage(target);
            bulletHit = true;
        }

        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

	void Explode ()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
            if (collider.tag == "Enemy_Ice")
            {
                Damage(collider.transform);
            }
            if (collider.tag == "Enemy_Metal")
            {
                Damage(collider.transform);
            }
        }
	}

	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
