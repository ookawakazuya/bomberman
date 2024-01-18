using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    [SerializeField] GameObject explodePrefab; // 爆発エフェクトのプレハブ
    [SerializeField] LayerMask leveMask; // ステージのレイヤー

    private bool exploded = false; // すでに爆発している場合 = true

    // Start is called before the first frame update
    void Start()
    {
        // 3秒後にExplode関数を実行
        Invoke("Explode", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 爆弾が爆発する時の処理
    void Explode()
    {
        // 爆弾の位置に爆発エフェクトを作成
        Instantiate(explodePrefab, transform.position, Quaternion.identity);

        // 爆弾を非表示にする
        GetComponent<MeshRenderer>().enabled = false;
        // 爆発した
        exploded = true;

        // 爆風を広げる
        StartCoroutine(CreateExplosins(Vector3.forward));
        StartCoroutine(CreateExplosins(Vector3.right));
        StartCoroutine(CreateExplosins(Vector3.back));
        StartCoroutine(CreateExplosins(Vector3.left));

        Transform sphereColliderTransform = transform.Find("SphereCollider");
        if (sphereColliderTransform != null)
        {
            sphereColliderTransform.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("SphereCollider not found!");
        }

        // 0.3秒後に非表示にした爆弾を削除
        Destroy(gameObject, 0.3f);
    }

    // 爆風を広げる
    private IEnumerator CreateExplosins(Vector3 direction)
    {
        // 2マス分ループする
        for (int i = 1; i < 3; i++)
        {
            // ブロックとの当たり判定の結果を格納する変数
            RaycastHit hit;

            // 爆風を広げた先に何か存在するか確認
            Physics.Raycast
            (transform.position + new Vector3(0, 0.5f, 0), direction, out hit, i, leveMask);

            // 爆風を広げた先に何も存在しない場合
            if (!hit.collider)
            {
                // 爆風を広げるために爆発エフェクトのオブジェクトを作成
                Instantiate(explodePrefab, transform.position + (i * direction), explodePrefab.transform.rotation);
            }
            else // 爆風を広げた先にブロックが存在する場合
            {
                break; // 爆風はこれ以上広げない
            }

            // 0.05秒待ってから、次のマスに爆風を広げる
            yield return new WaitForSeconds(0.05f);
        }
    }

    // 他のオブジェクトがこの爆弾に当たったら呼び出される
    void OnTriggerEnter(Collider other)
    {
        // まだ爆発していない、かつ、この爆弾にぶつかったオブジェクトが爆発エフェクトの場合
        if (!exploded && other.CompareTag("Explosion"))
        {
            // 2重に爆発処理が実行されないようにすでに爆発処理が実行されている場合は止める
            CancelInvoke("Explode");

            // 爆発する
            Explode();
        }
    }
}
