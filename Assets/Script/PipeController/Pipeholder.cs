using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeholder : MonoBehaviour
{
    public float speed;
   

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance != null)
            if (BirdController.instance.flag == 1)  //Biến cờ được thể hiện từ script BirdController
                Destroy(GetComponent<Pipeholder>());//khi và chạm với ống nước-> flag =1 
                                               //-> xóa file sctript của pipe holder-> ngừng chạy
        _PipeMovement();

    }
    void _PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

    }
    /*void OnCollisionEnter2D(Collision2D target) // 2 đối tượng đều ko tích isTrigger
    {

    }*/
    void OnTriggerEnter2D(Collider2D target) //1 trong 2 đối tượng có tích isTrigger
    {
        if (target.tag == "Destroy")
            Destroy(gameObject);
    }
}
