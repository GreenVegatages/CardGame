using UnityEngine;

[CreateAssetMenu(fileName = "SkillConfig", menuName = "ScriptableObjects/SkillConfig", order = 0)]
public class SkillConfig : ScriptableObject
{
        public Sprite Icon;
        public int skillId;
        public string skillName;
        public int needRageValue = 100;
        public int skillShakeBeforeTimeMs;
        public int skillDurationTimeMs;
        public int skillShakeAfterTimeMs;
        
        public E_SkillType skillType;
        public E_TargetType targetType;
        public E_SkillAttackType skillAttackType;
        public E_DamageType damageType;
        public int damagePercent;
        
        //
        public string bullet;
        public string skillAnimation;
        public AudioClip skillSound;
        public string skillEffect;
        public string hitEffect;
        
        public int[]addedBuffs;
        public string skillDes;

}