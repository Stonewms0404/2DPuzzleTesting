using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Switch", menuName = "Objects/Switch")]
public class SwitchScriptableObject : ScriptableObject
{
    [Header("General Stats")]
    [SerializeField]
    [Tooltip("Switch Name")]
    string _name;

    [Space]
    [Header("Switch Stats")]
    [SerializeField]
    [Tooltip("How is this switch activated")]
    TypeOfSwitch _switchType;

    public string Name => _name;
    public TypeOfSwitch SwitchType => _switchType;
}

public enum TypeOfSwitch
{
    Lever,
    Projectile,
    Pressure
}