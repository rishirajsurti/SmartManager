using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using System.Threading;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool pause_classes = true;
        bool pause_coding = true;
        bool pause_fitness = true;
        bool pause_sleep = true;
        bool pause_ent = true;
        bool pause_social = true;
        string classesTimeElapsed, codingTimeElapsed, fitnessTimeElapsed;
        string sleepTimeElapsed, entTimeElapsed, socialTimeElapsed;
        Int32 total_time = 0, classesTime = 0, codingTime=0, fitnessTime = 0;
        Int32 sleepTime = 0, entTime = 0, socialTime = 0;

        Stopwatch classesStopWatch = new Stopwatch();
        Stopwatch codingStopWatch = new Stopwatch();
        Stopwatch fitnessStopWatch = new Stopwatch();
        Stopwatch sleepStopWatch = new Stopwatch();
        Stopwatch entStopWatch = new Stopwatch();
        Stopwatch socialStopWatch = new Stopwatch();
        Stopwatch localwatch = new Stopwatch();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void classes_Click(object sender, RoutedEventArgs e)
        {
            if (!pause_classes)
            {
                Windows.Storage.ApplicationDataContainer localsettings =
                    Windows.Storage.ApplicationData.Current.LocalSettings;  
                pause_classes = true;
                classesStopWatch.Stop();
                localwatch.Stop();
                TimeSpan ts = classesStopWatch.Elapsed;
                TimeSpan ls = localwatch.Elapsed;
                string localTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                   ls.Hours, ls.Minutes, ls.Seconds);
                // Format and display the TimeSpan value.
                classesTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);

               
                this.classesTextBlock.Text = classesTimeElapsed;
                this.activity.Text = "Paused Activity: Classes";

                classesTime = ts.Hours * 12 + ts.Minutes * 60 + ts.Seconds;
                localsettings.Values["classesTime"] = classesTime;
                int local_time = ls.Hours * 12 + ls.Minutes * 60 + ls.Seconds;
               // total_time += local_time;
            //    int pc = classesTime * 100 / total_time;
