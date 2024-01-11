using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    private Vector3 spawnPos = new Vector3(25, 4, 0);// 生成される座標
    private float startDelay = 2;
    private float repeatRate = 2;
    //private int number;

    void Start()
    {
        // オブジェクトを生成する機構
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        {
            //オブジェクトが生成される位置
            int number = Random.Range(0, Prefabs.Length);
            Instantiate(Prefabs[number], new Vector3(-21, -1, 0), Prefabs[number].transform.rotation);
        }
        // if (playerController.gameOver == false)
    }
    void Update()
    {
        
    }
}
