using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapple : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerGrapple player;
    [SerializeField] float travelSpeed = 10;

    [SerializeField] Sprite moveSpr;
    [SerializeField] Sprite stickSpr;
    
    Vector3 startPosition;
    Vector3 endPosition;

    AudioSource audioSource;
    SpriteRenderer sprRend;
    LineRenderer lineRend;
    bool moving;
    float grappleTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprRend = GetComponent<SpriteRenderer>();
        lineRend = GetComponent<LineRenderer>();
        //gameObject.SetActive(false);
        //lineRend.gameObject.SetActive(false);
        grappleTimer = 0;
    }

    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
        sprRend = GetComponent<SpriteRenderer>();
        //lineRend = GetComponent<LineRenderer>();
        gameObject.SetActive(false);
        //lineRend.gameObject.SetActive(false);
        grappleTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lineRend.SetPositions(new Vector3[] { transform.position + new Vector3(0, 0, -.1f), player.transform.position + new Vector3(0, 0, 0) });
        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, grappleTimer);
            grappleTimer += Time.deltaTime * travelSpeed;


        }
        else grappleTimer = 1;
        if (moving && Vector3.Distance(transform.position, endPosition) < .02f)
        {
            sprRend.sprite = stickSpr;
            moving = false;
            player.Grappling = true;
        }
    }

    private void OnEnable()
    {
        //lineRend = GetComponent<LineRenderer>();
        
        lineRend.SetPositions(new Vector3[] { transform.position + new Vector3(0, 0, -.1f), player.transform.position + new Vector3(0, 0, 0) });
        //sprRend = GetComponent<SpriteRenderer>();

        startPosition = player.transform.position;
        endPosition = player.CurrentGrappleTarget;
        sprRend.sprite = moveSpr;
        transform.position = startPosition;
        grappleTimer = 0;
        moving = true;
        audioSource.Play();
    }
}
