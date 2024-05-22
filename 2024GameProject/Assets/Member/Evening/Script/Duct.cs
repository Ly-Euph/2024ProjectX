using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{

    [SerializeField] GameObject[] Enemy;


    GameObject duct;
    Vector3 ductPos;

    private int random;
    private int[] enemyCost = { 1, 2, 2, 3 };       //�G���Ƃ̃R�X�g
    private int _enemyCost;                         //���݂̃R�X�g
    private int maxEnemyCost;                       //�ő�R�X�g

    private int[] typeCost = { 0, 0, 0, 0 };        //��ʂ̃R�X�g
    private int[] maxTypeCost = { 3, 2, 2, 1 };     //��ʂ̍ő�R�X�g

    private int[] randEnemy1 = { 1, 1, 2, 1, 2, 2, 1, 3, 1, 1, 2, 1, 2, 2, 3, 2, 1, 2, 1, 2 };      //��1
    private int[] randEnemy2 = { 3, 1, 4, 1, 1, 1, 4, 3, 4, 2, 2, 3, 1, 1, 1, 1, 1, 1, 3, 2 };      //��1
    private int[] randEnemy3 = { 2, 2, 1, 1, 2, 1, 3, 4, 3, 4, 1, 3, 2, 1, 3, 2, 2, 3, 1, 1 };      //��2
    private int[] randEnemy4 = { 2, 2, 3, 2, 1, 2, 3, 1, 1, 4, 3, 2, 2, 3, 1, 1, 1, 3, 3, 1 };      //��2
    private int[] randEnemy5 = { 1, 4, 3, 2, 2, 2, 3, 1, 4, 4, 4, 3, 1, 1, 4, 2, 3, 4, 3, 3 };      //��3
    private int[] randEnemy6 = { 2, 4, 4, 1, 3, 1, 1, 4, 3, 1, 4, 2, 3, 2, 3, 3, 1, 3, 3, 1 };      //��3

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
            //�ǂ̓G�������_���I��
            random = Random.Range(0, Enemy.Length);

            if (_enemyCost < maxEnemyCost && typeCost[random] < maxTypeCost[random])
            {
                //�e�̂̍ő�R�X�g��菬�����ꍇ���s
                Instantiate(Enemy[random], ductPos, Quaternion.identity);
                _enemyCost += enemyCost[random];
                Debug.Log("���݂̓G�S�̃R�X�g" + _enemyCost);

                typeCost[random]++;
                Debug.Log("���݂̎�ʃR�X�g { " + typeCost[0] + " , " + typeCost[1] + " , " + typeCost[2] + " , " + typeCost[3] + " }");

            }
            timer = 0;
        }

        
    }
}
