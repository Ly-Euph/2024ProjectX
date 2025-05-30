using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("�����ŃJ�����̃Y�[���@�\��ݒ�")]

    [SerializeField] int CamMin = 30;
    [SerializeField] int CamMax = 50;

    //�J�����̉��U��̐�����V���A���C�Y��

    [Header("�����ŃJ�����̐U�蕝��ݒ�")]

    [SerializeField] float MaxrotPos = 50;
    [SerializeField] float MinrotPos = -50;

    private float rad = 3.14f / 180;

    [Header("�J�����̔ԍ��ɉ�����Prefab�����ĂˁB")]

    [SerializeField] Camera cam;

    //Start is called before the first frame update
    void Start()
    {
        MaxrotPos = rad * MaxrotPos;
        MinrotPos = rad * MinrotPos;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) { return; }
        if (Input.GetKey(KeyCode.A) && MinrotPos < transform.rotation.y ||
            Input.GetKey(KeyCode.LeftArrow)&& MinrotPos < transform.rotation.y)
        {
            transform.rotation *= Quaternion.Euler(0, -1, 0);

        }
        if (Input.GetKey(KeyCode.D) && transform.rotation.y < MaxrotPos ||
            Input.GetKey(KeyCode.RightArrow)&& transform.rotation.y < MaxrotPos)
        {
            transform.rotation *= Quaternion.Euler(0, 1, 0);
        }
       
    }
}
