using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsProfile", menuName = "CoK-Scritpables/Character Stats Profile", order = 0)]
public class CharacterStatsProfile : ScriptableObject
{
    [Header("Character Stats")]
    
    public float strenght = 1f;
    public float dexterity = 1f;
    public float arcana = 1f;
    [Space(10)]
    public float strResistance = 1f;
    public float dexResistance = 1f;
    public float arcResistance = 1f;
    [Space(10)]
    public float critChance = 1f;
    public float lifeSteal = 1f;
    [Space(10)]
    public float attackSpeed = 1f;
    public float speed = 2f;
    public int hitPoints = 50;

}
