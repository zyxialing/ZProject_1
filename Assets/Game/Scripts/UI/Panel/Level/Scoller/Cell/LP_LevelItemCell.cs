using System;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

public partial class LP_LevelItemCell : EnhancedScrollerCellView
{
    [Inject] public ILevelMgr _levelMgr { get; set; }
    public override void RefreshCellView()
    {
        AutoInit();
        InitUIEvent();
        Refresh();
    }

    private void InitUIEvent()
    {
        levelBtn.onClick.RemoveAllListeners();
        levelBtn.onClick.AddListener(() => {
            var t = EventEnterLevel.AutoCreate();
            t.levelId = cellIndex;
            EventManager.Instance.Dispatch(t);
        });
    }

    private void Refresh()
    {
        LevelData levelData =  _levelMgr.GetAllLevelData()[cellIndex];
        levelTxt.text = levelData.id.ToString();
    }
}