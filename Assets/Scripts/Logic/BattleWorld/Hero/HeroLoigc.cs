public class HeroLoigc : LogicObject
{
    public HeroData Data { get;private set; }
    public E_HeroTeam Team { get;private set; }
    public HeroRender HeroRender { get;private set; }
    
    public HeroLoigc(HeroData data,E_HeroTeam team)
    {
        this.Data = data;
        this.Team = team;
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