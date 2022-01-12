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
        selectIndex = -1;
        mp_Compose.gameObject.SetActive(true);
        mp_Role.gameObject.SetActive(true);
        mP_EquipScroll.gameObject.SetActive(true);
        mP_PropScroll.gameObject.SetActive(true);
        equip.onClick.AddListener(OnTabEquipClick);
        prop.onClick.AddListener(OnTabPropClick);
        compose.onClick.AddListener(OnTabComposeClick);
        role.onClick.AddListener(OnTabRoleClick);
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
        OnTabEquipClick();
    }

    //click
    private void OnTabRoleClick()
    {
        equip_img.color = btnBlue;
        prop_img.color = btnBlue;
        compose_img.color = btnBlue;
        PlayBtnAnim(role_img.transform, role_img, btnWhite, AnimCallBack,3);
    }

    private void OnTabComposeClick()
    {
        equip_img.color = btnBlue;
        prop_img.color = btnBlue;
        role_img.color = btnBlue;
        PlayBtnAnim(compose_img.transform, compose_img, btnWhite, AnimCallBack,2);
    }

    private void OnTabPropClick()
    {
        equip_img.color = btnBlue;
        compose_img.color = btnBlue;
        role_img.color = btnBlue;
        PlayBtnAnim(prop_img.transform, prop_img, btnWhite,AnimCallBack,1);
    }

    private void OnTabEquipClick()
    {
        prop_img.color = btnBlue;
        compose_img.color = btnBlue;
        role_img.color = btnBlue;
        PlayBtnAnim(equip_img.transform, equip_img, btnWhite, AnimCallBack,0);
    }

    private void PlayBtnAnim(Transform trans,Image image,Color colorTarget,Action<int> callback,int index)
    {
        if (selectIndex < 0)
        {
            AnimCallBack(0);
            return;
        }
        if (btnSequence!=null && btnSequence.IsPlaying())
        {
            btnSequence.Kill(true);
            btnSequence = null;
        }
        btnSequence = DOTween.Sequence();
        btnSequence.Append(trans.DOScale(Vector3.one * 1.2f, 0.05f));
        btnSequence.Join(image.DOColor(colorTarget, 0.1f));
        btnSequence.Append(trans.DOScale(Vector3.one, 0.05f));
        btnSequence.AppendCallback(() => { callback?.Invoke(index); btnSequence = null; });
    }

    private void AnimCallBack(int index)
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


}