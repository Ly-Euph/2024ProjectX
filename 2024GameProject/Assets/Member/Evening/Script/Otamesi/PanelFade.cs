using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFade : MonoBehaviour
{
    [SerializeField] Image FadePanel;
    [SerializeField] Text gameOverText;

    float panelRed, panelGreen, panelBlue, panelAlfa;
    float textRed, textGreen, textBlue, textAlfa;

    float timer = 0.0f;

    private void Start()
    {
        panelRed = 0.6588235f;
        panelGreen = 0.0f;
        panelBlue = 0.0f;
        panelAlfa = 0.0f;

        FadePanel.color = new Color(panelRed, panelGreen, panelBlue, panelAlfa);

        textRed = 1.0f;
        textGreen = 1.0f;
        textBlue = 1.0f;
        textAlfa = 0.0f;

        gameOverText.color = new Color(textRed, textGreen, textBlue, textAlfa);

        //FadePanel.gameObject.GetComponent<Image>().color = panelColor;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3.0f)
        {
            Fade();
        }
    }

    private void Fade()
    {
        panelAlfa += 0.05f;
        textAlfa += 0.05f;
        FadePanel.color = new Color(panelRed, panelGreen, panelBlue, panelAlfa);
        gameOverText.color = new Color(textRed, textGreen, textBlue, textAlfa);
    }

}
