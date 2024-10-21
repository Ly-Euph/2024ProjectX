using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPos;

    private bool camChangeFlag;

    private int posAmount;
    private int rand;


    private Vector3 pos;
    private Quaternion qrt;


    // Start is called before the first frame update
    void Start()
    {
        camChangeFlag = false;

        posAmount = spawnPos.Length;

        rand = Random.Range(0, posAmount);
    }

    // Update is called once per frame
    void Update()
    {
        Test();

        if(Input.GetKeyDown(KeyCode.A))
        {
            camChangeFlag = true;
        }

    }

    void Test()
    {
        if(camChangeFlag==true)
        {
            pos = spawnPos[rand].transform.position;
            qrt = spawnPos[rand].transform.rotation;

            transform.position = pos;
            transform.rotation = qrt;

            rand = Random.Range(0, posAmount);

            camChangeFlag = false;
        }
    }

}
