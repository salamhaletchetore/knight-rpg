using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{
    [Header("Collision info")]
    public float hit_range ;
    public Transform hit_range_check;
    private bool knocked ;
    [SerializeField]protected float knocked_time; 
    
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;


    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public entity_fx fx{get ; private set;}
    public enemy Enemy;
    public Player Player;

    #endregion


    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    {
        
    }


    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        fx = GetComponent<entity_fx>();
        Enemy = GameObject.Find("enemy_skleton").GetComponent<enemy_skleton>();
        Player = GameObject.Find("player").GetComponent<Player>();
        
    }


    protected virtual void Update()
    { 
        
    }


    public void damage(string damaged)
    {
        
        fx.StartCoroutine("flash_fx");
        if(damaged == "enemy")
        {
            StartCoroutine("hit_knocked");
        }
    }



    protected virtual IEnumerator hit_knocked()
    {
        knocked = true;

        rb.velocity = new Vector2(12 *-facingDir , 1);

        yield return new WaitForSeconds(knocked_time);

        knocked = false;
    }


    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(hit_range_check.position , hit_range);
    }
    #endregion


    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }

    #endregion

    

    #region Velocity
    public void ZeroVelocity() 
    {

        if(knocked)
            return;        
        
        rb.velocity = new Vector2(0, 0);
        
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if(knocked)
            return; 

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

    #endregion
}
