using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameClasses
{
    public class TetrisGameGrid
    {
        public Block[,] gridSpaces;

        public int width;
        public int height;


        private void Initialize()
        {
            gridSpaces = new Block[width, height];
        }


        //Constructor
        public TetrisGameGrid(int desiredWidth, int desiredHeight)
        {
            this.width = desiredWidth;
            this.height = desiredHeight;

            Initialize();
        }
    }
}
