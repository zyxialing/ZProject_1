using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class TopBanner : BasePanel
{

    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.PanelUp;
        adressPath = "PanelUp/Top/TopBanner";
    }

    public override void OnShowing()
    {
        EventManager.Instance.AddObserver<EventShowBanner>(OnShowBanner);
    }

    public override void OnOpen()
    {
        RefreshPanel();
    }

    public override void OnClosing()
    {
        
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveObserver<EventShowBanner>(OnShowBanner);
    }

    private void RefreshPanel()
    {

    }
    ///////////////////////message///////////////////
    private void OnShowBanner(EventShowBanner obj)
    {
        panel.SetActive(obj.show);
    }

}