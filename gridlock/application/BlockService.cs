using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridlock.application
{
    public class BlockService
    {
        public Block GetBlockMovedLeft(Block inputBlock)
        {
            if (inputBlock.Direction == Direction.Horizontal)
            {
                //return new Block(inputBlock.Length, inputBlock.Direction, inputBlock.X - 1, inputBlock.Y);
                return inputBlock with { X = inputBlock.X - 1};
            }
            else
            {
                return inputBlock /* with { } */;
            }
        }

        public Block GetBlockMovedRight(Block inputBlock)
        {
            if (inputBlock.Direction == Direction.Horizontal)
            {
                return new Block(inputBlock.Length, inputBlock.Direction, inputBlock.X + 1, inputBlock.Y);
                /* return inputBlock with { X = inputBlock.X + 1}; */
            }
            else
            {
                return inputBlock /* with { } */;
            }
        }

        public Block GetBlockMovedDown(Block inputBlock)
        {
            if (inputBlock.Direction == Direction.Vertical)
            {
                return new Block(inputBlock.Length, inputBlock.Direction, inputBlock.X, inputBlock.Y - 1);
                /* return inputBlock with { Y = inputBlock.Y - 1}; */
            }
            else
            {
                return inputBlock /* with { } */;
            }
        }

        public Block GetBlockMovedUp(Block inputBlock)
        {
            if (inputBlock.Direction == Direction.Vertical)
            {
                return new Block(inputBlock.Length, inputBlock.Direction, inputBlock.X, inputBlock.Y + 1);
                /* return inputBlock with { Y = inputBlock.Y + 1}; */
            }
            else
            {
                return inputBlock /* with { } */;
            }
        }
    }
}
