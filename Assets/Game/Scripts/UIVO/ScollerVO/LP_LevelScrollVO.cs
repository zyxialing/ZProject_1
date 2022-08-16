using EnhancedUI.EnhancedScroller;
using UnityEngine;
using System;

[RequireComponent(typeof(EnhancedScroller))]
public partial class LP_LevelScroll : MonoBehaviour, IEnhancedScrollerDelegate
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
        ServiceBinder.Instance.RegisterObj(this);
        scroller = GetComponent<EnhancedScroller>();
        rectTransform = GetComponent<RectTransform>();
        cellRectTransform = cellViewPrefab.GetComponent<RectTransform>();
        scroller.Delegate = this;
        Init();
     }
}
