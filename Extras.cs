using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class Extras : MonoBehaviour {

    public SceneFader sceneFader;

    public string menu;
    public string credits;
    

    [Header("Types")]
    public GameObject extrasGO;
    public GameObject towersGO;
    public GameObject towersGO2;
    public GameObject hotkeysGO;
    public GameObject soundGO;
    public GameObject optionsGO;

    [Header("PartToRotate")]
    public GameObject turretPTR;
    public GameObject launcherPTR;
    public GameObject beamerPTR;
    public GameObject dartlingPTR;
    public GameObject blasterPTR;
    public GameObject windPTR;
    public GameObject turretPTRU1;
    public GameObject launcherPTRU1;
    public GameObject beamerPTRU1;
    public GameObject dartlingPTRU1;
    public GameObject blasterPTRU1;
    public GameObject windPTRU1;
    public GameObject turretPTRU2;
    public GameObject launcherPTRU2;
    public GameObject beamerPTRU2;
    public GameObject dartlingPTRU2;
    public GameObject blasterPTRU2;
    public GameObject windPTRU2;
    public GameObject turretPTRU3;
    public GameObject launcherPTRU3;
    public GameObject beamerPTRU3;
    public GameObject dartlingPTRU3;
    public GameObject blasterPTRU3;
    public GameObject windPTRU3;

    [Header("Tower GameObjects")]
    public GameObject turretPrefab;
    public GameObject launcherPrefab;
    public GameObject beamerPrefab;
    public GameObject dartlingPrefab;
    public GameObject blasterPrefab;
    public GameObject windPrefab;
    public GameObject turretPrefabU1;
    public GameObject launcherPrefabU1;
    public GameObject beamerPrefabU1;
    public GameObject dartlingPrefabU1;
    public GameObject blasterPrefabU1;
    public GameObject windPrefabU1;
    public GameObject turretPrefabU2;
    public GameObject launcherPrefabU2;
    public GameObject beamerPrefabU2;
    public GameObject dartlingPrefabU2;
    public GameObject blasterPrefabU2;
    public GameObject windPrefabU2;
    public GameObject turretPrefabU3;
    public GameObject launcherPrefabU3;
    public GameObject beamerPrefabU3;
    public GameObject dartlingPrefabU3;
    public GameObject blasterPrefabU3;
    public GameObject windPrefabU3;

    [Header("Towers")]
    public bool towers;
    public int turretShown;
    public int maxTowers;
    public Text towerTitle;
    public Button towersRightArrow;
    public Button towersLeftArrow;
    public int towerLevel;

    [Header("Sound")]
    public Scrollbar soundMusic;
    public Scrollbar soundMaster;
    public Scrollbar soundSFX;
    public Scrollbar soundWeather;
    public Toggle toggleMusic;
    public Toggle toggleMaster;
    public Toggle toggleSFX;
    public Toggle toggleWeather;
    public static float soundMasterValue;
    public static float soundMusicValue;
    public static float soundSFXValue;
    public static float soundWeatherValue;
    public static float applySoundMasterValue = 1f;
    public static float applySoundMusicValue = 1f;
    public static float applySoundSFXValue = 1f;
    public static float applySoundWeatherValue = 1f;
    public static float oldSoundMasterValue;
    public static bool volumeChange = false;
    public static bool optionsChange = false;
    public static float transferSoundMusicValue = 1f;
    public static float transferSoundMasterValue = 1f;
    public static float transferSoundSFXValue = 1f;
    public static float transferSoundWeatherValue = 1f;
    public bool soundSelected = false;

    [Header("Options")]
    public Button weatherOn;
    public Button weatherOff;
    public Button hintsOn;
    public Button hintsOff;

    private void Start()
    {
        towers = false;
        towerTitle.text = "Turret";
        towersGO.SetActive(false);
        towersGO2.SetActive(false);
        hotkeysGO.SetActive(false);
        extrasGO.SetActive(true);
        soundGO.SetActive(false);
        optionsGO.SetActive(false);
        towerLevel = 1;

        turretPrefab.SetActive(false);
        launcherPrefab.SetActive(false);
        beamerPrefab.SetActive(false);
        dartlingPrefab.SetActive(false);
        turretPrefabU1.SetActive(false);
        launcherPrefabU1.SetActive(false);
        beamerPrefabU1.SetActive(false);
        dartlingPrefabU1.SetActive(false);
        turretPrefabU2.SetActive(false);
        launcherPrefabU2.SetActive(false);
        beamerPrefabU2.SetActive(false);
        dartlingPrefabU2.SetActive(false);
        turretPrefabU3.SetActive(false);
        launcherPrefabU3.SetActive(false);
        beamerPrefabU3.SetActive(false);
        dartlingPrefabU3.SetActive(false);

        oldSoundMasterValue = soundMaster.value;
        volumeChange = true;
        optionsChange = true;

        soundMusic.value = transferSoundMusicValue;
        soundMaster.value = transferSoundMasterValue;
        soundSFX.value = transferSoundSFXValue;
        soundWeather.value = transferSoundWeatherValue;

        InvokeRepeating("SpinTower", 0f, 0.005f);
        InvokeRepeating("UpdateNew", 0f, 0.05f);

    }

    private void UpdateNew()
    {
        soundMusicValue = soundMusic.value;
        soundMasterValue = soundMaster.value;
        soundSFXValue = soundSFX.value;
        soundWeatherValue = soundWeather.value;

        if (soundSelected == true)
        {
            transferSoundMusicValue = soundMusic.value;
            transferSoundMasterValue = soundMaster.value;
            transferSoundSFXValue = soundSFX.value;
            transferSoundWeatherValue = soundWeather.value;
        }

        if (soundMusic.value > soundMaster.value)
        {
            soundMusic.value = soundMaster.value;
        }
        if (soundSFX.value > soundMaster.value)
        {
            soundSFX.value = soundMaster.value;
        }
        if (soundWeather.value > soundMaster.value)
        {
            soundWeather.value = soundMaster.value;
        }

        if (toggleMaster.isOn == true)
        {
            soundMaster.interactable = true;
        }
        if (toggleMusic.isOn == true)
        {
            soundMusic.interactable = true;
        }
        if (toggleSFX.isOn == true)
        {
            soundSFX.interactable = true;
        }
        if (toggleWeather.isOn == true)
        {
            soundWeather.interactable = true;
        }
        if (toggleMaster.isOn == false)
        {
            soundMaster.interactable = false;
            soundMusic.interactable = false;
            soundSFX.interactable = false;
            soundWeather.interactable = false;
            soundMaster.value = 0f;
        }
        if (toggleMusic.isOn == false)
        {
            soundMusic.interactable= false;
            soundMusic.value = 0f;
        }
        if (toggleSFX.isOn == false)
        {
            soundSFX.interactable = false;
            soundSFX.value = 0f;
        }
        if (toggleWeather.isOn == false)
        {
            soundWeather.interactable = false;
            soundWeather.value = 0f;
        }


        if (turretShown == maxTowers)
        {
            towersRightArrow.interactable = false;
        } else
        {
            towersRightArrow.interactable = true;
        }

        if (turretShown == 1)
        {
            towersLeftArrow.interactable = false;
            towerTitle.text = " STANDARD TURRET";

            if (towerLevel == 1)
            {
                turretPrefab.SetActive(true);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 2)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(true);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 3)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(true);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 4)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(true);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }

        }
        else
        {
            towersLeftArrow.interactable = true;
        }

        if (turretShown == 2)
        {
            towerTitle.text = "MISSILE LAUNCHER";

            if (towerLevel == 1)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(true);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 2)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(true);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 3)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(true);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 4)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(true);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
        }

        if (turretShown == 3)
        {
            towerTitle.text = "LASER BEAMER";

            if (towerLevel == 1)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(true);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 2)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(true);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 3)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(true);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 4)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(true);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
        }

        if (turretShown == 4)
        {
            towerTitle.text = "DARTLING GUN";

            if (towerLevel == 1)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(true);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 2)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(true);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 3)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(true);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 4)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(true);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
        }
        if (turretShown == 5)
        {
            towerTitle.text = "ICE BLASTER";

            if (towerLevel == 1)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(true);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 2)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(true);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 3)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(true);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 4)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(true);
                windPrefabU3.SetActive(false);
            }
        }
        if (turretShown == 6)
        {
            towerTitle.text = "WIND GENERATOR";

            if (towerLevel == 1)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(true);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 2)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(true);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 3)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(true);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(false);
            }
            if (towerLevel == 4)
            {
                turretPrefab.SetActive(false);
                launcherPrefab.SetActive(false);
                beamerPrefab.SetActive(false);
                dartlingPrefab.SetActive(false);
                blasterPrefab.SetActive(false);
                windPrefab.SetActive(false);
                turretPrefabU1.SetActive(false);
                launcherPrefabU1.SetActive(false);
                beamerPrefabU1.SetActive(false);
                dartlingPrefabU1.SetActive(false);
                blasterPrefabU1.SetActive(false);
                windPrefabU1.SetActive(false);
                turretPrefabU2.SetActive(false);
                launcherPrefabU2.SetActive(false);
                beamerPrefabU2.SetActive(false);
                dartlingPrefabU2.SetActive(false);
                blasterPrefabU2.SetActive(false);
                windPrefabU2.SetActive(false);
                turretPrefabU3.SetActive(false);
                launcherPrefabU3.SetActive(false);
                beamerPrefabU3.SetActive(false);
                dartlingPrefabU3.SetActive(false);
                blasterPrefabU3.SetActive(false);
                windPrefabU3.SetActive(true);
            }
        }


    }

    public void Towers ()
    {
        towers = true;
        turretShown = 1;
        towerLevel = 1;
        towersGO.SetActive(true);
        towersGO2.SetActive(true);
        extrasGO.SetActive(false);
        hotkeysGO.SetActive(false);
        soundGO.SetActive(false);
        optionsGO.SetActive(false);
    }

    public void TowersRightArrow ()
    {
        turretShown = turretShown + 1;
    }

    public void TowersLeftArrow ()
    {
        turretShown = turretShown - 1;
    }

    public void Level1 ()
    {
        towerLevel = 1;
    }

    public void Level2 ()
    {
        towerLevel = 2;
    }

    public void Level3 ()
    {
        towerLevel = 3;
    }

    public void Level4 ()
    {
        towerLevel = 4;
    }

    public void Level5 ()
    {
        towerLevel = 5;
    }

    void SpinTower()
    {
        turretPTR.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        launcherPTR.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        beamerPTR.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        dartlingPTR.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        blasterPTR.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        windPTR.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        turretPTRU1.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        launcherPTRU1.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        beamerPTRU1.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        dartlingPTRU1.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        blasterPTRU1.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        windPTRU1.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        turretPTRU2.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        launcherPTRU2.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        beamerPTRU2.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        dartlingPTRU2.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        blasterPTRU2.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        windPTRU2.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        turretPTRU3.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        launcherPTRU3.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        beamerPTRU3.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        dartlingPTRU3.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
        blasterPTRU3.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);
       // windPTRU3.transform.Rotate(0, 0.5f, 0 * Time.deltaTime);


    }

    public void ExtrasMenu ()
    {
        extrasGO.SetActive(true);
        towersGO.SetActive(false);
        towersGO2.SetActive(false);
        hotkeysGO.SetActive(false);
        soundGO.SetActive(false);
        optionsGO.SetActive(false);

        GameManager.applyWeatherConditions = GameManager.weatherConditions;
        GameManager.applyHints = GameManager.hints;

        soundSelected = false;
    }

    public void Hotkeys ()
    {
        extrasGO.SetActive(false);
        towersGO.SetActive(false);
        towersGO2.SetActive(false);
        hotkeysGO.SetActive(true);
        soundGO.SetActive(false);
        optionsGO.SetActive(false);
    }

    public void Sound ()
    {
        extrasGO.SetActive(false);
        towersGO.SetActive(false);
        towersGO2.SetActive(false);
        hotkeysGO.SetActive(false);
        soundGO.SetActive(true);
        optionsGO.SetActive(false);

        if (applySoundMasterValue != soundMaster.value)
        {
            soundMaster.value = applySoundMasterValue;
            soundMusic.value = applySoundMusicValue;
            soundSFX.value = applySoundSFXValue;
            soundWeather.value = applySoundWeatherValue;
        }

        soundSelected = true;
    }

    public void Options ()
    {
        extrasGO.SetActive(false);
        towersGO.SetActive(false);
        towersGO2.SetActive(false);
        hotkeysGO.SetActive(false);
        soundGO.SetActive(false);
        optionsGO.SetActive(true);

        if (GameManager.applyWeatherConditions != GameManager.weatherConditions)
        {
            GameManager.weatherConditions = GameManager.applyWeatherConditions;

            if (GameManager.weatherConditions == true)
            {
                weatherOn.interactable = false;
                weatherOff.interactable = true;
            } else
            {
                weatherOn.interactable = true;
                weatherOff.interactable = false;
            }
        }

        if (GameManager.applyHints != GameManager.hints)
        {
            GameManager.hints = GameManager.applyHints;

            if (GameManager.hints == true)
            {
                hintsOn.interactable = false;
                hintsOff.interactable = true;
            }
            else
            {
                hintsOn.interactable = true;
                hintsOff.interactable = false;
            }
        }
    }

    public void Menu ()
    {
        sceneFader.FadeTo(menu);
        applySoundMasterValue = soundMaster.value;
        applySoundMusicValue = soundMusic.value;
        applySoundSFXValue = soundSFX.value;
        applySoundWeatherValue = soundWeather.value;
        
       
    }

    public void WeatherConditionsON()
    {
        GameManager.weatherConditions = true;
        weatherOn.interactable = false;
        weatherOff.interactable = true;

    }

    public void WeatherConditionsOFF()
    {
        GameManager.weatherConditions = false;
        weatherOn.interactable = true;
        weatherOff.interactable = false;
    }

    public void HintsON ()
    {
        GameManager.hints = true;
        hintsOn.interactable = false;
        hintsOff.interactable = true;
    }

    public void HintsOFF ()
    {
        GameManager.hints = false;
        hintsOn.interactable = true;
        hintsOff.interactable = false;
    }

    public void Credits ()
    {
        extrasGO.SetActive(false);
        towersGO.SetActive(false);
        towersGO2.SetActive(false);
        hotkeysGO.SetActive(false);
        soundGO.SetActive(false);
        optionsGO.SetActive(false);

        sceneFader.FadeTo(credits);
    }

}
