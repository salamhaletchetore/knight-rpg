using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_state_machine : MonoBehaviour
{
    public enemy_state current_state {get ; private set ;}

    public void Initialize (enemy_state _startstate)
    {
        current_state = _startstate ;
        current_state.Enter();
    }

    public void change_state(enemy_state _new_state)
    {
        current_state.Exit();
        current_state = _new_state;
        current_state.Enter();

    }
}
