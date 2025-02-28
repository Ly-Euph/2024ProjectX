using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmOtamesi : MonoBehaviour
{
    public static EmOtamesi Instance { get; private set; }

    private int[] receiveData;

    private void Awake()
    {
        Instance = this;
    }

    public void SetData(int[] data)
    {
        receiveData = data;
        Debug.Log("�f�[�^�󂯎��F�@" + string.Join(",", receiveData));
    }

    private void Update()
    {
        
    }

}
