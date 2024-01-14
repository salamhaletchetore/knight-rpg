using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dorbin : MonoBehaviour
{
    [SerializeField] private Transform player ;
    private float narmi = 0.4f;
    private Vector3 velocity = new Vector3(3,0,0) ;
    private Vector3 distance_z = new Vector3 (0,0,-9);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dorbin_place = player.position + distance_z + new Vector3(0,3,0);
        transform.position = Vector3.SmoothDamp(transform.position , dorbin_place , ref velocity , narmi);
    }
}
