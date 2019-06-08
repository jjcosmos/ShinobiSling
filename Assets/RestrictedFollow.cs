using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float Y_Offset;
    Vector3 camOffset;
    void Start()
    {
        camOffset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x - camOffset.x, transform.position.y, transform.position.z);
        if (target.position.y > transform.position.y + camOffset.y)
        {
            transform.position = target.position - camOffset;
        }
        
        
    }
}
