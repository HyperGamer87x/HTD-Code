using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;
    public GameObject turretUI;
    public bool turretUiWasActive = false;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

    public static bool paused;

    [Header("Extras")]
    public GameObject pauseMenu;
    public GameObject extrasMenu;
    public GameObject hotkeysMenu;
    public GameObject soundMenu;
    public GameObject optionsMenu;

    [Header("Sound")]
    public Scrollbar soundMusic;
    public Scrollbar soundMaster;
    public Scrollbar soundSFX;
    public Scrollbar soundWeather;
    public Toggle toggleMusic;
    public Toggle toggleMaster;
    public Toggle toggleSFX;
    public Toggle toggleWeather;
    public bool soundSelected = false;

    [Header("Options")]
    public Button weatherOn;
    public Button weatherOff;
    public Button hintsOn;
    public Button hintsOff;

    private void Start()
    {
        
        soundMusic.value = Extras.transferSoundMusicValue;
        soundMaster.value = Extras.transferSoundMasterValue;
        soundSFX.value = Extras.transferSoundSFXValue;
        soundWeather.value = Extras.transferSoundWeatherValue;

    }

    void Update ()
	{
        

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
            soundMusic.interactable = false;
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

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}

        if (soundSelected == true)
        {
            Extras.transferSoundMusicValue = soundMusic.value;
            Extras.transferSoundMasterValue = soundMaster.value;
            Extras.transferSoundSFXValue = soundSFX.value;
            Extras.transferSoundWeatherValue = soundWeather.value;
        }

        
    }

	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            extrasMenu.SetActive(false);
            hotkeysMenu.SetActive(false);
            soundMenu.SetActive(false);
            optionsMenu.SetActive(false);
            paused = true;
            turretUI.SetActive(false);
        } else
		{
			Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            extrasMenu.SetActive(false);
            hotkeysMenu.SetActive(false);
            soundMenu.SetActive(false);
            optionsMenu.SetActive(false);
            paused = false;
            turretUI.SetActive(true);
        }
	}

	public void Retry ()
	{
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        WaveSpawner.resetWave = true;
    }

	public void Menu ()
	{
		Toggle();
		sceneFader.FadeTo(menuSceneName);
        WaveSpawner.resetWave = true;
    }

    public void ExtrasMenu ()
    {
        pauseMenu.SetActive(false);
        extrasMenu.SetActive(true);
        hotkeysMenu.SetActive(false);
        soundMenu.SetActive(false);
        optionsMenu.SetActive(false);

        GameManager.applyWeatherConditions = GameManager.weatherConditions;
        GameManager.applyHints = GameManager.hints;
    }

    public void Hotkeys ()
    {
        pauseMenu.SetActive(false);
        extrasMenu.SetActive(false);
        hotkeysMenu.SetActive(true);
        soundMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Sound ()
    {
        pauseMenu.SetActive(false);
        extrasMenu.SetActive(false);
        hotkeysMenu.SetActive(false);
        soundMenu.SetActive(true);
        optionsMenu.SetActive(false);

        soundSelected = true;
    }
    
    public void Options ()
    {

        pauseMenu.SetActive(false);
        extrasMenu.SetActive(false);
        hotkeysMenu.SetActive(false);
        soundMenu.SetActive(false);
        optionsMenu.SetActive(true);

        if (GameManager.applyWeatherConditions != GameManager.weatherConditions)
        {
            GameManager.weatherConditions = GameManager.applyWeatherConditions;

            if (GameManager.weatherConditions == true)
            {
                weatherOn.interactable = false;
                weatherOff.interactable = true;
            }
            else
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

    public void Pause ()
    {
        pauseMenu.SetActive(true);
        extrasMenu.SetActive(false);
        hotkeysMenu.SetActive(false);
        soundMenu.SetActive(false);
        optionsMenu.SetActive(false);

        soundSelected = false;
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

    public void HintsON()
    {
        GameManager.hints = true;
        hintsOn.interactable = false;
        hintsOff.interactable = true;
    }

    public void HintsOFF()
    {
        GameManager.hints = false;
        hintsOn.interactable = true;
        hintsOff.interactable = false;
    }


}
