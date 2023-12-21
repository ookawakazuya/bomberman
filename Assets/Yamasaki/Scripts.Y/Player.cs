using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bombs;
    private bool alive = true;
    [SerializeField] GameObject Wall1;
    [SerializeField] GameObject Wall2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateAlive()
    {

        //playerの動き
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

        //ボムの生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
    }
    void IsAlive()
    {
        Debug.Log("いきてます。");
        Vector3 d1 = Wall1.transform.position - transform.localPosition;
        Vector3 d2 = Wall2.transform.position - transform.localPosition;
        float len1 = d1.magnitude;
        float len2 = d2.magnitude;
        float sumR1x = transform.localScale.x / 2.0f + Wall1.transform.localScale.x / 2.0f;
        float sumR2x = transform.localScale.x / 2.0f + Wall2.transform.localScale.x / 2.0f;
        float sumR1z = transform.localScale.z / 2.0f + Wall1.transform.localScale.z / 2.0f;
        float sumR2z = transform.localScale.z / 2.0f + Wall2.transform.localScale.z / 2.0f;
        if ((len1 <= sumR1x && len1 <= sumR1z) || (len2 <= sumR2x && len2 <= sumR2z))
        {
            alive = false;
            Debug.Log("死にました");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            IsAlive();
            UpdateAlive();
        }
        else
        {
            Debug.Log("死にました");
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
