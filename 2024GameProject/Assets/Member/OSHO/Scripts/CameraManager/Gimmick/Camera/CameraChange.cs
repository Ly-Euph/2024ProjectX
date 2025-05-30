using UnityEngine;
using UnityEngine.UI;

// カメラを切り替えます
public class CameraChange : MonoBehaviour
{
    #region field
    [Header("カメラのオブジェクトを差し込む"),SerializeField] GameObject[] camObj;
    [Header("カメラの番号を表示するText"),SerializeField] Text camText;
    [Header("カメラの数を入力"),SerializeField] int camNum;
    #endregion

    public void CameraStart()
    {
        //初めはCamera1に設定
        SetCamera(1);
    }

    //カメラ関連の切り替えの処理
    public void SetCamera(int num)
    {
        // 全ステージ通してカメラは最大数9にします
        if (num >= 1 && num <= 9)
        {
            CameraScan();
            // 切り替え後のカメラを表示
            for (int i = 0; i < camObj.Length; i++)
            {
                if (i == num - 1)
                {
                    camObj[i].SetActive(true);
                }
            }
            //numの数字に応じてText（CAMERA○○）を表示
            camText.text = $"CAMERA{num}";
        }
    }

    /// <summary>
    /// 一度全てを非表示に変える
    /// </summary>
    private void CameraScan()
    {
        for (int i = 0; i < camObj.Length; i++)
        {
            camObj[i].SetActive(false);
        }
    }

    public int CameraNum
    {
        get { return camNum; }
    }
}
