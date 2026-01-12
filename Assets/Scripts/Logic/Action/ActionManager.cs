

using System.Collections.Generic;

public class ActionManager : Singleton<ActionManager>,ILogicBehaviour
{
    public void OnCreate()
    {
        
    }

    public void OnLogicFrameUpdate()
    {
        for (int i = 0; i < _actionList.Count; i++)
        {
            var action = _actionList[i];
            action.OnLogicFrameUpdate();
        }

        for (int i = _actionList.Count - 1; i >= 0; i--)
        {
            var action = _actionList[i];
            if (action.IsFinished)
            {
                _actionList.RemoveAt(i);
            }
        }
    }

    public void OnDestroy()
    {
        
    }
    
    private List<ActionBase> _actionList = new List<ActionBase>();
    
    public void RunAction(ActionBase actionBase)
    {
#if CLIENT_LOGIC
        _actionList.Add(actionBase);
#else
         OnLogicFrameUpdate();
#endif
    }
}
