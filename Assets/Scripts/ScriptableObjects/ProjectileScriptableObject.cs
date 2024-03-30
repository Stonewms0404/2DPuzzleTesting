using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Objects/Projectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    [Header("General Stats")]
    [SerializeField]
    [Tooltip("Projectile Name")]
    string _name;
    [SerializeField]
    [Tooltip("The speed at which the projectile moves")]
    float _speed;
    [SerializeField]
    [Tooltip("Attack Damage")]
    float _attackDamage;

    [Space]
    [SerializeField]
    [Tooltip("The type of projectile should this be treated as")]
    TypeOfProjectile _projectileType;

    public string Name => _name;
    public float Speed => _speed;
    public float AttackDamage => _attackDamage;
    public TypeOfProjectile ProjectileType => _projectileType;
}

public enum TypeOfProjectile
{
    DamagePlayer,
    Single,
    Burst,
    Rapid
}