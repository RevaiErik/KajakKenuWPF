using System.IO;
using System.Text;
using System.Windows;
using KajakKenuWPF;

namespace KajakKenuWPF
{
    public partial class MainWindow : Window
    {
        List<Kolcsonzes> kolcsonzesek = [];
        public MainWindow()
        {
            InitializeComponent();


            using (StreamReader be = new(path: @"..\..\..\src\kolcsonzes.txt", encoding: Encoding.UTF8))
            {
                _ = be.ReadLine();
                while (!be.EndOfStream)
                {
                    Kolcsonzes kolcsonzes = new(be.ReadLine());
                    kolcsonzesek.Add(kolcsonzes);
                }
            }
            Kolcsonzesek_Grid.ItemsSource = kolcsonzesek;
        }

        

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}