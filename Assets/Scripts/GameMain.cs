using System;
using UnityEngine;

public class GameMain : MonoBehaviour
{
   
    void Start()
    {
        WorldManager.Initialize();
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
