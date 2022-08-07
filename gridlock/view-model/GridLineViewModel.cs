using gridlock.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace gridlock.view_model
{
    public class GridLineViewModel
    {
        public GridLineViewModel(Point start, Point end, VisualSettingsDataService settings)
        {
            this.settings = settings;
            this.start = start;
            this.end = end;
        }

        public Brush Stroke { get => settings.Stroke; }

        public int Thickness { get => settings.GridLineThickness; }

        public Point Start { get => start; }
        public Point End { get => end; }

        private VisualSettingsDataService settings;
        private Point start;
        private Point end;
    }
}
