using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moveable Object", menuName = "Objects/Moveable Object")]
public class MoveableScriptableObject : ScriptableObject
{
    [Header("General Stats")]
    [SerializeField]
    [Tooltip("Name of the Moveable Object")]
    string _name;

    [Header("Moveable Object Stats")]
    [SerializeField]
    [Tooltip("The Weight of Object")]
    float _weight;
    [SerializeField]
    [Tooltip("Can the object activate a pressureplate")]
    bool _canActivate;
    [SerializeField]
    [Tooltip("The Size of Object")]
    SizeOfObject _objectSize;


    public string Name => _name;
    public float Weight => _weight;
    public bool CanActivate => _canActivate;
    public SizeOfObject ObjectSize => _objectSize;
}

public enum SizeOfObject
{
    Small,
    Medium,
    Large
}