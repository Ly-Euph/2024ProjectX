using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    Animator _Door3L;
    Animator _Door3R;
    // Start is called before the first frame update
    void Start()
    {
        _Door3L = GetComponent<Animator>();
        _Door3R = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            _Door3L.SetBool("Door3L", true);
            _Door3R.SetBool("Door3R", true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            _Door3L.SetBool("Door3L", false);
            _Door3R.SetBool("Door3R", false);
        }
    }
}
