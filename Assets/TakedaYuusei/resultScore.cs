using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour
{
    public Text ScoreText;
    int score_num;

    // Start is called before the first frame update
    void Start()
    {
        score_num = ScoreManager.getscore_num();

        ScoreText.text = string.Format("Score:{0}",score_num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
