using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkletonStunState : enemy_state
{
    enemy_skleton enemy_sk;

    public SkletonStunState(enemy _enemybase , enemy_state_machine _statemachine , string anim_bool_name , enemy_skleton _skleton) : base(_enemybase , _statemachine , anim_bool_name)
    {
        this.enemy_sk = _skleton ;
    }

    public override void Enter()
    {
        base.Enter();
        

        enemy_sk.fx.InvokeRepeating("red_color_blink",0,.1f);
        state_timer = enemy_sk.stun_duration;
        enemy_sk.rb.velocity = new Vector2(-enemy_sk.facingDir * enemy_sk.stun_direction.x , enemy_sk.stun_direction.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy_sk.fx.Invoke("cancel_red_blink",0);
    }

    public override void Update()
    {
        base.Update();
        if(state_timer < 0)
        {
            state_machine.change_state(enemy_sk.idle_state);
        }
    }
}
