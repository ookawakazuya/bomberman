using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    private Player playerController;
    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    [SerializeField]private float leftBound = 0;
    void Update()
    {
        //if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    //壊れないブロックや壊されなかったブロックを消す
    private void OnTriggerEnter(Collider collider)
    {
        //衝突したときに相手にWallタグが付いているときに
        if(collider.gameObject.tag == "DestroyWall")
        {   //このオブジェクトを消滅させる
            Destroy(gameObject,2f);
        }
    }
}
