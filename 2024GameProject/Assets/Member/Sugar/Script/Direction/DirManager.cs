using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirManager : MonoBehaviour
{
    // �S�̂Ŏg���ϐ�
    #region All
    // �Q�[���I�[�o�[���쓮�����瓮�����Ȃ�
    [SerializeField] GameOverObj gameOverObj;
    [SerializeField] GameObject img;
    [SerializeField] SubLight light;
    #endregion

    // ���邳�ύX�֌W
    #region Light
    [SerializeField]
    int fademaxBright = 70;
    [SerializeField]
    int fademinBright = 30;

    int minBright = 0;
    int setBright;

    // �X�C�b�`�����̔ԍ��Ǘ�
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
    /// ���邳�ύX���郁�\�b�h
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
    /// �X�C�b�`�����̃p�[�c���̏����Ɍ������N�[���^�C���Ǘ�
    /// </summary>
    /// <param name="time">�N�[���^�C��</param>
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
