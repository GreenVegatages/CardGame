public class HeroLoigc : LogicObject
{
    public HeroData Data { get;private set; }
    public E_HeroTeam Team { get;private set; }
    
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
        Debuger.Log(RenderObj.gameObject.name);
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
    }
}