using System;
using System.Collections.Generic;


public class TimerManager : Singleton<TimerManager>,ILogicBehaviour
{
    private List<Timer> _timersList = new ();


    public void Delay(VInt delay, Action callback, int loop = 1)
    {
#if CLIENT_LOGIC
        Timer timer = new Timer(delay, callback, loop);
        _timersList.Add(timer);
#else
        for (int i = 0; i < loop; i++)
        {
            callback?.(); 
        }
#endif
    }
    
    public void OnCreate()
    {
        
    }

    public void OnLogicFrameUpdate()
    {
#if CLIENT_LOGIC
        for (int i = 0; i < _timersList.Count; i++)
        {
            _timersList[i].OnLogicFrameUpdate();
        }

        for (int i = _timersList.Count - 1; i >= 0; i--)
        {
            var timer = _timersList[i];
            if (timer.isFinished)
            {
                _timersList.RemoveAt(i);
            }
        }
#endif
    }

    public void OnDestroy()
    {
        
    }
    
}
