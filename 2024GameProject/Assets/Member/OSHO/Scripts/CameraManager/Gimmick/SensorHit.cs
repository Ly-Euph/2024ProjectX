using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorHit : MonoBehaviour
{
    // �Z���T�[�ԍ���Mng�ɑ���Ǘ�
    [SerializeField] SensorManager SensorMng;
    // ���̃Z���T�[�̔ԍ�
    [SerializeField] int SendNum;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�G�ɐG��܂���");
        SensorMng.GSSensor = SendNum;
    }
}
