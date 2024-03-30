using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public static event Action<bool, string> ChangeSprite;

    [Header("SettingsManager")]
    [SerializeField]
    [Tooltip("The Settings ScriptableObject")]
    protected SettingsScriptableObject settingsSO;
    [SerializeField]
    [Tooltip("The Master audio channel")]
    AudioMixerGroup masterAudioGroup;
    [SerializeField]
    [Tooltip("The Music audio channel")]
    AudioMixerGroup musicAudioGroup;
    [SerializeField]
    [Tooltip("The SFX audio channel")]
    AudioMixerGroup sfxAudioGroup;

    static SettingsManager instance;

    private void Awake()
    {
        this.gameObject.TryGetComponent<OptionsMenu>(out OptionsMenu options);
        if (instance != null && options == null)
            Destroy(this.gameObject);
        else if (instance == null && options == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetSceneIndex(int value)
    {
        settingsSO.sceneIndex = value;
    }
    public int GetSceneIndex()
    {
        return settingsSO.sceneIndex;
    }

    public void SetMusicToggle(bool value)
    {
        settingsSO.musicToggle = value;
        if (!settingsSO.musicToggle)
            musicAudioGroup.audioMixer.SetFloat("MusicVolume", -80f);
        else
            musicAudioGroup.audioMixer.SetFloat("MusicVolume", settingsSO.musicVolume);
    }
    public void SetSFXToggle(bool value)
    {
        settingsSO.sfxToggle = value;
        if (!settingsSO.sfxToggle)
            sfxAudioGroup.audioMixer.SetFloat("SFXVolume", -80f);
        else
            sfxAudioGroup.audioMixer.SetFloat("SFXVolume", settingsSO.sfxVolume);
    }
    public void SetMasterToggle(bool value)
    {
        settingsSO.masterToggle = value;
        if (!settingsSO.masterToggle)
            masterAudioGroup.audioMixer.SetFloat("MasterVolume", -80f);
        else
            masterAudioGroup.audioMixer.SetFloat("MasterVolume", settingsSO.masterVolume);
    }
    public void SetFullscreenToggle(bool value)
    {
        settingsSO.fullscreenToggle = value;
        Screen.fullScreen = settingsSO.fullscreenToggle;
    }

    public void SetSFXVolume(float value)
    {
        settingsSO.sfxVolume = value;
        sfxAudioGroup.audioMixer.SetFloat("SFXVolume", settingsSO.sfxVolume);
        if (!settingsSO.sfxToggle)
            SetSFXToggle(true);
        ChangeSprite(true, "SFX");
    }
    public void SetMusicVolume(float value)
    {
        settingsSO.musicVolume = value;
        musicAudioGroup.audioMixer.SetFloat("MusicVolume", settingsSO.musicVolume);
        if (!settingsSO.musicToggle)
            SetMusicToggle(true);
        ChangeSprite(true, "Music");
    }
    public void SetMasterVolume(float value)
    {
        settingsSO.masterVolume = value;
        masterAudioGroup.audioMixer.SetFloat("MasterVolume", settingsSO.masterVolume);
        if (!settingsSO.masterToggle)
            SetMasterToggle(true);
        ChangeSprite(true, "Master");
    }

    public void SetHasPlayedTutorial(bool value)
    {
        settingsSO.hasPlayedTutorial = value;
    }
    public bool GetHasPlayedTutorial()
    {
        return settingsSO.hasPlayedTutorial;
    }
}