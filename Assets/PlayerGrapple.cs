using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool canMove;
    Camera cam;
    Rigidbody2D RB2d;
    public Vector3 CurrentGrappleTarget;
    public bool Grappling;
    SpriteRenderer SprRend;

    [SerializeField] float distanceToGrappleSleep = 1;
    [SerializeField] float grappleForce = 100;
    [SerializeField] Transform grapplingHook;

    public Sprite upSpr;
    public Sprite downSpr;
    [SerializeField] AudioClip releaseNoise;

    AudioSource audioSource;
    LayerMask mask;
    void Start()
    {
        upSpr = PurchaseManager.Instance.Costumes[PurchaseManager.Instance.PlayerCostume - 1].GetFrame1();
        downSpr = PurchaseManager.Instance.Costumes[PurchaseManager.Instance.PlayerCostume -1 ].GetFrame2();

        audioSource = GetComponent<AudioSource>();
        //grapplingHook.gameObject.SetActive(false);
        cam = Camera.main;
        RB2d = GetComponent<Rigidbody2D>();
        SprRend = GetComponent<SpriteRenderer>();
        mask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPosition = new Vector3();
        if (Input.GetButtonDown("Fire1") && !Grappling && canMove)
        {
            Debug.Log("ButtonPressed");
            grapplingHook.gameObject.SetActive(false);
            Vector3 position = new Vector3();
            position.x = Input.mousePosition.x;
            position.y = Input.mousePosition.y;
            position.z = 0;

            endPosition = cam.ScreenToWorldPoint(position);
            endPosition.z = 0;


            if (CheckWallTile(endPosition))
            {
                CurrentGrappleTarget = endPosition;
                grapplingHook.GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, transform.position });
                grapplingHook.gameObject.SetActive(true);
            }
            
        }

        if (Grappling)
        {
            RB2d.AddForce(Vector3.Normalize(CurrentGrappleTarget - transform.position) * grappleForce * Time.deltaTime);
            if (Vector3.Distance(transform.position, CurrentGrappleTarget) < distanceToGrappleSleep)
            {
                Grappling = false;
                RB2d.velocity = RB2d.velocity * .2f;
                grapplingHook.gameObject.SetActive(false);
                Debug.Log("Grapple id False");
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Grappling = false;
                grapplingHook.gameObject.SetActive(false);
                audioSource.PlayOneShot(releaseNoise);
            }
        }

        if(RB2d.velocity.y > 0)
        {
            SprRend.sprite = upSpr;
        }
        else{
            SprRend.sprite = downSpr;
        }
    }

    private bool CheckWallTile(Vector2 pos)
    {
        if (Physics2D.OverlapBox(pos, Vector2.one * .05f, 0, mask))
        {
            return true;
        }
        return false;
    }

    public void stopGrapple()
    {
        Grappling = false;
        grapplingHook.GetComponent<LineRenderer>().enabled=false;

    }
}
