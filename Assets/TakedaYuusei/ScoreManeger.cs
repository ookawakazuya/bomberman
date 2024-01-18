using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Text
    public static int score_num = 0; // スコア変数
    float time;
    bool alive = true;



    void Start()
    {
        
    }

    private void AliveScore()
    {
        time += Time.deltaTime;

        Text score_text = score_object.GetComponent<Text>();

        /*if(ブロックが壊されたら)//合わせたら書く
        {
            score_num += 300;
        }*/

        if (score_num >= 500) //collision.gameObject.name == "LimitWall" 合わせるとき条件式を(プレイヤーが死んだらにする)
        {
            RankingManager.instance.AddScore(score_num);
            Invoke("Deray", 2.0f);
            alive = false;

        }

        if (time >= 100)//スコア加算
        {
            time = 0;
            score_num += 1;
        }

        score_text.text = "Score:" + score_num;
    }

    void Update()
    {

        if (alive)
        {
            AliveScore();
        }
        else
        {

        }

    }

    private void Deray()
    {
        SceneManager.LoadScene("result");//リザルト画面へ移動
    }

    public static int getscore_num()
    {
        return score_num;
    }
}
