using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BombType.type = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPush1()
    {
        BombType.type = 0;
    }
    public void OnPush2()
    {
        BombType.type = 1;
    }
    public void OnPush3()
    {
        BombType.type = 2;
    }
    public void OnPush4()
    {
        BombType.type = 3;
    }
}
