using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;

public class UIManager : MonoBehaviour
{
    [Header ("MainViewCanvas")]
    public Canvas mainCanvas;
    public TMP_Text scoreText;
    public TMP_Text newBestText;
    public Image PlayButtonImage;
    public CanvasGroup canvasGroup;

    [Header ("CountDownCanvas")]
    public int countDownStartNumber;
    public TMP_Text countDownText;
    public int countDownCount;
    public Canvas countDownCanvas;
    public string countDownEndMessage;
    public CanvasGroup countDownCanvasGroup;

    public bool newRecord;
    public ParticleSystem confettiParticle;
    public void RetryUIAnimation()
    {
        mainCanvas.gameObject.SetActive(true);

        scoreText.rectTransform.anchoredPosition = Vector2.zero;
        canvasGroup.alpha = 0.0f;
        newBestText.rectTransform.anchoredPosition = Vector2.zero;
        PlayButtonImage.rectTransform.anchoredPosition = Vector2.zero;

        if(newRecord)
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
        PlayButtonImage.rectTransform.DOAnchorPosY(-380f, 1f).SetDelay(2f);
    }

    public void StartUIAnimation()
    {
        scoreText.rectTransform.DOAnchorPosX(720f, 1f).SetEase(Ease.InExpo);
        PlayButtonImage.rectTransform.DOAnchorPosX(720f, 1.2f).SetEase(Ease.InExpo);
        newBestText.rectTransform.DOAnchorPosX(720f, 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
        {
            mainCanvas.gameObject.SetActive(false);
            countDownCanvas.gameObject.SetActive(true);
            StartCountDown();
        });
    }

    public void StartCountDown()
    {
        countDownCount = countDownStartNumber;
        countDownCanvas.gameObject.SetActive(true);

        StartCoroutine(CountDownCo());
    }

    private IEnumerator CountDownCo()
    {
        if (countDownCount > 0)
        {
            countDownText.text = countDownCount.ToString();
        }
        else
        {
            countDownText.text = countDownEndMessage;
        }

        countDownCanvasGroup.DOFade(1f, 0.3f).SetUpdate(true).OnComplete(() =>
        {
            countDownCanvasGroup.DOFade(0f, 0.3f).SetUpdate(true).SetDelay(0.3f);
        });

        yield return new WaitForSecondsRealtime(1f);
        countDownCount--;
        if (countDownCount >= 0)
        {
            StartCoroutine(CountDownCo());
        }
        else
        {
            RetryUIAnimation();
        }
    }
}
