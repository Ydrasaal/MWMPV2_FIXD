﻿using System;
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

namespace WinMediaPLayer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SoundSlide_Click(object sender, RoutedEventArgs eve) {
            this.medPlayer.Volume = ((Slider)sender).Value / 100;
            //MessageBox.Show(((Slider)sender).Value.ToString());
        }

        private void ProgressBar_ValueChanged(object sender, RoutedEventArgs eve)
        {
            if (this.isPlaying)
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
            file.Filter = "Media Files (*.wav)|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3;*.wmv";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == true)
            {
                this.medPlayer.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                this.medPlayer.Source = new Uri(file.FileName);
                this.medPlayer.Play();
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
            var TotalTime = this.medPlayer.NaturalDuration.TimeSpan;
            if (this.medPlayer.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (TotalTime.TotalSeconds > 0)
                {
                    timeSlider.Value = (this.medPlayer.Position.TotalSeconds /
                                       TotalTime.TotalSeconds) * 100;
                    //MessageBox.Show((this.medPlayer.Position.TotalSeconds / TotalTime.TotalSeconds).ToString());

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
                PlayButton.Content = "Pause";
                this.isPlaying = false;
            }
            else if (this.medPlayer.Source != null) {
                this.medPlayer.Play(); 
                PlayButton.Content = "Play";
                this.isPlaying = true;
            }
            else
            {
                OpenButton_Click(this, null);
            }
        }
    }
}
