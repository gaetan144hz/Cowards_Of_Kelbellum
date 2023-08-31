using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "COK_Player/Player Data")]
public class PlayerData : ScriptableObject
{

    public void OnEnable()
    {

        Time.timeScale = 1f;

        health = baseHealth;

        speed = baseSpeed;

        strenght = baseStrenght;
        dexterity = baseDexterity;
        arcana = baseArcana;
    
        strRes = baseStrRes;
        dexRes = baseDexRes;
        arcRes = baseArcRes;

        critChance = baseCritChance;
        lifeSteal = baseLifeSteal;

    }


    [Header("Player Movement")]
    public float baseSpeed;
    [HideInInspector] public float speed;
    

    [Header("Health")]
    public float baseHealth;
    [HideInInspector] public float health;


    [Header("Ability Stats")]
    public float baseStrenght;
    [HideInInspector] public float strenght;
    public float baseDexterity;
    [HideInInspector] public float dexterity;
    public float baseArcana;
    [HideInInspector] public float arcana;


    [Header("Special Stats")]
    public int baseCritChance;
    [HideInInspector] public int critChance;
    public int baseLifeSteal;
    [HideInInspector] public int lifeSteal;
    

    [Header("Resistances Stats")]
    public float baseStrRes;
    [HideInInspector] public float strRes;
    public float baseDexRes;
    [HideInInspector] public float dexRes;
    public float baseArcRes;
    [HideInInspector] public float arcRes;
    
}