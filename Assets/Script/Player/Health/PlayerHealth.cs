using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData datap;

    private float health = 50f;
    private float maxHealth = 50f;

    public float shieldValue = 0f;

    [Header("Display")]
    public bool showSlider = true;
    public Slider slider;
    
    private void Start() 
    {
        if (datap)
        {
            GetData();
        }

        UpdateSlider();    
    }

    void GetData()
    {
        maxHealth = datap.health;
        health = maxHealth;
    }

    public void LoadPlayerData(PlayerData newData)
    {
        datap = newData;
        GetData();
    }

    public void SetDisplay(bool isDisplay)
    {
        showSlider = isDisplay;
    }

    public void ApplyDamage(float damage)
    {
        if (shieldValue > 0)
        {
            Debug.Log("TANKED");
            float da = damage;
            damage -= shieldValue;
            shieldValue -= da;
        }
        if (damage > 0)
        {
            health -= damage;
        }

        UpdateSlider();
        
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void UpdateSlider()
    {
        slider.value = health;
        slider.maxValue = maxHealth;
                
        if (!showSlider)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
    }

}
