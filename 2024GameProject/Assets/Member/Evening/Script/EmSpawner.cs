using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmSpawner : MonoBehaviour
{
    //�X�|�[��������G�̃v���n�u��ۑ�����Ƃ�
    [SerializeField] GameObject[] Enemy;

    //�e�L�������Ƃ�tag���t�����Ă���A���󋵂ł��̃L���������̑��݂��Ă��邩�̊m�F�Ɏg��
    private GameObject[] em_Normal;
    private GameObject[] em_Jammer;
    private GameObject[] em_Speed;
    private GameObject[] em_Hide;


    //�ŏ��̃X�|�[���A�R�X�gMax�܂�true�A�R�X�g�ő�܂ŗN��������false�ɂȂ�
    private bool firstSpawnFlag;

    //true�̎��A�G�X�|�[��
    //private bool spawnFlag;


    //�e�L�����̃X�|�[���R�X�g
    //1:normal
    //2:speed
    //3:hide
    //4:jammer
    private int[] spawnCost = { 1, 1, 2, 2, 2, 2, 3, 3 };

    //��Փx���Ƃ̊e�L�����ő�X�|�[����
    //1:normal
    //2:speed
    //3:hide
    //4:jammer
    private int[,] emMaxNum = new int[,] { { 10, 5, 5, 2 }, { 8, 6, 6, 4 }, { 4, 5, 5, 7 } };

    //�����݂̃R�X�g��ۑ�����
    private int totalCost;

    //�G���X�|�[������B�e��Փx�̍ő�R�X�g
    private int[] maxCost = { 20, 30, 40 };

    //��Փx���̓G�X�|�[���m��
    //�v�f1:normal��1  2:normal��2  3:speed��1  4:speed��2  5:hide��1  6:hide��2  7:jammer��1  8:jammer��2
    private int[,] probability = new int[,] {
        { 25, 50, 65, 80, 87, 95, 98, 100 }, // easy
        { 15, 30, 45, 60, 73, 85, 93, 100 }, // normal
        { 10, 20, 30, 40, 55, 70, 85, 100 }, // hard 
    };

    //�����_���Ȑ��̐����Ŏg�p
    int random;

    //���Ŏg���Ă邾��
    float timer;


    //�����݂̓�Փx��ۑ�
    //����difficulty�ƏƂ炵���킹�Ďg�p
    private string difficulty;
    private string[] difficult = { "Easy", "Normal", "Hard" };

    // Start is called before the first frame update
    void Start()
    {
        firstSpawnFlag = true;
        //spawnFlag = false;


        totalCost = 0;
        timer = 0;

        difficulty = "Normal";
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;


        if(firstSpawnFlag==true&&timer>=1f)
        {
            CountCost();
            timer = 0;
        }

        //if (timer >= 5f)
        //{
        //    random = Random.Range(0, 4);
        //    timer = 0;
        //    spawnFlag = true;
        //    //Instantiate(Enemy[random], new Vector3(0, 0, 0), Quaternion.identity);
        //}

        //if(spawnFlag==true)
        //{
        //    SearchEnemy();
        //    spawnFlag = false;
            
        //}
    }


    void CountCost()
    {
        //�G�������̑��݂��Ă邩���擾���邽�߂Ɏ��s
        //em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
        //em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");
        //em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        //em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

        random = Random.Range(1, 101);
        Debug.Log("random = " + random);
        for (int i = 0; i < difficult.GetLength(0); i++)
        {
            if (difficulty == difficult[i])
            {
                for (int j = 0; j < probability.GetLength(1); j++)
                {
                    if (j==0)
                    {
                        if(totalCost+spawnCost[j]<maxCost[i]&&probability[i,j]>=random)
                        {
                            Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                            totalCost += spawnCost[j];
                            Debug.Log("totalcost = " + totalCost);
                        }
                    }
                    else if (j >= 1)
                    {
                        if (totalCost + spawnCost[j] < maxCost[i] && probability[i, j] >= random && random > probability[i, j - 1])
                        {
                            Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                            totalCost += spawnCost[j];
                            Debug.Log("totalcost = " + totalCost);
                        }
                    }
                }
            }
        }

    }


    void SearchEnemy()
    {

        random = Random.Range(1, 101);

        //�G�������̑��݂��Ă邩���擾���邽�߂Ɏ��s
        em_Normal = GameObject.FindGameObjectsWithTag("NormalEnemy");
        em_Jammer = GameObject.FindGameObjectsWithTag("JammerEnemy");
        em_Speed = GameObject.FindGameObjectsWithTag("SpeedEnemy");
        em_Hide = GameObject.FindGameObjectsWithTag("HideEnemy");

        totalCost = spawnCost[0] * em_Normal.Length + spawnCost[1] * em_Jammer.Length + 
            spawnCost[2] * em_Speed.Length + spawnCost[3] * em_Hide.Length;





        ChooseEnemy();
        //Debug.Log(emNum);
    }

    void ChooseEnemy()
    {

        //��Փx�m�F
        //i��1��if�����ʂ������A��Փx��easy
        for(int i=0;i<difficult.GetLength(0);i++)
        {
            if(difficulty==difficult[i])
            {
                //�ݒ肳�ꂽ��Փx���̏o���m��
                //probability�̗v�f���������s
                for (int j = 0; j < probability.GetLength(1); j++)
                {
                    //random�̐��l����X�|�[��������G��I��
                    //�����Frandom�ŏo���l�̓G���R�X�g�I�[�o�[���Ă��Ȃ�
                    if (maxCost[i] + spawnCost[j] > totalCost && random > probability[i, j])
                    {
                        Instantiate(Enemy[j], new Vector3(0, 0, 0), Quaternion.identity);
                        totalCost += spawnCost[j];
                    }
                }

            }
            else
            {
                //Debug.Log("tigau");
            }
        }








        //if (random >= difficult[0, 0] && difficult[0, 1] > random)
        //{
        //    //normal_1
        //    Debug.Log("Normal1");
        //}
        //else if (random >= difficult[0, 1] && difficult[0, 2] > random)
        //{
        //    //normal_2
        //    Debug.Log("Normal2");
        //}
        //else if (random >= difficult[0, 2] && difficult[0, 3] > random)
        //{
        //    //jammer
        //    Debug.Log("Jammer");
        //}
        //else if (random >= difficult[0, 3] && difficult[0, 4] > random)
        //{
        //    //speed
        //    Debug.Log("Speed");
        //}
        //else if (random >= difficult[0, 4])
        //{
        //    //hide
        //    Debug.Log("Hide");
        //}
    }
}
