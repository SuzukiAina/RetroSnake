using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Retro_Snaker
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Point point = new Point(50,50);
            map = new Map(point);
            BackColor = Color.White;
        }
        private readonly Map map;
        private int gradenum = 100;//难度
        private void FormMain_Load(object sender, EventArgs e)
        {
            SetStyle(
               ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox_paint(object sender, PaintEventArgs e)
        {

        }

        private void Keyboard(object sender,KeyEventArgs e)
        {

        }

        private void 难度设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 新手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradenum = 200;
            label6.Text = "新手";
            game_timer.Interval= gradenum;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (label6.Text == "未设置")
            {
                MessageBox.Show("请先选择级别");
                return;
            }
            if (button1.Text == "开始")
            {
                button1.Text = "重新开始";
                game_timer.Enabled = true;
            }
            else if(button1.Text == "重新开始")
            {
                button1.Text = "开始";
                button2.Text = "暂停";
                game_timer.Enabled = true;
                map.reset(CreateGraphics());
                map.score = 0;
            }
        }

        public void DrawImageInPicturebox(Image myBitmap, float x, float y)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            //消除锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //高质量，低速度绘制
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.Clear(Color.White);
            g.DrawImage(myBitmap, new Point((int)x, (int)y));
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "继续")
            {
                button2.Text = "暂停";
                game_timer.Enabled = true;
            }
            else if(button2.Text == "暂停")
            {
                button2.Text = "继续";
                game_timer.Enabled = false;
            }
        }

        private void Game_timer_Tick(object sender, EventArgs e)
        {
            button1.Text = "重新开始";
            label1.Text = map.score.ToString();
            if (map.score > 250)
            {
                game_timer.Enabled = false;
                MessageBox.Show("1 1 4 5 1 4");
            }
            Bitmap bmp = new Bitmap(Width, Height);
            Image face = Image.FromFile("4.png");
            BackgroundImage = bmp;
            Graphics g = this.pictureBox1.CreateGraphics();
            map.show_Map(g);
            if (map.check_snake() || map.Snake.Is_touch_myself())
            {
                game_timer.Enabled = false;
                MessageBox.Show("1 9 1 9 8 1 0 ");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int k = 0, d = 0;
            k = e.KeyValue;
            if (k == 37)
            {
                d = 3;
            }
            else if (k == 40)
            {
                d = 2;
            }
            else if (k == 38)
            {
                d = 0;
            }
            else if (k == 39)
            {
                d = 1;
            }
            map.Snake.Turndirection(d);
        }

        private void 中级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradenum = 100;
            label6.Text = "中级";
            game_timer.Interval = gradenum;
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradenum = 50;
            label6.Text = "高手";
            game_timer.Interval = gradenum;
        }
    }
}
