using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Speed : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;

    private Cinemachine.CinemachinePathBase myPath;
    [SerializeField] Cinemachine.CinemachinePathBase[] path;
    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        myPath = path[0];
    }

    // Update is called once per frame
    void Update()
    {
        this.dolly.m_Path = myPath;
    }
}
