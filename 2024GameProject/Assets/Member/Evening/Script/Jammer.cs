using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jammer : MonoBehaviour
{
    private bool spawnFlag=false;

    private void OnEnable()
    {
        spawnFlag = true;
    }

    // �l�n��
    public bool SendFlag
    {
        set
        {
            spawnFlag = value;
        }
        get
        {
            return spawnFlag;
        }
    }
    void Update()
    {
        if (spawnFlag/* �G�R�[���ꂽ��̏����ɂ���I*/) {
            spawnFlag = false;
        } 
    }
}
