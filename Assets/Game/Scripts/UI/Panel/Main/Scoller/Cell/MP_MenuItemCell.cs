using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

public partial class MP_MenuItemCell : EnhancedScrollerCellView
{
    public override void RefreshCellView()
    {
        AutoInit();
        UIUtils.SetSprite(icon, "icon/tab" + dataIndex);
        cellBtn.onClick.RemoveAllListeners();
        cellBtn.onClick.AddListener(() => { ZLogUtil.LogError(dataIndex); });
    }
}