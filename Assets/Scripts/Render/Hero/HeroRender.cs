using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroRender : RenderObject
{
    
    public HeroData Data { get;private set; }
    public E_HeroTeam Team { get;private set; }
    
    private Animator _animator;
    private HeroHUDComponent _heroHUDComponent;
    private Transform _hudTransform;

    private void Awake()
    {
        Initialize();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if (_heroHUDComponent != null&& LogicObj!=null&& _hudTransform!=null)
        {
            _heroHUDComponent.transform.localPosition = WorldToCanvas(_hudTransform.position);
        }
    }
    public void SetHeroData(HeroData heroData)
    {
        this.Data = heroData;
    }

    public void SetTeam(E_HeroTeam heroTeam)
    {
        this.Team = heroTeam;
        _heroHUDComponent = ResManager.Instance.LoadPrefab<HeroHUDComponent>(AssetPathConfig.HUD+
                                                                             (heroTeam == E_HeroTeam.Enemy
                                                                                 ? "HPObjectEnemy"
                                                                                 : "HPObjectSelf"),BattleWorldNodes.Instance.HUD_Root);
        _heroHUDComponent.Init(this);
    }

    public void Initialize()
    {
        _animator = GetComponentInChildren<Animator>();
        _hudTransform = transform.GetChild(1);
    }
    public void PlayAnimation(string actionName)
    {
        _animator.SetTrigger(actionName);
    }

    public void UpdateHP_HUD(int damage,float rate)
    {
      var text=  ResManager.Instance.LoadPrefab(AssetPathConfig.HUD + (damage > 0 ? "DamageText" : "RestoreHPText"),BattleWorldNodes.Instance.HUD_Root,resetPosition:true);
      var localPosition = WorldToCanvas(transform.position);
      text.transform.localPosition = localPosition + new Vector3(0,10,0);
      text.GetComponent<Text>().text = (damage > 0 ? "-" : "+")+ Mathf.Abs(damage).ToString();
      
      text.transform.DOLocalMoveY(text.transform.localPosition.y+50f,1f);
      text.GetComponent<CanvasGroup>().DOFade(0, 0.5f).SetDelay(1.2f);
      Destroy(text,3f);
      
      _heroHUDComponent.UpdateHPSlider(rate);
    }

    public Vector3 WorldToCanvas(Vector3 worldPosition)
    {
        Vector2 targetPosition ;
        Vector3 screenPoint=  RectTransformUtility.WorldToScreenPoint(BattleWorldNodes.Instance.Camera3D, worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(BattleWorldNodes.Instance.HUD_Root as RectTransform, screenPoint, BattleWorldNodes.Instance.UICamera,out  targetPosition);
        return targetPosition;
    }
}