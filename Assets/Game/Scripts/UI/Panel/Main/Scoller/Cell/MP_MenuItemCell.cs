using EnhancedUI.EnhancedScroller;
using System;
using UnityEngine;
using UnityEngine.UI;

public partial class MP_MenuItemCell : EnhancedScrollerCellView
{
    private bool _init = false;
    public override void RefreshCellView()
    {
        Init();
        UIUtils.SetSprite(icon, "icon/tab" + dataIndex);

    }


    private void Init()
    {
        if (!_init)
        {
            _init = true;
            AutoInit();
            cellBtn.onClick.RemoveAllListeners();
            cellBtn.onClick.AddListener(() => { ZLogUtil.LogError(dataIndex); });
        }
    }

}