using EnhancedUI.EnhancedScroller;
using System;
using UnityEngine;
using UnityEngine.UI;

public partial class MP_MenuItemCell : EnhancedScrollerCellView
{
    private bool _init = false;
    private MP_TapMenu _tapMenu;
    public override void RefreshCellView()
    {
        UIUtils.SetSprite(icon, "icon/tab" + dataIndex);

    }

    public override void InitData(object obj)
    {
        Init(obj);
    }

    private void Init(object obj)
    {
        if (!_init)
        {
            _init = true;
            AutoInit();
            _tapMenu = obj as MP_TapMenu;
            cellBtn.onClick.RemoveAllListeners();
            cellBtn.onClick.AddListener(() => { _tapMenu.MoveToIndex(dataIndex); });
            cellBtn.onPressDown.AddListener(() => { _tapMenu.OnPointerDown(null); });
        }
    }

}