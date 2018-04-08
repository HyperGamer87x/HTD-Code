using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;
    private float defaultSpeed;

	public float startHealth = 100;
	public float health;
    //private float damage = 0;

	public int worth;

    public bool simple;
    public bool tough;
    public bool speedy;
    public bool ice;
    public bool metal;
    public bool trio;
    public bool motor;
    public bool armoured;
    public bool golden;
    public bool solid;

    public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar1;
    public Image healthBar2;
    public Image healthBar3;
    public Image healthBar4;
    public Image healthBar5;
    public Image healthBar6;

    public static bool isDead = false;

    public GameObject hbSlanted;
    public GameObject hbTop;
    public GameObject hbLeft;
    public GameObject hbRight;
    public GameObject hbFront;
    public GameObject hbBack;

    //public float green = 255;
    // public float red;

    private bool iced;
    public static bool iceHit;
    //public ParticleSystem iceImpactEffect;

    void Start ()
	{
        defaultSpeed = startSpeed;

		speed = startSpeed;
		health = startHealth;
        hbSlanted.SetActive(true);
        hbTop.SetActive(false);
        hbFront.SetActive(false);
        hbLeft.SetActive(false);
        hbBack.SetActive(false);
        hbRight.SetActive(false);
        iced = false;
        iceHit = false;
    }

	public void TakeDamage (float amount)
	{
        if (Bullet.slowAmountStatic > 0 && iced == false)
        {
            startSpeed = startSpeed / Bullet.slowAmountStatic;
            iceHit = true;
            iced = true;
            //iceImpactEffect.Play();
            StartCoroutine(IcedTimer());
        }

        health -= amount;

        //red = 2 * damage;
        //green = 2 * health;

        if (health <= 0)
        {
            Die();
        }

        healthBar1.fillAmount = health / startHealth;
        healthBar2.fillAmount = health / startHealth;
        healthBar3.fillAmount = health / startHealth;
        healthBar4.fillAmount = health / startHealth;
        healthBar5.fillAmount = health / startHealth;
        healthBar6.fillAmount = health / startHealth;

        if (startHealth / health <= 2)
        {
            healthBar1.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
            healthBar2.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
            healthBar3.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
            healthBar4.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
            healthBar5.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
            healthBar6.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
        }
        if (startHealth / health > 2)
        {
            healthBar1.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
            healthBar2.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
            healthBar3.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
            healthBar4.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
            healthBar5.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
            healthBar6.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
        }

        
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

        if (WaveSpawner.waveNumber < 10)
        {
            if (simple == true)
            {
                worth = Random.Range(5, 11);
            }
            if (tough == true)
            {
                worth = Random.Range(8, 15);
            }
            if (speedy == true)
            {
                worth = Random.Range(8, 15);
            }
        }
        if (WaveSpawner.waveNumber >= 10 && WaveSpawner.waveNumber < 20)
        {
            if (simple == true)
            {
                worth = Random.Range(4, 8);
            }
            if (tough == true)
            {
                worth = Random.Range(5, 9);
            }
            if (speedy == true)
            {
                worth = Random.Range(5, 9);
            }
            if (ice == true)
            {
                worth = Random.Range(9, 17);
            }
            if (metal == true)
            {
                worth = Random.Range(9, 17);
            }
        }
        if (WaveSpawner.waveNumber >= 20 && WaveSpawner.waveNumber < 40)
        {
            if (simple == true)
            {
                worth = Random.Range(2, 4);
            }
            if (tough == true)
            {
                worth = Random.Range(2, 5);
            }
            if (speedy == true)
            {
                worth = Random.Range(2, 5);
            }
            if (ice == true)
            {
                worth = Random.Range(4, 6);
            }
            if (metal == true)
            {
                worth = Random.Range(4, 6);
            }
            if (trio == true)
            {
                worth = Random.Range(4, 7);
            }
            if (motor == true)
            {
                worth = Random.Range(5, 7);
            }
            if (armoured == true)
            {
                worth = Random.Range(6, 8);
            }
            if (golden == true)
            {
                worth = Random.Range(7, 9);
            }
            if (solid == true)
            {
                worth = Random.Range(8, 10);
            }
        }
        if (WaveSpawner.waveNumber >= 40)
        {
            if (simple == true)
            {
                worth = Random.Range(1, 3);
            }
            if (tough == true)
            {
                worth = Random.Range(1, 3);
            }
            if (speedy == true)
            {
                worth = Random.Range(1, 3);
            }
            if (ice == true)
            {
                worth = Random.Range(2, 4);
            }
            if (metal == true)
            {
                worth = Random.Range(2, 4);
            }
            if (trio == true)
            {
                worth = Random.Range(2, 4);
            }
            if (motor == true)
            {
                worth = Random.Range(3, 5);
            }
            if (armoured == true)
            {
                worth = Random.Range(4, 6);
            }
            if (golden == true)
            {
                worth = Random.Range(5, 7);
            }
            if (solid == true)
            {
                worth = Random.Range(6, 8);
            }
        }
        

        PlayerStats.moneyGain = "$" + worth.ToString();
        PlayerStats.isMoneyGain = true;
        PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

    public void Update()
    {
        
        //damage = startHealth - health;
        
        if (Cameras.cameraNumber == 1)
        {
            hbSlanted.SetActive(true);
            hbTop.SetActive(false);
            hbFront.SetActive(false);
            hbLeft.SetActive(false);
            hbBack.SetActive(false);
            hbRight.SetActive(false);
        }

        if (Cameras.cameraNumber == 2)
        {
            hbSlanted.SetActive(false);
            hbTop.SetActive(true);
            hbFront.SetActive(false);
            hbLeft.SetActive(false);
            hbBack.SetActive(false);
            hbRight.SetActive(false);
        }

        if (Cameras.cameraNumber == 3)
        {
            hbSlanted.SetActive(false);
            hbTop.SetActive(false);
            hbFront.SetActive(true);
            hbLeft.SetActive(true);
            hbBack.SetActive(true);
            hbRight.SetActive(true);
        }
    }

    IEnumerator IcedTimer()
    {
        yield return new WaitForSeconds(Bullet.slowTimeStatic);
        iced = false;
        startSpeed = defaultSpeed;
        //iceImpactEffect.Stop();
    }

}
