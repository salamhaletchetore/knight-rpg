using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_skleton : enemy
{


    public SkletonIdleState idle_state {get; private set;}

    public SkletonMoveState move_state {get; private set;}

    public SkletonBattleState battle_state{get; private set;}

    public SkletonAttackState attack_state{get; private set;}

    public SkletonStunState stun_state{get; private set;}

    //public SkletonGroundState ground_state{get; private set;}


    protected override void Awake()
    {
        base.Awake();
        idle_state = new SkletonIdleState(this , state_machine, "Idle" , this);
        move_state = new SkletonMoveState(this , state_machine, "Move" , this);
        battle_state = new SkletonBattleState(this , state_machine , "Move" , this);
        attack_state = new SkletonAttackState(this , state_machine , "Attack" , this);
        stun_state = new SkletonStunState(this , state_machine , "Stun" , this);
        //ground_state = new SkletonGroundState(this , state_machine , "  " , this);
    }


    protected override void Start()
    {
        base.Start();
        state_machine.Initialize(idle_state);
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.U))
        {
            state_machine.change_state(stun_state);
        }
    }


    public override bool canbestun()
    {
        if(base.canbestun())
        {
            state_machine.change_state(stun_state);
            return true;
        }

        return false;
    }



}
