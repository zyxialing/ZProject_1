using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image loadingProgress;
    void Start()
    {
        loadingProgress.fillAmount = 0;
        ResHanderManager.Instance.Init((progress) =>
        {
            loadingProgress.DOKill(false);
            loadingProgress.DOFillAmount(progress,0.19f);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
