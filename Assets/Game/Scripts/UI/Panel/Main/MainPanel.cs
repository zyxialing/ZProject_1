using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public partial class MainPanel : BasePanel
{
    private Color btnBlue = new Color(0.2901961f, 0.6745098f, 0.9686275f);
    private Color btnWhite = Color.white;
    private Sequence btnSequence;
    private int selectIndex = -1;
    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Panel;
        adressPath = "Panel/Main/MainPanel";
    }
    public override void OnShowing()
    {
        EventManager.Instance.AddObserver<EventChangeTab_MP>(EventChangeTab_MPCallBack);
        selectIndex = -1;
        mp_Compose.gameObject.SetActive(true);
        mp_Role.gameObject.SetActive(true);
        mP_EquipScroll.gameObject.SetActive(true);
        mP_PropScroll.gameObject.SetActive(true);
    }

    public override void OnOpen()
    {
        SelectIndex(0);
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

 

    private void SelectIndex(int index)
    {
        if (selectIndex != index)
        {
            selectIndex = index;
            mp_Compose.gameObject.SetActive(false);
            mp_Role.gameObject.SetActive(false);
            mP_EquipScroll.gameObject.SetActive(false);
            mP_PropScroll.gameObject.SetActive(false);
            switch (selectIndex)
            {
                case 0:
                    Debug.LogError("装备tab");
                    mP_EquipScroll.gameObject.SetActive(true);
                    mP_EquipScroll.scroller.ReloadData();
                    break;
                case 1:
                    Debug.LogError("道具tab");
                    mP_PropScroll.gameObject.SetActive(true);
                    mP_PropScroll.scroller.ReloadData();
                    break;
                case 2:
                    Debug.LogError("合成tab");
                    mp_Compose.gameObject.SetActive(true);
                    break;
                case 3:
                    Debug.LogError("角色tab");
                    mp_Role.gameObject.SetActive(true);
                    break;
            }

        }
    }
    /// event
    private void EventChangeTab_MPCallBack(EventChangeTab_MP eventData)
    {
        SelectIndex(eventData.index);
    }

}