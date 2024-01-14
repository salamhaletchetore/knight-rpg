using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manager : MonoBehaviour
{
    public static player_manager instance;
    public Player player;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);
        else 
            instance = this ;
    }
}
