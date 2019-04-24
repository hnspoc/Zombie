using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public static class FactoryManager
    {
        
        private static ICharacterFactory botanyFactory = null;
        private static ICharacterFactory enemyFactory = null;
        private static IAttrFactory attrFactory = null;

        public static IAttrFactory AttrFactory
        {
            get
            {
                if (attrFactory == null)
                {
                    attrFactory = new AttrFactory();
                }
                return attrFactory;
            }
        }

        
        public static ICharacterFactory BotanyFactory
        {
            get
            {
                if (botanyFactory == null)
                {
                    botanyFactory = new BotanyFactory();
                }
                return botanyFactory;
            }
        }
        public static ICharacterFactory EnemyFactory
        {
            get
            {
                if (enemyFactory == null)
                {
                    enemyFactory = new EnemyFactory();
                }
                return enemyFactory;
            }
        }
    }
}
