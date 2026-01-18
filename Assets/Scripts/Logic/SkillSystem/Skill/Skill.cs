using System;

public class Skill
{
    public int SkillId { get;private set; }
    public HeroLoigc SKillOwner { get;private set; }
    public bool IsNormalAtk { get;private set; }
    public E_SkillState SkillState { get;private set; }
    
    public SkillConfig SkillConfig { get;private set; }
    public Skill(int skillId, LogicObject skillOwner, bool isNormalAtk)
    {
        this.SkillId = skillId;
        this.SKillOwner = skillOwner as HeroLoigc;
        this.IsNormalAtk = isNormalAtk;
        this.SkillConfig = SkillConfigCenter.LoadSkillConfig(skillId);
    }
    
    private HeroLoigc _skillTarget;
    
    
    public void ReleaseSkill()
    {
        SkillShakeBefore();
        PlaySkillAnimation();
        if (SkillConfig.skillType is E_SkillType.MoveToAttack or E_SkillType.MoveToCenter or E_SkillType.MoveToRootCenter)
        {
            MoveToTarget(SkillTrigger);
        }
        else if(SkillConfig.skillType is E_SkillType.Ballistic)
        {
            
        }else if (SkillConfig.skillType is E_SkillType.Chant)
        {
            
        }
        
    }

    public void SkillShakeBefore()
    {
        this.SkillState = E_SkillState.ShakeBefore;
    }
    
    public void PlaySkillAnimation()
    {
        SKillOwner.PlayAnimation(SkillConfig.skillAnimation);
    }
    
    public void MoveToTarget(Action onMoveComplete = null)
    {
        VInt3 targetPos = VInt3.zero;
        if (SkillConfig.skillType == E_SkillType.MoveToAttack)
        {
            _skillTarget = BattleRule.GetNormalAttackTarget(
                WorldManager.BattleWorld.heroLogicCtrl.GetHeroListByTeam(SKillOwner,
                    (E_HeroTeam)SkillConfig.targetType),SKillOwner.Data.seatid);
            targetPos = _skillTarget.LogicPosition;
            VInt z = SKillOwner.Team == E_HeroTeam.Enemy ? new VInt(-3).Int : new VInt(3).Int;
            targetPos.z -= z.RawInt;
        }
        ActionManager.Instance.RunAction(new MoveToAction(SKillOwner,targetPos,
            SkillConfig.skillShakeBeforeTimeMs,onMoveComplete));
       
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
        this.SkillState = E_SkillState.ShakeAfter;
    }
    public void MoveBack()
    {
        
    }
    public void SkillEnd()
    {
        
    }
    
}