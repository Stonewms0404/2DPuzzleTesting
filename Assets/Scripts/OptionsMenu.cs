using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : SettingsManager
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("The options menu object")]
    GameObject optionsMenuObj;
    [SerializeField]
    [Tooltip("A slider that adjusts sound")]
    Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider;
    [SerializeField]
    [Tooltip("A toggle that adjusts volume on or off")]
    Toggle musicToggle, sfxToggle, masterToggle;
    [SerializeField]
    [Tooltip("A toggle that adjusts the fullscreen or windowed")]
    Toggle fullscreenToggle;


    private void OnEnable()
    {
        SetObjects();
    }

    private void SetObjects()
    {
        masterVolumeSlider.value = settingsSO.masterVolume;
        musicVolumeSlider.value = settingsSO.musicVolume;
        sfxVolumeSlider.value = settingsSO.sfxVolume;

        musicToggle.isOn = settingsSO.musicToggle;
        sfxToggle.isOn = settingsSO.sfxToggle;
        masterToggle.isOn = settingsSO.masterToggle;
        fullscreenToggle.isOn = settingsSO.fullscreenToggle;
    }

    public void ResetOptions()
    {
        SetMusicToggle(true);
        SetSFXToggle(true);
        SetMasterToggle(true);
        SetFullscreenToggle(true);
        SetMasterVolume(0);
        SetMusicVolume(0);
        SetSFXVolume(0);
        SetHasPlayedTutorial(false);

        SetObjects();
    }

    public void BackButton()
    {
        optionsMenuObj.SetActive(false);
    }
}
