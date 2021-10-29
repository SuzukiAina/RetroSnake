using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Snaker
{
    class Snake
    {
        private List<Block> Blocklist;//存放蛇的列表
        private int Snake_direction;//蛇的方向 0：上 1：右 2：下 3：左
        private int Head_num;//蛇头的编号，蛇的长度
        private Point headPoint;
        private Point mapLeft;//蛇头的坐标
        public Snake(Point map,int count)
        {
            mapLeft = map;
            Block snake_block;
            Point p = new Point(map.X + 35, map.Y + 35);
            Blocklist = new List<Block>();
            for(int i=0;i<count;i++)
            {
                p.X += 35;
                snake_block = new Block();
                snake_block.sp = p;//定义蛇块的位置
                snake_block.BlockNumber = i + 1;//定义蛇块的编号
                if(i==count-1)
                {
                    headPoint = snake_block.sp;
                    snake_block.IsHead = true;
                }
                Blocklist.Add(snake_block);
            }
            Head_num = count;
        }
        public Point HeadPoint//只读属性
        {
            get { return headPoint; }
        }
        public int Direction//蛇头的运动方向
        {
            get { return Snake_direction; }
            set { Snake_direction = value; }
        }
        public void Turndirection(int next_direction)
        {
            switch (Direction)
            {
                case 0://原来向上
                    if (next_direction == 3)//向左
                        Direction = 3;
                    else if (next_direction == 1)//向右
                        Direction = 1;
                    break;
                case 1://原来向右
                    if (next_direction == 0)//向上
                        Direction = 0;
                    else if (next_direction == 2)//向下
                        Direction = 2;
                    break;
                case 2://原来向下
                    if (next_direction == 3)//向左
                        Direction = 3;
                    else if (next_direction == 1)//向右
                        Direction = 1;
                    break;
                case 3://原来向左
                    if (next_direction == 0)//向上
                        Direction = 0;
                    else if (next_direction == 3)//向下
                        Direction = 3;
                    break;
            }
        }
        public Point getheadpoint
        {
            get { return headPoint; }
        }
        public void Snake_growth()//吃到食物
        {
            Point head = Blocklist[Blocklist.Count - 1].sp;
            int x = head.X;
            int y = head.Y;
            switch(Direction)
            {
                case 0://向上运动
                    y -= 35;
                    break;
                case 1://向右运动
                    x += 35;
                    break;
                case 2://向下运动
                    y += 35;
                    break;
                case 3://向左运动
                    x -= 35;
                    break;
            }
            Blocklist[Blocklist.Count - 1].IsHead = false;
            Block newhead = new Block();
            newhead.IsHead = true;
            newhead.BlockNumber = Blocklist.Count + 1;
            newhead.sp = new Point(x, y);
            Blocklist.Add(newhead);
            Head_num++;
            headPoint = newhead.sp;
        }
        public void go(Graphics g)//单纯向前爬
        {
            Block snake_tail = Blocklist[0];
            snake_tail.UnShowBlock(g);
            foreach (var item in Blocklist)
            {
                item.BlockNumber--;
            }
            Head_num++;
            Snake_growth();
        }
        public void show_snake(Graphics g)//画出蛇
        {
            foreach(var item in Blocklist)
            {
                item.ShowBlock(g);
            }
        }
        public void unshow_snake(Graphics g)//隐藏蛇
        {
            foreach (var item in Blocklist)
            {
                item.UnShowBlock(g);
            }
        }
        public void Reset(Point map, int count)
        {
            Block blockSnake;
            Point p = new Point(mapLeft.X + 35, mapLeft.Y + 35);
            Blocklist = new List<Block>();
            for (int i = 0; i < count; i++)
            {
                //x坐标加35
                p.X += 35;
                //实例化蛇块
                blockSnake = new Block();
                //定义蛇块的左上角位置 
                blockSnake.sp = p;
                //定义蛇块的编号1，2，3...
                blockSnake.BlockNumber = i + 1;
                if (i == count - 1)
                {
                    //蛇头
                    //给蛇头位置赋值
                    headPoint = blockSnake.sp;
                    blockSnake.IsHead = true;
                }
                Blocklist.Add(blockSnake);

            }
            //蛇的长度赋值
            Head_num = count;
            Direction = 1;
        }
        public bool Is_touch_myself()//是否碰到自己
        {
            bool Is_touched=false;
            for (int i = 0; i < Blocklist.Count - 1; i++)
            {
                if (headPoint == Blocklist[i].sp)
                {
                    Is_touched = true;
                    break;
                }
            }
            return Is_touched;
        }
    }
}
