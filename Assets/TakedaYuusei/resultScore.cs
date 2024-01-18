using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour
{
    [SerializeField] Text playerScore;
    public Text[] ScoreText;
    Text rankIn;
    int score_num;

    // Start is called before the first frame update
    void Start()
    {
        score_num = ScoreManager.getscore_num();
        for (int i = 0; i < RankingManager.instance.scores.Count; i++)
        {
            int score = RankingManager.instance.scores[i];
            ScoreText[i].text = string.Format("Score:{0}", score);

            if(score == score_num) rankIn = ScoreText[i];//ランクインした場合
        }
        playerScore.text = string.Format("Score:{0}",score_num);
    }

    // Update is called once per frame
    void Update()
    {
        //ランクインした場合のアニメーションとか
    }
}
