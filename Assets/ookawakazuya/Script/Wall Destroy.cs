using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// 衝突した時
    /// </summary>
    /// <param name="collision"></param>
    [SerializeField] private float speed = 30;
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider collider)
    {
		//衝突したときに相手にWallタグが付いているとき
        if (collider.gameObject.tag == "DestroyWall")
        {
			//5秒後に消える
            Destroy(gameObject,3.0f);
        }
    }
}
