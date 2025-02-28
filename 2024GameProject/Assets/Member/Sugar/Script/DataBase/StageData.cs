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
    public string information_Level; // 情報(難易度)
    public string information_Cam; // 情報(カメラ数)
    public string StageSceneName;
    public StageData(StageData stagedata)
    {
        this.StageImage = stagedata.StageImage;
        this.StageName = stagedata.StageName;
        this.information_Level = stagedata.information_Level;
        this.information_Cam = stagedata.information_Cam;
        this.StageSceneName = stagedata.StageSceneName;
    }
}