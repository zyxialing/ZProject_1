using EnhancedUI.EnhancedScroller;
using UnityEngine;

[RequireComponent(typeof(EnhancedScroller))]
public class MP_ItemScroll : MonoBehaviour, IEnhancedScrollerDelegate
{
    private EnhancedScroller scroller;
    private RectTransform cellRectTransform;
    private RectTransform rectTransform;

    public EnhancedScrollerCellView cellViewPrefab;

    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
       MP_ItemCell prefab = scroller.GetCellView(cellViewPrefab) as MP_ItemCell;
       prefab.AutoInit();
       prefab.UpdateData(scroller,dataIndex,cellIndex);
        return prefab;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return cellRectTransform.rect.height;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return 6;
    }

    void Start()
    {
        scroller = GetComponent<EnhancedScroller>();
        rectTransform = GetComponent<RectTransform>();
        cellRectTransform = cellViewPrefab.GetComponent<RectTransform>();
        scroller.Delegate = this;
     }
}
