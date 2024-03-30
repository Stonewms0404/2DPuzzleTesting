using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerMenu : MonoBehaviour
{
    public static event Action<string> GameOver;

    [Header("Objects")]
    [SerializeField]
    [Tooltip("The Timer Panel Object")]
    GameObject timerPanelObj;
    [SerializeField]
    [Tooltip("The TextMeshPro that will display the text")]
    TextMeshProUGUI timerText;
    [SerializeField]
    [Tooltip("The Pause Menu so the timer doesn't add up when the game is paused")]
    PauseMenu pauseMenu;

    string timerFormatted, timerForm;
    float timer;

    private void OnEnable()
    {
        FinishBox.GameWon += GameOverTimer;
    }

    private void OnDestroy()
    {
        FinishBox.GameWon -= GameOverTimer;
    }

    private void GameOverTimer()
    {
        GameOver(timerForm);
        Destroy(timerPanelObj);
    }

    private void FixedUpdate()
    {
        if (!pauseMenu.IsPaused)
        {
            timer += Time.deltaTime;
            if ((int)(timer % 60.0f) < 10)
                timerForm =  (int)(timer / 60.0f) + ":0" + (int)(timer % 60.0f);
            else
                timerForm = (int)(timer / 60.0f) + ":" + (int)(timer % 60.0f);
            timerFormatted = "Timer: " + timerForm;
            timerText.text = timerFormatted;
        }
    }
}
