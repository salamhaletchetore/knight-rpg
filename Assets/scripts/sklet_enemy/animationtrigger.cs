using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationtrigger : MonoBehaviour
{
    private enemy_skleton enemy => GetComponentInParent<enemy_skleton>();

    private void animation_trigger()
    {
        enemy.AnimationFinishTrigger();
    }

    private void attack_trigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.hit_range_check.position , enemy.hit_range);

        foreach (var hit in colliders)
        {
            if(hit.tag == "Player")
                hit.GetComponent<Player>().damage("player");
        }
    }

    private void open_counter_window() => enemy.open_counter_window();

    private void close_counter_window() => enemy.close_counter_window(); 
}
