using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace Zombie
{
    public class AnimateImage
    {
        ICharacter iCharacter;
        Bitmap image;
        Form iform;
        bool mCanAnimate;
        bool currentlyAnimating = false;
        
        public AnimateImage(object oj, ICharacter iCharacter)
        {
            this.iCharacter = iCharacter;
            mCanAnimate = false;
            iform = (Form)oj;
            //mCanAnimate = ImageAnimator.CanAnimate(image);
        }
        public void changeImage(string path)
        {
            Stop();
            image = new Bitmap(path);
            ImageAnimator.Animate(image, new EventHandler(FrameChanged));
            Start();
        }
        public Image Image
        {
            get { return image; }
        }
        public void Start()
        {
            mCanAnimate = true;
        }
        private void FrameChanged(object sender, EventArgs e)
        {
            iform.Invalidate();
        }
        public void Stop()
        {
            mCanAnimate = false;
        }
        public void Animatetion(Graphics g)
        {
            //if (image == null) return;
            if (!currentlyAnimating && mCanAnimate)
            {
                //Begin the animation only once.
                ImageAnimator.Animate(image, new EventHandler(FrameChanged));
                currentlyAnimating = true;
                Start();
            }
            if (mCanAnimate)
            {
                ImageAnimator.UpdateFrames();
                //g.DrawImage(image, iCharacter.Position.X, iCharacter.Position.Y, image.Width,image.Height);
                g.DrawImage(image, iCharacter.Position.X, iCharacter.Position.Y);
            }
        }
    }
}
