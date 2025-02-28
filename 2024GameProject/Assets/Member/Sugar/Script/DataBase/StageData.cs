using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "StageInfo", menuName = "CreateStageInfo")]
public class StageData : ScriptableObject
{
    public string StageName;  // �X�e�[�W��
    public Sprite StageImage;  // �X�e�[�W�̃T���l
    public string information_Level; // ���(��Փx)
    public string information_Cam; // ���(�J������)
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