using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Objects/Levels")]
public class LevelScriptableObject : ScriptableObject
{

    [Header("Level Stats")]
    [SerializeField]
    [Tooltip("")]
    string _name;
    [SerializeField]
    [Tooltip ("The Level Difficulty")]
    DifficultyOfLevel _difficulty;
    [SerializeField]
    [Tooltip("Whether the Level is lit or not")]
    StyleOfLevel _levelStyle;

    public string Name => _name;
    public DifficultyOfLevel Difficulty => _difficulty;
    public StyleOfLevel LevelStyle => _levelStyle;
}

public enum StyleOfLevel
{
    Lit,
    Dark
}

public enum DifficultyOfLevel
{
    Easy,
    Medium,
    Hard
}
