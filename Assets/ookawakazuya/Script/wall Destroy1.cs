using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDestroy1 : MonoBehaviour
{
    //�ǂɃ{�b�N�X�R���C�_�[��ǉ�
    //���̃v���O������ǉ�
    //�����蔻��̃v���O������Collider�ɕύX����
    //�v���C���[�����ł����ƂɁA�I�u�W�F�N�g�̐����ƈړ����I��������
    //�{���Ƀ{�b�N�X�R���C�_�[��ǉ�
    //
    //

        public void OnTriggerEnter(Collider collider)
        {
            //�Փ˂����Ƃ��ɑ����Wall�^�O���t���Ă���Ƃ���
             if (collider.gameObject.tag == "DestroyWall")
            {   //���̃I�u�W�F�N�g�����ł�����
                Destroy(gameObject, 2f);
                Debug.Log("�m�E");
            }
        }
}
