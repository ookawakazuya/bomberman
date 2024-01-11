using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    /// <summary>
    /// 衝突した時
    /// </summary>
    /// <param name="collision"></param>

    public GameObject effectPrefab;

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //衝突したときに相手にWallタグが付いているとき
        if (other.CompareTag("Explosion"))
        {
            //1秒後に消滅
            Destroy(gameObject);
            //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            //Destroy(effect, 0.5f);
        }
    }
}
