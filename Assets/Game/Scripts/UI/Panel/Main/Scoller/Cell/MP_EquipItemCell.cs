using EnhancedUI.EnhancedScroller;
using System.Collections.Generic;
using UnityEngine.UI;

public partial class MP_EquipItemCell : EnhancedScrollerCellView
{
    private List<PropItem> _propItems;

    public override void RefreshCellView()
    {
        AutoInit();
        Init();
    }

    private void Init()
    {
        if (_propItems == null)
        {
            _propItems = new List<PropItem>();
        }
    }
}