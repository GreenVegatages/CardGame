using System.Collections.Generic;
using UnityEngine;

public class WorldManager 
{
    private static BattleWorld _battleWorld;
    
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
        _battleWorld?.OnDestroyWorld();
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    public static void OnUpdate()
    {
        _battleWorld?.OnUpdate();
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
        _battleWorld = new BattleWorld();
        _battleWorld.OnCreateWorld(player_Data,enemy_Data);
    }
}
