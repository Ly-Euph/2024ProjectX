using UnityEngine;

public class ScanEff : MonoBehaviour
{
    public RectTransform scanLine; // スキャンライン用のUI（RectTransform）
    public float scanSpeed = 300f; // スキャン速度
    public float resetPosition = 540f; // スキャンラインがリセットされるY座標
    public float startPosition = -540f; // スキャンラインの開始Y座標

    void Update()
    {
        if (scanLine != null)
        {
            // 現在の位置を取得
            Vector3 position = scanLine.anchoredPosition;

            // Y軸を移動
            position.y += scanSpeed * Time.deltaTime;

            // リセット位置を超えたら位置をリセット
            //if (position.y > resetPosition)
            //{
            //    position.y = startPosition;
            //}

            // 新しい位置を適用
            scanLine.anchoredPosition = position;
        }
        else
        {
            Debug.LogError("Scan Line (RectTransform) is not assigned!");
        }
    }
}