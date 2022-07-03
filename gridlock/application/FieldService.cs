﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridlock.application
{
    class FieldService
    {
        public bool CanMoveLeft(Field field, Block inputBlock)
        {
            if (inputBlock.X == 0)
            {
                return false;
            }

            if (field.Blocks.Any(block => inputBlock.Intesects(block)))
            {
                return false;
            }

            return true;
        }
    }
}