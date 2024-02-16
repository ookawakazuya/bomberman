using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    private bool scoreget;//0216
    private bool scoreget2;//0216
    [SerializeField] protected ScoreManeger scoreManeger;//0216

    private void Start()
    {
        breakcount = 0;  
        scoreget = false;//0216
        scoreget2 = false;//0216
        player = GameObject.Find("Player").GetComponent<Player>();
        reloading = false;
    }

    private void Update()
    {    
        if (scoreget)//0216
        {
            ScoreManeger.score_num += 300;
            scoreget = false;
        }

        if (scoreget2)//0216
        {
            ScoreManeger.score_num += 500;
            scoreget2 = false;
        }

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
                scoreget = true;//0216

                //1秒後に消滅
                Destroy(gameObject,0.005f);//0216
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
                    scoreget2 = true;//0216

                    Destroy(gameObject,0.005f);//0216
                    //player.ultpoint++;               
                }
            }
        }
        // Ultimateの壁の処理
        if (collider.gameObject.tag == "Ultimate")
        {
            Destroy(gameObject);
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
