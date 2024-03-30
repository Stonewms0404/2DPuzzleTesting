using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class VictoryMenu : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("The victory menu object")]
    GameObject victoryMenuObj;
    [SerializeField]
    [Tooltip("The text object that displays how long the player took to complete the level")]
    TextMeshProUGUI timerText;
    [SerializeField]
    AudioSource levelMusic, finishMusic;

    LevelGeneration levelGen;
    SettingsManager settingsManager;

    private void Awake()
    {
        levelGen = GameObject.FindGameObjectWithTag("LevelGen").GetComponent<LevelGeneration>();
        settingsManager = GameObject.FindGameObjectWithTag("SettingsManager").GetComponent<SettingsManager>();
        TimerMenu.GameOver += DisplayMenu;
        victoryMenuObj.SetActive(false);
    }

    private void DisplayMenu(string obj)
    {
        timerText.text = "Time you took: " + obj;
        if (levelMusic) levelMusic.Pause();
        if (finishMusic) finishMusic.Play();
        if (victoryMenuObj)
            victoryMenuObj.SetActive(true);
        if (levelGen.IsTutorial)
            settingsManager.SetHasPlayedTutorial(true);
    }
}
