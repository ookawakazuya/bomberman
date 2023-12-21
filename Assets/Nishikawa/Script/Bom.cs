using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    [SerializeField] GameObject explodePrefab; // �����G�t�F�N�g�̃v���n�u
    [SerializeField] LayerMask leveMask; // �X�e�[�W�̃��C���[

    // Start is called before the first frame update
    void Start()
    {
        // 3�b���Explode�֐������s
        Invoke("Explode", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���e���������鎞�̏���
    void Explode()
    {
        // ���e�̈ʒu�ɔ����G�t�F�N�g���쐬
        Instantiate(explodePrefab, transform.position, Quaternion.identity);

        // ���e���\���ɂ���
        GetComponent<MeshRenderer>().enabled = false;

        // �������L����
        StartCoroutine(CreateExplosins(Vector3.forward));
        StartCoroutine(CreateExplosins(Vector3.right));
        StartCoroutine(CreateExplosins(Vector3.back));
        StartCoroutine(CreateExplosins(Vector3.left));

        transform.Find("SphereCollider").gameObject.SetActive(false);

        // 0.3�b��ɔ�\���ɂ������e���폜
        Destroy(gameObject, 0.3f);
    }

    // �������L����
    private IEnumerator CreateExplosins(Vector3 direction)
    {
        // 2�}�X�����[�v����
        for (int i = 1; i < 3; i++)
        {
            // �u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
            RaycastHit hit;

            // �������L������ɉ������݂��邩�m�F
            Physics.Raycast
            (transform.position + new Vector3(0, 0.5f, 0), direction, out hit, i, leveMask);

            // �������L������ɉ������݂��Ȃ��ꍇ
            if (!hit.collider)
            {
                // �������L���邽�߂ɔ����G�t�F�N�g�̃I�u�W�F�N�g���쐬
                Instantiate(explodePrefab, transform.position + (i * direction), explodePrefab.transform.rotation);
            }
            else // �������L������Ƀu���b�N�����݂���ꍇ
            {
                break; // �����͂���ȏ�L���Ȃ�
            }

            // 0.05�b�҂��Ă���A���̃}�X�ɔ������L����
            yield return new WaitForSeconds(0.05f);
        }
    }
}
