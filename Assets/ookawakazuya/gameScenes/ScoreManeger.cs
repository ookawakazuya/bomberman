using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;

public class ScoreManeger : MonoBehaviour
{
    public GameObject score_object = null; // Text
    public static int score_num = 0; // �X�R�A�ϐ�
    float time;
    bool alive = true;
    [SerializeField] protected Player player;



    void Start()
    {
        
    }

    private void AliveScore()
    {
        time += Time.deltaTime;

        Text score_text = score_object.GetComponent<Text>();

        /*if(�u���b�N���󂳂ꂽ��)//���킹���珑��
        {
            score_num += 300;
        }*/

        if (player.alive == false) //collision.gameObject.name == "LimitWall" ���킹��Ƃ���������(�v���C���[�����񂾂�ɂ���)
        {
            RankingManager.instance.AddScore(score_num);
            Invoke("Deray", 2.0f);//�X�R�A�����Z�����܂ł̋󔒎���
            alive = false;

        }

        if (time >= 1)//�X�R�A���Z
        {
            time = 0;
            score_num += 0;

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
        SceneManager.LoadScene("result");//���U���g��ʂֈړ�
    }

    public static int getscore_num()
    {
        return score_num;
    }
}
