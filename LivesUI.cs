using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

	public Text livesText;
    public Text livesText2;


    private void Start()
    {
        InvokeRepeating("UpdateNew", 0f, 0.05f);

    }

    void UpdateNew () {
        if (PlayerStats.Lives == 1)
        {
            livesText.text = PlayerStats.Lives.ToString() + " LIFE";
            livesText2.text = PlayerStats.Lives.ToString() + " LIFE";
        } else
        {
            livesText.text = PlayerStats.Lives.ToString() + " LIVES";
            livesText2.text = PlayerStats.Lives.ToString() + " LIVES";
        }

        if (PlayerStats.startLivesStatic / PlayerStats.Lives > 0 && PlayerStats.startLivesStatic / PlayerStats.Lives <= 1)
        {
            livesText.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
            livesText2.color = new Color(28.0f / 255.0f, 158.0f / 255.0f, 34.0f / 255.0f);
        }
        if (PlayerStats.startLivesStatic / PlayerStats.Lives > 1 && PlayerStats.startLivesStatic / PlayerStats.Lives <= 2)
        {
            livesText.color = new Color(174.0f / 255.0f, 176.0f / 255.0f, 34.0f / 255.0f);
            livesText2.color = new Color(174.0f / 255.0f, 176.0f / 255.0f, 34.0f / 255.0f);
        }
        if (PlayerStats.startLivesStatic / PlayerStats.Lives > 2  && PlayerStats.startLivesStatic / PlayerStats.Lives <= 4)
        {
            livesText.color = new Color(174.0f / 255.0f, 98.0f / 255.0f, 8.0f / 255.0f);
            livesText2.color = new Color(174.0f / 255.0f, 98.0f / 255.0f, 8.0f / 255.0f);
        }
        if (PlayerStats.startLivesStatic / PlayerStats.Lives > 4 && PlayerStats.startLivesStatic / PlayerStats.Lives <= 10)
        {
            livesText.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
            livesText2.color = new Color(176.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f);
        }


    }
}
