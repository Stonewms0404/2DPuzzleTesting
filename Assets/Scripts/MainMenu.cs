using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Menu Objects")]
    GameObject mainMenuObj, creditsMenuObj, optionsMenuObj, tutorialMenuObj;

    LevelLoader levelLoader;
    SettingsManager settingsManager;
    bool skippedTutorial;

    private void Awake()
    {
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        settingsManager = GameObject.FindGameObjectWithTag("SettingsManager").GetComponent<SettingsManager>();
        MainMenuPanel();
    }

    public void OptionsPanel()
    {
        mainMenuObj.SetActive(false);
        optionsMenuObj.SetActive(true);
        creditsMenuObj.SetActive(false);
        tutorialMenuObj.SetActive(false);
    }
    public void MainMenuPanel()
    {
        Time.timeScale = 1f;
        mainMenuObj.SetActive(true);
        optionsMenuObj.SetActive(false);
        creditsMenuObj.SetActive(false);
        tutorialMenuObj.SetActive(false);
    }
    public void CreditsPanel()
    {
        mainMenuObj.SetActive(false);
        optionsMenuObj.SetActive(false);
        creditsMenuObj.SetActive(true);
        tutorialMenuObj.SetActive(false);
    }
    public void TutorialPanel()
    {
        mainMenuObj.SetActive(false);
        optionsMenuObj.SetActive(false);
        creditsMenuObj.SetActive(false);
        tutorialMenuObj.SetActive(true);
    }

    public void StartGame()
    {
        if (settingsManager.GetHasPlayedTutorial() || skippedTutorial)
            levelLoader.GoToScene(2);
        else
        {
            TutorialPanel();
        }
    }

    public void StartTutorial(bool value)
    {
        skippedTutorial = value;
        if (skippedTutorial)
            StartGame();
        else
            levelLoader.GoToScene(1);
    }

    public void QuitGame()
    {
        levelLoader.QuitApp();
    }
}
