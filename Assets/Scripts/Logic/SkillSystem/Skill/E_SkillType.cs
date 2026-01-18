using Sirenix.OdinInspector;

public enum E_SkillType
{
      [LabelText("移动型（目标位置）")]MoveToAttack,  
      [LabelText("移动型（目标阵容中心）")]MoveToRootCenter,
      [LabelText("移动型（全局中心）")]MoveToCenter,
      [LabelText("吟唱型")]Chant,
      [LabelText("弹道型")]Ballistic
}