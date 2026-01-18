using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 英雄逻辑控制类
/// </summary>
public class HeroLogicCtrl : ILogicBehaviour
{
    public List<HeroLoigc> Player_Logic_List = new List<HeroLoigc>();
    public List<HeroLoigc> Enemy_Logic_List = new List<HeroLoigc>();
    public List<HeroLoigc> Hero_Logic_List = new List<HeroLoigc>();
    
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
        CreateHerosByList(Player_Logic_List,player_Data,BattleWorldNodes.Instance.player_Hero_Roots,E_HeroTeam.Player);
        //创建敌人阵容
        CreateHerosByList(Enemy_Logic_List,enemy_Data,BattleWorldNodes.Instance.enemy_Hero_Roots,E_HeroTeam.Enemy);
#else
        //服务端不需要渲染逻辑

        //创建玩家阵容
        CreateHerosByList(Player_Logic_List,player_Data,null,E_HeroTeam.Player);
        //创建敌人阵容
        CreateHerosByList(Enemy_Logic_List,enemy_Data,null,E_HeroTeam.Enemy);

#endif
    }

    /// <summary>
    /// 通过数据列表加载英雄
    /// </summary>
    /// <param name="data"></param>
    /// <param name="root">阵容根位置</param>
    public void CreateHerosByList(List<HeroLoigc> logicList,List<HeroData> data,Transform[] root,E_HeroTeam team)
    {
        for (int i = 0; i < data.Count; i++)
        {
            var heroData = data[i]; 
            HeroLoigc heroLoigc = new HeroLoigc(heroData,team);
#if CLIENT_LOGIC
            var prefab = ResManager.Instance.LoadPrefab("Prefabs/Hero/" + data[i].id,root[data[i].seatid]
                ,true,true,false);
            var heroRender = prefab.GetComponent<HeroRender>();
            heroLoigc.SetRenderObject(heroRender);
            heroRender.SetLogicObject(heroLoigc);
            heroRender.SetHeroData(heroData);
            heroRender.SetTeam(team);
#endif
           heroLoigc.OnCreate();
           logicList.Add(heroLoigc);
           Hero_Logic_List.Add(heroLoigc);
        }
    }
    
    public List<HeroLoigc> GetHeroListByTeam(HeroLoigc attacker,E_HeroTeam attackTeam)
    {
        switch (attacker.Team)
        {

            case E_HeroTeam.Player:
                return attackTeam == E_HeroTeam.Player ? Player_Logic_List : Enemy_Logic_List;
                
            case E_HeroTeam.Enemy:
                return attackTeam == E_HeroTeam.Player ? Player_Logic_List : Enemy_Logic_List;

        }
        return null;
    }
    
}
