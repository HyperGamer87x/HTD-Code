using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {

    public static int weather;

    [Header("Heavy Snow")]
    public ParticleSystem heavySnow;
    [Header("Light Snow")]
    public ParticleSystem lightSnow;
    [Header("Heavy Sandstorm")]
    public ParticleSystem heavySand;
    [Header("Light Sandstorm")]
    public ParticleSystem lightSand;

    [Header("Heavy Rain")]
    public ParticleSystem heavyRain1;
    public ParticleSystem heavyRain2;
    public ParticleSystem heavyRain3;
    public ParticleSystem heavyRain4;
    public GameObject heavyRainGO1;
    public GameObject heavyRainGO2;
    public GameObject heavyRainGO3;
    public GameObject heavyRainGO4;
    [Header("Light Rain")]
    public ParticleSystem lightRain1;
    public ParticleSystem lightRain2;
    public ParticleSystem lightRain3;
    public ParticleSystem lightRain4;
    public GameObject lightRainGO1;
    public GameObject lightRainGO2;
    public GameObject lightRainGO3;
    public GameObject lightRainGO4;

    [Header("Darkness")]
    public ParticleSystem darkness1;
    public ParticleSystem darkness2;
    public ParticleSystem darkness3;
    public ParticleSystem darkness4;

    public static bool sceneSwitch;

    private void Start()
    {
        sceneSwitch = false;

        heavyRain1.Stop();
        heavyRain2.Stop();
        heavyRain3.Stop();
        heavyRain4.Stop();
        lightRain1.Stop();
        lightRain2.Stop();
        lightRain3.Stop();
        lightRain4.Stop();
        darkness1.Stop();
        darkness2.Stop();
        darkness3.Stop();
        darkness4.Stop();
        heavySnow.Stop();
        lightSnow.Stop();
        heavySand.Stop();
        lightSand.Stop();
        heavyRainGO1.SetActive(false);
        heavyRainGO2.SetActive(false);
        heavyRainGO3.SetActive(false);
        heavyRainGO4.SetActive(false);
        lightRainGO1.SetActive(false);
        lightRainGO2.SetActive(false);
        lightRainGO3.SetActive(false);
        lightRainGO4.SetActive(false);

        InvokeRepeating("SpawnWeather", 0f, 59f);
    }

    void SpawnWeather()
    {

        if (GameManager.sceneIndex == 1)
        {
            if (GameManager.applyWeatherConditions == true)
            {
                weather = Random.Range(1, 4);
            } else
            {
                weather = 1;
            }
            

            if (weather == 1)
            {
                heavyRain1.Stop();
                heavyRain2.Stop();
                heavyRain3.Stop();
                heavyRain4.Stop();

                lightRain1.Stop();
                lightRain2.Stop();
                lightRain3.Stop();
                lightRain4.Stop();

                heavyRainGO1.SetActive(false);
                heavyRainGO2.SetActive(false);
                heavyRainGO3.SetActive(false);
                heavyRainGO4.SetActive(false);

                lightRainGO1.SetActive(false);
                lightRainGO2.SetActive(false);
                lightRainGO3.SetActive(false);
                lightRainGO4.SetActive(false);

                darkness1.Stop();
                darkness2.Stop();
                darkness3.Stop();
                darkness4.Stop();
                return;
            }
            if (weather == 2)
            {
                heavyRain1.Play();
                heavyRain2.Play();
                heavyRain3.Play();
                heavyRain4.Play();

                lightRain1.Stop();
                lightRain2.Stop();
                lightRain3.Stop();
                lightRain4.Stop();

                heavyRainGO1.SetActive(true);
                heavyRainGO2.SetActive(true);
                heavyRainGO3.SetActive(true);
                heavyRainGO4.SetActive(true);

                lightRainGO1.SetActive(false);
                lightRainGO2.SetActive(false);
                lightRainGO3.SetActive(false);
                lightRainGO4.SetActive(false);

                darkness1.Play();
                darkness2.Play();
                darkness3.Stop();
                darkness4.Stop();
                return;
            }
            if (weather == 3)
            {
                heavyRain1.Stop();
                heavyRain2.Stop();
                heavyRain3.Stop();
                heavyRain4.Stop();

                lightRain1.Play();
                lightRain2.Play();
                lightRain3.Play();
                lightRain4.Play();

                heavyRainGO1.SetActive(false);
                heavyRainGO2.SetActive(false);
                heavyRainGO3.SetActive(false);
                heavyRainGO4.SetActive(false);

                lightRainGO1.SetActive(true);
                lightRainGO2.SetActive(true);
                lightRainGO3.SetActive(true);
                lightRainGO4.SetActive(true);

                darkness1.Stop();
                darkness2.Stop();
                darkness3.Play();
                darkness4.Play();
                return;
            }
            if (weather == 4)
            {

                return;
            }
            return;
        }
        if (GameManager.sceneIndex == 2)
        {
            if (GameManager.applyWeatherConditions == true)
            {
                weather = Random.Range(1, 4);
            } else
            {
                weather = 1;
            }
            
            if (weather == 1)
            {
                heavySnow.Stop();
                lightSnow.Stop();
                return;
            }
            if (weather == 2)
            {
                heavySnow.Play();
                lightSnow.Stop();
                return;
            }
            if (weather == 3)
            {
                heavySnow.Stop();
                lightSnow.Play();
                return;
            }
        }
       
        if (GameManager.sceneIndex == 4)
        {
            if (GameManager.applyWeatherConditions == true)
            {
                weather = Random.Range(1, 4);
            }
            else
            {
                weather = 1;
            }

            if (weather == 1)
            {
                heavySand.Stop();
                lightSand.Stop();
                return;
            }
            if (weather == 2)
            {
                heavySand.Play();
                lightSand.Stop();
                return;
            }
            if (weather == 3)
            {
                heavySand.Stop();
                lightSand.Play();
                return;
            }
        }
        else
        {
            return;
        }

        if (GameManager.sceneIndex == 6)
        {
            if (GameManager.applyWeatherConditions == true)
            {
                weather = Random.Range(1, 4);
            }
            else
            {
                weather = 1;
            }


            if (weather == 1)
            {
                heavyRain1.Stop();
                heavyRain2.Stop();
                heavyRain3.Stop();
                heavyRain4.Stop();

                lightRain1.Stop();
                lightRain2.Stop();
                lightRain3.Stop();
                lightRain4.Stop();

                heavyRainGO1.SetActive(false);
                heavyRainGO2.SetActive(false);
                heavyRainGO3.SetActive(false);
                heavyRainGO4.SetActive(false);

                lightRainGO1.SetActive(false);
                lightRainGO2.SetActive(false);
                lightRainGO3.SetActive(false);
                lightRainGO4.SetActive(false);

                darkness1.Stop();
                darkness2.Stop();
                darkness3.Stop();
                darkness4.Stop();
                return;
            }
            if (weather == 2)
            {
                heavyRain1.Play();
                heavyRain2.Play();
                heavyRain3.Play();
                heavyRain4.Play();

                lightRain1.Stop();
                lightRain2.Stop();
                lightRain3.Stop();
                lightRain4.Stop();

                heavyRainGO1.SetActive(true);
                heavyRainGO2.SetActive(true);
                heavyRainGO3.SetActive(true);
                heavyRainGO4.SetActive(true);

                lightRainGO1.SetActive(false);
                lightRainGO2.SetActive(false);
                lightRainGO3.SetActive(false);
                lightRainGO4.SetActive(false);

                darkness1.Play();
                darkness2.Play();
                darkness3.Stop();
                darkness4.Stop();
                return;
            }
            if (weather == 3)
            {
                heavyRain1.Stop();
                heavyRain2.Stop();
                heavyRain3.Stop();
                heavyRain4.Stop();

                lightRain1.Play();
                lightRain2.Play();
                lightRain3.Play();
                lightRain4.Play();

                heavyRainGO1.SetActive(false);
                heavyRainGO2.SetActive(false);
                heavyRainGO3.SetActive(false);
                heavyRainGO4.SetActive(false);

                lightRainGO1.SetActive(true);
                lightRainGO2.SetActive(true);
                lightRainGO3.SetActive(true);
                lightRainGO4.SetActive(true);

                darkness1.Stop();
                darkness2.Stop();
                darkness3.Play();
                darkness4.Play();
                return;
            }
            if (weather == 4)
            {

                return;
            }
            return;
        }
    }

    private void Update()
    {
        if (sceneSwitch == true)
        {
            SpawnWeather();
            sceneSwitch = false;
        }
        if (sceneSwitch == false)
        {
            return;
        }
    }

}
