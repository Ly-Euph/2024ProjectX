using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Data : MonoBehaviour
{
    [Header("それぞれのGimmicUIを入れるとこ")]

    public GameObject[] OBJ_gimmicUI;

    [Header("Camera関連をここに入れといて")]

    public GameObject[] OBJ_camera;

    [Header("Text関連をここに入れといて")]

    public Text TEXT_camera;

    [Header("SonarFxのScriptを入れてね")]
    // ソナースクリプト取得
    public SonarFx[] SonarFx_sf;

    //Camera用のFlag
    [Header("各カメラ用のフラグ")]

    public bool[] Cam_Flg;

    [Header("VoltのCooltime用のTextを入れてね。")]

    public Text[] CT_Volt;

    [Header("それぞれのVoltトラップで使うImageを入れてね")]

    // ボルトトラップイメージ
    public Image[] IMAGE_Volt;

    //Voltトラップのクールタイム
    private int V_time = 20;

    //Volt用のFlag
    [Header("各Volt用のフラグ")]

    public bool[] Volt_Flg;

    //Voltのtimerの変数
    [Header("各カメラのVoltのタイマー")]
    public float[] Volt_timers;

    [Header("Voltのクールタイム")]
    public int Cool_Volt;


    public void UIActive(int num)
    {
        for (int i = 0; i < OBJ_gimmicUI.Length; i++)
        {
            // 一旦全てのUI表示を非表示
            OBJ_gimmicUI[i].SetActive(false);
            // OBJ_camZoom[i].SetActive(false);
        }
        OBJ_gimmicUI[num].SetActive(true);
        //OBJ_camZoom[num].SetActive(true);
    }
    //カメラ関連の切り替えの処理
    public void SetCamera(int num)
    {
        if (num >= 1 && num <= 9)
        {
            CameraScan();
            for (int i = 0; i < OBJ_camera.Length; i++)
            {
                OBJ_camera[i].SetActive(i == num - 1);
            }
            //numの数字に応じてText（CAMERA○○）を表示
            TEXT_camera.text = $"CAMERA{num}";
        }
    }
    public void SonarOff()
    {
        for (int i = 0; i < SonarFx_sf.Length; i++)
        {
            SonarFx_sf[i].enabled = false;
        }
    }
    public void SonarOn()
    {
        for (int i = 0; i < SonarFx_sf.Length; i++)
        {
            SonarFx_sf[i].enabled = true;
        }
    }
    public void CameraScan()
    {
        for (int i = 0; i < OBJ_camera.Length; i++)
        {
            OBJ_camera[i].SetActive(false);
        }
    }
    public void CamFlag()
    {
        for (int i = 0; i < Cam_Flg.Length; i++)
        {
            Cam_Flg[i] = false;
        }
    }
    public void StartVoltTimer(int index)
    {
        CT_Volt[index].text = V_time.ToString();
        IMAGE_Volt[index].fillAmount = 1;
        Volt_Flg[index] = true;
    }
    public void UpdateVoltTimer(int index)
    {
        Volt_timers[index] -= Time.deltaTime;
        CT_Volt[index].text = ((int)Volt_timers[index]).ToString();
        IMAGE_Volt[index].fillAmount -= 1.0f / (float)Cool_Volt * Time.deltaTime;
        if (Volt_timers[index] <= 0)
        {
            Volt_Flg[index] = false;
            CT_Volt[index].text = "OK";
            Volt_timers[index] = Cool_Volt;
        }
    }
}
