using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DerekszoguHaromszogek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<DHaromszog> dHaromszogek = new List<DHaromszog>();

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.InitialDirectory = "";
            dialog.FileName = ""; 
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();
           
            if (result == true)
            {
                dHaromszogek.Clear();   
                hibakLista.Items.Clear();
                derekszoguLista.Items.Clear();
                kivalasztottLista.Items.Clear() ;    

                string filename = dialog.FileName;

                StreamReader reader = new StreamReader(filename);

                int sorszam = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    

                    try
                    {
                        sorszam++;
                        dHaromszogek.Add(new DHaromszog(line, sorszam));    
                    }
                    catch (Exception ex) 
                    {
                        hibakLista.Items.Add($"{sorszam}.sor: {ex.Message}");
                    }
                }

                foreach (DHaromszog d in dHaromszogek) 
                { 
                    derekszoguLista.Items.Add(d);
                }    

                reader.Close();
            }

        }

        private void derekszoguLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottLista.Items.Clear();
            kivalasztottLista.Items.Add($"Kerület = {dHaromszogek[derekszoguLista.SelectedIndex].Kerulet}");
            kivalasztottLista.Items.Add($"Terület = {dHaromszogek[derekszoguLista.SelectedIndex].Terulet}");
        }
    }
}