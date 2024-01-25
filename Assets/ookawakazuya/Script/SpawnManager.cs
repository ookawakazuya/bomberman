using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject[] Prefabs2;
    private float startDelay = 4;
    private float repeatRate = 4;
    private Player player;
    public int count;
    //private int number;

    void Start()
    {
        count = 0;
        // オブジェクトを生成する機構
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void SpawnObstacle()
    {
        if (player.alive == true)
        {
            if(count <= 20) 
            { 
                //オブジェクトが生成される位置
                int number = Random.Range(0, Prefabs.Length);
                Instantiate(Prefabs[number], new Vector3(-21, 0, 0), Prefabs[number].transform.rotation);
                count++;
            }
            else if(count >= 21)
            {
         
                int number = Random.Range(0,Prefabs2.Length);
                int number1 = Random.Range(0, Prefabs2.Length);
                int number2 = Random.Range(0, Prefabs2.Length);
                int number3 = Random.Range(0, Prefabs2.Length);
                int number4 = Random.Range(0, Prefabs2.Length);
                int number5 = Random.Range(0, Prefabs2.Length);
                int number6 = Random.Range(0, Prefabs2.Length);
                int number7 = Random.Range(0, Prefabs2.Length);
                int number8 = Random.Range(0, Prefabs2.Length);
                int number9 = Random.Range(0, Prefabs2.Length);
                int number10 = Random.Range(0, Prefabs2.Length);
                int number11 = Random.Range(0, Prefabs2.Length);
                int number12 = Random.Range(0, Prefabs2.Length);
                Instantiate(Prefabs2[number1],new Vector3(-21,0,4),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number2],new Vector3(-21,0,3),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number3],new Vector3(-21,0,2),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number4],new Vector3(-21,0,1),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number5],new Vector3(-21,0,0),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number6],new Vector3(-21,0,-1),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number7],new Vector3(-21,0,-2),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number8],new Vector3(-21,0,-3),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number9],new Vector3(-21,0,-4),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number10],new Vector3(-21,0,-5),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number11],new Vector3(-21,0,-6),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number12],new Vector3(-21,0,-7),Prefabs2[number].transform.rotation);

            }
        }
        // if (playerController.gameOver == false)
    }
    void Update()
    {
        
    }
}
