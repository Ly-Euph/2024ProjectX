using UnityEngine;
using UnityEngine.UI;

// �J������؂�ւ��܂�
public class CameraChange : MonoBehaviour
{
    #region field
    [Header("�J�����̃I�u�W�F�N�g����������"),SerializeField] GameObject[] camObj;
    [Header("�J�����̔ԍ���\������Text"),SerializeField] Text camText;
    [Header("�J�����̐������"),SerializeField] int camNum;
    #endregion

    public void CameraStart()
    {
        //���߂�Camera1�ɐݒ�
        SetCamera(1);
    }

    //�J�����֘A�̐؂�ւ��̏���
    public void SetCamera(int num)
    {
        // �S�X�e�[�W�ʂ��ăJ�����͍ő吔9�ɂ��܂�
        if (num >= 1 && num <= 9)
        {
            CameraScan();
            // �؂�ւ���̃J������\��
            for (int i = 0; i < camObj.Length; i++)
            {
                if (i == num - 1)
                {
                    camObj[i].SetActive(true);
                }
            }
            //num�̐����ɉ�����Text�iCAMERA�����j��\��
            camText.text = $"CAMERA{num}";
        }
    }

    /// <summary>
    /// ��x�S�Ă��\���ɕς���
    /// </summary>
    private void CameraScan()
    {
        for (int i = 0; i < camObj.Length; i++)
        {
            camObj[i].SetActive(false);
        }
    }

    public int CameraNum
    {
        get { return camNum; }
    }
}
