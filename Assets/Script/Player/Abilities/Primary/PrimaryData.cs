using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryData", menuName = "COK_Player/Primary Data")]
public class PrimaryData : ScriptableObject
{

    public void OnEnable()
    {

        damage = baseDamage;
        range = baseRange;
        knockback = baseKnockback;
        attackSpeed = baseAttackSpeed;

    }
    
    public enum PrimaryType
    {
        melee,
        range,
        spell
    }

    [Header("Primary Ability")]
    public PrimaryType pType;

    public float baseDamage;
    [HideInInspector] public float damage;

    public float baseRange;
    [HideInInspector] public float range;

    public float baseKnockback;
    [HideInInspector] public float knockback;

    public float baseAttackSpeed;
    [HideInInspector] public float attackSpeed;


    [Header("Prefabs & FX")]
    public float projectileSpeed;
    public GameObject projectilePrefab;
    
}