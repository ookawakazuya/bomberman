using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bombs;
    public bool alive = true;
    private bool ult;
    public int ultpoint;

    // Start is called before the first frame update
    void Start()
    {
        ult = false;
    }

    void UpdateAlive()
    {

        //player�̓���
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        //�E���g�|�C���g��20�ȏ�Ŕ����ҋ@���
        if(ultpoint >= 20)
        {
            ult = true;
        }

        //�G���^�[�L�[
        if (ult && Input.GetKeyDown(KeyCode.Return))
        {
            Ultimate();
        }

        //�{���̐���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
    }

    private void Ultimate()
    {

    }

    void Dead()
    {
        Destroy(gameObject);
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
}
