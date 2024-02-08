using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject[] Prefabs2;
    private float startDelay=2;
    private float repeatRate=5;
    private Player player;
    public int count;
    //private int number;
    [SerializeField] Text Leveltext;

    void Start()
    {
        count = 0;
        // �I�u�W�F�N�g�𐶐�����@�\
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        StartCoroutine("Spawn");
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine("Level1");
    }

    private IEnumerator Spawn()
    {
        //�J�E���g��19�ȉ��̏���
        if (player.alive == true)
        {
            if (count <= 19)
            {
                //�I�u�W�F�N�g�����������ʒu
                int number = Random.Range(0, Prefabs.Length);
                Instantiate(Prefabs[number], new Vector3(-21, -1, 0), Prefabs[number].transform.rotation);
                count++;
            }
            //�z��������_���ȏ��Ő�������
            else if (count >= 20)
            {
                int number = Random.Range(0, Prefabs2.Length);
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
                Instantiate(Prefabs2[number1], new Vector3(-21, 0, 4), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number2], new Vector3(-21, 0, 3), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number3], new Vector3(-21, 0, 2), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number4], new Vector3(-21, 0, 1), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number5], new Vector3(-21, 0, 0), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number6], new Vector3(-21, 0, -1), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number7], new Vector3(-21, 0, -2), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number8], new Vector3(-21, 0, -3), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number9], new Vector3(-21, 0, -4), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number10], new Vector3(-21, 0, -5), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number11], new Vector3(-21, 0, -6), Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number12], new Vector3(-21, 0, -7), Prefabs2[number].transform.rotation);
                count++;
            }
        }
    }

    /*void SpawnObstacle()
    {
        //�J�E���g��19�ȉ��̏���
        if (player.alive == true)
        {
            if(count <= 19) 
            { 
                //�I�u�W�F�N�g�����������ʒu
                int number = Random.Range(0, Prefabs.Length);
                Instantiate(Prefabs[number], new Vector3(-21, -1, 0), Prefabs[number].transform.rotation);
                count++;
            }
            //�z��������_���ȏ��Ő�������
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
                Instantiate(Prefabs2[number1],new Vector3(-21,0,4),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number2],new Vector3(-21,0,3),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number3],new Vector3(-21,0,2),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number4],new Vector3(-21,0,1),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number5],new Vector3(-21,0,0),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number6],new Vector3(-21,0,-1),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number7],new Vector3(-21,0,-2),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number8],new Vector3(-21,0,-3),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number9],new Vector3(-21,0,-4),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number10],new Vector3(-21,0,-5),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number11],new Vector3(-21,0,-6),Prefabs2[number].transform.rotation);
                Instantiate(Prefabs2[number12],new Vector3(-21,0,-7),Prefabs2[number].transform.rotation);
                count++;
            }
        }
    }*/
    void Update()
    {
        if (count == 21)
        {
            StartCoroutine("Level2");
        }
        else if(count == 30)
        {
            CancelInvoke();
            StartCoroutine("Level3");
        }if(count >=30)
        {
            InvokeRepeating("SpawnObstacle", startDelay, 3);
        }
    }
    //���x������������e�L�X�g
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
}
