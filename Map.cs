using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro_Snaker
{
    class Map
    {
        private Point mapLeft;
        private static int unit = 35;
        private readonly int length = 20 * unit;
        private readonly int width = 20 * unit;
        public int score;//分数
        private readonly Snake snake;
        public bool victory = false;
        public Snake Snake
        {
            get { return snake; }
        }
        Food blacktea;//食物
        public Map(Point start)
        {
            mapLeft = start;
            snake = new Snake(start, 5);
            blacktea = new Food();
            blacktea.Origin = new Point(start.X + 35, start.Y + 35);
        }
        private Food Foodrandom()
        {
            Random d = new Random();
            int x = d.Next(0, length / unit);
            int y = d.Next(0, width / unit);
            Point origin = new Point(mapLeft.X + x * 35, mapLeft.Y + y * 35);
            Food blacktea = new Food();
            blacktea.Origin = origin;
            return blacktea;
        }
        public void show_newtea(Graphics g)
        {
            blacktea.UnShow_food(g);
            blacktea = Foodrandom();
            blacktea.Show_food(g);
        }
        public bool check_Tea()
        {
            return blacktea.Origin.Equals(snake.HeadPoint);
        }
        public void show_Map(Graphics g)
        {
            blacktea.Show_food(g);
            if (check_Tea())
            {
                show_newtea(g);
                snake.Snake_growth();
                score += 10;
                snake.show_snake(g);
            }
            else
            {
                snake.go(g);
                snake.show_snake(g);
            }
        }
        public bool check_snake()
        {
            return !(snake.getheadpoint.X > mapLeft.X - 5 && snake.getheadpoint.X < (mapLeft.X + length - 5) && snake.getheadpoint.Y > mapLeft.Y - 5 && snake.getheadpoint.Y < (mapLeft.Y + width - 5));
        }
        public void reset(Graphics g)
        {
            snake.unshow_snake(g);
            snake.Reset(mapLeft, 5);
        }
    }
}
