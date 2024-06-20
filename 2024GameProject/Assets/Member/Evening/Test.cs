using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
       
    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag=="Door")
        {
            Debug.Log("è’ìÀ");
        }
    }
}
