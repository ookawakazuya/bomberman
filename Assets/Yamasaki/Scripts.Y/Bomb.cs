using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3f);
    }

    private void Explode()
    {
        // 爆弾の位置に爆発エフェクトを作成
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // 爆弾を非表示にする
        GetComponent<MeshRenderer>().enabled = false;
        //transform.Find("Box Collider").gameObject.SetActive(false);

        // 0.3 秒後に非表示にした爆弾を削除
        Destroy(gameObject, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
