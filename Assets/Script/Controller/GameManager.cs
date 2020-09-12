using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

   void Awake ()
    {

    }
    void _MakeSingleInstance ()
    {
        if (instance != null)
            instance = this;
    }
}
