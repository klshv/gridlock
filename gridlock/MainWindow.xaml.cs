using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using gridlock.data;
using gridlock.view_model;

namespace gridlock
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LevelViewModel levelViewModel;

        public MainWindow()
        {
            InitializeComponent();

            levelViewModel = new LevelViewModel();
            this.DataContext = levelViewModel;
        }

        private void GameGridlock_OnLoaded(object sender, RoutedEventArgs e) {

        }

        private void ButtonOptions_Click(object sender, RoutedEventArgs e) {

        }
        
        private void ButtonFAQ_Click(object sender, RoutedEventArgs e) {

        }
        
        private void ButtonReset_Click(object sender, RoutedEventArgs e) {

        }

        private void OnBlockMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {

                // Скорее всего понадобится решить проблему - sender это тот, над которым сейчас проводим мышь, а
                // не блок, который мы подхватили. Необходимо либо запоминать блок, с которого началось движение 
                // с зажатой кнопкой (сбрасывая это состояние при отпускании кнопки - MouseUp), либо использовать
                // стандартный механизм Drag-and-Drop (про это нужно читать, как этим пользоваться).

                Rectangle targetRect = sender as Rectangle;
                BlockViewModel targetBlock = targetRect.DataContext as BlockViewModel;

                var position = targetBlock.ConvertCoordinateScreenToField(e.MouseDevice.GetPosition(this.WorkSpaceGridlock));
                targetBlock.TryToChangePosition(position);

                Console.WriteLine($"Move {targetBlock.Name} {position.X}x{position.Y}");
            }
        }


    }
}
