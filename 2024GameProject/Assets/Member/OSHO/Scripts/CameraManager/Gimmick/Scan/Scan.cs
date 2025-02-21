using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scan : MonoBehaviour
{
    #region
    // �g�p�̗L����\��
    [Header("�X�L�����̎g�p��ԃe�L�X�g"),SerializeField] Text scanText;
    // �\������I�u�W�F�N�g
    [Header("SensorP�I�u�W�F�N�g"),SerializeField] GameObject scan;
    // �p�l����\�����g���Ȃ����Ƃ���������
    [Header("�N�[���^�C���̃p�l���\��"), SerializeField] Image scanImg;

    // Volt�g���b�v�̃N�[���^�C���ݒ�
    const int scanCTTimer = 20;
    // �N�[���^�C���̌v�Z�p
    float scanTimer;

    // �X�L�����G�t�F�N�g
    [SerializeField] GameObject Eff;
    #endregion

    public void ScanStart()
    {
        // �X�L�����g�p�\��\��
        scanText.text = "READY";

        // �ŏ��͎g����̂�0
        scanImg.fillAmount = 0;
    }

    //�o�b�e���[�c�ʂ̊Ǘ���Main�ł�����CameraManager�ɂ�
    /// <summary>
    /// �X�L�����g�p�̏���
    /// </summary>
    public bool UseScan()
    {
        // �����o�������`�F�b�N
        if (scanText.text != "READY") { return false; }
        // �I�u�W�F�N�g��\������
        scan.SetActive(true);
        Eff.SetActive(true);
        // �g�p��
        scanText.text = "USED";
        scanImg.fillAmount = 1;

        return true;
    }

    /// <summary>
    /// �N�[���^�C���v�Z
    /// </summary>
    public void Recharge()
    {
        // �`���[�W�ɐ؂�ւ������v�Z�J�n
        if (scanText.text != "CHARGE" && scanImg.fillAmount == 0) { return; }
        // ���Ԍv�Z
        scanTimer += Time.deltaTime;
        scanImg.fillAmount -= 1.0f / (float)scanCTTimer * Time.deltaTime;

        // �\����ԂȂ�
        if(scan.activeSelf&&scanTimer>=2.0f)
        {
            // �I�u�W�F�N�g���\���ɐؑ�
            scan.SetActive(false);
        }
        if (scanTimer >= scanCTTimer)
        {
            scanTimer = 0;
            scanText.text = "READY";
            // �ꉞ������0�ɂ��Ă���
            scanImg.fillAmount = 0;
        }
    }

    /// <summary>
    /// �`���[�W�o���Ă��Ă��o�b�e���[������Ȃ����Ɏg���Ȃ����Ƃ�m�点��
    /// </summary>
    public void NotCost()
    {
        scanText.text = "CHARGE";
    }

    /// <summary>
    /// �R�X�g�����ԂŌĂяo���g����悤�ɂ���
    /// </summary>
    public void ReadySet()
    {
        if (scanImg.fillAmount != 0)
        {
            return;
        }
        scanText.text = "READY";
    }
}
