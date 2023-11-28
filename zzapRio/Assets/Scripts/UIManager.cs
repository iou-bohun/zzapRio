using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas canvas_Main;
    public TMP_Text scoreText;
    public TMP_Text newBestText;
    public Image PlayButtonImage;
    public CanvasGroup canvasGroup;

    public void Retry()
    {
        canvas_Main.gameObject.SetActive(true);

        scoreText.rectTransform.anchoredPosition = Vector2.zero;
        canvasGroup.alpha = 0.0f;
        newBestText.rectTransform.anchoredPosition = Vector2.zero;
        PlayButtonImage.rectTransform.anchoredPosition = Vector2.zero;

        scoreText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        scoreText.rectTransform.DOAnchorPosY(270f, 1f).SetDelay(2f);
        scoreText.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetDelay(2f);

        canvasGroup.DOFade(1f, 1f).SetDelay(2f);

        newBestText.rectTransform.DOAnchorPosY(13f, 1f).SetDelay(2f);
        PlayButtonImage.rectTransform.DOAnchorPosY(-380f, 1f).SetDelay(2f);
    }
}
