using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] bombs;
    [SerializeField] GameObject ultimate;
    public Rigidbody rb;
    public bool alive = true;
    /*public int numbomb;
    private bool canbombs;*/
    private bool ult;
    public  int ultpoint;
    private Transform myTransform;
    private bool canDropBombs = true;

    public GameObject ultimatepoint = null; // Text
    
   

    // Start is called before the first frame update
    void Start()
    {
        ult = false;
        /*canbombs = true;
        numbomb = 0;*/
        myTransform = transform;
    }

    void UpdateAlive()
    {
        Text ult_text = ultimatepoint.GetComponent<Text>();

        /*if(numbomb >= 3)
        {
            canbombs = false;

        }
        else
        {
            canbombs = true;
        }*/
        rb = GetComponent<Rigidbody>();
        //playerの動き
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

        //ウルトポイントが20以上で発動待機状態
        if(ultpoint >= 30)
        {
            ult = true;
        }
        else
        {
            ult = false;
        }

        //エンターキー
        if (ult && Input.GetKeyDown(KeyCode.Return))
        {
            Ultimate();
            ultpoint -= 30;
        }

        //ボムの生成
        if (canDropBombs && Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
            //numbomb += 1;
        }

        ult_text.text = "アルティメットポイント:" + ultpoint + "/30";
    }

    public int getultpoint()
    {
        return ultpoint;
    }

    void Dead()
    {
        Destroy(gameObject);
        Invoke("Deray", 2.0f);
    }

    private void Deray()
    {
        SceneManager.LoadScene("result");//リザルト画面へ移動
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "LimitWall")
        {
            Debug.Log("触れた");
            alive = false;
            Debug.Log("死んだ");
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
    private int maxBombs = 3;
    private int currentBombs = 0;

    private void DropBomb()
    {
        /*var pos = new Vector3
        (
            Mathf.RoundToInt(transform.position.x),
            bombs.transform.position.y,
            Mathf.RoundToInt(transform.position.z)
         );*/
        if (currentBombs >= maxBombs) return;
        Debug.Log("+");
        if (bombs[BombType.type])
        {
           //Instantiate(bombs,pos,ombs.transform.rotation);
            StartCoroutine(BombControl());
        }

    }
    IEnumerator BombControl()
    {
        GameObject bomb = Instantiate(bombs[BombType.type], myTransform.position, bombs[BombType.type].transform.rotation);
        currentBombs++;

        while (bomb != null)
        {
            yield return null;

        }

        currentBombs--;
    }

    private void Ultimate()
    {
        var pos = new Vector3
        (
            Mathf.RoundToInt(transform.position.x),
            bombs[BombType.type].transform.position.y,
            Mathf.RoundToInt(transform.position.z)
        );
        if (ultimate)
        {
            Instantiate(ultimate, pos, ultimate.transform.rotation);
        }
    }
}
