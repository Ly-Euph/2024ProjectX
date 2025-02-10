using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOp : MonoBehaviour
{
    Animator _DoorOp;
    // Start is called before the first frame update
    void Start()
    {
        _DoorOp = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            _DoorOp.SetBool("DoorCl", false);
            _DoorOp.SetBool("DoorOp", true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            _DoorOp.SetBool("DoorOp", false);
            _DoorOp.SetBool("DoorCl", true);
        }

      
    }
}
