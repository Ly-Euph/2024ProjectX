using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Echo : MonoBehaviour
{
    [SerializeField] Image echo;
    [SerializeField] RectTransform rct;

    // scale変数
    private float scaleX;
    private float scaleY;
    private float scaleZ;

    // カラー関連変数
    private float col_a;
    private float col_r;
    private float col_g;
    private float col_b;

    private float scale_max = 10f;


    // 仕様
    // scalex,yを1～10まで拡大していく
    // この際にα値をどんどん透明にする
    // 初期化としてscale x,y1 α1
    // 輪っか三つ
    private void OnEnable()
    {
        // 初期値用関数
        setUpState();
        echo.color = new Color(col_r, col_g, col_b, col_a);
        rct.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }

    void Start()
    {
        setUpState();
        echo.color = new Color(col_r, col_g, col_b, col_a);
        rct.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }

    void Update()
    {
        if(scaleY <= scale_max && scaleX <= scale_max)
        { 
            scaleX += 0.1f;
            scaleY += 0.1f;
            col_a -= 0.01f;
            rct.localScale = new Vector3(scaleX, scaleY, scaleZ);
            echo.color = new Color(col_r, col_g, col_b, col_a);

            //echo_counter++;
        }
        if (scaleY >= scale_max) 
        {
            this.gameObject.SetActive(false);
        }
    }
    void setUpState()
    {
        col_a = 1;
        col_r = 255;
        col_g = 255;
        col_b = 255;
        scaleX = 1f;
        scaleY = 1f;
        scaleZ = 1f;
    }
}
