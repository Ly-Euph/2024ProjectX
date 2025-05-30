using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("ここでカメラのズーム機能を設定")]

    [SerializeField] int CamMin = 30;
    [SerializeField] int CamMax = 50;

    //カメラの横振りの制御をシリアライズ化

    [Header("ここでカメラの振り幅を設定")]

    [SerializeField] float MaxrotPos = 50;
    [SerializeField] float MinrotPos = -50;

    private float rad = 3.14f / 180;

    [Header("カメラの番号に応じたPrefabを入れてね。")]

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
