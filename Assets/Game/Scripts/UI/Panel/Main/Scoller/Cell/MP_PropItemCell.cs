using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;


public partial class MP_PropItemCell : EnhancedScrollerCellView
{
    [Inject]public ITestMgr testMgr { get; set; }
    public override void RefreshCellView()
    {
        AutoInit();
        testMgr.Test();
    }
}