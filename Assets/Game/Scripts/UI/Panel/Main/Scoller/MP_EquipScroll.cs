using EnhancedUI.EnhancedScroller;
using UnityEngine;
using System;

[RequireComponent(typeof(EnhancedScroller))]
public partial class MP_EquipScroll : MonoBehaviour, IEnhancedScrollerDelegate
{
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
       EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
        cellView.dataIndex = dataIndex;
        cellView.cellIndex = cellIndex;
        cellView.RefreshCellView();
        return cellView;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return cellRectTransform.rect.height;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return 6;
    }

}
