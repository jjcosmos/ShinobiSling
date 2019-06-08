using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationSpeed;
    SpriteRenderer SprRend;
    void Start()
    {
        SprRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SprRend.isVisible)
        {
            transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);
        }
    }
}
