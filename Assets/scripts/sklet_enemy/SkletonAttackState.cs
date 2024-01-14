using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkletonAttackState : enemy_state
{
        enemy_skleton enemy_sk;

    public SkletonAttackState(enemy _enemybase , enemy_state_machine _statemachine , string anim_bool_name , enemy_skleton _skleton) : base(_enemybase , _statemachine , anim_bool_name)
    {
        this.enemy_sk = _skleton ;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy_sk.last_time_attack = Time.time;
    }

    public override void Update()
    {
        base.Update();
        enemy_sk.ZeroVelocity();

        if(trigger_called )
            state_machine.change_state(enemy_sk.battle_state);

    }
}
