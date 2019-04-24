using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class CharacterSystem:IGameSystem
    {
        private List<ICharacter> mEnemys = new List<ICharacter>();
        private List<ICharacter> mBotanys = new List<ICharacter>();

        public void AddEnemy(IEnemy enemy)
        {
            mEnemys.Add(enemy);
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
        public void UpdateRender(Graphics g)
        {
            foreach (IEnemy e in mEnemys)
            {
                e.MAnim.Animatetion(g);
            }
            foreach (IBotany s in mBotanys)
            {
                s.MAnim.Animatetion(g);
            }
        }
        public override void Update()
        {
            UpdateEnemy();
            UpdateBotanys();

            RemoveCharacterIsKilled(mEnemys);
            RemoveCharacterIsKilled(mBotanys);
        }
        private void UpdateEnemy()
        {
            foreach (IEnemy e in mEnemys)
            {
                e.Update();
                e.UpdateFSMAI(mBotanys);
            }
        }
        private void UpdateBotanys()
        {
            foreach (IBotany s in mBotanys)
            {
                s.Update();
                s.UpdateFSMAI(mEnemys);
            }
        }
        private void RemoveCharacterIsKilled(List<ICharacter> characters)
        {
            List<ICharacter> canDestroyes = new List<ICharacter>();
            foreach (ICharacter character in characters)
            {
                if (character.canDestroy)
                {
                    canDestroyes.Add(character);
                }
            }
            foreach (ICharacter character in canDestroyes)
            {
                character.Release();
                characters.Remove(character);
            }
        }
        
    }
}
