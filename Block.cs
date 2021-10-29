using System.Drawing;

namespace Retro_Snaker
{
    class Block
    {
        private bool _isHead;//是否为蛇头
        public bool IsHead
        {
            get { return _isHead; }
            set { _isHead = value; }
        }
        private int _blockNumber;//蛇块的编号
        public int BlockNumber
        {
            get { return _blockNumber; }
            set { _blockNumber = value; }
        }
        private Point Snake_point;//蛇块的位置
        public Point sp
        {
            get { return Snake_point; }
            set { Snake_point = value; }
        }
        public void ShowBlock(Graphics g)
        {
            Bitmap bitMap;
            if (IsHead)
            {
                //蛇头
                bitMap = new Bitmap(Image.FromFile("1.jpg"));
            }
            else
            {
                bitMap = new Bitmap(Image.FromFile("1.jpg"));
            }
            g.DrawImage(bitMap, sp.X, sp.Y, 35, 35);
        }
        public void UnShowBlock(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, sp.X, sp.Y, 35, 35);
        }
    }
}
