using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : MonoBehaviour
{
    [SerializeField] float speed;           //移動スピード


    private GameObject[] door;              //ドアのデータ保存
    private GameObject nearDoor;               //敵から一番近いドア


    private Vector3 pos;                    //敵の座標
    private Vector3 nearDoorPos;



    private float[] disx;                   //敵とドアの距離(x座標)
    private float[] disz;                   //敵とドアの距離(z座標)
    private float[] distance;               //敵とドアの距離(最短)

    public bool serchFlag;                  //近いドアの検索

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
        serchFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        //ドアの検索をかける
        if(serchFlag==true)
        {
            SerchDoor();
        }


        EnemyMove();
        Anim();
    }

    void SerchDoor()
    {
        //ドアというタグがついたオブジェクトを保存
        door = GameObject.FindGameObjectsWithTag("Door");


        disx = new float[door.Length];          //ドアの数と配列の要素数を同じに
        disz = new float[door.Length];          //ドアの数と配列の要素数を同じに
        distance = new float[door.Length];      //ドアの数と配列の要素数を同じに


        for (int i = 0; i < door.Length; i++)
        {

            Debug.Log("登録したドア"+door[i].name);
            //ドアの数だけループ

            disx[i] = Mathf.Abs(door[i].transform.position.x - pos.x);      //i番目にドアとの距離(x)を保存
            
            disz[i] = Mathf.Abs(door[i].transform.position.z - pos.z);      //i番目にドアとの距離(z)を保存

            distance[i] = Mathf.Pow(disx[i], 2) + Mathf.Pow(disz[i], 2);    //i番目にドアとの距離(最短)を保存
        }
        float minDis = Mathf.Min(distance);         //一番近い距離を選択
        Debug.Log("最短距離 = "+minDis);

        
        for(int j=0;j<distance.Length;j++)
        {
            //一番近いドアがどれか
            if(distance[j]==minDis)
            {
                nearDoor = door[j];
                Debug.Log("一番近いドアは"+nearDoor.name) ;
                nearDoorPos = nearDoor.transform.position;      //一番近いドアの座標取得
            }
        }

        serchFlag = false;
    }//検索終了


    void EnemyMove()
    {

    }



    void Anim()
    {

    }

}
