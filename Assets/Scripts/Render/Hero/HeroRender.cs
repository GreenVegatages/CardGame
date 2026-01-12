using System;
using UnityEngine;

public class HeroRender : RenderObject
{
    public HeroData Data { get;private set; }
    public E_HeroTeam Team { get;private set; }
    
    private Animator _animator;

    private void Awake()
    {
        Initialize();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public void SetHeroData(HeroData heroData)
    {
        this.Data = heroData;
    }

    public void SetTeam(E_HeroTeam heroTeam)
    {
        this.Team = heroTeam;
    }

    public void Initialize()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void PlayAnimation(string actionName)
    {
        _animator.SetTrigger(actionName);
    }
}