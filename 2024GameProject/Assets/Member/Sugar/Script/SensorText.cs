using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SensorText : MonoBehaviour
{
    #region
    // 上段、中段、下段の順番
    [SerializeField] Text[] text;
    // テキストに反映させる文字はここから取得
    [SerializeField] SensorManager Mng;
    // ↑で取得されたものを保存する
    private string message;

    #endregion
    void Start()
    {
        for(int i=0;i<text.Length;i++)
        {
            // テキストを初期化
            text[i].text = "";
        }
    }

    void Update()
    {
        if(Mng.Recieve)
        {
            UnderSet();
        }
    }

    #region Method
    // 下段に新規セット
    // 元々のを上段にしていく
    private void UnderSet()
    {
        CenterSet();
        text[2].text = Mng.GSSencor.ToString();
    }
    private void CenterSet()
    {
        TopSet();
        text[1].text = text[2].text.ToString();
    }
    private void TopSet()
    {
        text[0].text = text[1].text.ToString();
    }
    #endregion
}
