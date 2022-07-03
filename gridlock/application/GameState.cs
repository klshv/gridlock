using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridlock.application
{
    public class GameState
    {
        public GameState(int moveCount, int curentLevel, Field field)
        {
            MoveCount = moveCount;
            CurentLevel = curentLevel;
            Field = field;
        }

        public int MoveCount { get; private set; }
        public int CurentLevel { get; private set; }
        public Field Field { get; private set; }
    }

    // количество ходов, текущий уровень и текущее поле
}
