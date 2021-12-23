using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class LoadingPanel : BasePanel
{

    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Tips;
       adressPath = "Overlay/Loading/LoadingPanel";
    }
    public override void OnShowing()
    {

    }

    public override void OnShowed()
    {
        RefreshPanel();
    }

    private void RefreshPanel()
    {
        slider_LoadingBar.value = 0;
        ResHanderManager.Instance.Init((progress) =>
        {
            slider_LoadingBar.DOKill(false);
            slider_LoadingBar.DOValue(progress, 1f);
            if (progress >= 1)
            {
                UIManager.Instance.Init();
                Invoke("EnterGame", 1f);
            }
        });
    }
    private void EnterGame()
    {
        ResLoader.Instance.GetScene("MainUI", ()=> {
            Close();
            UIManager.Instance.OpenPanel<MainPanel>();
        });
    }

    public void Update()
    {
        if (slider_progress != null && slider_LoadingBar != null)
        {
            slider_progress.text = (slider_LoadingBar.value).ToString("#00.00%");
        }
    }
}