using EnhancedUI.EnhancedScroller;
using UnityEngine;
using System;
using System.Collections;
using ZFramework;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EnhancedScroller))]
public partial class MP_TapMenu : MonoBehaviour, IEnhancedScrollerDelegate
{
    private RectTransform scrollRectTransform;
    private Coroutine _coroutine;
    private float[] IndexPos;
    private bool isDraging = false;
    private bool isMoving = false;
    public void Init()
    {
        scroller.ReloadData();
        scrollRectTransform = scroller.gameObject.GetComponent<RectTransform>();
        IndexPos = new float[6];
        float width = ((scroller.Container.rect.width - scroller.padding.left - scroller.padding.right) - scroller.spacing / 2f)/(6-1);
        for (int i = 0; i < 6; i++)
        {
            IndexPos[i] = i * width;
        }
        scroller.onPointerDown = OnPointerDown;
        scroller.onPointerUp = OnPointerUp;
        scroller.scrollOnBeginDrag = OnBeginDrag;
        scroller.scrollOnEndDrag = OnEndDrag;
    }

    public void MoveToIndex(int index)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(Snap(index));
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (!isDraging)
        {
            _coroutine = StartCoroutine(Snap());
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            isMoving = false;
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        isDraging = true;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            isMoving = false;
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            isMoving = false;
        }
       _coroutine = StartCoroutine(Snap());
       isDraging = false;
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
        return 6;
    }
    #region ¶¯»­
    private IEnumerator Snap(int index = -1)
    {
        while (Mathf.Abs(scroller.LinearVelocity) > scroller.snapVelocityThreshold)
        {
            yield return null;
        }
        if (index < 0)
        {
            index = GetSnapIndex(scroller.ScrollPosition);
        }
        isMoving = true;
        scroller.LinearVelocity = 0;
        float time = 0.5f;
        float _tweenTimeLeft = 0;
        var newPosition = 0f;
        while (_tweenTimeLeft < time)
        {
            newPosition = ZMathUtil.easeInSine(scroller.ScrollPosition, IndexPos[index], (_tweenTimeLeft / time));

            // set the scroll position to the tweened position
            scroller.ScrollPosition = newPosition;

            // increase the time elapsed
            _tweenTimeLeft += Time.unscaledDeltaTime;

            yield return null;
        }
        isMoving = false;
    }

    private int GetSnapIndex(float curPos)
    {
        float dis = float.MaxValue;
        float tempDis;
        float tempPos;
        int index = 0;
        for (int i = 0; i < IndexPos.Length; i++)
        {

            tempDis = Mathf.Abs(curPos - IndexPos[i]);
            if (tempDis < dis)
            {
                dis = tempDis;
                tempPos = IndexPos[i];
                index = i;
            }
        }
        return index;
    }

    #endregion
}
