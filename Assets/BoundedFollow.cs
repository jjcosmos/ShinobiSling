using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float UpperYBound;
    [SerializeField] float LowerYBound;
    [SerializeField] Transform playerTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);

        if(playerTransform.position.y < transform.position.y - LowerYBound)
        {
            //transform.position = playerTransform.position + new Vector3(0, LowerYBound, 0);
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + LowerYBound, transform.position.z);
        }
        if (playerTransform.position.y > transform.position.y + UpperYBound)
        {
            //transform.position = playerTransform.position - new Vector3(0, UpperYBound, 0);
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y - UpperYBound, transform.position.z);
        }
    }
}
