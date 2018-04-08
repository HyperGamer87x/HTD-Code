using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bill : MonoBehaviour {

    public GameObject text;

    public Text changeText;

    public GameObject attention;
    
    public static int textNumber = 0;
    public static bool more = true;
    public static bool canPlay = false;
    public static bool attentionPerspect = false;

    private void Start()
    {
        attention.SetActive(false);
        
        changeText.text = "Hey! I'm Bill. I'm here to give useful tips for future waves. To navigate to the next page, press the right arrow key!";

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (more == true)
            {
                textNumber = textNumber + 1;
            }
           
            if (textNumber == 1)
            {
                changeText.text = "I will let you know if I have any important information to share with you. Now go kill some enemies!";
            }
            if (textNumber == 2)
            {
                changeText.text = "You can only interact with me though between waves, but not during waves. Use the space bar to toggle between the track and me. Good Luck!";
                more = false;
                canPlay = true;
            }
            
        }

        if (WaveSpawner.EnemiesAlive > 0)
        {
            attention.SetActive(false);
            attentionPerspect = false;
        }

        if (WaveSpawner.waveNumber == 4 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 3;
            changeText.text = "Next wave contains some stronger enemies. Don't panic though, they are slower than usual!";
            attentionPerspect = true;
        }

        if (WaveSpawner.waveNumber == 7 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 4;
            changeText.text = "Beware of the fast enemies. They are indeed fast, but not extremely strong!";
            attentionPerspect = true;
        }

        if (WaveSpawner.waveNumber == 9 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 5;
            changeText.text = "Ice enemies will attack in a couple more waves. Make sure you use explosions to destroy them! Non-explosive towers will not attempt to smash these.";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 14 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 6;
            changeText.text = "A new enemy type will appear soon that not all towers can destroy. I'll give you a hint though. Lasers melt metal easily.";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 21 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 7;
            changeText.text = "Trio enemies are the first three enemies built into one. Be careful.";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 29 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 8;
            changeText.text = "The armoured enemies will strike next round. Your towers will really need to work together to destroy these.";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 34 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 9;
            changeText.text = "Looks like the five original enemies are working on an upgrade!";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 40 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 10;
            changeText.text = "You can probably guess what the motor enemy is going to be like.";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 44 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 11;
            changeText.text = "Nothing can beat Golden enemies. Enemies made out of gold are even tougher than armour.";
            attentionPerspect = true;
        }
        if (WaveSpawner.waveNumber == 53 && WaveSpawner.EnemiesAlive == 0)
        {
            attention.SetActive(true);
            textNumber = 11;
            changeText.text = "Looks like the enemies are starting to retreat. Keep it up!";
            attentionPerspect = true;
        }
    }
}

