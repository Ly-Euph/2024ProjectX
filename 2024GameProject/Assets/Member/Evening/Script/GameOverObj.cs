using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverObj : MonoBehaviour
{

    bool detection = false;         //�G���m
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(detection==true)
        {
            Debug.Log("GameOver");
            //SceneManager.LoadScene("GameOverScene");        //��
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        detection = true;
    }

}
