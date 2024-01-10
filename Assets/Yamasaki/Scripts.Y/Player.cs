using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bombs;
    private bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateAlive()
    {

        //playerÇÃìÆÇ´
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

        //É{ÉÄÇÃê∂ê¨
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "LimitWall")
        {
            Debug.Log("êGÇÍÇΩ");
            alive = false;
            Debug.Log("éÄÇÒÇæ");
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
            Debug.Log("éÄÇ…Ç‹ÇµÇΩ");
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
