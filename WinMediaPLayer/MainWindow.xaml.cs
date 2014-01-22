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
using System.Windows.Threading;
using WinMediaPLayer.Models;

namespace WinMediaPLayer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPlaying = false;
        private PlaylistModel currentList = new PlaylistModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SoundSlide_Click(object sender, RoutedEventArgs eve) {
            this.medPlayer.Volume = ((Slider)sender).Value / 100;
        }

        private void ProgressBar_ValueChanged(object sender, RoutedEventArgs eve)
        {
            if (this.medPlayer.Source != null)
            {
                if (this.medPlayer.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    this.medPlayer.Position = TimeSpan.FromSeconds(this.medPlayer.NaturalDuration.TimeSpan.TotalSeconds * (((Slider)sender).Value / 100));
                }
            }
            else
            {
                ((Slider)sender).Value = 0;
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            file.Filter = "Media Files (*.wav)|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3;*.mp4;*.wmv";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == true)
            {
                if (file.FileName.Length > 0)
                {
                    MessageBox.Show(file.FileName);
                    this.currentList.addElement(file.FileName);
                    currentPlaylist.ItemsSource = this.currentList.getNameList();
                }
                this.medPlayer.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                this.medPlayer.Source = new Uri(file.FileName);
                this.medPlayer.Play();
                //PlayButton.IsChecked = true;
                this.isPlaying = true;
                this.medPlayer.Volume = 0.5;
            }
        }

        private void medPlayer_MediaOpened(object sender, EventArgs e)
        {
            var timerTime = new DispatcherTimer();
            timerTime.Interval = TimeSpan.FromSeconds(1);
            timerTime.Tick += new EventHandler(timer_Tick);
            timerTime.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.medPlayer.NaturalDuration.HasTimeSpan)
            {
                var TotalTime = this.medPlayer.NaturalDuration.TimeSpan;
                if (this.medPlayer.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    if (TotalTime.TotalSeconds > 0)
                    {
                        timeSlider.Value = (this.medPlayer.Position.TotalSeconds /
                                           TotalTime.TotalSeconds) * 100;
                    }
                }
            }
        }

        private void accelButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.isPlaying)
            {
                this.medPlayer.SpeedRatio += (this.medPlayer.SpeedRatio / 2);
            }
        }

        private void deccelButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.isPlaying)
            {
                this.medPlayer.SpeedRatio -= (this.medPlayer.SpeedRatio / 2);
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.isPlaying)
            {
                this.medPlayer.Pause();
                PlayButton.IsChecked = false;
                this.isPlaying = false;
            }
            else if (this.medPlayer.Source != null) {
                this.medPlayer.Play();
                PlayButton.IsChecked = true;
                this.isPlaying = true;
            }
            else
            {
                OpenButton_Click(this, null);
            }
        }

        private void validateSearch(object sender, TouchEventArgs e)
        {
            // == Recherche ==
        }

        private void dropElement(object sender, DragEventArgs e)
        {
            String[] FileName = (String[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, true);
            if (FileName.Length > 0)
            {
                String VideoPath = FileName[0].ToString();
                MessageBox.Show(VideoPath);
                this.currentList.addElement(VideoPath);
                currentPlaylist.ItemsSource = this.currentList.getNameList();
            }
            e.Handled = true;
        }

        private void SoundSlide_Click(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.medPlayer.Volume = ((Slider)sender).Value / 100;
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.medPlayer.Source != null)
            {
                if (this.medPlayer.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    this.medPlayer.Position = TimeSpan.FromSeconds(this.medPlayer.NaturalDuration.TimeSpan.TotalSeconds * (((Slider)sender).Value / 100));
                }
            }
            else
            {
                ((Slider)sender).Value = 0;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            file.Filter = "Media Files (*.wav)|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3;*.mp4;*.wmv";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == true)
            {
                if (file.FileName.Length > 0)
                {
                    MessageBox.Show(file.FileName);
                    this.currentList.addElement(file.FileName);
                    currentPlaylist.ItemsSource = this.currentList.getNameList();
                }
                e.Handled = true;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RawUpSoundButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RawDownSoundButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
