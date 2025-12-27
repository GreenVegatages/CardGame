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
        _battleWorld = new BattleWorld();
        _battleWorld.OnCreateWorld();
    }
}
