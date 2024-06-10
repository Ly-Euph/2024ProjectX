using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Jammer : MonoBehaviour
{
    private Cinemachine.CinemachineDollyCart dolly;

    private Cinemachine.CinemachinePathBase myPath;
    [SerializeField] Cinemachine.CinemachinePathBase[] path;
    [SerializeField] SkinnedMeshRenderer smr;
    //[SerializeField] Material material_N; // 基本マテリアル
    //[SerializeField] Material material_S; // スキャン中マテリアル
    // Start is called before the first frame update
    void Start()
    {
        dolly = GetComponent<Cinemachine.CinemachineDollyCart>();

        myPath = path[0];
        // 初期マテリアルセット
        //smr.material = material_N;
    }

    // Update is called once per frame
    void Update()
    {
        this.dolly.m_Path = myPath;
        //smr.material = material_S;
    }
}
