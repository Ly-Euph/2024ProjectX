using UnityEngine;

public class UIShake : MonoBehaviour
{
    public float amplitude = 10f;  // —h‚ê‚é•
    public float duration = 1f;   // —h‚ê‚éŠÔ

    [Header("“®‚©‚·‘ÎÛ"),SerializeField] RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeRoutine());
    }

    private System.Collections.IEnumerator ShakeRoutine()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float progress = elapsed / duration;
            float offset = Mathf.Sin(progress * Mathf.PI * 2) * amplitude;
            rectTransform.anchoredPosition = originalPosition + new Vector2(offset, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // ÅŒã‚ÉŒ³‚ÌˆÊ’u‚É–ß‚·
        rectTransform.anchoredPosition = originalPosition;
    }
}
