using PECAN.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PECAN._2D
{
    public class Position2D : IPosition, IEquatable<Position2D>
    {
        protected readonly int xPos;
        protected readonly int yPos;
        public Position2D(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
        public bool Equals(IPosition other)
        {
            if (other is Position2D other2d)
            {
                return this.Equals(other2d);
            }
            return false;
        }

        public bool Equals(Position2D other)
        {
            if (other == null)
            {
                return false;
            }
            return this.xPos == other.xPos &&
                   this.yPos == other.yPos;
        }

        public int X => this.xPos;
        public int Y => this.yPos;
    }
}
