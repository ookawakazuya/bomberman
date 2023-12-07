using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
	/// <summary>
	/// 衝突した時
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		// 衝突した相手にDestroyWallタグが付いているとき
		if (collision.gameObject.tag == "DestroyWall")
		{
			// 0.2秒後に消える
			Destroy(gameObject, 0.2f);
		}
	}
}
