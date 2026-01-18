using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillConfig", menuName = "ScriptableObjects/SkillConfig", order = 0)]
public class SkillConfig : ScriptableObject
{
        [LabelText("技能图标"),LabelWidth(0.1f),PreviewField(70, ObjectFieldAlignment.Left)]
        public Sprite Icon;
        
        [LabelText("技能Id")]
        public int skillId;
        
        [LabelText("技能名称")]
        public string skillName;
        
        [LabelText("技能释放的怒气值"),ProgressBar(0,300,0.8f,0.2f)]
        public int needRageValue = 100;
        
        [LabelText("技能前摇时间(ms)")]
        public int skillShakeBeforeTimeMs;
        
        [LabelText("技能持续时间(ms)")]
        public int skillDurationTimeMs;
        
        [LabelText("技能后摇时间(ms)")]
        public int skillShakeAfterTimeMs;
        
        [LabelText("技能类型")]
        public E_SkillType skillType;
        
        [LabelText("目标类型")]
        public E_TargetType targetType;
        
        [LabelText("技能攻击类型")]
        public E_SkillAttackType skillAttackType;
        
        [LabelText("伤害类型")]
        public E_DamageType damageType;
        
        [LabelText("伤害百分比"),ProgressBar(0,500,0.8f,0.2f)]
        [ShowIf("ShowDamagePercent")]
        public int damagePercent;
        
        [LabelText("子弹预制体")]
        [ShowIf("skillType",E_SkillType.Ballistic)]
        public string bullet;
        
        
        [LabelText("技能动画")]
        public string skillAnimation;
        
        [LabelText("技能音效")]
        public AudioClip skillSound;
        
        [LabelText("技能特效")]
        public string skillEffect;
        
        [LabelText("受击特效")]
        public string hitEffect;
        
        [LabelText("附加buff")]
        public int[]addedBuffs;
        
        [LabelText("技能描述"),MultiLineProperty(3)]
        public string skillDes;

        
        private bool ShowDamagePercent()
        {
                switch (damageType)
                {
                        case E_DamageType.AtkPercentAge:
                        case E_DamageType.HpPercentage:
                                return true;    
                }
                return false;
        }
}