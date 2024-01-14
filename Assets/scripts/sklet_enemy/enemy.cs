using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : entity
{
    public enemy_state_machine state_machine{get; private set;}

    public float player_check_distance;
    public LayerMask whatisplayer ;

    [Header("stun info")]
    public float stun_duration;
    public Vector2 stun_direction;
    protected bool can_be_stun;
    [SerializeField] protected GameObject counter_image;

    [Header("attack info")]
    public float attack_range;
    public float attack_cooldown;
    [HideInInspector]public float last_time_attack;
    [SerializeField]protected Transform attack_check;



    protected override void Awake()
    {
        base.Awake();
        state_machine = new enemy_state_machine() ;
    }

    
    protected override void Update()
    {
        base.Update();
        state_machine.current_state.Update();

        Debug.Log(player_check_distance);
        Debug.Log(isplayerdetected());
    }


    public virtual RaycastHit2D isplayerdetected() => Physics2D.Raycast(attack_check.position , Vector2.right *facingDir , player_check_distance , whatisplayer ) ;

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position , new Vector3(transform.position.x + attack_range * facingDir , transform.position.y));
    }


    public virtual void open_counter_window()
    {
        can_be_stun = true;
        counter_image.SetActive(true);
    }


    public virtual void close_counter_window()
    {
        can_be_stun = false;
        counter_image.SetActive(false);
    }


    public virtual bool canbestun()
    {
        if(can_be_stun)
        {
            close_counter_window();
            return true;
        } 

        return false;   
    }
    public virtual void AnimationFinishTrigger() => state_machine.current_state.AnimationFinishTrigger();
}

