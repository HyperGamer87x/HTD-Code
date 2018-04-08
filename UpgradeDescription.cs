using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDescription : MonoBehaviour {

    
    public GameObject arrow;
    public GameObject upgradeDescriptionBG;
    public GameObject upgradeDescription;
    public Text upgradeDescriptionText;
    public GameObject upgradeTextBG;
    public GameObject upgradeText;
    public Text upgradeTextText;
    public GameObject upgradeStatsBG;
    public GameObject damageStats;
    public GameObject speedStats;
    public GameObject radiusStats;
    public GameObject rangeStats;
    public GameObject rateStats;
    public GameObject slowStats;
    public GameObject enemySStats;

    public GameObject damageBarNowGO;
    public GameObject damageBarUpgradeGO;
    public GameObject speedBarNowGO;
    public GameObject speedBarUpgradeGO;
    public GameObject radiusBarNowGO;
    public GameObject radiusBarUpgradeGO;
    public GameObject rangeBarNowGO;
    public GameObject rangeBarUpgradeGO;
    public GameObject rateBarNowGO;
    public GameObject rateBarUpgradeGO;
    public GameObject slowBarNowGO;
    public GameObject slowBarUpgradeGO;
    public GameObject enemySBarNowGO;
    public GameObject enemySBarUpgradeGO;

    public Image damageBarNow;
    public Image damageBarUpgrade;
    public Image speedBarNow;
    public Image speedBarUpgrade;
    public Image radiusBarNow;
    public Image radiusBarUpgrade;
    public Image rangeBarNow;
    public Image rangeBarUpgrade;
    public Image rateBarNow;
    public Image rateBarUpgrade;
    public Image slowBarNow;
    public Image slowBarUpgrade;
    public Image enemySBarNow;
    public Image enemySBarUpgrade;

    public GameObject turretPrefab;
    public GameObject launcherPrefab;
    public GameObject beamerPrefab;
    public GameObject dartlingPrefab;
    public GameObject turretPrefabU1;
    public GameObject launcherPrefabU1;
    public GameObject beamerPrefabU1;
    public GameObject dartlingPrefabU1;
    public GameObject turretPrefabU2;
    public GameObject launcherPrefabU2;
    public GameObject beamerPrefabU2;
    public GameObject dartlingPrefabU2;
    public GameObject turretPrefabU3;
    public GameObject launcherPrefabU3;
    public GameObject beamerPrefabU3;
    public GameObject dartlingPrefabU3;

    public static bool isInformationShown = false;
    public static bool isStatisticsShown = false;

    public static int towerNumber;

    public Button showInformation;

    private void Start()
    {
        InvokeRepeating("UIView", 0f, 0.25f);

    }

    public void Information ()
    {

        if (isInformationShown == false)
        {
            isStatisticsShown = false;
            isInformationShown = true;
            arrow.SetActive(true);
            upgradeDescriptionBG.SetActive(true);
            upgradeDescription.SetActive(true);
            upgradeTextBG.SetActive(true);
            upgradeText.SetActive(true);

            if (towerNumber == 1)
            {
                upgradeDescriptionText.text = "A small increase of damage, bullet speed, range, and firing rate.";
                upgradeTextText.text = "A Small Upgrade";
            }
            if(towerNumber == 2)
            {
                upgradeDescriptionText.text = "A more powerful launcher with flaming bullets.";
                upgradeTextText.text = "Explosion Of Flames";
            }
            if(towerNumber == 3)
            {
                upgradeDescriptionText.text = "This beam is powerful enough to set enemies on fire!";
                upgradeTextText.text = "Expensive Machinery";
            }
            if(towerNumber == 4)
            {
                upgradeDescriptionText.text = "Why use one barrel when you can use two!";
                upgradeTextText.text = "Double-Barrel Gunner";
            }
            if (towerNumber == 5)
            {
                upgradeDescriptionText.text = "This ice does a greater job at freezing the enemies!";
                upgradeTextText.text = "Colder Ice";
            }
            if (towerNumber == 6)
            {
                upgradeDescriptionText.text = "This wind generator will blow those enemies away without any trouble, including ice enemies!";
                upgradeTextText.text = "Fast Wind";
            }
            if (towerNumber == 11)
            {
                upgradeDescriptionText.text = "Flaming bullets and metal enemies go together nicely!";
                upgradeTextText.text = "Metal Obliterator";
            }
            if (towerNumber == 12)
            {
                upgradeDescriptionText.text = "Don't mess with this beast. It may just look like a couple of concrete blocks but it is much more powerful than you think! Metal enemies can be melted by the heat of this thing.";
                upgradeTextText.text = "Super Hot Missile Launcher";
            }
            if (towerNumber == 13)
            {
                upgradeDescriptionText.text = "I call this one the plasma paralyser. It shoots plasma beams and slows the enemies so much, it almost paralyses them! An extra beamer is also added.";
                upgradeTextText.text = "Plasma Paralyser";
            }
            if (towerNumber == 14)
            {
                upgradeDescriptionText.text = "This trio of barrels will tear enemies apart!";
                upgradeTextText.text = "The Great Trio";
            }
            if (towerNumber == 15)
            {
                upgradeDescriptionText.text = "More damage, more range, more cold ice... How can this get any better?";
                upgradeTextText.text = "Freezestorm";
            }
            if (towerNumber == 16)
            {
                upgradeDescriptionText.text = "Even stronger winds occur with this wind generator, winds strong enough to blow metal away!";
                upgradeTextText.text = "Larger Battery";
            }
            if (towerNumber == 21)
            {
                upgradeDescriptionText.text = "The two smaller barrels are now in working order with extreme range. Two flaming bullets and a normal bullet to finish them off!";
                upgradeTextText.text = "The Power Of Panels";
            }
            if (towerNumber == 22)
            {
                upgradeDescriptionText.text = "The concrete blocks will evolve into red concrete blocks with two mini side concrete blocks on the... sides.";
                upgradeTextText.text = "The Four-Headed Beast";
            }
            if (towerNumber == 23)
            {
                upgradeDescriptionText.text = "Not only have we got two plasma paralysers now, we also have a plasma shooter, which will of course shoot plasma balls at a great firing rate! The plasma shooter can also sense and destroy ice enemies.";
                upgradeTextText.text = "Plasma Mayhem";
            }
            if (towerNumber == 24)
            {
                upgradeDescriptionText.text = "So we went from having one barrel, to two barrels, to three barrels, and then four spinning barrels. I think that's pretty decent!";
                upgradeTextText.text = "Death Machine";
            }
            if (towerNumber == 25)
            {
                upgradeDescriptionText.text = "Heavy ice and heavy bullets. Nice!";
                upgradeTextText.text = "Ice Lord The IV";
            }
            if (towerNumber == 26)
            {
                upgradeDescriptionText.text = "This may be the fastest windmill you've ever encountered. Good thing it's on your side!";
                upgradeTextText.text = "Windmill of Torture";
            }
            if (towerNumber == 31)
            {
                upgradeDescriptionText.text = "Not happy with your turret? Maybe a new upgrade will come out soon!";
                upgradeTextText.text = "Standard Turret";
            }
            if (towerNumber == 32)
            {
                upgradeDescriptionText.text = "Not happy with your turret? Maybe a new upgrade will come out soon!";
                upgradeTextText.text = "Missile Launcher";
            }
            if (towerNumber == 33)
            {
                upgradeDescriptionText.text = "Not happy with your turret? Maybe a new upgrade will come out soon!";
                upgradeTextText.text = "Laser Beamer";
            }
            if (towerNumber == 34)
            {
                upgradeDescriptionText.text = "Not happy with your turret? Maybe a new upgrade will come out soon!";
                upgradeTextText.text = "Dartling Gun";
            }
            if (towerNumber == 35)
            {
                upgradeDescriptionText.text = "Not happy with your turret? Maybe a new upgrade will come out soon!";
                upgradeTextText.text = "Ice Blaster";
            }
            if (towerNumber == 36)
            {
                upgradeDescriptionText.text = "Not happy with your turret? Maybe a new upgrade will come out soon!";
                upgradeTextText.text = "Wind Generator";
            }

            return;
        }
        if(isInformationShown == true)
        {
            isInformationShown = false;
            arrow.SetActive(false);
            upgradeDescriptionBG.SetActive(false);
            upgradeDescription.SetActive(false);
            upgradeTextBG.SetActive(false);
            upgradeText.SetActive(false);
            return;
        }

        if (isStatisticsShown == false)
        {
            upgradeStatsBG.SetActive(false);
            upgradeStatsBG.SetActive(false);
            damageStats.SetActive(false);
            speedStats.SetActive(false);
            radiusStats.SetActive(false);
            rangeStats.SetActive(false);
            rateStats.SetActive(false);
            slowStats.SetActive(false);
            enemySStats.SetActive(false);
            damageBarNowGO.SetActive(false);
            damageBarUpgradeGO.SetActive(false);
            speedBarNowGO.SetActive(false);
            speedBarUpgradeGO.SetActive(false);
            radiusBarNowGO.SetActive(false);
            radiusBarUpgradeGO.SetActive(false);
            rangeBarNowGO.SetActive(false);
            rangeBarUpgradeGO.SetActive(false);
            rateBarNowGO.SetActive(false);
            rateBarUpgradeGO.SetActive(false);
            slowBarNowGO.SetActive(false);
            slowBarUpgradeGO.SetActive(false);
            enemySBarNowGO.SetActive(false);
            enemySBarUpgradeGO.SetActive(false);
        }

        if (isInformationShown == false)
        {
            upgradeDescriptionBG.SetActive(false);
            upgradeDescription.SetActive(false);
            upgradeTextBG.SetActive(false);
            upgradeText.SetActive(false);
        }
    }

    public void Statistics ()
    {

        if (isStatisticsShown == false)
        {
            StartCoroutine(StatsToShow());
            isStatisticsShown = true;
            isInformationShown = false;
            arrow.SetActive(true);
            upgradeStatsBG.SetActive(true);

            if (towerNumber == 1)
            {
                damageBarNow.fillAmount = 0.1f;
                damageBarUpgrade.fillAmount = 0.14f;

                speedBarNow.fillAmount = 0.35f;
                speedBarUpgrade.fillAmount = 0.45f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.3f;
                rangeBarUpgrade.fillAmount = 0.4f;

                rateBarNow.fillAmount = 0.1f;
                rateBarUpgrade.fillAmount = 0.15f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.8f;

            }
            if (towerNumber == 2)
            {
                damageBarNow.fillAmount = 0.16f;
                damageBarUpgrade.fillAmount = 0.2f;

                speedBarNow.fillAmount = 0.15f;
                speedBarUpgrade.fillAmount = 0.25f;

                radiusBarNow.fillAmount = 0.4f;
                radiusBarUpgrade.fillAmount = 0.5f;

                rangeBarNow.fillAmount = 0.5f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.05f;
                rateBarUpgrade.fillAmount = 0.075f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 3)
            {
                damageBarNow.fillAmount = 0.12f;
                damageBarUpgrade.fillAmount = 0.18f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.4f;
                rangeBarUpgrade.fillAmount = 0.56f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.5f;
                slowBarUpgrade.fillAmount = 0.7f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 4)
            {
                damageBarNow.fillAmount = 0.2f;
                damageBarUpgrade.fillAmount = 0.4f;

                speedBarNow.fillAmount = 0.35f;
                speedBarUpgrade.fillAmount = 0.35f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.4f;
                rangeBarUpgrade.fillAmount = 0.5f;

                rateBarNow.fillAmount = 0.1f;
                rateBarUpgrade.fillAmount = 0.2f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.8f;
            }
            if (towerNumber == 5)
            {
                damageBarNow.fillAmount = 0.0f;
                damageBarUpgrade.fillAmount = 0.02f;

                speedBarNow.fillAmount = 0.35f;
                speedBarUpgrade.fillAmount = 0.4f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.3f;
                rangeBarUpgrade.fillAmount = 0.4f;

                rateBarNow.fillAmount = 0.1f;
                rateBarUpgrade.fillAmount = 0.2f;

                slowBarNow.fillAmount = 0.15f;
                slowBarUpgrade.fillAmount = 0.3f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 6)
            {
                damageBarNow.fillAmount = 0.12f;
                damageBarUpgrade.fillAmount = 0.18f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.3f;
                rangeBarUpgrade.fillAmount = 0.4f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.2f;
                slowBarUpgrade.fillAmount = 0.4f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 11)
            {
                damageBarNow.fillAmount = 0.14f;
                damageBarUpgrade.fillAmount = 0.2f;

                speedBarNow.fillAmount = 0.45f;
                speedBarUpgrade.fillAmount = 0.45f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.4f;
                rangeBarUpgrade.fillAmount = 0.4f;

                rateBarNow.fillAmount = 0.15f;
                rateBarUpgrade.fillAmount = 0.15f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 12)
            {
                damageBarNow.fillAmount = 0.2f;
                damageBarUpgrade.fillAmount = 0.4f;

                speedBarNow.fillAmount = 0.25f;
                speedBarUpgrade.fillAmount = 0.25f;

                radiusBarNow.fillAmount = 0.5f;
                radiusBarUpgrade.fillAmount = 0.5f;

                rangeBarNow.fillAmount = 0.7f;
                rangeBarUpgrade.fillAmount = 0.8f;

                rateBarNow.fillAmount = 0.075f;
                rateBarUpgrade.fillAmount = 0.2f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 13)
            {
                damageBarNow.fillAmount = 0.18f;
                damageBarUpgrade.fillAmount = 0.36f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.56f;
                rangeBarUpgrade.fillAmount = 0.66f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.7f;
                slowBarUpgrade.fillAmount = 0.8f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 14)
            {
                damageBarNow.fillAmount = 0.4f;
                damageBarUpgrade.fillAmount = 0.6f;

                speedBarNow.fillAmount = 0.35f;
                speedBarUpgrade.fillAmount = 0.35f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.5f;
                rangeBarUpgrade.fillAmount = 0.6f;

                rateBarNow.fillAmount = 0.2f;
                rateBarUpgrade.fillAmount = 0.3f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.8f;
            }
            if (towerNumber == 15)
            {
                damageBarNow.fillAmount = 0.02f;
                damageBarUpgrade.fillAmount = 0.1f;

                speedBarNow.fillAmount = 0.4f;
                speedBarUpgrade.fillAmount = 0.45f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.4f;
                rangeBarUpgrade.fillAmount = 0.6f;

                rateBarNow.fillAmount = 0.2f;
                rateBarUpgrade.fillAmount = 0.3f;

                slowBarNow.fillAmount = 0.3f;
                slowBarUpgrade.fillAmount = 0.5f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 16)
            {
                damageBarNow.fillAmount = 0.18f;
                damageBarUpgrade.fillAmount = 0.32f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.4f;
                rangeBarUpgrade.fillAmount = 0.6f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.4f;
                slowBarUpgrade.fillAmount = 0.6f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 21)
            {
                damageBarNow.fillAmount = 0.2f;
                damageBarUpgrade.fillAmount = 0.54f;

                speedBarNow.fillAmount = 0.45f;
                speedBarUpgrade.fillAmount = 0.45f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.4f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.15f;
                rateBarUpgrade.fillAmount = 0.3f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 0.9f;
            }
            if (towerNumber == 22)
            {
                damageBarNow.fillAmount = 0.4f;
                damageBarUpgrade.fillAmount = 0.8f;

                speedBarNow.fillAmount = 0.25f;
                speedBarUpgrade.fillAmount = 0.25f;

                radiusBarNow.fillAmount = 0.5f;
                radiusBarUpgrade.fillAmount = 0.5f;

                rangeBarNow.fillAmount = 0.8f;
                rangeBarUpgrade.fillAmount = 0.9f;

                rateBarNow.fillAmount = 0.2f;
                rateBarUpgrade.fillAmount = 0.4f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 1f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 23)
            {
                damageBarNow.fillAmount = 0.36f;
                damageBarUpgrade.fillAmount = 0.6f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.25f;

                rangeBarNow.fillAmount = 0.66f;
                rangeBarUpgrade.fillAmount = 0.8f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.8f;
                slowBarUpgrade.fillAmount = 0.9f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 24)
            {
                damageBarNow.fillAmount = 0.6f;
                damageBarUpgrade.fillAmount = 0.8f;

                speedBarNow.fillAmount = 0.35f;
                speedBarUpgrade.fillAmount = 0.35f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.6f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.3f;
                rateBarUpgrade.fillAmount = 0.4f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.8f;
            }
            if (towerNumber == 25)
            {
                damageBarNow.fillAmount = 0.1f;
                damageBarUpgrade.fillAmount = 0.4f;

                speedBarNow.fillAmount = 0.45f;
                speedBarUpgrade.fillAmount = 0.5f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.6f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.3f;
                rateBarUpgrade.fillAmount = 0.4f;

                slowBarNow.fillAmount = 0.5f;
                slowBarUpgrade.fillAmount = 0.75f;

                enemySBarNow.fillAmount = 0.9f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 26)
            {
                damageBarNow.fillAmount = 0.32f;
                damageBarUpgrade.fillAmount = 0.65f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.6f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.6f;
                slowBarUpgrade.fillAmount = 0.8f;

                enemySBarNow.fillAmount = 1f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 31)
            {
                damageBarNow.fillAmount = 0.54f;
                damageBarUpgrade.fillAmount = 0.54f;

                speedBarNow.fillAmount = 0.45f;
                speedBarUpgrade.fillAmount = 0.45f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.7f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.3f;
                rateBarUpgrade.fillAmount = 0.3f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.8f;
            }
            if (towerNumber == 32)
            {
                damageBarNow.fillAmount = 0.8f;
                damageBarUpgrade.fillAmount = 0.8f;

                speedBarNow.fillAmount = 0.25f;
                speedBarUpgrade.fillAmount = 0.25f;

                radiusBarNow.fillAmount = 0.5f;
                radiusBarUpgrade.fillAmount = 0.5f;

                rangeBarNow.fillAmount = 0.9f;
                rangeBarUpgrade.fillAmount = 0.9f;

                rateBarNow.fillAmount = 0.4f;
                rateBarUpgrade.fillAmount = 0.4f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 1f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 33)
            {
                damageBarNow.fillAmount = 0.6f;
                damageBarUpgrade.fillAmount = 0.6f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.25f;
                radiusBarUpgrade.fillAmount = 0.25f;

                rangeBarNow.fillAmount = 0.8f;
                rangeBarUpgrade.fillAmount = 0.8f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.9f;
                slowBarUpgrade.fillAmount = 0.9f;

                enemySBarNow.fillAmount = 1f;
                enemySBarUpgrade.fillAmount = 1f;

            }
            if (towerNumber == 34)
            {
                damageBarNow.fillAmount = 0.8f;
                damageBarUpgrade.fillAmount = 0.8f;

                speedBarNow.fillAmount = 0.35f;
                speedBarUpgrade.fillAmount = 0.35f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.7f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.4f;
                rateBarUpgrade.fillAmount = 0.04f;

                slowBarNow.fillAmount = 0.0f;
                slowBarUpgrade.fillAmount = 0.0f;

                enemySBarNow.fillAmount = 0.8f;
                enemySBarUpgrade.fillAmount = 0.8f;
            }
            if (towerNumber == 35)
            {
                damageBarNow.fillAmount = 0.4f;
                damageBarUpgrade.fillAmount = 0.4f;

                speedBarNow.fillAmount = 0.5f;
                speedBarUpgrade.fillAmount = 0.5f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.7f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 0.4f;
                rateBarUpgrade.fillAmount = 0.4f;

                slowBarNow.fillAmount = 0.75f;
                slowBarUpgrade.fillAmount = 0.75f;

                enemySBarNow.fillAmount = 1f;
                enemySBarUpgrade.fillAmount = 1f;
            }
            if (towerNumber == 36)
            {
                damageBarNow.fillAmount = 0.65f;
                damageBarUpgrade.fillAmount = 0.65f;

                speedBarNow.fillAmount = 1f;
                speedBarUpgrade.fillAmount = 1f;

                radiusBarNow.fillAmount = 0.1f;
                radiusBarUpgrade.fillAmount = 0.1f;

                rangeBarNow.fillAmount = 0.7f;
                rangeBarUpgrade.fillAmount = 0.7f;

                rateBarNow.fillAmount = 1f;
                rateBarUpgrade.fillAmount = 1f;

                slowBarNow.fillAmount = 0.8f;
                slowBarUpgrade.fillAmount = 0.8f;

                enemySBarNow.fillAmount = 1f;
                enemySBarUpgrade.fillAmount = 1f;
            }

            return;
        }

        if (isStatisticsShown == true)
        {
            isStatisticsShown = false;
            arrow.SetActive(false);
            upgradeStatsBG.SetActive(false);
            upgradeStatsBG.SetActive(false);
            damageStats.SetActive(false);
            speedStats.SetActive(false);
            radiusStats.SetActive(false);
            rangeStats.SetActive(false);
            rateStats.SetActive(false);
            slowStats.SetActive(false);
            enemySStats.SetActive(false);
            damageBarNowGO.SetActive(false);
            damageBarUpgradeGO.SetActive(false);
            speedBarNowGO.SetActive(false);
            speedBarUpgradeGO.SetActive(false);
            radiusBarNowGO.SetActive(false);
            radiusBarUpgradeGO.SetActive(false);
            rangeBarNowGO.SetActive(false);
            rangeBarUpgradeGO.SetActive(false);
            rateBarNowGO.SetActive(false);
            rateBarUpgradeGO.SetActive(false);
            slowBarNowGO.SetActive(false);
            slowBarUpgradeGO.SetActive(false);
            enemySBarNowGO.SetActive(false);
            enemySBarUpgradeGO.SetActive(false);

            return;
        }

        if (isStatisticsShown == false)
        {
            upgradeStatsBG.SetActive(false);
            upgradeStatsBG.SetActive(false);
            damageStats.SetActive(false);
            speedStats.SetActive(false);
            radiusStats.SetActive(false);
            rangeStats.SetActive(false);
            rateStats.SetActive(false);
            slowStats.SetActive(false);
            enemySStats.SetActive(false);
            damageBarNowGO.SetActive(false);
            damageBarUpgradeGO.SetActive(false);
            speedBarNowGO.SetActive(false);
            speedBarUpgradeGO.SetActive(false);
            radiusBarNowGO.SetActive(false);
            radiusBarUpgradeGO.SetActive(false);
            rangeBarNowGO.SetActive(false);
            rangeBarUpgradeGO.SetActive(false);
            rateBarNowGO.SetActive(false);
            rateBarUpgradeGO.SetActive(false);
            slowBarNowGO.SetActive(false);
            slowBarUpgradeGO.SetActive(false);
            enemySBarNowGO.SetActive(false);
            enemySBarUpgradeGO.SetActive(false);
        }

        if (isInformationShown == false)
        {
            upgradeDescriptionBG.SetActive(false);
            upgradeDescription.SetActive(false);
            upgradeTextBG.SetActive(false);
            upgradeText.SetActive(false);
        }
    }

    IEnumerator StatsToShow ()
    {
        damageStats.SetActive(true);
        speedStats.SetActive(true);
        radiusStats.SetActive(true);
        rangeStats.SetActive(true);
        rateStats.SetActive(true);
        slowStats.SetActive(true);
        enemySStats.SetActive(true);

        damageBarUpgradeGO.SetActive(true);
        speedBarUpgradeGO.SetActive(true);
        radiusBarUpgradeGO.SetActive(true);
        rangeBarUpgradeGO.SetActive(true);
        rateBarUpgradeGO.SetActive(true);
        slowBarUpgradeGO.SetActive(true);
        enemySBarUpgradeGO.SetActive(true);

        yield return new WaitForSeconds(0.05f);

        damageBarNowGO.SetActive(true);
        speedBarNowGO.SetActive(true);
        radiusBarNowGO.SetActive(true);
        rangeBarNowGO.SetActive(true);
        rateBarNowGO.SetActive(true);
        slowBarNowGO.SetActive(true);
        enemySBarNowGO.SetActive(true);

    }

    void UIView()
    {
        if (isInformationShown == false)
        {
            upgradeDescriptionBG.SetActive(false);
            upgradeDescription.SetActive(false);
            upgradeTextBG.SetActive(false);
            upgradeText.SetActive(false);
        }
        if (isStatisticsShown == false)
        {
            upgradeStatsBG.SetActive(false);
            damageStats.SetActive(false);
            speedStats.SetActive(false);
            radiusStats.SetActive(false);
            rangeStats.SetActive(false);
            rateStats.SetActive(false);
            slowStats.SetActive(false);
            enemySStats.SetActive(false);
            damageBarNowGO.SetActive(false);
            damageBarUpgradeGO.SetActive(false);
            rangeBarNowGO.SetActive(false);
            rangeBarUpgradeGO.SetActive(false);
            rateBarNowGO.SetActive(false);
            rateBarUpgradeGO.SetActive(false);
            slowBarNowGO.SetActive(false);
            slowBarUpgradeGO.SetActive(false);
            enemySBarNowGO.SetActive(false);
            enemySBarUpgradeGO.SetActive(false);
        }
        if (isInformationShown == false && isStatisticsShown == false)
        {
            arrow.SetActive(false);
        }
    }

}
