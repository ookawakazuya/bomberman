using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /*[SerializeField]float spawnRangeX = 25;//スポンするオブジェクトのｘ座標
    [SerializeField] float spawnPosZ = 0;*/// スポンするオブジェクトのｚ座標
    public GameObject[] Prefabs;
    private Vector3 spawnPos = new Vector3(25,4,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    //private int number;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        {
            int number = Random.Range(0, Prefabs.Length);
            Instantiate(Prefabs[number], new Vector3(-21, -1, 0), Prefabs[number].transform.rotation);
        }
        // if (playerControllerScript.gameOver == false)
    }
    void Update()
    {
        
    }
}
