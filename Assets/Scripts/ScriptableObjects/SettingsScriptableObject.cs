using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Objects/Settings")]
public class SettingsScriptableObject : ScriptableObject
{
    public bool musicToggle, sfxToggle, masterToggle, fullscreenToggle, hasPlayedTutorial;
    public int sceneIndex, fastestTime;
    public float musicVolume, sfxVolume, masterVolume;
    
}