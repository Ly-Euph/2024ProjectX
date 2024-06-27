using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETest : MonoBehaviour
{
    public float fadeDuration = 2.0f; // フェードアウトの持続時間
    private Material objectMaterial;
    private float fadeAmount = 0.0f; // 初期状態は中心から透明になる

    [SerializeField]
    GameObject obj;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer not found on the object.");
            return;
        }

        objectMaterial = renderer.material;
        Vector3 centerPosition = renderer.bounds.center;
        objectMaterial.SetVector("_Center", new Vector4(centerPosition.x, centerPosition.y, centerPosition.z, 1.0f));
        objectMaterial.SetFloat("_FadeAmount", fadeAmount); // 初期状態を設定
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeAmount = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeDuration); // 0.0から1.0にフェードアウト
            objectMaterial.SetFloat("_FadeAmount", fadeAmount);
            yield return null;
        }

        // 完全に透明になったらオブジェクトを非アクティブにする
        // gameObject.SetActive(false);
        Destroy(obj);
    }
}
