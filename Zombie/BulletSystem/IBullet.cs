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
        private Rectangle rc;
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

        public IBullet( Point position, Point targetPosition)
        {
            SetActive(position,targetPosition);
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
                rc = new Rectangle(targetPosition.X, targetPosition.Y, position.X - targetPosition.X, position.Y - targetPosition.Y);
            else
                rc = new Rectangle(position.X, position.Y, targetPosition.X - position.X, targetPosition.Y - position.Y);
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
        public void Update()
        {
            
            if (rc.Contains(position))
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
