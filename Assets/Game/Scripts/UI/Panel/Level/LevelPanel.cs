using System;
using System.Collections;
using System.Collections.Generic;
using Table;
using UnityEngine;
using UnityEngine.UI;
public partial class LevelPanel : BasePanel
{

    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Panel;
        adressPath = "Panel/Level/LevelPanel";
    }
    public override void OnShowing()
    {
        EventManager.Instance.AddObserver<EventEnterLevel>(EventEnterLevelCallBack);
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
    private void OnDestroy()
    {
        EventManager.Instance.RemoveObserver<EventEnterLevel>(EventEnterLevelCallBack);
    }
    ///messager
    private void EventEnterLevelCallBack(EventEnterLevel obj)
    {
        Statistics.Instance.SetLevelId(obj.levelId);
        GameControler.Instance.GoGameScene(() => { Close(); });
    }

}