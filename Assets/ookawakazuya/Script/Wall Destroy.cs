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
    public int breakcount;
    private Player player;
    bool reloading;//硬い壁の爆発ロード時間

    private void Start()
    {
        breakcount = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        reloading = false;
    }
    //爆発でブロックを消す
    public void OnTriggerEnter(Collider collider)
    {
        //触れた時、自身の名前がbreakWallだった場合
        if (gameObject.name == "breakWall")
        {
            //衝突したときに相手にExplosionタグが付いているとき
            if (collider.CompareTag("Explosion"))
            {
                //1秒後に消滅
                Destroy(gameObject);
                //player.ultpoint++;
            }
        }
        //衝突したときに自信の名前がbreakWall+1だった場合
        else if(gameObject.name == "breakWall+1" && !reloading)
        {
            //衝突したときに相手にExplosionタグが付いているとき
            if (collider.CompareTag("Explosion"))
            { 
                StartCoroutine(Reload());
                if(breakcount >= 2)
                {
                    Destroy(gameObject);
                    //player.ultpoint++;
                }
            }
        }
        //衝突したときに相手にDestroyWallタグが付いているときに
        if (collider.gameObject.tag == "DestroyWall")
        {   //このオブジェクトを消滅させる
            Destroy(gameObject, 2f);
        }
    }

    private IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("待機時間開始");
        yield return new WaitForSeconds(2);

        //カウントを1追加する
        breakcount++;
        Debug.Log("カウント+1");
        reloading = false;
    }
}
