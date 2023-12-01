using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class UIManager1 : MonoBehaviour
{
    [Header ("MainViewCanvas")]
    public Canvas mainCanvas;
    public TMP_Text scoreText;
    public TMP_Text newBestText;
    public Image PlayButtonImage;
    public CanvasGroup canvasGroup;

    public bool newRecord;
    public ParticleSystem confettiParticle;

    private void Start()
    {
        scoreText.text = DataManager.Instance.Score.ToString();
    }

    public void RetryUIAnimation()
    {

        mainCanvas.gameObject.SetActive(true);

        scoreText.rectTransform.anchoredPosition = Vector2.zero;
        canvasGroup.alpha = 0.0f;
        newBestText.rectTransform.anchoredPosition = Vector2.zero;
        PlayButtonImage.rectTransform.anchoredPosition = Vector2.zero;

        if(DataManager.Instance.isNewRecord)
        {
            newBestText.gameObject.SetActive(true);
            confettiParticle.Play();
        }
        else
        {
            newBestText.gameObject.SetActive(false);
        }


        scoreText.rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        scoreText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);

        scoreText.rectTransform.DOAnchorPosY(270f, 1f).SetDelay(2f);
        scoreText.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetDelay(2f);

        canvasGroup.DOFade(1f, 1f).SetDelay(2f);

        newBestText.rectTransform.DOAnchorPosY(13f, 1f).SetDelay(2f);
        PlayButtonImage.rectTransform.DOAnchorPosY(-380f, 1f).SetDelay(2f).OnComplete(() =>
        {
            Debug.Log("sibal");
            SceneManager.LoadScene("MainView");
        });
    }

}
