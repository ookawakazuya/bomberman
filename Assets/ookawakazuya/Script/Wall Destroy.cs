using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// 衝突した時
    /// </summary>
    /// <param name="collision"></param>

    public GameObject effectPrefab;

    private void Update()
    {

    }
    //爆発でブロックを消す
    public void OnTriggerEnter(Collider collider)
    {
        //触れた時、自身に対応するタグが付いていた場合
        if (gameObject.name == "breakWall")
        {
            //衝突したときに相手にExplosionタグが付いているとき
            if (collider.CompareTag("Explosion"))
            {
                //1秒後に消滅
                Destroy(gameObject);
                Debug.Log("爆散");
                //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                //Destroy(effect, 0.5f);
            } 
        }
        //衝突したときに相手にDestroyWallタグが付いているときに
        else if (collider.gameObject.tag == "DestroyWall")
        {   //このオブジェクトを消滅させる
            Destroy(gameObject, 2f);
            Debug.Log("消滅");
        }
    }
}
