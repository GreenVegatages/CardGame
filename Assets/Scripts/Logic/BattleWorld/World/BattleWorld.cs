using UnityEngine;

public class BattleWorld 
{
    public HeroLogicCtrl heroLogicCtrl;
    public RoundLogicCtrl roundLogicCtrl;
    
    /// <summary>
    /// 创建世界时调用
    /// </summary>
    public void OnCreateWorld()
    {
        heroLogicCtrl = new HeroLogicCtrl();
        roundLogicCtrl = new RoundLogicCtrl();
        heroLogicCtrl.OnCreate();
        roundLogicCtrl.OnCreate();
        
    }
    public void OnUpdate()
    {
        
    }
    /// <summary>
    /// 销毁世界时调用
    /// </summary>
    public void OnDestroyWorld()
    {
        heroLogicCtrl?.OnDestroy();
        roundLogicCtrl?.OnDestroy();
    }
    
    /// <summary>
    /// 逻辑帧更新
    /// </summary>
    public void OnLogicFrameUpdate()
    {
        heroLogicCtrl?.OnLogicFrameUpdate();
        roundLogicCtrl?.OnLogicFrameUpdate();
    }
}
