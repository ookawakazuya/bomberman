using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false; // ���łɔ������Ă���ꍇ true
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

        // ��������
        exploded = true;

        // �������L����
        StartCoroutine(CreateExplosions(Vector3.forward)); // ��ɍL����
        StartCoroutine(CreateExplosions(Vector3.right)); // �E�ɍL����
        StartCoroutine(CreateExplosions(Vector3.back)); // ���ɍL����
        StartCoroutine(CreateExplosions(Vector3.left)); // ���ɍL����

        // 0.3 �b��ɔ�\���ɂ������e���폜
        Destroy(gameObject, 0.3f);

    }

    // �������L����
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        // 2 �}�X�����[�v����
        for (int i = 1; i < 3; i++)
        {
            // �u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
            RaycastHit hit;

            // �������L������ɉ������݂��邩�m�F
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0.5f, 0),
                direction,
                out hit,
                i,
                levelMask
            );

            // �������L������ɉ������݂��Ȃ��ꍇ
            if (!hit.collider)
            {
                // �������L���邽�߂ɁA
                // �����G�t�F�N�g�̃I�u�W�F�N�g���쐬
                Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
            }
            // �������L������Ƀu���b�N�����݂���ꍇ
            else
            {
                // �����͂���ȏ�L���Ȃ�
                break;
            }

            // 0.05 �b�҂��Ă���A���̃}�X�ɔ������L����
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // �܂��������Ă��Ȃ��A
        // ���A���̔��e�ɂԂ������I�u�W�F�N�g�������G�t�F�N�g�̏ꍇ
        if (!exploded && other.CompareTag("Explosion"))
        {
            // 2 �d�ɔ������������s����Ȃ��悤��
            // ���łɔ������������s����Ă���ꍇ�͎~�߂�
            CancelInvoke("Explode");

            // ��������
            Explode();
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
