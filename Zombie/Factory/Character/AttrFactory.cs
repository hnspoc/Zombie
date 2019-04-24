using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class AttrFactory : IAttrFactory
    {
        private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrDict;
        public AttrFactory()
        {
            InitCharacterBaseAttr();
        }
        private void InitCharacterBaseAttr()
        {
            mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
            mCharacterBaseAttrDict.Add(typeof(EnemyZombie), new CharacterBaseAttr("丧尸", 100, 2, 10, 30));
            mCharacterBaseAttrDict.Add(typeof(BotanicRepeater), new CharacterBaseAttr("豌豆射手", 100, 2, 5, 25));   
        }
        public CharacterBaseAttr GetCharacterBaseAttr(Type t)
        {
            if (mCharacterBaseAttrDict.ContainsKey(t) == false)
            {
               return null;
            }
            return mCharacterBaseAttrDict[t];
        }
    }
}
