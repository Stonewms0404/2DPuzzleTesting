using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Objects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [Header("General Stats")]
    [SerializeField]
    [Tooltip("Player's Name")]
    string _name;

    [Space]
    [Header("Player Specifics")]
    [SerializeField]
    [Tooltip("The speed at which the player can Shoot")]
    float _attackSpeed;
    [SerializeField]
    [Tooltip("The speed at which the player moves")]
    float _speed;
    [SerializeField]
    [Tooltip("The friction of how fast the player stops")]
    float _friction;
    [SerializeField]
    [Tooltip("The Player's Gravity")]
    float _gravity;
    [SerializeField]
    [Tooltip("The Force at which the player can jump")]
    float _jumpForce;
    [SerializeField]
    [Tooltip("Player Projectiles")]
    GameObject[] _projectiles;

    public string Name => _name;
    public float AttackSpeed => _attackSpeed;
    public float Speed => _speed;
    public float Friction => _friction;
    public float Gravity => _gravity;
    public float JumpForce => _jumpForce;
    public GameObject[] Projectiles => _projectiles;
}