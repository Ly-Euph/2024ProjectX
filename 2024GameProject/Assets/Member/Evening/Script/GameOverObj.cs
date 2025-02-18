using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverObj : MonoBehaviour
{
    bool detection = false;         //“GŒŸ’m

    bool IsEnd = false;

    [SerializeField] Fade fade;


    public bool SendDetection
    {
        get { return detection; }
    }

    void GameOver()
    {
        if (!IsEnd)
        {
            IsEnd = true;
            fade.FadeIn(0.5f, () => SceneManager.LoadScene("GameOverScene"));
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        detection = true;
        GameOver();
    }

}
