using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity_fx : MonoBehaviour
{


    private SpriteRenderer sr ;
    [Header("FlashFX")]
    [SerializeField] private Material flash_material;
     private Material default_material;



    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

        default_material = sr.material;
        
    }

    private IEnumerator flash_fx()
    {
        sr.material = flash_material;

        yield return new WaitForSeconds(.2f);

        sr.material = default_material;
    }


    private void red_color_blink()
    {
        if(sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;    
    }


    private void cancel_red_blink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
