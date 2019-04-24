using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    class BulletSystem:IGameSystem
    {
        private List<IBullet> warehouse = new List<IBullet>();
        private List<IBullet> launchhouse = new List<IBullet>();
        public void AddLaunch(IBullet launch)
        {
            launchhouse.Add(enemy);
        }
        public void RemoveEnemey(IEnemy enemy)
        {
            mEnemys.Remove(enemy);
        }
        public void AddBotany(IBotany soldier)
        {
            mBotanys.Add(soldier);
        }
        public void RemoveBotany(IBotany soldier)
        {
            mBotanys.Remove(soldier);
        }
    }
}
