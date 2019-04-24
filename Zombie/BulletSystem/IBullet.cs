using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    
    public abstract class IBullet
    {
        protected BulletBaseAttr attr;
        private bool activa;
        private Point position;
        private Point targetPosition;
        private Rectangle area;
        private int imgheight;
        private int imgwidth;
        private int directionX;
        private int directionY;
        private AnimateImage mAnim;
        private string currimg;
        public AnimateImage MAnim
        {
            set
            {
                mAnim = value;
            }
        }
        public bool Activa
        {
            get
            {
                return activa;
            }

            set
            {
                activa = value;
            }
        }

        public BulletBaseAttr Attr
        {
            get
            {
                return attr;
            }

            set
            {
                attr = value;
            }
        }

        public IBullet(BulletBaseAttr ar, Point position, Point targetPosition)
        {
            this.attr = ar;
            SetActive(position,targetPosition);
            Image bm=Image.FromFile(attr.Flyimg);
            this.imgheight = bm.Height;
            this.imgwidth = bm.Width;
            bm.Dispose();
        }
        public void SetActive(Point position, Point targetPosition)
        {
            this.position = position;
            this.targetPosition = targetPosition;
            if (position.X - targetPosition.X > 0)
                directionX = -1;
            else if (position.X - targetPosition.X < 0)
                directionX = 1;
            else
                directionX = 0;

            if (position.Y - targetPosition.Y > 0)
                directionY = -1;
            else if (position.Y - targetPosition.Y < 0)
                directionY = 1;
            else
                directionY = 0;

            if (directionX == -1)
                area = new Rectangle(targetPosition.X, targetPosition.Y, position.X - targetPosition.X, position.Y - targetPosition.Y);
            else
                area = new Rectangle(position.X, position.Y, targetPosition.X - position.X, targetPosition.Y - position.Y);
            Activa = true;
            
        }

        public abstract void Attack(ICharacter target);
        public void PlayAnim(string animName)
        {
            if (currimg != animName)
            {
                currimg = animName;
                mAnim.changeImage(animName);
            }
        }
        public virtual void FlyTo()
        {
            position.X = position.X + attr.MoveSpeed*directionX;
            position.Y = position.Y + attr.MoveSpeed * directionY;
            PlayAnim(attr.Flyimg);
        }
        public bool  CheckCross(Rectangle r1, Rectangle r2)
        {
            PointF c1 = new PointF(r1.Left + r1.Width / 2.0f, r1.Top + r1.Height / 2.0f);
            PointF c2 = new PointF(r2.Left + r2.Width / 2.0f, r2.Top + r2.Height / 2.0f);
            return (Math.Abs(c1.X - c2.X) <= r1.Width / 2.0 + r2.Width / 2.0 && Math.Abs(c2.Y - c1.Y) <= r1.Height / 2.0 + r2.Height / 2.0);
        }
        public void UpdateCollsion(List<ICharacter> targets)
        {
            Rectangle rc = new Rectangle(position.X, position.Y, imgwidth, imgheight);
            foreach (ICharacter item in targets)
            {
                if(CheckCross(rc, item.box))
                {
                    activa = false;
                }

            }
        }
        public void Update()
        {
            if (!activa) return;
            if (area.Contains(position))
            {
                FlyTo();
            }
            else
            {
                activa = false;
            }
        }
    }
}
