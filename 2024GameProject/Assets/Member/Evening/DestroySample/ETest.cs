using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETest : MonoBehaviour
{
    public float fadeDuration = 2.0f; // �t�F�[�h�A�E�g�̎�������
    private Material objectMaterial;
    private float fadeAmount = 0.0f; // ������Ԃ͒��S���瓧���ɂȂ�

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
        objectMaterial.SetFloat("_FadeAmount", fadeAmount); // ������Ԃ�ݒ�
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeAmount = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeDuration); // 0.0����1.0�Ƀt�F�[�h�A�E�g
            objectMaterial.SetFloat("_FadeAmount", fadeAmount);
            yield return null;
        }

        // ���S�ɓ����ɂȂ�����I�u�W�F�N�g���A�N�e�B�u�ɂ���
        // gameObject.SetActive(false);
        Destroy(obj);
    }
}
