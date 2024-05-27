using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Door : MonoBehaviour
{
    [SerializeField] Animator _S2Door;

    // Start is called before the first frame update
    void Start()
    {
        _S2Door = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            _S2Door.SetBool("DoorOpCl", true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            _S2Door.SetBool("DoorOpCl", false);
        }

    }
}
