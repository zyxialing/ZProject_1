using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEva : EvaMono
{
    public List<Transform> mapTransforms;
    [Range(0, 1)]
    public float mapSpeed = 1;
    [Header("后期调整好值后可以去除该参数")]
    public float limitMapSpeed = 1;
    private int curHeadIndex;
    private int curTialIndex;
    private int mapCount;
    Transform headTF;
    Transform tialTF;
    void Start()
    {
        if (InitPosition())
        {
           
        }
    }

    private bool InitPosition()
    {
        if (mapTransforms.Count < 2)
        {
            Debug.LogError("数量不能小于2");
            return false;
        }
        else
        {
            mapCount = mapTransforms.Count;
            curHeadIndex = 0;
            curTialIndex = 1;
            headTF = mapTransforms[curHeadIndex];
            tialTF = mapTransforms[curTialIndex];
            headTF.position = Vector3.zero;
            tialTF.position = Vector3.right * 300;
            tialTF.SetParent(headTF);
            return true;
        }
    }

    public void StartMove()
    {

        headTF.DOLocalMoveX(-300, 20).SetEase(Ease.Linear).OnComplete(OnComplete);
    }

    private void FixedUpdate()
    {
        headTF.Translate(Vector3.left* limitMapSpeed * mapSpeed);
    }

    private void Update()
    {
        if (headTF.position.x <= -300f)
        {
            OnComplete();
        }
    }

    private void OnComplete()
    {
        curHeadIndex++;
        curTialIndex++;
        if (curHeadIndex >= mapCount)
        {
            curHeadIndex = 0;
        }
        if (curTialIndex >= mapCount)
        {
            curTialIndex = 0;
        }

        tialTF.SetParent(transform);
        headTF = mapTransforms[curHeadIndex];
        tialTF = mapTransforms[curTialIndex];
        headTF.position = Vector3.zero;
        tialTF.position = Vector3.right * 300;
        tialTF.SetParent(headTF);
        

    }
}
