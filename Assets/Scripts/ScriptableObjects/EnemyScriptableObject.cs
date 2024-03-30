using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "Objects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{

    [Header ("General Stats")]
    [SerializeField] [Tooltip ("Enemy's Name")]
    string _name;

    [Header("Enemy Stats")]
    [SerializeField]
    [Tooltip("The type of enemy")]
    TypeOfEnemy _enemyType;
    [SerializeField]
    [Tooltip ("The damage the target will recieve on contact")]
    float _attackDamage;
    [SerializeField]
    [Tooltip("The speed the enemy will attack the player")]
    float _attackSpeed;
    [SerializeField]
    [Tooltip("The Weight of the enemy")]
    float _weight;
    [SerializeField]
    [Tooltip ("The speed the enemy moves")]
    float _moveSpeed;
    [SerializeField]
    [Tooltip("The time the enemy takes to move before pausing")]
    float _moveTimer;
    [SerializeField]
    [Tooltip("The Jump force for the enemy")]
    float _jumpForce;
    [SerializeField]
    [Tooltip("The gravity pulling the enemy down")]
    float _gravity;
    [SerializeField]
    [Tooltip("The time the enemy pauses for before continuing moving")]
    float _pauseTimer;

    //Accessible variables
    public string Name => _name;
    public TypeOfEnemy EnemyType => _enemyType;
    public float AttackDamage => _attackDamage;
    public float AttackSpeed => _attackSpeed;
    public float Weight => _weight;
    public float MoveSpeed => _moveSpeed;
    public float MoveTimer => _moveTimer;
    public float JumpForce => _jumpForce;
    public float Gravity => _gravity;
    public float PauseTimer => _pauseTimer;
}

public enum TypeOfEnemy
{
    Patrol,
    MoveAndShoot,
    Turret,
    Dart
}