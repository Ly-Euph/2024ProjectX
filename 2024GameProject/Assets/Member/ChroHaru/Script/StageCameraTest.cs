using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCameraTest : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;
    public GameObject Camera6;
    public GameObject Camera12;
    public GameObject Camera34;
    public GameObject Camera56;

    GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        Camera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(true);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(true);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(true);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(true);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(true);
            Camera34.SetActive(false);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(true);
            Camera56.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera12.SetActive(false);
            Camera34.SetActive(false);
            Camera56.SetActive(true);
        }
    }
}
