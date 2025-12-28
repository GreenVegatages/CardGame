using UnityEngine;
/// <summary>
/// 打印类
/// </summary>
public static class Debuger
{
    public static void Log(object message)
    {
#if CLIENT_LOGIC
        Debug.Log(message);
#else
        Console.WriteLine(message);
#endif
    }

    public static void LogError(object message)
    {
#if CLIENT_LOGIC
        Debug.LogError(message);
#else
        Console.WriteLine(message);
#endif
    }
}
