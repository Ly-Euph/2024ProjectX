using UnityEngine;
using UnityEngine.UI;

// センサーが反応した時の処理
public class SensorFade : MonoBehaviour
{
    [SerializeField] Image img;

    float fadeSpd = 1;
    float spd = 0.04f;
    int num = 0;
    float _time = 0;
    float falseTime = 3f;
    void Start()
    {
        img.color = new Color(1, 0, 0, fadeSpd);
        _time = 0;
    }

    private void OnEnable()
    {
        _time = 0;
    }

    // フェード
    void Update()
    {
        switch (num)
        {
            case 0:
                fadeSpd -= spd;
                img.color = new Color(1, 0, 0, fadeSpd);
                if (fadeSpd <= 0)
                {
                    num++;
                }
                break;
            case 1:
                fadeSpd += spd;
                img.color = new Color(1, 0, 0, fadeSpd);
                if (fadeSpd >= 1)
                {
                    num = 0;
                }
                break;
        }
        _time += Time.deltaTime;

        if(_time>=falseTime)
        {
            this.gameObject.SetActive(false);
        }
    }
}
