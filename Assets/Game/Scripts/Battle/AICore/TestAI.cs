using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TestAI : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    public HeroAttr heroAttr;
    public AnimData animData;

    private Action _animCallBack;
    private float _keepEpiphanyTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        heroAttr = new HeroAttr();
        animData = new AnimData(animator,this);
    }

    void Start()
    {
        AIUtils.SafeGetExternalBehavior("Assets/Game/AssetDynamic/AI/ai1001", (ai) =>
        {
            AIAgent aIAgent = new AIAgent(gameObject, ai);
        });
    }

    public void Play(string name, Action callBack = null , float AnimEpiphanyNormalizedTime = -1,float keepEpiphanyTime = 0)
    {
        _animCallBack = callBack;
        _keepEpiphanyTime = keepEpiphanyTime;
        animator.Play(name,0,0);
        AnimationClip anim = animData.GetAnim(name);
        if (AnimEpiphanyNormalizedTime > 0)
        {
            this.Invoke("AnimEpiphany", anim.length * AnimEpiphanyNormalizedTime);
        }
        this.Invoke("AnimCallBack", anim.length + keepEpiphanyTime);
    }

    public void AnimCallBack()
    {
        _animCallBack?.Invoke();
    }

    public void AnimEpiphany()
    {
        animator.speed = 0;
        Invoke("ResetSpeed", _keepEpiphanyTime);
    }

    public void ResetSpeed()
    {
        animator.speed = 1;
    }




}

public class HeroAttr
{
    public int Hp = 100;
    public bool IsEnterGame = false;
}

public class AnimData
{
    public MonoBehaviour aiMono;
    public Animator animator;
    public Dictionary<string, AnimationClip> animMap;
    public AnimData(Animator animator,MonoBehaviour aiMono)
    {
        this.aiMono = aiMono;
        this.animator = animator;
        var anims = this.animator.runtimeAnimatorController.animationClips;
        animMap = new Dictionary<string, AnimationClip>();
        foreach (var item in anims)
        {
            if (!animMap.ContainsKey(item.name))
            {
                animMap.Add(item.name, item);
            }
            else
            {
                Debug.LogError("重复动作名称:"+ item.name);
            }
        }
    }

    public AnimationClip GetAnim(string name)
    {
        if (animMap.ContainsKey(name))
        {
            return animMap[name];
        }
        Debug.LogError(name + "为空");
        return null;
    }
}
