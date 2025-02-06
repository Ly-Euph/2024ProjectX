using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volt : MonoBehaviour
{
    #region field
    // �{���g�g���b�v�g�p��ė��p�܂�
    // �p�l����\�����g���Ȃ����Ƃ���������
    [Header("�N�[���^�C���̃p�l���\��"),SerializeField] Image voltImg;
    // �g�������ǂ����̏��
    [Header("Volt�̎g�p��ԕ\���e�L�X�g"),SerializeField] Text voltText;

    // transform�擾�p
    [Header("��������ʒu�w�肷��I�u�W�F�N�g"), SerializeField] GameObject[] objPos;
    // volt�����I�u�W�F�N�g
    [Header("��������volt�̃I�u�W�F�N�g"), SerializeField] GameObject voltObj;

    // Volt�g���b�v�̃N�[���^�C���ݒ�
    const int voltCTTimer = 7;
    // �N�[���^�C���̌v�Z�p
    float voltTimer ;
    #endregion

    public void VoltStart()
    {
        // �{���g�g���b�v�g�p�\��\��
        voltText.text = "READY";

        // �ŏ��͎g����̂�0
        voltImg.fillAmount = 0;
    }

    //�o�b�e���[�c�ʂ̊Ǘ���Main�ł�����CameraManager�ɂ�
    /// <summary>
    /// �{���g�g�p�̏���
    /// </summary>
    /// <param name="num">�ǂ̃J������CameraManager��camaeraNum�𑗂���</param>
    public void UseVolt(int num)
    {
        // �����o�������`�F�b�N
        if (voltText.text != "READY") { return; }
        // -1�ɂ��Ĕz���0�Ԗڂ���g����悤��
        // �|�W�V�����̐ݒ�
        Vector3 ObjPos = objPos[num-1].transform.position;
        // ����
        Instantiate(voltObj, ObjPos, Quaternion.identity);
        // �g�p��
        voltText.text = "CHARGE";
        voltImg.fillAmount = 1;
    }

    /// <summary>
    /// �N�[���^�C���v�Z
    /// </summary>
    public void Recharge()
    {
        // �`���[�W�ɐ؂�ւ������v�Z�J�n
        if (voltText.text != "CHARGE") { return; }
        // ���Ԍv�Z
        voltTimer += Time.deltaTime;
        voltImg.fillAmount -= 1.0f / (float)voltCTTimer*Time.deltaTime;
        if (voltTimer>=voltCTTimer)
        {
            voltTimer = 0;
            voltText.text = "READY";
            // �ꉞ������0�ɂ��Ă���
            voltImg.fillAmount = 0;
        }
    }
}
