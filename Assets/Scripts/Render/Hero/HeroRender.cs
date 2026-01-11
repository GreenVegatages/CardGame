public class HeroRender : RenderObject
{
    public HeroData Data { get;private set; }
    public E_HeroTeam Team { get;private set; }
    
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
}