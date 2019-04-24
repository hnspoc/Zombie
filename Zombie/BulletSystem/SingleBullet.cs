using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class SingleBullet : IBullet
    {
        public SingleBullet(BulletBaseAttr ar,Point position, Point targetPosition):base(ar,position, targetPosition)
        {

        }
        public override void Attack(ICharacter target)
        {
            PlayAnim(attr.Boomimg);//播放动画
            target.UnderAttack(attr.Damage);
        }
    }
}
