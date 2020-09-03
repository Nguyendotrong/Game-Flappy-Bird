using System.Collections;
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
        Instantiate(pipeHolder, transform.position, Quaternion.identity);
        StartCoroutine(Spawner());

    }
}
