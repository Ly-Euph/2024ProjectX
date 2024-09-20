using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverObj : MonoBehaviour
{
    bool START = false;    // シート切り替えタイミング管理 

    // シーン遷移に使う
    [SerializeField] Fade fade;

    bool detection = false;         //敵検知

    // Update is called once per frame
    void Update()
    {
        if(detection==true&&!START)
        {
            START = true;
            Debug.Log("death");
            fade.FadeIn(0.5f, () => SceneManager.LoadScene("GameOverScene"));
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        detection = true;
    }

}
