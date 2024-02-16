using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// �Փ˂�����
    /// </summary>
    /// <param name="collision"></param>

    public GameObject effectPrefab;
    public int breakcount;
    private Player player;
    bool reloading;//�d���ǂ̔������[�h����
    private bool scoreget;//0216
    private bool scoreget2;//0216
    [SerializeField] protected ScoreManeger scoreManeger;//0216

    private void Start()
    {
        breakcount = 0;  
        scoreget = false;//0216
        scoreget2 = false;//0216
        player = GameObject.Find("Player").GetComponent<Player>();
        reloading = false;
    }

    private void Update()
    {    
        if (scoreget)//0216
        {
            ScoreManeger.score_num += 300;
            scoreget = false;
        }

        if (scoreget2)//0216
        {
            ScoreManeger.score_num += 500;
            scoreget2 = false;
        }

    }
    //�����Ńu���b�N������
    public void OnTriggerEnter(Collider collider)
    {
        //�G�ꂽ���A���g�̖��O��breakWall�������ꍇ
        if (gameObject.name == "breakWall")
        {
            //�Փ˂����Ƃ��ɑ����Explosion�^�O���t���Ă���Ƃ�
            if (collider.CompareTag("Explosion"))
            {
                scoreget = true;//0216

                //1�b��ɏ���
                Destroy(gameObject,0.005f);//0216
                //player.ultpoint++;
            }
        }
        //�Փ˂����Ƃ��Ɏ��M�̖��O��breakWall+1�������ꍇ
        else if(gameObject.name == "breakWall+1" && !reloading)
        {
            //�Փ˂����Ƃ��ɑ����Explosion�^�O���t���Ă���Ƃ�
            if (collider.CompareTag("Explosion"))
            { 
                StartCoroutine(Reload());
                if(breakcount >= 2)
                {
                    scoreget2 = true;//0216

                    Destroy(gameObject,0.005f);//0216
                    //player.ultpoint++;               
                }
            }
        }
        // Ultimate�̕ǂ̏���
        if (collider.gameObject.tag == "Ultimate")
        {
            Destroy(gameObject);
        }
        //�Փ˂����Ƃ��ɑ����DestroyWall�^�O���t���Ă���Ƃ���
        if (collider.gameObject.tag == "DestroyWall")
        {   //���̃I�u�W�F�N�g�����ł�����
            Destroy(gameObject, 2f);
        }
    }

    private IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("�ҋ@���ԊJ�n");
        yield return new WaitForSeconds(2);

        //�J�E���g��1�ǉ�����
        breakcount++;
        Debug.Log("�J�E���g+1");
        reloading = false;
    }

}
