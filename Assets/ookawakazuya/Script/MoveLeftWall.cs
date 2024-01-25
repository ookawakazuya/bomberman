using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftWall : MonoBehaviour
{
    [SerializeField] private float speed;
    private Player player;
    SpawnManager spawnmanager;
    GameObject obj;
    void Start()
    {
        speed = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        obj = GameObject.Find("Spawn Manager");
        spawnmanager = obj.GetComponent<SpawnManager>();

    }

    // [SerializeField]private float leftBound = 0;
    void Update()
    {
        //�v���C���[�����ł����Ƃ��ɃI�u�W�F�N�g�̐������I��������
        if (player.alive == true)
        {
            if(spawnmanager.count == 21)
            {
                speed = 1;
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            
        }
    }
}
