/// <summary>
/// 英雄数据类
/// </summary>
public class HeroData
{
        /// <summary>
        /// 座位id
        /// </summary>
        public int seatid;
        
        /// <summary>
        /// 英雄id
        /// </summary>
        public int id;
        
        /// <summary>
        /// 英雄名字
        /// </summary>
        public string name;
        
        /// <summary>
        /// 
        /// </summary>
        public int type;
        
        /// <summary>
        /// 技能id数组
        /// </summary>
        public int[] skillIdArr;
        
        /// <summary>
        /// 血量
        /// </summary>
        public int hp;
        
        /// <summary>
        /// 攻击力
        /// </summary>
        public int atk;
        
        /// <summary>
        /// 防御力
        /// </summary>
        public int def;
        
        /// <summary>
        /// 攻击回复怒气值
        /// </summary>
        public int atkRange;
        
        /// <summary>
        /// 受伤回复怒气值
        /// </summary>
        public int takeDamageRage;
        
        /// <summary>
        /// 最大怒气值
        /// </summary>
        public int maxRage;

        public HeroData()
        {
                
        }
}
