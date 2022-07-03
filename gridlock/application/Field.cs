using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridlock.application
{
    public class Field
    {
        public Field(Block target, IEnumerable<Block> blocks, int height, int width)
        {
            Target = target;
            Blocks = blocks;
            Height = height;
            Width = width;
        }
        public IEnumerable<Block> Blocks { get; private set; }
        public Block Target { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
    }
}
