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

    private void Update()
    {

    }
    //�����Ńu���b�N������
    public void OnTriggerEnter(Collider collider)
    {
        //�G�ꂽ���A���g�ɑΉ�����^�O���t���Ă����ꍇ
        if (gameObject.name == "breakWall")
        {
            //�Փ˂����Ƃ��ɑ����Explosion�^�O���t���Ă���Ƃ�
            if (collider.CompareTag("Explosion"))
            {
                //1�b��ɏ���
                Destroy(gameObject);
                Debug.Log("���U");
                //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                //Destroy(effect, 0.5f);
            } 
        }
        //�Փ˂����Ƃ��ɑ����DestroyWall�^�O���t���Ă���Ƃ���
        else if (collider.gameObject.tag == "DestroyWall")
        {   //���̃I�u�W�F�N�g�����ł�����
            Destroy(gameObject, 2f);
            Debug.Log("����");
        }
    }
}
