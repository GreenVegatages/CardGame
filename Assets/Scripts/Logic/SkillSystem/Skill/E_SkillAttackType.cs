using Sirenix.OdinInspector;

public enum E_SkillAttackType
{
      
      [LabelText("单体")]SingleTarget,  
      [LabelText("全体")]All,
      [LabelText("后排")]BackRow,
      [LabelText("前排")]FrontRow,
      [LabelText("同行")]SamColumn
}