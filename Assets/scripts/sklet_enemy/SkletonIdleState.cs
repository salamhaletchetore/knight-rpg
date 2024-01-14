using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkletonIdleState : enemy_state
{
    enemy_skleton enemy_sk;

    public SkletonIdleState(enemy _enemybase , enemy_state_machine _statemachine , string anim_bool_name , enemy_skleton _skleton) : base(_enemybase , _statemachine , anim_bool_name)
    {
        this.enemy_sk = _skleton ;
    }

    public override void Enter()
    {
        base.Enter();

        state_timer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(enemy_sk.isplayerdetected() || Vector2.Distance(enemy_sk.transform.position , Player.position) < 4)
            state_machine.change_state(enemy_sk.battle_state);

        if(state_timer < 0)
            state_machine.change_state(enemy_sk.move_state);
    }
}
