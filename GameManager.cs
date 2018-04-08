using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
    
    public static int sceneIndex;
    public static int oldSceneIndex;

    public bool musicOn;
    public int musicPlaying;
    public bool musicIsFading;

    public static int oldWeather;

    private AudioSource track0;
    private AudioSource track1;
    private AudioSource track2;
    private AudioSource bullet;
    private AudioSource missile;
    private AudioSource plasma;
    private AudioSource laser;
    private AudioSource rainH;
    private AudioSource rainL;
    private AudioSource track3;
    private AudioSource track4;
    private AudioSource track5;
    private AudioSource wind;
    private AudioSource fireworks;
    private AudioSource freeze;
    private AudioSource windBoom;

    public static bool weatherConditions = true;
    public static bool applyWeatherConditions = true;
    public static bool hints = true;
    public static bool applyHints = true;

    void Start ()
	{
        AudioSource[] soundTracks = GetComponents<AudioSource>();

        track0 = soundTracks[0];
        track1 = soundTracks[1];
        track2 = soundTracks[2];
        bullet = soundTracks[3];
        missile = soundTracks[4];
        plasma = soundTracks[5];
        laser = soundTracks[6];
        rainH = soundTracks[7];
        rainL = soundTracks[8];
        track3 = soundTracks[9];
        track4 = soundTracks[10];
        track5 = soundTracks[11];
        wind = soundTracks[12];
        fireworks = soundTracks[13];
        freeze = soundTracks[14];
        //windBoom = soundTracks[15];

        oldWeather = 0;

        if (Extras.volumeChange == false)
        {
            Extras.soundMusicValue = 1f;
            Extras.soundSFXValue = 1f;
            Extras.soundWeatherValue = 1f;
        }
        if (Extras.optionsChange == false)
        {
            weatherConditions = true;
            hints = true;
        }

        PauseMenu.paused = false;

        musicOn = false;
        musicIsFading = false;
        oldSceneIndex = sceneIndex;
        GameIsOver = false;
        InvokeRepeating("WhichScene", 0f, 0.5f);
        InvokeRepeating("Laser", 0f, 0.2f);
        InvokeRepeating("Fireworks", 0f, 6f);
    }

    // Update is called once per frame
    void Update () {

        if (oldWeather != Weather.weather)
        {
            if (sceneIndex == 1)
            {
                if (Weather.weather == 1)
                {
                    rainH.Stop();
                    rainL.Stop();
                    oldWeather = Weather.weather;
                }
                if (Weather.weather == 2)
                {
                    rainH.Play();
                    rainL.Stop();
                    oldWeather = Weather.weather;
                }
                if (Weather.weather == 3)
                {
                    rainH.Stop();
                    rainL.Play();
                    oldWeather = Weather.weather;
                }
            }
            if (sceneIndex == 4)
            {
                if (Weather.weather == 1)
                {
                    wind.Stop();
                    oldWeather = Weather.weather;
                }
                if (Weather.weather == 2)
                {
                    wind.Play();
                    oldWeather = Weather.weather;
                }
                if (Weather.weather == 3)
                {
                    wind.Play();
                    oldWeather = Weather.weather;
                }
            }
            if (sceneIndex == 6)
            {
                if (Weather.weather == 1)
                {
                    rainH.Stop();
                    rainL.Stop();
                    oldWeather = Weather.weather;
                }
                if (Weather.weather == 2)
                {
                    rainH.Play();
                    rainL.Stop();
                    oldWeather = Weather.weather;
                }
                if (Weather.weather == 3)
                {
                    rainH.Stop();
                    rainL.Play();
                    oldWeather = Weather.weather;
                }
            }

        }

        track0.volume = Extras.transferSoundMusicValue;
        track1.volume = Extras.transferSoundMusicValue;
        track2.volume = Extras.transferSoundMusicValue;
        bullet.volume = Extras.transferSoundSFXValue;
        missile.volume = Extras.transferSoundSFXValue;
        plasma.volume = Extras.transferSoundSFXValue;
        laser.volume = Extras.transferSoundSFXValue;
        rainH.volume = Extras.transferSoundWeatherValue;
        rainL.volume = Extras.transferSoundWeatherValue;
        track3.volume = Extras.transferSoundMusicValue;
        track4.volume = Extras.transferSoundMusicValue;
        track5.volume = Extras.transferSoundMusicValue;
        wind.volume = Extras.transferSoundWeatherValue;
        fireworks.volume = Extras.transferSoundSFXValue;
        freeze.volume = Extras.transferSoundSFXValue;
       // windBoom.volume = Extras.transferSoundSFXValue;

        if (PauseMenu.paused == true)
        {
            track0.Pause();
            track1.Pause();
            track2.Pause();
            bullet.Pause();
            missile.Pause();
            plasma.Pause();
            laser.Pause();
            rainH.Pause();
            rainL.Pause();
            track3.Pause();
            track4.Pause();
            track5.Pause();
            wind.Pause();
            fireworks.Pause();
            freeze.Pause();
           // windBoom.Pause();
        }
        else
        {
            track0.UnPause();
            track1.UnPause();
            track2.UnPause();
            bullet.UnPause();
            missile.UnPause();
            plasma.UnPause();
            laser.UnPause();
            rainH.UnPause();
            rainL.UnPause();
            track3.UnPause();
            track4.UnPause();
            track5.UnPause();
            wind.UnPause();
            fireworks.UnPause();
            freeze.UnPause();
          //  windBoom.UnPause();
        }

        if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}

        if (Bullet.bulletHit == true)
        {
            bullet.Play();
            Bullet.bulletHit = false;
        }
        if (Bullet.missileHit == true)
        {
            missile.Play();
            Bullet.missileHit = false;
        }
        if (Enemy.iceHit == true)
        {
            freeze.Play();
            bullet.Stop();
            Enemy.iceHit = false;
        }
        

        if (sceneIndex != 0)
            {
            

            if (GameIsOver == false || WaveSpawner.EnemiesAlive > 0)
            {
                if (musicOn == false)
                {
                    musicPlaying = Random.Range(0, 6);

                    if (musicPlaying == 0)
                    {
                        track0.Play();

                    }
                    if (musicPlaying == 1)
                    {
                        track1.Play();
                    }
                    if (musicPlaying == 2)
                    {
                        track2.Play();
                    }
                    if (musicPlaying == 3)
                    {
                        track3.Play();

                    }
                    if (musicPlaying == 4)
                    {
                        track4.Play();
                    }
                    if (musicPlaying == 5)
                    {
                        track5.Play();
                    }


                    musicOn = true;
                }
            }
            

            
        }
        


    }

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
        StartCoroutine(FadeMusicOut());

    }

    public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
        StartCoroutine(FadeMusicOut());

    }

    void WhichScene()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            sceneIndex = 0;
            //Debug.Log("0");
        }
        if (sceneName == "Backyard")
        {
            sceneIndex = 1;
            //Debug.Log("1");
        }
        if (sceneName == "SnowTown")
        {
            sceneIndex = 2;
            //Debug.Log("2");

        }
        if (sceneName == "Building")
        {
            sceneIndex = 3;
            //Debug.Log("3");

        }
        if (sceneName == "Desert")
        {
            sceneIndex = 4;
            //Debug.Log("3");

        }
        if (sceneName == "Bonfire")
        {
            sceneIndex = 5;
            //Debug.Log("3");

        }
        if (sceneName == "Highway")
        {
            sceneIndex = 6;
            //Debug.Log("1");
        }

    }

    IEnumerator FadeMusicOut()
    {
        if (Extras.soundMusicValue > 0)
        {
            musicIsFading = true;
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            yield return new WaitForSeconds(0.1f);
            Extras.soundMusicValue = Extras.soundMusicValue - 0.05f;
            musicIsFading = false;
            musicOn = false;
            Extras.soundMusicValue = 0f;
        }
    }

    void Laser()
    {
        if (Turret.laserOn == true)
        {
            if (Turret.laserBeamerStatic == true)
            {
                laser.Play();
            }
            if (Turret.laserBeamerStatic == false)
            {
                //windBoom.Play();
            }
        }
        else
        {
            if (Turret.laserBeamerStatic == true)
            {
                laser.Stop();
            }
            if (Turret.laserBeamerStatic == false)
            {
                //windBoom.Stop();
            }
        }
    }

    void Fireworks()
    {
        if (sceneIndex == 5)
        {
            fireworks.Play();
        } else
        {
            fireworks.Stop();
        }
    }

}
