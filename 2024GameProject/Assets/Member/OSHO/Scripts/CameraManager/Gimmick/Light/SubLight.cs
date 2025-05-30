using UnityEngine;
using UnityEngine.UI;

// �����Ȃ��G���f�����C�g�̎���
public class SubLight : MonoBehaviour
{
    string colorMain = "#D0FF8D"; // �������C�g�̃J���[�R�[�h
    string colorSub = "#8DC0FF";  // �M�~�b�N���C�g�̃J���[�R�[�h
    Color newColor;
    // ���C�g�g�������Ƃ��C�x���g(DirManager)�ɑ���
    bool IsUse = false;
    [Header("�g�p���郉�C�g�I�u�W�F�N�g"), SerializeField] Light[] lights;
    // �g�������ǂ����̏��
    [Header("Volt�̎g�p��ԕ\���e�L�X�g"), SerializeField] Text lightText;

    /// <summary>
    /// �M�~�b�N���C�g�ɐF�ύX
    /// </summary>
    /// <param name="camNum">�J�����ԍ�</param>
    public bool UseLight(int camNum)
    {
        // �g�p��ԕύX
        lightText.text = "ON";
        IsUse = true;
        ColorUtility.TryParseHtmlString(colorSub, out newColor); // �V����Color���쐬
        lights[camNum-1].color = newColor;

        return true;
    }

    /// <summary>
    /// ���̐F�ɖ߂�
    /// </summary>
    /// <param name="camNum">�J�����ԍ�</param>
    public void NormalLight(int camNum)
    {
        // �g�p��ԕύX
        lightText.text = "OFF";
        IsUse = false;
        ColorUtility.TryParseHtmlString(colorMain, out newColor); // �V����Color���쐬
        lights[camNum - 1].color = newColor;
    }

    public bool IsLight
    {
        get { return IsUse; }
    }
}
