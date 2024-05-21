using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{

    [SerializeField] GameObject[] Enemy;


    GameObject duct;
    Vector3 ductPos;

    private int random;
    private int[] enemyCost = { 1, 2, 2, 3 };       //敵ごとのコスト
    private int _enemyCost;                         //現在のコスト
    private int maxEnemyCost;                       //最大コスト

    private int[] typeCost = { 0, 0, 0, 0 };        //種別のコスト
    private int[] maxTypeCost = { 3, 2, 2, 1 };     //種別の最大コスト

    private int[] randEnemy1 = { 1, 1, 2, 1, 2, 2, 1, 3, 1, 1, 2, 1, 2, 2, 3, 2, 1, 2, 1, 2 };      //☆1
    private int[] randEnemy2 = { 3, 1, 4, 1, 1, 1, 4, 3, 4, 2, 2, 3, 1, 1, 1, 1, 1, 1, 3, 2 };      //☆1
    private int[] randEnemy3 = { 2, 2, 1, 1, 2, 1, 3, 4, 3, 4, 1, 3, 2, 1, 3, 2, 2, 3, 1, 1 };      //☆2
    private int[] randEnemy4 = { 2, 2, 3, 2, 1, 2, 3, 1, 1, 4, 3, 2, 2, 3, 1, 1, 1, 3, 3, 1 };      //☆2
    private int[] randEnemy5 = { 1, 4, 3, 2, 2, 2, 3, 1, 4, 4, 4, 3, 1, 1, 4, 2, 3, 4, 3, 3 };      //☆3
    private int[] randEnemy6 = { 2, 4, 4, 1, 3, 1, 1, 4, 3, 1, 4, 2, 3, 2, 3, 3, 1, 3, 3, 1 };      //☆3

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        duct = GameObject.FindGameObjectWithTag("duct");
        ductPos = duct.transform.position;

        timer = 0;

        _enemyCost = 0;
        maxEnemyCost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=2f)
        {
            //どの敵かランダム選択
            random = Random.Range(0, Enemy.Length);

            if (_enemyCost < maxEnemyCost && typeCost[random] < maxTypeCost[random])
            {
                //各個体の最大コストより小さい場合実行
                Instantiate(Enemy[random], ductPos, Quaternion.identity);
                _enemyCost += enemyCost[random];
                Debug.Log("現在の敵全体コスト" + _enemyCost);

                typeCost[random]++;
                Debug.Log("現在の種別コスト { " + typeCost[0] + " , " + typeCost[1] + " , " + typeCost[2] + " , " + typeCost[3] + " }");

            }
            timer = 0;
        }

        
    }
}
