using UnityEngine;
public class SensorIMG : MonoBehaviour
{
    #region field
    [Header("表示場所"), SerializeField] GameObject[] Obj;
    [SerializeField] SensorManager sMng;
    #endregion

    void Update()
    {
        if (sMng.Recieve)
        {
            Spawn();
        }
    }
    // 敵のいるエリア番号のImageを表示する
    void Spawn()
    {
        Obj[sMng.GSSensor - 1].SetActive(true);
    }
}
