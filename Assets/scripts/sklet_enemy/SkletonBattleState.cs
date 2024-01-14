using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkletonBattleState : enemy_state
{
    private enemy_skleton enemy_sk;
    protected float move_dir;

    public SkletonBattleState(enemy _enemybase , enemy_state_machine _statemachine , string anim_bool_name , enemy_skleton _skleton) : base(_enemybase , _statemachine , anim_bool_name)
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

        if(enemy_sk.isplayerdetected().distance < enemy_sk.attack_range)
            {
                if(can_attack())
                    state_machine.change_state(enemy_sk.attack_state);
            }

        if(Player.position.x > enemy_sk.transform.position.x)
            move_dir = 1;
        else
            move_dir = -1;

        enemy_sk.SetVelocity(3 * move_dir , rb.velocity.y);


        if(!enemy_sk.isplayerdetected() && enemy_sk.transform.position.y >= Player.position.y)
            state_machine.change_state(enemy_sk.idle_state);
    }

    private bool can_attack()
    {
        if(Time.time >= enemy_sk.last_time_attack+ enemy_sk.attack_cooldown)
        {
            return true;
        }

        return false;
    }
}
