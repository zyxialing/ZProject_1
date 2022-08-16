using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class FailPanel : BasePanel
{

    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Panel;
        adressPath = "Pop/Fail/FailPanel";
    }
    public override void OnShowing()
    {
        AddClick(backBtn, () => {
            ResLoader.Instance.GetScene("EmptyScene", (hander) =>
            {
                JumpManager.GomeHome(()=> { JumpManager.JumpPanel<LevelPanel>(); });

            });
        });
    }

    public override void OnOpen()
    {
        RefreshPanel();
    }

    public override void OnHide()
    {
     
    }

    public override void OnClosing()
    {
     
    }

    private void RefreshPanel()
    {

    }

}