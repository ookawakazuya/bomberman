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
    private void OnTriggerEnter(Collider other)
    {
        //�Փ˂����Ƃ��ɑ����Wall�^�O���t���Ă���Ƃ�
        if (other.CompareTag("Explosion"))
        {
            //1�b��ɏ���
            Destroy(gameObject);
            //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            //Destroy(effect, 0.5f);
        }
    }
}
