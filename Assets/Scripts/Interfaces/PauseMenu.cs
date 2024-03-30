using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("The pause menu object")]
    GameObject pauseMenuObj;
    [SerializeField]
    [Tooltip("The Options menu Panel")]
    GameObject optionsMenuObj;

    LevelLoader levelLoader;

    bool isPaused;
    public bool IsPaused => isPaused;

    private void Awake()
    {
        Unpause();
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && isPaused)
            Unpause();
        else if (Input.GetButtonDown("Cancel") && !isPaused)
            Pause();
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pauseMenuObj.SetActive(false);
        optionsMenuObj.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        pauseMenuObj.SetActive(true);
    }

    public void MainMenu()
    {
        levelLoader.GoToScene(0);
    }

    public void Restart()
    {
        levelLoader.RestartLevel();
    }

    public void Options()
    {
        optionsMenuObj.SetActive(!optionsMenuObj.activeSelf);
    }
    public void QuitGame()
    {
        levelLoader.QuitApp();
    }
}
