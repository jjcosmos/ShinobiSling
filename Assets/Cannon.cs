using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool isTrackingCannon;
    [SerializeField] bool startFaceLeft;
    [SerializeField] float ballSpeed;
    [SerializeField] float fireRate;
    [SerializeField] float trackingRate;

    [SerializeField] Rigidbody2D CannonBallObject;

    [SerializeField] Sprite NormalCannonRight;
    [SerializeField] Sprite NormalCannonLeft;

    [SerializeField] Sprite TrackingCannonRight;
    [SerializeField] Sprite TrackingCannonLeft;
    [SerializeField] Sprite TrackingCannonRightON;
    [SerializeField] Sprite TrackingCannonLeftON;

    [SerializeField] Sprite NormalBaseSprite;
    [SerializeField] Sprite TrackingBaseSprite;

    SpriteRenderer spriteRenderer; // cannon base
    SpriteRenderer childSpriteRenderer; // cannon barrel
    Transform FPointL;
    LineRenderer linerRenderer;
    Vector3 playerLagTarget;
    
    Transform Player;
    private float fireTimer;
    private bool Tracking;
    LayerMask player_mask;
    bool LineRefresh;
    [SerializeField] AudioClip cannonClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CannonBallObject.gameObject.SetActive(false);
        linerRenderer = GetComponent<LineRenderer>();
        Tracking = true;

        player_mask = LayerMask.GetMask("Player");
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        fireTimer = fireRate;

        spriteRenderer = GetComponent<SpriteRenderer>();
        childSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        FPointL = transform.GetChild(0).Find("FirePointL");
        

        if (isTrackingCannon)
        {
            spriteRenderer.sprite = TrackingBaseSprite;

            if (startFaceLeft)
            {
                childSpriteRenderer.sprite = TrackingCannonLeft;
            }
            else
            {
                childSpriteRenderer.sprite = TrackingCannonRight;
            }
        }
        else
        {
            spriteRenderer.sprite = NormalBaseSprite;

            if (startFaceLeft)
            {
                childSpriteRenderer.sprite = NormalCannonLeft;
            }
            else
            {
                childSpriteRenderer.sprite = NormalCannonRight;
            }
        }

        if (!startFaceLeft)
        {
            childSpriteRenderer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }

        CannonBallObject.transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //spriteRenderer.isVisible
        if (Vector3.Distance(Player.transform.position, transform.position) <= 10)
        {
            if (Tracking)
            {
                playerLagTarget = Vector3.Lerp(playerLagTarget, Player.transform.position, Time.deltaTime * trackingRate);
            }

            if (isTrackingCannon)
            {
                TrackerUpdate();
            }

            else
            {
                NormalUpdate();
            }

        }
        else
        {
            linerRenderer.enabled = false;
        }
    }

    void TrackerUpdate()
    {

        if (!LineRefresh)
        {
            linerRenderer.enabled = true;
        }
        if (Tracking)
        {
            childSpriteRenderer.transform.LookAt(playerLagTarget);
            childSpriteRenderer.transform.rotation = XLookRotation2D(-childSpriteRenderer.transform.forward);
            //Quaternion temp = XLookRotation2D(-childSpriteRenderer.transform.forward);
            //childSpriteRenderer.transform.rotation = Quaternion.Slerp(childSpriteRenderer.transform.rotation, temp, Time.deltaTime);

        }

        if (Player.position.x > transform.position.x && Tracking)
        {
            childSpriteRenderer.sprite = TrackingCannonRight;
        }
        else
        {
            childSpriteRenderer.sprite = TrackingCannonLeft;
        }

        fireTimer += Time.deltaTime;
        if(fireTimer > fireRate && Physics2D.Raycast(childSpriteRenderer.transform.position, FPointL.right, 20, player_mask))
        {
            //fire
            Fire();

            StopAllCoroutines();
            StartCoroutine(DisableLineRenderer());
            StartCoroutine(StopTracking());
            fireTimer = 0;
        }

        linerRenderer.SetPositions(new Vector3[] {FPointL.position, FPointL.position + FPointL.right * 10 + new Vector3(0,0,.1f) });

        
    }

    IEnumerator DisableLineRenderer()
    {
        LineRefresh = true;
        linerRenderer.enabled = false;
        yield return new WaitForSeconds(fireRate/2);
        linerRenderer.enabled = true;
        LineRefresh = false;
    }

    IEnumerator StopTracking()
    {
        Tracking = false;
        yield return new WaitForSeconds(1);
        Tracking = true;
    }

    void NormalUpdate()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireRate)
        {
            Fire();
            fireTimer = 0;
        }

    }

    void Fire()
    {
        CannonBallObject.gameObject.SetActive(true);
        CannonBallObject.position = FPointL.position;
        CannonBallObject.GetComponent<Rigidbody2D>().velocity = FPointL.right * ballSpeed;
        CannonBallObject.GetComponent<Rigidbody2D>().angularVelocity = 1000;
        CannonBallObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        audioSource.PlayOneShot(cannonClip);
    }



    Quaternion XLookRotation2D(Vector3 right)
    {
        Quaternion rightToUp = Quaternion.Euler(0f, 0f, 90f);
        Quaternion upToTarget = Quaternion.LookRotation(Vector3.forward, right);

        return upToTarget * rightToUp;
    }
}
