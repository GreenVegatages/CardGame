using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 英雄逻辑控制类
/// </summary>
public class HeroLogicCtrl : ILogicBehaviour
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
    
    public void OnCreate(List<HeroData> player_Data, List<HeroData> enemy_Data)
    {
#if CLIENT_LOGIC
        //创建玩家阵容
        CreateHerosByList(player_Data,BattleWorldNodes.Instance.player_Hero_Roots);
        //创建敌人阵容
        CreateHerosByList(enemy_Data,BattleWorldNodes.Instance.enemy_Hero_Roots);
#else
        //服务端不需要渲染逻辑

        //创建玩家阵容
        CreateHerosByList(player_Data,null);
        //创建敌人阵容
        CreateHerosByList(enemy_Data,null);
#endif
    }

    /// <summary>
    /// 通过数据列表加载英雄
    /// </summary>
    /// <param name="data"></param>
    /// <param name="root">阵容根位置</param>
    public void CreateHerosByList(List<HeroData> data,Transform[] root)
    {
        for (int i = 0; i < data.Count; i++)
        {
           var prefab = ResManager.Instance.LoadPrefab("Prefabs/Hero/" + data[i].id,root[data[i].seatid]
           ,true,true,false);
        }
    }
    
    
}
