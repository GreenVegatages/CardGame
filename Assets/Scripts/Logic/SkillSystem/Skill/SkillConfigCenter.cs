public class SkillConfigCenter
{
        public static SkillConfig LoadSkillConfig(int skillId)
        {
            return ResManager.Instance.LoadAsset<SkillConfig>(AssetPathConfig.SKILLCONDIG+skillId);
        }
}