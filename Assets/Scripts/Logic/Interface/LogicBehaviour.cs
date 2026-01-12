/// <summary>
/// 负责基础的属性和接口，不负责实现
/// </summary>
public class LogicBehaviour
{
    /// <summary>
    /// 渲染对象
    /// </summary>
    public RenderObject RenderObj { get;protected set; }
    
    /// <summary>
    /// 逻辑位置
    /// </summary>
    public VInt3  LogicPosition { get; set; }
   
    
    public virtual void OnCreate()
    {
    }
    public virtual void OnLogicUpdate()
    {
    }

    public virtual void OnDestroy()
    {
        
    }
}