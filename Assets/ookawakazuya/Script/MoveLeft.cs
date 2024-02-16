using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    private Player player;
    SpawnManager spawnmanager;
    GameObject obj;
    bool loading;
    void Start()
    {
        speed = 1;
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
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(spawnmanager.count >= 30)
        {
            speed = 2;
        }
        if (spawnmanager.count >= 50)
        {
            speed = 3;
        }
    }

//���Ȃ��u���b�N��󂳂�Ȃ������u���b�N������
public void OnTriggerEnter(Collider collider)
    {
        //�Փ˂����Ƃ��ɑ����Wall�^�O���t���Ă���Ƃ���
        if (collider.gameObject.tag == "DestroyWall")
        {   //���̃I�u�W�F�N�g�����ł�����
            Destroy(gameObject, 2f);
        }
    }
}
