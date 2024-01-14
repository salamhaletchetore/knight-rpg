using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] Colliders = Physics2D.OverlapCircleAll(player.hit_range_check.position , player.hit_range);

        foreach(var hit in Colliders)
        {
            if(hit.tag == "Enemy")
                hit.GetComponent<enemy>().damage("enemy");
        }
    } 
}
