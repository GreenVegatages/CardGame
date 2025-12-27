using UnityEngine;

public class BattleWorld 
{
    public HeroLogicCtrl heroLogicCtrl;
    public RoundLogicCtrl roundLogicCtrl;

    /// <summary>
    /// 逻辑帧累计运行时间
    /// </summary>
    private float _accLogicRunTime;
    
    /// <summary>
    /// 下一个逻辑帧开始时间
    /// </summary>
    private float _nextLogicFrameTime;
    
    /// <summary>
    /// 动画插值时间
    /// </summary>
    private float _deltaTime;
    
    
    
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
        //客户端需要正常进行战斗
#if CLIENT_LOGIC 
        //逻辑帧运行时间累加
        _accLogicRunTime += Time.deltaTime;
        //更新逻辑帧，控制帧数并进行追帧
        while (_accLogicRunTime >= _nextLogicFrameTime)
        {
            //更新逻辑帧
            OnLogicFrameUpdate();
            //计算下一个逻辑帧的开始时间
            _nextLogicFrameTime += LogicFrameSyncConfig.LogicFrameInterval;
            //逻辑帧id自增
            LogicFrameSyncConfig.LogicFrameId++;
            Debug.Log("LogicFrameId: " + LogicFrameSyncConfig.LogicFrameId);
        }
        //计算帧间隔之间的插值
        _deltaTime = (_accLogicRunTime + LogicFrameSyncConfig.LogicFrameInterval - _nextLogicFrameTime) /
                     LogicFrameSyncConfig.LogicFrameInterval;
        
#else
        //服务端直接进行战斗计算，服务端不需要渲染
        OnLogicFrameUpdate();
#endif 
        

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
