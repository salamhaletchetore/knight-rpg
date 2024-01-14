/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkletonGroundState : enemy_state
{
    protected enemy_skleton enemy_sk;
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

        if(enemy_sk.isplayerdetected())
            state_machine.current_state(enemy_sk.SkletonBattleState);
    }
}*/
