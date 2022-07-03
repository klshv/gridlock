using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridlock.application
{
    class BlockService
    {
        Block GetBlockMovedLeft(Block inputBlock)
        {
            if (inputBlock.Direction == Direction.Horizontal)
            {
                return new Block(inputBlock.Length, inputBlock.Direction, inputBlock.X - 1, inputBlock.Y);
                /* return inputBlock with { X = inputBlock.X - 1}; */
            }
            else
            {
                return inputBlock /* with { } */;
            }
        }
    }
}
