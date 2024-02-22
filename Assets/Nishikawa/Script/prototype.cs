using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prototype : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody rigidBody;
    private Transform myTransform;
    private bool canDropBombs = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        if (canDropBombs && Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }
    }

    private int maxBombs = 3;
    private int currentBombs = 0;

    void DropBomb()
    {
        if(currentBombs >= maxBombs) return;

        if (bombPrefab)
        {
            //Instantiate(bombPrefab, myTransform.position, bombPrefab.transform.rotation);
            
            StartCoroutine(BombControl());
        }
    }

    IEnumerator BombControl()
    {
        GameObject bomb = Instantiate(bombPrefab, myTransform.position, bombPrefab.transform.rotation);
        currentBombs++;

        while (bomb != null)
        {
            yield return null;
        }

        currentBombs--;
    }
}
