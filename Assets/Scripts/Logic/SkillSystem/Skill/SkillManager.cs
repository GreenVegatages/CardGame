using UnityEngine;

public class SkillManager: Singleton<SkillManager>,ILogicBehaviour
{
    public void OnCreate()
    {
        
    }

    public void OnLogicFrameUpdate()
    {
        
    }

    public void OnDestroy()
    {
        
    }
    
    public Skill ReleaseSkill(int skillId, LogicObject skillOwner, bool isNormalAtk)
    {
        Skill skill = new Skill(skillId, skillOwner, isNormalAtk);
        skill.ReleaseSkill();
        return skill;
    }
}
