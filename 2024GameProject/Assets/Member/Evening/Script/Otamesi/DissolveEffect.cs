using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    public Material dissolveMaterial; // Dissolve用マテリアル
    public float dissolveSpeed = 1.0f;
    private float dissolveAmount = 0.9f;
    [HideInInspector] public bool isDissolving = false;

    void Start()
    {
        dissolveMaterial = new Material(GetComponent<Renderer>().material);
        GetComponent<Renderer>().material = dissolveMaterial;
        dissolveMaterial.SetFloat("DissolveAmount", 0.9f);
    }

    void Update()
    {
        if (isDissolving)
        {
            DissolveProcess();
        }

        //if (Input.GetKeyDown(KeyCode.Space)) // スペースキーで消える
        //{
        //    isDissolving = true;
        //}
    }

    public void DissolveProcess()
    {
        dissolveAmount += Time.deltaTime * dissolveSpeed * 0.05f;
        dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);

        if (dissolveAmount >= 1)
        {
            gameObject.SetActive(false); // 完全に消えたらオブジェクトを非表示
        }
    }
}
