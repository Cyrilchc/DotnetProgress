using System;
using System.Threading.Tasks;
using System.Windows;

namespace WpfProgress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IProgress<ProgressInfo> Progress;
        public MainWindow()
        {
            InitializeComponent();
            Progress = new Progress<ProgressInfo>(progress =>
            {
                ProgressBar.Value = progress.Percentage;
                ProgressName.Text = progress.Message;
            });
        }

        async Task LaunchRocket(IProgress<ProgressInfo> progress)
        {
            progress.Report(new ProgressInfo(0, "Embarquement de l'équipage..."));
            await Task.Delay(2000);
            progress.Report(new ProgressInfo(30, "Remplissage des réservoirs..."));
            await Task.Delay(2000);
            progress.Report(new ProgressInfo(60, "Énumération de la checklist..."));
            await Task.Delay(2000);
            progress.Report(new ProgressInfo(90, "Dernière prière..."));
            await Task.Delay(2000);
            progress.Report(new ProgressInfo(100, "Décollage !"));
        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
            => await LaunchRocket(Progress);
    }

    class ProgressInfo
    {
        public ProgressInfo(int percentage, string message)
        {
            Percentage = percentage;
            Message = message;
        }
        
        public int Percentage { get; set; }
        public string Message { get; set; }
    }
}