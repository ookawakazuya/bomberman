using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // [SerializeField]private float leftBound = 0;
    void Update()
    {
        //プレイヤーが消滅したときにオブジェクトの生成を終了させる
        if (player.alive == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    //壊れないブロックや壊されなかったブロックを消す
    public void OnTriggerEnter(Collider collider)
    {
        //衝突したときに相手にWallタグが付いているときに
        if (collider.gameObject.tag == "DestroyWall")
        {   //このオブジェクトを消滅させる
            Destroy(gameObject, 2f);
        }
    }
}
