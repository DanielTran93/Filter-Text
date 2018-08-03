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
using System.Windows.Forms;
using System.IO;

namespace Filter_Text
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            List<string> accounts = new List<string>();
            string[] toSplit = input.Text.Split(new[] {splitOneText.Text}, StringSplitOptions.None);
            string[] account = toSplit[1].Split(new[] {splitTwoText.Text}, StringSplitOptions.None);
            accounts.Add(account[0]);

            foreach (var i in accounts)
            {
                accountsList.Items.Add(i);
            }

        }

        private void browseFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string[] files;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                pathLocation.Text = dialog.SelectedPath;
            }

            //files = System.IO.Directory.GetFiles(dialog.SelectedPath);


           
        }

        private void saveFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                saveLocation.Text = dialog.SelectedPath;

                using (StreamWriter outputStream = new StreamWriter(saveLocation.Text + "\\"+ "Output.csv"))
                    foreach (var item in accountsList.Items)
                    {
                        outputStream.WriteLine(item);
                    }
            }


            
        }
    }
}
