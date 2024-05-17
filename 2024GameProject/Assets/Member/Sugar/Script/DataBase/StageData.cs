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
    public Image StageImage;  // �X�e�[�W�̃T���lS
    public string infomation_Level; // ���(��Փx)
    public string infomation_Cam; // ���(�J������)

    public StageData(StageData stagedata)
    {
        this.StageImage = stagedata.StageImage;
        this.StageName = stagedata.StageName;
        this.infomation_Level = stagedata.infomation_Level;
        this.infomation_Cam = stagedata.infomation_Cam;
    }
}