using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Table;

public class TestAI : MonoBehaviour
{
    public int id = 150000;
    public bool isAI = true;
    [HideInInspector]
    public Animator animator;
    public HeroAttr heroAttr;
    public AnimData animData;
    public AIAgent aIAgent;
    [HideInInspector]
    public UnitMono unitMono;

    private Action _animProgressCallBack;
    private Action _animEndCallBack;
    private float _progressTime;
    private float _endTime;


    private void Awake()
    {
        unitMono = transform.parent.GetComponent<UnitMono>();
        animator = GetComponent<Animator>();
        animData = new AnimData(animator,this);
    }

    void Start()
    {
        excel_character character = ExcelConfig.Get_excel_character(id);
        heroAttr = new HeroAttr(character);
        var ai = AIUtils.GetExternalBehavior(isAI?character.enemyPath : character.heroPath);
        aIAgent = new AIAgent(gameObject, ai);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">动画名称</param>
    /// <param name="callBack">动画完成回调</param>
    /// <param name="normalBackTime">回调提前进度（0-1）</param>
    /// <param name="AnimEpiphanyNormalizedTime">卡顿点（0-1）</param>
    /// <param name="keepEpiphanyTime">卡顿时长</param>
    public void Play(string animName,float speed = 1f,Action bpCallBack = null,float backProgress = 1f,Action endCallBack = null,bool isLoop = false)
    {
        int state = 0;
        switch (animName)
        {
            case Const_BattleAnim_Name.anim_birth:
                state = Const_BattleAnim_State.birth;
            break;
            case Const_BattleAnim_Name.anim_idle:
                state = Const_BattleAnim_State.idle;
            break;
            case Const_BattleAnim_Name.anim_dead:
                state = Const_BattleAnim_State.dead;
            break;
            case Const_BattleAnim_Name.anim_run:
                state = Const_BattleAnim_State.run;
            break;
            case Const_BattleAnim_Name.anim_attack1:
                state = Const_BattleAnim_State.attack1;
            break;
            case Const_BattleAnim_Name.anim_attack2:
                state = Const_BattleAnim_State.attack2;
            break;
            case Const_BattleAnim_Name.anim_dizzy:
                state = Const_BattleAnim_State.dizzy;
            break;
        }
        if(animator.GetInteger("name")== state)
        {
            return;
        }
        animator.SetInteger("name",state);
        this.CancelInvoke();
        animator.speed = speed;
        _animProgressCallBack = bpCallBack;
        _animEndCallBack = endCallBack;
        AnimationClip anim = animData.GetAnim(animName);
        var localSpeed = 1f / animator.speed;
        _progressTime = anim.length * localSpeed * backProgress;
        _endTime = anim.length * localSpeed;
        if (isLoop)
        {
            this.InvokeRepeating("AnimCallStart", 0, _endTime);
        }
        else
        {
            this.Invoke("AnimCallStart", 0);
        }
    }

    public float GetAnimLength(string animName,float speed)
    {
        AnimationClip anim = animData.GetAnim(animName);
        var localSpeed = 1f / speed;
        return anim.length * localSpeed;
    }

    public void BeHurt(HitData hitData)
    {

        bool isDead = heroAttr.SetHp(hitData.hurt);
        if (!isAI)
        {
            Debug.Log(heroAttr.hp);
        }
        if (isDead)
        {
            aIAgent.SendEvent(Const_BattleEvent.event_fight_dead);
            return;
        }
        if (hitData.isDizzy)
        {
            aIAgent.SendEvent(Const_BattleEvent.event_fight_dizzy);
        }
    }

    public void Clear()
    {
        gameObject.SetActive(false);
    }

    #region invoke
    void AnimCallStart()
    {
        this.Invoke("AnimCallBack", _progressTime);
        this.Invoke("AnimCallBack2", _endTime);
    }

    void AnimCallBack()
    {
        _animProgressCallBack?.Invoke();
    }
    
    void AnimCallBack2()
    {
        _animEndCallBack?.Invoke();
    }
    #endregion


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
