using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// �Փ˂�����
    /// </summary>
    /// <param name="collision"></param>
    [SerializeField] private float speed = 30;
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider collider)
    {
		//�Փ˂����Ƃ��ɑ����Wall�^�O���t���Ă���Ƃ�
        if (collider.gameObject.tag == "DestroyWall")
        {
			//5�b��ɏ�����
            Destroy(gameObject,3.0f);
        }
    }
}
