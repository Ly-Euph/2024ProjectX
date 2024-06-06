using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [Header("Camera関連をここに入れといて")]

    [SerializeField] GameObject[] Camera = new GameObject[3];

    [Header("Text関連をここに入れといて")]

    [SerializeField] Text CameraText;

    [Header("BatteryManagerを入れてね。")]

    [SerializeField] BatteryManager Bm;

    [Header("TrapManagerを入れてね")]

    [SerializeField] TrapManager Tm;

    [Header("Enemy関連")]

    [SerializeField] GameObject[] enemy = new GameObject[3];

    [Header("Trapを設置するObject")]

    [SerializeField] GameObject[] Trap_Obj;

    [Header("様々なTrapを入れてね")]

    [SerializeField] GameObject[] Trap_GK;

    [Header("お好きなようにクールタイムを変えてね")]

    [SerializeField] float Cool_Time = 20;

    SonarFx[] sf = new SonarFx[6];

    [SerializeField] Text[] CoolTime_Volt;

    private int Volt_time = 20;

    private int _time = 1;

    private float time;
    private float time1;
    private float time2;

    private float Volt_timer = 20;
    private float Volt_timer1 = 20;
    private float Volt_timer2 = 20;
    private float Volt_timer3 = 20;
    private float Volt_timer4 = 20;
    private float Volt_timer5 = 20;

    private bool TimeFlg = true;

    private bool[] Volt_Flg = new bool[6];

    private bool[] CamFlg = new bool[6];

    void Start()
    {
        //カメラ1以外のカメラは最初にfalseに

        Camera[1].SetActive(false);
        Camera[2].SetActive(false);
        Camera[3].SetActive(false);
        Camera[4].SetActive(false);
        Camera[5].SetActive(false);

        //sfの配列にSonarFxをげっとする。

        sf[0] = Camera[0].GetComponent<SonarFx>();
        sf[1] = Camera[1].GetComponent<SonarFx>();
        sf[2] = Camera[2].GetComponent<SonarFx>();
        sf[3] = Camera[3].GetComponent<SonarFx>();
        sf[4] = Camera[4].GetComponent<SonarFx>();
        sf[5] = Camera[5].GetComponent<SonarFx>();

        //Sonartxをfalseに

        SonarOff();

        CoolTime_Volt[0].text = "OK";
        CoolTime_Volt[1].text = "OK";
        CoolTime_Volt[2].text = "OK";
        CoolTime_Volt[3].text = "OK";
        CoolTime_Volt[4].text = "OK";
        CoolTime_Volt[5].text = "OK";

        Tm.Volt_CTImg[0].GetComponent<Image>().fillAmount = 0;
        Tm.Volt_CTImg[1].GetComponent<Image>().fillAmount = 0;
        Tm.Volt_CTImg[2].GetComponent<Image>().fillAmount = 0;
        Tm.Volt_CTImg[3].GetComponent<Image>().fillAmount = 0;
        Tm.Volt_CTImg[4].GetComponent<Image>().fillAmount = 0;
        Tm.Volt_CTImg[5].GetComponent<Image>().fillAmount = 0;
    }

    void Update()
    {
        //Shiftキーを押したときにバッテリーを５%減らす。
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            Bm.Para_Battery -= 5f;
        }

        //Shiftキーを押し続けたときにバッテリーを継続的に減らす。

        if (Input.GetKey(KeyCode.LeftShift))
        {
            SonarOn();
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 0.05f;
            }
        }

        //Shiftキーを離したときにスキャンを止める。

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SonarOff();
        }
        //トラップEキーを押したときの処理


        if (Input.GetKeyDown(KeyCode.E) && CamFlg[0] && Volt_timer >= 20)
        {
            Vector3 ObjPos = Trap_Obj[0].transform.position;
            Instantiate(Trap_GK[0], ObjPos, Quaternion.identity);
            TimeFlg = false;
            time = 0;
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 10;
            }
        }
        if(!TimeFlg)
        {
            time += Time.deltaTime;
            //Fキーのクールタイム
            if (time >= Volt_timer)
            {
                TimeFlg = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && CamFlg[1] && Volt_timer1 >= 20)
        {
            Vector3 ObjPos = Trap_Obj[1].transform.position;
            Instantiate(Trap_GK[1], ObjPos, Quaternion.identity);
            TimeFlg = false;
            time1 = 0;
            if (Bm.Para_Battery >= 0)
            {
                Bm.Para_Battery -= 10;
            }
        }
        if (!TimeFlg)
        {
            time1 += Time.deltaTime;
            //Fキーのクールタイム
            if (time1 >= Volt_timer1)
            {
                TimeFlg = true;
            }
        }
        Debug.Log(time);
        //番号１
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Camera1の設定
            SetCamera1();
            CamFlag();
            CamFlg[0] = true;
        }
        //番号２

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Camera2の設定
            SetCamera2();
            CamFlag();
            CamFlg[1] = true;
        }

        //番号３

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Camera3の設定
            SetCamera3();
            CamFlag();
            CamFlg[2] = true;
        }
        //番号４

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Camera4の設定
            SetCamera4();
            CamFlag();
            CamFlg[3] = true;
        }
        //番号５

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Camera5の設定
            SetCamera5();
            CamFlag();
            CamFlg[4] = true;
        }
        //番号６

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Camera6の設定
            SetCamera6();
            CamFlag();
            CamFlg[5] = true;
        }
        TextChange();
    }


    //以下カメラ機能の制御

    void SetCamera1()
    {
        CameraScan();
        Camera[0].SetActive(true);
        CameraText.text = "カメラ１:";
    }

    void SetCamera2()
    {
        CameraScan();
        Camera[1].SetActive(true);

        CameraText.text = "カメラ２:";
    }

    void SetCamera3()
    {
        CameraScan();
        Camera[2].SetActive(true);
        CameraText.text = "カメラ３:";
    }

    void SetCamera4()
    {
        CameraScan();
        Camera[3].SetActive(true);
        CameraText.text = "カメラ４:";
    }

    void SetCamera5()
    {
        CameraScan();
        Camera[4].SetActive(true);
        CameraText.text = "カメラ５:";
    }
    void SetCamera6()
    {
        CameraScan();
        Camera[5].SetActive(true);
        CameraText.text = "カメラ６:";
    }
    void SonarOff()
    {
        for (int i = 0; i < sf.Length; i++)
        {
            sf[i].enabled = false;
        }
    }
    void SonarOn()
    {
        for (int i = 0; i < sf.Length; i++)
        {
            sf[i].enabled = true;
        }
    }
    void CameraScan()
    {
        for (int i = 0; i < Camera.Length; i++)
        {
            Camera[i].SetActive(false);
        }
    }

    void CamFlag()
    {
        for (int i = 0; i < CamFlg.Length; i++)
        {
            CamFlg[i] = false;
        }
    }

    void TextChange()
    {
        //以下のプログラムは暇なときに綺麗にする。とりあえずクールタイムとカメラそれぞれのUIの切り替え

        if (CamFlg[0] && Input.GetKeyDown(KeyCode.E) && Tm.Volt_CTImg[0].GetComponent<Image>().fillAmount == 0)
        {
            CoolTime_Volt[0].text = Volt_time.ToString();
            Tm.Volt_CTImg[0].GetComponent<Image>().fillAmount += 1;
            Volt_Flg[0] = true;
        }

        if (CamFlg[1] && Input.GetKeyDown(KeyCode.E) && Tm.Volt_CTImg[1].GetComponent<Image>().fillAmount == 0)
        {
            CoolTime_Volt[1].text = Volt_time.ToString();
            Tm.Volt_CTImg[1].GetComponent<Image>().fillAmount += 1;
            Volt_Flg[1] = true;
        }

        if (CamFlg[2] && Input.GetKeyDown(KeyCode.E) && Tm.Volt_CTImg[2].GetComponent<Image>().fillAmount == 0)
        {
            CoolTime_Volt[2].text = Volt_time.ToString();
            Tm.Volt_CTImg[2].GetComponent<Image>().fillAmount += 1;
            Volt_Flg[2] = true;
        }

        if (CamFlg[3] && Input.GetKeyDown(KeyCode.E) && Tm.Volt_CTImg[3].GetComponent<Image>().fillAmount == 0)
        {
            CoolTime_Volt[3].text = Volt_time.ToString();
            Tm.Volt_CTImg[3].GetComponent<Image>().fillAmount += 1;
            Volt_Flg[3] = true;
        }

        if (CamFlg[4] && Input.GetKeyDown(KeyCode.E) && Tm.Volt_CTImg[4].GetComponent<Image>().fillAmount == 0)
        {
            CoolTime_Volt[4].text = Volt_time.ToString();
            Tm.Volt_CTImg[4].GetComponent<Image>().fillAmount += 1;
            Volt_Flg[4] = true;
        }

        if (CamFlg[5] && Input.GetKeyDown(KeyCode.E) && Tm.Volt_CTImg[5].GetComponent<Image>().fillAmount == 0)
        {
            CoolTime_Volt[5].text = Volt_time.ToString();
            Tm.Volt_CTImg[5].GetComponent<Image>().fillAmount += 1;
            Volt_Flg[5] = true;
        }

        if (Volt_Flg[0])
        {
            Volt_timer -= Time.deltaTime;
            CoolTime_Volt[0].text = (int)Volt_timer + "";
            Tm.Volt_CTImg[0].GetComponent<Image>().fillAmount -= 1 / 20.0f * Time.deltaTime;
            if (Volt_timer <= 0)
            {
                Volt_Flg[0] = false;
                CoolTime_Volt[0].text = "OK";
                Volt_timer = 20;
            }
        }

        if (Volt_Flg[1])
        {
            Volt_timer1 -= Time.deltaTime;
            CoolTime_Volt[1].text = (int)Volt_timer1 + "";
            Tm.Volt_CTImg[1].GetComponent<Image>().fillAmount -= 1 / 20.0f * Time.deltaTime;
            if (Volt_timer1 <= 0)
            {
                Volt_Flg[1] = false;
                CoolTime_Volt[1].text = "OK";
                Volt_timer1 = 20;
            }
        }
        if (Volt_Flg[2])
        {
            Volt_timer2 -= Time.deltaTime;
            CoolTime_Volt[2].text = (int)Volt_timer2 + "";
            Tm.Volt_CTImg[2].GetComponent<Image>().fillAmount -= 1 / 20.0f * Time.deltaTime;
            if (Volt_timer2 <= 0)
            {
                Volt_Flg[2] = false;
                CoolTime_Volt[2].text = "OK";
                Volt_timer2 = 20;
            }
        }
        if (Volt_Flg[3])
        {
            Volt_timer3 -= Time.deltaTime;
            CoolTime_Volt[3].text = (int)Volt_timer3 + "";
            Tm.Volt_CTImg[3].GetComponent<Image>().fillAmount -= 1 / 20.0f * Time.deltaTime;
            if (Volt_timer3 <= 0)
            {
                Volt_Flg[3] = false;
                CoolTime_Volt[3].text = "OK";
                Volt_timer3 = 20;
            }
        }
        if (Volt_Flg[4])
        {
            Volt_timer4 -= Time.deltaTime;
            CoolTime_Volt[4].text = (int)Volt_timer4 + "";
            Tm.Volt_CTImg[4].GetComponent<Image>().fillAmount -= 1 / 20.0f * Time.deltaTime;
            if (Volt_timer4 <= 0)
            {
                Volt_Flg[4] = false;
                CoolTime_Volt[4].text = "OK";
                Volt_timer4 = 20;
            }
        }
        if (Volt_Flg[5])
        {
            Volt_timer5 -= Time.deltaTime;
            CoolTime_Volt[5].text = (int)Volt_timer5 + "";
            Tm.Volt_CTImg[5].GetComponent<Image>().fillAmount -= 1 / 20.0f * Time.deltaTime;
            if (Volt_timer5 <= 0)
            {
                Volt_Flg[5] = false;
                CoolTime_Volt[5].text = "OK";
                Volt_timer5 = 20;
            }
        }
    }
}
