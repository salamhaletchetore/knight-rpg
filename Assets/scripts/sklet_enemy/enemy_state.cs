using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_state 
{
    protected enemy_state_machine state_machine;
    protected enemy enemybase;
    protected Rigidbody2D rb;


    protected Transform Player ;

    protected bool trigger_called;
    private string anim_bool_name;
    protected float state_timer;

    public enemy_state(enemy _enemybase , enemy_state_machine _statemachine , string _animboolname)
    {
        this.enemybase = _enemybase;

        this.state_machine = _statemachine;

        this.anim_bool_name = _animboolname;
    }


    public virtual void Update()
    {
        state_timer -= Time.deltaTime;
        rb = enemybase.rb;
    }

    public virtual void Enter()
    {
        Player = GameObject.Find("player").transform ;
        trigger_called = false ;
        enemybase.anim.SetBool(anim_bool_name , true);
    }

    public virtual void Exit ()
    {
        enemybase.anim.SetBool(anim_bool_name , false);
    }

    public virtual void AnimationFinishTrigger()
    {
        trigger_called = true;
    }

}
