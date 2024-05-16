using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Normal : MonoBehaviour
{
    [SerializeField] float speed;           //�ړ��X�s�[�h


    private GameObject[] door;              //�h�A�̃f�[�^�ۑ�
    private GameObject nearDoor;               //�G�����ԋ߂��h�A


    private Vector3 pos;                    //�G�̍��W
    private Vector3 nearDoorPos;



    private float[] disx;                   //�G�ƃh�A�̋���(x���W)
    private float[] disz;                   //�G�ƃh�A�̋���(z���W)
    private float[] distance;               //�G�ƃh�A�̋���(�ŒZ)

    public bool serchFlag;                  //�߂��h�A�̌���

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

        //�h�A�̌�����������
        if(serchFlag==true)
        {
            SerchDoor();
        }


        EnemyMove();
        Anim();
    }

    void SerchDoor()
    {
        //�h�A�Ƃ����^�O�������I�u�W�F�N�g��ۑ�
        door = GameObject.FindGameObjectsWithTag("Door");


        disx = new float[door.Length];          //�h�A�̐��Ɣz��̗v�f���𓯂���
        disz = new float[door.Length];          //�h�A�̐��Ɣz��̗v�f���𓯂���
        distance = new float[door.Length];      //�h�A�̐��Ɣz��̗v�f���𓯂���


        for (int i = 0; i < door.Length; i++)
        {

            Debug.Log("�o�^�����h�A"+door[i].name);
            //�h�A�̐��������[�v

            disx[i] = Mathf.Abs(door[i].transform.position.x - pos.x);      //i�ԖڂɃh�A�Ƃ̋���(x)��ۑ�
            
            disz[i] = Mathf.Abs(door[i].transform.position.z - pos.z);      //i�ԖڂɃh�A�Ƃ̋���(z)��ۑ�

            distance[i] = Mathf.Pow(disx[i], 2) + Mathf.Pow(disz[i], 2);    //i�ԖڂɃh�A�Ƃ̋���(�ŒZ)��ۑ�
        }
        float minDis = Mathf.Min(distance);         //��ԋ߂�������I��
        Debug.Log("�ŒZ���� = "+minDis);

        
        for(int j=0;j<distance.Length;j++)
        {
            //��ԋ߂��h�A���ǂꂩ
            if(distance[j]==minDis)
            {
                nearDoor = door[j];
                Debug.Log("��ԋ߂��h�A��"+nearDoor.name) ;
                nearDoorPos = nearDoor.transform.position;      //��ԋ߂��h�A�̍��W�擾
            }
        }

        serchFlag = false;
    }//�����I��


    void EnemyMove()
    {

    }



    void Anim()
    {

    }

}
