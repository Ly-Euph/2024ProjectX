using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{

    [SerializeField] GameObject[] Enemy;

    [SerializeField] GameObject[] NormalEnemy;
    [SerializeField] GameObject[] JammerEnemy;
    [SerializeField] GameObject[] SpeedEnemy;
    [SerializeField] GameObject[] HideEnemy;



    GameObject duct;
    Vector3 ductPos;

    private int random;
    private int[] enemyCost = { 1, 2, 2, 3 };       //敵ごとのコスト
    private int _enemyCost;                         //現在のコスト
    private int maxEnemyCost;                       //最大コスト

    private int[] easy = { 3, 2, 2, 1 };
    private int[] normal = { 4, 3, 2, 2 };
    private int[] hard = { 4, 3, 3, 3 };

    private int[] typeCost = { 0, 0, 0, 0 };        //種別のコスト
    private int[] maxTypeCost;     //種別の最大コスト

    public int difficultyNum;                       //難易度設定の時に使用

    int normalNum;
    int jammerNum;
    int speedNum;
    int hideNum;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
        duct = GameObject.FindGameObjectWithTag("duct");
        ductPos = duct.transform.position;

        difficultyNum = 3;

        timer = 0;

        DifficultySetting();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=0.1f)
        {
            //どの敵かランダム選択
            random = Random.Range(0, Enemy.Length);

            if (_enemyCost < maxEnemyCost && typeCost[random] < maxTypeCost[random])
            {
                //各個体の最大コストより小さい場合実行
                Instantiate(Enemy[random], ductPos, Quaternion.identity);
                Debug.Log("現在の敵全体コスト" + _enemyCost);

                typeCost[random]++;
                Debug.Log("現在の種別コスト { " + typeCost[0] + " , " + typeCost[1] + " , " + typeCost[2] + " , " + typeCost[3] + " }");
            }
            timer = 0;
        }

        SearchEnemy();
    }

    void DifficultySetting()
    {
        _enemyCost = 0;

        switch (difficultyNum)
        {
            case 1:
                //Easy
                maxEnemyCost = 12;
                maxTypeCost = easy;
                break;

            case 2:
                //Normal
                maxEnemyCost = 15;
                maxTypeCost = normal;
                break;

            case 3:
                //Hard
                maxEnemyCost = 20;
                maxTypeCost = hard;
                break;
        }
    }

    void SearchEnemy()
    {
        NormalEnemy = GameObject.FindGameObjectsWithTag("NormalEnemy");
        JammerEnemy = GameObject.FindGameObjectsWithTag("JammerEnemy");
        SpeedEnemy = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        HideEnemy = GameObject.FindGameObjectsWithTag("HideEnemy");

        normalNum = NormalEnemy.Length * enemyCost[0];
        jammerNum = JammerEnemy.Length * enemyCost[1];
        speedNum = SpeedEnemy.Length * enemyCost[2];
        hideNum = HideEnemy.Length * enemyCost[3];

        _enemyCost = normalNum + jammerNum + speedNum + hideNum;
        Debug.Log(_enemyCost);

        typeCost = new int[] { normalNum, jammerNum, speedNum, hideNum };
        Debug.Log("ノーマルは" + normalNum + "\nジャマーは" + jammerNum +
                  "\nスピードは" + speedNum + "\nハイドは" + hideNum);
    }
}
