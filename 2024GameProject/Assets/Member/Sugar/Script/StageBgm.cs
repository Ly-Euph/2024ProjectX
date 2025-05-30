using UnityEngine;

public class StageBgm : MonoBehaviour
{
    //@‰¹Ä¶
    [SerializeField] GameManager gMng;

    float timer = 0.0f;
    float interval = 5.0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=interval) {
            timer = 0;
            gMng.OneShotSE_C(SEData.Type.OBJ, GameManager.ClipSe.stage);
        }
    }
}
