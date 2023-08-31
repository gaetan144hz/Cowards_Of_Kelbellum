using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageDisplayer : MonoBehaviour
{
    
    public TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ModifyDisplay(float damage)
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = "" + damage;
        
        Destroy(transform.parent.gameObject,0.4f);
        StartCoroutine(FadeAndMove());
    }

    IEnumerator FadeAndMove()
    {
        while (textComponent.alpha > 0)
        {
            textComponent.alpha -= 0.1f;
            transform.position += new Vector3(0,0.4f,0);
            yield return new WaitForSeconds(.1f);
        }
    }

}
