using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CountDownManager : MonoBehaviour
{
    public int countDownStartNumber;
    public TMP_Text countDownText;
    public int countDownCount;
    public Canvas countDownCanvas;
    public string countDownEndMessage;
    public CanvasGroup canvasGroup;

    public UIManager uiManager;

    public void StartCountDown()
    {
        countDownCount = countDownStartNumber;
        countDownCanvas.gameObject.SetActive(true);

        StartCoroutine(CountDownCo());
    }

    private IEnumerator CountDownCo()
    {
        if(countDownCount > 0)
        {
            countDownText.text = countDownCount.ToString();
        }
        else
        {
            countDownText.text = countDownEndMessage;
        }

        canvasGroup.DOFade(1f, 0.3f).SetUpdate(true).OnComplete(() => 
        {
            canvasGroup.DOFade(0f, 0.3f).SetUpdate(true).SetDelay(0.3f);
        });

        yield return new WaitForSecondsRealtime(1f);
        countDownCount--;
        if(countDownCount >= 0 )
        {
            StartCoroutine(CountDownCo());
        }
        else
        {
            uiManager.Retry();
        }
    }
}
