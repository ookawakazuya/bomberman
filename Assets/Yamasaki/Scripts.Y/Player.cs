using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bombs;
    [SerializeField] GameObject ultimate;
    public Rigidbody rb;
    public bool alive = true;
    /*public int numbomb;
    private bool canbombs;*/
    private bool ult;
    public int ultpoint;

    // Start is called before the first frame update
    void Start()
    {
        ult = false;
        /*canbombs = true;
        numbomb = 0;*/
    }

    void UpdateAlive()
    {
        /*if(numbomb >= 3)
        {
            canbombs = false;

        }
        else
        {
            canbombs = true;
        }*/
        rb = GetComponent<Rigidbody>();
        //player�̓���
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(-speed, 0, 0);
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        //�E���g�|�C���g��20�ȏ�Ŕ����ҋ@���
        if(ultpoint >= 20)
        {
            ult = true;
        }
        else
        {
            ult = false;
        }

        //�G���^�[�L�[
        if (ult && Input.GetKeyDown(KeyCode.Return))
        {
            Ultimate();
            ultpoint = 0;
        }

        //�{���̐���
        if (/*canbombs && */Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
            //numbomb += 1;
        }
    }

    void Dead()
    {
        Destroy(gameObject);
        Invoke("Deray", 2.0f);
    }

    private void Deray()
    {
        SceneManager.LoadScene("result");//���U���g��ʂֈړ�
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "LimitWall")
        {
            Debug.Log("�G�ꂽ");
            alive = false;
            Debug.Log("����");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            alive = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("title");
        }

        if (alive)
        {
            UpdateAlive();
        }
        else
        {
            Dead();
        }
    }

    private void DropBomb()
    {
        var pos = new Vector3
        (
            Mathf.RoundToInt(transform.position.x),
            bombs.transform.position.y,
            Mathf.RoundToInt(transform.position.z)
         );
        if (bombs)
        {
            Instantiate(bombs,pos,bombs.transform.rotation);
        }
    }

    private void Ultimate()
    {
        var pos = new Vector3
        (
            Mathf.RoundToInt(transform.position.x),
            bombs.transform.position.y,
            Mathf.RoundToInt(transform.position.z)
        );
        if (ultimate)
        {
            Instantiate(ultimate, pos, ultimate.transform.rotation);
        }
    }
}
