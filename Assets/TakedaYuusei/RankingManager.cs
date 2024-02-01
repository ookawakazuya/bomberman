using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance; // インスタンスの定義
    //public int[] number = new int[5]; // この変数にアクセスしたい
    public List<int> scores = new List<int>();

    private void Awake()
    {
        // シングルトンの呪文
        if (instance == null)
        {
            // 自身をインスタンスとする
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitScore();
        }
        else
        {
            // インスタンスが複数存在しないように、既に存在していたら自身を消去する
            Destroy(gameObject);
        }
    }

    private void InitScore()
    {
        for(int i = 0; i < 5; i++)
        {
            scores.Add(i * 10);
        }
    }

    public void AddScore(int value)
    {
        scores.Add(value);
        //sort
        //int[] sco = {3,1,5,4,2};
        //var list = new List<int>();

        //list.AddRange(sco);
        Debug.Log(scores[5]);
        scores.Sort();
        scores.Reverse();
        Debug.Log(scores[0]);
        /*Console.WriteLine("[{0}]", string.Join(", ", list));
        Console.ReadKey();*/

        // 一番下の変数を消す
        scores.RemoveAt(scores.Count - 1);    
    }
}
