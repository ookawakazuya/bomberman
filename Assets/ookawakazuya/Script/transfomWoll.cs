using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transfomWoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������g��Transform���擾
        Transform myTransform = this.transform;

        // ��قǎ擾����Transform�̏�񂩂���W�̏����擾
        // Vector3�F3D �x�N�g���ƈʒu�̕\��
        Vector3 pos = myTransform.position;

        // x,y,z���W�̒l���t���[������0.05���Z����
        pos.x -= 0.05f;

        // �����̍��W�����Z�����l�ɐݒ�
        myTransform.position = pos;
    }
}
