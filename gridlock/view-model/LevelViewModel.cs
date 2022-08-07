using gridlock.application;
using gridlock.data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace gridlock.view_model
{
    public class LevelViewModel : INotifyPropertyChanged
    {
        public LevelViewModel()
        {
            visualSettings = new();

            CurrentLevel = 25;
            MoveCount = 0;
            GridLines = GenerateGrid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int CurrentLevel { 
            get
            {
                return currentLevel;
            } 
            private set
            {
                if (currentLevel != value)
                {
                    currentLevel = value;
                    MoveCount = 0;
                    level = levelDataService.LoadLevel(value);
                    cellSize = (int)(visualSettings.CanvasSize.Height / level.Height);

                    var blockViewModels = level
                        .Blocks
                        .Select(x => new BlockViewModel(x, BlockType.Regular, visualSettings, cellSize))
                        .ToList();

                    BlockViewModel targetBlock = new(level.Target, BlockType.Target, visualSettings, cellSize);
                    blockViewModels.Add(targetBlock);

                    Blocks = new ObservableCollection<BlockViewModel>(blockViewModels);

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentLevel)));
                }
            }
        }

        public IList<BlockViewModel> Blocks
        {
            get
            {
                return blocks;
            }
            private set
            {
                if (blocks != value)
                {
                    blocks = new ObservableCollection<BlockViewModel>(value);

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Blocks)));
                }
            }
        }

        public IEnumerable<GridLineViewModel> GridLines
        {
            get
            {
                return gridLines;
            }
            private set
            {
                if (gridLines != value)
                {
                    gridLines = new ObservableCollection<GridLineViewModel>(value);

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridLines)));
                }
            }
        }

        public int MoveCount
        {
            get
            {
                return moveCount;
            }
            private set
            {
                if (moveCount != value)
                {
                    moveCount = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MoveCount)));
                }
            }
        }

        public int ExitY1 { get => cellSize * 2; }
        public int ExitY2 { get => cellSize * 3; }

        public VisualSettingsDataService VisualSettings { get => visualSettings; }

        private IEnumerable<GridLineViewModel> GenerateGrid()
        {
            return GenerateHorizontalGrid()
                .Concat(GenerateVerticalGrid());
            
        }

        private IEnumerable<GridLineViewModel> GenerateHorizontalGrid()
        {
            List<GridLineViewModel> result = new();
            for (int i = 0; i < level.Height; i++)
            {
                var y = i * visualSettings.CanvasSize.Height / level.Height;
                GridLineViewModel newLine = new(
                    new Point(0, y),
                    new Point(visualSettings.CanvasSize.Width, y),
                    visualSettings
                    );
                result.Add(newLine);
            }
            return result;
        }

        private IEnumerable<GridLineViewModel> GenerateVerticalGrid()
        {
            List<GridLineViewModel> result = new();
            for (int i = 0; i < level.Width; i++)
            {
                var x = i * visualSettings.CanvasSize.Width / level.Width;
                GridLineViewModel newLine = new(
                    new Point(x, 0),
                    new Point(x, visualSettings.CanvasSize.Height),
                    visualSettings
                    );
                result.Add(newLine);
            }
            return result;
        }


        private ObservableCollection<BlockViewModel> blocks = new();
        private IEnumerable<GridLineViewModel> gridLines = new List<GridLineViewModel>();

        private int cellSize;

        private int currentLevel;
        private Field level;
        private int moveCount;

        private VisualSettingsDataService visualSettings;
        private LevelDataService levelDataService = new();
    }
}
