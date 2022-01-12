using EnhancedUI.EnhancedScroller;
using UnityEngine;
using System;

[RequireComponent(typeof(EnhancedScroller))]
public partial class MP_EquipScroll : MonoBehaviour, IEnhancedScrollerDelegate
{
    [NonSerialized]
    public EnhancedScroller scroller;
    [NonSerialized]
    public RectTransform cellRectTransform;
    [NonSerialized]
    public RectTransform rectTransform;
    public EnhancedScrollerCellView cellViewPrefab;

    void Start()
    {
        scroller = GetComponent<EnhancedScroller>();
        rectTransform = GetComponent<RectTransform>();
        cellRectTransform = cellViewPrefab.GetComponent<RectTransform>();
        scroller.Delegate = this;
     }
}
