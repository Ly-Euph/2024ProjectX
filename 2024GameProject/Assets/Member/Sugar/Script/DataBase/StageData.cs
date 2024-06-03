using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "StageInfo", menuName = "CreateStageInfo")]
public class StageData : ScriptableObject
{
    public string StageName;  // ステージ名
    public Sprite StageImage;  // ステージのサムネ
    public string infomation_Level; // 情報(難易度)
    public string infomation_Cam; // 情報(カメラ数)
    public string StageSceneName;
    public StageData(StageData stagedata)
    {
        this.StageImage = stagedata.StageImage;
        this.StageName = stagedata.StageName;
        this.infomation_Level = stagedata.infomation_Level;
        this.infomation_Cam = stagedata.infomation_Cam;
        this.StageSceneName = stagedata.StageSceneName;
    }
}