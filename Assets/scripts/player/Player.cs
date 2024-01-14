using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : entity
{

    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counter_attack_duration = .2f;

    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash info")]
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }



    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }    
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerDashState dashState { get; private set; }

    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerCounnterAttackState counterAttack{get; private set;}
    #endregion

    protected override void Awake()
    {
        base.Awake();
        
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState  = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounnterAttackState(this , stateMachine , "counterattack");
    }

    protected override void Start()
    {
         base.Start();

        stateMachine.Initialize(idleState);

    }


    protected override void Update()
    {

        base.Update();
        stateMachine.currentState.Update();


        CheckForDashInput();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;        

        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        if (IsWallDetected())
            return;

        dashUsageTimer -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift) && skill_manager.instance.dash.can_use_skill())
        {
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;

            
            stateMachine.ChangeState(dashState);
        }
    }

    

    
    
}
