using System;
using UnityEngine;

public class GameMain : MonoBehaviour
{
   
    void Start()
    {
        WorldManager.Initialize();
        WorldManager.CreateBattleWorld();
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
