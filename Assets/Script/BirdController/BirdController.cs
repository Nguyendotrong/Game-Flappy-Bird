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
    public float flag = 0; //  Bird còn sống: flag = 0, Bird chết: flag = 1
    private GameObject spawner;

    public static BirdController instance; //Đồng bộ hóa các biến và các strcipt với 
    public int score = 0;

    void MakeInstance()
    {
        if (instance == null) //tạo thể hiện
            instance = this;
    }
    void Awake()
    {
        isALive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");//tìm gameObject Spawner Pipe để tí xóa
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

        if (myBody.velocity.y > 0)  // chỉnh rotation của con Bird, 
                                        //khi nó bay lên thì miệng chốc lên và ngược lại
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
    void OnTriggerEnter2D(Collider2D target)// khi bay qua thành công thì phát âm thanh, và tăng điểmS 
    {
        if(target.tag == "PipeHolder" )                      //vì hàm _setScore nằm ở GamePlayController.cs
        {                                                    //nên bên đó phải tạo instance và bên này                   
            score++;                                        //phải gọi thông qua instance
            
            if (GamePlayController.instance != null)
                GamePlayController.instance._setScore(score);
            audioSource.PlayOneShot(pingClip);
        }    
    }
    
    void OnCollisionEnter2D(Collision2D target)// khi đụng đát hoặc ống nước sẽ dừng game, phát âm thanh,
    {
        if(target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")

        {                               //Bird chết->FLAG đổi trạng thái và được instance ở bên PipeHolder
            flag = 1;                     //để hủy script của pipeHolder-> nó sẽ ngừng di chuyển 

            if (isALive == true)            //    khi bird chết không cho click vào FlappButton
            {
                isALive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(DiedClip);
                anim.SetTrigger("Died"); // chuyển animation sang died
            }

            if (GamePlayController.instance != null)
                GamePlayController.instance._BirdDiedShowGamePanel(score);

        }    
    }
}
