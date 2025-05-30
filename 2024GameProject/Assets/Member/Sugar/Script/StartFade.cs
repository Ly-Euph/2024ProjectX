using UnityEngine;
using UnityEngine.UI;
public class StartFade : MonoBehaviour
{
    // �n�܂�̃t�F�[�h����
    [SerializeField] Image img;

    float fadeSpd = 1;

    void Update()
    {
        fadeSpd -= 0.02f;
        img.color = new Color(0, 0, 0, fadeSpd);

        if(fadeSpd<=0)
        {
            Destroy(gameObject);
        }
    }
}
