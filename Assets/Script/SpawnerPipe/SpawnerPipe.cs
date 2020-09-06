﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( Spawner());
    }

   IEnumerator Spawner()
    {
        yield return new WaitForSeconds (1);
        Vector3 temp = transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(pipeHolder, temp, Quaternion.identity);// sinh ra ống nuocs tại vị trí..,cố định , không xoay.

        StartCoroutine(Spawner()); //sinh ra tuần hoàn

    }
}
