using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public abstract class IBullet
    {
        private int moveSpeed;
        private int damage;
        protected bool mCanDestroy = false;
        private Point position;
        private int posRow;
        protected BulletFSMSystem mFSMSystem;
        private AnimateImage mAnim;
        protected string flyimg;
        protected string boomimg;
    }
}
