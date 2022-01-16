using EnhancedUI.EnhancedScroller;
using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(EnhancedScroller))]
public partial class MP_PropScroll : MonoBehaviour, IEnhancedScrollerDelegate
{
    [Inject] public IPropMgr propMgr { get; set; }
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
        List<PropData> propDataList = propMgr.GetAllPropData();
        int count = Mathf.CeilToInt(propDataList.Count / 5f);
        return count;
    }

}
