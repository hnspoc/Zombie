using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    class SingleBullet : IBullet
    {
        public SingleBullet()
        {

        }
        public override void Attack(ICharacter target)
        {
            PlayAnim(attr.Boomimg);//播放动画
            target.UnderAttack(attr.Damage);
        }
    }
}
