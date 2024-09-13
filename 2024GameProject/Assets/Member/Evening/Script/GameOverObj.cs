using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverObj : MonoBehaviour
{
    bool START = false;    // シート切り替えタイミング管理 

    bool detection = false;         //敵検知

    // Update is called once per frame
    void Update()
    {
        if(detection==true&&!START)
        {
            START = true;
            Debug.Log("death");
            //SceneManager.LoadScene("GameOverScene");        //仮
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        detection = true;
    }

}
