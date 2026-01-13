public class HeroLoigc : LogicObject
{
    protected VInt hp;
    protected VInt atk;
    protected VInt def;
    protected VInt agl;
    protected VInt rage;
    public VInt Hp
    {
        get { return hp; }
    }
    
    public VInt MaxHp
    {
        get ;
        protected set;
    }
    
    public VInt ATK
    {
        get { return atk; }
    }
    public VInt DEF
    {
        get { return def; }
    }
    public VInt AGL
    {
        get { return agl; }
    }
    public VInt RAGE
    {
        get { return rage; }
    }
    
    public VInt MaxRAGE
    {
        get ;
        protected set;
    }

    
    public void DamageHp(VInt damagehp)
    {
        if(damagehp == 0)return;
        hp -= damagehp;
        if (hp <= 0)
        {
            
            hp = 0;
            Death();
            return;
        }
        PlayAnimation("OnHit");
        
    }

    public void Death()
    {
        
    }
    
    
    
    
    
    public HeroData Data { get;private set; }
    public E_HeroTeam Team { get;private set; }
    public HeroRender HeroRender { get;private set; }
    
    public HeroLoigc(HeroData data,E_HeroTeam team)
    {
        this.Data = data;
        this.Team = team;
        hp = data.hp;
        MaxHp = data.hp;
        atk = data.atk;
        def = data.def;
        agl = data.agl;
        rage = 50;
        MaxRAGE = data.maxRage;
        
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnCreate()
    {
        base.OnCreate();
        HeroRender = RenderObj as  HeroRender;
        Debuger.Log(RenderObj.gameObject.name);
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
    }

    public void PlayAnimation(string actionName)
    {
#if RENDER_LOGIC
        HeroRender.PlayAnimation(actionName);
#endif
        
    }
}