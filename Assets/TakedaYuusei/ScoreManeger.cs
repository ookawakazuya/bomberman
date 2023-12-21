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

    void Start()
    {
        
    }
 
    void Update()
    {
       time += Time.deltaTime;

        Text score_text = score_object.GetComponent<Text>();
        
        score_text.text = "Score:" + score_num;

        if(time >= 1)
        {
            time = 0;
            score_num += 100;
        }
        
        /*if(ブロックが壊されたら)//合わせたら書く
        {
            score_num += 300;
        }*/

        if(score_num >= 500)//合わせるとき条件式を(プレイヤーが死んだらにする)
        {
            SceneManager.LoadScene("result");
        }

    }

    public static int getscore_num()
    {
        return score_num;
    }
}
