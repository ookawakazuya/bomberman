using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    private Vector3 spawnPos = new Vector3(25, 4, 0);// �����������W
    private float startDelay = 4;
    private float repeatRate = 4;
    private Player player;
    //private int number;

    void Start()
    {
        // �I�u�W�F�N�g�𐶐�����@�\
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void SpawnObstacle()
    {
        if (player.alive == true)
        {
            //�I�u�W�F�N�g�����������ʒu
            int number = Random.Range(0, Prefabs.Length);
            Instantiate(Prefabs[number], new Vector3(-21, 0, 0), Prefabs[number].transform.rotation);
        }
        // if (playerController.gameOver == false)
    }
    void Update()
    {
        
    }
}
