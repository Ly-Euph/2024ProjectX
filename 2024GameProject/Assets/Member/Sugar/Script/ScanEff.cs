using UnityEngine;

public class ScanEff : MonoBehaviour
{
    public RectTransform scanLine; // �X�L�������C���p��UI�iRectTransform�j
    public float scanSpeed = 300f; // �X�L�������x
    public float resetPosition = 540f; // �X�L�������C�������Z�b�g�����Y���W
    public float startPosition = -540f; // �X�L�������C���̊J�nY���W

    void Update()
    {
        if (scanLine != null)
        {
            // ���݂̈ʒu���擾
            Vector3 position = scanLine.anchoredPosition;

            // Y�����ړ�
            position.y += scanSpeed * Time.deltaTime;

            // ���Z�b�g�ʒu�𒴂�����ʒu�����Z�b�g
            //if (position.y > resetPosition)
            //{
            //    position.y = startPosition;
            //}

            // �V�����ʒu��K�p
            scanLine.anchoredPosition = position;
        }
        else
        {
            Debug.LogError("Scan Line (RectTransform) is not assigned!");
        }
    }
}