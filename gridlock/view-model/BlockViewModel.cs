using gridlock.application;
using gridlock.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace gridlock.view_model
{
    public enum BlockType { Target, Regular }

    public class BlockViewModel : INotifyPropertyChanged
    {
        public BlockViewModel(Block block, BlockType type, VisualSettingsDataService settings, int cellSize)
        {
            this.block = block;
            this.cellSize = cellSize;
            this.settings = settings;
            this.fill = type switch
            {
                BlockType.Target => Brushes.Blue,
                BlockType.Regular => block.Length == 2 ? Brushes.DarkGreen : Brushes.DarkGray,
                _ => throw new NotImplementedException("Specified block type is not supported!")
            };
        }

        public int Top
        {
            get => (int)(settings.CanvasSize.Height) - (block.Y * cellSize);
        }

        public int Left
        {
            get => block.X * cellSize;
        }


        public Size Size { 
            get => 
                block.Direction == Direction.Horizontal
                    ? new Size(cellSize * block.Length, cellSize) 
                    : new Size(cellSize, cellSize * block.Length); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Brush Fill
        {
            get { return fill; }
        }

        private readonly Block block;
        private readonly Brush fill;
        private VisualSettingsDataService settings;
        private int cellSize;
    }
}
