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
        // ���e�̈ʒu�ɔ����G�t�F�N�g���쐬
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // ���e���\���ɂ���
        GetComponent<MeshRenderer>().enabled = false;
        //transform.Find("Box Collider").gameObject.SetActive(false);

        // 0.3 �b��ɔ�\���ɂ������e���폜
        Destroy(gameObject, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
