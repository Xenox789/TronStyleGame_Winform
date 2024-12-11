using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// direction means: 1-North; 2-East; 3-South; 4-West

namespace Tron.Model
{
    public class Player
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int direction { get; set; }

        public Player(int id, int x, int y, int dir)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            if (dir < 1 || dir > 4)
            {
                throw new Exception();
            }
            direction = dir;
        }

        public void Move()
        {
            if (direction == 1)
            {
                y--;
            }
            else if (direction == 2)
            {
                x++;
            }
            else if (direction == 3)
            {
                y++;
            }
            else { x--; }
        }

        public void LeftTurn()
        {
            if (direction == 1)
            {
                direction = 4;
            }
            else if (direction == 2)
            {
                direction = 1;
            }
            else if (direction == 3)
            {
                direction = 2;
            }
            else { direction = 3; }
        }

        public void RightTurn()
        {
            if (direction == 1)
            {
                direction = 2;
            }
            else if (direction == 2)
            {
                direction = 3;
            }
            else if (direction == 3)
            {
                direction = 4;
            }
            else { direction = 1; }
        }

        public void Setup(int x, int y, int dir)
        {
            this.x = x;
            this.y = y;
            direction = dir;
        }
    }
}
