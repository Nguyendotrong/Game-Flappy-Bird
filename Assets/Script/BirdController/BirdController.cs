using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;
    private bool isALive;
    private bool didFlap;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, DiedClip;


    void Awake()
    {
        isALive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        _BirdMoveMent();
    }
    void _BirdMoveMent()
    {
        if(isALive)
            if(didFlap)
            {
                didFlap = false; 
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }    
        /*if (Input.GetMouseButtonDown(0))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
            audioSource.PlayOneShot(flyClip);
        }*/

        if (myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);

        }
        else if (myBody.velocity.y == 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);

        }
       
    }
    public void FlappButton()
    {
        didFlap = true;
    }
}
