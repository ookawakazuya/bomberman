using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool scoreget;
    private bool scoreget2;
    [SerializeField] protected ScoreManeger scoreManeger;

    private void Start()
    {
        breakcount = 0;
        scoreget = false;
        scoreget2 = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        reloading = false;
    }

    private void Update()
    {
        if (scoreget)
        {
            ScoreManeger.score_num += 50;
            scoreget = false;
            player.ultpoint++;
        }

        if (scoreget2)
        {
            ScoreManeger.score_num += 100;
            scoreget2 = false;
            player.ultpoint++;
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
                scoreget = true;
                //1�b��ɏ���
                Destroy(gameObject,0.005f);
            }
        }
        //�Փ˂����Ƃ��Ɏ��M�̖��O��breakWall+1�������ꍇ
        else if(gameObject.name == "breakWall+1" && !reloading)
        {
            //�Փ˂����Ƃ��ɑ����Explosion�^�O���t���Ă���Ƃ�
            if (collider.CompareTag("Explosion"))
            { 
                StartCoroutine(Reload());
                if(breakcount == 1)
                {
                    scoreget2 = true;

                    Destroy(gameObject,0.005f);
                }
            }
        }
        // Ultimate�̕ǂ̏���
        if (collider.gameObject.tag == "Ultimate")
        {
            Destroy(gameObject,0.005f);
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
