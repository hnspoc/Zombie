using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class BotanicRepeater : IBotany
    {
        public BotanicRepeater()
        {
            idleimg = "images/Plants/Repeater/Repeater.gif"; 
        }
        protected override void PlayEffect()
        {
            throw new NotImplementedException();
        }
        public override void Attack(ICharacter target)
        {

        }
        protected override void PlaySound()
        {
            throw new NotImplementedException();
        }
    }
}
