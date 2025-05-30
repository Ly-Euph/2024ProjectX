using UnityEngine;
using UnityEngine.UI;

// 見えない敵を映すライトの実装
public class SubLight : MonoBehaviour
{
    string colorMain = "#D0FF8D"; // 初期ライトのカラーコード
    string colorSub = "#8DC0FF";  // ギミックライトのカラーコード
    Color newColor;
    // ライト使ったことをイベント(DirManager)に送る
    bool IsUse = false;
    [Header("使用するライトオブジェクト"), SerializeField] Light[] lights;
    // 使ったかどうかの状態
    [Header("Voltの使用状態表示テキスト"), SerializeField] Text lightText;

    /// <summary>
    /// ギミックライトに色変更
    /// </summary>
    /// <param name="camNum">カメラ番号</param>
    public bool UseLight(int camNum)
    {
        // 使用状態変更
        lightText.text = "ON";
        IsUse = true;
        ColorUtility.TryParseHtmlString(colorSub, out newColor); // 新しくColorを作成
        lights[camNum-1].color = newColor;

        return true;
    }

    /// <summary>
    /// 元の色に戻す
    /// </summary>
    /// <param name="camNum">カメラ番号</param>
    public void NormalLight(int camNum)
    {
        // 使用状態変更
        lightText.text = "OFF";
        IsUse = false;
        ColorUtility.TryParseHtmlString(colorMain, out newColor); // 新しくColorを作成
        lights[camNum - 1].color = newColor;
    }

    public bool IsLight
    {
        get { return IsUse; }
    }
}
