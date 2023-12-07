using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
	/// <summary>
	/// Õ“Ë‚µ‚½
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		// Õ“Ë‚µ‚½‘Šè‚ÉDestroyWallƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
		if (collision.gameObject.tag == "DestroyWall")
		{
			// 0.2•bŒã‚ÉÁ‚¦‚é
			Destroy(gameObject, 0.2f);
		}
	}
}
