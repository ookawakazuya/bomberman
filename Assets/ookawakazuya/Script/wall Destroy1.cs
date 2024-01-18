using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDestroy1 : MonoBehaviour
{
    //壁にボックスコライダーを追加
    //このプログラムを追加
    //当たり判定のプログラムでColliderに変更する
    //プレイヤーが消滅したとに、オブジェクトの生成と移動を終了させる
    //ボムにボックスコライダーを追加
    //
    //

        public void OnTriggerEnter(Collider collider)
        {
            //衝突したときに相手にWallタグが付いているときに
             if (collider.gameObject.tag == "DestroyWall")
            {   //このオブジェクトを消滅させる
                Destroy(gameObject, 2f);
                Debug.Log("確殺");
            }
        }
}
