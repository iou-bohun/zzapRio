using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        scoreText.text = DataManager.Instance.MaxScore.ToString();
    }

    public void StartUIAnimation()
    {
        DataManager.Instance.Score = 0;
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
            GameManager.Instance.LoadNextScene();
        }
    }
}
