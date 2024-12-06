using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject[] Prefabs2;
    private float startDelay=0;
    private float repeatRate=7;
    private Player player;
    public int count;
    //private int number;
    [SerializeField] Text Leveltext;

    void Start()
    {
        count = 0;
        // オブジェクトを生成する機構
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine("Level1");
    }

    void SpawnObstacle()
    {
        int x;//レベルアップしたときの生成される右端の座標
        float y = 1.5f;
        int z = -13;
        //カウントが19以下の処理
        if (player.alive == true)
        {
            if(count <= 19) 
            {
                x = -2;
                //オブジェクトが生成される位置
                int number = Random.Range(0, Prefabs.Length);//決められた配列に並んでいる壁をランダムで決める
                Instantiate(Prefabs[number], new Vector3(x,y,z), Prefabs[number].transform.rotation);
                count++;
            }
            //配列をランダムな順で生成する
            else if(count >= 20)
            {
                x = 2;
                for (int i = 0; i < 12; i++)//壁が1列分生成されるまで回す
                {
                    int number = Random.Range(0, Prefabs2.Length);//生成する壁の種類をランダムで決める
                    Instantiate(Prefabs2[number], new Vector3(x - i, y, z), Prefabs2[number].transform.rotation);
                }
                count++;
            }
        }
    }
    void Update()
    {
        if (count == 21)
        {
            StartCoroutine("Level2");
        }
        else if(count == 30)
        {
            CancelInvoke();
            InvokeRepeating("SpawnObstacle", 5, 5);
            count = 31;
            StartCoroutine("Level3");
        }
        else if (count == 50)
        {
            CancelInvoke();
            InvokeRepeating("SpawnObstacle", 3, 3);
            count = 51;
            StartCoroutine("LevelEndless");
        }
    }
    //レベル分けをするテキスト
    IEnumerator Level1()
    {
        yield return new WaitForSeconds(1.0f);
        Leveltext.text = "Level1";
    }

    IEnumerator Level2()
    {
        Leveltext.text = "";
        yield return new WaitForSeconds(0.5F);
        Leveltext.text = "Lvel2";
    }
    IEnumerator Level3()
    {
        Leveltext.text = "";
        yield return new WaitForSeconds(0.5f);
        Leveltext.text = "Level3";
    }
    IEnumerator LevelEndless()
    {
        Leveltext.text = "";
        yield return new WaitForSeconds(0.5f);
        Leveltext.text = "LevelEndless";
    }
}
