using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class UnitMono : MonoBehaviour
{
    public float speed = 0f;
    public Transform textRt;

    private GameObject dizzyObj;
    void Start()
    {
        speed = 0f;
        textRt = new GameObject("3dText").transform;
        textRt.SetParent(transform);
        textRt.localPosition = new Vector3(0, 2.43f, 0.23f);
        textRt.localRotation = Quaternion.Euler(0, -90f,0f);
        textRt.localScale = Vector3.one * 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* speed, Space.World);
    }

    private Timer _timer;
    public void PlayStateText(string path,float time)
    {
        if (_timer != null)
        {
            _timer.Pause();
            Timer.Cancel(_timer);
        }
        if (dizzyObj == null)
        {
            dizzyObj = PrefabUtils.Instance(path);
        }
        dizzyObj.SetActive(true);
        TransformUtils.TransformLocalNormalize(dizzyObj, textRt);
        _timer = this.AttachTimer(time, () => { dizzyObj.SetActive(false);});
    }
}
