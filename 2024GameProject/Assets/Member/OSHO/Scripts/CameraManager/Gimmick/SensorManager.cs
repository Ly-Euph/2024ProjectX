using UnityEngine;

public class SensorManager : MonoBehaviour
{
    int SencorNum;

    bool recieve = false;
    [Header("表示場所"), SerializeField] GameObject[] Obj;


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
    // センサーに敵が触れたかどうかを返す
    public bool Recieve
    {
        get
        {
            return recieve;
        }
    }
}
