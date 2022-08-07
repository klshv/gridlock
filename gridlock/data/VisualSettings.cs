using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace gridlock.data
{
    public class VisualSettingsDataService
    {
        public int GridLineThickness { get => 3; }
        public Brush Stroke { get => Brushes.Black; }

        public Size CanvasSize { get => new(500, 500);  }

        public int BoundaryThickness { get => 5; }
        public Brush BoundaryStroke { get => Brushes.Red; }
    }
}
