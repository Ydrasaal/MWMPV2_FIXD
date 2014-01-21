using System;
using System.IO;
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
using Microsoft.Win32;

namespace WinMediaPLayer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SoundSlide_Click(object sender, RoutedEventArgs eve) {
            this.medPLayer.Volume = ((Slider)sender).Value;
        }

        private void ProgressBar_Click(object sender, RoutedEventArgs eve)
        {
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            file.Filter = "Media Files (*.wav)|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3;*.wmv";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == true)
            {
                this.medPLayer.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                this.medPLayer.Source = new Uri(file.FileName);
                //wmp.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
                //wmp.MediaError +=
                //    new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
                this.medPLayer.Play();
                this.medPLayer.Volume = 50;
                //wmp.URL = file.FileName;
                //wmp.settings.volume = 50;
                //wmp.controls.play();
                //playButton.Text = "Pause";
            }
        }
    }
}
