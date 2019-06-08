using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    bool Dying;
    // Start is called before the first frame update
    [SerializeField] Animation WipeOutAnim;

    AudioSource audiosource;
    void Start()
    {
        PlayerGrapple.canMove = true;
        Dying = false;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player Collision");
        if (collision.collider.CompareTag("Enemy"))
        {
            //TODO Death sequence
            if (!Dying)
            {
                StartCoroutine(DeathSequ());
                Dying = true;
            }
            
        }
        else
        {
            Debug.Log(collision.collider.name);
        }
    }

    IEnumerator DeathSequ()
    {
        audiosource.Play();
        GetComponent<PlayerGrapple>().stopGrapple();
        PlayerGrapple.canMove = false;
        transform.Rotate(new Vector3(0, 0, 180));
        yield return new WaitForSeconds(3f);
        WipeOutAnim.Play("WipeTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
