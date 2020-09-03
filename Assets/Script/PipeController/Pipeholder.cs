﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeholder : MonoBehaviour
{
    public float speed;
   

    // Update is called once per frame
    void Update()
    {
        _PipeMovement();

    }
    void _PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

    }
}
