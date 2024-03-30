using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Objects")]
    [SerializeField]
    [Tooltip("The Visuals of the current Enemy")]
    GameObject visuals;

    [Space]
    [Header("Enemy Attributes")]
    [SerializeField]
    [Tooltip("The Scriptable Object of the current Enemy")]
    EnemyScriptableObject enemySO;

    private void Start()
    {
        tag = "Enemy";
    }

    public string GetName()
    {
        return enemySO.Name;
    }
    public TypeOfEnemy GetEnemyType()
    {
        return enemySO.EnemyType;
    }
    public float GetAttackDamage()
    {
        return enemySO.AttackDamage;
    }
    public float GetShootSpeed()
    {
        return enemySO.AttackSpeed;
    }
    public float GetMoveSpeed()
    {
        return enemySO.MoveSpeed;
    }
    public float GetMoveTimer()
    {
        return enemySO.MoveTimer;
    }
    public float GetJumpForce()
    {
        return enemySO.JumpForce;
    }
    public float GetGravity()
    {
        return enemySO.Gravity;
    }
    public float GetPauseTimer()
    {
        return enemySO.PauseTimer;
    }
}
