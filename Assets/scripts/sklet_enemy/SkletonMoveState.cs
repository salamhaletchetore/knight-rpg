using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkletonMoveState : enemy_state
{
    enemy_skleton enemy_sk;
    

    public SkletonMoveState(enemy _enemybase , enemy_state_machine _statemachine , string anim_bool_name , enemy_skleton _skleton) : base(_enemybase , _statemachine , anim_bool_name)
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
    }

    public override void Update()
    {
        base.Update();

        if(enemy_sk.isplayerdetected() || Vector2.Distance(enemy_sk.transform.position , Player.position) < 2)
            state_machine.change_state(enemy_sk.battle_state);

        enemy_sk.SetVelocity(2* enemy_sk.facingDir , rb.velocity.y);

        if(enemy_sk.IsWallDetected() || !enemy_sk.IsGroundDetected())
        {
            enemy_sk.Flip();
            state_machine.change_state(enemy_sk.idle_state);
        }

    }
}
