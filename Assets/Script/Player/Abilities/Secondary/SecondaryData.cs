using UnityEngine;

[CreateAssetMenu(fileName = "SecondaryData", menuName = "COK_Player/Secondary Data")]
public class SecondaryData : ScriptableObject
{

    public void OnEnable()
    {

        value = baseValue;
        cooldown = baseCooldown;

    }
    
    public enum SecondaryType
    {
        shield,
        heal,
        statsUp
    }

    [Header("Primary Ability")]
    public SecondaryType sType;

    public float baseValue;
    [HideInInspector] public float value;

    public float baseCooldown;
    [HideInInspector] public float cooldown;


    [Header("Prefabs & FX")]
    public GameObject fxPrefab;
    public GameObject additionalPrefab;
    
}