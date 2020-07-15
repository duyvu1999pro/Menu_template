using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vu_Manager.Properties;

namespace Vu_Manager
{
    public partial class Menu : Form
    {
   //     [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
   //     private static extern IntPtr CreateRoundRectRgn
   //(
   //    int nLeftRect,     // x-coordinate of upper-left corner
   //    int nTopRect,      // y-coordinate of upper-left corner
   //    int nRightRect,    // x-coordinate of lower-right corner
   //    int nBottomRect,   // y-coordinate of lower-right corner
   //    int nWidthEllipse, // width of ellipse
   //    int nHeightEllipse // height of ellipse
   //);
        public Menu()
        {
            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            InitializeComponent();
         
        }
        private void call_form(Form child_form)
        {
            child_form.TopLevel = false;
            board_main.Controls.Add(child_form);
            child_form.Dock = DockStyle.Fill;
            child_form.Show();
        }
        private void but_child_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Name)
            {
                //case "but_home":
                //    this.screen.Controls.Clear();
                //    ThongBao formAnnounce = new ThongBao();
                //    call_form(formAnnounce);
                //    break;
            }
            }
        private void resize_but_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exit_but_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        private void board_bar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void board_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void board_bar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private int indexBut = 1;
        private void but_parent_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Name)
            {
                case "but1":
                    autoCloseBut(3);
                    indexBut = 1;
                    timer1.Start();
                    break;
                case "but2":
                    autoCloseBut(3);
                    indexBut = 2;
                    timer1.Start();
                    break;
                case "but3":
                    autoCloseBut(3);
                    indexBut = 3;
                    timer1.Start();
                    break;
                case "but4":
                    autoCloseBut(3);
                    indexBut = 4;
                    timer1.Start();
                    break;

            }
        }
        private bool[] isExpand = { false, false, false, false,false };
      private void resizeBut(int index,Panel p,Button b)
        {
           
            if (!isExpand[index])//mở ra
            {
                b.Image = Resources.up_arrow;
                p.Height += 10;
                if (p.Size.Height == p.MaximumSize.Height)
                {
                    timer1.Stop();
                    isExpand[index] = true;
                }
            }
            else  //thu lại
            {
                b.Image = Resources.down_arrow;
                p.Height -= 10;
                if (p.Size.Height == p.MinimumSize.Height)
                {
                    timer1.Stop();
                    isExpand[index] = false;
                }

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        
            switch (indexBut)
            {
                case 1:
               
                    resizeBut(indexBut,p1,but1);
                    break;
                case 2:
                   
                    resizeBut(indexBut, p2, but2);                
                    break;
                case 3:
                 
                    resizeBut(indexBut, p3, but3);                  
                    break;
                case 4:
                   
                    resizeBut(indexBut, p4, but4);                  
                    break;

            }
        }
        private void autoCloseBut(int max)
        {
            int dem = 0;
            for (int i = 1; i < isExpand.Length; i++)
            {
                if (isExpand[i]==true)
                {
                    dem++;
                }
            }

            if (dem>max-1)
            {                                                                               
                        but1.Image = Resources.down_arrow;
                         p1.Height = p1.MinimumSize.Height;
                         isExpand[1] = false;
                         but2.Image = Resources.down_arrow;
                         p2.Height = p2.MinimumSize.Height; 
                         isExpand[2] = false;
                         but3.Image = Resources.down_arrow;
                         p3.Height = p3.MinimumSize.Height;
                           isExpand[3] = false;
                          but4.Image = Resources.down_arrow;                                                                   
                          p4.Height = p4.MinimumSize.Height;          
                           isExpand[4] = false;
             
                    
                
              
            }
        }

     
    }
}
