using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Zombie
{
    public partial class BattleForm : Form
    {
        private CharacterName currBotany;
        private bool isBuild=false;
        private Bitmap currentMap;
        private Point currentPt;

        public BattleForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);        
        }

        private void BattleForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            Bitmap bm=Properties.Resources.background1;
            this.Width= bm.Width+5;
            this.Height = bm.Height+5;
            
            SetRow();
            GameFacade.Insance.Init();
            GameFacade.Insance.Currform = this;
        }

        private void BattleForm_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer = currentContext.Allocate(e.Graphics, e.ClipRectangle);
            Graphics g = myBuffer.Graphics;
            g.Clear(this.BackColor);
            
            g.DrawImage(Properties.Resources.background1, 0, 0, Properties.Resources.background1.Width, Properties.Resources.background1.Height);
            GameFacade.Insance.UpdateRender(g);
            if(isBuild)
            g.DrawImage(currentMap, currentPt);
            myBuffer.Render(e.Graphics);  //呈现图像至关联的Graphics
            myBuffer.Dispose();
            g.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*this.x++;
            if(1000 - this.x * 2 >260)
                Zombie.Location = new Point(1300-this.x*2, 450);
            else
            {
                x = 0;
                Zombie.Location = new Point(1300,450);
            }
            if (280 + x * 10<1200)
            {
                PeaBullet.Location = new Point(280 + x * 10, 480);
            }
            else
            {
                PeaBullet.Location = new Point(280,480);
                x = 0;
            }
            Gardenrender.Animate();
            Zombierender.Animate();
            Plantrender.Animate();
            PeaBulletrender.Animate();*/
            //mCharacterSystem.Update();
            GameFacade.Insance.Update();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SceneStateController.controll.Request();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            currBotany = CharacterName.nRepeater;
            currentMap = new Bitmap( "images/Plants/Repeater/Repeater.gif");
            isBuild = true;
        }

        private void BattleForm_MouseClick(object sender, MouseEventArgs e)
        {
            if(isBuild)
            {
                currentPt.X = e.Location.X - currentMap.Width / 2;
                if (currentPt.X < 250) currentPt.X = 250;
                currentPt.Y = e.Location.Y - currentMap.Height / 2;
                
                int i;
                for ( i = 0; i < GameFacade.Insance.botanyrowPos.Length; i++)
                {
                    if(System.Math.Abs(currentPt.Y - GameFacade.Insance.botanyrowPos[i]) <= currentMap.Height/2)
                    {
                        break;
                    }
                }
                if (i < -1) i = 0;
                if (i >= GameFacade.Insance.botanyrowPos.Length) i = i - 1;
                currentPt.Y = GameFacade.Insance.botanyrowPos[i];
                GameFacade.Insance.MCampSystem.SetCampCommand(currBotany, currentPt,i);
                isBuild = false;
                currentMap.Dispose();
                currentMap = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void BattleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isBuild)
            {
                this.Cursor = Cursors.Hand;
                currentPt.X = e.Location.X-currentMap.Width/2;
                currentPt.Y = e.Location.Y - currentMap.Height / 2;
                this.Invalidate();
            }
        }
        public void SetRow()
        {
            GameFacade.Insance.botanyrowPos = new int[5];
            GameFacade.Insance.enyrowPos = new int[5];
            Bitmap plant = new Bitmap("images/Plants/Repeater/Repeater.gif");
            Bitmap eny = new Bitmap("images/Zombies/Zombie/Zombie.gif");
            int i;
            int rowheight = (this.Height - 53) / 5;
            for(i=1;i<=5;i++)
            {
                GameFacade.Insance.enyrowPos[i - 1] = 10 + rowheight * i  - eny.Height ;
                GameFacade.Insance.botanyrowPos[i-1] = 10 + rowheight*i - plant.Height ; 
            }
            plant.Dispose();
            eny.Dispose();
        }
    }
}
