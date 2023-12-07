using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transfomWoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 自分自身のTransformを取得
        Transform myTransform = this.transform;

        // 先ほど取得したTransformの情報から座標の情報を取得
        // Vector3：3D ベクトルと位置の表現
        Vector3 pos = myTransform.position;

        // x,y,z座標の値をフレームごと0.05加算する
        pos.x -= 0.05f;

        // 自分の座標を加算した値に設定
        myTransform.position = pos;
    }
}
