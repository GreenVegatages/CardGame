using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
   
    void Start()
    {
        WorldManager.Initialize();
        List<HeroData> player_Data = new List<HeroData>();
        List<HeroData> enemy_Data = new List<HeroData>();
        List<int> heroIdList = new List<int>(){101,102,103,104,105,501,502,503,504,505};
        for (int i = 0; i < heroIdList.Count; i++)
        {
            var data  = new HeroData();
            data.hp = 100;
            data.id = heroIdList[i];
            if (i < 5)
            {
                data.seatid = i;
                player_Data.Add(data);
            }
            else
            {
                data.seatid= i % 5;
                enemy_Data.Add(data);
            }
           
        }
        WorldManager.CreateBattleWorld(player_Data,enemy_Data);
    }

    
    // Update is called once per frame
    void Update()
    {
        WorldManager.OnUpdate();
    }


    private void OnDestroy()
    {
        WorldManager.DestoryWorld();
    }
}
