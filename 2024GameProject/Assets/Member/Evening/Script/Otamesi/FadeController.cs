using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] GameObject PanelObj;
    [SerializeField] GameObject redPanel;
    private RectTransform rectRed;
    [SerializeField] GameObject bloodPanel;
    private RectTransform rectBlood;
    [SerializeField] Text gameOverText;

    private Vector2 wideRed;
    private Vector2 wideBlood;

    private Vector3 redPanelPos;
    private Vector3 bloodPanelPos;

    private const float MAX_FADETIME = 60.0f;
    private const float MIN_FADETIME = 60.0f;

    private float fadeTimer;


    // Start is called before the first frame update
    void Start()
    {
        rectRed = redPanel.GetComponent<RectTransform>();
        rectBlood = bloodPanel.GetComponent<RectTransform>();

        wideRed = rectRed.sizeDelta;
        wideBlood = rectBlood.sizeDelta;

        redPanelPos = redPanel.transform.localPosition;
        bloodPanelPos = bloodPanel.transform.localPosition;

        fadeTimer = 0.0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        fadeTimer += Time.deltaTime;

        if (fadeTimer <= MAX_FADETIME)
        {
            FadeInPanel();
        }
        else if (fadeTimer > MAX_FADETIME)
        {
            FadeOutPanel();
        }

    }

    private void FadeInPanel()
    {
        Debug.Log(fadeTimer);
        rectRed.sizeDelta = new Vector2(0, 0.03f * Time.deltaTime);
        rectBlood.sizeDelta = new Vector2(0, 1000 * Time.deltaTime);
    }

    private void FadeOutPanel()
    {

    }

    private void TransitionScene()
    {
        SceneManager.LoadScene("");
    }
}
