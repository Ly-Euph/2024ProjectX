using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamNumText : MonoBehaviour
{
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "camera1";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            text.text = "camera1";
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Text>().text = "camera2";
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Text>().text = "camera3";
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Text>().text = "camera4";
        }
    }
}
