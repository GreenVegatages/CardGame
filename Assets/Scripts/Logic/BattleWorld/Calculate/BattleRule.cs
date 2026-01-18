using System.Collections.Generic;

public class BattleRule
{
    public static HeroLoigc GetNormalAttackTarget(List<HeroLoigc> heroLoigcs, int heroSeatid)
    {
        if (heroLoigcs[0].LogicState == E_LogicObjectState.Survival)
        {
            return  heroLoigcs[0];
        }
        var attackOrder = GetAttackSeatArr(heroSeatid);
        foreach (var seatId in attackOrder)
        {
            var hero = heroLoigcs[seatId];
            if (hero.LogicState == E_LogicObjectState.Survival)
                return hero;
            
        }
        return null;
    }

    public static int[] GetAttackSeatArr(int startSeatId)
    {
        if (startSeatId == 0)
        {
            return new int[] {0,1,2,3,4 };
        }
        else if (startSeatId is 1 or 4)
        {
            return new int[] {1,2,4,3,0};
        }else if(startSeatId is 2 or 5)
        {
            return new int[] {2,1,3,4,0};
        }

        return null;
    }
}