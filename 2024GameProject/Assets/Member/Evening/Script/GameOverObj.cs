using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverObj : MonoBehaviour
{
    bool START = false;    // �V�[�g�؂�ւ��^�C�~���O�Ǘ� 

    bool detection = false;         //�G���m

    // Update is called once per frame
    void Update()
    {
        if(detection==true&&!START)
        {
            START = true;
            Debug.Log("death");
            //SceneManager.LoadScene("GameOverScene");        //��
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        detection = true;
    }

}
