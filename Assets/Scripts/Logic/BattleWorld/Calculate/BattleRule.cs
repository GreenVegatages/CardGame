using System;
using System.Collections.Generic;

public class BattleRule
{
    
    public static List<HeroLoigc> GetHeroSurvivalList(List<HeroLoigc> heroList)
    {
        List<HeroLoigc> survivalList = new List<HeroLoigc>();
        foreach (var hero in heroList)
        {
            if (hero.LogicState == E_LogicObjectState.Survival)
            {
                survivalList.Add(hero);
            }
        }
        return survivalList;
    }
    public static List<HeroLoigc> GetFrontHeroList(List<HeroLoigc> heroList)
    {
        List<HeroLoigc> backRowHeroList = new List<HeroLoigc>();
        backRowHeroList.Add(heroList[0]);
        backRowHeroList.Add(heroList[1]);
        backRowHeroList.Add(heroList[2]);
        return backRowHeroList;
    }
    public static List<HeroLoigc> GetBackRowHeroList(List<HeroLoigc> heroList)
    {
        List<HeroLoigc> backRowHeroList = new List<HeroLoigc>();
        backRowHeroList.Add(heroList[^1]);
        backRowHeroList.Add(heroList[^2]);
        return backRowHeroList;
    }
    public static List<HeroLoigc> GetAttackListByAttackType(E_SkillAttackType attackType,List<HeroLoigc> heroList ,int attackSeatId)
    {
        List<HeroLoigc> targetList = new List<HeroLoigc>();
        switch (attackType)
        {
            case E_SkillAttackType.SingleTarget:
                var target = GetNormalAttackTarget(heroList, attackSeatId);
                targetList.Add(target);
                break;
            
            case E_SkillAttackType.All:
               return GetHeroSurvivalList(heroList);

            case E_SkillAttackType.BackRow:
               targetList = GetBackRowHeroList(heroList);
               if (targetList.Count == 0)
               {
                   targetList = GetFrontHeroList(heroList);
               }
               return  GetHeroSurvivalList(targetList);

            case E_SkillAttackType.FrontRow:
                targetList = GetFrontHeroList(heroList);
                targetList = GetHeroSurvivalList(targetList);
                if (targetList.Count == 0)
                {
                    targetList = GetBackRowHeroList(heroList);
                }
                return GetHeroSurvivalList(targetList);

            case E_SkillAttackType.SamColumn:
                int[] targetArr = GetAttackSeatArr(attackSeatId);
                targetList.Add(heroList[targetArr[0]]);
                targetList.Add(heroList[targetArr[1]]);
                targetList = GetHeroSurvivalList(heroList);
                if (targetList.Count == 0)
                {
                    targetList.Add(heroList[targetArr[2]]);
                    targetList.Add(heroList[targetArr[3]]);
                    targetList = GetHeroSurvivalList(heroList);
                    if (targetList.Count == 0)
                    {
                        targetList.Add(heroList[targetArr[4]]);
                    }
                }
                return targetList;
        }
        
        
        return targetList;
    }
    
    
    
    
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