using System.Collections.Generic;
using UnityEngine;

public class WorldManager 
{
    public static BattleWorld BattleWorld { get;private set; }
    
    /// <summary>
    /// 初始化
    /// </summary>
    public static void Initialize()
    {
        
    }
    
    /// <summary>
    /// 销毁世界
    /// </summary>
    public static void DestoryWorld()
    {
        BattleWorld?.OnDestroyWorld();
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    public static void OnUpdate()
    {
        BattleWorld?.OnUpdate();
    }
    
    
    
    /// <summary>
    /// 创建战斗世界
    /// </summary>
    public static void CreateBattleWorld()
    {

    }
    /// <summary>
    /// 创建战斗世界
    /// </summary>
    /// <param name="player_Data">玩家阵容数据</param>
    /// <param name="enemy_Data">敌人阵容数据</param>
    public static void CreateBattleWorld(List<HeroData> player_Data,List<HeroData> enemy_Data)
    {
        BattleWorld = new BattleWorld();
        BattleWorld.OnCreateWorld(player_Data,enemy_Data);
    }
}