//              this.classesPc.Text = pc.ToString();
                updatePercentages();
            }
            else if (pause_classes)
            {
                pause_classes = false;
                classesStopWatch.Start();
                localwatch.Reset();
                localwatch.Start();
                
                this.activity.Text = "Current Activity: Classes";
            }

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(About));
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void coding_Click(object sender, RoutedEventArgs e)
        {
            if (!pause_coding)
            {
                this.codingBtn.Opacity = 1.0;
                this.codingBtn.Background.Opacity = 1.0;
                pause_coding = true;
                codingStopWatch.Stop();
                //localwatch.Stop();
                TimeSpan ts = codingStopWatch.Elapsed;
                TimeSpan ls = localwatch.Elapsed;
                string localTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                   ls.Hours, ls.Minutes, ls.Seconds);
                // Format and display the TimeSpan value.
                codingTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                this.codingTextBlock.Text = codingTimeElapsed;
                this.activity.Text = "Paused Activity: Coding";

                codingTime = ts.Hours * 12 + ts.Minutes * 60 + ts.Seconds;
                //int local_time = ls.Hours * 12 + ls.Minutes * 60 + ls.Seconds;
                //total_time += local_time;
                //int pc = codingTime * 100 / total_time;
                //this.codingPc.Text = pc.ToString();
                updatePercentages();
            }
            else if (pause_coding)
            {
                this.codingBtn.Background.Opacity = 0.5;
                pause_coding = false;
                codingStopWatch.Start();
                //localwatch.Reset();
                //localwatch.Start();
                this.activity.Text = "Current Activity: Coding";
                this.codingBtn.Opacity = 1.0;
            }
        }

        private void classesTextBlock_Copy_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void fitness_Click(object sender, RoutedEventArgs e)
        {
            this.fitnessBtn.Background.Opacity = pause_coding ? 1.0: 0.5;
            if (!pause_fitness)
            {
                pause_fitness= true;
                fitnessStopWatch.Stop();
                //localwatch.Stop();
                TimeSpan ts = fitnessStopWatch.Elapsed;
                TimeSpan ls = localwatch.Elapsed;
                string localTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                   ls.Hours, ls.Minutes, ls.Seconds);
                // Format and display the TimeSpan value.
                fitnessTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                this.fitnessTextBlock.Text = fitnessTimeElapsed;
                this.activity.Text = "Paused Activity: Fitness";

                fitnessTime = ts.Hours * 12 + ts.Minutes * 60 + ts.Seconds;
                //int local_time = ls.Hours * 12 + ls.Minutes * 60 + ls.Seconds;
                //total_time += local_time;
                //int pc = fitnessTime * 100 / total_time;
                //this.fitnessPc.Text = pc.ToString();
                updatePercentages();
            }
            else if (pause_fitness)
            {
                pause_fitness = false;
                fitnessStopWatch.Start();
                //localwatch.Reset();
                //localwatch.Start();
                this.activity.Text = "Current Activity: Fitness";
            }
        }

        private void sleep_Click(object sender, RoutedEventArgs e)
        {
            if (!pause_sleep)
            {
                pause_sleep = true;
                sleepStopWatch.Stop();
                //localwatch.Stop();
                TimeSpan ts = sleepStopWatch.Elapsed;
                TimeSpan ls = localwatch.Elapsed;
                string localTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                   ls.Hours, ls.Minutes, ls.Seconds);
                // Format and display the TimeSpan value.
                sleepTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                this.sleepTextBlock.Text = sleepTimeElapsed;
                this.activity.Text = "Paused Activity: Sleep";

                sleepTime = ts.Hours * 12 + ts.Minutes * 60 + ts.Seconds;
                //int local_time = ls.Hours * 12 + ls.Minutes * 60 + ls.Seconds;
                updatePercentages();
            }
            else if (pause_sleep)
            {
                pause_sleep = false;
                sleepStopWatch.Start();
                //localwatch.Reset();
                //localwatch.Start();
                this.activity.Text = "Current Activity: Sleep";
            }
        }

        private void ent_Click(object sender, RoutedEventArgs e)
        {
            this.entertainmentBtn.Background.Opacity = pause_coding ? 0.5 : 1.0;
            if (!pause_ent)
            {
                pause_ent = true;
                entStopWatch.Stop();
                //localwatch.Stop();
                TimeSpan ts = entStopWatch.Elapsed;
                TimeSpan ls = localwatch.Elapsed;
                string localTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                   ls.Hours, ls.Minutes, ls.Seconds);
                // Format and display the TimeSpan value.
                entTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                this.entTextBlock.Text = entTimeElapsed;
                this.activity.Text = "Paused Activity: Entertainment";

                entTime = ts.Hours * 12 + ts.Minutes * 60 + ts.Seconds;
                //int local_time = ls.Hours * 12 + ls.Minutes * 60 + ls.Seconds;
                //total_time += local_time;
                //int pc = entTime * 100 / total_time;
                //this.entPc.Text = pc.ToString();
                updatePercentages();
            }
            else if (pause_ent)
            {
                pause_ent = false;
                entStopWatch.Start();
                //localwatch.Reset();
                //localwatch.Start();
                this.activity.Text = "Current Activity: Entertainment";
            }
        }

        private void social_Click(object sender, RoutedEventArgs e)
        {
            this.socialBtn.Background.Opacity = pause_coding ? 0.5 : 1.0;
            if (!pause_social)
            {
                pause_social = true;
                socialStopWatch.Stop();
                //localwatch.Stop();
                TimeSpan ts = socialStopWatch.Elapsed;
                TimeSpan ls = localwatch.Elapsed;
                string localTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                   ls.Hours, ls.Minutes, ls.Seconds);
                // Format and display the TimeSpan value.
                socialTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                this.socialTextBlock.Text = socialTimeElapsed;
                this.activity.Text = "Paused Activity: Social";
                socialTime = ts.Hours * 12 + ts.Minutes * 60 + ts.Seconds;
                int local_time = ls.Hours * 12 + ls.Minutes * 60 + ls.Seconds;
                //total_time += local_time;
                //int pc = socialTime * 100 / total_time;
                //this.socialPc.Text = pc.ToString();
                updatePercentages();
            }
            else if (pause_social)
            {
                pause_social = false;
                socialStopWatch.Start();
                //localwatch.Reset();
                //localwatch.Start();
                this.activity.Text = "Current Activity: Social";
            }
        }

        private void updatePercentages()
        {
            total_time = classesTime + codingTime + sleepTime + socialTime + entTime + fitnessTime;
            int pc;
            pc = 100*classesTime / total_time;
            this.classesPc.Text = pc.ToString() + "%";
            pc = 100 * codingTime / total_time;
            this.codingPc.Text = pc.ToString()+"%";
            pc = 100 * fitnessTime / total_time;
            this.fitnessPc.Text = pc.ToString() + "%";
            pc = 100 * sleepTime / total_time;
            this.sleepPc.Text = pc.ToString() + "%";
            pc = 100 * socialTime / total_time;
            this.socialPc.Text = pc.ToString() + "%";
            pc = 100 * entTime / total_time;
            this.entPc.Text = pc.ToString() + "%";
            
        }
    }
}
