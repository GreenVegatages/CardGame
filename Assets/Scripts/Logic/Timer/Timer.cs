
using System;

public class Timer : ILogicBehaviour
{
    public bool isFinished;
    public VInt delay;
    public int loop;
    public Action callback;
    private VInt _acctime;
    
    public void OnCreate()
    {
       
    }

    public void OnLogicFrameUpdate()
    {
        _acctime += LogicFrameSyncConfig.LogicFrameIntervalMs;
        if (_acctime >= delay && loop > 0)
        {
            callback?.Invoke();
            _acctime = 0;
            loop--;
            if (loop == 0)
            {
                isFinished = true;
            }
        }
    }

    public void OnDestroy()
    {
        
    }

    public Timer(VInt delay, Action callback, int loop )
    {
        _acctime = 0;
        this.delay = delay;
        this.callback = callback;
        this.loop = loop;
    }
}