using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance; // �C���X�^���X�̒�`
    //public int[] number = new int[5]; // ���̕ϐ��ɃA�N�Z�X������
    public List<int> scores = new List<int>();

    private void Awake()
    {
        // �V���O���g���̎���
        if (instance == null)
        {
            // ���g���C���X�^���X�Ƃ���
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitScore();
        }
        else
        {
            // �C���X�^���X���������݂��Ȃ��悤�ɁA���ɑ��݂��Ă����玩�g����������
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

        // ��ԉ��̕ϐ�������
        scores.RemoveAt(scores.Count - 1);    
    }
}
