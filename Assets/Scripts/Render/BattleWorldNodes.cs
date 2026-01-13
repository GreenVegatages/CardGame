using UnityEngine;
/// <summary>
/// 获取世界节点信息类
/// </summary>
public class BattleWorldNodes : SingletonMono<BattleWorldNodes>
{
        /// <summary>
        /// 玩家阵容世界根位置
        /// </summary>
        public Transform[] player_Hero_Roots;

        /// <summary>
        /// 敌人阵容世界根位置
        /// </summary>
        public Transform[] enemy_Hero_Roots;

        public Transform HUD_Root;
        
        public Camera Camera3D;
        public Camera UICamera;
}