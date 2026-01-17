public class Skill
{
    public int SkillId { get;private set; }
    public HeroLoigc SKillOwner { get;private set; }
    public bool IsNormalAtk { get;private set; }
    public Skill(int skillId, LogicObject skillOwner, bool isNormalAtk)
    {
        this.SkillId = skillId;
        this.SKillOwner = skillOwner as HeroLoigc;
        this.IsNormalAtk = isNormalAtk;
    }
    
    
    
    public void ReleaseSkill()
    {
        
    }

    public void SkillShakeBefore()
    {
        
    }
    
    public void PlaySkillAnimation()
    {
        
    }
    public void MoveToTarget()
    {
        
    }
    public void SkillTrigger()
    {
        
    }
    public void CreateSkillEffect()
    {
        
    }
    public void CauseDamage()
    {
        
    }
    public void AdditionalBuff()
    {
        
    }
    
    public void SkillShakeAfter()
    {
        
    }
    public void MoveBack()
    {
        
    }
    public void SkillEnd()
    {
        
    }
    
}