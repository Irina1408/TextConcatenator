using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextConcatenator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Parameters parameters;

        public MainWindow()
        {
            InitializeComponent();
            parameters = new Parameters();
            this.DataContext = parameters;
        }


        private void ButtonSplit_OnClick(object sender, RoutedEventArgs e)
        {
            // check on general erorrs
            if (string.IsNullOrEmpty(parameters.FilePath) || !Directory.Exists(parameters.FilePath))
            {
                MessageBox.Show("Directory path is incorrect.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(parameters.ResFileName))
            {
                MessageBox.Show("Result file path is empty. Please, write file path and try again.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (File.Exists(parameters.ResFileName))
            {
                File.Delete(parameters.ResFileName);
            }

            var sb = new StringBuilder();
            var files = Directory.GetFiles(parameters.FilePath).OrderBy(x => x).ToList();

            if (parameters.CompareByLength)
            {
                files = files.OrderBy(item => item.Length).ThenBy(x => x).ToList();
            }
           
            foreach (var fileName in files)
            {
                using (var sr = new StreamReader(fileName))
                {
                    if (sb.Length > 0)
                    {
                        sb.AppendLine(parameters.TextBetweenFiles);
                    }

                    sb.AppendLine(sr.ReadToEnd());
                }
            }

            // write to new file
            using (var sr = new StreamWriter(parameters.ResFileName))
            {
                sr.Write(sb.ToString());
            }
            
            MessageBox.Show("Separating is successfully completed!", "Complete", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
