using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mutant : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1.0f;


        if(timer<=0)
        {
            Destroy(gameObject);
        }
    }
}
