using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Snaker
{
    class Food
    {
        private Point food_point;
        public Point Origin
        {
            get { return food_point; }
            set { food_point = value; }
        }
        public void Show_food(Graphics g)
        {
            Bitmap bitMap;
            bitMap = new Bitmap(Image.FromFile("2.jpg"));
            g.DrawImage(bitMap, Origin.X, Origin.Y, 35, 35);
        }
        public void UnShow_food(Graphics g)
        {
            //定义系统背景颜色的画笔
            SolidBrush brush = new SolidBrush(Color.White);
            //画实心矩形颜色为系统背景颜色，相当于食物被吃掉了
            g.FillRectangle(brush, Origin.X, Origin.Y, 35, 35);
        }
    }
}
