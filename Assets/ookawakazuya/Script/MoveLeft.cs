using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    private Player playerController;
    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    [SerializeField]private float leftBound = 0;
    void Update()
    {
        //if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    //���Ȃ��u���b�N��󂳂�Ȃ������u���b�N������
    private void OnTriggerEnter(Collider collider)
    {
        //�Փ˂����Ƃ��ɑ����Wall�^�O���t���Ă���Ƃ���
        if(collider.gameObject.tag == "DestroyWall")
        {   //���̃I�u�W�F�N�g�����ł�����
            Destroy(gameObject,2f);
        }
    }
}
