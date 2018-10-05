using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameClasses
{

    public enum BlockColor
    {
        White,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple

    }

    public class Block
    {

        public int x;
        public int y;

        public BlockColor color = BlockColor.White;

        public Block(int xPosition, int yPosition)
        {
            this.x = xPosition;
            this.y = yPosition;
        }


        public Block(int xPosition, int yPosition, BlockColor blockColor)
        {
            this.x = xPosition;
            this.y = yPosition;

            this.color = blockColor;


        }
    }
}
