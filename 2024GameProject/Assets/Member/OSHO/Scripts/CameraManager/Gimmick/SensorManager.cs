using UnityEngine;

public class SensorManager : MonoBehaviour
{
    int SencorNum;

    bool recieve = false;
    [Header("�\���ꏊ"), SerializeField] GameObject[] Obj;


    public int GSSensor
    {
        set 
        {
            SencorNum = value;
            recieve = true;
            Obj[SencorNum - 1].SetActive(true);
        }

        get 
        {
            recieve = false;
            return SencorNum;
        }

    }
    // �Z���T�[�ɓG���G�ꂽ���ǂ�����Ԃ�
    public bool Recieve
    {
        get
        {
            return recieve;
        }
    }
}
