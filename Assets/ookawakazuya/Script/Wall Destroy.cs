using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// �Փ˂�����
    /// </summary>
    /// <param name="collision"></param>

    public GameObject effectPrefab;
    public int breakcount;
    private Player player;

    private void Start()
    {
        breakcount = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    //�����Ńu���b�N������
    public void OnTriggerEnter(Collider collider)
    {
        //�G�ꂽ���A���g�̖��O��breakWall�������ꍇ
        if (gameObject.name == "breakWall")
        {
            //�Փ˂����Ƃ��ɑ����Explosion�^�O���t���Ă���Ƃ�
            if (collider.CompareTag("Explosion"))
            {
                //1�b��ɏ���
                Destroy(gameObject);
                //player.ultpoint++;
            }
        }
        //�Փ˂����Ƃ��Ɏ��M�̖��O��breakWall+1�������ꍇ
        else if(gameObject.name == "breakWall+1")
        {
            //�Փ˂����Ƃ��ɑ����Explosion�^�O���t���Ă���Ƃ�
            if (collider.CompareTag("Explosion"))
            { 
                //�J�E���g��1�ǉ�����
                breakcount++;
                Debug.Log("+1");
                if(breakcount >= 2)
                {
                    Destroy(gameObject);
                    //player.ultpoint++;
                }
            }
        }
        //�Փ˂����Ƃ��ɑ����DestroyWall�^�O���t���Ă���Ƃ���
        if (collider.gameObject.tag == "DestroyWall")
        {   //���̃I�u�W�F�N�g�����ł�����
            Destroy(gameObject, 2f);
        }
    }
}
