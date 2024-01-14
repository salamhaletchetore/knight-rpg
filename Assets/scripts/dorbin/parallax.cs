using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private GameObject dorbin;

    [SerializeField] private float parallax_effect ;

    private float first_x_position;
    // Start is called before the first frame update
    void Start()
    {
        dorbin = GameObject.Find("Main Camera");

        first_x_position = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance_to_move = dorbin.transform.position.x * parallax_effect;
        transform.position = new Vector3(first_x_position + distance_to_move , transform.position.y );
        
    }
}
