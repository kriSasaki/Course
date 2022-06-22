using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40_РаботаСоСвойствами
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(5, 5);
            renderer.DrawPlayer(player.PositionX, player.PositionY);
        }
    }

    class Renderer
    {
        public void DrawPlayer(int positionX, int positionY, char sign = '$')
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(sign);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
