using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SE", menuName = "CreateSE")]
public class SEData : ScriptableObject
{
    public enum Type // ��������SE�̎��
    {
        OBJ,HUMAN,ETC,
    }

    public Type type; // ���

    // �����f�[�^
    public AudioClip[] SE;
    public SEData(SEData sedata)
    {
        this.type = sedata.type;
        this.SE = sedata.SE;
    }
}

