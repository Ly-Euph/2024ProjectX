using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverObj : MonoBehaviour
{
    bool detection = false;         //“GŒŸ’m

    public bool SendDetection
    {
        get { return detection; }
    }

    private void OnTriggerEnter(Collider col)
    {
        detection = true;
    }

}
