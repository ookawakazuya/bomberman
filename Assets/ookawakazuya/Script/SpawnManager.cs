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
        //カウントが19以下の処理
        if (player.alive == true)
        {
            if(count <= 19) 
            { 
                //オブジェクトが生成される位置
                int number = Random.Range(0, Prefabs.Length);
                Instantiate(Prefabs[number], new Vector3(-2, 1.5f, -13), Prefabs[number].transform.rotation);
                count++;
            }
            //配列をランダムな順で生成する
            else if(count >= 20)
            {
                int number = Random.Range(0,Prefabs2.Length);
                int number1 = Random.Range(0, Prefabs2.Length);
                int number2 = Random.Range(0, Prefabs2.Length);
                int number3 = Random.Range(0, Prefabs2.Length);
                int number4 = Random.Range(0, Prefabs2.Length);
                int number5 = Random.Range(0, Prefabs2.Length);
                int number6 = Random.Range(0, Prefabs2.Length);
                int number7 = Random.Range(0, Prefabs2.Length);
                int number8 = Random.Range(0, Prefabs2.Length);
                int number9 = Random.Range(0, Prefabs2.Length);
                int number10 = Random.Range(0, Prefabs2.Length);
                int number11 = Random.Range(0, Prefabs2.Length);
                int number12 = Random.Range(0, Prefabs2.Length);
                Instantiate(Prefabs2[number1],new Vector3(2,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number2],new Vector3(1,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number3],new Vector3(0,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number4],new Vector3(-1,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number5],new Vector3(-2,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number6],new Vector3(-3,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number7],new Vector3(-4,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number8],new Vector3(-5,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number9],new Vector3(-6,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number10],new Vector3(-7,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number11],new Vector3(-8,1.5f,-13),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number12],new Vector3(-9,1.5f,-13),Prefabs2[number].transform.rotation);
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
