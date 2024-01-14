using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{
    [SerializeField]protected float cool_down;
    protected float cool_down_timer;

    protected virtual void Update()
    {
        cool_down_timer -= Time.deltaTime;
    }


    public virtual bool can_use_skill()
    {
        if(cool_down_timer < 0)
        {
            use_skill();
            cool_down_timer = cool_down;
            return true;
        }

        return false;
    }


    public virtual void use_skill()
    {

    }
}
