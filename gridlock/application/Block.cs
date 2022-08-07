using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace gridlock.application
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Direction {
        Horizontal,
        Vertical
    }

    public record Block
    {
        public Block(int length, Direction direction, int x, int y)
        {
            Length = length;
            Direction = direction;
            X = x;
            Y = y;
        }

        public int Length { get; init; }
        public Direction Direction { get; init; }
        public int X { get; init; }
        public int Y { get; init; }

        public bool Intesects(Block block2)
        {
            var coodinates1 = ToCoordinates();
            var coordinates2 = block2.ToCoordinates();

            return coodinates1.Any(point1 => coordinates2.Any(point2 => point1 == point2));
        }

        // массив, если вертикальное y = const x увеличвается

        private IEnumerable<(int, int)> ToCoordinates()
        {
            var coordinates = new List<(int, int)>();
            for (int i = 0; i < Length; i++) 
            {
                if (Direction == Direction.Horizontal)
                {
                    coordinates.Add((X + i, Y));
                }
                else
                {
                    coordinates.Add((X, Y + i));
                }
            }
            return coordinates;
        }
    }
}
