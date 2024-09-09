using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SensorText : MonoBehaviour
{
    #region
    // ��i�A���i�A���i�̏���
    [SerializeField] Text[] text;
    // �e�L�X�g�ɔ��f�����镶���͂�������擾
    [SerializeField] SensorManager Mng;
    // ���Ŏ擾���ꂽ���̂�ۑ�����
    private string message;

    #endregion
    void Start()
    {
        for(int i=0;i<text.Length;i++)
        {
            // �e�L�X�g��������
            text[i].text = "";
        }
    }

    void Update()
    {
        if(Mng.Recieve)
        {
            UnderSet();
        }
    }

    #region Method
    // ���i�ɐV�K�Z�b�g
    // ���X�̂���i�ɂ��Ă���
    private void UnderSet()
    {
        CenterSet();
        text[2].text = Mng.GSSencor.ToString();
    }
    private void CenterSet()
    {
        TopSet();
        text[1].text = text[2].text.ToString();
    }
    private void TopSet()
    {
        text[0].text = text[1].text.ToString();
    }
    #endregion
}
