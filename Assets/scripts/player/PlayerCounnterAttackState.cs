using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounnterAttackState : PlayerState
{
    public PlayerCounnterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.counter_attack_duration;
        player.anim.SetBool("successful" , false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.ZeroVelocity();

        Collider2D[] Colliders = Physics2D.OverlapCircleAll(player.hit_range_check.position , player.hit_range);

        foreach(var hit in Colliders)
        {
            if(hit.tag == "Enemy")
            {
                hit.GetComponent<enemy>().damage("enemy");
                if(hit.GetComponent<enemy>().canbestun())
                {
                    stateTimer = 1;
                    player.anim.SetBool("successful" , true);
                }
            }

        }

        if(stateTimer < 0 || triggerCalled)
            {
            player.anim.SetBool("successful" , false);
            stateMachine.ChangeState(player.idleState);
            }
    }
}