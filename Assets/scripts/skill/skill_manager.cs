using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_manager : MonoBehaviour
{
    public static skill_manager instance;
    public dash_skill dash;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);
        else 
            instance = this ;
    }

    private void Start()
    {
        dash = GetComponent<dash_skill>();
    }
}
