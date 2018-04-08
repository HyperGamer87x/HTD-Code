using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
    public Button waveBtn;
    public Button waveBtn2;
    public Text waveNumberText;
    public Text waveNumberText2;
    public static int waveNumber = 0;
    public Button fastMode;
    public Button normalMode;
    public GameObject fastModeGO;
    public GameObject normalModeGO;
    public GameObject fastModeGO2;
    public GameObject normalModeGO2;

    public Text enemiesRemain;
    public Text enemiesRemain2;

    public Text waveCountdownText;

	public GameManager gameManager;

    public int bonusMoney;
    public bool giveBonusMoney = false;

    public static bool resetWave = false;

	private int waveIndex = 0;

    public static bool canChangeTrail = true;

    private int waveAmount;

    private void Start()
    {
        InvokeRepeating("UpdateNew", 0f, 0.05f);
    }

    void UpdateNew ()
	{
        if (LevelSelector.difficulty == 1)
        {
            waveAmount = 45;
        }
        if (LevelSelector.difficulty == 2)
        {
            waveAmount = 50;
        }
        if (LevelSelector.difficulty == 3)
        {
            waveAmount = 55;
        }
        if (LevelSelector.difficulty == 4)
        {
            waveAmount = 58;
        }
        if (LevelSelector.difficulty == 5)
        {
            waveAmount = 60;
        }

        if (resetWave == true)
        {
            waveIndex = 0;
            EnemiesAlive = 0;
            waveNumber = 0;
            Bill.more = true;
            Bill.textNumber = 0;
            resetWave = false;
        }

        enemiesRemain.text = EnemiesAlive.ToString() + " ENEMIES REMAIN!";
        enemiesRemain2.text = EnemiesAlive.ToString() + " ENEMIES";

        if (EnemiesAlive > 0)
		{
            waveNumberText.text = "WAVE " + waveNumber.ToString();
            waveNumberText2.text = "WAVE " + waveNumber.ToString();
            waveBtn.interactable = false;
            waveBtn2.interactable = false;
            return;
		}

		if (waveIndex == waveAmount)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

        if (EnemiesAlive < 1)
        {
            EnemiesAlive = 0;
            
            fastModeGO.SetActive(false);
            normalModeGO.SetActive(false);
            fastModeGO2.SetActive(false);
            normalModeGO2.SetActive(false);
            waveBtn.interactable = true;
            waveBtn2.interactable = true;
            Time.timeScale = 1.0f;

            if (giveBonusMoney == true)
            {
                bonusMoney = Random.Range(40, 100); 
                PlayerStats.Money = PlayerStats.Money + bonusMoney;
                PlayerStats.isMoneyGain = true;
                PlayerStats.moneyGain = "$" + bonusMoney.ToString();
                giveBonusMoney = false;
            }
        }

		//if (countdown <= 0f)
		//{
		//	StartCoroutine(SpawnWave());
		//	countdown = timeBetweenWaves;
		//	return;
		//}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
        giveBonusMoney = true;

        waveNumber = waveNumber + 1;
        fastModeGO.SetActive(true);
        normalModeGO.SetActive(false);
        fastModeGO2.SetActive(true);
        normalModeGO2.SetActive(false);
        PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.countA + wave.countB + wave.countC + wave.countD + wave.countE;

		for (int i = 0; i < wave.countA; i++)
		{
			SpawnEnemy(wave.enemyA);
			yield return new WaitForSeconds(1f / wave.rateA);
            canChangeTrail = true;

        }
        for (int i = 0; i < wave.countB; i++)
        {
            SpawnEnemy(wave.enemyB);
            yield return new WaitForSeconds(1f / wave.rateB);
            canChangeTrail = true;

        }
        for (int i = 0; i < wave.countC; i++)
        {
            SpawnEnemy(wave.enemyC);
            yield return new WaitForSeconds(1f / wave.rateC);
            canChangeTrail = true;

        }
        for (int i = 0; i < wave.countD; i++)
        {
            SpawnEnemy(wave.enemyD);
            yield return new WaitForSeconds(1f / wave.rateD);
            canChangeTrail = true;

        }
        for (int i = 0; i < wave.countE; i++)
        {
            SpawnEnemy(wave.enemyE);
            yield return new WaitForSeconds(1f / wave.rateE);
            canChangeTrail = true;

        }

        waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

	}

    public void WhenWaveButtonPressed ()
    {
        StartCoroutine(SpawnWave());
        return;
    }

    public void FastFoward ()
    {
        Time.timeScale = 2.0f;
        fastModeGO.SetActive(false);
        normalModeGO.SetActive(true);
        fastModeGO2.SetActive(false);
        normalModeGO2.SetActive(true);
    }

    public void FastFowardOff ()
    {
        Time.timeScale = 1.0f;
        fastModeGO.SetActive(true);
        normalModeGO.SetActive(false);
        fastModeGO2.SetActive(true);
        normalModeGO2.SetActive(false);
    }

}
