public enum E_LogicObjectState
{
    Survival,
    Death,
    SurvivalWaitting
}
public class LogicObject : LogicBehaviour
{
    public E_LogicObjectState LogicState = E_LogicObjectState.Survival;
    
    public override void OnDestroy()
    {
        base.OnDestroy();
#if CLIENT_LOGIC
        RenderObj.OnRelease();
#endif
        
    }

    public void SetRenderObject(RenderObject renderObject)
    {
        LogicState = E_LogicObjectState.Survival;
        this.RenderObj = renderObject;
        LogicPosition = new VInt3(renderObject.transform.position);
    }
}