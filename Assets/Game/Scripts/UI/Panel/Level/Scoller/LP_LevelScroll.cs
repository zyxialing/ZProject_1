using EnhancedUI.EnhancedScroller;
using UnityEngine;
using System;

[RequireComponent(typeof(EnhancedScroller))]
public partial class LP_LevelScroll : MonoBehaviour, IEnhancedScrollerDelegate
{
    [Inject] public ILevelMgr _levelMgr { get; set; }
    public void Init()
    {
     
    }
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
       EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
        cellView.dataIndex = dataIndex;
        cellView.cellIndex = cellIndex;
        cellView.scroller = scroller;
        cellView.InitData(this);
        cellView.RefreshCellView();
        return cellView;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return cellRectTransform.rect.height;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return _levelMgr.GetAllLevelData().Count;
    }

}
