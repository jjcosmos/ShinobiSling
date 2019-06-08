using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, target.position.y - target.position.y/10, transform.position.z);
    }
}
