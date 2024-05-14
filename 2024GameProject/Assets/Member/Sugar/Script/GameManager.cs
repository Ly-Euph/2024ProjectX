using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����̃I�u�W�F�N�g���\�����ꂽ�玞�Ԓ�~
    [SerializeField] GameObject[] Target;
    [SerializeField] bool B_Title=false;
    void Start()
    {
        // FPS60���ێ�����悤��
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeManager();
        InputKEY();
    }
    void timeManager()
    {
        if (Target[0].activeSelf == true || Target[1].activeSelf == true) { Time.timeScale = 0; }
        else if (Target[0].activeSelf == false || Target[1].activeSelf == false) { Time.timeScale = 1; }

    }
    void InputKEY()
    {
        if (B_Title) { return; }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Target[0].activeSelf == false) { Target[0].SetActive(true); }
            else { Target[0].SetActive(false); }
        }
    }
}
