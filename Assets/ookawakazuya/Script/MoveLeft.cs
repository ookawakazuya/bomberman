using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    private Player player;
    SpawnManager spawnmanager;
    GameObject obj;
    bool loading;
    void Start()
    {
        speed = 1;
        player = GameObject.Find("Player").GetComponent<Player>();
        obj = GameObject.Find("Spawn Manager");
        spawnmanager = obj.GetComponent<SpawnManager>();
    }

    // [SerializeField]private float leftBound = 0;
    void Update()
    {
        //プレイヤーが消滅したときにオブジェクトの生成を終了させる
        if (player.alive == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(spawnmanager.count >= 30)
        {
            speed = 2;
        }
        if (spawnmanager.count >= 50)
        {
            speed = 3;
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
