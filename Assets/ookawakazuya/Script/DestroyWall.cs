using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
	/// <summary>
	/// �Փ˂�����
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		// �Փ˂��������DestroyWall�^�O���t���Ă���Ƃ�
		if (collision.gameObject.tag == "DestroyWall")
		{
			// 0.2�b��ɏ�����
			Destroy(gameObject, 0.2f);
		}
	}
}
