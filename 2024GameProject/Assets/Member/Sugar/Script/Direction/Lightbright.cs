using UnityEngine;

public class Lightbright : MonoBehaviour
{
    // ���o�Ɏg�����C�g
    [SerializeField] Light light;

    // ���邳�ύX�l��Ⴄ
    [SerializeField] DirManager dirMng;

    // �����l
    int range = 70;

    void Update()
    {
        light.range = range;
        range = dirMng.SendBright;
    }
}
