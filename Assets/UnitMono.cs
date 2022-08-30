using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class UnitMono : MonoBehaviour
{
    public float speed = 0f;
    public Transform effectTransform;

    private Dictionary<string, EffectInstance> _effectMap = new Dictionary<string, EffectInstance>();

    void Start()
    {
        speed = 0f;
        effectTransform = new GameObject("effectPos").transform;
        TransformUtils.TransformLocalNormalize(effectTransform.gameObject, transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* speed, Space.World);
    }

    internal void ShowEffect(HitData hitData)
    {
        switch (hitData.attackType)
        {
            case E_AttackType.Normal:
                break;
            case E_AttackType.Dizzy:
                ShowLoopEffect("StateText/dizzy", 3f);
                break;
        }
    }

    private void ShowLoopEffect(string path,float time)
    {
        if (_effectMap.ContainsKey(path))
        {
            EffectInstance ei = _effectMap[path];
            ei.timer.Pause();
            ei.timer.Cancel();
            TransformUtils.TransformLocalNormalize(ei.effectObj, effectTransform);
            ei.effectObj.SetActive(true);
            ei.timer = this.AttachTimer(time, () => {
                _effectMap.Remove(path);
                ZGameObjectPool.Push(path, ei.effectObj);
            });
        }
        else
        {
            GameObject effectObj = ZGameObjectPool.Pop(path, () => {
                return PrefabUtils.Instance(path);
            }); 
             TransformUtils.TransformLocalNormalize(effectObj, effectTransform);
             effectObj.SetActive(true);
             Timer _timer = this.AttachTimer(time, () => {
                 ZGameObjectPool.Push(path, effectObj);
             });
             _effectMap.Add(path, new EffectInstance(_timer, effectObj));
        }
    }


    private void ShowEffect(string path,float destroyTime)
    {
        GameObject effectObj = ZGameObjectPool.Pop(path, () => {
            return PrefabUtils.Instance(path);
        });
        TransformUtils.TransformLocalNormalize(effectObj, effectTransform);
        effectObj.SetActive(true);
        Timer _timer = this.AttachTimer(destroyTime, () => {
            ZGameObjectPool.Push(path, effectObj);
        });
    }
}

public class EffectInstance
{
    public Timer timer;
    public GameObject effectObj;

    public EffectInstance(Timer timer,GameObject effectObj)
    {
        this.timer = timer;
        this.effectObj = effectObj;
    }
}
