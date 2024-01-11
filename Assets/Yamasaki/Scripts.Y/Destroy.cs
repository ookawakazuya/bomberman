using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float Delay = 3f;
    //Delay in seconds before destroying the gameobject

    void Start()
    {
        Destroy(gameObject, Delay);
    }
}
