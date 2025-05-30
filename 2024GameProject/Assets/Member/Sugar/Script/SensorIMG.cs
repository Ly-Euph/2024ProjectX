using UnityEngine;
public class SensorIMG : MonoBehaviour
{
    #region field
    [Header("�\���ꏊ"), SerializeField] GameObject[] Obj;
    [SerializeField] SensorManager sMng;
    #endregion

    void Update()
    {
        if (sMng.Recieve)
        {
            Spawn();
        }
    }
    // �G�̂���G���A�ԍ���Image��\������
    void Spawn()
    {
        Obj[sMng.GSSensor - 1].SetActive(true);
    }
}
