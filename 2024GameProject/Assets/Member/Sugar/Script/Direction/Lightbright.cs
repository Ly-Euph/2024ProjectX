using UnityEngine;

public class Lightbright : MonoBehaviour
{
    // 演出に使うライト
    [SerializeField] Light light;

    // 明るさ変更値を貰う
    [SerializeField] DirManager dirMng;

    // 初期値
    int range = 70;

    void Update()
    {
        light.range = range;
        range = dirMng.SendBright;
    }
}
