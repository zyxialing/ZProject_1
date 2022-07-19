using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEva : EvaMono
{
    public Transform triggerTransform;
    public float singleSize = 300;
    [HideInInspector]
    public List<GameObject> mapPrefabs;
    public int curId = 0;
    private int maxCount;
    private void Start()
    {
        mapPrefabs = new List<GameObject>();
        Transform poolTrans = transform.parent.Find("Pools").transform;
        for (int i = 0; i < poolTrans.childCount; i++)
        {
            mapPrefabs.Add(poolTrans.GetChild(i).gameObject);
            mapPrefabs[i].SetActive(false);
        }
        maxCount = mapPrefabs.Count;
        if (maxCount < 2)
        {
            Debug.LogError("地图不能小于2");
        }
        GameObject obj = mapPrefabs[curId % maxCount];
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * 300 * curId;
        obj.SetActive(true);
    }

    public void Update()
    {
        var nextID = Mathf.CeilToInt(triggerTransform.position.z / 300);
        if (nextID != curId)
        {
            curId = nextID;
            GameObject obj = mapPrefabs[curId % maxCount];
            obj.transform.SetParent(transform);
            obj.transform.position = Vector3.forward * 300 * curId;
            obj.SetActive(true);
        }
    }
}
