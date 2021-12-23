using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class MainPanel : BasePanel
{

    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Panel;
       adressPath = "Panel/Main/MainPanel";
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

    }

}