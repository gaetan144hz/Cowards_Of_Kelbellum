using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrimaryAbility : MonoBehaviour
{

    public bool isMelee = true;
    public MeleeAttack meleeScript;
    public bool isRange = false;
    public RangeAttack rangeScript;
    public bool isSpell = false;
    public SpellAttack spellScript;
    

    void Start()
    {
        meleeScript = gameObject.GetComponent<MeleeAttack>();
        rangeScript = gameObject.GetComponent<RangeAttack>();
        spellScript = gameObject.GetComponent<SpellAttack>();
    }    

    public void OnPrimary(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
            if (isMelee)
            {
                meleeScript.Attack();
            }
            if (isRange)
            {
                rangeScript.Attack();
            }
            if (isSpell)
            {
                Debug.Log("Spell"); //NEXT
            }
        }
    }
}
