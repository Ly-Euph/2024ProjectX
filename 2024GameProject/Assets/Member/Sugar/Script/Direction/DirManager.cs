using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirManager : MonoBehaviour
{
    // 全体で使う変数
    #region All
    // ゲームオーバーが作動したら動かさない
    [SerializeField] GameOverObj gameOverObj;
    [SerializeField] GameObject img;
    [SerializeField] SubLight light;
    #endregion

    // 明るさ変更関係
    #region Light
    [SerializeField]
    int fademaxBright = 70;
    [SerializeField]
    int fademinBright = 30;

    int minBright = 0;
    int setBright;

    // スイッチ処理の番号管理
    int bNum = 0;

    float bTimer = 0;
    #endregion

    void Start()
    {
        setBright = fademaxBright;
    }

    // Update is called once per frame
    void Update()
    {
        if (light.IsLight)
        {
            setBright = 100;
            return;
        }
        else
        {
            setBright = fademaxBright;
        }
        Bright();

    }

    /// <summary>
    /// 明るさ変更するメソッド
    /// </summary>
    private void Bright()
    {
        switch (bNum)
        {
            case 0:
                setBright = fademaxBright;
                Bparts(2);
                break;
            case 1:
                setBright = fademinBright;
                Bparts(0.5f);
                break;
            case 2:
                setBright = fademaxBright;
                Bparts(0.1f);
                break;
            case 3:
                setBright = fademinBright;
                Bparts(0.5f);
                break;
            case 4:
                setBright = fademaxBright;
                Bparts(0);
                break;
            case 5:
                setBright = fademinBright;
                Bparts(0.5f);
                break;
            case 6:
                setBright = fademaxBright;
                bNum++;
                break;
            case 7:
                bTimer += Time.deltaTime;
                if(bTimer>=17)
                {
                    bNum = 0;
                }
                break;
        }

    }

    /// <summary>
    /// スイッチ処理のパーツ次の処理に向かうクールタイム管理
    /// </summary>
    /// <param name="time">クールタイム</param>
    private void Bparts(float time )
    {
        bTimer += Time.deltaTime;

        if (bTimer >= time)
        {
            bTimer = 0;
            bNum++;
        }
    }
    public int SendBright
    {
        get { return setBright; }
    }
}
