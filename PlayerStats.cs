using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;
    public static string moneyLost;
    public static bool isMoneyLost = false;
    public static string moneyGain;
    public static bool isMoneyGain = false;

    public static int Lives;
	public int startLives = 100;
    public static int startLivesStatic;

    public GameObject moneyLostGO;
    public Text moneyLostText;
    public GameObject moneyLostGO2;
    public Text moneyLostText2;
    public GameObject moneyLostGO3;
    public Text moneyLostText3;
    public GameObject moneyLostGO4;
    public Text moneyLostText4;
    public GameObject moneyLostGO5;
    public Text moneyLostText5;
    public GameObject moneyLostGO6;
    public Text moneyLostText6;

    public GameObject moneyGainGO;
    public Text moneyGainText;
    public GameObject moneyGainGO2;
    public Text moneyGainText2;
    public GameObject moneyGainGO3;
    public Text moneyGainText3;
    public GameObject moneyGainGO4;
    public Text moneyGainText4;
    public GameObject moneyGainGO5;
    public Text moneyGainText5;
    public GameObject moneyGainGO6;
    public Text moneyGainText6;

    public int randomDirectionLoss;
    public int randomDirectionGain;

    public static int Rounds;

	void Start ()
	{
        if (LevelSelector.difficulty == 1)
        {
            startLives = 200;
            startMoney = 600;
        }
        if (LevelSelector.difficulty == 2)
        {
            startLives = 150;
            startMoney = 550;
        }
        if (LevelSelector.difficulty == 3)
        {
            startLives = 100;
            startMoney = 500;
        }
        if (LevelSelector.difficulty == 4)
        {
            startLives = 50;
            startMoney = 450;
        }
        if (LevelSelector.difficulty == 5)
        {
            startLives = 1;
            startMoney = 400;
        }

        Money = startMoney;
        Lives = startLives;

		Rounds = 0;
        moneyLostGO.SetActive(false);
        moneyLostGO2.SetActive(false);
        moneyLostGO3.SetActive(false);
        moneyLostGO4.SetActive(false);
        moneyLostGO5.SetActive(false);
        moneyLostGO6.SetActive(false);
        moneyGainGO.SetActive(false);
        moneyGainGO2.SetActive(false);
        moneyGainGO3.SetActive(false);
        moneyGainGO4.SetActive(false);
        moneyGainGO5.SetActive(false);
        moneyGainGO6.SetActive(false);
    }

    private void Update()
    {
        startLivesStatic = startLives;

        if (isMoneyLost == true)
        {
            StartCoroutine(LoseMoney());
            return;
        }
        if (isMoneyGain == true)
        {
            StartCoroutine(GainMoney());
            return;
        }

    }


    IEnumerator LoseMoney()
    {
       
            randomDirectionLoss = Random.Range(1, 7);
            
            if (randomDirectionLoss == 1)
            {
                moneyLostGO.SetActive(true);
                moneyLostText.text = moneyLost.ToString();
                isMoneyLost = false;
                yield return new WaitForSeconds(3);
                moneyLostGO.SetActive(false);
                
                randomDirectionLoss = 0;
            }
            if (randomDirectionLoss == 2)
            {
                moneyLostGO2.SetActive(true);
                moneyLostText2.text = moneyLost.ToString();
                isMoneyLost = false;
                yield return new WaitForSeconds(3);
                moneyLostGO2.SetActive(false);
                
                randomDirectionLoss = 0;
            }
            if (randomDirectionLoss == 3)
            {
                moneyLostGO3.SetActive(true);
                moneyLostText3.text = moneyLost.ToString();
                isMoneyLost = false;
                yield return new WaitForSeconds(3);
                moneyLostGO3.SetActive(false);
                
                randomDirectionLoss = 0;
            }
            if (randomDirectionLoss == 4)
            {
                moneyLostGO4.SetActive(true);
                moneyLostText4.text = moneyLost.ToString();
                isMoneyLost = false;
                yield return new WaitForSeconds(3);
                moneyLostGO4.SetActive(false);
                
                randomDirectionLoss = 0;
            }
            if (randomDirectionLoss == 5)
            {
                moneyLostGO5.SetActive(true);
                moneyLostText5.text = moneyLost.ToString();
                isMoneyLost = false;
                yield return new WaitForSeconds(3);
                moneyLostGO5.SetActive(false);
                
                randomDirectionLoss = 0;
            }
            if (randomDirectionLoss == 6)
            {
                moneyLostGO6.SetActive(true);
                moneyLostText6.text = moneyLost.ToString();
                isMoneyLost = false;
                yield return new WaitForSeconds(3);
                moneyLostGO6.SetActive(false);
                
                randomDirectionLoss = 0;
            }
    }

    IEnumerator GainMoney()
    {
        randomDirectionGain = Random.Range(1, 7);

        if (randomDirectionGain == 1)
        {
            moneyGainGO.SetActive(true);
            moneyGainText.text = moneyGain.ToString();
            isMoneyGain = false;
            yield return new WaitForSeconds(3);
            moneyGainGO.SetActive(false);

            randomDirectionGain = 0;
        }
        if (randomDirectionGain == 2)
        {
            moneyGainGO2.SetActive(true);
            moneyGainText2.text = moneyGain.ToString();
            isMoneyGain = false;
            yield return new WaitForSeconds(3);
            moneyGainGO2.SetActive(false);

            randomDirectionGain = 0;
        }
        if (randomDirectionGain == 3)
        {
            moneyGainGO3.SetActive(true);
            moneyGainText3.text = moneyGain.ToString();
            isMoneyGain = false;
            yield return new WaitForSeconds(3);
            moneyGainGO3.SetActive(false);

            randomDirectionGain = 0;
        }
        if (randomDirectionGain == 4)
        {
            moneyGainGO4.SetActive(true);
            moneyGainText4.text = moneyGain.ToString();
            isMoneyGain = false;
            yield return new WaitForSeconds(3);
            moneyGainGO4.SetActive(false);

            randomDirectionGain = 0;
        }
        if (randomDirectionGain == 5)
        {
            moneyGainGO5.SetActive(true);
            moneyGainText5.text = moneyGain.ToString();
            isMoneyGain = false;
            yield return new WaitForSeconds(3);
            moneyGainGO5.SetActive(false);

            randomDirectionGain = 0;
        }
        if (randomDirectionGain == 6)
        {
            moneyGainGO6.SetActive(true);
            moneyGainText6.text = moneyGain.ToString();
            isMoneyGain = false;
            yield return new WaitForSeconds(3);
            moneyGainGO6.SetActive(false);

            randomDirectionGain = 0;
        }
    }
}
