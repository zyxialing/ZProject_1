using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    public Animator animator;
    public HeroAttr heroAttr;
    public AnimData animData;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        heroAttr = new HeroAttr();
        animData = new AnimData(animator);
    }

    void Start()
    {
        AIUtils.SafeGetExternalBehavior("Assets/Game/AssetDynamic/AI/ai1001", (ai) =>
        {
            AIAgent aIAgent = new AIAgent(gameObject, ai);
        });
    }


    public void anim_attack1CallBack()
    {
        animator.Play(Const_BattleAnim.anim_attack1, 0, 0);
    }
    

    public void anim_attack2CallBack()
    {
        animator.Play(Const_BattleAnim.anim_attack2, 0, 0);
    }

    public void anim_idleCallBack()
    {

    }
    public void anim_deadCallBack()
    {

    }
}

public class HeroAttr
{
    public int Hp = 100;
    public bool IsEnterGame = false;
}

public class AnimData
{
    public Animator animator;
    public Dictionary<string, AnimationClip> animMap;
    public AnimData(Animator animator)
    {
        this.animator = animator;
        var anims = this.animator.runtimeAnimatorController.animationClips;
        animMap = new Dictionary<string, AnimationClip>();
        foreach (var item in anims)
        {
            if (!animMap.ContainsKey(item.name))
            {
                animMap.Add(item.name, item);
                SetOnCompleted(item.name);
            }
            else
            {
                Debug.LogError("重复动作名称:"+ item.name);
            }
        }
    }

    public void SetOnCompleted(string animName)
    {
        if (animMap.ContainsKey(animName))
        {
            AnimationEvent animationEvent = new AnimationEvent();
            animationEvent.time = animMap[animName].length;
            animationEvent.functionName = animName + "CallBack";
            animMap[animName].AddEvent(animationEvent);
        }
    }
}
