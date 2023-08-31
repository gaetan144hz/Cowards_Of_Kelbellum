using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SecondaryAbility : MonoBehaviour
{
    public PlayerData datap;
    public SecondaryData secData;

    private PlayerHealth pHealth;

    public bool canUseSecondary;

    private float lastUseTime = 0;

    void Start()
    {
        if (secData)
        {
            GetSecData();
        }

        pHealth = gameObject.GetComponent<PlayerHealth>();
    }

    public void LoadPlayerData(PlayerData newData)
    {
        datap = newData;
    }

    public void LoadSecondaryData(SecondaryData newSecData)
    {
        secData = newSecData;
        GetSecData();
    }

    void GetSecData()
    {
        canUseSecondary = secData;
    }


    public void OnSecondary(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canUseSecondary && CooldownCheck())
        {
            switch (secData.sType)
            {
                case SecondaryData.SecondaryType.shield:
                    Debug.Log("Shield");
                    UseShield();
                    break;
                
                case SecondaryData.SecondaryType.heal:
                    break;

                case SecondaryData.SecondaryType.statsUp:
                    break;
            }
            lastUseTime = Time.time;
        }
    }

    private bool CooldownCheck()
    {
        if (Time.time - lastUseTime < secData.cooldown)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void UseShield()
    {
        pHealth.shieldValue += secData.value;
        StartCoroutine(RemoveShield());
    }

    IEnumerator RemoveShield()
    {
        while (pHealth.shieldValue > 0)
        {
            pHealth.shieldValue -= secData.value / 10;
            yield return new WaitForSeconds(.1f);
        }
        pHealth.shieldValue = 0;
    }

}
