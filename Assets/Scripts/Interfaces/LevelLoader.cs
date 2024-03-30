using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    SettingsManager settingsManager;
    static LevelLoader instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        settingsManager = GameObject.FindGameObjectWithTag("SettingsManager").GetComponent<SettingsManager>();
    }

    public void GoToScene(int sceneIndex)
    {
        settingsManager.SetSceneIndex(sceneIndex);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(settingsManager.GetSceneIndex());
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}