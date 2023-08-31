using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHolder : MonoBehaviour
{

    public CharacterStatsProfile data;


    [Header("Character Stats")]
    public float strenght;
    public float dexterity;
    public float arcana;
        [Space(10)]
    public float strResistance;
    public float dexResistance;
    public float arcResistance;
        [Space(10)]
    public float critChance;
    public float lifeSteal;
        [Space(10)]
    public float attackSpeed;
    public float speed;
    public int hitPoints;

    void Start()
    {
        strenght = data.strenght;
        dexterity = data.dexterity;
        arcana = data.arcana ;
        strResistance = data.strResistance;
        dexResistance = data.dexResistance;
        arcResistance = data.arcResistance;
        critChance = data.critChance;
        lifeSteal = data.lifeSteal;
        attackSpeed = data.attackSpeed;
        speed = data.speed;
        hitPoints = data.hitPoints;
    }

}
